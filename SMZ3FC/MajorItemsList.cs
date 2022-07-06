using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class MajorItemsList
    {
        public List<string> MajorItems { get; private set; } = new List<string>();

        public string Name { get; private set; }

        public FileInfo ItemsXMLFile { get; private set; }

        public string StringToHash { get; private set; }

        public string Hash { get; set; }

        public string HelpText { get; set; }

        public MajorItemsList(string name, FileInfo fi, List<string> mi, string help)
        {
            Name = name;
            ItemsXMLFile = fi;
            MajorItems = mi;
            HelpText = help;
            GenHash();
        }

        public MajorItemsList GetCleanCopy()
        {

            string[] copy = new string[MajorItems.Count()];
            MajorItems.CopyTo(copy);
            List<string> ci = new List<string>(copy);
            return new MajorItemsList(Name, ItemsXMLFile, ci, HelpText);
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
