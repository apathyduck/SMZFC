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

        public static string ErrorReports { get; private set; } = string.Empty;

        public static bool HasError
        {
            get
            {
                return (!string.IsNullOrEmpty(ErrorReports));
            }
        }

        public static void ParseStructureJson(string path)
        {
            string jsontext = File.ReadAllText(path);

            try
            {
                SpoilerLocations = JsonConvert.DeserializeObject<List<LocationInfo>>(jsontext).ToDictionary(l => l.UniqueName);
            }
            catch(Exception e)
            {
                if(e is ArgumentException)
                {
                    GenerateCollisonReport(jsontext);
                }
                else
                {
                    AppendErrorMessage(e.Message);
                }

                return;

            }

            if(!EnsureUniqueAddresses(path))
            {
                return;
            }


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

        private static void GenerateCollisonReport(string jsontext)
        {
             List<LocationInfo> li = JsonConvert.DeserializeObject<List<LocationInfo>>(jsontext);
             for(int n = 0; n<li.Count-1; n++)
            {
                LocationInfo first = li[n];
                for(int m=n+1; m<li.Count; m++)
                {
                    LocationInfo second = li[m];
                    if(first.Name == second.Name )
                    {
                        string eMsg = $"Location Info {first.Name} has collison at index {n} and {m}";
                        AppendErrorMessage(eMsg);
                    }
                }
            }    


              
        }


        private static bool EnsureUniqueAddresses(string path)
        {
            bool noCollison = true;
            Dictionary<string,LocationInfo> addresses = new Dictionary<string, LocationInfo>();
            foreach (LocationInfo li in SpoilerLocations.Values)
            {
                if(string.IsNullOrEmpty(li.AddressOffsetString))
                {
                    //Don't throw an error for empties
                    continue;
                }

                string addstring = $"{li.Game}.{li.AddressOffset}.{li.Mask}";
                if (addresses.Keys.Contains(addstring))
                {
                    if(noCollison)
                    {
                        AppendErrorMessage($"Memory Addres Collisons in Location Json file at {path}. Either fix the collisons, or retrieve a new file from the GitHub Repo");
                    }
                    LocationInfo orig = addresses[addstring];
                    string eMsg = $"Addresses Collison for {orig.Name} and {li.Name}";
                    AppendErrorMessage(eMsg);
                    noCollison = false;
                }
                else
                {
                    addresses.Add(addstring, li);
                }
            }
            return noCollison;
        
        
        
        }

        private static void AppendErrorMessage(string error)
        {
            StringBuilder sb = new StringBuilder();
            if(string.IsNullOrWhiteSpace(ErrorReports))
            {
                sb.AppendLine(error);
            }
            else
            {
                sb.AppendLine(ErrorReports);
                sb.AppendLine(error);
            }

            ErrorReports = sb.ToString();
        }

        public static void WriteJson(string path)
        {
            string jsonstruc = JsonConvert.SerializeObject(SpoilerLocations.Values, Formatting.Indented);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, path), jsonstruc);
        }
    }
}
