namespace SmartEngineer.UserControls
{
    partial class SaleforceAccountModule
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
            this.grbSalesforceAccountSetting = new System.Windows.Forms.GroupBox();
            this.cmbUpdateInterval = new System.Windows.Forms.ComboBox();
            this.lblUpdateInterbalUnit = new System.Windows.Forms.Label();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.txtAPIBaseUrl = new System.Windows.Forms.TextBox();
            this.lblAPIBaseUrl = new System.Windows.Forms.Label();
            this.lblSandBox = new System.Windows.Forms.Label();
            this.chkSandBox = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtConsumerSecret = new System.Windows.Forms.TextBox();
            this.lblConsumerSecret = new System.Windows.Forms.Label();
            this.txtConsumerKey = new System.Windows.Forms.TextBox();
            this.lblConsumerKey = new System.Windows.Forms.Label();
            this.txtSecurityToken = new System.Windows.Forms.TextBox();
            this.lblSecurityToken = new System.Windows.Forms.Label();
            this.grbSalesforceAccountSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSalesforceAccountSetting
            // 
            this.grbSalesforceAccountSetting.Controls.Add(this.cmbUpdateInterval);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblUpdateInterbalUnit);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblUpdateInterval);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtAPIBaseUrl);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblAPIBaseUrl);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblSandBox);
            this.grbSalesforceAccountSetting.Controls.Add(this.chkSandBox);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtPassword);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblPassword);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtUserName);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblUserName);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtConsumerSecret);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblConsumerSecret);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtConsumerKey);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblConsumerKey);
            this.grbSalesforceAccountSetting.Controls.Add(this.txtSecurityToken);
            this.grbSalesforceAccountSetting.Controls.Add(this.lblSecurityToken);
            this.grbSalesforceAccountSetting.Location = new System.Drawing.Point(3, 3);
            this.grbSalesforceAccountSetting.Name = "grbSalesforceAccountSetting";
            this.grbSalesforceAccountSetting.Size = new System.Drawing.Size(490, 290);
            this.grbSalesforceAccountSetting.TabIndex = 0;
            this.grbSalesforceAccountSetting.TabStop = false;
            this.grbSalesforceAccountSetting.Text = "Salesforce Account Setting";
            // 
            // cmbUpdateInterval
            // 
            this.cmbUpdateInterval.FormattingEnabled = true;
            this.cmbUpdateInterval.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbUpdateInterval.Location = new System.Drawing.Point(106, 217);
            this.cmbUpdateInterval.Name = "cmbUpdateInterval";
            this.cmbUpdateInterval.Size = new System.Drawing.Size(44, 21);
            this.cmbUpdateInterval.TabIndex = 31;
            // 
            // lblUpdateInterbalUnit
            // 
            this.lblUpdateInterbalUnit.AutoSize = true;
            this.lblUpdateInterbalUnit.Location = new System.Drawing.Point(156, 225);
            this.lblUpdateInterbalUnit.Name = "lblUpdateInterbalUnit";
            this.lblUpdateInterbalUnit.Size = new System.Drawing.Size(36, 13);
            this.lblUpdateInterbalUnit.TabIndex = 30;
            this.lblUpdateInterbalUnit.Text = "(Hour)";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(11, 222);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(83, 13);
            this.lblUpdateInterval.TabIndex = 28;
            this.lblUpdateInterval.Text = "Update Interval:";
            // 
            // txtAPIBaseUrl
            // 
            this.txtAPIBaseUrl.Location = new System.Drawing.Point(106, 27);
            this.txtAPIBaseUrl.Name = "txtAPIBaseUrl";
            this.txtAPIBaseUrl.Size = new System.Drawing.Size(304, 20);
            this.txtAPIBaseUrl.TabIndex = 27;
            // 
            // lblAPIBaseUrl
            // 
            this.lblAPIBaseUrl.AutoSize = true;
            this.lblAPIBaseUrl.Location = new System.Drawing.Point(15, 30);
            this.lblAPIBaseUrl.Name = "lblAPIBaseUrl";
            this.lblAPIBaseUrl.Size = new System.Drawing.Size(79, 13);
            this.lblAPIBaseUrl.TabIndex = 26;
            this.lblAPIBaseUrl.Text = "API Base URL:";
            // 
            // lblSandBox
            // 
            this.lblSandBox.AutoSize = true;
            this.lblSandBox.Location = new System.Drawing.Point(38, 198);
            this.lblSandBox.Name = "lblSandBox";
            this.lblSandBox.Size = new System.Drawing.Size(56, 13);
            this.lblSandBox.TabIndex = 25;
            this.lblSandBox.Text = "Sand Box:";
            // 
            // chkSandBox
            // 
            this.chkSandBox.AutoSize = true;
            this.chkSandBox.Location = new System.Drawing.Point(106, 198);
            this.chkSandBox.Name = "chkSandBox";
            this.chkSandBox.Size = new System.Drawing.Size(15, 14);
            this.chkSandBox.TabIndex = 24;
            this.chkSandBox.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(106, 169);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(304, 20);
            this.txtPassword.TabIndex = 23;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(38, 172);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 22;
            this.lblPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(106, 140);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(304, 20);
            this.txtUserName.TabIndex = 21;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(31, 143);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 20;
            this.lblUserName.Text = "User Name:";
            // 
            // txtConsumerSecret
            // 
            this.txtConsumerSecret.Location = new System.Drawing.Point(106, 111);
            this.txtConsumerSecret.Name = "txtConsumerSecret";
            this.txtConsumerSecret.Size = new System.Drawing.Size(304, 20);
            this.txtConsumerSecret.TabIndex = 19;
            // 
            // lblConsumerSecret
            // 
            this.lblConsumerSecret.AutoSize = true;
            this.lblConsumerSecret.Location = new System.Drawing.Point(3, 114);
            this.lblConsumerSecret.Name = "lblConsumerSecret";
            this.lblConsumerSecret.Size = new System.Drawing.Size(91, 13);
            this.lblConsumerSecret.TabIndex = 18;
            this.lblConsumerSecret.Text = "Consumer Secret:";
            // 
            // txtConsumerKey
            // 
            this.txtConsumerKey.Location = new System.Drawing.Point(106, 82);
            this.txtConsumerKey.Name = "txtConsumerKey";
            this.txtConsumerKey.Size = new System.Drawing.Size(304, 20);
            this.txtConsumerKey.TabIndex = 17;
            // 
            // lblConsumerKey
            // 
            this.lblConsumerKey.AutoSize = true;
            this.lblConsumerKey.Location = new System.Drawing.Point(16, 82);
            this.lblConsumerKey.Name = "lblConsumerKey";
            this.lblConsumerKey.Size = new System.Drawing.Size(78, 13);
            this.lblConsumerKey.TabIndex = 16;
            this.lblConsumerKey.Text = "Consumer Key:";
            // 
            // txtSecurityToken
            // 
            this.txtSecurityToken.Location = new System.Drawing.Point(106, 53);
            this.txtSecurityToken.Name = "txtSecurityToken";
            this.txtSecurityToken.Size = new System.Drawing.Size(304, 20);
            this.txtSecurityToken.TabIndex = 15;
            // 
            // lblSecurityToken
            // 
            this.lblSecurityToken.AutoSize = true;
            this.lblSecurityToken.Location = new System.Drawing.Point(12, 56);
            this.lblSecurityToken.Name = "lblSecurityToken";
            this.lblSecurityToken.Size = new System.Drawing.Size(82, 13);
            this.lblSecurityToken.TabIndex = 14;
            this.lblSecurityToken.Text = "Security Token:";
            // 
            // SaleforceAccountModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbSalesforceAccountSetting);
            this.Name = "SaleforceAccountModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.Load += new System.EventHandler(this.SaleforceAccountModule_Load);
            this.grbSalesforceAccountSetting.ResumeLayout(false);
            this.grbSalesforceAccountSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSalesforceAccountSetting;
        private System.Windows.Forms.TextBox txtAPIBaseUrl;
        private System.Windows.Forms.Label lblAPIBaseUrl;
        private System.Windows.Forms.Label lblSandBox;
        private System.Windows.Forms.CheckBox chkSandBox;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtConsumerSecret;
        private System.Windows.Forms.Label lblConsumerSecret;
        private System.Windows.Forms.TextBox txtConsumerKey;
        private System.Windows.Forms.Label lblConsumerKey;
        private System.Windows.Forms.TextBox txtSecurityToken;
        private System.Windows.Forms.Label lblSecurityToken;
        private System.Windows.Forms.Label lblUpdateInterbalUnit;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.ComboBox cmbUpdateInterval;
    }
}
