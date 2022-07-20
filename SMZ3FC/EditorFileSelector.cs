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
        SMZ3FCManager smzManager;

        public string SelectedKey { get; private set; }
        public string GroupTitle { get; private set; }
        public SMZ3XMLFileInfo XMLFileInfo { get; private set; }

        public bool BlankFile { get; private set; } = false;

        public bool OverWriteCurrent { get; private set; } = false;

        private Type selEditorType = null;
       

        public EditorFileSelector(SMZ3FCManager man, Type seltype)
        {
            InitializeComponent();
            smzManager = man;
            selEditorType = seltype;

            if (selEditorType.IsAssignableFrom(typeof(MajorItemsDefinition)))
            {
                foreach (string s in smzManager.ItemSets.Keys)
                {
                    lbCurrentWorlds.Items.Add(s);
                }
            }

            else if (selEditorType.IsAssignableFrom(typeof(WorldDefinition)))
            {
                foreach (string s in smzManager.Worlds.Keys)
                {
                    lbCurrentWorlds.Items.Add(s);
                }
            }
            else
            {
                //programmer error
                throw new Exception();
            }

            lbCurrentWorlds.SelectedIndex = 0;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
            SelectedKey = lbCurrentWorlds.SelectedItem.ToString();
            DialogResult = DialogResult.OK;
            GroupTitle = SelectedKey;
            if (selEditorType.IsAssignableFrom(typeof(MajorItemsDefinition)))
            {
                XMLFileInfo = smzManager.ItemSets[SelectedKey].ItemsFile;
            }

            else if (selEditorType.IsAssignableFrom(typeof(WorldDefinition)))
            {
                XMLFileInfo = smzManager.Worlds[SelectedKey].WorldFile;
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
            SelectedKey = lbCurrentWorlds.SelectedItem.ToString();
            GroupTitle = tbNewName.Text;

            string filepath = CheckAndGetFilePath(GroupTitle);
            if (string.IsNullOrEmpty(filepath))
            {
                return;
            }


            XMLFileInfo = new SMZ3XMLFileInfo()
            {
                Info = new FileInfo(filepath)
            };


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
            XMLFileInfo = new SMZ3XMLFileInfo()
            {
                Info = new FileInfo(filepath)
            };
                
               
            DialogResult = DialogResult.OK;
            this.Close();

        }

        private string CheckAndGetFilePath(string title)
        {

            if(string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Must Input a Title for a New or Copied File", "No Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;

            }
            string filepath = string.Empty;
            if (selEditorType.IsAssignableFrom(typeof(MajorItemsDefinition)))
            {
                if (smzManager.ItemSets.ContainsKey(GroupTitle))
                {
                    MessageBox.Show("Item List Already Exists with this Title", "Key Collison", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return filepath;
                }
                return filepath = Path.Combine(Environment.CurrentDirectory, $"{GroupTitle}Items.xml");
            }
            else if (selEditorType.IsAssignableFrom(typeof(WorldDefinition)))
            {
                if (smzManager.Worlds.ContainsKey(GroupTitle))
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
