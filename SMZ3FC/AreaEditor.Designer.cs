
namespace SMZ3FC
{
    partial class AreaEditor
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
            this.components = new System.ComponentModel.Container();
            this.btnLocAdd = new System.Windows.Forms.Button();
            this.btnLocSub = new System.Windows.Forms.Button();
            this.lbSpoilerSubLocs = new System.Windows.Forms.ListBox();
            this.tbSetAreaName = new System.Windows.Forms.TextBox();
            this.btnAddTab = new System.Windows.Forms.Button();
            this.lbSpoilerLocs = new System.Windows.Forms.ListBox();
            this.tvArea = new System.Windows.Forms.TreeView();
            this.tbTabName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddArea = new System.Windows.Forms.Button();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblTab = new System.Windows.Forms.Label();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.tbSearchFor = new System.Windows.Forms.TextBox();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnEditHelp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLocAdd
            // 
            this.btnLocAdd.Location = new System.Drawing.Point(395, 292);
            this.btnLocAdd.Name = "btnLocAdd";
            this.btnLocAdd.Size = new System.Drawing.Size(54, 23);
            this.btnLocAdd.TabIndex = 3;
            this.btnLocAdd.TabStop = false;
            this.btnLocAdd.Text = "<";
            this.btnLocAdd.UseVisualStyleBackColor = true;
            this.btnLocAdd.Click += new System.EventHandler(this.btnLocAdd_Click);
            // 
            // btnLocSub
            // 
            this.btnLocSub.Location = new System.Drawing.Point(395, 321);
            this.btnLocSub.Name = "btnLocSub";
            this.btnLocSub.Size = new System.Drawing.Size(54, 23);
            this.btnLocSub.TabIndex = 4;
            this.btnLocSub.TabStop = false;
            this.btnLocSub.Text = ">";
            this.btnLocSub.UseVisualStyleBackColor = true;
            this.btnLocSub.Click += new System.EventHandler(this.btnLocSub_Click);
            // 
            // lbSpoilerSubLocs
            // 
            this.lbSpoilerSubLocs.FormattingEnabled = true;
            this.lbSpoilerSubLocs.Location = new System.Drawing.Point(455, 385);
            this.lbSpoilerSubLocs.Name = "lbSpoilerSubLocs";
            this.lbSpoilerSubLocs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSpoilerSubLocs.Size = new System.Drawing.Size(276, 199);
            this.lbSpoilerSubLocs.TabIndex = 7;
            this.lbSpoilerSubLocs.TabStop = false;
            this.lbSpoilerSubLocs.SelectedIndexChanged += new System.EventHandler(this.lbSpoilerSubLocs_SelectedIndexChanged);
            // 
            // tbSetAreaName
            // 
            this.tbSetAreaName.Location = new System.Drawing.Point(17, 71);
            this.tbSetAreaName.Name = "tbSetAreaName";
            this.tbSetAreaName.Size = new System.Drawing.Size(141, 20);
            this.tbSetAreaName.TabIndex = 1;
            this.tbSetAreaName.Enter += new System.EventHandler(this.tbSetAreaName_Enter);
            // 
            // btnAddTab
            // 
            this.btnAddTab.Location = new System.Drawing.Point(176, 32);
            this.btnAddTab.Name = "btnAddTab";
            this.btnAddTab.Size = new System.Drawing.Size(75, 23);
            this.btnAddTab.TabIndex = 10;
            this.btnAddTab.TabStop = false;
            this.btnAddTab.Text = "Add ";
            this.btnAddTab.UseVisualStyleBackColor = true;
            this.btnAddTab.Click += new System.EventHandler(this.btnAddTab_Click);
            // 
            // lbSpoilerLocs
            // 
            this.lbSpoilerLocs.FormattingEnabled = true;
            this.lbSpoilerLocs.Location = new System.Drawing.Point(455, 142);
            this.lbSpoilerLocs.Name = "lbSpoilerLocs";
            this.lbSpoilerLocs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSpoilerLocs.Size = new System.Drawing.Size(276, 238);
            this.lbSpoilerLocs.TabIndex = 12;
            this.lbSpoilerLocs.TabStop = false;
            this.lbSpoilerLocs.SelectedIndexChanged += new System.EventHandler(this.lbSpoilerLocs_SelectedIndexChanged);
            // 
            // tvArea
            // 
            this.tvArea.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tvArea.Location = new System.Drawing.Point(12, 142);
            this.tvArea.Name = "tvArea";
            this.tvArea.Size = new System.Drawing.Size(377, 442);
            this.tvArea.TabIndex = 14;
            this.tvArea.TabStop = false;
            // 
            // tbTabName
            // 
            this.tbTabName.Location = new System.Drawing.Point(17, 32);
            this.tbTabName.Name = "tbTabName";
            this.tbTabName.Size = new System.Drawing.Size(141, 20);
            this.tbTabName.TabIndex = 0;
            this.tbTabName.Enter += new System.EventHandler(this.tbTabName_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddArea);
            this.groupBox1.Controls.Add(this.lblArea);
            this.groupBox1.Controls.Add(this.lblTab);
            this.groupBox1.Controls.Add(this.lblFeedback);
            this.groupBox1.Controls.Add(this.tbTabName);
            this.groupBox1.Controls.Add(this.tbSetAreaName);
            this.groupBox1.Controls.Add(this.btnAddTab);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 124);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Area Creator";
            // 
            // btnAddArea
            // 
            this.btnAddArea.Location = new System.Drawing.Point(176, 71);
            this.btnAddArea.Name = "btnAddArea";
            this.btnAddArea.Size = new System.Drawing.Size(75, 23);
            this.btnAddArea.TabIndex = 14;
            this.btnAddArea.Text = "Add";
            this.btnAddArea.UseVisualStyleBackColor = true;
            this.btnAddArea.Click += new System.EventHandler(this.btnAddArea_Click);
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(14, 55);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(60, 13);
            this.lblArea.TabIndex = 13;
            this.lblArea.Text = "Area Name";
            // 
            // lblTab
            // 
            this.lblTab.AutoSize = true;
            this.lblTab.Location = new System.Drawing.Point(14, 16);
            this.lblTab.Name = "lblTab";
            this.lblTab.Size = new System.Drawing.Size(57, 13);
            this.lblTab.TabIndex = 12;
            this.lblTab.Text = "Tab Name";
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.ForeColor = System.Drawing.Color.DarkRed;
            this.lblFeedback.Location = new System.Drawing.Point(14, 94);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(52, 13);
            this.lblFeedback.TabIndex = 17;
            this.lblFeedback.Text = "feedback";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblSearchInfo);
            this.gbSearch.Controls.Add(this.btnNext);
            this.gbSearch.Controls.Add(this.tbSearchFor);
            this.gbSearch.Controls.Add(this.rbDown);
            this.gbSearch.Controls.Add(this.rbUp);
            this.gbSearch.Location = new System.Drawing.Point(455, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(281, 124);
            this.gbSearch.TabIndex = 21;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.AutoSize = true;
            this.lblSearchInfo.Location = new System.Drawing.Point(7, 92);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(62, 13);
            this.lblSearchInfo.TabIndex = 4;
            this.lblSearchInfo.Text = "Search Info";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(6, 62);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tbSearchFor
            // 
            this.tbSearchFor.Location = new System.Drawing.Point(6, 16);
            this.tbSearchFor.Name = "tbSearchFor";
            this.tbSearchFor.Size = new System.Drawing.Size(269, 20);
            this.tbSearchFor.TabIndex = 2;
            this.tbSearchFor.Enter += new System.EventHandler(this.tbSearchFor_Enter);
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(51, 39);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(53, 17);
            this.rbDown.TabIndex = 1;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "Down";
            this.rbDown.UseVisualStyleBackColor = true;
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.Location = new System.Drawing.Point(6, 39);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(39, 17);
            this.rbUp.TabIndex = 0;
            this.rbUp.Text = "Up";
            this.rbUp.UseVisualStyleBackColor = true;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(655, 590);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 42);
            this.btnPreview.TabIndex = 22;
            this.btnPreview.Text = "Preview && Save XML";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnEditHelp
            // 
            this.btnEditHelp.Location = new System.Drawing.Point(574, 590);
            this.btnEditHelp.Name = "btnEditHelp";
            this.btnEditHelp.Size = new System.Drawing.Size(75, 42);
            this.btnEditHelp.TabIndex = 23;
            this.btnEditHelp.Text = "Edit Help Text";
            this.btnEditHelp.UseVisualStyleBackColor = true;
            this.btnEditHelp.Click += new System.EventHandler(this.btnEditHelp_Click);
            // 
            // AreaEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 644);
            this.Controls.Add(this.btnEditHelp);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tvArea);
            this.Controls.Add(this.lbSpoilerLocs);
            this.Controls.Add(this.lbSpoilerSubLocs);
            this.Controls.Add(this.btnLocSub);
            this.Controls.Add(this.btnLocAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AreaEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AreaEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLocAdd;
        private System.Windows.Forms.Button btnLocSub;
        private System.Windows.Forms.ListBox lbSpoilerSubLocs;
        private System.Windows.Forms.TextBox tbSetAreaName;
        private System.Windows.Forms.Button btnAddTab;
        private System.Windows.Forms.ListBox lbSpoilerLocs;
        private System.Windows.Forms.TreeView tvArea;
        private System.Windows.Forms.TextBox tbTabName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblTab;
        private System.Windows.Forms.Button btnAddArea;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TextBox tbSearchFor;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.RadioButton rbUp;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnEditHelp;
    }
}