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

        public Action<MessagePackage> ActionHandler { get; set; }

        public object Tag { get; set; }

        public string RawMessage { get; private set; }
    
        public MessagePackage(Request req, Action<MessagePackage> handler, object tag = null)
        {
            MsgRequest = req;
            ActionHandler = handler;
            Tag = tag;
            RawMessage = JsonConvert.SerializeObject(MsgRequest);
        }


        public void SetResponse(Response msg)
        {
            MsgResponse = msg;
            ActionHandler?.Invoke(this);
        }

    }
}
