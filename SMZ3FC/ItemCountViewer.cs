using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
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

        private SMZ3FCManager smzManager;
        private SMZ3FCSettings settings;
        private SubLocViewer myLocView; 

        
        public string SpoilerLogPath { get; private set; } = string.Empty;

    
      
        public ItemCountViewer(SMZ3FCManager ai, SMZ3FCSettings set)
        {

            AutoUpdater.ShowRemindLaterButton = false;
            AutoUpdater.Start("https://apathyduck.github.io/SMZFC/UpdateConfig.xml");

            InitializeComponent();

            settings = set;
            this.MaximizeBox = false;
            
            lblHash.Text = "No File Loaded";

            smzManager = ai;

            
            if(settings.PrimaryLocColor == Color.Empty)
            {
                settings.PrimaryLocColor = SystemColors.Info;
            }


            myStrmView = new StreamView(settings, smzManager.ActiveWorld);
            hlpForm = new HelpForm();
            setForm = new SettingsForm(settings);
                    
            myLocView = new SubLocViewer(smzManager.ActiveWorld);

        }

        private void SetGroupHash(string h)
        {
            lblGroupHash.Text = $"Group Hash: ({smzManager.CurrentWorldKey} and {smzManager.CurrentItemKey}) - {h}";
        }

        public void SetGroups()
        {

            RemoveLocationsFromLayout();

            this.tabLocationTab.SuspendLayout();
          
       
            SetGroupHash(smzManager.CurrentCombinedHash);
            int index = 0;

            foreach(string t in smzManager.CurrentWorldDefintion.Tabs)
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


            foreach (ActiveArea active in smzManager.ActiveWorld.Areas.Values)
            {
                LocationDisp ld = new LocationDisp(settings);
                ld.SetLocationData(active);
                tabLocationTab.TabPages[active.Tab].Controls[$"flp{active.Tab}"].Controls.Add(ld);
              
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

        private void SetTotalItems()
        {
            lblTotal.Text = $"Total Items: {smzManager.ActiveWorld.FoundItems}/{smzManager.ActiveWorld.TotalItems}";
        }

        private void LoadSpoilerLog()
        {
            smzManager.LoadLogFile(SpoilerLogPath);
            SetGroups();
           
            SetTotalItems();
            lblHash.Text = smzManager.ActiveWorld.CurrentLog.LogHash;
            pnLoadSpoilerBlank.Visible = false;
            streamviewToolStripMenuItem.Checked = true;
            myStrmView.Show();
        }

        private void SetSelectedGroup(string groupk, string itemk, bool def)
        {
            smzManager.CurrentWorldKey = groupk;
            smzManager.CurrentItemKey = itemk;

            if (def)
            {
                settings.DefaultGroup = groupk;
                settings.DefaultItem = itemk;
                settings.SaveSettings();

            }

            hlpForm.SetHelpText(smzManager.CurrentWorldDefintion.HelpText, smzManager.CurrentItemList.HelpText);

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
            WorldItemSelector gs = new WorldItemSelector(smzManager);
            
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
                hlpForm.SetHelpText(smzManager.CurrentWorldDefintion.HelpText, smzManager.CurrentItemList.HelpText);
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
            myStrmView.Display(streamviewToolStripMenuItem.Checked);
        }

        private void areaEdiotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFileSelector aes = new EditorFileSelector(smzManager, typeof(WorldDefinition));
            if (DialogResult.OK == aes.ShowDialog(this))
            {
                WorldEditor ae = new WorldEditor(smzManager, aes.GroupTitle, smzManager.Worlds.Keys.ToList<string>());

                if (aes.OverWriteCurrent)
                {
                    ae.SetEditFromTitle(aes.GroupTitle);
                }


                ae.SetXMLFile(aes.XMLFileInfo);

                if (!aes.BlankFile)
                {
                    WorldDefinition wd = smzManager.Worlds[aes.SelectedKey];
                    ae.SetWorld(wd);
                }

                if (DialogResult.OK == ae.ShowDialog(this))
                {
                    if (aes.OverWriteCurrent)
                    {
                        smzManager.RemoveWorld(aes.GroupTitle);
                    }

                    smzManager.AddWorld(aes.XMLFileInfo);

                    SetSelectedGroup(aes.GroupTitle, smzManager.CurrentItemKey, false);

                }

            }
        }

        private void itemEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditorFileSelector aes = new EditorFileSelector(smzManager, typeof(MajorItemsDefinition));
            if (DialogResult.OK == aes.ShowDialog(this))
            {
                ItemEditor ie = new ItemEditor(aes.GroupTitle, smzManager.ItemSets.Keys.ToList<string>());

                if (aes.OverWriteCurrent)
                {
                    ie.SetEditFromTitle(aes.GroupTitle);
                }

                ie.SetXMLFile(aes.XMLFileInfo);

                if (!aes.BlankFile)
                {
                    MajorItemsDefinition mil = smzManager.ItemSets[aes.SelectedKey];
                    ie.SetItemList(mil);
                }

                if (DialogResult.OK == ie.ShowDialog(this))
                {
                    if (aes.OverWriteCurrent)
                    {
                        smzManager.RemoveWorld(aes.GroupTitle);

                    }

                    smzManager.AddItemSet(aes.XMLFileInfo);

                    SetSelectedGroup(smzManager.CurrentWorldDefintion.Name, aes.GroupTitle, false);

                }

            }
        }

        private void copyHashesToClipboardToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Clipboard.SetText($"{lblHash.Text} || {lblGroupHash.Text}");
        }

        private void subLocationWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subLocationWindowToolStripMenuItem.Checked = !subLocationWindowToolStripMenuItem.Checked;
            myLocView.Display(subLocationWindowToolStripMenuItem.Checked);
        }

        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!smzManager.ActiveWorld.IsInitialized)
            {
                return;
            }
            ReportViewer rv = new ReportViewer(smzManager.ActiveWorld);
            rv.ShowDialog(this);
        }

        private void downloadXMLsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGitXML fgx = new FormGitXML();
            DialogResult res = fgx.ShowDialog();
            if(res == DialogResult.OK)
            {
                foreach(SMZ3XMLFileInfo fi in fgx.NewFiles)
                {
                    smzManager.AddFile(fi);
                }
            }

        }

        private void generateSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //GenSeed gs = new GenSeed();
            //gs.ShowDialog();
        }

        private void locationNameEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FriendlyNameEditor fne = new FriendlyNameEditor(settings);
            fne.ShowDialog();
        }
    }
    
}
