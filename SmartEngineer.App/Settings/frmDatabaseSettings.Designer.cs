namespace SmartEngineer.Forms
{
    partial class frmDatabaseSettings
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
            this.txtServerName = new System.Windows.Forms.TextBox();
            this.lblServerName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grbAuthentication = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cmbAuthenticationType = new System.Windows.Forms.ComboBox();
            this.lblAuthenticationType = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.grbConnectToDatabase = new System.Windows.Forms.GroupBox();
            this.cmbAuditLog = new System.Windows.Forms.ComboBox();
            this.cmbSmartEngineer = new System.Windows.Forms.ComboBox();
            this.cmbMembership = new System.Windows.Forms.ComboBox();
            this.lblAuditLog = new System.Windows.Forms.Label();
            this.lblSmartEngineer = new System.Windows.Forms.Label();
            this.lblMembership = new System.Windows.Forms.Label();
            this.btnTestConnection = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdvancedSettings = new System.Windows.Forms.Button();
            this.lblLine = new System.Windows.Forms.Label();
            this.grbAuthentication.SuspendLayout();
            this.grbConnectToDatabase.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerName
            // 
            this.txtServerName.Location = new System.Drawing.Point(99, 35);
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Size = new System.Drawing.Size(170, 20);
            this.txtServerName.TabIndex = 0;
            // 
            // lblServerName
            // 
            this.lblServerName.AutoSize = true;
            this.lblServerName.Location = new System.Drawing.Point(21, 38);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Size = new System.Drawing.Size(72, 13);
            this.lblServerName.TabIndex = 1;
            this.lblServerName.Text = "Server Name:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(275, 33);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grbAuthentication
            // 
            this.grbAuthentication.Controls.Add(this.txtPassword);
            this.grbAuthentication.Controls.Add(this.txtUserName);
            this.grbAuthentication.Controls.Add(this.cmbAuthenticationType);
            this.grbAuthentication.Controls.Add(this.lblAuthenticationType);
            this.grbAuthentication.Controls.Add(this.lblPassword);
            this.grbAuthentication.Controls.Add(this.lblUserName);
            this.grbAuthentication.Location = new System.Drawing.Point(24, 78);
            this.grbAuthentication.Name = "grbAuthentication";
            this.grbAuthentication.Size = new System.Drawing.Size(326, 123);
            this.grbAuthentication.TabIndex = 3;
            this.grbAuthentication.TabStop = false;
            this.grbAuthentication.Text = "Log on to the server";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 90);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(132, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(113, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(132, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // cmbAuthenticationType
            // 
            this.cmbAuthenticationType.FormattingEnabled = true;
            this.cmbAuthenticationType.Location = new System.Drawing.Point(113, 31);
            this.cmbAuthenticationType.Name = "cmbAuthenticationType";
            this.cmbAuthenticationType.Size = new System.Drawing.Size(132, 21);
            this.cmbAuthenticationType.TabIndex = 3;
            // 
            // lblAuthenticationType
            // 
            this.lblAuthenticationType.AutoSize = true;
            this.lblAuthenticationType.Location = new System.Drawing.Point(17, 34);
            this.lblAuthenticationType.Name = "lblAuthenticationType";
            this.lblAuthenticationType.Size = new System.Drawing.Size(78, 13);
            this.lblAuthenticationType.TabIndex = 2;
            this.lblAuthenticationType.Text = "Authentication:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(39, 93);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(34, 63);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(61, 13);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "User name:";
            // 
            // grbConnectToDatabase
            // 
            this.grbConnectToDatabase.Controls.Add(this.cmbAuditLog);
            this.grbConnectToDatabase.Controls.Add(this.cmbSmartEngineer);
            this.grbConnectToDatabase.Controls.Add(this.cmbMembership);
            this.grbConnectToDatabase.Controls.Add(this.lblAuditLog);
            this.grbConnectToDatabase.Controls.Add(this.lblSmartEngineer);
            this.grbConnectToDatabase.Controls.Add(this.lblMembership);
            this.grbConnectToDatabase.Location = new System.Drawing.Point(24, 219);
            this.grbConnectToDatabase.Name = "grbConnectToDatabase";
            this.grbConnectToDatabase.Size = new System.Drawing.Size(326, 109);
            this.grbConnectToDatabase.TabIndex = 4;
            this.grbConnectToDatabase.TabStop = false;
            this.grbConnectToDatabase.Text = "Connect to a database";
            // 
            // cmbAuditLog
            // 
            this.cmbAuditLog.FormattingEnabled = true;
            this.cmbAuditLog.Location = new System.Drawing.Point(113, 81);
            this.cmbAuditLog.Name = "cmbAuditLog";
            this.cmbAuditLog.Size = new System.Drawing.Size(132, 21);
            this.cmbAuditLog.TabIndex = 6;
            // 
            // cmbSmartEngineer
            // 
            this.cmbSmartEngineer.FormattingEnabled = true;
            this.cmbSmartEngineer.Location = new System.Drawing.Point(113, 54);
            this.cmbSmartEngineer.Name = "cmbSmartEngineer";
            this.cmbSmartEngineer.Size = new System.Drawing.Size(132, 21);
            this.cmbSmartEngineer.TabIndex = 5;
            // 
            // cmbMembership
            // 
            this.cmbMembership.FormattingEnabled = true;
            this.cmbMembership.Location = new System.Drawing.Point(113, 26);
            this.cmbMembership.Name = "cmbMembership";
            this.cmbMembership.Size = new System.Drawing.Size(132, 21);
            this.cmbMembership.TabIndex = 4;
            // 
            // lblAuditLog
            // 
            this.lblAuditLog.AutoSize = true;
            this.lblAuditLog.Location = new System.Drawing.Point(40, 84);
            this.lblAuditLog.Name = "lblAuditLog";
            this.lblAuditLog.Size = new System.Drawing.Size(55, 13);
            this.lblAuditLog.TabIndex = 2;
            this.lblAuditLog.Text = "Audit Log:";
            // 
            // lblSmartEngineer
            // 
            this.lblSmartEngineer.AutoSize = true;
            this.lblSmartEngineer.Location = new System.Drawing.Point(13, 54);
            this.lblSmartEngineer.Name = "lblSmartEngineer";
            this.lblSmartEngineer.Size = new System.Drawing.Size(82, 13);
            this.lblSmartEngineer.TabIndex = 1;
            this.lblSmartEngineer.Text = "Smart Engineer:";
            // 
            // lblMembership
            // 
            this.lblMembership.AutoSize = true;
            this.lblMembership.Location = new System.Drawing.Point(28, 29);
            this.lblMembership.Name = "lblMembership";
            this.lblMembership.Size = new System.Drawing.Size(67, 13);
            this.lblMembership.TabIndex = 0;
            this.lblMembership.Text = "Membership:";
            // 
            // btnTestConnection
            // 
            this.btnTestConnection.Location = new System.Drawing.Point(24, 377);
            this.btnTestConnection.Name = "btnTestConnection";
            this.btnTestConnection.Size = new System.Drawing.Size(95, 23);
            this.btnTestConnection.TabIndex = 7;
            this.btnTestConnection.Text = "Test Connection";
            this.btnTestConnection.UseVisualStyleBackColor = true;
            this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(186, 377);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(76, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(268, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cacnel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdvancedSettings
            // 
            this.btnAdvancedSettings.Location = new System.Drawing.Point(239, 334);
            this.btnAdvancedSettings.Name = "btnAdvancedSettings";
            this.btnAdvancedSettings.Size = new System.Drawing.Size(111, 23);
            this.btnAdvancedSettings.TabIndex = 10;
            this.btnAdvancedSettings.Text = "Advanced Settings";
            this.btnAdvancedSettings.UseVisualStyleBackColor = true;
            this.btnAdvancedSettings.Click += new System.EventHandler(this.btnAdvancedSettings_Click);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.Location = new System.Drawing.Point(21, 350);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(331, 13);
            this.lblLine.TabIndex = 11;
            this.lblLine.Text = "______________________________________________________";
            // 
            // frmDatabaseSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 409);
            this.ControlBox = false;
            this.Controls.Add(this.btnAdvancedSettings);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTestConnection);
            this.Controls.Add(this.grbConnectToDatabase);
            this.Controls.Add(this.grbAuthentication);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblServerName);
            this.Controls.Add(this.txtServerName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabaseSettings";
            this.Text = "Database Connection Settings";
            this.grbAuthentication.ResumeLayout(false);
            this.grbAuthentication.PerformLayout();
            this.grbConnectToDatabase.ResumeLayout(false);
            this.grbConnectToDatabase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServerName;
        private System.Windows.Forms.Label lblServerName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grbAuthentication;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cmbAuthenticationType;
        private System.Windows.Forms.Label lblAuthenticationType;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.GroupBox grbConnectToDatabase;
        private System.Windows.Forms.ComboBox cmbAuditLog;
        private System.Windows.Forms.ComboBox cmbSmartEngineer;
        private System.Windows.Forms.ComboBox cmbMembership;
        private System.Windows.Forms.Label lblAuditLog;
        private System.Windows.Forms.Label lblSmartEngineer;
        private System.Windows.Forms.Label lblMembership;
        private System.Windows.Forms.Button btnTestConnection;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdvancedSettings;
        private System.Windows.Forms.Label lblLine;
    }
}