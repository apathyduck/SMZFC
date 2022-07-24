using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public static class SpoilerLogStructure
    {
        public static Dictionary<string, AreaInfo> SpoilerAreas { get; private set; }

        public static Dictionary<string, LocationInfo> SpoilerLocations { get; private set; }

        public static Dictionary<LocationInfo, AreaInfo> ReverseAreaLookup { get; private set; }

        public static void ParseStructureJson(string path)
        {
            string jsontext = File.ReadAllText(path);
            SpoilerLocations = JsonConvert.DeserializeObject<List<LocationInfo>>(jsontext).ToDictionary(l => l.SpoilerLocationName);
            SpoilerAreas = new Dictionary<string, AreaInfo>();
            ReverseAreaLookup = new Dictionary<LocationInfo, AreaInfo>();


            List<string> areas = (from area in SpoilerLocations.Values select area.AreaName).Distinct().ToList();
            foreach (string a in areas)
            {
                AreaInfo ai = new AreaInfo();
                ai.Name = a;

                List<LocationInfo> lis = (from loc in SpoilerLocations.Values where loc.AreaName.Equals(a) select loc).ToList();
                ai.LocationsInArea = lis;
                SpoilerAreas.Add(ai.Name,ai);
            }
            foreach(LocationInfo li in SpoilerLocations.Values)
            {
                ReverseAreaLookup.Add(li, SpoilerAreas[li.AreaName]);
            }

        }

        public static void WriteJson(string path)
        {
            string jsonstruc = JsonConvert.SerializeObject(SpoilerLocations.Values, Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, path), jsonstruc);
        }
    }
}
