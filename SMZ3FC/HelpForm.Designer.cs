
namespace SMZ3FC
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.tbAreaGuide = new System.Windows.Forms.RichTextBox();
            this.tcHelp = new System.Windows.Forms.TabControl();
            this.tpMain = new System.Windows.Forms.TabPage();
            this.tbHowTo = new System.Windows.Forms.RichTextBox();
            this.tpAreaHelp = new System.Windows.Forms.TabPage();
            this.tpItemHelp = new System.Windows.Forms.TabPage();
            this.tbItems = new System.Windows.Forms.RichTextBox();
            this.tcHelp.SuspendLayout();
            this.tpMain.SuspendLayout();
            this.tpAreaHelp.SuspendLayout();
            this.tpItemHelp.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbAreaGuide
            // 
            this.tbAreaGuide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAreaGuide.Location = new System.Drawing.Point(3, 3);
            this.tbAreaGuide.Name = "tbAreaGuide";
            this.tbAreaGuide.ReadOnly = true;
            this.tbAreaGuide.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbAreaGuide.Size = new System.Drawing.Size(565, 591);
            this.tbAreaGuide.TabIndex = 0;
            this.tbAreaGuide.Text = resources.GetString("tbAreaGuide.Text");
            // 
            // tcHelp
            // 
            this.tcHelp.Controls.Add(this.tpMain);
            this.tcHelp.Controls.Add(this.tpAreaHelp);
            this.tcHelp.Controls.Add(this.tpItemHelp);
            this.tcHelp.Location = new System.Drawing.Point(12, 12);
            this.tcHelp.Name = "tcHelp";
            this.tcHelp.SelectedIndex = 0;
            this.tcHelp.Size = new System.Drawing.Size(579, 623);
            this.tcHelp.TabIndex = 1;
            // 
            // tpMain
            // 
            this.tpMain.Controls.Add(this.tbHowTo);
            this.tpMain.Location = new System.Drawing.Point(4, 22);
            this.tpMain.Name = "tpMain";
            this.tpMain.Padding = new System.Windows.Forms.Padding(3);
            this.tpMain.Size = new System.Drawing.Size(571, 597);
            this.tpMain.TabIndex = 0;
            this.tpMain.Text = "How To Use";
            this.tpMain.UseVisualStyleBackColor = true;
            // 
            // tbHowTo
            // 
            this.tbHowTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbHowTo.Location = new System.Drawing.Point(3, 3);
            this.tbHowTo.Name = "tbHowTo";
            this.tbHowTo.ReadOnly = true;
            this.tbHowTo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbHowTo.Size = new System.Drawing.Size(565, 591);
            this.tbHowTo.TabIndex = 0;
            this.tbHowTo.Text = resources.GetString("tbHowTo.Text");
            // 
            // tpAreaHelp
            // 
            this.tpAreaHelp.Controls.Add(this.tbAreaGuide);
            this.tpAreaHelp.Location = new System.Drawing.Point(4, 22);
            this.tpAreaHelp.Name = "tpAreaHelp";
            this.tpAreaHelp.Padding = new System.Windows.Forms.Padding(3);
            this.tpAreaHelp.Size = new System.Drawing.Size(571, 597);
            this.tpAreaHelp.TabIndex = 1;
            this.tpAreaHelp.Text = "Area Guide";
            this.tpAreaHelp.UseVisualStyleBackColor = true;
            // 
            // tpItemHelp
            // 
            this.tpItemHelp.Controls.Add(this.tbItems);
            this.tpItemHelp.Location = new System.Drawing.Point(4, 22);
            this.tpItemHelp.Name = "tpItemHelp";
            this.tpItemHelp.Size = new System.Drawing.Size(571, 597);
            this.tpItemHelp.TabIndex = 2;
            this.tpItemHelp.Text = "Items";
            this.tpItemHelp.UseVisualStyleBackColor = true;
            // 
            // tbItems
            // 
            this.tbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbItems.Location = new System.Drawing.Point(0, 0);
            this.tbItems.Name = "tbItems";
            this.tbItems.ReadOnly = true;
            this.tbItems.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.tbItems.Size = new System.Drawing.Size(571, 597);
            this.tbItems.TabIndex = 0;
            this.tbItems.Text = "";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 647);
            this.Controls.Add(this.tcHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "HelpForm";
            this.Text = "Help";
            this.tcHelp.ResumeLayout(false);
            this.tpMain.ResumeLayout(false);
            this.tpAreaHelp.ResumeLayout(false);
            this.tpItemHelp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox tbAreaGuide;
        private System.Windows.Forms.TabControl tcHelp;
        private System.Windows.Forms.TabPage tpMain;
        private System.Windows.Forms.TabPage tpAreaHelp;
        private System.Windows.Forms.TabPage tpItemHelp;
        private System.Windows.Forms.RichTextBox tbHowTo;
        private System.Windows.Forms.RichTextBox tbItems;
    }
}