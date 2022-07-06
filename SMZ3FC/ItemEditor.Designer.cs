
namespace SMZ3FC
{
    partial class ItemEditor
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
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnSubItem = new System.Windows.Forms.Button();
            this.lbFinalItems = new System.Windows.Forms.ListBox();
            this.lbItemList = new System.Windows.Forms.ListBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.lblSearchInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.rbDown = new System.Windows.Forms.RadioButton();
            this.rbUp = new System.Windows.Forms.RadioButton();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnEditHelp = new System.Windows.Forms.Button();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(178, 295);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 23);
            this.btnAddItem.TabIndex = 2;
            this.btnAddItem.Text = "<";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnSubItem
            // 
            this.btnSubItem.Location = new System.Drawing.Point(178, 324);
            this.btnSubItem.Name = "btnSubItem";
            this.btnSubItem.Size = new System.Drawing.Size(75, 26);
            this.btnSubItem.TabIndex = 3;
            this.btnSubItem.Text = ">";
            this.btnSubItem.UseVisualStyleBackColor = true;
            this.btnSubItem.Click += new System.EventHandler(this.btnSubItem_Click);
            // 
            // lbFinalItems
            // 
            this.lbFinalItems.FormattingEnabled = true;
            this.lbFinalItems.Location = new System.Drawing.Point(12, 152);
            this.lbFinalItems.Name = "lbFinalItems";
            this.lbFinalItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbFinalItems.Size = new System.Drawing.Size(160, 329);
            this.lbFinalItems.TabIndex = 4;
            // 
            // lbItemList
            // 
            this.lbItemList.FormattingEnabled = true;
            this.lbItemList.Location = new System.Drawing.Point(259, 152);
            this.lbItemList.Name = "lbItemList";
            this.lbItemList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbItemList.Size = new System.Drawing.Size(160, 329);
            this.lbItemList.TabIndex = 5;
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(12, 31);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(160, 20);
            this.tbTitle.TabIndex = 6;
            this.tbTitle.TextChanged += new System.EventHandler(this.tbTitle_TextChanged);
            this.tbTitle.Enter += new System.EventHandler(this.tbTitle_Enter);
            this.tbTitle.Leave += new System.EventHandler(this.tbTitle_Leave);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.lblSearchInfo);
            this.gbSearch.Controls.Add(this.btnNext);
            this.gbSearch.Controls.Add(this.rbDown);
            this.gbSearch.Controls.Add(this.rbUp);
            this.gbSearch.Controls.Add(this.tbSearch);
            this.gbSearch.Location = new System.Drawing.Point(202, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(217, 134);
            this.gbSearch.TabIndex = 7;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Search";
            // 
            // lblSearchInfo
            // 
            this.lblSearchInfo.AutoSize = true;
            this.lblSearchInfo.Location = new System.Drawing.Point(7, 101);
            this.lblSearchInfo.Name = "lblSearchInfo";
            this.lblSearchInfo.Size = new System.Drawing.Size(62, 13);
            this.lblSearchInfo.TabIndex = 4;
            this.lblSearchInfo.Text = "Search Info";
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(6, 71);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // rbDown
            // 
            this.rbDown.AutoSize = true;
            this.rbDown.Checked = true;
            this.rbDown.Location = new System.Drawing.Point(51, 45);
            this.rbDown.Name = "rbDown";
            this.rbDown.Size = new System.Drawing.Size(53, 17);
            this.rbDown.TabIndex = 2;
            this.rbDown.TabStop = true;
            this.rbDown.Text = "Down";
            this.rbDown.UseVisualStyleBackColor = true;
            // 
            // rbUp
            // 
            this.rbUp.AutoSize = true;
            this.rbUp.Location = new System.Drawing.Point(6, 45);
            this.rbUp.Name = "rbUp";
            this.rbUp.Size = new System.Drawing.Size(39, 17);
            this.rbUp.TabIndex = 1;
            this.rbUp.Text = "Up";
            this.rbUp.UseVisualStyleBackColor = true;
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(6, 19);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(193, 20);
            this.tbSearch.TabIndex = 0;
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(344, 489);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 42);
            this.btnPreview.TabIndex = 23;
            this.btnPreview.Text = "Preview && Save XML";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnEditHelp
            // 
            this.btnEditHelp.Location = new System.Drawing.Point(253, 489);
            this.btnEditHelp.Name = "btnEditHelp";
            this.btnEditHelp.Size = new System.Drawing.Size(75, 42);
            this.btnEditHelp.TabIndex = 24;
            this.btnEditHelp.Text = "Edit Help Text";
            this.btnEditHelp.UseVisualStyleBackColor = true;
            this.btnEditHelp.Click += new System.EventHandler(this.btnEditHelp_Click);
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(12, 61);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(55, 13);
            this.lblFeedback.TabIndex = 25;
            this.lblFeedback.Text = "Feedback";
            // 
            // ItemEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(440, 543);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.btnEditHelp);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.lbItemList);
            this.Controls.Add(this.lbFinalItems);
            this.Controls.Add(this.btnSubItem);
            this.Controls.Add(this.btnAddItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ItemEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Editor";
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSubItem;
        private System.Windows.Forms.ListBox lbFinalItems;
        private System.Windows.Forms.ListBox lbItemList;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.RadioButton rbDown;
        private System.Windows.Forms.RadioButton rbUp;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblSearchInfo;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnEditHelp;
        private System.Windows.Forms.Label lblFeedback;
    }
}