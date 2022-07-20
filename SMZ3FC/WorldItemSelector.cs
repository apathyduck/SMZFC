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
    public partial class WorldItemSelector : Form
    {

  
        public string SelectedGroup
        {
            get
            {
                return lbGroups.SelectedItem.ToString();
            }
        }


        public string SelectedItems
        {
            get
            {
                return lbItems.SelectedItem.ToString();
            }
        }

        public bool SetAsDefault { get; private set; } = false;

        private SMZ3FCManager manager;

        public WorldItemSelector(SMZ3FCManager man)
        {

           
            InitializeComponent();

            manager = man;

            foreach(string g in manager.Worlds.Keys)
            {
                lbGroups.Items.Add(g);
            }

            foreach(string i in manager.ItemSets.Keys)
            {
                lbItems.Items.Add(i);
            }

            
            lbGroups.SelectedIndex = lbGroups.Items.IndexOf(manager.CurrentWorldKey);
            lbItems.SelectedIndex = lbItems.Items.IndexOf(manager.CurrentItemKey);

        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {

            bool groupinit = lbGroups.SelectedIndex != -1;
            bool iteminit = lbItems.SelectedIndex != -1;

            if (groupinit)
            {
                lblLocHash.Text = $"Location Hash: {manager.Worlds[lbGroups.SelectedItem.ToString()].Hash}";
            }
            if(iteminit)
            {
                lblItemHash.Text = $"Item List Hash: {manager.ItemSets[lbItems.SelectedItem.ToString()].Hash}";
            }

            if (groupinit && iteminit)
            {
                lblCombinedHash.Text = $"Combined Hash: {manager.CombineHashes(lbGroups.SelectedItem.ToString(), lbItems.SelectedItem.ToString())}";
            }
        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void cbSetAsDef_CheckedChanged(object sender, EventArgs e)
        {
            SetAsDefault = cbSetAsDef.Checked;
        }
    }
}
