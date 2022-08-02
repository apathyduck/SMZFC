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
        WorldState curWorldState;
        bool display = true;
        bool forceclose = false;

        private void CurWorldState_PrimaryAreaUpdated(object sender, EventArgs e)
        {
            if(curWorldState.PrimaryArea == null)
            { return; }
            lblStream.Text = $"{curWorldState.PrimaryArea.Name}: {curWorldState.PrimaryArea.CurrentItems}";
            lblStream.Font = settings.StreamViewFont;
            lblStream.ForeColor = settings.StreamViewFontColor;
            if (display)
            {
                this.Show();
            }
        }

        public void ForceClose()
        {
            forceclose = true;
            this.Close();
        }

        public void Display(bool disp)
        {
            display = disp;
            if(display)
            {
                this.Show();
            }
            else
            {
                this.Hide();
            }
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
            if(settings.StreamViewFontColor != Color.Empty)
            {
                lblStream.ForeColor = settings.StreamViewFontColor;
            }
            else
            {
                settings.StreamViewFontColor = lblStream.ForeColor;
            }
            
        }


        public StreamView(SMZ3FCSettings set, WorldState wrld)
        {
           
            InitializeComponent();
            settings = set;
            UpdateSettings();
            curWorldState = wrld;
            curWorldState.AreaStateUpdate += CurWorldState_PrimaryAreaUpdated;
            lblStream.Text = "No Area";

         
        }

        private void StreamView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!forceclose)
            {
                this.Hide();
                display = false;
                e.Cancel = true;
                return;
            }

        }
    }

    
        
}
