
namespace SMZ3FC
{
    partial class WorldItemSelector
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
            this.lblGroups = new System.Windows.Forms.Label();
            this.lblItems = new System.Windows.Forms.Label();
            this.lblLocHash = new System.Windows.Forms.Label();
            this.lblItemHash = new System.Windows.Forms.Label();
            this.lblCombinedHash = new System.Windows.Forms.Label();
            this.btnSel = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbSetAsDef = new System.Windows.Forms.CheckBox();
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.lbItems = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(9, 9);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(72, 13);
            this.lblGroups.TabIndex = 2;
            this.lblGroups.Text = "Location Files";
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Location = new System.Drawing.Point(150, 9);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(51, 13);
            this.lblItems.TabIndex = 3;
            this.lblItems.Text = "Item Files";
            // 
            // lblLocHash
            // 
            this.lblLocHash.AutoSize = true;
            this.lblLocHash.Location = new System.Drawing.Point(13, 214);
            this.lblLocHash.Name = "lblLocHash";
            this.lblLocHash.Size = new System.Drawing.Size(35, 13);
            this.lblLocHash.TabIndex = 4;
            this.lblLocHash.Text = "label1";
            // 
            // lblItemHash
            // 
            this.lblItemHash.AutoSize = true;
            this.lblItemHash.Location = new System.Drawing.Point(150, 214);
            this.lblItemHash.Name = "lblItemHash";
            this.lblItemHash.Size = new System.Drawing.Size(35, 13);
            this.lblItemHash.TabIndex = 5;
            this.lblItemHash.Text = "label2";
            // 
            // lblCombinedHash
            // 
            this.lblCombinedHash.AutoSize = true;
            this.lblCombinedHash.Location = new System.Drawing.Point(13, 238);
            this.lblCombinedHash.Name = "lblCombinedHash";
            this.lblCombinedHash.Size = new System.Drawing.Size(35, 13);
            this.lblCombinedHash.TabIndex = 6;
            this.lblCombinedHash.Text = "label3";
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(209, 266);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(75, 23);
            this.btnSel.TabIndex = 7;
            this.btnSel.Text = "Select";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(124, 266);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbSetAsDef
            // 
            this.cbSetAsDef.AutoSize = true;
            this.cbSetAsDef.Location = new System.Drawing.Point(12, 270);
            this.cbSetAsDef.Name = "cbSetAsDef";
            this.cbSetAsDef.Size = new System.Drawing.Size(98, 17);
            this.cbSetAsDef.TabIndex = 9;
            this.cbSetAsDef.Text = "Set as Defaults";
            this.cbSetAsDef.UseVisualStyleBackColor = true;
            this.cbSetAsDef.CheckedChanged += new System.EventHandler(this.cbSetAsDef_CheckedChanged);
            // 
            // lbGroups
            // 
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(12, 25);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.Size = new System.Drawing.Size(133, 186);
            this.lbGroups.TabIndex = 10;
            this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            // 
            // lbItems
            // 
            this.lbItems.FormattingEnabled = true;
            this.lbItems.Location = new System.Drawing.Point(151, 25);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(133, 186);
            this.lbItems.TabIndex = 11;
            this.lbItems.SelectedIndexChanged += new System.EventHandler(this.lb_SelectedIndexChanged);
            // 
            // GroupSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 300);
            this.ControlBox = false;
            this.Controls.Add(this.lbItems);
            this.Controls.Add(this.lbGroups);
            this.Controls.Add(this.cbSetAsDef);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSel);
            this.Controls.Add(this.lblCombinedHash);
            this.Controls.Add(this.lblItemHash);
            this.Controls.Add(this.lblLocHash);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.lblGroups);
            this.Name = "GroupSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.Label lblLocHash;
        private System.Windows.Forms.Label lblItemHash;
        private System.Windows.Forms.Label lblCombinedHash;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox cbSetAsDef;
        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.ListBox lbItems;
    }
}