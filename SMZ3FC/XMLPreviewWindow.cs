using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SMZ3FC
{
    public partial class XMLPreviewWindow : Form
    {
        public XMLPreviewWindow(SMZ3XMLFileInfo fi)
        {
            InitializeComponent();
            rtbShowXML.AppendText(fi.Contents);
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
