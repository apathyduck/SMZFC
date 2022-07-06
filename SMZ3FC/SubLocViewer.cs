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


        public void SetText(string s)
        {
            rtbSubLocs.Text = s;
            int n = rtbSubLocs.Lines.Count();
            this.Height = rtbSubLocs.Font.Height * (n+3) + rtbSubLocs.Margin.Vertical;

        }
        public SubLocViewer()
        {
            InitializeComponent();
        }
    }
}
