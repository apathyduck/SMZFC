using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{

    public enum SMZ3XMLFileType
    {
        World,
        Items
    }

    public class SMZ3XMLFileInfo
    {
        public string Name { get; set; }

        public string Path
        {
            get
            {
                return Info.FullName;
            }
            set
            {
                Info = new FileInfo(value);
            }
        }

        public string ServerURl { get; set; }
        public string Contents { get; set; }

        public FileInfo Info { get; set; }

        public SMZ3XMLFileType FileType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
