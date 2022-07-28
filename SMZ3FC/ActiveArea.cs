using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{
    public class ActiveArea
    {


        public string Name
        {
            get
            {
                return CurrentArea.Name;

            }
        }

        public string Tab

        {
            get
            {
                return CurrentArea.Tab;
            }
        }

        public AreaDefinition CurrentArea { get; set; }

        public int TotalItems
        {
            get
            {
                return (from locs in CurrentLocations.Values where locs.IsMajor select locs).Count();
            }
        }

        public int CurrentItems
        {
            get
            {
                return TotalItems - FoundItems;
            }
        }

        public int FoundItems
        {
            get
            {
                return mfounditems;
            }
            set
            {
                if (value > TotalItems)
                {
                    mfounditems = TotalItems;

                }
                else if (value < 0)
                {
                    mfounditems = 0;
                }
                else
                {
                    mfounditems = value;
                }
                ItemCountUpdate?.Invoke(this, new EventArgs());
            }
        }

        private int mfounditems = 0;

        public int LocationCount
        {
            get
            {
                return CurrentLocations.Count;
            }
        }

        public bool IsPrimary
        {
            get
            {
                return StateOwner.PrimaryArea?.Equals(this) ?? false;
            }
        }

        public void SetAsPrimary()
        {
            if (StateOwner.PrimaryArea?.Equals(this) ?? false)
            {
                return;
            }
            StateOwner.SetPrimaryArea(this);
            UpdatePrimary();
        }

        public void UpdatePrimary()
        {
            PrimaryAreaUpdate?.Invoke(this, new EventArgs());
        }

        public event EventHandler PrimaryAreaUpdate;

        public event EventHandler ItemCountUpdate;

        public Dictionary<string, ActiveLocation> CurrentLocations { get; set; }

        public string LocationTextString
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                foreach (ActiveLocation loc in CurrentLocations.Values)
                {
                    sb.AppendLine(loc.Name);
                }

                return sb.ToString();
            }
        }
        public void ItemFound()
        {
            FoundItems++;
        }

        public void ItemReplace()
        {
            FoundItems--;
        }

        private WorldState StateOwner;

        public ActiveArea(AreaDefinition ad, SpoilerLog sl, WorldState state)
        {
            StateOwner = state;
            CurrentArea = ad;
            CurrentLocations = new Dictionary<string, ActiveLocation>();
          
            foreach (LocationInfo loc in ad.FullLocationList.Values)
            {
                SpoilerLogLocation sll = sl.LogLocationInfos[loc.UniqueName];
                ActiveLocation al = new ActiveLocation(loc, sll, state.CurrentItems.IsMajor(sll.Item));
             

                CurrentLocations.Add(al.Key, al);
            }     
        }

      
     


       


    }
}
