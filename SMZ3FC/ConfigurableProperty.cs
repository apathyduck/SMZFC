using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMZ3FC
{



    public class ConfigurableProperty : Attribute
    {
      
        public string DefaultValue { get; private set; }

        public ConfigurableProperty(string defaultval)
        {
            DefaultValue = defaultval;
        }

    }
}
