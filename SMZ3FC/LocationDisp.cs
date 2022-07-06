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
    public partial class LocationDisp : UserControl
    {
        public CollatedLocationData LocData { get; private set; }

        public static event EventHandler ActiveStatusOn;
        public static event EventHandler CountChanged;

        SMZ3FCSettings settings;

        public string ToolTipText { get; private set; }
       


        public LocationDisp(SMZ3FCSettings set)
        {
            InitializeComponent();
            settings = set;



        }


        public void SetLocationData(CollatedLocationData cld)
        {
            LocData = cld;
            gbTitle.Text = $"{cld.Name} | ?";

            StringBuilder sb = new StringBuilder();
            foreach(LocationInfo li in cld.ItemLines)
            {
                sb.AppendLine(li.SpoilerSubLoc);
            }

            ToolTipText = sb.ToString();
            tipLocationList.SetToolTip(gbTitle, ToolTipText);
        }

        public void SetActive()
        {
            cbActive.Checked = true;
        }

        public void OtherActiveStatusOnHandler(object sender, EventArgs e)
        {
            CollatedLocationData data = ((LocationDisp)sender).LocData;
            if(!data.Name.Equals(this.LocData.Name))
            {
                cbActive.Checked = false;
                gbTitle.BackColor = SystemColors.Control;
                this.BackColor = SystemColors.Control;
            }
            else
            {
                rbShow.Checked = true;
                gbTitle.BackColor = settings.PrimaryLocColor;
                this.BackColor = settings.PrimaryLocColor;
            }
            
        }


        public void HandleLocDataUpdated(object sender, EventArgs e)
        {
            gbTitle.Text = $"{LocData.Name} | {LocData.IndividualLocs}";
        }

      

        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCount(0);
        }

        private void UpdateCount(int changeval)
        {

            switch (changeval)
            {              
                case 1:
                    LocData.AddCurrentItem();
                    break;
                case -1:
                    LocData.RemoveCurrentItem();
                    break;
                default:
                    break;
            }
          
            if(rbShow.Checked)
            {
                lblCount.Text = LocData.CurrentCount.ToString();
            }
            else
            {
                lblCount.Text = "?";
            }
            CountChanged?.Invoke(this, new EventArgs());
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if(!rbShow.Checked)
            { return; }

           
            UpdateCount(-1);
            if (settings.SubButtonAuto)
            {
                cbActive.Checked = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!rbShow.Checked)
            { return; }
            UpdateCount(1);
            if (settings.AddButtonAuto)
            {
                cbActive.Checked = true;
            }
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {
            if (cbActive.Checked)
            {
                ActiveStatusOn?.Invoke(this, new EventArgs());
            }
        }
    }
}
