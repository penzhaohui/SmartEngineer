namespace SmartEngineer.Forms
{
    partial class frmEmailSettings
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
            this.grbUserInformation = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.grbServerInformation = new System.Windows.Forms.GroupBox();
            this.lblColon2 = new System.Windows.Forms.Label();
            this.lblColon1 = new System.Windows.Forms.Label();
            this.txtIncomingMailServerPort = new System.Windows.Forms.TextBox();
            this.txtOutgoingMailServerPort = new System.Windows.Forms.TextBox();
            this.txtOutgoingMailServer = new System.Windows.Forms.TextBox();
            this.txtIncomingMailServer = new System.Windows.Forms.TextBox();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lblOutgoingMailServer = new System.Windows.Forms.Label();
            this.lblIncomingMailServer = new System.Windows.Forms.Label();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.chkRequireSPA = new System.Windows.Forms.CheckBox();
            this.btnTestEmailAccount = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkEnableHtmlContent = new System.Windows.Forms.CheckBox();
            this.grbUserInformation.SuspendLayout();
            this.grbServerInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbUserInformation
            // 
            this.grbUserInformation.Controls.Add(this.txtPassword);
            this.grbUserInformation.Controls.Add(this.txtUserName);
            this.grbUserInformation.Controls.Add(this.lblPassword);
            this.grbUserInformation.Controls.Add(this.lblUserName);
            this.grbUserInformation.Controls.Add(this.txtEmailAddress);
            this.grbUserInformation.Controls.Add(this.txtDisplayName);
            this.grbUserInformation.Controls.Add(this.lblEmailAddress);
            this.grbUserInformation.Controls.Add(this.lblDisplayName);
            this.grbUserInformation.Location = new System.Drawing.Point(12, 12);
            this.grbUserInformation.Name = "grbUserInformation";
            this.grbUserInformation.Size = new System.Drawing.Size(553, 81);
            this.grbUserInformation.TabIndex = 0;
            this.grbUserInformation.TabStop = false;
            this.grbUserInformation.Text = "User Information";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(399, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(399, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(138, 20);
            this.txtUserName.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(337, 55);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(330, 29);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "User Name:";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Location = new System.Drawing.Point(152, 52);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(138, 20);
            this.txtEmailAddress.TabIndex = 3;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(152, 26);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(138, 20);
            this.txtDisplayName.TabIndex = 1;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.AutoSize = true;
            this.lblEmailAddress.Location = new System.Drawing.Point(70, 55);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Size = new System.Drawing.Size(76, 13);
            this.lblEmailAddress.TabIndex = 2;
            this.lblEmailAddress.Text = "Email Address:";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(83, 26);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(63, 13);
            this.lblDisplayName.TabIndex = 1;
            this.lblDisplayName.Text = "Your Name:";
            // 
            // grbServerInformation
            // 
            this.grbServerInformation.Controls.Add(this.lblColon2);
            this.grbServerInformation.Controls.Add(this.lblColon1);
            this.grbServerInformation.Controls.Add(this.txtIncomingMailServerPort);
            this.grbServerInformation.Controls.Add(this.txtOutgoingMailServerPort);
            this.grbServerInformation.Controls.Add(this.txtOutgoingMailServer);
            this.grbServerInformation.Controls.Add(this.txtIncomingMailServer);
            this.grbServerInformation.Controls.Add(this.cmbAccountType);
            this.grbServerInformation.Controls.Add(this.lblOutgoingMailServer);
            this.grbServerInformation.Controls.Add(this.lblIncomingMailServer);
            this.grbServerInformation.Controls.Add(this.lblAccountType);
            this.grbServerInformation.Location = new System.Drawing.Point(12, 115);
            this.grbServerInformation.Name = "grbServerInformation";
            this.grbServerInformation.Size = new System.Drawing.Size(553, 113);
            this.grbServerInformation.TabIndex = 1;
            this.grbServerInformation.TabStop = false;
            this.grbServerInformation.Text = "Server Information";
            // 
            // lblColon2
            // 
            this.lblColon2.AutoSize = true;
            this.lblColon2.Location = new System.Drawing.Point(295, 81);
            this.lblColon2.Name = "lblColon2";
            this.lblColon2.Size = new System.Drawing.Size(10, 13);
            this.lblColon2.TabIndex = 13;
            this.lblColon2.Text = ":";
            // 
            // lblColon1
            // 
            this.lblColon1.AutoSize = true;
            this.lblColon1.Location = new System.Drawing.Point(295, 55);
            this.lblColon1.Name = "lblColon1";
            this.lblColon1.Size = new System.Drawing.Size(10, 13);
            this.lblColon1.TabIndex = 12;
            this.lblColon1.Text = ":";
            // 
            // txtIncomingMailServerPort
            // 
            this.txtIncomingMailServerPort.Location = new System.Drawing.Point(308, 52);
            this.txtIncomingMailServerPort.Name = "txtIncomingMailServerPort";
            this.txtIncomingMailServerPort.Size = new System.Drawing.Size(40, 20);
            this.txtIncomingMailServerPort.TabIndex = 11;
            // 
            // txtOutgoingMailServerPort
            // 
            this.txtOutgoingMailServerPort.Location = new System.Drawing.Point(308, 78);
            this.txtOutgoingMailServerPort.Name = "txtOutgoingMailServerPort";
            this.txtOutgoingMailServerPort.Size = new System.Drawing.Size(40, 20);
            this.txtOutgoingMailServerPort.TabIndex = 9;
            // 
            // txtOutgoingMailServer
            // 
            this.txtOutgoingMailServer.Location = new System.Drawing.Point(154, 78);
            this.txtOutgoingMailServer.Name = "txtOutgoingMailServer";
            this.txtOutgoingMailServer.Size = new System.Drawing.Size(138, 20);
            this.txtOutgoingMailServer.TabIndex = 7;
            // 
            // txtIncomingMailServer
            // 
            this.txtIncomingMailServer.Location = new System.Drawing.Point(154, 52);
            this.txtIncomingMailServer.Name = "txtIncomingMailServer";
            this.txtIncomingMailServer.Size = new System.Drawing.Size(138, 20);
            this.txtIncomingMailServer.TabIndex = 6;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Location = new System.Drawing.Point(154, 24);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(138, 21);
            this.cmbAccountType.TabIndex = 5;
            // 
            // lblOutgoingMailServer
            // 
            this.lblOutgoingMailServer.AutoSize = true;
            this.lblOutgoingMailServer.Location = new System.Drawing.Point(6, 81);
            this.lblOutgoingMailServer.Name = "lblOutgoingMailServer";
            this.lblOutgoingMailServer.Size = new System.Drawing.Size(142, 13);
            this.lblOutgoingMailServer.TabIndex = 4;
            this.lblOutgoingMailServer.Text = "Outgoing mail server(SMTP):";
            // 
            // lblIncomingMailServer
            // 
            this.lblIncomingMailServer.AutoSize = true;
            this.lblIncomingMailServer.Location = new System.Drawing.Point(42, 55);
            this.lblIncomingMailServer.Name = "lblIncomingMailServer";
            this.lblIncomingMailServer.Size = new System.Drawing.Size(106, 13);
            this.lblIncomingMailServer.TabIndex = 3;
            this.lblIncomingMailServer.Text = "Incoming mail server:";
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(71, 27);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(77, 13);
            this.lblAccountType.TabIndex = 2;
            this.lblAccountType.Text = "Account Type:";
            // 
            // chkRequireSPA
            // 
            this.chkRequireSPA.AutoSize = true;
            this.chkRequireSPA.Location = new System.Drawing.Point(21, 234);
            this.chkRequireSPA.Name = "chkRequireSPA";
            this.chkRequireSPA.Size = new System.Drawing.Size(303, 17);
            this.chkRequireSPA.TabIndex = 2;
            this.chkRequireSPA.Text = "Require logon using Security Pasword Authentication(SPA)";
            this.chkRequireSPA.UseVisualStyleBackColor = true;
            // 
            // btnTestEmailAccount
            // 
            this.btnTestEmailAccount.Location = new System.Drawing.Point(21, 280);
            this.btnTestEmailAccount.Name = "btnTestEmailAccount";
            this.btnTestEmailAccount.Size = new System.Drawing.Size(98, 23);
            this.btnTestEmailAccount.TabIndex = 3;
            this.btnTestEmailAccount.Text = "Test Account";
            this.btnTestEmailAccount.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(433, 280);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(63, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(502, 280);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chkEnableHtmlContent
            // 
            this.chkEnableHtmlContent.AutoSize = true;
            this.chkEnableHtmlContent.Location = new System.Drawing.Point(21, 257);
            this.chkEnableHtmlContent.Name = "chkEnableHtmlContent";
            this.chkEnableHtmlContent.Size = new System.Drawing.Size(132, 17);
            this.chkEnableHtmlContent.TabIndex = 8;
            this.chkEnableHtmlContent.Text = "Enable HTML Content";
            this.chkEnableHtmlContent.UseVisualStyleBackColor = true;
            // 
            // frmEmailSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 314);
            this.Controls.Add(this.chkEnableHtmlContent);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTestEmailAccount);
            this.Controls.Add(this.chkRequireSPA);
            this.Controls.Add(this.grbServerInformation);
            this.Controls.Add(this.grbUserInformation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmailSettings";
            this.Text = "Email Server Settings";
            this.grbUserInformation.ResumeLayout(false);
            this.grbUserInformation.PerformLayout();
            this.grbServerInformation.ResumeLayout(false);
            this.grbServerInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbUserInformation;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.GroupBox grbServerInformation;
        private System.Windows.Forms.TextBox txtOutgoingMailServer;
        private System.Windows.Forms.TextBox txtIncomingMailServer;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label lblOutgoingMailServer;
        private System.Windows.Forms.Label lblIncomingMailServer;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.CheckBox chkRequireSPA;
        private System.Windows.Forms.Button btnTestEmailAccount;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkEnableHtmlContent;
        private System.Windows.Forms.Label lblColon2;
        private System.Windows.Forms.Label lblColon1;
        private System.Windows.Forms.TextBox txtIncomingMailServerPort;
        private System.Windows.Forms.TextBox txtOutgoingMailServerPort;
    }
}