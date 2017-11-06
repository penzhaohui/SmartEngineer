namespace SmartEngineer.Forms
{
    partial class frmMembers
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
            this.dgvMemberList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TestRailAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GitHubAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnActivate = new System.Windows.Forms.Button();
            this.btnForbidden = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbTenants = new System.Windows.Forms.ComboBox();
            this.lblTenant = new System.Windows.Forms.Label();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.cmbGroups = new System.Windows.Forms.ComboBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.grbSearchBox = new System.Windows.Forms.GroupBox();
            this.btnAssignToRole = new System.Windows.Forms.Button();
            this.btnAssignToGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).BeginInit();
            this.grbSearchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMemberList
            // 
            this.dgvMemberList.AllowUserToAddRows = false;
            this.dgvMemberList.AllowUserToDeleteRows = false;
            this.dgvMemberList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMemberList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.UserName,
            this.FirstName,
            this.LastName,
            this.DisplayName,
            this.Signature,
            this.Active,
            this.TenantName,
            this.EmailAddress,
            this.JiraAccount,
            this.TestRailAccount,
            this.GitHubAccount});
            this.dgvMemberList.Location = new System.Drawing.Point(12, 114);
            this.dgvMemberList.Name = "dgvMemberList";
            this.dgvMemberList.ReadOnly = true;
            this.dgvMemberList.Size = new System.Drawing.Size(1190, 619);
            this.dgvMemberList.TabIndex = 0;
            this.dgvMemberList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMemberList_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "No";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // DisplayName
            // 
            this.DisplayName.DataPropertyName = "DisplayName";
            this.DisplayName.HeaderText = "Display Name";
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.ReadOnly = true;
            // 
            // Signature
            // 
            this.Signature.DataPropertyName = "Signature";
            this.Signature.HeaderText = "Signature";
            this.Signature.Name = "Signature";
            this.Signature.ReadOnly = true;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "IsActive";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 50;
            // 
            // TenantName
            // 
            this.TenantName.DataPropertyName = "TenantName";
            this.TenantName.HeaderText = "Tenant";
            this.TenantName.Name = "TenantName";
            this.TenantName.ReadOnly = true;
            // 
            // EmailAddress
            // 
            this.EmailAddress.DataPropertyName = "EmailAddress";
            this.EmailAddress.HeaderText = "Email";
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.ReadOnly = true;
            this.EmailAddress.Width = 150;
            // 
            // JiraAccount
            // 
            this.JiraAccount.DataPropertyName = "JiraAccount";
            this.JiraAccount.HeaderText = "Jira Account";
            this.JiraAccount.Name = "JiraAccount";
            this.JiraAccount.ReadOnly = true;
            this.JiraAccount.Width = 150;
            // 
            // TestRailAccount
            // 
            this.TestRailAccount.DataPropertyName = "TestRailAccount";
            this.TestRailAccount.HeaderText = "TestRail Account";
            this.TestRailAccount.Name = "TestRailAccount";
            this.TestRailAccount.ReadOnly = true;
            this.TestRailAccount.Width = 150;
            // 
            // GitHubAccount
            // 
            this.GitHubAccount.DataPropertyName = "GitHubAccount";
            this.GitHubAccount.HeaderText = "GitHub Account";
            this.GitHubAccount.Name = "GitHubAccount";
            this.GitHubAccount.ReadOnly = true;
            this.GitHubAccount.Width = 150;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnActivate
            // 
            this.btnActivate.Location = new System.Drawing.Point(174, 12);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(75, 23);
            this.btnActivate.TabIndex = 3;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = true;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // btnForbidden
            // 
            this.btnForbidden.Location = new System.Drawing.Point(255, 12);
            this.btnForbidden.Name = "btnForbidden";
            this.btnForbidden.Size = new System.Drawing.Size(75, 23);
            this.btnForbidden.TabIndex = 4;
            this.btnForbidden.Text = "Deactivate";
            this.btnForbidden.UseVisualStyleBackColor = true;
            this.btnForbidden.Click += new System.EventHandler(this.btnForbidden_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(633, 29);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(336, 12);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(113, 23);
            this.btnResetPassword.TabIndex = 6;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(445, 32);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(164, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // cmbTenants
            // 
            this.cmbTenants.FormattingEnabled = true;
            this.cmbTenants.Location = new System.Drawing.Point(21, 32);
            this.cmbTenants.Name = "cmbTenants";
            this.cmbTenants.Size = new System.Drawing.Size(75, 21);
            this.cmbTenants.TabIndex = 8;
            // 
            // lblTenant
            // 
            this.lblTenant.AutoSize = true;
            this.lblTenant.Location = new System.Drawing.Point(18, 16);
            this.lblTenant.Name = "lblTenant";
            this.lblTenant.Size = new System.Drawing.Size(44, 13);
            this.lblTenant.TabIndex = 9;
            this.lblTenant.Text = "Tenant:";
            // 
            // cmbRoles
            // 
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(126, 32);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(111, 21);
            this.cmbRoles.TabIndex = 10;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(123, 16);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(32, 13);
            this.lblRole.TabIndex = 11;
            this.lblRole.Text = "Role:";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(263, 16);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(39, 13);
            this.lblGroup.TabIndex = 12;
            this.lblGroup.Text = "Group:";
            // 
            // cmbGroups
            // 
            this.cmbGroups.FormattingEnabled = true;
            this.cmbGroups.Location = new System.Drawing.Point(266, 32);
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(143, 21);
            this.cmbGroups.TabIndex = 13;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(442, 16);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email:";
            // 
            // grbSearchBox
            // 
            this.grbSearchBox.Controls.Add(this.cmbTenants);
            this.grbSearchBox.Controls.Add(this.lblEmail);
            this.grbSearchBox.Controls.Add(this.btnSearch);
            this.grbSearchBox.Controls.Add(this.lblTenant);
            this.grbSearchBox.Controls.Add(this.txtEmail);
            this.grbSearchBox.Controls.Add(this.lblGroup);
            this.grbSearchBox.Controls.Add(this.cmbGroups);
            this.grbSearchBox.Controls.Add(this.cmbRoles);
            this.grbSearchBox.Controls.Add(this.lblRole);
            this.grbSearchBox.Location = new System.Drawing.Point(12, 41);
            this.grbSearchBox.Name = "grbSearchBox";
            this.grbSearchBox.Size = new System.Drawing.Size(714, 67);
            this.grbSearchBox.TabIndex = 15;
            this.grbSearchBox.TabStop = false;
            // 
            // btnAssignToRole
            // 
            this.btnAssignToRole.Location = new System.Drawing.Point(457, 12);
            this.btnAssignToRole.Name = "btnAssignToRole";
            this.btnAssignToRole.Size = new System.Drawing.Size(113, 23);
            this.btnAssignToRole.TabIndex = 16;
            this.btnAssignToRole.Text = "Assign to Role";
            this.btnAssignToRole.UseVisualStyleBackColor = true;
            this.btnAssignToRole.Click += new System.EventHandler(this.btnAssignToRole_Click);
            // 
            // btnAssignToGroup
            // 
            this.btnAssignToGroup.Location = new System.Drawing.Point(578, 12);
            this.btnAssignToGroup.Name = "btnAssignToGroup";
            this.btnAssignToGroup.Size = new System.Drawing.Size(113, 23);
            this.btnAssignToGroup.TabIndex = 17;
            this.btnAssignToGroup.Text = "Assign to Group";
            this.btnAssignToGroup.UseVisualStyleBackColor = true;
            this.btnAssignToGroup.Click += new System.EventHandler(this.btnAssignToGroup_Click);
            // 
            // frmMembers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.btnAssignToGroup);
            this.Controls.Add(this.btnAssignToRole);
            this.Controls.Add(this.grbSearchBox);
            this.Controls.Add(this.btnResetPassword);
            this.Controls.Add(this.btnForbidden);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.dgvMemberList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMembers";
            this.ShowInTaskbar = false;
            this.Text = "Member Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgvMemberList)).EndInit();
            this.grbSearchBox.ResumeLayout(false);
            this.grbSearchBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMemberList;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.Button btnForbidden;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbTenants;
        private System.Windows.Forms.Label lblTenant;
        private System.Windows.Forms.ComboBox cmbRoles;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.ComboBox cmbGroups;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.GroupBox grbSearchBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signature;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TestRailAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn GitHubAccount;
        private System.Windows.Forms.Button btnAssignToRole;
        private System.Windows.Forms.Button btnAssignToGroup;
    }
}