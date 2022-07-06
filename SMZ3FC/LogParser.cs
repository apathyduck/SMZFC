using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    static class LogParser
    {

        public static List<SubLocationData> SubLocations { get; private set; }
        public static List<string> ShiftLocationsWithItems { get; private set; }

        public static string SpoilerHash { get; private set; }


        static public void Parse(string fileloc, AreaGroupings ag, MajorItemsList mil)
        {
            SubLocations = new List<SubLocationData>();
            ShiftLocationsWithItems = new List<string>();


            FileInfo fi = new FileInfo(fileloc);
            List<string> filelines = new List<string>();

            using (StreamReader sr = fi.OpenText())
            {
                string line;
                while((line= sr.ReadLine()) != null)
                {
                    filelines.Add(line);
                }

                sr.Close();
            }

            SpoilerHash =filelines[0].Trim().Remove(0,1);
            
            for(int n = 1; n<filelines.Count(); n++)
            {
                if(IsLocationHeader(filelines[n]))
                {
                    n = ParseLocation(filelines, ag, mil, n);
                }
            }
        }

       
        private static bool IsLocationHeader(string fileline)
        {
            fileline = fileline.Trim();
            return fileline[0] == '-';          
        }

        private static int ParseLocation(List<string> filelines, AreaGroupings ag, MajorItemsList mil, int n)
        {
            bool endofloc = false;
            string locname = "";
            bool foundloc = false;
            CollatedLocationData thiscld = null;

            foreach (CollatedLocationData cld in ag.Locations)
            {
                foreach (string loc in cld.SubLocations)
                {
                    if (filelines[n].Contains(loc))
                    {
                        locname = loc;
                        foundloc = true;
                        thiscld = cld;
                        break;
                    }
                }
            }

            if(!foundloc) { return n; }

            //Go to next line
            n++;
           
            string trimline;

            

            while (!endofloc)
            {
                trimline = filelines[n].Trim();
                if(trimline[0] == '-')
                {
                    endofloc = true;
                    break;
                }

                LocationInfo li = new LocationInfo();
                string itemonly = trimline.Substring(trimline.IndexOf(":")+1);
                string locationonly = trimline.Remove(trimline.IndexOf(":"));

                li.SpoilerItem = itemonly;
                li.SpoilerSubLoc = locationonly;
                li.SpoilerLine = trimline;
                li.SpoilerLocationHeader = locname;

                thiscld.ItemLines.Add(li);
                

                thiscld.AddIndivdualLocation();

                foreach (ShiftedSubLocation shift in ag.ShiftedLocations)
                {
                    if (locationonly.Contains(shift.SubLocName))
                    {
                        thiscld.RemoveIndividualLocation();
                        thiscld.ItemLines.Remove(li);
                        shift.LocInfo = li;
                    }
                }

                foreach (string k in mil.MajorItems)
                {
                    
      
                    if (itemonly.Contains(k))
                    {
                        bool isshifted = false;
                        foreach (ShiftedSubLocation shift in ag.ShiftedLocations)
                        {
                            if (locationonly.Contains(shift.SubLocName))
                            {
                                
                                shift.LocHasItem();
                                isshifted = true;

                            }

                        }
                        if(!isshifted)
                        {
                            
                            thiscld.AddTotalItem();
                            li.IsMajor = true;
                            
                        }    
                        
                    }
                }
             
                n++;
            }

            
            return n-1;
        }






    }
}
