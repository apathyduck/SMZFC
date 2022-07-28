using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{

    public enum LocationType
    {
        Area,
        Location
    }

    public class WorldEditorAreaBuilderItem
    {


        public IFCPlaceInfo Info { get; private set; }

        public string Name 
        { 
            get 
            {
                return Info.Name;
            } 
        }

        public string Key
        {
            get
            {
                return Info.UniqueName;
            }
        }

      
        public int Index { get; private set; }

        public LocationType TypeOfLocation { get; private set; }

        public override string ToString()
        {

            return Name;
        }


        public WorldEditorAreaBuilderItem(IFCPlaceInfo pi, int i)
        {
            Info = pi;
            Index = i;
            if(pi is AreaInfo)
            {
                TypeOfLocation = LocationType.Area;    
            }
            if(pi is LocationInfo)
            {
                TypeOfLocation = LocationType.Location;
            }

        }

      

        public bool CompareInfo(IFCPlaceInfo pi)
        {
            return pi.UniqueName.Equals(Info.UniqueName);
        }


    }
}
