using System;
using System.Collections.Generic;
using SMZ3FC;
using Newtonsoft.Json;
using System.IO;

namespace CreateFriendlyJSONNames
{
    class Program
    {
        static void Main(string[] args)
        {


            //List<FriendlyLocData> fld= new List<FriendlyLocData>();
            //foreach(string l in LocationAndItemKeys.SubLocations)
            //{
            //    FriendlyLocData f = new FriendlyLocData()
            //    {
            //        spoilername = l,
            //        use = true,
            //        friendlyname = string.Empty
            //    };
            //    fld.Add(f);
            //}


            string jsonfile = File.ReadAllText(@"C:\Users\negli\source\repos\SMZ3FC\SMZ3FC\FriendlyLocNames.json");
            List<FriendlyLocData> flds = JsonConvert.DeserializeObject<List<FriendlyLocData>>(jsonfile);



            FileInfo fi = new FileInfo(@"C:\Users\negli\source\repos\SMZ3FC\SMZ3FC\Super Metroid & A Link to the Past Combo Randomizer v11.3 - JS59lphZSYOs0-EGDqt_zQ - Spoiler.txt");
            List<string> filelines = new List<string>();

            using (StreamReader sr = fi.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    filelines.Add(line);
                }

                sr.Close();
            }

            string trimline;

           
            for (int n = 0; n < filelines.Count; n++)
            {
                trimline = filelines[n].Trim();
                if (trimline[0] == '-')
                {
                    bool endofloc = false;
                    n++;
                    if (n >= filelines.Count)
                    {
                        break;
                    }
                    string locname = trimline.Substring(1);
                    locname = locname.Remove(locname.Length - 1);
                    while(!endofloc)
                    {
                        if (n >= filelines.Count)
                        {
                            break;
                        }
                        trimline = filelines[n].Trim();
                        if (trimline[0] == '-')
                        {
                            endofloc = true;
                            n--;
                            break;
                        }

                        string locationonly = trimline.Remove(trimline.IndexOf(":"));
                        foreach(FriendlyLocData fld in flds)
                        {
                            if(fld.spoilername.Equals(locationonly))
                            {
                                fld.areaname = locname;
                                break;
                            }
                        }
                        n++;

                    }

                }

            }

            string newfile = Path.Combine(Environment.CurrentDirectory, "newfrieldly.json");
            string newjson = JsonConvert.SerializeObject(flds, Formatting.Indented);
            File.WriteAllText(newfile, newjson);
        }
    }
}
