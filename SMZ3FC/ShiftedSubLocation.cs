using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class ShiftedSubLocation
    {
        public string SubLocName { get; private set; }

        public string ShiftToGroup { get; private set; }

        public LocationInfo LocInfo {get; set; }

        public bool HasItem { get; private set; } = false;

        public string StringToHash { get; private set; }



        public ShiftedSubLocation(string n, string g)
        {
            SubLocName = n;
            ShiftToGroup = g;
            
            GenHash();
        }

        public ShiftedSubLocation GetCleanCopy()
        {
            return new ShiftedSubLocation(SubLocName, ShiftToGroup);
        }

        public void LocHasItem()
        {
            HasItem = true;
            LocInfo.IsMajor = true;
        }

        void GenHash()
        {
            StringToHash = string.Empty;
            StringToHash = string.Concat(SubLocName, ShiftToGroup);
        }

    }
}
