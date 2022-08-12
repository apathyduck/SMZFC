
namespace SMZ3FC
{
    partial class AutoTrackTestForm
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
            this.flpDebugLocs = new System.Windows.Forms.FlowLayoutPanel();
            this.cbAreas = new System.Windows.Forms.ComboBox();
            this.lblLastUpdate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.atdlDefault = new SMZ3FC.AutoTrackingDebugLoc();
            this.SuspendLayout();
            // 
            // flpDebugLocs
            // 
            this.flpDebugLocs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDebugLocs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flpDebugLocs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpDebugLocs.Location = new System.Drawing.Point(382, 12);
            this.flpDebugLocs.Name = "flpDebugLocs";
            this.flpDebugLocs.Size = new System.Drawing.Size(485, 558);
            this.flpDebugLocs.TabIndex = 0;
            // 
            // cbAreas
            // 
            this.cbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAreas.FormattingEnabled = true;
            this.cbAreas.Location = new System.Drawing.Point(47, 56);
            this.cbAreas.Name = "cbAreas";
            this.cbAreas.Size = new System.Drawing.Size(239, 21);
            this.cbAreas.TabIndex = 1;
            this.cbAreas.SelectedIndexChanged += new System.EventHandler(this.cbAreas_SelectedIndexChanged);
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.AutoSize = true;
            this.lblLastUpdate.Location = new System.Drawing.Point(44, 160);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(118, 13);
            this.lblLastUpdate.TabIndex = 0;
            this.lblLastUpdate.Text = "Last Updated Location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Area Selector";
            // 
            // atdlDefault
            // 
            this.atdlDefault.Location = new System.Drawing.Point(44, 176);
            this.atdlDefault.Name = "atdlDefault";
            this.atdlDefault.Size = new System.Drawing.Size(198, 102);
            this.atdlDefault.TabIndex = 2;
            // 
            // AutoTrackTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 615);
            this.Controls.Add(this.lblLastUpdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.atdlDefault);
            this.Controls.Add(this.cbAreas);
            this.Controls.Add(this.flpDebugLocs);
            this.Name = "AutoTrackTestForm";
            this.Text = "AutoTrackTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpDebugLocs;
        private System.Windows.Forms.ComboBox cbAreas;
        private System.Windows.Forms.Label lblLastUpdate;
        private AutoTrackingDebugLoc atdlDefault;
        private System.Windows.Forms.Label label1;
    }
}