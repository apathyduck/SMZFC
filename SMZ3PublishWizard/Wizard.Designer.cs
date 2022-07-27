
namespace SMZ3PublishWizard
{
    partial class Wizard
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
            this.tbServerVer = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbServerMandatory = new System.Windows.Forms.CheckBox();
            this.tbServerChange = new System.Windows.Forms.TextBox();
            this.tbServerAsset = new System.Windows.Forms.TextBox();
            this.clbReleaseDirItems = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbLocalMandatory = new System.Windows.Forms.CheckBox();
            this.tbLocalChange = new System.Windows.Forms.TextBox();
            this.tbLocalAsset = new System.Windows.Forms.TextBox();
            this.tbLocalVersion = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbNewMandatory = new System.Windows.Forms.CheckBox();
            this.tbNewChange = new System.Windows.Forms.TextBox();
            this.tbNewAsset = new System.Windows.Forms.TextBox();
            this.tbNewVersion = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.btnApplyUpdate = new System.Windows.Forms.Button();
            this.rtbPatchNotes = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblUpdateStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbServerVer
            // 
            this.tbServerVer.Location = new System.Drawing.Point(88, 25);
            this.tbServerVer.Name = "tbServerVer";
            this.tbServerVer.ReadOnly = true;
            this.tbServerVer.Size = new System.Drawing.Size(300, 20);
            this.tbServerVer.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbServerMandatory);
            this.groupBox1.Controls.Add(this.tbServerChange);
            this.groupBox1.Controls.Add(this.tbServerAsset);
            this.groupBox1.Controls.Add(this.tbServerVer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Config Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Asset Url:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Changelog Url:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Version:";
            // 
            // cbServerMandatory
            // 
            this.cbServerMandatory.AutoSize = true;
            this.cbServerMandatory.Enabled = false;
            this.cbServerMandatory.Location = new System.Drawing.Point(88, 103);
            this.cbServerMandatory.Name = "cbServerMandatory";
            this.cbServerMandatory.Size = new System.Drawing.Size(76, 17);
            this.cbServerMandatory.TabIndex = 3;
            this.cbServerMandatory.Text = "Mandatory";
            this.cbServerMandatory.UseVisualStyleBackColor = true;
            // 
            // tbServerChange
            // 
            this.tbServerChange.Location = new System.Drawing.Point(88, 77);
            this.tbServerChange.Name = "tbServerChange";
            this.tbServerChange.ReadOnly = true;
            this.tbServerChange.Size = new System.Drawing.Size(300, 20);
            this.tbServerChange.TabIndex = 2;
            // 
            // tbServerAsset
            // 
            this.tbServerAsset.Location = new System.Drawing.Point(88, 51);
            this.tbServerAsset.Name = "tbServerAsset";
            this.tbServerAsset.ReadOnly = true;
            this.tbServerAsset.Size = new System.Drawing.Size(300, 20);
            this.tbServerAsset.TabIndex = 1;
            // 
            // clbReleaseDirItems
            // 
            this.clbReleaseDirItems.FormattingEnabled = true;
            this.clbReleaseDirItems.Location = new System.Drawing.Point(18, 19);
            this.clbReleaseDirItems.Name = "clbReleaseDirItems";
            this.clbReleaseDirItems.Size = new System.Drawing.Size(403, 334);
            this.clbReleaseDirItems.TabIndex = 7;
            this.clbReleaseDirItems.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbReleaseDirItems_ItemCheck);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbLocalMandatory);
            this.groupBox2.Controls.Add(this.tbLocalChange);
            this.groupBox2.Controls.Add(this.tbLocalAsset);
            this.groupBox2.Controls.Add(this.tbLocalVersion);
            this.groupBox2.Location = new System.Drawing.Point(12, 146);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(403, 128);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local Config Info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Asset Url:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Changelog Url:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Version:";
            // 
            // cbLocalMandatory
            // 
            this.cbLocalMandatory.AutoSize = true;
            this.cbLocalMandatory.Enabled = false;
            this.cbLocalMandatory.Location = new System.Drawing.Point(88, 103);
            this.cbLocalMandatory.Name = "cbLocalMandatory";
            this.cbLocalMandatory.Size = new System.Drawing.Size(76, 17);
            this.cbLocalMandatory.TabIndex = 3;
            this.cbLocalMandatory.Text = "Mandatory";
            this.cbLocalMandatory.UseVisualStyleBackColor = true;
            // 
            // tbLocalChange
            // 
            this.tbLocalChange.Location = new System.Drawing.Point(88, 77);
            this.tbLocalChange.Name = "tbLocalChange";
            this.tbLocalChange.ReadOnly = true;
            this.tbLocalChange.Size = new System.Drawing.Size(300, 20);
            this.tbLocalChange.TabIndex = 2;
            // 
            // tbLocalAsset
            // 
            this.tbLocalAsset.Location = new System.Drawing.Point(88, 51);
            this.tbLocalAsset.Name = "tbLocalAsset";
            this.tbLocalAsset.ReadOnly = true;
            this.tbLocalAsset.Size = new System.Drawing.Size(300, 20);
            this.tbLocalAsset.TabIndex = 1;
            // 
            // tbLocalVersion
            // 
            this.tbLocalVersion.Location = new System.Drawing.Point(88, 25);
            this.tbLocalVersion.Name = "tbLocalVersion";
            this.tbLocalVersion.ReadOnly = true;
            this.tbLocalVersion.Size = new System.Drawing.Size(300, 20);
            this.tbLocalVersion.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cbNewMandatory);
            this.groupBox3.Controls.Add(this.tbNewChange);
            this.groupBox3.Controls.Add(this.tbNewAsset);
            this.groupBox3.Controls.Add(this.tbNewVersion);
            this.groupBox3.Location = new System.Drawing.Point(12, 280);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 128);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "New Config Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Asset Url:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Changelog Url:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Version:";
            // 
            // cbNewMandatory
            // 
            this.cbNewMandatory.AutoSize = true;
            this.cbNewMandatory.Location = new System.Drawing.Point(88, 103);
            this.cbNewMandatory.Name = "cbNewMandatory";
            this.cbNewMandatory.Size = new System.Drawing.Size(76, 17);
            this.cbNewMandatory.TabIndex = 3;
            this.cbNewMandatory.Text = "Mandatory";
            this.cbNewMandatory.UseVisualStyleBackColor = true;
            // 
            // tbNewChange
            // 
            this.tbNewChange.Location = new System.Drawing.Point(88, 77);
            this.tbNewChange.Name = "tbNewChange";
            this.tbNewChange.ReadOnly = true;
            this.tbNewChange.Size = new System.Drawing.Size(300, 20);
            this.tbNewChange.TabIndex = 2;
            // 
            // tbNewAsset
            // 
            this.tbNewAsset.Location = new System.Drawing.Point(88, 51);
            this.tbNewAsset.Name = "tbNewAsset";
            this.tbNewAsset.ReadOnly = true;
            this.tbNewAsset.Size = new System.Drawing.Size(300, 20);
            this.tbNewAsset.TabIndex = 1;
            // 
            // tbNewVersion
            // 
            this.tbNewVersion.Location = new System.Drawing.Point(88, 25);
            this.tbNewVersion.Name = "tbNewVersion";
            this.tbNewVersion.ReadOnly = true;
            this.tbNewVersion.Size = new System.Drawing.Size(300, 20);
            this.tbNewVersion.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbUpdate);
            this.groupBox4.Controls.Add(this.rbNew);
            this.groupBox4.Controls.Add(this.clbReleaseDirItems);
            this.groupBox4.Location = new System.Drawing.Point(421, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(438, 395);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Package BOMs";
            // 
            // rbUpdate
            // 
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Location = new System.Drawing.Point(315, 369);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.Size = new System.Drawing.Size(106, 17);
            this.rbUpdate.TabIndex = 11;
            this.rbUpdate.Text = "Update Package";
            this.rbUpdate.UseVisualStyleBackColor = true;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Location = new System.Drawing.Point(216, 369);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(93, 17);
            this.rbNew.TabIndex = 10;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New Package";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // btnApplyUpdate
            // 
            this.btnApplyUpdate.Location = new System.Drawing.Point(784, 681);
            this.btnApplyUpdate.Name = "btnApplyUpdate";
            this.btnApplyUpdate.Size = new System.Drawing.Size(75, 34);
            this.btnApplyUpdate.TabIndex = 12;
            this.btnApplyUpdate.Text = "Apply Update";
            this.btnApplyUpdate.UseVisualStyleBackColor = true;
            this.btnApplyUpdate.Click += new System.EventHandler(this.btnApplyUpdate_Click);
            // 
            // rtbPatchNotes
            // 
            this.rtbPatchNotes.Location = new System.Drawing.Point(12, 436);
            this.rtbPatchNotes.Name = "rtbPatchNotes";
            this.rtbPatchNotes.Size = new System.Drawing.Size(403, 279);
            this.rtbPatchNotes.TabIndex = 13;
            this.rtbPatchNotes.Text = "";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Create Patch Notes";
            // 
            // lblUpdateStatus
            // 
            this.lblUpdateStatus.AutoSize = true;
            this.lblUpdateStatus.Location = new System.Drawing.Point(421, 705);
            this.lblUpdateStatus.Name = "lblUpdateStatus";
            this.lblUpdateStatus.Size = new System.Drawing.Size(75, 13);
            this.lblUpdateStatus.TabIndex = 15;
            this.lblUpdateStatus.Text = "Update Status";
            // 
            // Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 727);
            this.Controls.Add(this.lblUpdateStatus);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rtbPatchNotes);
            this.Controls.Add(this.btnApplyUpdate);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Wizard";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbServerVer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbServerMandatory;
        private System.Windows.Forms.TextBox tbServerChange;
        private System.Windows.Forms.TextBox tbServerAsset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox clbReleaseDirItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbLocalMandatory;
        private System.Windows.Forms.TextBox tbLocalChange;
        private System.Windows.Forms.TextBox tbLocalAsset;
        private System.Windows.Forms.TextBox tbLocalVersion;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbNewMandatory;
        private System.Windows.Forms.TextBox tbNewChange;
        private System.Windows.Forms.TextBox tbNewAsset;
        private System.Windows.Forms.TextBox tbNewVersion;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbUpdate;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.Button btnApplyUpdate;
        private System.Windows.Forms.RichTextBox rtbPatchNotes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblUpdateStatus;
    }
}

