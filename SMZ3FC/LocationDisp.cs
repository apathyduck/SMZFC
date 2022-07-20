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
        public ActiveArea AreaData { get; private set; }

        public static event EventHandler ActiveStatusOn;
        public static event EventHandler CountChanged;

        SMZ3FCSettings settings;

        public string ToolTipText { get; private set; }
       


        public LocationDisp(SMZ3FCSettings set)
        {
            InitializeComponent();
            settings = set;



        }


        public void SetLocationData(ActiveArea active)
        {
            AreaData = active;
            gbTitle.Text = $"{active.Name} | ?";

            StringBuilder sb = new StringBuilder();
            foreach(ActiveLocation li in AreaData.CurrentLocations.Values)
            {
                sb.AppendLine(li.Name);
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
            ActiveArea data = ((LocationDisp)sender).AreaData;
            if(!data.Name.Equals(AreaData.Name))
            {
                cbActive.Checked = false;
                gbTitle.BackColor = SystemColors.Control;
                BackColor = SystemColors.Control;
            }
            else
            {
                rbShow.Checked = true;
                gbTitle.BackColor = settings.PrimaryLocColor;
                BackColor = settings.PrimaryLocColor;
            }
            
        }


        public void HandleLocDataUpdated(object sender, EventArgs e)
        {
            gbTitle.Text = $"{AreaData.Name} | {AreaData.LocationCount}";
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
                    AreaData.ItemReplace();
                    break;
                case -1:
                    AreaData.ItemFound();
                    break;
                default:
                    break;
            }
          
            if(rbShow.Checked)
            {
                lblCount.Text = $"{AreaData.CurrentItems}/{AreaData.TotalItems}";
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
