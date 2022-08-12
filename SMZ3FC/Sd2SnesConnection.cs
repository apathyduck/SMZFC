using Newtonsoft.Json;
using SD2SNESToy.USB2SNES.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace SMZ3FC
{

    public class Sd2SnesConnection
    {
        WebSocket mSocket = new WebSocket("ws://localhost:23074");
        EventWaitHandle mSingleMessageWait = new EventWaitHandle(false, EventResetMode.AutoReset);


        MessagePackage mCurMessage;

        public Sd2SnesConnection()
        {
            //  Configure socket handlers
            mSocket.OnOpen += MSocket_OnOpen;
            mSocket.OnClose += MSocket_OnClose;
            mSocket.OnError += MSocket_OnError;
            mSocket.OnMessage += MSocket_OnMessage;
        }


        //public Task<MessagePackage> SendMessage(MessagePackage msg)
        //{
        //    mCurMessage = msg;
        //    return Task.Run(() => Task_SendMessage(msg));
        //}

        public MessagePackage SendMessage(MessagePackage msg)
        {
            mCurMessage = msg;
            mSocket.Send(mCurMessage.RawMessage);
            //zzzz deal with timeout
            if (msg.ResponseExcpected)
            {
                mSingleMessageWait.WaitOne();
            }
           
            return mCurMessage;
        }


    
      

        private void MSocket_OnMessage(object sender, MessageEventArgs e)
        {
            Response r = new Response();
            if (e.Data != null)
            {
                r = JsonConvert.DeserializeObject<Response>(e.Data);
            }
            if (e.RawData != null)
            {
                r.RawData = e.RawData;
            }
            mCurMessage.MsgResponse = r;
    
            mSingleMessageWait.Set();
        }

        private void MSocket_OnError(object sender, ErrorEventArgs e)
        {
            System.Diagnostics.Debug.Print(e.Message);
        }

        private void MSocket_OnClose(object sender, CloseEventArgs e)
        {
            System.Diagnostics.Debug.Print("Socket Closed");
        }



        private void MSocket_OnOpen(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Socket Opened");

        }


      


        public void TryConnect()
        {
            if (mSocket.IsAlive)
                return;

            mSocket.Connect();
        }

       

        public void ReadGame()
        {
            Request r = new Request()
            {
                Opcode = OpcodeType.GetAddress.ToString(),
                Space = "SNES",
                Operands = new List<string>()


            };
            //int gamemem = 0xa173fe;
            //gamemem = GetSRAMOffset(gamemem);
            //int sdshift = 0xe00000;
            //int add = gamemem + sdshift;

            //int add = 0x7e0998;

            int WRAM_START = 0xF50000;

            int SAVEDATA_START = WRAM_START + 0xF000;
            int addoff = 0x208;

            int add = SAVEDATA_START + addoff;

            //int add = 0x7ed870;
            //int shift = 0x3;
            //add += shift;
            r.Operands.Add(add.ToString("X"));

            int one = 1;
            r.Operands.Add(one.ToString("X"));
            string jsonout = JsonConvert.SerializeObject(r);
            //PostMessage(jsonout, OnGameState);
        }


        private int GetSRAMOffset(int address)
        {
            int offset = 0x0;
            int remain_add = address - 0xa06000;
            while (remain_add >= 0x2000)
            {
                remain_add = remain_add - 0x10000;
                offset = offset + 0x2000;

            }
            return offset + remain_add;
        }

    }

}
