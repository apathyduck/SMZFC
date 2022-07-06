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
using System.Xml.Linq;

namespace SMZ3FC
{
    public partial class ItemEditor : Form
    {

        private string myTitle;
        private string myHelpText = string.Empty;
        private FileInfo myXMLFileInfo;
        private List<string> curItemKeys;
        private string tempTitle;
        private bool titleCollison = false;
        private string editFromTitle;

        public ItemEditor(string title, List<string> cik)
        {
            InitializeComponent();

            curItemKeys = cik;
            
            myTitle = title;
            tbTitle.Text = myTitle;
            int n = 0;
            lblFeedback.Text = string.Empty;
            foreach (string i in LocationAndItemKeys.Items)
            {
                ItemEditorItemBuilderItem itbl = new ItemEditorItemBuilderItem(i, n);
                n++;
                lbItemList.Items.Add(itbl);
            }
        }

        public void SetEditFromTitle(string edit)
        {
            editFromTitle = edit;
        }


        public void SetItemList(MajorItemsList mil)
        {

            List<ItemEditorItemBuilderItem> ielist = new List<ItemEditorItemBuilderItem>();
            foreach(string item in mil.MajorItems)
            {
                foreach(ItemEditorItemBuilderItem iei in lbItemList.Items)
                {
                    if(item.Equals(iei.ToString()))
                    {
                        ielist.Add(iei);
                    }

                }

            }

            List<ItemEditorItemBuilderItem> ielistfromlb = new List<ItemEditorItemBuilderItem>();
            foreach (ItemEditorItemBuilderItem item in lbItemList.Items)
            {
                ielistfromlb.Add(item);
            }

            foreach (ItemEditorItemBuilderItem iei in ielist)
            {
                foreach(ItemEditorItemBuilderItem item in ielistfromlb)
                {
                    if (iei == item)
                    {
                        lbItemList.Items.Remove(item);
                        lbFinalItems.Items.Add(item);
                    }
                }
            }    


        }

        public void SetXMLFile(FileInfo fi)
        {
            myXMLFileInfo = fi;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {

            AddMultiItemsToList(lbItemList, lbFinalItems);
          
        }

        private void btnSubItem_Click(object sender, EventArgs e)
        {
            AddMultiItemsToList(lbFinalItems, lbItemList);
        }


        private void AddMultiItemsToList( ListBox lbfrom, ListBox lbto)
        {
            List<ItemEditorItemBuilderItem> itemstoremove = new List<ItemEditorItemBuilderItem>();
            foreach (object itemobject in lbfrom.SelectedItems)
            {
                var item = (ItemEditorItemBuilderItem)itemobject;
                itemstoremove.Add(item);

            }
            foreach (ItemEditorItemBuilderItem i in itemstoremove)
            {
                AddItemToList(i, lbfrom, lbto);
            }
        }

        private void AddItemToList(ItemEditorItemBuilderItem ibi, ListBox lbfrom, ListBox lbto)
        {

           
           
                int n = lbfrom.SelectedIndex;
                lbfrom.Items.Remove(ibi);

                if (lbfrom.Items.Count != 0)
                {
                    if (n >= lbfrom.Items.Count)
                    {
                        lbfrom.SelectedIndex = lbfrom.Items.Count - 1;
                    }
                    else
                    {
                        lbfrom.SelectedIndex = n;
                    }
                }

                bool added = false;
                for (int m = 0; m < lbto.Items.Count; m++)
                {
                    int p = ((ItemEditorItemBuilderItem)lbto.Items[m]).Index;
                    if (ibi.Index < p)
                    {
                        lbto.Items.Insert(m, ibi);
                        added = true;

                        break;
                    }
                }
                if (!added)
                {

                    lbto.Items.Add(ibi);
                }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int startindex = 0;
            string searchfor = tbSearch.Text;


            if(lbItemList.SelectedIndex == -1)
            {
                if(rbDown.Checked)
                {
                    startindex = 0;
                }
                else
                {
                    {
                        startindex = lbItemList.Items.Count - 1;
                    }
                }
            }
            else if (rbDown.Checked)
            {
                var lastloc = (from object item in lbItemList.SelectedItems select item).LastOrDefault();
                startindex =  lbItemList.Items.IndexOf(lastloc) + 1;
            }
            else
            {
                var firstloc = (from object item in lbItemList.SelectedItems select item).LastOrDefault();
                startindex = lbItemList.Items.IndexOf(firstloc) -1;
            }


            if(startindex < 0 )
            {
                startindex = 0;
            }
            if(startindex >= lbItemList.Items.Count)
            {
                startindex = lbItemList.Items.Count - 1;
            }

            if (rbUp.Checked)
            {
                for (int n = startindex; n >= 0; n--)
                {
                    if (CompareAndSet(lbItemList, n, searchfor)) { return; }
                }
                
                return;

            }
            else
            {
                for (int n = startindex; n < lbItemList.Items.Count; n++)
                {
                    if (CompareAndSet(lbItemList, n, searchfor)) { return ; }
                }
                

            }


        }

        bool CompareAndSet(ListBox lb, int n, string searchfor)
        {
            string compare = lb.Items[n].ToString().ToLower();

            if (compare.Contains(searchfor))
            {
                lb.SelectedItems.Clear();
                lb.SelectedIndex = n;
                return true;
            }
            return false;
        }

        private void btnEditHelp_Click(object sender, EventArgs e)
        {
            HelpTextEditor hle = new HelpTextEditor(myHelpText);
            if (DialogResult.OK == hle.ShowDialog())
            {
                myHelpText = hle.HelpText;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            XDocument doc = ItemEditorXMLBuilder.GenerateXML(tbTitle.Text, lbFinalItems, myHelpText);
            XMLPreviewWindow pw = new XMLPreviewWindow(doc);
            if (DialogResult.OK == pw.ShowDialog())
            {

                SaveXML(doc, myXMLFileInfo);
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void SaveXML(XDocument doc, FileInfo fi)
        {
            doc.Save(fi.FullName);
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            foreach(string t in curItemKeys)
            {
                if (t.Equals(tbTitle.Text))
                {
                    if (!string.IsNullOrEmpty(editFromTitle) && !tbTitle.Text.Equals(editFromTitle))
                    {

                        lblFeedback.Text = "File with that Title already Exists!";
                        lblFeedback.ForeColor = Color.DarkRed;
                        titleCollison = true;
                        return;
                    }
                }
            }
            titleCollison = false;
            lblFeedback.Text = string.Empty;
        }

        private void tbTitle_Leave(object sender, EventArgs e)
        {
            if(titleCollison)
            {
                tbTitle.Text = tempTitle;
            }
        }

        private void tbTitle_Enter(object sender, EventArgs e)
        {
            tempTitle = tbTitle.Text;
        }
    }
}
