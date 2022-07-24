
namespace SMZ3FC
{
    partial class FriendlyNameEditor
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
            this.lbLocations = new System.Windows.Forms.ListBox();
            this.cbUse = new System.Windows.Forms.CheckBox();
            this.tbFriendly = new System.Windows.Forms.TextBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.tbArea = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbLocInfo = new System.Windows.Forms.GroupBox();
            this.btnSaveAndExit = new System.Windows.Forms.Button();
            this.gbLocInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLocations
            // 
            this.lbLocations.FormattingEnabled = true;
            this.lbLocations.Location = new System.Drawing.Point(12, 12);
            this.lbLocations.Name = "lbLocations";
            this.lbLocations.Size = new System.Drawing.Size(403, 524);
            this.lbLocations.TabIndex = 0;
            this.lbLocations.SelectedIndexChanged += new System.EventHandler(this.lbLocations_SelectedIndexChanged);
            // 
            // cbUse
            // 
            this.cbUse.AutoSize = true;
            this.cbUse.Location = new System.Drawing.Point(16, 146);
            this.cbUse.Name = "cbUse";
            this.cbUse.Size = new System.Drawing.Size(91, 17);
            this.cbUse.TabIndex = 1;
            this.cbUse.Text = "Use Preferred";
            this.cbUse.UseVisualStyleBackColor = true;
            this.cbUse.CheckedChanged += new System.EventHandler(this.cbUse_CheckedChanged);
            // 
            // tbFriendly
            // 
            this.tbFriendly.Location = new System.Drawing.Point(16, 120);
            this.tbFriendly.Name = "tbFriendly";
            this.tbFriendly.Size = new System.Drawing.Size(207, 20);
            this.tbFriendly.TabIndex = 3;
            this.tbFriendly.TextChanged += new System.EventHandler(this.tbFriendly_TextChanged);
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(16, 81);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.ReadOnly = true;
            this.tbLocation.Size = new System.Drawing.Size(207, 20);
            this.tbLocation.TabIndex = 4;
            // 
            // tbArea
            // 
            this.tbArea.Location = new System.Drawing.Point(16, 38);
            this.tbArea.Name = "tbArea";
            this.tbArea.ReadOnly = true;
            this.tbArea.Size = new System.Drawing.Size(207, 20);
            this.tbArea.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Location Spoiler Area:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Location Spoiler Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Prefered Name:";
            // 
            // gbLocInfo
            // 
            this.gbLocInfo.Controls.Add(this.tbArea);
            this.gbLocInfo.Controls.Add(this.label3);
            this.gbLocInfo.Controls.Add(this.cbUse);
            this.gbLocInfo.Controls.Add(this.label2);
            this.gbLocInfo.Controls.Add(this.tbFriendly);
            this.gbLocInfo.Controls.Add(this.label1);
            this.gbLocInfo.Controls.Add(this.tbLocation);
            this.gbLocInfo.Location = new System.Drawing.Point(421, 12);
            this.gbLocInfo.Name = "gbLocInfo";
            this.gbLocInfo.Size = new System.Drawing.Size(260, 196);
            this.gbLocInfo.TabIndex = 9;
            this.gbLocInfo.TabStop = false;
            this.gbLocInfo.Text = "Location Info";
            // 
            // btnSaveAndExit
            // 
            this.btnSaveAndExit.Location = new System.Drawing.Point(604, 501);
            this.btnSaveAndExit.Name = "btnSaveAndExit";
            this.btnSaveAndExit.Size = new System.Drawing.Size(77, 34);
            this.btnSaveAndExit.TabIndex = 10;
            this.btnSaveAndExit.Text = "Apply";
            this.btnSaveAndExit.UseVisualStyleBackColor = true;
            this.btnSaveAndExit.Click += new System.EventHandler(this.btnSaveAndExit_Click);
            // 
            // FriendlyNameEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 547);
            this.Controls.Add(this.btnSaveAndExit);
            this.Controls.Add(this.gbLocInfo);
            this.Controls.Add(this.lbLocations);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FriendlyNameEditor";
            this.Text = "Location Name Editor";
            this.gbLocInfo.ResumeLayout(false);
            this.gbLocInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbLocations;
        private System.Windows.Forms.CheckBox cbUse;
        private System.Windows.Forms.TextBox tbFriendly;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.TextBox tbArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbLocInfo;
        private System.Windows.Forms.Button btnSaveAndExit;
    }
}