using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpoilerLogSplitter
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> mainlocs = new List<string>();
            List<string> sublocs = new List<string>();
            List<string> items = new List<string>();

            string path = @"D:\Users\Wookiee\Downloads\Super Metroid & A Link to the Past Combo Randomizer v11.3 - KkKWTZo4Rk2Br47N5hcZIw - Spoiler.txt";
            List<string> filelines = new List<string>();
            FileInfo fi = new FileInfo(path);
            using (StreamReader sr = fi.OpenText())
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    filelines.Add(line);
                }

                sr.Close();
            }

            string startoflogkey = "Light World Death Mountain West";

            string[] copy = new string[filelines.Count];
            filelines.CopyTo(copy);
            List<string> filelinescopy = new List<string>(copy);

            foreach(string s in filelines)
            {
                if(s.Contains(startoflogkey))
                {
                    break;
                }

                filelinescopy.Remove(s);
            }

            string endoffile = "- Meta:";

            foreach (string s in filelinescopy)
            {
                if(s.Contains(endoffile))
                {
                    break;
                }
                string trimline = s.Trim();
                
                if(trimline[0] == '-')
                {

                    int i = trimline.IndexOf('-');
                    trimline = trimline.Remove(i, 1);
                    i = trimline.IndexOf(':');
                    trimline = trimline.Remove(i, 1);
                    trimline = trimline.Trim();
                    mainlocs.Add(trimline);
                   

                }
                else 
                {
                    int i = trimline.IndexOf(':');
                    string subloc = trimline.Remove(i);
                    subloc = subloc.Trim();
                    string item = trimline.Substring(i+1);
                    item = item.Trim();
                    sublocs.Add(subloc);
                    if(!items.Contains(item))
                    {
                        items.Add(item);
                    }    
                
                
                }
            }

            StringBuilder locslistline = new StringBuilder();

            locslistline.AppendLine("List<string> Locations = new List<string>()");
            locslistline.AppendLine("{");
            foreach(string s in mainlocs)
            {
                locslistline.AppendLine($@"""{s}"",");
            }
            locslistline.Remove(locslistline.Length-3,1);
            locslistline.AppendLine("};");


            StringBuilder sublocslistline = new StringBuilder();
            sublocslistline.AppendLine("List<string> SubLocations = new List<string>()");
            sublocslistline.AppendLine("{");
            foreach (string s in sublocs)
            {
                locslistline.AppendLine($@"""{s}"",");
            }
            sublocslistline.Remove(sublocslistline.Length - 3, 1);
            sublocslistline.AppendLine("};");

            StringBuilder itemslistline = new StringBuilder();
            itemslistline.AppendLine("List<string> Items = new List<string>()");
            itemslistline.AppendLine("{");
            foreach (string s in items)
            {
                itemslistline.AppendLine($@"""{s}"",");
            }
            itemslistline.Remove(itemslistline.Length - 3, 1);
            itemslistline.AppendLine("};");


            using (StreamWriter sw = new StreamWriter("locscode.txt"))
            {

                sw.WriteLine(locslistline.ToString());
                sw.WriteLine(sublocslistline.ToString());
                sw.WriteLine(itemslistline.ToString());
                sw.Close();
            }
        }
    }
}
