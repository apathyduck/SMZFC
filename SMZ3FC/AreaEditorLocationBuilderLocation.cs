using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{

    public enum LocationType
    {
        Location,
        SubLocation
    }

    public class AreaEditorLocationBuilderLocation
    {
        public string Name { get; private set; }

        public int Index { get; private set; }

        public LocationType TypeOfLocation { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public AreaEditorLocationBuilderLocation(string s, int i, LocationType t)
        {
            Name = s;
            Index = i;
            TypeOfLocation = t;

        }


    }
}
