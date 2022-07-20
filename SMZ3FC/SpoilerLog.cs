using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class SpoilerLog
    {
        public string LogHash { get; set; }

        public FileInfo LogFileInfo { get; set; }

        public Dictionary<string, SpoilerLogLocation> LogLocationInfos { get; set; } = new Dictionary<string, SpoilerLogLocation>();

    }
}
