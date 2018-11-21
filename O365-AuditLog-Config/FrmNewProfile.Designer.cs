namespace O365_AuditLog_Extract
{
    partial class FrmNewProfile
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenentGUID = new System.Windows.Forms.TextBox();
            this.txtClientSecret = new System.Windows.Forms.TextBox();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.lstAvailableSubscriptions = new System.Windows.Forms.ListBox();
            this.lstAlreadySubscribed = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnAddSubscription = new System.Windows.Forms.Button();
            this.BtnRemoveSubscription = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter O365 Tenent GUID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "AAD App ClientID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "AAD App Client Secret:";
            // 
            // txtTenentGUID
            // 
            this.txtTenentGUID.Location = new System.Drawing.Point(192, 43);
            this.txtTenentGUID.Name = "txtTenentGUID";
            this.txtTenentGUID.Size = new System.Drawing.Size(321, 20);
            this.txtTenentGUID.TabIndex = 3;
            // 
            // txtClientSecret
            // 
            this.txtClientSecret.Location = new System.Drawing.Point(192, 101);
            this.txtClientSecret.Name = "txtClientSecret";
            this.txtClientSecret.Size = new System.Drawing.Size(321, 20);
            this.txtClientSecret.TabIndex = 4;
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(192, 73);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(321, 20);
            this.txtClientID.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(409, 127);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(438, 126);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(75, 23);
            this.btnSignIn.TabIndex = 7;
            this.btnSignIn.Text = "Authenticate";
            this.btnSignIn.UseVisualStyleBackColor = true;
            // 
            // lstAvailableSubscriptions
            // 
            this.lstAvailableSubscriptions.FormattingEnabled = true;
            this.lstAvailableSubscriptions.Location = new System.Drawing.Point(12, 222);
            this.lstAvailableSubscriptions.Name = "lstAvailableSubscriptions";
            this.lstAvailableSubscriptions.Size = new System.Drawing.Size(111, 134);
            this.lstAvailableSubscriptions.TabIndex = 8;
            // 
            // lstAlreadySubscribed
            // 
            this.lstAlreadySubscribed.FormattingEnabled = true;
            this.lstAlreadySubscribed.Location = new System.Drawing.Point(159, 222);
            this.lstAlreadySubscribed.Name = "lstAlreadySubscribed";
            this.lstAlreadySubscribed.Size = new System.Drawing.Size(383, 134);
            this.lstAlreadySubscribed.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Already Subscribed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Available Subscriptions";
            // 
            // BtnAddSubscription
            // 
            this.BtnAddSubscription.Location = new System.Drawing.Point(15, 360);
            this.BtnAddSubscription.Name = "BtnAddSubscription";
            this.BtnAddSubscription.Size = new System.Drawing.Size(108, 23);
            this.BtnAddSubscription.TabIndex = 12;
            this.BtnAddSubscription.Text = "Start Subscription";
            this.BtnAddSubscription.UseVisualStyleBackColor = true;
            // 
            // BtnRemoveSubscription
            // 
            this.BtnRemoveSubscription.Location = new System.Drawing.Point(438, 360);
            this.BtnRemoveSubscription.Name = "BtnRemoveSubscription";
            this.BtnRemoveSubscription.Size = new System.Drawing.Size(104, 23);
            this.BtnRemoveSubscription.TabIndex = 13;
            this.BtnRemoveSubscription.Text = "Stop Subscription";
            this.BtnRemoveSubscription.UseVisualStyleBackColor = true;
            // 
            // FrmNewProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 386);
            this.Controls.Add(this.BtnRemoveSubscription);
            this.Controls.Add(this.BtnAddSubscription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstAlreadySubscribed);
            this.Controls.Add(this.lstAvailableSubscriptions);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtClientID);
            this.Controls.Add(this.txtClientSecret);
            this.Controls.Add(this.txtTenentGUID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNewProfile";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create New Profile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenentGUID;
        private System.Windows.Forms.TextBox txtClientSecret;
        private System.Windows.Forms.TextBox txtClientID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.ListBox lstAvailableSubscriptions;
        private System.Windows.Forms.ListBox lstAlreadySubscribed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnAddSubscription;
        private System.Windows.Forms.Button BtnRemoveSubscription;
    }
}