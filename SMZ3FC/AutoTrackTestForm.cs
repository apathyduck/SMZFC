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
        public AutoTrackTestForm(SMZ3FCManager managaer)
        {
            InitializeComponent();
            mManager = managaer;
            mAtManager = new AutotrackingManager();
            mAtManager.Initialize(mManager.ActiveWorld);
           

        }
    }
}
