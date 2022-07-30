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
        bool forceclose = false;

       

        public SubLocViewer(WorldState ws)
        {
            InitializeComponent();
            curWorld = ws;
            curWorld.AreaStateUpdate += CurWorld_PrimaryAreaUpdated;
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

        public void ForceClose()
        {
            forceclose = true;
            this.Close();
        }

        private void CurWorld_PrimaryAreaUpdated(object sender, EventArgs e)
        {
            rtbSubLocs.Text = curWorld.PrimaryArea?.LocationTextString;
            if(display)
            {
                this.Show();
            }
        }

        private void SubLocViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!forceclose)
            {
                display = false;
                this.Hide();
                e.Cancel = true;
                return;
            }

        }
    }
}
