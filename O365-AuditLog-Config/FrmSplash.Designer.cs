namespace O365_AuditLog_Extract
{
    partial class FrmSplash
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
            this.BtnProfile = new System.Windows.Forms.Button();
            this.BtnSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnProfile
            // 
            this.BtnProfile.Location = new System.Drawing.Point(87, 53);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(110, 34);
            this.BtnProfile.TabIndex = 0;
            this.BtnProfile.Text = "Edit Local Settings";
            this.BtnProfile.UseVisualStyleBackColor = true;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            // 
            // BtnSignIn
            // 
            this.BtnSignIn.Location = new System.Drawing.Point(99, 119);
            this.BtnSignIn.Name = "BtnSignIn";
            this.BtnSignIn.Size = new System.Drawing.Size(75, 23);
            this.BtnSignIn.TabIndex = 1;
            this.BtnSignIn.Text = "SignIn";
            this.BtnSignIn.UseVisualStyleBackColor = true;
            this.BtnSignIn.Click += new System.EventHandler(this.BtnSignIn_Click);
            // 
            // FrmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 220);
            this.Controls.Add(this.BtnSignIn);
            this.Controls.Add(this.BtnProfile);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Office 365 Audit Log Configurator";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnProfile;
        private System.Windows.Forms.Button BtnSignIn;
    }
}

