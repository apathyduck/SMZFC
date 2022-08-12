using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD2SNESToy.USB2SNES.Messages
{
    public class MessagePackage
    {
        public Request MsgRequest { get; private set; }
        public Response MsgResponse { get; set; }

        private Action<MessagePackage> ActionHandler { get; set; }

        public bool ResponseExcpected { get; private set; }

        public object Tag { get; set; }

        public string RawMessage { get; private set; }
    
        public MessagePackage(Request req, bool resp = true, Action<MessagePackage> handler = null, object tag = null)
        {
            MsgRequest = req;
            ResponseExcpected = resp;
            ActionHandler = handler;
            Tag = tag;
            RawMessage = JsonConvert.SerializeObject(MsgRequest);
        }

        public void InvokeHandler()
        {
            ActionHandler?.Invoke(this);
        }

    }
}
