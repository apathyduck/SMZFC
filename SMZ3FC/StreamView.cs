using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMZ3FC
{
    public partial class StreamView : Form
    {


        SMZ3FCSettings settings;
        public void SetLabel(CollatedLocationData loc)
        {

            lblStream.Text = $"{loc.Name}: {loc.CurrentCount.ToString()}";
            lblStream.Font = settings.StreamViewFont;
            

        }

        public void UpdateSettings()
        {
            
            if (settings.StreamViewFont != null)
            {
                lblStream.Font = settings.StreamViewFont;
            }
            else
            {
                settings.StreamViewFont = lblStream.Font;
            }
            if(settings.StreamViewColorKey != Color.Empty)
            {
                this.BackColor = settings.StreamViewColorKey;
            }
            else
            {
                settings.StreamViewColorKey = this.BackColor;
            }
            
        }


        public StreamView(SMZ3FCSettings set)
        {
           
            InitializeComponent();
            settings = set;
            UpdateSettings();
        }
    }

    
        
}
