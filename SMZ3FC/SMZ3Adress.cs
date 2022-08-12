using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    class SMZ3Adress
    {
        public int Address { get; set; }

        public int Value { get; set; }

        public Dictionary<int, ActiveLocation> MaskMap { get; private set; }

        public void SetValue()
        {
           

        }

    }
}
