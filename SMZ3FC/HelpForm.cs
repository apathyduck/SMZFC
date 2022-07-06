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


    public partial class HelpForm : Form
    {

        public void SetHelpText(string a, string i)
        {
            tbAreaGuide.Text = a;
            tbItems.Text = i;
        }

        public HelpForm()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
        }
    }
}
