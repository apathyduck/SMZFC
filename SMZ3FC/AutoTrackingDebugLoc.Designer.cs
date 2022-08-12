
namespace SMZ3FC
{
    partial class AutoTrackingDebugLoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLocName = new System.Windows.Forms.GroupBox();
            this.cbFound = new System.Windows.Forms.CheckBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblMask = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.gbLocName.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLocName
            // 
            this.gbLocName.Controls.Add(this.cbFound);
            this.gbLocName.Controls.Add(this.lblValue);
            this.gbLocName.Controls.Add(this.lblMask);
            this.gbLocName.Controls.Add(this.lblAdd);
            this.gbLocName.Controls.Add(this.lblItem);
            this.gbLocName.Location = new System.Drawing.Point(3, 3);
            this.gbLocName.Name = "gbLocName";
            this.gbLocName.Size = new System.Drawing.Size(279, 94);
            this.gbLocName.TabIndex = 1;
            this.gbLocName.TabStop = false;
            this.gbLocName.Text = "Name";
            // 
            // cbFound
            // 
            this.cbFound.AutoCheck = false;
            this.cbFound.AutoSize = true;
            this.cbFound.Location = new System.Drawing.Point(9, 74);
            this.cbFound.Name = "cbFound";
            this.cbFound.Size = new System.Drawing.Size(56, 17);
            this.cbFound.TabIndex = 5;
            this.cbFound.Text = "Found";
            this.cbFound.UseVisualStyleBackColor = true;
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(6, 57);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(61, 13);
            this.lblValue.TabIndex = 4;
            this.lblValue.Text = "Add Vallue:";
            // 
            // lblMask
            // 
            this.lblMask.AutoSize = true;
            this.lblMask.Location = new System.Drawing.Point(6, 44);
            this.lblMask.Name = "lblMask";
            this.lblMask.Size = new System.Drawing.Size(36, 13);
            this.lblMask.TabIndex = 3;
            this.lblMask.Text = "Mask:";
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.Location = new System.Drawing.Point(6, 31);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(48, 13);
            this.lblAdd.TabIndex = 2;
            this.lblAdd.Text = "Address:";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(6, 18);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 13);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "Item:";
            // 
            // AutoTrackingDebugLoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLocName);
            this.Name = "AutoTrackingDebugLoc";
            this.Size = new System.Drawing.Size(285, 102);
            this.gbLocName.ResumeLayout(false);
            this.gbLocName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbLocName;
        private System.Windows.Forms.CheckBox cbFound;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblMask;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.Label lblItem;
    }
}
