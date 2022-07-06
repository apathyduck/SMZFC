using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMZ3FC
{
    public partial class EditorFileSelector : Form
    {
        AreaItemManager aiManager;

        public string SelectedKey { get; private set; }
        public string GroupTitle { get; private set; }
        public FileInfo XMLFileInfo { get; private set; }

        public bool BlankFile { get; private set; } = false;

        public bool OverWriteCurrent { get; private set; } = false;

        private Type selEditorType = null;
       

        public EditorFileSelector(AreaItemManager aim, Type seltype)
        {
            InitializeComponent();
            aiManager = aim;
            selEditorType = seltype;

            if (selEditorType.IsAssignableFrom(typeof(MajorItemsList)))
            {
                foreach (string s in aim.ItemsList.Keys)
                {
                    lbCurrentGroups.Items.Add(s);
                }
            }

            else if (selEditorType.IsAssignableFrom(typeof(AreaGroupings)))
            {
                foreach (string s in aim.Groupings.Keys)
                {
                    lbCurrentGroups.Items.Add(s);
                }
            }
            else
            {
                //programmer error
                throw new Exception();
            }

            lbCurrentGroups.SelectedIndex = 0;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            SelectedKey = lbCurrentGroups.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            GroupTitle = SelectedKey;
            if (selEditorType.IsAssignableFrom(typeof(MajorItemsList)))
            {
                XMLFileInfo = aiManager.ItemsList[SelectedKey].ItemsXMLFile;
            }

            else if (selEditorType.IsAssignableFrom(typeof(AreaGroupings)))
            {
                XMLFileInfo = aiManager.Groupings[SelectedKey].LocXmlFile;
            }
            else
            {
                //programmer error
                throw new Exception();
            }
            OverWriteCurrent = true;
            this.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            SelectedKey = lbCurrentGroups.SelectedItem.ToString();
            GroupTitle = tbNewName.Text;

            string filepath = CheckAndGetFilePath(GroupTitle);
            if (string.IsNullOrEmpty(filepath))
            {
                return;
            }


            XMLFileInfo = new FileInfo(filepath);
            DialogResult = DialogResult.OK;
            this.Close();


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            GroupTitle = tbNewName.Text;

            string filepath = CheckAndGetFilePath(GroupTitle);
            if(string.IsNullOrEmpty(filepath))
            {
                return;
            }

            BlankFile = true;
            XMLFileInfo = new FileInfo(filepath);
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private string CheckAndGetFilePath(string title)
        {
            string filepath = string.Empty;
            if (selEditorType.IsAssignableFrom(typeof(MajorItemsList)))
            {
                if (aiManager.ItemsList.ContainsKey(GroupTitle))
                {
                    MessageBox.Show("Item List Already Exists with this Title", "Key Collison", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return filepath;
                }
                return filepath = Path.Combine(Environment.CurrentDirectory, $"{GroupTitle}Items.xml");
            }
            else if (selEditorType.IsAssignableFrom(typeof(AreaGroupings)))
            {
                if (aiManager.Groupings.ContainsKey(GroupTitle))
                {
                    MessageBox.Show("Group Already Exists with this Title", "Key Collison", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return filepath;
                }
                return filepath = Path.Combine(Environment.CurrentDirectory, $"{GroupTitle}Areas.xml");
            }
            else
            {
                //programmer error
                throw new Exception();
            }
        }
    }
}
