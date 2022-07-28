using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3FC
{
    public class WorldDefinition
    {
        
        public WorldDefinition(SMZ3XMLFileInfo wfi)
        {
       
            WorldFile = wfi;
            Parse();
            GenHash();
        }

        public string Name { get; set; }

        public SMZ3XMLFileInfo WorldFile { get; set; }

        public string HelpText { get; set; }

        public Dictionary<string, AreaDefinition> Areas { get; set; }

        public string StringToHash { get; private set; }

        public string Hash { get; private set; }

        public List<string> Tabs
        {         
            get
            {
                
                return (from areas in Areas.Values select areas.Tab).Distinct().ToList();
            }
        }

        public bool ParseError { get; private set; } = false;

        public string ErrorMessage { get; private set; }

        private Dictionary<LocationInfo, AreaDefinition> LocationLookup;

        public void Parse()
        {
            Areas = new Dictionary<string, AreaDefinition>();
            LocationLookup = new Dictionary<LocationInfo, AreaDefinition>();

            try
            {
                XDocument doc = XDocument.Parse(WorldFile.Contents);
                XElement root = doc.Root;
                HelpText = root.Element("Help")?.Value ?? string.Empty;
                Name = root.Attribute("name").Value;

                foreach (XElement areas in root.Elements("Area"))
                {
                    string name = areas.Attribute("name").Value;
                    string tab = areas.Attribute("tab").Value;

                    Dictionary<string, AreaInfo> areainfos = new Dictionary<string, AreaInfo>();
                    Dictionary<string, LocationInfo> shiftlocinfos = new Dictionary<string, LocationInfo>();

                    foreach (XElement locs in areas.Elements())
                    {
                        if (locs.Name.ToString().Equals("Loc"))
                        {
                            string areaname = locs.Value;
                            AreaInfo ai = SpoilerLogStructure.SpoilerAreas[areaname];
                            areainfos.Add(ai.UniqueName, ai);


                        }
                        else if (locs.Name.ToString().Equals("SubLoc"))
                        {
                            string locname = locs.Value;
                            LocationInfo li = SpoilerLogStructure.SpoilerLocations[locname];
                            shiftlocinfos.Add(li.UniqueName, li);
                        }
                    }


                    AreaDefinition ad = new AreaDefinition(name, tab, areainfos, shiftlocinfos);
                    Areas.Add(ad.Name, ad);
                    List<LocationInfo> locsinares = (from a in areainfos.Values from l in a.LocationsInArea select l).ToList();
                    foreach (LocationInfo li in locsinares)
                    {
                        LocationLookup.Add(li, ad);
                    }
                }

                //List<AreaDefinition> ads = Areas.Values.ToList();
                //var locs = from shift in ads

                List<LocationInfo> shifted = (from ads in Areas.Values from shift in ads.SubLocations select shift.Value).ToList();
                foreach(LocationInfo shift in shifted)
                {
                    if (LocationLookup.ContainsKey(shift))
                    {
                        LocationLookup[shift].ShiftLocation(shift);
                    }
                }
            }
            catch(Exception ex)
            {
                ParseError = true;
                ErrorMessage = $"File {WorldFile.Path} had a parsing error cannont load file.";
            }


        }
         
        private void GenHash()
        {

            foreach(AreaDefinition ad in Areas.Values)
            {
                ad.GenHash();
            }

            StringToHash = string.Empty;
            StringBuilder sb = new StringBuilder();



            List<string> sorthash = (from areas in Areas.Values select areas.StringToHash).ToList();
            sorthash.Sort();
                     
            foreach (string s in sorthash)
            {
                sb.Append(s);
                
            }

            StringToHash = sb.ToString();

            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(StringToHash);
                byte[] hash = sha.ComputeHash(textData);
                Hash = BitConverter.ToString(hash).Replace("-", String.Empty);
                Hash = Hash.Remove(8);
            }
        }
    }

}
