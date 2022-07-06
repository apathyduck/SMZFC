using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class SubLocationData
    {
        public string LocationName { get; private set; }
        public int ItemCount { get; private set;}

        public SubLocationData(string name, int count)
        {
            LocationName = name;
            ItemCount = count;
        
        }

    }
}
