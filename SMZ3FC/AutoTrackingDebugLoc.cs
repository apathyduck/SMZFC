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
    public partial class AutoTrackingDebugLoc : UserControl
    {
        ActiveLocation mLoc;
        bool isDefault = true;

        public AutoTrackingDebugLoc()
        {
            InitializeComponent();
        }

        public AutoTrackingDebugLoc(ActiveLocation loc)
        {          
            InitializeComponent();
            isDefault = false;
            mLoc = loc;
         
            gbLocName.Text = mLoc.Name;
            lblItem.Text = $"Item: {mLoc.LogLocation.Item}";
            lblAdd.Text = $"Address: {mLoc.Info.AddressOffset.ToString("X")}";
            lblMask.Text = $"Mask: {mLoc.Info.Mask.ToString("X")}";
            lblValue.Text = $"Add Value: {mLoc.AddressValue.ToString("X")}";
            cbFound.Checked = mLoc.IsFound;
        }

        public void AddThisLoc()
        {
            mLoc.AddressValueUpdated += MLoc_AddressValueUpdated;
        }

        public void RemoveThisLoc()
        {
            if(isDefault) { return; }
            mLoc.AddressValueUpdated -= MLoc_AddressValueUpdated;
        }

        public void ChangeLocation(ActiveLocation al)
        {
            RemoveThisLoc();
            SetLoc(al);

        }

        private void SetLoc(ActiveLocation loc)
        {
            mLoc = loc;

            gbLocName.Text = mLoc.Name;
            lblItem.Text = $"Item: {mLoc.LogLocation.Item}";
            lblAdd.Text = $"Address: {mLoc.Info.AddressOffset.ToString("X")}";
            lblMask.Text = $"Mask: {mLoc.Info.Mask.ToString("X")}";
            lblValue.Text = $"Add Value: {mLoc.AddressValue.ToString("X")}";
            
            cbFound.Checked = mLoc.IsFound;

            mLoc.AddressValueUpdated += MLoc_AddressValueUpdated;
        }

        private void MLoc_AddressValueUpdated(object sender, EventArgs e)
        {
            Action label = delegate { lblValue.Text = $"Add Value: {mLoc.AddressValue.ToString("X")}"; };
            lblValue.Invoke(label);
           
            Action checkbox = delegate { cbFound.Checked = mLoc.IsFound; };
            cbFound.Invoke(checkbox);
        }
    }
}
