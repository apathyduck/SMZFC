using SD2SNESToy.USB2SNES;
using SD2SNESToy.USB2SNES.Messages;
using SMZ3FC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SMZ3FC
{
    class AutotrackingManager
    {

        private int mCircularCounterIndex = 0;
        private int mLocInfoListCount = 0;
        private WorldState mStateOwner;
        private Thread mRunTrackingThread;
        private bool mRunThread;


        EventWaitHandle mRunTrackingThreadFinished;
        EventWaitHandle mFinializedInit;
        //zzzz set from settings
        int WRAM_START = 0xF50000;
        private int SAVEDATA_START { get { return WRAM_START + 0xF000; } }
        private int mAddressStart;
        Dictionary<int, int> mMemoryMap;
        Sd2SnesConnection mConnection;
       

        public AutotrackingManager()
        {
            mRunTrackingThread = new Thread(TrackingThread);
            mConnection = new Sd2SnesConnection();
            mRunTrackingThreadFinished = new EventWaitHandle(false, EventResetMode.AutoReset);
            mFinializedInit = new EventWaitHandle(false, EventResetMode.AutoReset);

        }


        public void Initialize(WorldState curWorld)
        {

            mConnection.TryConnect();

            Thread.Sleep(1000);


            SetAppName();

         //   mFinializedInit.WaitOne();
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
            var memlist = (from locs in mStateOwner.AllActiveLocations.Values select locs.Info.AddressOffset).Distinct();
            mMemoryMap = new Dictionary<int, int>();
            foreach (int mem in memlist)
            {
                mMemoryMap.Add(mem, 0);
            }

         
        }

        public void StartTrackingThread()
        {
            mRunTrackingThread = new Thread(TrackingThread);
            mRunThread = true;
            mRunTrackingThread.Start();
        }



        private async void TrackingThread()
        {

            mCircularCounterIndex = 0;
            mLocInfoListCount = mStateOwner.AllActiveLocations.Count - 1;

            while (mRunThread)
            {

                int memvalue = mMemoryMap.ElementAt(mCircularCounterIndex).Key;
                MessagePackage mh = CreateMemoryRequest(memvalue, 1);
                mh = await mConnection.SendMessage(mh);

                mCircularCounterIndex++;
                mCircularCounterIndex %= mLocInfoListCount;
            }
            mRunTrackingThreadFinished.Set();

        }

        private MessagePackage CreateMemoryRequest(int mem, int size)
        {
            Request req = new Request();


            req.Opcode = OpcodeType.GetAddress.ToString();
            req.Space = "SNES";

            List<string> ops = new List<string>();
            int add = mAddressStart + mem;
            ops.Add(add.ToString("X"));
            ops.Add(size.ToString("X"));

            return new MessagePackage(req, MemoryMessageResponse);


        }


        private void MemoryMessageResponse(MessagePackage msg)
        {

        }

        private void SetAppName()
        {

            Request req = new Request()
            {
                Opcode = OpcodeType.Name.ToString(),
                Operands = new List<string>(new[] { "SMZ3FC" })
            };
            MessagePackage mp = new MessagePackage(req, FindDevices);
            mConnection.SendMessage2(mp, false);
        }




        private void FindDevices(MessagePackage msg)
        {

            // Retrieve device list
            Request devreq = new Request()
            {
                Opcode = OpcodeType.DeviceList.ToString(),
                Space = "SNES"
            };
            MessagePackage devicemp = new MessagePackage(devreq, AttachDevice);
            mConnection.SendMessage2(devicemp);

            //zzz handle error
           
        }

        private void AttachDevice(MessagePackage msg)
        {
            if (msg.MsgResponse.Results.Any())
            {
                //zzz allow user to chose device
                string device = msg.MsgResponse.Results.First();

                //  Attach to the first available device
                Request attachreq = new Request()
                {
                    Opcode = OpcodeType.Attach.ToString(),
                    Operands = new List<string>(new[] { device })
                };
                MessagePackage attachmp = new MessagePackage(attachreq, FinalizeInit);
               mConnection.SendMessage2(attachmp, false);
            }
        }

        private void FinalizeInit(MessagePackage msg)
        {

            mFinializedInit.Set();
        }

        private void FindFullMemoryMask()
        {
            int fullmask = 0;
            foreach (int mem in mMemoryMap.Keys)
            {
                fullmask = fullmask ^ (1 << mem);
            }


        }

       
    }
}
