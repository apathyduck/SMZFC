using SD2SNESToy.USB2SNES.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SMZ3FC
{

    enum GameState
    {
        ALTTP,
        SM,
        Indeterminate,
        Disconnected,
        NoDebug
    }

    enum ConnectionType
    {
        Sd2Snes,
        Bizhawk
        
    }

    class AutotrackingManager
    {




        private bool mRunThread;
        private GameState mCurGameState = GameState.Indeterminate;
        private GameState mPrevGameState = GameState.Indeterminate;


        private ConnectionType mConnectionType = ConnectionType.Sd2Snes;


        private const uint BIZHAWK_OFFSET = 0x700000;
        private const uint SD2SNESS_OFFSET = 0xe00000;

        private const uint GAME_STATE_ADD = 0xa173fe;
        private const byte IN_SM = 0xFF;
        private const byte IN_ALTTP = 0x00;


        private const uint WRAM_START = 0xF50000;


        private const uint SM_OFFSET = 0x7ed870;
        private const uint ALTTP_OFFSET = 0xF000;
        
        private const uint SRAM_START = 0x7e0000;

        private const uint ALTTP_LOCDATA_START = WRAM_START + ALTTP_OFFSET;
        private const uint SM_LOCDATA_START = SM_OFFSET - SRAM_START + WRAM_START;


        private const uint SM_SRAM_OFFSET = 0xa16010;
        private const uint ALTTP_SRAM_OFFSET = 0xa06000;

        private const uint SM_SRAM_LOC = 0xb0;
        private const uint ALTTP_SRAM_LOC = 0x0;

       

        private uint mGameStateAddress = 0;
        private uint mALTTPSRAMAdd = 0;
        private uint mSMSRAMAdd = 0;



        private WorldState mStateOwner;
        
        private Thread mRunTrackingThread;
        private Thread mSramUpdateThread;


        EventWaitHandle mRunTrackingThreadFinished;
        EventWaitHandle mSramUpdateWaiter;
        EventWaitHandle mThrottleWait;


        bool mUpdateSram = false;
        bool mSramStart = false;

        List<AutoTrackingMemoryBlock> mAlttpBlocks;
        List<AutoTrackingMemoryBlock> mSmBlocks;

        AutoTrackingMemoryBlock mCurAlttpBlock;
        AutoTrackingMemoryBlock mCurSmBlock;

        AutoTrackingMemoryBlock mSramReadStartBlock;

    
        Sd2SnesConnection mConnection;

        StringBuilder mErrorBuilder = new StringBuilder();


        //Update SRAM once every 5 minutes
        public int SRAMUpdateTimer { get; set; } = 1000 * 60 * 5;

        public int ThrottleTimer { get; set; } = 0;
        private bool IsThrottled { get { return ThrottleTimer > 0; } }

        public GameState DebugMode = GameState.NoDebug;

        public AutotrackingManager()
        {
            mRunTrackingThread = new Thread(TrackingThread);
            mConnection = new Sd2SnesConnection();
            mRunTrackingThreadFinished = new EventWaitHandle(false, EventResetMode.AutoReset);
            mSramUpdateWaiter = new EventWaitHandle(false, EventResetMode.AutoReset);
            mThrottleWait = new EventWaitHandle(false, EventResetMode.AutoReset);

            //zzzz for testing allow this sto be setable
            DebugMode = GameState.ALTTP;
        }



        public void Initialize(WorldState curWorld, ConnectionType ct = ConnectionType.Sd2Snes)
        {

            mConnection.TryConnect();
            mConnectionType = ct;

            mGameStateAddress = MapSRAMAddress(GAME_STATE_ADD);
            mALTTPSRAMAdd = MapSRAMAddress(ALTTP_SRAM_LOC + ALTTP_SRAM_OFFSET);
            mSMSRAMAdd = MapSRAMAddress(SM_SRAM_LOC + SM_SRAM_OFFSET);

            SetAppName();
            List<string> devices = FindDevices();

            //zzzz give option to users/populate from user data
            AttachDevice(devices[0]);

            SetOwnerAndReset(curWorld);
        }



        public void SetOwnerAndReset(WorldState curWorld)
        {
            mRunThread = false;
            if (mRunTrackingThread?.IsAlive ?? false)
            {
                mRunTrackingThreadFinished.WaitOne();
            }
           
            mStateOwner = curWorld;
            
       
            List<ActiveLocation> alsAlttp  = (from al in curWorld.AllActiveLocations.Values where al.Info.Game.Equals("ALTTP") select al).ToList();
            List<ActiveLocation> alsSM = (from al in curWorld.AllActiveLocations.Values where al.Info.Game.Equals("SM") select al).ToList();
            
            alsAlttp.Sort(CompareLocAddress);
            alsSM.Sort(CompareLocAddress);
           
            int CompareLocAddress(ActiveLocation a, ActiveLocation b)
            {
                if(a.Info.AddressOffset > b.Info.AddressOffset)
                {
                    return 1;
                }
                if(a.Info.AddressOffset < b.Info.AddressOffset)
                {
                    return -1;
                }
                if(a.Info.AddressOffset == a.Info.AddressOffset)
                {
                    if(a.Info.Mask > b.Info.Mask)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                return 0;
            }

            mAlttpBlocks = new List<AutoTrackingMemoryBlock>();
            mSmBlocks = new List<AutoTrackingMemoryBlock>();

            CreateMemoryBlocks(alsAlttp, mAlttpBlocks);
            CreateMemoryBlocks(alsSM, mSmBlocks);

            void CreateMemoryBlocks(List<ActiveLocation> als, List<AutoTrackingMemoryBlock> block)
            {

            
                AutoTrackingMemoryBlock mb = new AutoTrackingMemoryBlock(null);
                AutoTrackingMemoryBlock newMb;
                block.Add(mb);
                foreach(ActiveLocation al in als)
                {

                    newMb = mb.AddMemoryLocation(al);
                    if(newMb != mb)
                    {
                        block.Add(newMb);
                    }

                    mb = newMb;
                   
                }


                //Finalize the last block and stitch the loop together
                mb.CreateChunks();

                AutoTrackingMemoryBlock first = block.First();
                AutoTrackingMemoryBlock last = block.Last();
                first.PreviousBlock = last;
                last.NextBlock = first;

            }
        }

        public void StartTrackingThread()
        {
            if(mRunThread)
            {
                return; 
            }
            mRunTrackingThread = new Thread(TrackingThread);
            mSramUpdateThread = new Thread(SramTimerThread);
            mRunThread = true;
            mRunTrackingThread.Start();
            mSramUpdateThread.Start();
        }


        private void SramTimerThread()
        {
            while (mRunThread)
            {
                bool kicked = mSramUpdateWaiter.WaitOne(SRAMUpdateTimer);
                if (!kicked && DebugMode == GameState.NoDebug)
                {
                    mSramStart = mUpdateSram = true;
                }
            }

        }

        private void TrackingThread()
        {
            mCurAlttpBlock = mAlttpBlocks.First();
            mCurSmBlock = mSmBlocks.First();


            while (mRunThread)
            {

                if (DebugMode == GameState.NoDebug)
                {
                    ReadGame();
                }
                else
                {
                    mCurGameState = DebugMode;
                }


                if (mCurGameState != mPrevGameState)
                {
                    mPrevGameState = mCurGameState;
                    //kick the timer to reset it
                    mSramUpdateWaiter.Set();
                }

                switch (mCurGameState)
                {
                    case GameState.ALTTP:
                        if (mUpdateSram)
                        {
                            if (mSramStart)
                            {
                                mSramReadStartBlock = mCurSmBlock;
                                mSramStart = false;
                            }
                            mCurSmBlock = RunBlock(mCurSmBlock, mSMSRAMAdd);
                           
                        }
                        else
                        {
                            mCurAlttpBlock = RunBlock(mCurAlttpBlock, ALTTP_LOCDATA_START);
                        }
                        break;

                    case GameState.SM:
                        if(mUpdateSram)
                        {
                            if (mSramStart)
                            {
                                mSramReadStartBlock = mCurAlttpBlock;
                                mSramStart = false;
                            }
                            mCurAlttpBlock = RunBlock(mCurAlttpBlock, mALTTPSRAMAdd);
                            
                        }
                        else
                        {
                            mCurSmBlock = RunBlock(mCurSmBlock, SM_LOCDATA_START);
                        }
                        break;

                    default:
                        //If were indeterminate just continue reading state until we find out where we are
                        mPrevGameState = mCurGameState;                        
                        continue;
                }
                if(IsThrottled)
                {
                    mThrottleWait.WaitOne(ThrottleTimer);
                }
            }
            mRunTrackingThreadFinished.Set();

            AutoTrackingMemoryBlock RunBlock(AutoTrackingMemoryBlock curBlock, uint startAdd)
            {
                MessagePackage msgMem = CreateMemoryRequest(curBlock.InitialAddressOffset + startAdd, curBlock.BlockSize);
                msgMem = mConnection.SendMessage(msgMem);
                curBlock.SetMemoryValue(msgMem.MsgResponse.RawData);

                if (mUpdateSram && curBlock.NextBlock.Equals(mSramReadStartBlock))
                {
                    mUpdateSram = false;
                }
                return curBlock.NextBlock;
            }
        }

        private MessagePackage CreateMemoryRequest(uint mem, uint size)
        {
            Request req = new Request()
            {
                Opcode = OpcodeType.GetAddress.ToString(),
                Space = "SNES",
                Operands = new List<string>()
            };
       
            //int add = SAVEDATA_START + mem;
            req.Operands.Add(mem.ToString("X"));
            req.Operands.Add(size.ToString("X"));

            return new MessagePackage(req);
        }

        private void SetAppName()
        {

            Request req = new Request()
            {
                Opcode = OpcodeType.Name.ToString(),
                Operands = new List<string>(new[] { "SMZ3FC" })
            };
            MessagePackage mp = new MessagePackage(req, false);
            mConnection.SendMessage(mp);
        }


        private List<string> FindDevices()
        {

            // Retrieve device list
            Request devreq = new Request()
            {
                Opcode = OpcodeType.DeviceList.ToString(),
                Space = "SNES"
            };
            MessagePackage devicemp = new MessagePackage(devreq);
            devicemp = mConnection.SendMessage(devicemp);
            return devicemp.MsgResponse.Results;

        }

        private void AttachDevice(string dName)
        {

            Request attachreq = new Request()
            {
                Opcode = OpcodeType.Attach.ToString(),
                Operands = new List<string>(new[] { dName })
            };
            MessagePackage attachmp = new MessagePackage(attachreq, false);
            mConnection.SendMessage(attachmp);

        }

        public void ReadGame()
        {
            MessagePackage gameState = CreateMemoryRequest(mGameStateAddress, 1);
            gameState = mConnection.SendMessage(gameState);

            byte state = gameState.MsgResponse.RawData[0];

            switch(state)
            {
                case IN_ALTTP:
                    mCurGameState = GameState.ALTTP;
                    break;
                case IN_SM:
                    mCurGameState = GameState.SM;
                    break;
                default:
                    mCurGameState = GameState.Indeterminate;
                    break;
            }
        }

      


        private uint MapSRAMAddress(uint address)
        {
            uint typeoffset = 0;
            switch(mConnectionType)
            {
                case ConnectionType.Sd2Snes:
                    typeoffset = SD2SNESS_OFFSET;
                    break;
                case ConnectionType.Bizhawk:
                    typeoffset = BIZHAWK_OFFSET;
                    break;
                default:
                    typeoffset = SD2SNESS_OFFSET;
                    break;
            }
                
            uint offset = 0x0;
            uint remain_add = address - 0xa06000;
            while (remain_add >= 0x2000)
            {
                remain_add = remain_add - 0x10000;
                offset = offset + 0x2000;

            }
            return offset + remain_add + typeoffset;
        }

    }
}
