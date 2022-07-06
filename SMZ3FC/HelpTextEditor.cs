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
    public partial class HelpTextEditor : Form
    {

        public string HelpText { get; private set; }

        public HelpTextEditor(string help)
        {
            InitializeComponent();
            rtbEditHelp.Text = HelpText = help;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            HelpText = rtbEditHelp.Text;
            DialogResult = DialogResult.OK;

            this.Close();
        }
    }
}
