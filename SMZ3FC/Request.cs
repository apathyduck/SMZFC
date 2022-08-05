using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD2SNESToy.USB2SNES.Messages
{
    public enum OpcodeType
    {
        // Error handling is done via the underlying WebSocket protocol which disconnects the socket.

        // Connection
        DeviceList, // Request: Operands: null,                                   Response: Operands[stringList]
        Attach,     // Request: Operands: [COM#],                                 NoResponse
        AppVersion, // Request: Operands: null,                                   Response: Operands[stringList]
        Name,       // Request: Operands: [name],                                 NoResponse

        // Special
        Info,       // Request: Operands: null,                                   Response: Result: [versionString, version#]
        Boot,       // Request: Operands: [filename],
        Menu,       // Request: Operands: null,
        Reset,      // Request: Operands: null,
        Stream,     // Request: Operands: null,
        Fence,      // Request: Operands: null,

        // Address space access
        GetAddress, // Request: Operands: [address,size],                         Data: [data]
        PutAddress, // Request: Operands: [address,size],    Data: [data]
        PutIPS,     // Request: Operands: [""/"hook",size],  Data: [data]

        // File system access
        GetFile,    // Request: Operands: [filename],                             Data: [data]
        PutFile,    // Request: Operands: [filename],        Data: [data]
        List,       // Request: Operands: null,                                   Response: Operands[stringList]
        Remove,     // Request: Operands: [filename],
        Rename,     // Request: Operands: [filename0,filename1]
        MakeDir,    // Request: Operands: [filename],
    }

    /// <summary>
    /// Request interface
    /// </summary>
    [Serializable]
    public class Request
    {
        public string Opcode;
        public string Space;
        public List<string> Flags;
        public List<string> Operands;
       
    }
}
