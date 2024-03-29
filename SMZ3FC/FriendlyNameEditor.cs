﻿using System;
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
    public partial class FriendlyNameEditor : Form
    {
        LocationInfo selLoc;
        SMZ3FCSettings settings;

        public FriendlyNameEditor(SMZ3FCSettings set)
        {
            InitializeComponent();
            settings = set;
            foreach(LocationInfo li in SpoilerLogStructure.SpoilerLocations.Values)
            {
                lbLocations.Items.Add(li);
            }
        }

        private void lbLocations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lbLocations.SelectedIndex == -1)
            {
                return;
            }

            selLoc = (LocationInfo)lbLocations.SelectedItem;
            tbArea.Text = selLoc.AreaName;
            tbLocation.Text = selLoc.SpoilerLocationName;
            tbFriendly.Text = selLoc.FriendlyName;
            cbUse.Checked = selLoc.UseFriendly;

            
        }

        private void tbFriendly_TextChanged(object sender, EventArgs e)
        {
            if(lbLocations.SelectedIndex == -1)
            { return; }

            selLoc.FriendlyName = tbFriendly.Text;
            lbLocations.Items[lbLocations.SelectedIndex] = lbLocations.Items[lbLocations.SelectedIndex];
            if(string.IsNullOrEmpty(tbFriendly.Text))
            {
                cbUse.Checked = true;
            }
        }

  

        private void cbUse_CheckedChanged(object sender, EventArgs e)
        {
            if(lbLocations.SelectedIndex == -1)
            { return; }
            selLoc.UseFriendly = cbUse.Checked;
            lbLocations.Items[lbLocations.SelectedIndex] = lbLocations.Items[lbLocations.SelectedIndex];
        }

        private void btnSaveAndExit_Click(object sender, EventArgs e)
        {
            SpoilerLogStructure.WriteJson(settings.LocationInfoJsonPath);
            this.Close();
        }
    }
}
