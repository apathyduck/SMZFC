using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class AreaItemManager
    {
        public Dictionary<string, AreaGroupings> Groupings { get; private set; }

        public Dictionary<string, MajorItemsList> ItemsList { get; private set; }

        public string CurrentGroupKey
        {
            get
            {
                return CurrentGroup.Name;
            }
            set
            {
                CurrentGroup = Groupings[value];

            }

        }

        public string CurrentItemKey
        {
            get
            {
                return CurrentItemList.Name;
            }
            set
            {
                CurrentItemList = ItemsList[value];
            }
        }

        public AreaGroupings CurrentGroup { get; private set; }

        public MajorItemsList CurrentItemList { get; private set;}

    
        public string CurrentLogFilePath { get; private set; }

        public string CurrentCombinedHash
        {
            
            get { return CombineHashes(CurrentGroupKey, CurrentItemKey);  }
        }

        public string CombineHashes(string gk, string ik)
        {

            string tohash = string.Concat(Groupings[gk].StringToHash, ItemsList[ik].StringToHash);
            string finalhash = string.Empty;
            using (var sha = new SHA256Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(tohash);
                byte[] hash = sha.ComputeHash(textData);
                finalhash = BitConverter.ToString(hash).Replace("-", String.Empty);
                finalhash = finalhash.Remove(8);
            }

            return finalhash;

        }

        public bool ParseLog(string fileloc)
        {
            try
            {
                CurrentGroup = Groupings[CurrentGroupKey].GetCleanCopy();
                CurrentItemList = ItemsList[CurrentItemKey].GetCleanCopy();

                LogParser.Parse(fileloc, CurrentGroup, CurrentItemList);

                foreach (ShiftedSubLocation ssl in CurrentGroup.ShiftedLocations)
                {

                    var loc = (from l in CurrentGroup.Locations where l.Name.Equals(ssl.ShiftToGroup) select l).First();
                    loc.AddIndivdualLocation();

                    if (ssl.HasItem)
                    {
                        
                        loc.AddTotalItem();
                        
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveGroup(string k)
        {
            if (Groupings.ContainsKey(k))
            {
                Groupings.Remove(k);
            }
        }

        public void RemoveItemList(string k)
        {
            if(ItemsList.ContainsKey(k))
            {
                ItemsList.Remove(k);
            }
        }

        public AreaItemManager(SMZ3FCSettings set)
        {

            (Groupings, ItemsList) = FCXMLParser.LoadLocationData();
            try
            {
                CurrentGroupKey = set.DefaultGroup;
            }
            catch
            {
                CurrentGroupKey = Groupings.Keys.First();
            }
            try
            {
                CurrentItemKey = set.DefaultItem;
            }
            catch
            {
                CurrentItemKey = ItemsList.Keys.First();
            }

            CurrentGroup = Groupings[CurrentGroupKey].GetCleanCopy();
            CurrentItemList = ItemsList[CurrentItemKey].GetCleanCopy();

        }

        


    }
}
