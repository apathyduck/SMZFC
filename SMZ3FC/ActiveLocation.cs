using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class ActiveLocation
    {

        public string Key
        {
            get
            {
                return Info.Name;
            }
        }

        public string Name
        {
            get
            {
                return Info.Name;
            }
        }

        public LocationInfo Info { get; private set; }

        public SpoilerLogLocation LogLocation { get; private set; }

        public bool IsMajor { get; private set; }

        public bool IsFound { get; private set; }

        public ActiveLocation(LocationInfo li, SpoilerLogLocation sli, bool major)
        {
            Info = li;
            LogLocation = sli;
            IsMajor = major;
        }



    }
}
