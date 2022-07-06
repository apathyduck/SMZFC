
namespace SMZ3FC
{
    partial class SubLocViewer
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
            this.rtbSubLocs = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtbSubLocs
            // 
            this.rtbSubLocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbSubLocs.Location = new System.Drawing.Point(0, 0);
            this.rtbSubLocs.Name = "rtbSubLocs";
            this.rtbSubLocs.ReadOnly = true;
            this.rtbSubLocs.Size = new System.Drawing.Size(320, 450);
            this.rtbSubLocs.TabIndex = 0;
            this.rtbSubLocs.Text = "";
            // 
            // SubLocViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(320, 450);
            this.ControlBox = false;
            this.Controls.Add(this.rtbSubLocs);
            this.Name = "SubLocViewer";
            this.Text = "SubLocViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSubLocs;
    }
}