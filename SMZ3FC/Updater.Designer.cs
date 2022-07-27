
namespace SMZ3FC
{
    partial class Updater
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCurVer = new System.Windows.Forms.TextBox();
            this.llPatchNotes = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLatestVer = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Version:";
            // 
            // tbCurVer
            // 
            this.tbCurVer.Location = new System.Drawing.Point(94, 6);
            this.tbCurVer.Name = "tbCurVer";
            this.tbCurVer.ReadOnly = true;
            this.tbCurVer.Size = new System.Drawing.Size(206, 20);
            this.tbCurVer.TabIndex = 1;
            // 
            // llPatchNotes
            // 
            this.llPatchNotes.AutoSize = true;
            this.llPatchNotes.Location = new System.Drawing.Point(212, 56);
            this.llPatchNotes.Name = "llPatchNotes";
            this.llPatchNotes.Size = new System.Drawing.Size(88, 13);
            this.llPatchNotes.TabIndex = 3;
            this.llPatchNotes.TabStop = true;
            this.llPatchNotes.Text = "See Patch Notes";
            this.llPatchNotes.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llPatchNotes_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Latest Version:";
            // 
            // tbLatestVer
            // 
            this.tbLatestVer.Location = new System.Drawing.Point(94, 33);
            this.tbLatestVer.Name = "tbLatestVer";
            this.tbLatestVer.ReadOnly = true;
            this.tbLatestVer.Size = new System.Drawing.Size(206, 20);
            this.tbLatestVer.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 56);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(21, 13);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Init";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(225, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Get Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 104);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tbLatestVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.llPatchNotes);
            this.Controls.Add(this.tbCurVer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Updater";
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCurVer;
        private System.Windows.Forms.LinkLabel llPatchNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLatestVer;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnUpdate;
    }
}