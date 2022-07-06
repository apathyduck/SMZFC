
namespace SMZ3FC
{
    partial class SettingsForm
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
            this.cbSubAuto = new System.Windows.Forms.CheckBox();
            this.cbAddAuto = new System.Windows.Forms.CheckBox();
            this.btnSVFont = new System.Windows.Forms.Button();
            this.btnSVKey = new System.Windows.Forms.Button();
            this.btnPLCol = new System.Windows.Forms.Button();
            this.cdStrmView = new System.Windows.Forms.ColorDialog();
            this.cdPrimaryLoc = new System.Windows.Forms.ColorDialog();
            this.fdStreamView = new System.Windows.Forms.FontDialog();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSubAuto
            // 
            this.cbSubAuto.AutoSize = true;
            this.cbSubAuto.Location = new System.Drawing.Point(9, 24);
            this.cbSubAuto.Name = "cbSubAuto";
            this.cbSubAuto.Size = new System.Drawing.Size(220, 17);
            this.cbSubAuto.TabIndex = 0;
            this.cbSubAuto.Text = "- button automatically makes area primary";
            this.cbSubAuto.UseVisualStyleBackColor = true;
            this.cbSubAuto.CheckedChanged += new System.EventHandler(this.cbSubAuto_CheckedChanged);
            // 
            // cbAddAuto
            // 
            this.cbAddAuto.AutoSize = true;
            this.cbAddAuto.Location = new System.Drawing.Point(9, 47);
            this.cbAddAuto.Name = "cbAddAuto";
            this.cbAddAuto.Size = new System.Drawing.Size(223, 17);
            this.cbAddAuto.TabIndex = 1;
            this.cbAddAuto.Text = "+ button automatically makes area primary";
            this.cbAddAuto.UseVisualStyleBackColor = true;
            this.cbAddAuto.CheckedChanged += new System.EventHandler(this.cbAddAuto_CheckedChanged);
            // 
            // btnSVFont
            // 
            this.btnSVFont.Location = new System.Drawing.Point(9, 70);
            this.btnSVFont.Name = "btnSVFont";
            this.btnSVFont.Size = new System.Drawing.Size(104, 23);
            this.btnSVFont.TabIndex = 2;
            this.btnSVFont.Text = " Streamview Font";
            this.btnSVFont.UseVisualStyleBackColor = true;
            this.btnSVFont.Click += new System.EventHandler(this.btnSVFont_Click);
            // 
            // btnSVKey
            // 
            this.btnSVKey.Location = new System.Drawing.Point(9, 99);
            this.btnSVKey.Name = "btnSVKey";
            this.btnSVKey.Size = new System.Drawing.Size(104, 23);
            this.btnSVKey.TabIndex = 3;
            this.btnSVKey.Text = "Streamview Key Color";
            this.btnSVKey.UseVisualStyleBackColor = true;
            this.btnSVKey.Click += new System.EventHandler(this.btnSVKey_Click);
            // 
            // btnPLCol
            // 
            this.btnPLCol.Location = new System.Drawing.Point(9, 128);
            this.btnPLCol.Name = "btnPLCol";
            this.btnPLCol.Size = new System.Drawing.Size(104, 23);
            this.btnPLCol.TabIndex = 4;
            this.btnPLCol.Text = "Primary Loc Color";
            this.btnPLCol.UseVisualStyleBackColor = true;
            this.btnPLCol.Click += new System.EventHandler(this.btnPLCol_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(248, 128);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(85, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply && Save";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(157, 128);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 165);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnPLCol);
            this.Controls.Add(this.btnSVKey);
            this.Controls.Add(this.btnSVFont);
            this.Controls.Add(this.cbAddAuto);
            this.Controls.Add(this.cbSubAuto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbSubAuto;
        private System.Windows.Forms.CheckBox cbAddAuto;
        private System.Windows.Forms.Button btnSVFont;
        private System.Windows.Forms.Button btnSVKey;
        private System.Windows.Forms.Button btnPLCol;
        private System.Windows.Forms.ColorDialog cdStrmView;
        private System.Windows.Forms.ColorDialog cdPrimaryLoc;
        private System.Windows.Forms.FontDialog fdStreamView;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
    }
}