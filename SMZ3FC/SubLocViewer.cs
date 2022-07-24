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
    public partial class SubLocViewer : Form
    {


        WorldState curWorld;
        bool display;
        public SubLocViewer(WorldState ws)
        {
            InitializeComponent();
            curWorld = ws;
            curWorld.PrimaryAreaUpdated += CurWorld_PrimaryAreaUpdated;
        }

        public void Display(bool disp)
        {
            display = disp;
            if(display)
            {
                this.Show();
            }
            else
            { 
                this.Hide();
            }
        }

        private void CurWorld_PrimaryAreaUpdated(object sender, EventArgs e)
        {
            rtbSubLocs.Text = curWorld.PrimaryArea?.LocationTextString;
            if(display)
            {
                this.Show();
            }
        }
    }
}
