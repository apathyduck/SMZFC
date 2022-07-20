
namespace SMZ3FC
{
    partial class ItemCountViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblHash = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.mnViewerMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSpoilerLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectGroupingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadXMLsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.areaEdiotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationNameEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyHashesToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.streamviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subLocationWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblGroupHash = new System.Windows.Forms.Label();
            this.tabLocationTab = new System.Windows.Forms.TabControl();
            this.tpSMLocs = new System.Windows.Forms.TabPage();
            this.flpSM = new System.Windows.Forms.FlowLayoutPanel();
            this.tpALTTPLocs = new System.Windows.Forms.TabPage();
            this.flpALTTP = new System.Windows.Forms.FlowLayoutPanel();
            this.ofdOpenSpoilerBrowser = new System.Windows.Forms.OpenFileDialog();
            this.pnLoadSpoilerBlank = new System.Windows.Forms.Panel();
            this.lblDragAndDrop = new System.Windows.Forms.Label();
            this.mnViewerMenu.SuspendLayout();
            this.tabLocationTab.SuspendLayout();
            this.tpSMLocs.SuspendLayout();
            this.tpALTTPLocs.SuspendLayout();
            this.pnLoadSpoilerBlank.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHash
            // 
            this.lblHash.AutoSize = true;
            this.lblHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHash.Location = new System.Drawing.Point(19, 24);
            this.lblHash.Name = "lblHash";
            this.lblHash.Size = new System.Drawing.Size(331, 29);
            this.lblHash.TabIndex = 1;
            this.lblHash.Text = "Spoiler Hash: No File Loaded";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(15, 647);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(341, 41);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total Items: 0/57";
            // 
            // mnViewerMenu
            // 
            this.mnViewerMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ediToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnViewerMenu.Location = new System.Drawing.Point(0, 0);
            this.mnViewerMenu.Name = "mnViewerMenu";
            this.mnViewerMenu.Size = new System.Drawing.Size(574, 24);
            this.mnViewerMenu.TabIndex = 4;
            this.mnViewerMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSpoilerLogToolStripMenuItem,
            this.selectGroupingFileToolStripMenuItem,
            this.generateReportToolStripMenuItem,
            this.downloadXMLsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadSpoilerLogToolStripMenuItem
            // 
            this.loadSpoilerLogToolStripMenuItem.Name = "loadSpoilerLogToolStripMenuItem";
            this.loadSpoilerLogToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadSpoilerLogToolStripMenuItem.Text = "Load Spoiler Log";
            this.loadSpoilerLogToolStripMenuItem.Click += new System.EventHandler(this.loadSpoilerLogToolStripMenuItem_Click);
            // 
            // selectGroupingFileToolStripMenuItem
            // 
            this.selectGroupingFileToolStripMenuItem.Name = "selectGroupingFileToolStripMenuItem";
            this.selectGroupingFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.selectGroupingFileToolStripMenuItem.Text = "Select Grouping File";
            this.selectGroupingFileToolStripMenuItem.Click += new System.EventHandler(this.selectGroupingFileToolStripMenuItem_Click);
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.generateReportToolStripMenuItem.Text = "Generate Report";
            this.generateReportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // downloadXMLsToolStripMenuItem
            // 
            this.downloadXMLsToolStripMenuItem.Name = "downloadXMLsToolStripMenuItem";
            this.downloadXMLsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.downloadXMLsToolStripMenuItem.Text = "Download XMLs";
            this.downloadXMLsToolStripMenuItem.Click += new System.EventHandler(this.downloadXMLsToolStripMenuItem_Click);
            // 
            // ediToolStripMenuItem
            // 
            this.ediToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.areaEdiotToolStripMenuItem,
            this.itemEditorToolStripMenuItem,
            this.locationNameEditorToolStripMenuItem,
            this.copyHashesToClipboardToolStripMenuItem});
            this.ediToolStripMenuItem.Name = "ediToolStripMenuItem";
            this.ediToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.ediToolStripMenuItem.Text = "Edit";
            // 
            // areaEdiotToolStripMenuItem
            // 
            this.areaEdiotToolStripMenuItem.Name = "areaEdiotToolStripMenuItem";
            this.areaEdiotToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.areaEdiotToolStripMenuItem.Text = "Area Editor";
            this.areaEdiotToolStripMenuItem.Click += new System.EventHandler(this.areaEdiotToolStripMenuItem_Click);
            // 
            // itemEditorToolStripMenuItem
            // 
            this.itemEditorToolStripMenuItem.Name = "itemEditorToolStripMenuItem";
            this.itemEditorToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.itemEditorToolStripMenuItem.Text = "Item Editor";
            this.itemEditorToolStripMenuItem.Click += new System.EventHandler(this.itemEditorToolStripMenuItem_Click);
            // 
            // locationNameEditorToolStripMenuItem
            // 
            this.locationNameEditorToolStripMenuItem.Name = "locationNameEditorToolStripMenuItem";
            this.locationNameEditorToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.locationNameEditorToolStripMenuItem.Text = "Location Name Editor";
            this.locationNameEditorToolStripMenuItem.Click += new System.EventHandler(this.locationNameEditorToolStripMenuItem_Click);
            // 
            // copyHashesToClipboardToolStripMenuItem
            // 
            this.copyHashesToClipboardToolStripMenuItem.Name = "copyHashesToClipboardToolStripMenuItem";
            this.copyHashesToClipboardToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.copyHashesToClipboardToolStripMenuItem.Text = "Copy Hashes To Clipboard";
            this.copyHashesToClipboardToolStripMenuItem.Click += new System.EventHandler(this.copyHashesToClipboardToolStripMenuItem_Click_1);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.streamviewToolStripMenuItem,
            this.subLocationWindowToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // streamviewToolStripMenuItem
            // 
            this.streamviewToolStripMenuItem.Name = "streamviewToolStripMenuItem";
            this.streamviewToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.streamviewToolStripMenuItem.Text = "Streamview";
            this.streamviewToolStripMenuItem.Click += new System.EventHandler(this.streamviewToolStripMenuItem_Click);
            // 
            // subLocationWindowToolStripMenuItem
            // 
            this.subLocationWindowToolStripMenuItem.Name = "subLocationWindowToolStripMenuItem";
            this.subLocationWindowToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.subLocationWindowToolStripMenuItem.Text = "Sub Location Window";
            this.subLocationWindowToolStripMenuItem.Click += new System.EventHandler(this.subLocationWindowToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.getHelpToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.helpToolStripMenuItem.Text = "Other";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // getHelpToolStripMenuItem
            // 
            this.getHelpToolStripMenuItem.Name = "getHelpToolStripMenuItem";
            this.getHelpToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.getHelpToolStripMenuItem.Text = "Get Help";
            this.getHelpToolStripMenuItem.Click += new System.EventHandler(this.getHelpToolStripMenuItem_Click);
            // 
            // lblGroupHash
            // 
            this.lblGroupHash.AutoSize = true;
            this.lblGroupHash.Location = new System.Drawing.Point(21, 60);
            this.lblGroupHash.Name = "lblGroupHash";
            this.lblGroupHash.Size = new System.Drawing.Size(101, 13);
            this.lblGroupHash.TabIndex = 5;
            this.lblGroupHash.Text = "Group Hash: NONE";
            // 
            // tabLocationTab
            // 
            this.tabLocationTab.Controls.Add(this.tpSMLocs);
            this.tabLocationTab.Controls.Add(this.tpALTTPLocs);
            this.tabLocationTab.Location = new System.Drawing.Point(22, 76);
            this.tabLocationTab.Name = "tabLocationTab";
            this.tabLocationTab.SelectedIndex = 0;
            this.tabLocationTab.Size = new System.Drawing.Size(540, 568);
            this.tabLocationTab.TabIndex = 6;
            // 
            // tpSMLocs
            // 
            this.tpSMLocs.Controls.Add(this.flpSM);
            this.tpSMLocs.Location = new System.Drawing.Point(4, 22);
            this.tpSMLocs.Name = "tpSMLocs";
            this.tpSMLocs.Padding = new System.Windows.Forms.Padding(3);
            this.tpSMLocs.Size = new System.Drawing.Size(532, 542);
            this.tpSMLocs.TabIndex = 0;
            this.tpSMLocs.Text = "SM";
            this.tpSMLocs.UseVisualStyleBackColor = true;
            // 
            // flpSM
            // 
            this.flpSM.AutoSize = true;
            this.flpSM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSM.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSM.Location = new System.Drawing.Point(3, 3);
            this.flpSM.Name = "flpSM";
            this.flpSM.Size = new System.Drawing.Size(526, 536);
            this.flpSM.TabIndex = 0;
            // 
            // tpALTTPLocs
            // 
            this.tpALTTPLocs.Controls.Add(this.flpALTTP);
            this.tpALTTPLocs.Location = new System.Drawing.Point(4, 22);
            this.tpALTTPLocs.Name = "tpALTTPLocs";
            this.tpALTTPLocs.Padding = new System.Windows.Forms.Padding(3);
            this.tpALTTPLocs.Size = new System.Drawing.Size(532, 542);
            this.tpALTTPLocs.TabIndex = 1;
            this.tpALTTPLocs.Text = "ALTTP";
            this.tpALTTPLocs.UseVisualStyleBackColor = true;
            // 
            // flpALTTP
            // 
            this.flpALTTP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpALTTP.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpALTTP.Location = new System.Drawing.Point(3, 3);
            this.flpALTTP.Name = "flpALTTP";
            this.flpALTTP.Size = new System.Drawing.Size(526, 536);
            this.flpALTTP.TabIndex = 0;
            // 
            // pnLoadSpoilerBlank
            // 
            this.pnLoadSpoilerBlank.AllowDrop = true;
            this.pnLoadSpoilerBlank.Controls.Add(this.lblDragAndDrop);
            this.pnLoadSpoilerBlank.Location = new System.Drawing.Point(13, 56);
            this.pnLoadSpoilerBlank.Name = "pnLoadSpoilerBlank";
            this.pnLoadSpoilerBlank.Size = new System.Drawing.Size(549, 632);
            this.pnLoadSpoilerBlank.TabIndex = 7;
            this.pnLoadSpoilerBlank.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnLoadSpoilerBlank_DragDrop);
            this.pnLoadSpoilerBlank.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnLoadSpoilerBlank_DragEnter);
            // 
            // lblDragAndDrop
            // 
            this.lblDragAndDrop.AutoSize = true;
            this.lblDragAndDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDragAndDrop.Location = new System.Drawing.Point(36, 280);
            this.lblDragAndDrop.Name = "lblDragAndDrop";
            this.lblDragAndDrop.Size = new System.Drawing.Size(485, 31);
            this.lblDragAndDrop.TabIndex = 0;
            this.lblDragAndDrop.Text = "Drag And Drop Spoiler Log File to Load";
            // 
            // ItemCountViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 695);
            this.Controls.Add(this.pnLoadSpoilerBlank);
            this.Controls.Add(this.tabLocationTab);
            this.Controls.Add(this.lblGroupHash);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblHash);
            this.Controls.Add(this.mnViewerMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mnViewerMenu;
            this.Name = "ItemCountViewer";
            this.Text = "SMZ3 Full Countdown";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ItemCountViewer_FormClosed);
            this.mnViewerMenu.ResumeLayout(false);
            this.mnViewerMenu.PerformLayout();
            this.tabLocationTab.ResumeLayout(false);
            this.tpSMLocs.ResumeLayout(false);
            this.tpSMLocs.PerformLayout();
            this.tpALTTPLocs.ResumeLayout(false);
            this.pnLoadSpoilerBlank.ResumeLayout(false);
            this.pnLoadSpoilerBlank.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblHash;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.MenuStrip mnViewerMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadSpoilerLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectGroupingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getHelpToolStripMenuItem;
        private System.Windows.Forms.Label lblGroupHash;
        private System.Windows.Forms.TabControl tabLocationTab;
        private System.Windows.Forms.TabPage tpSMLocs;
        private System.Windows.Forms.FlowLayoutPanel flpSM;
        private System.Windows.Forms.TabPage tpALTTPLocs;
        private System.Windows.Forms.FlowLayoutPanel flpALTTP;
        private System.Windows.Forms.OpenFileDialog ofdOpenSpoilerBrowser;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Panel pnLoadSpoilerBlank;
        private System.Windows.Forms.Label lblDragAndDrop;
        private System.Windows.Forms.ToolStripMenuItem ediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem areaEdiotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem streamviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subLocationWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyHashesToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadXMLsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locationNameEditorToolStripMenuItem;
    }
}