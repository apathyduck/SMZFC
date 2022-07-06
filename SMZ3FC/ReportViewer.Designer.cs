
namespace SMZ3FC
{
    partial class ReportViewer
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
            this.rtbReport = new System.Windows.Forms.RichTextBox();
            this.cbMajorsOnly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // rtbReport
            // 
            this.rtbReport.Location = new System.Drawing.Point(12, 12);
            this.rtbReport.Name = "rtbReport";
            this.rtbReport.ReadOnly = true;
            this.rtbReport.Size = new System.Drawing.Size(515, 682);
            this.rtbReport.TabIndex = 0;
            this.rtbReport.Text = "";
            // 
            // cbMajorsOnly
            // 
            this.cbMajorsOnly.AutoSize = true;
            this.cbMajorsOnly.Location = new System.Drawing.Point(416, 700);
            this.cbMajorsOnly.Name = "cbMajorsOnly";
            this.cbMajorsOnly.Size = new System.Drawing.Size(111, 17);
            this.cbMajorsOnly.TabIndex = 1;
            this.cbMajorsOnly.Text = "Only Show Majors";
            this.cbMajorsOnly.UseVisualStyleBackColor = true;
            this.cbMajorsOnly.CheckedChanged += new System.EventHandler(this.cbMajorsOnly_CheckedChanged);
            // 
            // ReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 729);
            this.Controls.Add(this.cbMajorsOnly);
            this.Controls.Add(this.rtbReport);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ReportViewer";
            this.Text = "Seed Summary";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReport;
        private System.Windows.Forms.CheckBox cbMajorsOnly;
    }
}