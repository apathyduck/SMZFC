using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SMZ3FC
{
    public class MajorItemsDefinition
    {
        public List<string> MajorItems { get; private set; } = new List<string>();

        public string Name { get; private set; }

        public SMZ3XMLFileInfo ItemsFile { get; private set; }

        public string StringToHash { get; private set; }

        public string Hash { get; set; }

        public string HelpText { get; set; }

        public bool ParseError { get; private set; } = false;

        public MajorItemsDefinition(SMZ3XMLFileInfo xfi)
        {
            ItemsFile = xfi;
            Parse();
            GenHash();
        }

        public bool IsMajor(string item)
        {

          //  MajorItems.Con
            return MajorItems.Contains(item);
        }

        void Parse()
        {
            try
            {
                XDocument doc = XDocument.Parse(ItemsFile.Contents);
                XElement root = doc.Root;

                Name = root.Attribute("name").Value;
                HelpText = root.Element("Help")?.Value ?? string.Empty;

                List<string> items = new List<string>();
                
                foreach (XElement itm in root.Elements("Item"))
                {
                    MajorItems.Add(itm.Value);
                   

                }
            }
            catch
            {
                ParseError = true;
                return;
            }
        }

        void GenHash()
        {

            string[] copy = new string[MajorItems.Count()];
            MajorItems.CopyTo(copy);
            List<string> sort = new List<string>(copy);
            sort.Sort();

            StringToHash = string.Empty;
            foreach (string s in sort)
            {
                StringToHash = string.Concat(StringToHash, s);
            }


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
