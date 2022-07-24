using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;


namespace SMZ3FC
{
    public class SMZ3FCManager
    {
        
        public bool IsInitialized { get; private set; }

        public Dictionary<string, MajorItemsDefinition> ItemSets { get; private set; }

        public Dictionary<string, WorldDefinition> Worlds { get; private set; }

        public WorldState ActiveWorld { get; private set; }

        public string CurrentWorldKey
        {
            get
            {
                return CurrentWorldDefintion.Name;
            }
            set
            {
                CurrentWorldDefintion = Worlds[value];
                if (ActiveWorld != null)
                {
                    ActiveWorld.SetWorldAndReset(CurrentWorldDefintion);
                }
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
                CurrentItemList = ItemSets[value];
                if (ActiveWorld != null)
                {
                    ActiveWorld.SetItemsAndReset(CurrentItemList);
                }
            }
        }

        public WorldDefinition CurrentWorldDefintion { get; private set; }

        public MajorItemsDefinition CurrentItemList { get; private set;}

        public List<LocationInfo> AllLocationInfo { get; private set; }

        public string CurrentLogFilePath { get; private set; }

        public string CurrentCombinedHash
        {
            
            get { return CombineHashes(CurrentWorldKey, CurrentItemKey);  }
        }

        public event EventHandler SMZ3ManagerError;

        public string CombineHashes(string gk, string ik)
        {

            string tohash = string.Concat(Worlds[gk].StringToHash, ItemSets[ik].StringToHash);
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

        public void LoadLogFile(string fileloc)
        {
            ActiveWorld.SetSpoilerAndReset(LogParser.Parse(fileloc));
        }

        public void AddWorld(SMZ3XMLFileInfo fi)
        {
            WorldDefinition wd = new WorldDefinition(fi);
            if(!wd.ParseError)
            {
                Worlds.Add(wd.Name, wd);
                CurrentWorldKey = wd.Name;
            }
        }

        public void AddFile(SMZ3XMLFileInfo fi)
        {
            switch(fi.FileType)
            {
                case SMZ3XMLFileType.World:
                    AddWorld(fi);
                    break;
                case SMZ3XMLFileType.Items:
                    AddItemSet(fi);
                    break;
            }
        }

        public void RemoveWorld(string k)
        {
            if (Worlds.ContainsKey(k))
            {
                Worlds.Remove(k);
            }
        }

        public void AddItemSet(SMZ3XMLFileInfo fi)
        {
            MajorItemsDefinition md = new MajorItemsDefinition(fi);
            if (!md.ParseError)
            {
                ItemSets.Add(md.Name, md);
                CurrentItemKey = md.Name;
            }

        }

        public void RemoveItemList(string k)
        {
            if(ItemSets.ContainsKey(k))
            {
                ItemSets.Remove(k);
            }
        }

        private SMZ3FCSettings settings;

        public SMZ3FCManager(SMZ3FCSettings set)
        {
            
            settings = set;
            
            SpoilerLogStructure.ParseStructureJson(Path.Combine(Environment.CurrentDirectory, settings.LocationInfoJsonPath));
      
            FCXMLParser.DiscoverSMZ3DefinitionFiles();
            Worlds = new Dictionary<string, WorldDefinition>();
            ItemSets = new Dictionary<string, MajorItemsDefinition>();


           
           
            foreach (SMZ3XMLFileInfo files in FCXMLParser.WorldFiles.Values)
            {
                WorldDefinition wd = new WorldDefinition(files);
                Worlds.Add(wd.Name, wd);
            }

            foreach(SMZ3XMLFileInfo items in FCXMLParser.ItemFiles.Values)
            {
                MajorItemsDefinition mi = new MajorItemsDefinition(items);
                ItemSets.Add(mi.Name, mi);
            }

            if (Worlds.Count == 0)
            {
                IsInitialized = false;
                SMZ3FCManagerErrorEventArgs ea = new SMZ3FCManagerErrorEventArgs()
                {
                    ErrorMessage = $"No World Files Have Been Loaded. At least 1 World File is required to run."
                };

                SMZ3ManagerError?.Invoke(this, ea);
                return;

            }


            if (ItemSets.Count == 0)
            {
                IsInitialized = false;
                SMZ3FCManagerErrorEventArgs ea = new SMZ3FCManagerErrorEventArgs()
                {
                    ErrorMessage = $"No Item Files Have Been Loaded. At least 1 Item File is required to run."
                };

                SMZ3ManagerError?.Invoke(this, ea);
                return;
            }

            if (Worlds.Keys.Contains(settings.DefaultGroup))
            {
                CurrentWorldKey = settings.DefaultGroup;
            }
            else
            {
                CurrentWorldKey = Worlds.Keys.First();
            }


            if (ItemSets.Keys.Contains(settings.DefaultItem))
            {
                CurrentItemKey = settings.DefaultItem;
            }
            else
            {
                CurrentItemKey = ItemSets.Keys.First();
            }

            ActiveWorld = new WorldState(CurrentWorldDefintion, CurrentItemList);

        }
    }

    public class SMZ3FCManagerErrorEventArgs : EventArgs
    {
        public string ErrorMessage { get; set; }
    }
}
