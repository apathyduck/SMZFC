using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class AreaInfo : IFCPlaceInfo
    {
        public string Name { get; set; }

        public List<LocationInfo> LocationsInArea { get; set; }

        public string UniqueName { get { return Name; } }
    }
}
