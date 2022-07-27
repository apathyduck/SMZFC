
namespace SMZ3FC
{
    partial class FormGitXML
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
            this.pbSync = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbAreaDown = new System.Windows.Forms.ListBox();
            this.lbItemsDown = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // pbSync
            // 
            this.pbSync.Location = new System.Drawing.Point(10, 94);
            this.pbSync.Name = "pbSync";
            this.pbSync.Size = new System.Drawing.Size(179, 23);
            this.pbSync.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Area Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item Files";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(552, 572);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 41);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Download All Selected";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sync Progess";
            // 
            // lbAreaDown
            // 
            this.lbAreaDown.FormattingEnabled = true;
            this.lbAreaDown.Location = new System.Drawing.Point(10, 149);
            this.lbAreaDown.Name = "lbAreaDown";
            this.lbAreaDown.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbAreaDown.Size = new System.Drawing.Size(304, 420);
            this.lbAreaDown.TabIndex = 0;
            // 
            // lbItemsDown
            // 
            this.lbItemsDown.FormattingEnabled = true;
            this.lbItemsDown.Location = new System.Drawing.Point(323, 149);
            this.lbItemsDown.Name = "lbItemsDown";
            this.lbItemsDown.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbItemsDown.Size = new System.Drawing.Size(304, 420);
            this.lbItemsDown.TabIndex = 1;
            // 
            // FormGitXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 623);
            this.Controls.Add(this.lbItemsDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAreaDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pbSync);
            this.Name = "FormGitXML";
            this.Text = "FormGitXML";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormGitXML_FormClosing);
            this.Load += new System.EventHandler(this.FormGitXML_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbAreaDown;
        private System.Windows.Forms.ListBox lbItemsDown;
    }
}