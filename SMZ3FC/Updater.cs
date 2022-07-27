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

            AutoUpdater.ReportErrors = true;
            AutoUpdater.Mandatory = true;
            AutoUpdater.UpdateMode = Mode.Normal;
            AutoUpdater.CheckForUpdateEvent += AutoUpdater_CheckForUpdateEvent;
            AutoUpdater.Start(settings.UpdaterUrl);
        }

        private void AutoUpdater_CheckForUpdateEvent(UpdateInfoEventArgs args)
        {
            cachedArgs = args;
            string newver = args.CurrentVersion;
            tbLatestVer.Text = $"v{newver}";
            bool avail = args.IsUpdateAvailable;
            if (avail)
            {
                lblStatus.Text = "Update Available!";
                btnUpdate.Enabled = true;
            }
            else
            {
                lblStatus.Text = "No Updates Found";
                btnUpdate.Enabled = false;
            }
            

        }

        private void llPatchNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/apathyduck/SMZFC/releases");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            AutoUpdater.ShowUpdateForm(cachedArgs);
        }
    }
}
