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
                else if(value < 0)
                {
                    mfounditems = 0;
                }
                else
                {
                    mfounditems = value;
                }
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

        public Dictionary<string, ActiveLocation> CurrentLocations { get; set; }

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
                SpoilerLogLocation sll = sl.LogLocationInfos[loc.SpoilerLocationName];
                ActiveLocation al = new ActiveLocation(loc, sll, state.CurrentItems.IsMajor(sll.Item));
                CurrentLocations.Add(al.Key, al);
            }

        }


       


    }
}
