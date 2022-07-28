using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace SMZ3FC
{
    public class LocationInfo : IFCPlaceInfo
    {
        [JsonIgnore]
        public string Name
        {
            get
            {
                if (UseFriendly)
                {
                    return FriendlyName;
                }
                return SpoilerLocationName;
            }
        }

        [JsonProperty("areaname")]
        public string AreaName { get; set; }
        [JsonProperty("friendlyname")]
        public string FriendlyName { get; set; }
        [JsonProperty("spoilername")]
        public string SpoilerLocationName { get; set; }

        [JsonProperty("use")]
        public bool UseFriendly

        { 
            get 
            {
                return use && !string.IsNullOrEmpty(FriendlyName);
            }              
            set 
            {
                use = value;
            } 
        }

        public string UniqueName { get { return SpoilerLocationName; } }

        private bool use;

        public override string ToString()
        {
            return Name;
        }

    }
}
