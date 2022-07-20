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

        public LocationInfo Info { get; private set; }

        public AreaInfo AreaInfo { get; private set; }

        public string Name { 
            get 
            {
                if(TypeOfLocation == LocationType.Area)
                {
                    return AreaInfo.Name;
                }
                if (TypeOfLocation == LocationType.Location)
                {
                    return Info.SpoilerLocationName;
                }
                return null;
            } 
        }

        public int Index { get; private set; }

        public LocationType TypeOfLocation { get; private set; }

        public override string ToString()
        {
            if (TypeOfLocation == LocationType.Area)
            {
                return AreaInfo.Name;
            }
            if (TypeOfLocation == LocationType.Location)
            {
                return Info.Name;
            }

            return null;
        }


        public WorldEditorAreaBuilderItem(AreaInfo ai, int i)
        {
            AreaInfo = ai;
            Index = i;
            TypeOfLocation = LocationType.Area;
        }

        public WorldEditorAreaBuilderItem(LocationInfo li, int i)
        {


            Info = li;
            Index = i;
            TypeOfLocation = LocationType.Location;

        }


    }
}
