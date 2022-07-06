using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMZ3FC
{


    public partial class ItemCountViewer : Form
    {

        private StreamView myStrmView;

        private HelpForm hlpForm;

        private SettingsForm setForm;

        private AreaItemManager aiManager;
        private SMZ3FCSettings settings;
        private SubLocViewer myLocView; 

     
        public string CurrentGroupKey
        {
            get
            {
                return aiManager.CurrentGroupKey;
            }
        }

        public string CurrentItemKey
        {
            get
            {
                return aiManager.CurrentItemKey;
            }
        }

        public string SpoilerLogPath { get; private set; } = string.Empty;

        //public event EventHandler OpenNewSpoilerLog;
        public event EventHandler LocationDataUpdated;
        bool showstreamview = true;
        bool showlocviwer = false;

        public ItemCountViewer(AreaItemManager ai, SMZ3FCSettings set)
        {
            InitializeComponent();

            settings = set;
            this.MaximizeBox = false;
            
            lblHash.Text = "No File Loaded";

            aiManager = ai;

            //SetGroups(ag);
            
            if(settings.PrimaryLocColor == Color.Empty)
            {
                settings.PrimaryLocColor = SystemColors.Info;
            }


            myStrmView = new StreamView(settings);
            hlpForm = new HelpForm();
            setForm = new SettingsForm(settings);
            

            LocationDisp.ActiveStatusOn += StatusOnHandler;
            LocationDisp.CountChanged += LocationDisp_CountChanged;

            showstreamview = streamviewToolStripMenuItem.Checked = true;
            myLocView = new SubLocViewer();

        }

        private void SetGroupHash(string h)
        {
            lblGroupHash.Text = $"Group Hash: ({aiManager.CurrentGroupKey} and {aiManager.CurrentItemKey}) - {h}";
        }

        public void SetGroups()
        {

            RemoveLocationsFromLayout();

            this.tabLocationTab.SuspendLayout();
          
       
            SetGroupHash(aiManager.CurrentCombinedHash);
            int index = 0;

            foreach(string t in aiManager.CurrentGroup.GameTabList)
            {
                TabPage tp = new TabPage();
                tp.Name = t;
                tp.Text = t;
                tp.TabIndex = index;
                index++;

                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.AutoSize = true;
                flp.Dock = DockStyle.Fill;
                flp.FlowDirection = FlowDirection.TopDown;

                flp.Name = $"flp{t}";

                tp.Controls.Add(flp);
                tabLocationTab.TabPages.Add(tp);

            }


            foreach (CollatedLocationData cld in aiManager.CurrentGroup.Locations)
            {
                LocationDisp ld = new LocationDisp(settings);
                ld.SetLocationData(cld);
                LocationDisp.ActiveStatusOn += ld.OtherActiveStatusOnHandler;
                LocationDataUpdated += ld.HandleLocDataUpdated;

                tabLocationTab.TabPages[cld.Tab].Controls[$"flp{cld.Tab}"].Controls.Add(ld);
              
            }

           

            this.tpSMLocs.ResumeLayout();
            this.tpALTTPLocs.ResumeLayout();

        }

        private void RemoveLocationsFromLayout()
        {

            tabLocationTab.SuspendLayout();


           

            foreach (TabPage tp in tabLocationTab.TabPages)
            {
                tabLocationTab.TabPages.Remove(tp);
            }
            tabLocationTab.ResumeLayout();


        }

        private void LocationDisp_CountChanged(object sender, EventArgs e)
        {


            SetTotalItems();
            UpdateStreamView(sender);
            UpdateSubLocViewer(sender);
        }

        private void UpdateSubLocViewer(object sender)
        {
            LocationDisp s = (LocationDisp)sender;
            myLocView.SetText(s.ToolTipText);
            if (showlocviwer)
            {
                myLocView.Show();
            }
        }

        private void StatusOnHandler(object sender, EventArgs e)
        {

            UpdateStreamView(sender);
        }

        private void UpdateStreamView(object sender)
        {
            LocationDisp s = (LocationDisp)sender;
            myStrmView.SetLabel(s.LocData);
            if (showstreamview)
            {
                myStrmView.Show();
            }

        }

        private void SetTotalItems()
        {
            lblTotal.Text = $"Total Items: {aiManager.CurrentGroup.FoundItemCount}/{aiManager.CurrentGroup.TotalItemCount}";
        }

        private void LoadSpoilerLog()
        {
            aiManager.ParseLog(SpoilerLogPath);
            SetGroups();
            LocationDataUpdated?.Invoke(this, new EventArgs());
            SetTotalItems();
            lblHash.Text = LogParser.SpoilerHash;
            pnLoadSpoilerBlank.Visible = false;
        }

        private void SetSelectedGroup(string groupk, string itemk, bool def)
        {
            aiManager.CurrentGroupKey = groupk;
            aiManager.CurrentItemKey = itemk;

            if (def)
            {
                settings.DefaultGroup = groupk;
                settings.DefaultGroup = itemk;
                settings.SaveSettings();

            }

            hlpForm.SetHelpText(aiManager.CurrentGroup.HelpText, aiManager.CurrentItemList.HelpText);

            if (!string.IsNullOrEmpty(SpoilerLogPath))
            {
                LoadSpoilerLog();
            }
        }

        private void ItemCountViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            myStrmView.Close();
        }

      

        private void loadSpoilerLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdOpenSpoilerBrowser.ShowDialog() == DialogResult.OK)
            {
                
                SpoilerLogPath = ofdOpenSpoilerBrowser.FileName;
                LoadSpoilerLog();
               
            }
        }

        private void selectGroupingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GroupSelector gs = new GroupSelector(aiManager);
            
            if(gs.ShowDialog(this) == DialogResult.OK)
            {
                SetSelectedGroup(gs.SelectedGroup, gs.SelectedItems, gs.SetAsDefault);
            }
           

        }

      

        private void getHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (hlpForm.IsDisposed)
            {
                hlpForm = new HelpForm();
                hlpForm.SetHelpText(aiManager.CurrentGroup.HelpText, aiManager.CurrentItemList.HelpText);
            }
            if (!hlpForm.Visible)
            {
                hlpForm.Show();
            }

        }

        private void pnLoadSpoilerBlank_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // Assign the file names to a string array, in 
                // case the user has selected multiple files.
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                try
                {
                    SpoilerLogPath = files[0];
                    LoadSpoilerLog();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void pnLoadSpoilerBlank_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap) || e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (setForm.IsDisposed)
            {

                setForm = new SettingsForm(settings);

            }
            if (DialogResult.OK == setForm.ShowDialog(this))
            {
                myStrmView.UpdateSettings();
                settings.SaveSettings();
            }
        }

     

        private void streamviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            streamviewToolStripMenuItem.Checked = !streamviewToolStripMenuItem.Checked;
            showstreamview = streamviewToolStripMenuItem.Checked;
            if(!showstreamview)
            {
                myStrmView.Hide();
            }
        }

        private void areaEdiotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFileSelector aes = new EditorFileSelector(aiManager, typeof(AreaGroupings));
            if (DialogResult.OK == aes.ShowDialog(this))
            {
                AreaEditor ae = new AreaEditor(aes.GroupTitle, aiManager.Groupings.Keys.ToList<string>());

                if (aes.OverWriteCurrent)
                {
                    ae.SetEditFromTitle(aes.GroupTitle);
                }


                ae.SetXMLFile(aes.XMLFileInfo);

                if (!aes.BlankFile)
                {
                    AreaGroupings ag = aiManager.Groupings[aes.SelectedKey];
                    ae.SetAreaGroup(ag);
                }

                if (DialogResult.OK == ae.ShowDialog(this))
                {
                    if (aes.OverWriteCurrent)
                    {
                        aiManager.RemoveGroup(aes.GroupTitle);
                    }
                    FCXMLParser.LoadSingleFile(aes.XMLFileInfo);


                    SetSelectedGroup(aes.GroupTitle, aiManager.CurrentItemKey, false);

                }

            }
        }

        private void itemEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFileSelector aes = new EditorFileSelector(aiManager, typeof(MajorItemsList));
            if (DialogResult.OK == aes.ShowDialog(this))
            {
                ItemEditor ie = new ItemEditor(aes.GroupTitle, aiManager.ItemsList.Keys.ToList<string>());

                if (aes.OverWriteCurrent)
                {
                    ie.SetEditFromTitle(aes.GroupTitle);
                }

                ie.SetXMLFile(aes.XMLFileInfo);

                if (!aes.BlankFile)
                {
                    MajorItemsList mil = aiManager.ItemsList[aes.SelectedKey];
                    ie.SetItemList(mil);
                }

                if (DialogResult.OK == ie.ShowDialog(this))
                {
                    if (aes.OverWriteCurrent)
                    {
                        aiManager.RemoveGroup(aes.GroupTitle);

                    }
                    FCXMLParser.LoadSingleFile(aes.XMLFileInfo);


                    SetSelectedGroup(aiManager.CurrentGroup.Name, aes.GroupTitle, false);

                }

            }
        }

        private void copyHashesToClipboardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText($"{lblHash.Text} || {lblGroupHash.Text}");
        }

        private void subLocationWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showlocviwer = subLocationWindowToolStripMenuItem.Checked = !subLocationWindowToolStripMenuItem.Checked;
            if(!showlocviwer)
            {
                myLocView.Hide();
            }
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(SpoilerLogPath))
            {
                return;
            }
            ReportViewer rv = new ReportViewer(aiManager);
            rv.ShowDialog(this);
        }
    }
    
}
