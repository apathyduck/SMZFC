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


        SMZ3FCSettings settings;


        public LocationDisp(SMZ3FCSettings set)
        {
            InitializeComponent();
            settings = set;
            lblTotalItemSmall.Text = string.Empty;
        }


        public void SetLocationData(ActiveArea active)
        {
            AreaData = active;
            gbTitle.Text = $"{active.Name} | {AreaData.CurrentArea.TotalLocations}";

            AreaData.PrimaryAreaUpdate += AreaData_PrimaryAreaChanged;
            AreaData.ItemCountUpdate += AreaData_ItemCountUpdate;
            tipLocationList.SetToolTip(gbTitle, AreaData.LocationTextString);
            tipLocationList.SetToolTip(btnAdd, AreaData.LocationTextString);
            tipLocationList.SetToolTip(btnSub, AreaData.LocationTextString);
            tipLocationList.SetToolTip(rbHide, AreaData.LocationTextString);
            tipLocationList.SetToolTip(rbShow, AreaData.LocationTextString);
            tipLocationList.SetToolTip(lblCount, AreaData.LocationTextString);
            tipLocationList.SetToolTip(lblTotalItemSmall, AreaData.LocationTextString);
            tipLocationList.SetToolTip(this, AreaData.LocationTextString);



        }

        private void AreaData_ItemCountUpdate(object sender, EventArgs e)
        {
            UpdateCount();      
        }

        private void AreaData_PrimaryAreaChanged(object sender, EventArgs e)
        {
            MakePrimary(AreaData.IsPrimary);
            
        }

    

        private void MakePrimary(bool prime)
        {
            if(prime)
            {
                rbShow.Checked = true;
                gbTitle.BackColor = settings.PrimaryLocColor;
                BackColor = settings.PrimaryLocColor;
                cbActive.Checked = true;
            }
            else
            {
                cbActive.Checked = false;
                gbTitle.BackColor = SystemColors.Control;
                BackColor = SystemColors.Control;
                cbActive.Checked = false;
            }
        }

        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCount();
        }

        private void UpdateCount()
        {
            if (rbShow.Checked)
            {
                lblCount.Text = $"{AreaData.CurrentItems}";
                lblTotalItemSmall.Text = $"/{AreaData.TotalItems}";
            }
            else if (!AreaData.IsPrimary)
            {
                lblCount.Text = "?";
                lblTotalItemSmall.Text = string.Empty;
            }
            else
            {
                rbShow.Checked = true;
            }
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            if(!rbShow.Checked)
            { return; }

            AreaData.ItemFound();
          
            if (settings.SubButtonAuto)
            {
                cbActive.Checked = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!rbShow.Checked)
            { return; }

            AreaData.ItemReplace();

            if (settings.AddButtonAuto)
            {
                cbActive.Checked = true;
            }
        }

        private void cbActive_CheckedChanged(object sender, EventArgs e)
        {        
            if(AreaData.IsPrimary)
            {
                cbActive.Checked = true;
            }
            if(cbActive.Checked)
            {
                AreaData.SetAsPrimary();
            }
        }

        private void tipLocationList_Popup(object sender, PopupEventArgs e)
        {
            
           tipLocationList.ToolTipTitle = AreaData.LocationTextString ;
        }
    }
}
