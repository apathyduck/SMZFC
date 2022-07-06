using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace SMZ3FC
{
    public class SMZ3FCSettings
    {

        [ConfigurableProperty("false")]
        public bool AddButtonAuto { get; set; }
      
        [ConfigurableProperty("false")]
        public bool SubButtonAuto { get; set; }
       
        [ConfigurableProperty("Default")]
        public string DefaultGroup { get; set; }
       
        [ConfigurableProperty("Default")]
        public string DefaultItem { get; set; }
        
        [ConfigurableProperty("")]
        public Font StreamViewFont { get; set; }

        [ConfigurableProperty("")]
        public Color StreamViewColorKey { get; set; }
        
        [ConfigurableProperty("")]
        public Color PrimaryLocColor { get; set; }
     
        public SMZ3FCSettings()
        {
            GetSettings();
        }

        private void GetSettings()
        {
            Type me = typeof(SMZ3FCSettings);

            foreach(PropertyInfo pi in me.GetProperties())
            {
                if(Attribute.IsDefined(pi, typeof(ConfigurableProperty)))
                {
                    string key = pi.Name;
                    Type settype = pi.PropertyType;
                    TypeConverter conv = TypeDescriptor.GetConverter(settype);

                    if(ConfigurationManager.AppSettings[key] == null)
                    {
                        CreateNewSetting(pi);
                    }
                    string setting = ConfigurationManager.AppSettings[key];
                    try
                    {
                        pi.SetValue(this, conv.ConvertFromString(setting));
                    }
                    catch
                    {
                        //Leave value as default
                    }

                }
            }
        
        }

        private void CreateNewSetting(PropertyInfo pi)
        {
            string key = pi.Name;
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           
            ConfigurableProperty confia = (ConfigurableProperty)Attribute.GetCustomAttribute(pi, typeof(ConfigurableProperty));
            configFile.AppSettings.Settings.Add(key, confia.DefaultValue);




            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

        }

        public void SaveSettings()
        {
            Type me = typeof(SMZ3FCSettings);

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           

            foreach (PropertyInfo pi in me.GetProperties())
            {
                if (Attribute.IsDefined(pi, typeof(ConfigurableProperty)))
                {
                    configFile.AppSettings.Settings[pi.Name].Value = pi.GetValue(this).ToString();

                }
            }


            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);

        }

    }
}
