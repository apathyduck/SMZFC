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



    public partial class AreaEditor : Form
    {

        
        const string kLoc = "Locations";
        const string kSubLoc = "Sub Locations";
        AreaGroupings myArea;
        FileInfo myXMLFileInfo;
        List<string> currentAreaKeys;

        string myHelpText = string.Empty;
        string editFromTitle = string.Empty;

        public AreaEditor(string grouptitle, List<string> cak)
        {
            InitializeComponent();


            currentAreaKeys = cak;

            lblFeedback.Text = string.Empty;
            lblSearchInfo.Text = string.Empty;

            BuildLocations();


            TreeNode top = new TreeNode();
            top.Name = grouptitle;
            top.Text = grouptitle;
            top.Tag = new TitleTag();

            tvArea.Nodes.Add(top);

            tvArea.AfterSelect += TvArea_AfterSelect;
            tvArea.BeforeSelect += TvArea_BeforeSelect1;
            tvArea.NodeMouseDoubleClick += TvArea_NodeMouseDoubleClick;
            tvArea.KeyDown += TvArea_KeyDown;

            tvArea.AfterLabelEdit += TvArea_AfterLabelEdit;
            tvArea.LabelEdit = true;

            tvArea.AllowDrop = true;
            tvArea.ItemDrag += TvArea_ItemDrag;
            tvArea.DragEnter += TvArea_DragEnter;
            tvArea.DragOver += TvArea_DragOver;
            tvArea.DragDrop += TvArea_DragDrop;





        }

        public void SetAreaGroup(AreaGroupings ag)
        {
            myArea = ag;
            myHelpText = ag.HelpText;

            foreach (CollatedLocationData cld in myArea.Locations)
            {

                
                if (!tvArea.Nodes[0].Nodes.ContainsKey(cld.Tab))
                {
                    TreeNode tntab = new TreeNode();
                    tntab.Text = cld.Tab;
                    tntab.Name = cld.Tab;
                    tntab.Tag = new TabTag();
                    tvArea.Nodes[0].Nodes.Add(tntab);
                }

                TreeNode tab = tvArea.Nodes[0].Nodes[cld.Tab];
                AreaEditorLocationBuilder alb = new AreaEditorLocationBuilder();
                alb.Name = cld.Name;
                alb.Tab = cld.Tab;

                TreeNode tna = new TreeNode();
                tna.Tag = alb;
                tna.Name = alb.Name;
                tna.Text = alb.Name;

                TreeNode tnl = new TreeNode();
                tnl.Name = kLoc;
                tnl.Text = kLoc;
                tnl.Tag = new LocationTag();

                TreeNode tnsl = new TreeNode();
                tnsl.Name = kSubLoc;
                tnsl.Text = kSubLoc;
                tnsl.Tag = new SubLocationTag();

                tab.Nodes.Add(tna);
                tna.Nodes.Add(tnl);
                tna.Nodes.Add(tnsl);


                foreach (string sld in cld.SubLocations)
                {
                    AreaEditorLocationBuilderLocation foundloc = null;
                    foreach (AreaEditorLocationBuilderLocation albl in lbSpoilerLocs.Items)
                    {
                        if(string.Equals(albl.Name, sld))
                        {
                            foundloc = albl;
                            break;
                        }
                    }
                    TreeNode locnode = new TreeNode();
                    locnode.Name = foundloc.Name;
                    locnode.Text = foundloc.Name;
                    locnode.Tag = foundloc;
                    tnl.Nodes.Add(locnode);

                    lbSpoilerLocs.Items.Remove(foundloc);
                    alb.Locations.Add(foundloc);

                }

                foreach(string ssld in cld.ShiftLocsIn)
                {
                    AreaEditorLocationBuilderLocation foundloc = null;
                    foreach (AreaEditorLocationBuilderLocation albl in lbSpoilerSubLocs.Items)
                    {
                        if (string.Equals(albl.Name, ssld))
                        {
                            foundloc = albl;
                            break;
                        }
                    }
                    TreeNode slocnode = new TreeNode();
                    slocnode.Name = foundloc.Name;
                    slocnode.Text = foundloc.Name;
                    slocnode.Tag = foundloc;
                    tnsl.Nodes.Add(slocnode);

                    lbSpoilerSubLocs.Items.Remove(foundloc);
                    alb.SubLocations.Add(foundloc);
                }

                tab.Expand();
                tna.Expand();
                tnl.Expand();
                tnsl.Expand();
            }


            tvArea.Nodes[0].Expand();
            

            

        }

        public void SetXMLFile(FileInfo fi)
        {
            myXMLFileInfo = fi;
        }

        public void SetEditFromTitle(string e)
        {
            editFromTitle = e;
        }
      
        private void TvArea_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.  
            Point targetPoint = tvArea.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.  
            TreeNode targetNode = tvArea.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.  
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not   
            // the dragged node or a descendant of the dragged node.  
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current   
                // location and add it to the node at the drop location.  
                if (e.Effect == DragDropEffects.Move)
                {
                    if (draggedNode.Tag is AreaEditorLocationBuilderLocation)
                    {

                        TreeNode oldAreaNode = FindParentWithTag(draggedNode, typeof(AreaEditorLocationBuilder));
                        var oldarea = (AreaEditorLocationBuilder)oldAreaNode.Tag;
                           
                        var loc = (AreaEditorLocationBuilderLocation)draggedNode.Tag;

                        TreeNode newAreaNode = FindParentWithTag(targetNode, typeof(AreaEditorLocationBuilder));
                        var newarea = (AreaEditorLocationBuilder)newAreaNode.Tag;
                        if (loc.TypeOfLocation == LocationType.Location)
                        {
                            oldarea.Locations.Remove(loc);
                            draggedNode.Remove();
                            newAreaNode.Nodes[kLoc].Nodes.Add(draggedNode);
                            newAreaNode.Expand();
                            newarea.Locations.Add(loc);
                            
                        }
                        if (loc.TypeOfLocation == LocationType.SubLocation)
                        {
                            oldarea.SubLocations.Remove(loc);
                            draggedNode.Remove();
                            newAreaNode.Nodes[kSubLoc].Nodes.Add(draggedNode);
                            newAreaNode.Expand();
                            newarea.SubLocations.Add(loc);
                        }
                    }

                    if (draggedNode.Tag is AreaEditorLocationBuilder)
                    {
                        var area = (AreaEditorLocationBuilder)draggedNode.Tag;
                        area.Tab = targetNode.Name;
                        draggedNode.Remove();
                        targetNode.Nodes.Add(draggedNode);
                    }

                  
                }
                // Expand the node at the location   
                // to show the dropped node.  
                targetNode.Expand();
            }
        }

        private void TvArea_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.  
            Point targetPoint = tvArea.PointToClient(new Point(e.X, e.Y));
            TreeNode overnode = tvArea.GetNodeAt(targetPoint);

            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (overnode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (draggedNode.Tag == null || overnode.Tag == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }


            if (draggedNode.Tag is AreaEditorLocationBuilderLocation)
            {
                if (overnode.Tag is LocationTag || overnode.Tag is SubLocationTag || overnode.Tag is AreaEditorLocationBuilder || overnode.Tag is AreaEditorLocationBuilderLocation)
                {
                    e.Effect = DragDropEffects.Move;
                    return;
                }

            }

            if (draggedNode.Tag is AreaEditorLocationBuilder && overnode.Tag is TabTag)
            {
                e.Effect = DragDropEffects.Move;
                return;
            }

            e.Effect = DragDropEffects.None;



        }

        private void TvArea_DragEnter(object sender, DragEventArgs e)
        {


            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (draggedNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            else
            {
                e.Effect = e.AllowedEffect;
            }

        }

        private void TvArea_ItemDrag(object sender, ItemDragEventArgs e)
        {

            lblFeedback.Text = string.Empty;
            TreeNode tn = (TreeNode)e.Item;
            if (!(tn.Tag is AreaEditorLocationBuilder) && !(tn.Tag is AreaEditorLocationBuilderLocation))
            {
                return;
            }

            // Move the dragged node when the left mouse button is used.  
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.  

        }

        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.  
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node,   
            // call the ContainsNode method recursively using the parent of   
            // the second node.  
            return ContainsNode(node1, node2.Parent);
        }

        private void TvArea_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode tn = tvArea.SelectedNode;
            if (e.KeyCode == Keys.Delete)
            {
                if (tn.Tag is TabTag)
                {

                    List<TreeNode> locsnodes = new List<TreeNode>();
                    
                    foreach (TreeNode locs in tn.Nodes)
                    {
                        locsnodes.Add(locs);
                       
                       
                    }
                    foreach(TreeNode loc in locsnodes)
                    {
                        RemoveWholeLocation(loc);
                    }
                    tn.Remove();
                }
                if (tn.Tag is AreaEditorLocationBuilder)
                {
                    RemoveWholeLocation(tn);
                    tn.Remove();
                }
            }
        }

        private void TvArea_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode tn = e.Node;
            string newname = e.Label;
            lblFeedback.Text = string.Empty;




            if (string.IsNullOrWhiteSpace(newname))
            {

                e.CancelEdit = true;
                return;
            }


            if(tn.Tag is TitleTag)
            {
                if(currentAreaKeys.Contains(newname))
                {

                    if (!string.IsNullOrEmpty(editFromTitle) && !newname.Equals(editFromTitle))
                    {
                        lblFeedback.Text = "File with that Title already Exists!";
                        lblFeedback.ForeColor = Color.DarkRed;
                        e.CancelEdit = true;
                        return;
                    }
                }
            }

            if (tn.Tag is TabTag)
            {

                if (tvArea.Nodes.ContainsKey(newname))
                {
                    lblFeedback.Text = "Tab Names must be unique!";
                    lblFeedback.ForeColor = Color.DarkRed;
                    e.CancelEdit = true;
                    return;
                }


                foreach (TreeNode node in tn.Nodes)
                {

                    var loc = (AreaEditorLocationBuilder)node.Tag;
                    loc.Tab = tn.Text;
                    tn.Expand();
                }

            }
            if (tn.Tag is AreaEditorLocationBuilder)
            {


                if (!ValiddateSingleAreaName(newname))
                {
                    e.CancelEdit = true;
                    return;
                }
                var loc = (AreaEditorLocationBuilder)tn.Tag;
                loc.Name = tn.Text;
                tn.Expand();
            }
        }

        private void TvArea_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = e.Node;

            if (tn.Tag is TabTag || tn.Tag is AreaEditorLocationBuilder || tn == tvArea.TopNode)
            {
                tn.BeginEdit();


            }
        }

        private void TvArea_BeforeSelect1(object sender, TreeViewCancelEventArgs e)
        {
            if (tvArea.SelectedNode != null)
            {
                tvArea.SelectedNode.BackColor = SystemColors.Window;
                tvArea.SelectedNode.ForeColor = SystemColors.WindowText;
            }
        }

        private void TvArea_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = tvArea.SelectedNode;
            if (tn == null)
            {
                return;
            }

            tn.BackColor = SystemColors.HotTrack;
            tn.ForeColor = SystemColors.HighlightText;





        }

        private void BuildLocations()
        {
            int i = 0;
            foreach (string loc in LocationAndItemKeys.Locations)
            {
                AreaEditorLocationBuilderLocation albl = new AreaEditorLocationBuilderLocation(loc, i, LocationType.Location);
                i++;
                lbSpoilerLocs.Items.Add(albl);
            }

            i = 0;
            foreach (string sloc in LocationAndItemKeys.SubLocations)
            {
                AreaEditorLocationBuilderLocation albl = new AreaEditorLocationBuilderLocation(sloc, i, LocationType.SubLocation);
                i++;
                lbSpoilerSubLocs.Items.Add(albl);
            }
        }

        private void btnLocAdd_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = string.Empty;

            if (lbSpoilerLocs.SelectedIndex == -1 && lbSpoilerSubLocs.SelectedIndex == -1)
            {
                return;
            }

            TreeNode curnode = tvArea.SelectedNode;

            TreeNode areaparent = FindParentWithTag(curnode, typeof(AreaEditorLocationBuilder));

            if (!(areaparent?.Tag is AreaEditorLocationBuilder))
            {
                lblFeedback.Text = "You Must Select An Area Node to Add a Location!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }

            AreaEditorLocationBuilder alb = (AreaEditorLocationBuilder)areaparent.Tag;


            List<AreaEditorLocationBuilderLocation> locstoremove = new List<AreaEditorLocationBuilderLocation>();
            if (lbSpoilerLocs.SelectedIndex != -1)
            {
                foreach (object locobject in lbSpoilerLocs.SelectedItems)
                {
                    var loc = (AreaEditorLocationBuilderLocation)locobject;
                    locstoremove.Add(loc);
                    AddLocationNode(loc, alb, areaparent);
                }
                foreach (AreaEditorLocationBuilderLocation loc in locstoremove)
                {
                    int n = lbSpoilerLocs.SelectedIndex;
                    lbSpoilerLocs.Items.Remove(loc);

                    if (lbSpoilerLocs.Items.Count != 0)
                    {
                        if (n >= lbSpoilerLocs.Items.Count)
                        {
                            lbSpoilerLocs.SelectedIndex = lbSpoilerLocs.Items.Count - 1;
                        }
                        else
                        {
                            lbSpoilerLocs.SelectedIndex = n;
                        }
                    }
                }

            }
            if (lbSpoilerSubLocs.SelectedIndex != -1)
            {
                foreach (object locobject in lbSpoilerSubLocs.SelectedItems)
                {
                    var loc = (AreaEditorLocationBuilderLocation)locobject;
                    locstoremove.Add(loc);
                    AddLocationNode(loc, alb, areaparent);
                }
                foreach (AreaEditorLocationBuilderLocation loc in locstoremove)
                {
                    int n = lbSpoilerSubLocs.SelectedIndex;
                    lbSpoilerSubLocs.Items.Remove(loc);

                    if (lbSpoilerSubLocs.Items.Count != 0)
                    {
                        if (n >= lbSpoilerSubLocs.Items.Count)
                        {
                            lbSpoilerSubLocs.SelectedIndex = lbSpoilerSubLocs.Items.Count - 1;
                        }
                        else
                        {
                            lbSpoilerSubLocs.SelectedIndex = n;
                        }
                    }
                }
            }



        }

        private void AddLocationNode(AreaEditorLocationBuilderLocation loc, AreaEditorLocationBuilder alb, TreeNode areaparent)
        {
            

            TreeNode tn = new TreeNode();
            tn.Name = loc.Name;
            tn.Text = loc.Name;
            tn.Tag = loc;
            tn.Expand();


            TreeNode subnode = null;
            if (loc.TypeOfLocation == LocationType.Location)
            {
                alb.Locations.Add(loc);
                subnode = areaparent.Nodes[kLoc];
            }
            if (loc.TypeOfLocation == LocationType.SubLocation)
            {
                alb.SubLocations.Add(loc);
                subnode = areaparent.Nodes[kSubLoc];
            }


            subnode.Nodes.Add(tn);
            areaparent.Expand();
            subnode.Expand();
        }

        private void btnLocSub_Click(object sender, EventArgs e)
        {
            lblFeedback.Text = string.Empty;
            RemoveLocation(tvArea.SelectedNode);
           

        }

        private void AddAreaNode()
        {


            AreaEditorLocationBuilder alb = new AreaEditorLocationBuilder();
            alb.Name = tbSetAreaName.Text;


            if (string.IsNullOrWhiteSpace(alb.Name))
            {
                lblFeedback.Text = "Area Name cannot be blank!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }


            if (!ValiddateSingleAreaName(alb.Name)) { return; }


            TreeNode tabpar = FindParentWithTag(tvArea.SelectedNode, typeof(TabTag));

            if (tabpar == null)
            {
                lblFeedback.Text = "Must have a Tab Selected to add Area!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }

            alb.Tab = tabpar.Text;




            TreeNode tn = new TreeNode();
            tn.Tag = alb;
            tn.Name = alb.Name;
            tn.Text = $"{alb.Name}";




            TreeNode tnl = new TreeNode();
            tnl.Name = kLoc;
            tnl.Text = kLoc;
            tnl.Tag = new LocationTag();

            TreeNode tnsl = new TreeNode();
            tnsl.Name = kSubLoc;
            tnsl.Text = kSubLoc;
            tnsl.Tag = new SubLocationTag();

            tn.Nodes.Add(tnl);
            tn.Nodes.Add(tnsl);

            tabpar.Nodes.Add(tn);

            tn.Expand();
            tabpar.Expand();



            //if (tvArea.TopNode.Nodes.ContainsKey(alb.Tab))
            //{
            //    tvArea.TopNode.Nodes[alb.Tab].Nodes.Add(tn);
            //}
            //else
            //{
            //    TreeNode tabtn = new TreeNode();
            //    tabtn.Name = alb.Tab;
            //    tabtn.Text = alb.Tab;
            //    tabtn.Nodes.Add(tn);
            //    tabtn.Expand();
            //    tvArea.TopNode.Nodes.Add(tabtn);
            //}

            tvArea.TopNode.Expand();
            tbSetAreaName.Focus();
            tvArea.SelectedNode = tn;
            tbSetAreaName.Text = string.Empty;

        }

        private void RemoveWholeLocation(TreeNode tn)
        {
            if (tn.Nodes != null)
            {
                

                foreach (TreeNode tnsub in tn.Nodes)
                {
                    List<TreeNode> nodes = new List<TreeNode>();
                    foreach (TreeNode tnloc in tnsub.Nodes)
                    {
                        if (tnloc == null)
                        {
                            continue;
                        }
                        nodes.Add(tnloc);
                        
                    }
                    foreach (TreeNode node in nodes)
                    {
                        RemoveLocation(node);
                    }
                }
            }

            tn.Remove();

        }

        private bool ValiddateSingleAreaName(string newtabname)
        {

            foreach (TreeNode tabnode in tvArea.TopNode.Nodes)
            {
                if (tabnode.Nodes.ContainsKey(newtabname))
                {

                    lblFeedback.Text = "Area Names must be unique!";
                    lblFeedback.ForeColor = Color.DarkRed;
                    return false;
                }

            }


            return true;
        }

        private void RemoveLocation(TreeNode curnode)
        {


            

            TreeNode parnode = FindParentWithTag(curnode, typeof(AreaEditorLocationBuilder));

            if (!curnode?.Tag.GetType().Equals(typeof(AreaEditorLocationBuilderLocation)) ?? true)
            {
                lblFeedback.Text = "No Location Selected";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }

            parnode.Nodes.Remove(curnode);


            AreaEditorLocationBuilder abl = (AreaEditorLocationBuilder)parnode.Tag;
            var location = (AreaEditorLocationBuilderLocation)curnode.Tag;
            abl.Locations.Remove((AreaEditorLocationBuilderLocation)curnode.Tag);

            ListBox listbox = null;
            if (location.TypeOfLocation == LocationType.Location)
            {
                listbox = lbSpoilerLocs;
            }
            if (location.TypeOfLocation == LocationType.SubLocation)
            {
                listbox = lbSpoilerSubLocs;
            }


           
            bool added = false;

            for (int n = 0; n < listbox.Items.Count; n++)
            {
                int m = ((AreaEditorLocationBuilderLocation)listbox.Items[n]).Index;
                if (location.Index < m)
                {
                    listbox.Items.Insert(n, location);
                    added = true;
                    
                    break;
                }
            }
            if (!added)
            {
               
                listbox.Items.Add(location);
            }

        }

        private void lbSpoilerLocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSpoilerLocs.SelectedIndex != -1)
            {
                lbSpoilerSubLocs.SelectedIndex = -1;
            }
        }

        private void lbSpoilerSubLocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSpoilerSubLocs.SelectedIndex != -1)
            {
                lbSpoilerLocs.SelectedIndex = -1;
            }
        }

      

 
        private void btnAddArea_Click(object sender, EventArgs e)
        {


            if (tvArea.TopNode == null)
            {
                lblFeedback.Text = "No Group Name created yet!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }




            lblFeedback.Text = string.Empty;
            AddAreaNode();
        }

        private void btnAddTab_Click(object sender, EventArgs e)
        {

            lblFeedback.Text = string.Empty;

            string name = tbTabName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                lblFeedback.Text = "Tab Name cannot be blank!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }

            if (tvArea.TopNode.Nodes.ContainsKey(name))
            {
                lblFeedback.Text = "Tab Names must be unique!";
                lblFeedback.ForeColor = Color.DarkRed;
                return;
            }


            TreeNode tabtn = new TreeNode();
            tabtn.Name = name;
            tabtn.Text = name;
            tabtn.Tag = new TabTag();
            tvArea.TopNode.Nodes.Add(tabtn);
            tvArea.SelectedNode = tabtn;
            tvArea.TopNode.Expand();

            tbTabName.Text = string.Empty;

            tbSetAreaName.Focus();

        }

        private TreeNode FindParentWithTag(TreeNode cur, Type tag)
        {

            if (cur == null)
            {
                return null;
            }
            if (cur.Tag?.GetType().Equals(tag) ?? false)
            {
                return cur;
            }
            TreeNode parent = cur?.Parent;


            return FindParentWithTag(parent, tag);
        }

        private void tbTabName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnAddTab;
        }

        private void tbSetAreaName_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnAddArea;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            lblSearchInfo.Text = string.Empty;

            string searchfor = tbSearchFor.Text.ToLower();
            ListBox curselected = null;
            ListBox nextbox = null;
            if (lbSpoilerLocs.SelectedIndex != -1)
            {
                curselected = lbSpoilerLocs;
                if (rbDown.Checked)
                {
                    nextbox = lbSpoilerSubLocs;
                }

            }
            else if (lbSpoilerSubLocs.SelectedIndex != -1)
            {
                curselected = lbSpoilerSubLocs;
                if (rbUp.Checked)
                {
                    nextbox = lbSpoilerLocs;
                }

            }


            int startindex = 0;
            int dir = 1;

            if (rbDown.Checked)
            {
                if (curselected == null)
                {
                    curselected = lbSpoilerLocs;
                    nextbox = lbSpoilerSubLocs;
                }
                else
                {
                    var lastloc = (from object item in curselected.SelectedItems select item).LastOrDefault();
                    startindex = curselected.Items.IndexOf(lastloc)+1;
                }
                dir = 1;

            }
            else
            {
                if (curselected == null)
                {
                    curselected = lbSpoilerSubLocs;
                    startindex = lbSpoilerSubLocs.Items.Count - 1;
                }
                else
                {
                    var firstloc = (from object item in curselected.SelectedItems select item).First();
                    startindex = curselected.Items.IndexOf(firstloc) - 1;
                }
                dir = -1;
            }



            bool found = SearchForItem(startindex, dir, curselected, nextbox, searchfor);
            if(!found)
            {
                lblSearchInfo.Text = "No instances found";
            }


        }

        bool SearchForItem(int start, int dir, ListBox startingbox, ListBox nextbox, string searchfor)
        {

            if (dir < 0)
            {
                for (int n = start; n >= 0; n--)
                {
                    if(CompareAndSet(startingbox, n, searchfor)) { return true; }
                }
                if(nextbox == null)
                {
                    return false;
                }
                for(int n = nextbox.Items.Count -1; n>=0; n--)
                {
                    if (CompareAndSet(nextbox, n, searchfor)) { return true; }
                }
                return false;

            }
            else
            {
                for (int n = start; n <startingbox.Items.Count; n++)
                {
                    if (CompareAndSet(startingbox, n, searchfor)) { return true; }
                }
                if (nextbox == null)
                {
                    return false;
                }
                for (int n = 0; n < nextbox.Items.Count; n++)
                {
                    if (CompareAndSet(nextbox, n, searchfor)) { return true; }
                }
                return false;

            }
           
        }


        bool CompareAndSet(ListBox lb, int n, string searchfor)
        {
            string compare = lb.Items[n].ToString().ToLower(); 

            if(compare.Contains(searchfor))
            {
                lb.SelectedItems.Clear();
                lb.SelectedIndex = n;
                return true;
            }
            return false;
        }

        private void tbSearchFor_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = btnNext;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            XDocument doc = AreaEditorXMLBuilder.GenerateXML(tvArea.Nodes[0], myHelpText);
            XMLPreviewWindow pw = new XMLPreviewWindow(doc);
            if(DialogResult.OK == pw.ShowDialog())
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

        private void btnEditHelp_Click(object sender, EventArgs e)
        {
            HelpTextEditor hle = new HelpTextEditor(myHelpText);
            if(DialogResult.OK == hle.ShowDialog())
            {
                myHelpText = hle.HelpText;
            }
        }
    }


    class TabTag
    {

    }

    class LocationTag
    {

    }

    class SubLocationTag
    {

    }

    class TitleTag
    {

    }
}
