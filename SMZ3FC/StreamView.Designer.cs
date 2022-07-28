
namespace SMZ3FC
{
    partial class StreamView
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
            this.lblStream = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStream
            // 
            this.lblStream.AutoSize = true;
            this.lblStream.Font = new System.Drawing.Font("Consolas", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStream.ForeColor = System.Drawing.SystemColors.Control;
            this.lblStream.Location = new System.Drawing.Point(12, 9);
            this.lblStream.Name = "lblStream";
            this.lblStream.Size = new System.Drawing.Size(310, 56);
            this.lblStream.TabIndex = 0;
            this.lblStream.Text = "Crateria: 1";
            // 
            // StreamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lime;
            this.ClientSize = new System.Drawing.Size(707, 78);
            this.ControlBox = false;
            this.Controls.Add(this.lblStream);
            this.Name = "StreamView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "StreamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StreamView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStream;
    }
}