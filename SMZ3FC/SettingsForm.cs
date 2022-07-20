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
    public partial class SettingsForm : Form
    {

        SMZ3FCSettings settings;



        public SettingsForm(SMZ3FCSettings set)
        {
            settings = set;
            InitializeComponent();
            fdStreamView.Font = settings.StreamViewFont;
            cdStrmView.Color = settings.StreamViewColorKey;
            cdPrimaryLoc.Color = settings.PrimaryLocColor;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {

            settings.PrimaryLocColor = cdPrimaryLoc.Color;
            settings.StreamViewColorKey = cdStrmView.Color;
            settings.StreamViewFont = fdStreamView.Font;
            settings.StreamViewFontColor = cdSVFont.Color;
            settings.AddButtonAuto = cbAddAuto.Checked;
            settings.SubButtonAuto = cbSubAuto.Checked;

            settings.SaveSettings();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSVFont_Click(object sender, EventArgs e)
        {
            
            fdStreamView.ShowDialog();
            
        }

        private void btnSVKey_Click(object sender, EventArgs e)
        {
           
            cdStrmView.ShowDialog();
            

        }

        private void btnPLCol_Click(object sender, EventArgs e)
        {
            
            cdPrimaryLoc.ShowDialog();
         
        }

        private void cbSubAuto_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void cbAddAuto_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void btnFontColor_Click(object sender, EventArgs e)
        {
            cdSVFont.ShowDialog();
        }
    }
}
