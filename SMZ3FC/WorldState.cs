using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class WorldState
    {

        public bool IsInitialized { get; private set; }
        public Dictionary<string, ActiveArea> Areas { get; private set; }

        public MajorItemsDefinition CurrentItems { get; private set; }

        public ActiveArea PrimaryArea { get; private set; }

        public string ItemsKey
        { 
            get
            {
                return CurrentItems.Name;
            }
        }

        public string WorldKey
        {
            get
            {
                return CurrentWorld.Name;
            }
        }

        public string CombinedHash { get; }

        public WorldDefinition CurrentWorld { get; private set; }

        public string AreaHelpText
        {
            get
            {
                return CurrentWorld.HelpText;
            }

        }

        public string ItemsHelpText
        {
            get
            {
                return CurrentItems.HelpText;
            }
        }

        public SpoilerLog CurrentLog { get; private set; }

        public int TotalItems
        {
            get
            {
                return (from areas in Areas.Values select areas.TotalItems).Sum();
            }
        }

        public int FoundItems
        {
            get
            {
                return (from areas in Areas.Values select areas.FoundItems).Sum();
            }
        }

        public event EventHandler PrimaryAreaUpdated;

        public void SetPrimaryArea(ActiveArea aa)
        {
            ActiveArea prevActive = PrimaryArea;
            PrimaryArea = aa;
            prevActive?.UpdatePrimary();
            PrimaryAreaUpdated?.Invoke(this, new EventArgs());
        }

        public WorldState(WorldDefinition world, MajorItemsDefinition mi)
        {
            CurrentWorld = world;
            CurrentItems = mi;
            
        }

        public void SetWorldAndReset(WorldDefinition world)
        {
            CurrentWorld = world;
            Reset();
        }

        public void SetSpoilerAndReset(SpoilerLog log)
        {
            IsInitialized = true;
            CurrentLog = log;
            Reset();
        }

        public void SetItemsAndReset(MajorItemsDefinition mi)
        {
            CurrentItems = mi;
            Reset();
        }

        private void Reset()
        {
            if (!IsInitialized)
            {
                return;
            }

            Areas = new Dictionary<string, ActiveArea>();
            foreach (AreaDefinition ad in CurrentWorld.Areas.Values)
            {
                ActiveArea aa = new ActiveArea(ad, CurrentLog, this);              
                Areas.Add(aa.Name, aa);
            }

            PrimaryArea = null;

        }

   
    }
}
