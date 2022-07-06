using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace SMZ3FC
{
    public class AreaGroupings
    {

        public string Name { get; private set; }

        public FileInfo LocXmlFile { get; private set; }

        public List<CollatedLocationData> Locations { get; private set; }

        public List<ShiftedSubLocation> ShiftedLocations { get; private set; }

        public List<string> GameTabList
        {
            get
            {
                var gtl = (from loc in Locations select loc.Tab).Distinct().ToList();
                
                return gtl;
            }
        }

        public string HelpText { get; private set; }

        public int SMLocNum { get; private set; }

        public int ALTTPLocNum { get; private set; }

        public string StringToHash { get; private set; }

        public string Hash { get; private set; }

        public int TotalItemCount
        {
            get
            {
                int total = 0;
                foreach(CollatedLocationData cld in Locations)
                {
                    total += cld.TotalCount;
                }
                return total;
            }

        }

        public int CurrentItemCount
        {
            get
            {
                int cur = 0;
                foreach (CollatedLocationData cld in Locations)
                {
                    cur += cld.CurrentCount;
                }
                return cur;
            }

        }

        public int FoundItemCount
        {
            get
            {
                int total = 0;
                int cur = 0;
                foreach (CollatedLocationData cld in Locations)
                {
                    total += cld.TotalCount;
                    cur += cld.CurrentCount;
                }
                return total-cur;
            }
        }

        public AreaGroupings(string n, FileInfo fi, List<CollatedLocationData> cld, List<ShiftedSubLocation> ssl, string help)
        {
            Name = n;

            LocXmlFile = fi;
            Locations = cld;
            ShiftedLocations = ssl;
            HelpText = help;
           

            var sms = from smlocs in Locations where smlocs.Tab.Equals("SM") select smlocs;
            SMLocNum = sms.Count();
            var alttps = from alttplocs in Locations where alttplocs.Tab.Equals("ALTTP") select alttplocs;
            ALTTPLocNum = alttps.Count();

            GenHash();
        }

        public AreaGroupings GetCleanCopy()
        {
            List<CollatedLocationData> cldlist = new List<CollatedLocationData>();
            List<ShiftedSubLocation> ssllist = new List<ShiftedSubLocation>();

            foreach(CollatedLocationData cld in Locations)
            {
                cldlist.Add(cld.GetCleanCopy());
            }    
            foreach(ShiftedSubLocation ssl in ShiftedLocations)
            {
                ssllist.Add(ssl.GetCleanCopy());
            }


            return new AreaGroupings(Name, LocXmlFile, cldlist, ssllist, HelpText);
        }

        private void GenHash()
        {

            StringToHash = string.Empty;

            List<string> sorthash = new List<string>();

            foreach (CollatedLocationData cld in Locations)
            {
                sorthash.Add(cld.StringToHash);
            }
            sorthash.Sort();
            foreach(string s in sorthash)
            {
                StringToHash = string.Concat(StringToHash, s);
            }

            sorthash = new List<string>();

            foreach (ShiftedSubLocation ssl in ShiftedLocations)
            {
                sorthash.Add(ssl.StringToHash);
            }
            sorthash.Sort();
            foreach (string s in sorthash)
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
