using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class ActiveLocation
    {

        public event EventHandler AddressValueUpdated;
        public event EventHandler FoundUpdated;

        public string Key
        {
            get
            {
                return Info.UniqueName;
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

        public bool IsFound
        {
            get
            {
                return (Info.Mask & AddressValue) != 0;
            }
        }

        public byte AddressValue
        {
            get
            {
                return _AddressValue;
            }
            set
            {
                bool dirty = !(_AddressValue == value);
                
                if (dirty)
                {
                    bool prevFound = IsFound;
                    _AddressValue = value;
                    AddressValueUpdated?.Invoke(this, new EventArgs());
                    bool founddirty = prevFound != IsFound;
                    if(founddirty)
                    {
                        FoundUpdated?.Invoke(this, new EventArgs());
                    }

                }
            }
        }

        private byte _AddressValue;

        public ActiveLocation(LocationInfo li, SpoilerLogLocation sli, bool major)
        {
            Info = li;
            LogLocation = sli;
            IsMajor = major;
        }



    }
}
