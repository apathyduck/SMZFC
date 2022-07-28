using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class AreaDefinition
    {
        public string Name { get; private set; }

        public string Tab { get; private set; }

        public Dictionary<string, AreaInfo> SpoilerAreas { get; private set; }

        public  Dictionary<string, LocationInfo> SubLocations { get; private set; }

        public Dictionary<string, LocationInfo> FullLocationList
        {
            get
            {
                List<LocationInfo> areali = (from area in SpoilerAreas from locs in area.Value.LocationsInArea select locs).ToList();
                areali.RemoveAll(IsRemoved);
                areali.AddRange(SubLocations.Values);
                return areali.ToDictionary(l => l.UniqueName);
            }

        }

        public int TotalLocations { get { return FullLocationList.Count; } }

        public string StringToHash
        {
            get
            {
                return GenHash();
            }
        }
        private List<LocationInfo> RemovedSubLocations = new List<LocationInfo>();

        public AreaDefinition(string n, string t, Dictionary<string,AreaInfo> ai, Dictionary<string,LocationInfo> li)
        {
            Name = n;
            Tab = t;
            SpoilerAreas = ai;
            SubLocations = li;
        }


        public void ShiftLocation(LocationInfo li)
        {
            RemovedSubLocations.Add(li);
        }

        private bool IsRemoved(LocationInfo li)
        {
            return RemovedSubLocations.Contains(li);
        }

        public string GenHash()
        {
            

            List<string> sorthash = (from locs in FullLocationList select locs.Value.UniqueName).ToList();
           
            sorthash.Sort();
            StringBuilder sb = new StringBuilder();
            foreach (string s in sorthash)
            {
                sb.Append(s);
            }

            return sb.ToString();

        
        }

    }
}
