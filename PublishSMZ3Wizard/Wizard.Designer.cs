
namespace PublishSMZ3Wizard
{
    partial class Wizard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbMajor = new System.Windows.Forms.TextBox();
            this.tbMInor = new System.Windows.Forms.TextBox();
            this.tbPatch = new System.Windows.Forms.TextBox();
            this.tbBuild = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSerVersion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbAssests = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMajor
            // 
            this.tbMajor.Location = new System.Drawing.Point(13, 39);
            this.tbMajor.Name = "tbMajor";
            this.tbMajor.Size = new System.Drawing.Size(56, 23);
            this.tbMajor.TabIndex = 0;
            // 
            // tbMInor
            // 
            this.tbMInor.Location = new System.Drawing.Point(75, 39);
            this.tbMInor.Name = "tbMInor";
            this.tbMInor.Size = new System.Drawing.Size(56, 23);
            this.tbMInor.TabIndex = 1;
            // 
            // tbPatch
            // 
            this.tbPatch.Location = new System.Drawing.Point(137, 39);
            this.tbPatch.Name = "tbPatch";
            this.tbPatch.Size = new System.Drawing.Size(56, 23);
            this.tbPatch.TabIndex = 2;
            // 
            // tbBuild
            // 
            this.tbBuild.Location = new System.Drawing.Point(199, 39);
            this.tbBuild.Name = "tbBuild";
            this.tbBuild.Size = new System.Drawing.Size(56, 23);
            this.tbBuild.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSerVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBuild);
            this.groupBox1.Controls.Add(this.tbPatch);
            this.groupBox1.Controls.Add(this.tbMInor);
            this.groupBox1.Controls.Add(this.tbMajor);
            this.groupBox1.Location = new System.Drawing.Point(24, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 145);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set New Verison #";
            // 
            // tbSerVersion
            // 
            this.tbSerVersion.Location = new System.Drawing.Point(75, 68);
            this.tbSerVersion.Name = "tbSerVersion";
            this.tbSerVersion.ReadOnly = true;
            this.tbSerVersion.Size = new System.Drawing.Size(180, 23);
            this.tbSerVersion.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Old Ver #:";
            // 
            // lbAssests
            // 
            this.lbAssests.FormattingEnabled = true;
            this.lbAssests.ItemHeight = 15;
            this.lbAssests.Location = new System.Drawing.Point(24, 218);
            this.lbAssests.Name = "lbAssests";
            this.lbAssests.Size = new System.Drawing.Size(324, 169);
            this.lbAssests.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Select Update Asset";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbAssests);
            this.Controls.Add(this.groupBox1);
            this.Name = "Wizard";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbMajor;
        private System.Windows.Forms.TextBox tbMInor;
        private System.Windows.Forms.TextBox tbPatch;
        private System.Windows.Forms.TextBox tbBuild;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbSerVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbAssests;
        private System.Windows.Forms.Label label2;
    }
}

