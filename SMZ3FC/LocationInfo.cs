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

        [JsonProperty("offset")]
        public string AddressOffsetString { get; set; }

        public int AddressOffset
        {
            get
            {
                return Convert.ToInt32(AddressOffsetString, 16);
            }
        }

        [JsonProperty("mask")]
        public string MaskString { get; set; }

        public int Mask
        {
            get
            {
                return Convert.ToInt32(MaskString, 16);
            }
        }

        [JsonProperty("game")]
        public string Game { get; set; }

        [JsonProperty("group")]
        public string Group { get; set; }

        public string UniqueName { get { return SpoilerLocationName; } }

        private bool use;

        public override string ToString()
        {
            return Name;
        }

    }
}
