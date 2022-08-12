using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD2SNESToy.USB2SNES.Messages
{
    [Serializable]
    public class Response
    {
        public List<string> Results { get; set; }
        public byte[] RawData { get; set; }

     

    }
}
