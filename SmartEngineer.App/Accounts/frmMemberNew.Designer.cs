namespace SmartEngineer.Forms
{
    partial class frmMemberNew
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
            this.lblEmailAccount = new System.Windows.Forms.Label();
            this.txtEmailAccount = new System.Windows.Forms.TextBox();
            this.lblEmailPassword = new System.Windows.Forms.Label();
            this.gpbMailAccount = new System.Windows.Forms.GroupBox();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.gpbJiraAccount = new System.Windows.Forms.GroupBox();
            this.txtJiraPassword = new System.Windows.Forms.TextBox();
            this.lblJiraAccount = new System.Windows.Forms.Label();
            this.txtJiraAccount = new System.Windows.Forms.TextBox();
            this.lblJiraPassword = new System.Windows.Forms.Label();
            this.gpbTestRailAccount = new System.Windows.Forms.GroupBox();
            this.txtTestRailPassword = new System.Windows.Forms.TextBox();
            this.lblTestRailAccount = new System.Windows.Forms.Label();
            this.txtTestRailAccount = new System.Windows.Forms.TextBox();
            this.lblTestRailPassword = new System.Windows.Forms.Label();
            this.gpbGithubAccount = new System.Windows.Forms.GroupBox();
            this.txtGitHubPassword = new System.Windows.Forms.TextBox();
            this.lblGitHubAccount = new System.Windows.Forms.Label();
            this.txtGitHubAccount = new System.Windows.Forms.TextBox();
            this.lblGitHubPassword = new System.Windows.Forms.Label();
            this.gpbBasicInfo = new System.Windows.Forms.GroupBox();
            this.lblActive = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtLoginAccountName = new System.Windows.Forms.TextBox();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.lblSignature = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtLoginAccountID = new System.Windows.Forms.TextBox();
            this.lblLoginUser = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.gpbMailAccount.SuspendLayout();
            this.gpbJiraAccount.SuspendLayout();
            this.gpbTestRailAccount.SuspendLayout();
            this.gpbGithubAccount.SuspendLayout();
            this.gpbBasicInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblEmailAccount
            // 
            this.lblEmailAccount.AutoSize = true;
            this.lblEmailAccount.Location = new System.Drawing.Point(17, 29);
            this.lblEmailAccount.Name = "lblEmailAccount";
            this.lblEmailAccount.Size = new System.Drawing.Size(50, 13);
            this.lblEmailAccount.TabIndex = 12;
            this.lblEmailAccount.Text = "Account:";
            // 
            // txtEmailAccount
            // 
            this.txtEmailAccount.Location = new System.Drawing.Point(73, 26);
            this.txtEmailAccount.Name = "txtEmailAccount";
            this.txtEmailAccount.Size = new System.Drawing.Size(100, 20);
            this.txtEmailAccount.TabIndex = 13;
            // 
            // lblEmailPassword
            // 
            this.lblEmailPassword.AutoSize = true;
            this.lblEmailPassword.Location = new System.Drawing.Point(6, 54);
            this.lblEmailPassword.Name = "lblEmailPassword";
            this.lblEmailPassword.Size = new System.Drawing.Size(56, 13);
            this.lblEmailPassword.TabIndex = 14;
            this.lblEmailPassword.Text = "Password:";
            // 
            // gpbMailAccount
            // 
            this.gpbMailAccount.Controls.Add(this.txtEmailPassword);
            this.gpbMailAccount.Controls.Add(this.lblEmailAccount);
            this.gpbMailAccount.Controls.Add(this.txtEmailAccount);
            this.gpbMailAccount.Controls.Add(this.lblEmailPassword);
            this.gpbMailAccount.Location = new System.Drawing.Point(12, 183);
            this.gpbMailAccount.Name = "gpbMailAccount";
            this.gpbMailAccount.Size = new System.Drawing.Size(202, 89);
            this.gpbMailAccount.TabIndex = 16;
            this.gpbMailAccount.TabStop = false;
            this.gpbMailAccount.Text = "Email Account";
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Location = new System.Drawing.Point(73, 51);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.Size = new System.Drawing.Size(100, 20);
            this.txtEmailPassword.TabIndex = 15;
            // 
            // gpbJiraAccount
            // 
            this.gpbJiraAccount.Controls.Add(this.txtJiraPassword);
            this.gpbJiraAccount.Controls.Add(this.lblJiraAccount);
            this.gpbJiraAccount.Controls.Add(this.txtJiraAccount);
            this.gpbJiraAccount.Controls.Add(this.lblJiraPassword);
            this.gpbJiraAccount.Location = new System.Drawing.Point(249, 183);
            this.gpbJiraAccount.Name = "gpbJiraAccount";
            this.gpbJiraAccount.Size = new System.Drawing.Size(202, 89);
            this.gpbJiraAccount.TabIndex = 17;
            this.gpbJiraAccount.TabStop = false;
            this.gpbJiraAccount.Text = "Jira Account";
            // 
            // txtJiraPassword
            // 
            this.txtJiraPassword.Location = new System.Drawing.Point(73, 51);
            this.txtJiraPassword.Name = "txtJiraPassword";
            this.txtJiraPassword.Size = new System.Drawing.Size(100, 20);
            this.txtJiraPassword.TabIndex = 15;
            // 
            // lblJiraAccount
            // 
            this.lblJiraAccount.AutoSize = true;
            this.lblJiraAccount.Location = new System.Drawing.Point(17, 29);
            this.lblJiraAccount.Name = "lblJiraAccount";
            this.lblJiraAccount.Size = new System.Drawing.Size(50, 13);
            this.lblJiraAccount.TabIndex = 12;
            this.lblJiraAccount.Text = "Account:";
            // 
            // txtJiraAccount
            // 
            this.txtJiraAccount.Location = new System.Drawing.Point(73, 26);
            this.txtJiraAccount.Name = "txtJiraAccount";
            this.txtJiraAccount.Size = new System.Drawing.Size(100, 20);
            this.txtJiraAccount.TabIndex = 13;
            // 
            // lblJiraPassword
            // 
            this.lblJiraPassword.AutoSize = true;
            this.lblJiraPassword.Location = new System.Drawing.Point(6, 54);
            this.lblJiraPassword.Name = "lblJiraPassword";
            this.lblJiraPassword.Size = new System.Drawing.Size(56, 13);
            this.lblJiraPassword.TabIndex = 14;
            this.lblJiraPassword.Text = "Password:";
            // 
            // gpbTestRailAccount
            // 
            this.gpbTestRailAccount.Controls.Add(this.txtTestRailPassword);
            this.gpbTestRailAccount.Controls.Add(this.lblTestRailAccount);
            this.gpbTestRailAccount.Controls.Add(this.txtTestRailAccount);
            this.gpbTestRailAccount.Controls.Add(this.lblTestRailPassword);
            this.gpbTestRailAccount.Location = new System.Drawing.Point(12, 292);
            this.gpbTestRailAccount.Name = "gpbTestRailAccount";
            this.gpbTestRailAccount.Size = new System.Drawing.Size(202, 89);
            this.gpbTestRailAccount.TabIndex = 17;
            this.gpbTestRailAccount.TabStop = false;
            this.gpbTestRailAccount.Text = "TestRaill Account";
            // 
            // txtTestRailPassword
            // 
            this.txtTestRailPassword.Location = new System.Drawing.Point(73, 51);
            this.txtTestRailPassword.Name = "txtTestRailPassword";
            this.txtTestRailPassword.Size = new System.Drawing.Size(100, 20);
            this.txtTestRailPassword.TabIndex = 15;
            // 
            // lblTestRailAccount
            // 
            this.lblTestRailAccount.AutoSize = true;
            this.lblTestRailAccount.Location = new System.Drawing.Point(17, 29);
            this.lblTestRailAccount.Name = "lblTestRailAccount";
            this.lblTestRailAccount.Size = new System.Drawing.Size(50, 13);
            this.lblTestRailAccount.TabIndex = 12;
            this.lblTestRailAccount.Text = "Account:";
            // 
            // txtTestRailAccount
            // 
            this.txtTestRailAccount.Location = new System.Drawing.Point(73, 26);
            this.txtTestRailAccount.Name = "txtTestRailAccount";
            this.txtTestRailAccount.Size = new System.Drawing.Size(100, 20);
            this.txtTestRailAccount.TabIndex = 13;
            // 
            // lblTestRailPassword
            // 
            this.lblTestRailPassword.AutoSize = true;
            this.lblTestRailPassword.Location = new System.Drawing.Point(6, 54);
            this.lblTestRailPassword.Name = "lblTestRailPassword";
            this.lblTestRailPassword.Size = new System.Drawing.Size(56, 13);
            this.lblTestRailPassword.TabIndex = 14;
            this.lblTestRailPassword.Text = "Password:";
            // 
            // gpbGithubAccount
            // 
            this.gpbGithubAccount.Controls.Add(this.txtGitHubPassword);
            this.gpbGithubAccount.Controls.Add(this.lblGitHubAccount);
            this.gpbGithubAccount.Controls.Add(this.txtGitHubAccount);
            this.gpbGithubAccount.Controls.Add(this.lblGitHubPassword);
            this.gpbGithubAccount.Location = new System.Drawing.Point(249, 292);
            this.gpbGithubAccount.Name = "gpbGithubAccount";
            this.gpbGithubAccount.Size = new System.Drawing.Size(202, 89);
            this.gpbGithubAccount.TabIndex = 18;
            this.gpbGithubAccount.TabStop = false;
            this.gpbGithubAccount.Text = "GitHub Account";
            // 
            // txtGitHubPassword
            // 
            this.txtGitHubPassword.Location = new System.Drawing.Point(73, 51);
            this.txtGitHubPassword.Name = "txtGitHubPassword";
            this.txtGitHubPassword.Size = new System.Drawing.Size(100, 20);
            this.txtGitHubPassword.TabIndex = 15;
            // 
            // lblGitHubAccount
            // 
            this.lblGitHubAccount.AutoSize = true;
            this.lblGitHubAccount.Location = new System.Drawing.Point(17, 29);
            this.lblGitHubAccount.Name = "lblGitHubAccount";
            this.lblGitHubAccount.Size = new System.Drawing.Size(50, 13);
            this.lblGitHubAccount.TabIndex = 12;
            this.lblGitHubAccount.Text = "Account:";
            // 
            // txtGitHubAccount
            // 
            this.txtGitHubAccount.Location = new System.Drawing.Point(73, 26);
            this.txtGitHubAccount.Name = "txtGitHubAccount";
            this.txtGitHubAccount.Size = new System.Drawing.Size(100, 20);
            this.txtGitHubAccount.TabIndex = 13;
            // 
            // lblGitHubPassword
            // 
            this.lblGitHubPassword.AutoSize = true;
            this.lblGitHubPassword.Location = new System.Drawing.Point(6, 54);
            this.lblGitHubPassword.Name = "lblGitHubPassword";
            this.lblGitHubPassword.Size = new System.Drawing.Size(56, 13);
            this.lblGitHubPassword.TabIndex = 14;
            this.lblGitHubPassword.Text = "Password:";
            // 
            // gpbBasicInfo
            // 
            this.gpbBasicInfo.Controls.Add(this.lblActive);
            this.gpbBasicInfo.Controls.Add(this.chkIsActive);
            this.gpbBasicInfo.Controls.Add(this.txtLoginAccountName);
            this.gpbBasicInfo.Controls.Add(this.txtSignature);
            this.gpbBasicInfo.Controls.Add(this.lblSignature);
            this.gpbBasicInfo.Controls.Add(this.txtLastName);
            this.gpbBasicInfo.Controls.Add(this.lblLastName);
            this.gpbBasicInfo.Controls.Add(this.txtFirstName);
            this.gpbBasicInfo.Controls.Add(this.lblFirstName);
            this.gpbBasicInfo.Controls.Add(this.txtDisplayName);
            this.gpbBasicInfo.Controls.Add(this.lblDisplayName);
            this.gpbBasicInfo.Controls.Add(this.txtUserName);
            this.gpbBasicInfo.Controls.Add(this.lblUserName);
            this.gpbBasicInfo.Controls.Add(this.txtLoginAccountID);
            this.gpbBasicInfo.Controls.Add(this.lblLoginUser);
            this.gpbBasicInfo.Controls.Add(this.txtMemberID);
            this.gpbBasicInfo.Location = new System.Drawing.Point(12, 12);
            this.gpbBasicInfo.Name = "gpbBasicInfo";
            this.gpbBasicInfo.Size = new System.Drawing.Size(439, 151);
            this.gpbBasicInfo.TabIndex = 21;
            this.gpbBasicInfo.TabStop = false;
            this.gpbBasicInfo.Text = "Basic Information";
            // 
            // lblActive
            // 
            this.lblActive.AutoSize = true;
            this.lblActive.Location = new System.Drawing.Point(51, 115);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(43, 13);
            this.lblActive.TabIndex = 35;
            this.lblActive.Text = "Enable:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(109, 115);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(15, 14);
            this.chkIsActive.TabIndex = 34;
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtLoginAccountName
            // 
            this.txtLoginAccountName.Location = new System.Drawing.Point(320, 22);
            this.txtLoginAccountName.Name = "txtLoginAccountName";
            this.txtLoginAccountName.ReadOnly = true;
            this.txtLoginAccountName.Size = new System.Drawing.Size(100, 20);
            this.txtLoginAccountName.TabIndex = 33;
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(320, 55);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(100, 20);
            this.txtSignature.TabIndex = 32;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(253, 58);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(55, 13);
            this.lblSignature.TabIndex = 31;
            this.lblSignature.Text = "Signature:";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(320, 81);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 20);
            this.txtLastName.TabIndex = 30;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(247, 86);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(61, 13);
            this.lblLastName.TabIndex = 29;
            this.lblLastName.Text = "Last Name:";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(109, 79);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(100, 20);
            this.txtFirstName.TabIndex = 28;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(34, 86);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(60, 13);
            this.lblFirstName.TabIndex = 27;
            this.lblFirstName.Text = "First Name:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(109, 51);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(100, 20);
            this.txtDisplayName.TabIndex = 26;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(19, 56);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(75, 13);
            this.lblDisplayName.TabIndex = 25;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(109, 22);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 24;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(31, 25);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 23;
            this.lblUserName.Text = "User Name:";
            // 
            // txtLoginAccountID
            // 
            this.txtLoginAccountID.Location = new System.Drawing.Point(320, 22);
            this.txtLoginAccountID.Name = "txtLoginAccountID";
            this.txtLoginAccountID.Size = new System.Drawing.Size(100, 20);
            this.txtLoginAccountID.TabIndex = 22;
            // 
            // lblLoginUser
            // 
            this.lblLoginUser.AutoSize = true;
            this.lblLoginUser.Location = new System.Drawing.Point(253, 25);
            this.lblLoginUser.Name = "lblLoginUser";
            this.lblLoginUser.Size = new System.Drawing.Size(61, 13);
            this.lblLoginUser.TabIndex = 21;
            this.lblLoginUser.Text = "Login User:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(139, 407);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 407);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(109, 22);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(100, 20);
            this.txtMemberID.TabIndex = 36;
            // 
            // frmMemberNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 442);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gpbBasicInfo);
            this.Controls.Add(this.gpbGithubAccount);
            this.Controls.Add(this.gpbTestRailAccount);
            this.Controls.Add(this.gpbJiraAccount);
            this.Controls.Add(this.gpbMailAccount);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMemberNew";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Member Profile";
            this.gpbMailAccount.ResumeLayout(false);
            this.gpbMailAccount.PerformLayout();
            this.gpbJiraAccount.ResumeLayout(false);
            this.gpbJiraAccount.PerformLayout();
            this.gpbTestRailAccount.ResumeLayout(false);
            this.gpbTestRailAccount.PerformLayout();
            this.gpbGithubAccount.ResumeLayout(false);
            this.gpbGithubAccount.PerformLayout();
            this.gpbBasicInfo.ResumeLayout(false);
            this.gpbBasicInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEmailAccount;
        private System.Windows.Forms.TextBox txtEmailAccount;
        private System.Windows.Forms.Label lblEmailPassword;
        private System.Windows.Forms.GroupBox gpbMailAccount;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.GroupBox gpbJiraAccount;
        private System.Windows.Forms.TextBox txtJiraPassword;
        private System.Windows.Forms.Label lblJiraAccount;
        private System.Windows.Forms.TextBox txtJiraAccount;
        private System.Windows.Forms.Label lblJiraPassword;
        private System.Windows.Forms.GroupBox gpbTestRailAccount;
        private System.Windows.Forms.TextBox txtTestRailPassword;
        private System.Windows.Forms.Label lblTestRailAccount;
        private System.Windows.Forms.TextBox txtTestRailAccount;
        private System.Windows.Forms.Label lblTestRailPassword;
        private System.Windows.Forms.GroupBox gpbGithubAccount;
        private System.Windows.Forms.TextBox txtGitHubPassword;
        private System.Windows.Forms.Label lblGitHubAccount;
        private System.Windows.Forms.TextBox txtGitHubAccount;
        private System.Windows.Forms.Label lblGitHubPassword;
        private System.Windows.Forms.GroupBox gpbBasicInfo;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtLoginAccountName;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtLoginAccountID;
        private System.Windows.Forms.Label lblLoginUser;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtMemberID;
    }
}