//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Security.Cryptography;

//namespace SMZ3FC
//{
//    public class CollatedLocationData
//    {
//        public string Name { get; private set; }

//        public string Tab { get; private set; }

//        public int TotalCount { get; private set; } = 0;

//        public int IndividualLocs { get; private set; } = 0;

//        public int CurrentCount
//        {
//            get
//            { return mcurcount; }

//            private set
//            {
//                mcurcount = value;
//                if (mcurcount < 0)
//                {
//                    mcurcount = 0;
//                }
//                if (mcurcount > TotalCount)
//                {
//                    mcurcount = TotalCount;
//                }

//            }
//        }

//        private int mcurcount = 0;

//        public List<string> SubLocations { get; private set; }

//        public List<string> ShiftLocsIn { get; private set; }

//        public string StringToHash { get; private set; }

//        public List<LocationInfo> ItemLines { get; set; }




//        public CollatedLocationData(string name, string t, List<string> subLocs, List<string> shiftLocsin)
//        {
//            Name = name;
//            Tab = t;
//            SubLocations = subLocs;
//            ShiftLocsIn = shiftLocsin;
//            ItemLines = new List<LocationInfo>();
//            GenHash();


//        }

//        public CollatedLocationData GetCleanCopy()
//        {
//            string[] copy = new string[SubLocations.Count()];
//            SubLocations.CopyTo(copy);
//            List<string> copyloc = new List<string>(copy);

//            copy = new string[ShiftLocsIn.Count()];
//            ShiftLocsIn.CopyTo(copy);
//            List<string> copyshift = new List<string>(copy);

//            return new CollatedLocationData(Name, Tab, copyloc, copyshift);
//        }

//        public void ResetItems()
//        {
//            TotalCount = 0;
//            CurrentCount = 0;
//            IndividualLocs = 0;
//        }

//        public void RemoveTotalItem()
//        {
//            TotalCount--;
//            CurrentCount = TotalCount;
//        }

//        public void AddTotalItem()
//        {
//            TotalCount++;
//            CurrentCount = TotalCount;
//        }

//        public void AddCurrentItem()
//        {
//            CurrentCount++;
//        }

//        public void RemoveCurrentItem()
//        {
//            CurrentCount--;
//        }


//        public void AddIndivdualLocation()
//        {
//            IndividualLocs++;
//        }

//        public void RemoveIndividualLocation()
//        {
//            IndividualLocs--;
//        }

//        private void GenHash()
//        {

//            StringToHash = string.Empty;
//            string[] listcopy = new string[SubLocations.Count()];
//            SubLocations.CopyTo(listcopy);
//            List<string> listsort = new List<string>(listcopy);
//            listsort.Sort();


//            foreach (string s in listsort)
//            {
//                StringToHash = string.Concat(StringToHash, s);
//            }

//            listcopy = new string[ShiftLocsIn.Count()];
//            ShiftLocsIn.CopyTo(listcopy);
//            listsort = new List<string>(listcopy);
//            listsort.Sort();

//            foreach (string s in listsort)
//            {
//                StringToHash = string.Concat(StringToHash, s);
//            }

//        }


//    }
//}
