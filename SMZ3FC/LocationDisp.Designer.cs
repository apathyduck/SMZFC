
namespace SMZ3FC
{
    partial class LocationDisp
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
            this.components = new System.ComponentModel.Container();
            this.rbShow = new System.Windows.Forms.RadioButton();
            this.rbHide = new System.Windows.Forms.RadioButton();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSub = new System.Windows.Forms.Button();
            this.tipLocationList = new System.Windows.Forms.ToolTip(this.components);
            this.lblTotalItemSmall = new System.Windows.Forms.Label();
            this.gbTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbShow
            // 
            this.rbShow.AutoSize = true;
            this.rbShow.Location = new System.Drawing.Point(20, 19);
            this.rbShow.Name = "rbShow";
            this.rbShow.Size = new System.Drawing.Size(52, 17);
            this.rbShow.TabIndex = 0;
            this.rbShow.Text = "Show";
            this.rbShow.UseVisualStyleBackColor = true;
            this.rbShow.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // rbHide
            // 
            this.rbHide.AutoSize = true;
            this.rbHide.Checked = true;
            this.rbHide.Location = new System.Drawing.Point(20, 42);
            this.rbHide.Name = "rbHide";
            this.rbHide.Size = new System.Drawing.Size(47, 17);
            this.rbHide.TabIndex = 1;
            this.rbHide.TabStop = true;
            this.rbHide.Text = "Hide";
            this.rbHide.UseVisualStyleBackColor = true;
            // 
            // gbTitle
            // 
            this.gbTitle.BackColor = System.Drawing.SystemColors.Control;
            this.gbTitle.Controls.Add(this.lblTotalItemSmall);
            this.gbTitle.Controls.Add(this.cbActive);
            this.gbTitle.Controls.Add(this.lblCount);
            this.gbTitle.Controls.Add(this.btnAdd);
            this.gbTitle.Controls.Add(this.btnSub);
            this.gbTitle.Controls.Add(this.rbHide);
            this.gbTitle.Controls.Add(this.rbShow);
            this.gbTitle.Location = new System.Drawing.Point(3, 3);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(162, 73);
            this.gbTitle.TabIndex = 2;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "Loc Name";
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Location = new System.Drawing.Point(117, 50);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(15, 14);
            this.cbActive.TabIndex = 5;
            this.cbActive.UseVisualStyleBackColor = true;
            this.cbActive.CheckedChanged += new System.EventHandler(this.cbActive_CheckedChanged);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Consolas", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(111, 13);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(31, 34);
            this.lblCount.TabIndex = 4;
            this.lblCount.Text = "?";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(78, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(27, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSub
            // 
            this.btnSub.Location = new System.Drawing.Point(78, 42);
            this.btnSub.Name = "btnSub";
            this.btnSub.Size = new System.Drawing.Size(27, 23);
            this.btnSub.TabIndex = 2;
            this.btnSub.Text = "-";
            this.btnSub.UseVisualStyleBackColor = true;
            this.btnSub.Click += new System.EventHandler(this.btnSub_Click);
            // 
            // tipLocationList
            // 
            this.tipLocationList.AutoPopDelay = 32000;
            this.tipLocationList.InitialDelay = 500;
            this.tipLocationList.ReshowDelay = 100;
            // 
            // lblTotalItemSmall
            // 
            this.lblTotalItemSmall.AutoSize = true;
            this.lblTotalItemSmall.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalItemSmall.Location = new System.Drawing.Point(131, 49);
            this.lblTotalItemSmall.Name = "lblTotalItemSmall";
            this.lblTotalItemSmall.Size = new System.Drawing.Size(21, 15);
            this.lblTotalItemSmall.TabIndex = 6;
            this.lblTotalItemSmall.Text = "/5";
            // 
            // LocationDisp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gbTitle);
            this.Name = "LocationDisp";
            this.Size = new System.Drawing.Size(168, 81);
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbShow;
        private System.Windows.Forms.RadioButton rbHide;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSub;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.ToolTip tipLocationList;
        private System.Windows.Forms.Label lblTotalItemSmall;
    }
}
