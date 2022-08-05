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


        public Task<MessagePackage> SendMessage(MessagePackage msg)
        {
            mCurMessage = msg;
            return Task.Run(() => Task_SendMessage(msg));
        }

        private MessagePackage Task_SendMessage(MessagePackage msg)
        {

           
            mSocket.SendAsync(msg.RawMessage, MessageResponse);
            //mSocket.SendAsync(msg.RawMessage);
            ///zzz deal with timeout
           // mSingleMessageWait.WaitOne();
            msg = mCurMessage;
            mCurMessage = null;
            return msg;
        }


        public void SendMessage2(MessagePackage msg, bool response = true)
        {
            bool wtf = mSocket.IsAlive;
            mCurMessage = msg;
            mSocket.Send(mCurMessage.RawMessage);
            if(!response)
            {
                mCurMessage?.ActionHandler?.Invoke(mCurMessage);
                mCurMessage = null;
            }
        }


        private void MessageResponse(bool compl)
        {
            //???
        }

        private void MSocket_OnMessage(object sender, MessageEventArgs e)
        {
            Response r = new Response();
            if (e.Data != null)
            {
                List<string> data = JsonConvert.DeserializeObject<List<string>>(e.Data);
                r.Results = data;
            }
            if (e.RawData != null)
            {
                r.RawData = e.RawData;
            }
            mCurMessage.MsgResponse = r;
            mCurMessage.ActionHandler?.Invoke(mCurMessage);
            mCurMessage = null;
           // mSingleMessageWait.Set();
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

        private void OnDeviceList(MessageEventArgs msg)
        {
            Response resp = JsonConvert.DeserializeObject<Response>(msg.Data);

            if (resp.Results.Any())
            {
                //  Attach to the first available device
                Request req = new Request()
                {
                    Opcode = OpcodeType.Attach.ToString(),
                    Operands = new List<string>(new[] { resp.Results.First() })
                };



            }
        }

        private void OnGameState(MessageEventArgs msg)
        {
            byte[] x = msg.RawData;
        }


        public void TryConnect()
        {
            if (mSocket.IsAlive)
                return;

            mSocket.Connect();
        }

        public void GetInfo()
        {
            Request r = new Request()
            {
                Opcode = OpcodeType.Info.ToString()
            };
            // PostMessage(JsonConvert.SerializeObject(r), OnGameState);
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
