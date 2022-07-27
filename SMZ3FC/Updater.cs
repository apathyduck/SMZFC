using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMZ3FC
{
    public partial class Updater : Form
    {
        SMZ3FCSettings settings;
        UpdateInfoEventArgs cachedArgs;
        public Updater(SMZ3FCSettings set)
        {
            settings = set;
            InitializeComponent();
            Assembly thisAss = Assembly.GetExecutingAssembly();
            Version ver = thisAss.GetName().Version;
            tbCurVer.Text = $"v{ver.Major}.{ver.Minor}.{ver.Revision}.{ver.Build}";
            tbLatestVer.Text = $"v{FCAutoUpdate.ServerVersion}";
            if(FCAutoUpdate.CheckForUpdates())
            {

                lblStatus.Text = "Update Available!";
                btnUpdate.Enabled = true;
            }
            else
            {
                lblStatus.Text = "No Updates Found";
                btnUpdate.Enabled = false;
            }
            AutoUpdater.Start(settings.UpdaterUrl);
        }

      

        private void llPatchNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/apathyduck/SMZFC/releases");
        }

      

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            FCAutoUpdate.ShowUpdateForm();
        }
    }
}
