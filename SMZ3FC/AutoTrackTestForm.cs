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
    public partial class AutoTrackTestForm : Form
    {
        SMZ3FCManager mManager;
        AutotrackingManager mAtManager;
        Label lblBevel = new Label();
        ActiveLocation mPrimaryLoc = null;
        ActiveArea mPrimaryArea = null;

        object lockUI = new object();


        public AutoTrackTestForm(SMZ3FCManager managaer)
        {
            InitializeComponent();
            mManager = managaer;
            mAtManager = new AutotrackingManager();
            mAtManager.Initialize(mManager.ActiveWorld);
            mAtManager.StartTrackingThread();

            lock (lockUI)
            {
                foreach (ActiveArea area in mManager.ActiveWorld.Areas.Values)
                {
                    cbAreas.Items.Add(area);
                }


                flpDebugLocs.AutoScroll = true;
                flpDebugLocs.WrapContents = false;


                lblBevel.Height = 2;
                lblBevel.Width = flpDebugLocs.Width - 10;
                lblBevel.BorderStyle = BorderStyle.Fixed3D;

                flpDebugLocs.Controls.Add(lblBevel);

                foreach (ActiveLocation al in mManager.ActiveWorld.AllActiveLocations.Values)
                {
                    al.FoundUpdated += Al_FoundUpdated;
                }
            }

          

           

        }

        private void Al_FoundUpdated(object sender, EventArgs e)
        {
            lock (lockUI)
            {

                mPrimaryLoc = (ActiveLocation)sender;
                Action cla = delegate { atdlDefault.ChangeLocation(mPrimaryLoc); };
                this.Invoke(cla);
                
            }
            
        }

        private void ResetControls()
        {

            flpDebugLocs.SuspendLayout();
            flpDebugLocs.Controls.Clear();
            foreach(Control c in flpDebugLocs.Controls)
            {
                if(c is AutoTrackingDebugLoc)
                {
                    ((AutoTrackingDebugLoc)c).RemoveThisLoc();
                
                }
            }
            flpDebugLocs.Controls.Clear();


            if (mPrimaryArea == null)
            {
                return;
            }

            foreach(ActiveLocation al in mPrimaryArea.CurrentLocations.Values)
            {
                AutoTrackingDebugLoc atbl = new AutoTrackingDebugLoc(al);              
                flpDebugLocs.Controls.Add(atbl);
                atbl.AddThisLoc();
            }
            flpDebugLocs.ResumeLayout();

        }


        private void cbAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            mPrimaryArea = (ActiveArea)cbAreas.SelectedItem;
            Action reset = delegate { ResetControls(); };

            flpDebugLocs.Invoke(reset);
        }
    }
}
