﻿namespace SmartEngineer.Forms
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseServerSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailServerSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rolesSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jiraMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSubTaskSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDBTicketSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workLogReportSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryProgressReportSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanCaseStatusCrossProjectSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesforceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCaseSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyCaseSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanReleaseStatusSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accelaFTPMonitorSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeAttachmentsSubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testRailMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolMenuExecuteImportNewCase = new System.Windows.Forms.ToolStripButton();
            this.toolMenuSyncStatusBetweenSalesforceAndJira = new System.Windows.Forms.ToolStripButton();
            this.toolMenuSendOutDailyWorkLogReport = new System.Windows.Forms.ToolStripButton();
            this.toolMenuSendOutDailyReport = new System.Windows.Forms.ToolStripButton();
            this.toolMenuSendOutWeeklyReport = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsMenuItem,
            this.accountsMenuItem,
            this.jiraMenuItem,
            this.salesforceMenuItem,
            this.githubMenuItem,
            this.testRailMenuItem,
            this.helpMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1234, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip";
            // 
            // SettingsMenuItem
            // 
            this.SettingsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseServerSubMenuItem,
            this.emailServerSubMenuItem,
            this.logoutSubMenuItem,
            this.exitSubMenuItem});
            this.SettingsMenuItem.Name = "SettingsMenuItem";
            this.SettingsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.SettingsMenuItem.Text = "Settings";
            // 
            // databaseServerSubMenuItem
            // 
            this.databaseServerSubMenuItem.Name = "databaseServerSubMenuItem";
            this.databaseServerSubMenuItem.Size = new System.Drawing.Size(157, 22);
            this.databaseServerSubMenuItem.Tag = "Database Server Setting";
            this.databaseServerSubMenuItem.Text = "Database Server";
            this.databaseServerSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // emailServerSubMenuItem
            // 
            this.emailServerSubMenuItem.Name = "emailServerSubMenuItem";
            this.emailServerSubMenuItem.Size = new System.Drawing.Size(157, 22);
            this.emailServerSubMenuItem.Tag = "Email Server Setting";
            this.emailServerSubMenuItem.Text = "Email Server";
            this.emailServerSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // logoutSubMenuItem
            // 
            this.logoutSubMenuItem.Name = "logoutSubMenuItem";
            this.logoutSubMenuItem.Size = new System.Drawing.Size(157, 22);
            this.logoutSubMenuItem.Text = "Logout";
            this.logoutSubMenuItem.Click += new System.EventHandler(this.logoutSubMenuItem_Click);
            // 
            // exitSubMenuItem
            // 
            this.exitSubMenuItem.Name = "exitSubMenuItem";
            this.exitSubMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitSubMenuItem.Text = "Exit";
            this.exitSubMenuItem.Click += new System.EventHandler(this.exitSubMenuItem_Click);
            // 
            // accountsMenuItem
            // 
            this.accountsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userSubMenuItem,
            this.rolesSubMenuItem,
            this.groupSubMenuItem,
            this.permissionSubMenuItem});
            this.accountsMenuItem.Name = "accountsMenuItem";
            this.accountsMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsMenuItem.Text = "Accounts";
            // 
            // userSubMenuItem
            // 
            this.userSubMenuItem.Name = "userSubMenuItem";
            this.userSubMenuItem.Size = new System.Drawing.Size(137, 22);
            this.userSubMenuItem.Tag = "Users";
            this.userSubMenuItem.Text = "Users";
            this.userSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // rolesSubMenuItem
            // 
            this.rolesSubMenuItem.Name = "rolesSubMenuItem";
            this.rolesSubMenuItem.Size = new System.Drawing.Size(137, 22);
            this.rolesSubMenuItem.Tag = "Roles";
            this.rolesSubMenuItem.Text = "Roles";
            this.rolesSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // groupSubMenuItem
            // 
            this.groupSubMenuItem.Name = "groupSubMenuItem";
            this.groupSubMenuItem.Size = new System.Drawing.Size(137, 22);
            this.groupSubMenuItem.Tag = "Groups";
            this.groupSubMenuItem.Text = "Groups";
            this.groupSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // permissionSubMenuItem
            // 
            this.permissionSubMenuItem.Name = "permissionSubMenuItem";
            this.permissionSubMenuItem.Size = new System.Drawing.Size(137, 22);
            this.permissionSubMenuItem.Tag = "Permissions";
            this.permissionSubMenuItem.Text = "Permissions";
            this.permissionSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // jiraMenuItem
            // 
            this.jiraMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSubTaskSubMenuItem,
            this.createDBTicketSubMenuItem,
            this.workLogReportSubMenuItem,
            this.deliveryProgressReportSubMenuItem,
            this.scanCaseStatusCrossProjectSubMenuItem});
            this.jiraMenuItem.Name = "jiraMenuItem";
            this.jiraMenuItem.Size = new System.Drawing.Size(41, 20);
            this.jiraMenuItem.Text = "JIRA";
            // 
            // createSubTaskSubMenuItem
            // 
            this.createSubTaskSubMenuItem.Name = "createSubTaskSubMenuItem";
            this.createSubTaskSubMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createSubTaskSubMenuItem.Tag = "Create Sub Task";
            this.createSubTaskSubMenuItem.Text = "Create Sub Task";
            this.createSubTaskSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // createDBTicketSubMenuItem
            // 
            this.createDBTicketSubMenuItem.Name = "createDBTicketSubMenuItem";
            this.createDBTicketSubMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createDBTicketSubMenuItem.Tag = "Create DB Ticket";
            this.createDBTicketSubMenuItem.Text = "Create DB Ticket";
            this.createDBTicketSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // workLogReportSubMenuItem
            // 
            this.workLogReportSubMenuItem.Name = "workLogReportSubMenuItem";
            this.workLogReportSubMenuItem.Size = new System.Drawing.Size(234, 22);
            this.workLogReportSubMenuItem.Tag = "Work Log Report";
            this.workLogReportSubMenuItem.Text = "Work Log Report";
            this.workLogReportSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // deliveryProgressReportSubMenuItem
            // 
            this.deliveryProgressReportSubMenuItem.Name = "deliveryProgressReportSubMenuItem";
            this.deliveryProgressReportSubMenuItem.Size = new System.Drawing.Size(234, 22);
            this.deliveryProgressReportSubMenuItem.Tag = "Delivery Progress Report";
            this.deliveryProgressReportSubMenuItem.Text = "Delivery Progress Report";
            this.deliveryProgressReportSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // scanCaseStatusCrossProjectSubMenuItem
            // 
            this.scanCaseStatusCrossProjectSubMenuItem.Name = "scanCaseStatusCrossProjectSubMenuItem";
            this.scanCaseStatusCrossProjectSubMenuItem.Size = new System.Drawing.Size(234, 22);
            this.scanCaseStatusCrossProjectSubMenuItem.Tag = "Scan Case Status Cross Project";
            this.scanCaseStatusCrossProjectSubMenuItem.Text = "Scan Case Status Cross Project";
            this.scanCaseStatusCrossProjectSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // salesforceMenuItem
            // 
            this.salesforceMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyCaseSubMenuItem,
            this.weeklyCaseSubMenuItem,
            this.scanReleaseStatusSubMenuItem,
            this.accelaFTPMonitorSubMenuItem,
            this.mergeAttachmentsSubMenuItem});
            this.salesforceMenuItem.Name = "salesforceMenuItem";
            this.salesforceMenuItem.Size = new System.Drawing.Size(72, 20);
            this.salesforceMenuItem.Text = "Salesforce";
            // 
            // dailyCaseSubMenuItem
            // 
            this.dailyCaseSubMenuItem.Name = "dailyCaseSubMenuItem";
            this.dailyCaseSubMenuItem.Size = new System.Drawing.Size(190, 22);
            this.dailyCaseSubMenuItem.Tag = "Daily Case Manager";
            this.dailyCaseSubMenuItem.Text = "Daily Case Manager";
            this.dailyCaseSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // weeklyCaseSubMenuItem
            // 
            this.weeklyCaseSubMenuItem.Name = "weeklyCaseSubMenuItem";
            this.weeklyCaseSubMenuItem.Size = new System.Drawing.Size(190, 22);
            this.weeklyCaseSubMenuItem.Tag = "Weekly Case Manager";
            this.weeklyCaseSubMenuItem.Text = "Weekly Case Manager";
            this.weeklyCaseSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // scanReleaseStatusSubMenuItem
            // 
            this.scanReleaseStatusSubMenuItem.Name = "scanReleaseStatusSubMenuItem";
            this.scanReleaseStatusSubMenuItem.Size = new System.Drawing.Size(190, 22);
            this.scanReleaseStatusSubMenuItem.Tag = "Scan Release Status";
            this.scanReleaseStatusSubMenuItem.Text = "Scan Release Status";
            this.scanReleaseStatusSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // accelaFTPMonitorSubMenuItem
            // 
            this.accelaFTPMonitorSubMenuItem.Name = "accelaFTPMonitorSubMenuItem";
            this.accelaFTPMonitorSubMenuItem.Size = new System.Drawing.Size(190, 22);
            this.accelaFTPMonitorSubMenuItem.Tag = "Scan New FTP Upload";
            this.accelaFTPMonitorSubMenuItem.Text = "Scan New FTP Upload";
            this.accelaFTPMonitorSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // mergeAttachmentsSubMenuItem
            // 
            this.mergeAttachmentsSubMenuItem.Name = "mergeAttachmentsSubMenuItem";
            this.mergeAttachmentsSubMenuItem.Size = new System.Drawing.Size(190, 22);
            this.mergeAttachmentsSubMenuItem.Tag = "Merge Attachments";
            this.mergeAttachmentsSubMenuItem.Text = "Merge Attachments";
            this.mergeAttachmentsSubMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // githubMenuItem
            // 
            this.githubMenuItem.Name = "githubMenuItem";
            this.githubMenuItem.Size = new System.Drawing.Size(55, 20);
            this.githubMenuItem.Text = "Github";
            // 
            // testRailMenuItem
            // 
            this.testRailMenuItem.Name = "testRailMenuItem";
            this.testRailMenuItem.Size = new System.Drawing.Size(59, 20);
            this.testRailMenuItem.Text = "TestRail";
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.contactToolStripMenuItem});
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpMenuItem.Text = "Help";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.versionToolStripMenuItem.Tag = "Version";
            this.versionToolStripMenuItem.Text = "Version";
            this.versionToolStripMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.licenseToolStripMenuItem.Tag = "License";
            this.licenseToolStripMenuItem.Text = "License";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // contactToolStripMenuItem
            // 
            this.contactToolStripMenuItem.Name = "contactToolStripMenuItem";
            this.contactToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.contactToolStripMenuItem.Tag = "Contact";
            this.contactToolStripMenuItem.Text = "Contact";
            this.contactToolStripMenuItem.Click += new System.EventHandler(this.SubMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 789);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1234, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuExecuteImportNewCase,
            this.toolMenuSyncStatusBetweenSalesforceAndJira,
            this.toolMenuSendOutDailyWorkLogReport,
            this.toolMenuSendOutDailyReport,
            this.toolMenuSendOutWeeklyReport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1234, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolMenuExecuteImportNewCase
            // 
            this.toolMenuExecuteImportNewCase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMenuExecuteImportNewCase.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuExecuteImportNewCase.Image")));
            this.toolMenuExecuteImportNewCase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuExecuteImportNewCase.Name = "toolMenuExecuteImportNewCase";
            this.toolMenuExecuteImportNewCase.Size = new System.Drawing.Size(23, 22);
            this.toolMenuExecuteImportNewCase.Text = "Import New Case";
            this.toolMenuExecuteImportNewCase.Click += new System.EventHandler(this.toolMenuItem_Click);
            // 
            // toolMenuSyncStatusBetweenSalesforceAndJira
            // 
            this.toolMenuSyncStatusBetweenSalesforceAndJira.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMenuSyncStatusBetweenSalesforceAndJira.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuSyncStatusBetweenSalesforceAndJira.Image")));
            this.toolMenuSyncStatusBetweenSalesforceAndJira.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuSyncStatusBetweenSalesforceAndJira.Name = "toolMenuSyncStatusBetweenSalesforceAndJira";
            this.toolMenuSyncStatusBetweenSalesforceAndJira.Size = new System.Drawing.Size(23, 22);
            this.toolMenuSyncStatusBetweenSalesforceAndJira.Text = "Sync Status between Salesforce and Jira";
            this.toolMenuSyncStatusBetweenSalesforceAndJira.Click += new System.EventHandler(this.toolMenuItem_Click);
            // 
            // toolMenuSendOutDailyWorkLogReport
            // 
            this.toolMenuSendOutDailyWorkLogReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMenuSendOutDailyWorkLogReport.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuSendOutDailyWorkLogReport.Image")));
            this.toolMenuSendOutDailyWorkLogReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuSendOutDailyWorkLogReport.Name = "toolMenuSendOutDailyWorkLogReport";
            this.toolMenuSendOutDailyWorkLogReport.Size = new System.Drawing.Size(23, 22);
            this.toolMenuSendOutDailyWorkLogReport.Text = "Send Out Daily Work Log Report";
            // 
            // toolMenuSendOutDailyReport
            // 
            this.toolMenuSendOutDailyReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMenuSendOutDailyReport.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuSendOutDailyReport.Image")));
            this.toolMenuSendOutDailyReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuSendOutDailyReport.Name = "toolMenuSendOutDailyReport";
            this.toolMenuSendOutDailyReport.Size = new System.Drawing.Size(23, 22);
            this.toolMenuSendOutDailyReport.Text = "Send Out Daily Case Review Report";
            this.toolMenuSendOutDailyReport.Click += new System.EventHandler(this.toolMenuItem_Click);
            // 
            // toolMenuSendOutWeeklyReport
            // 
            this.toolMenuSendOutWeeklyReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolMenuSendOutWeeklyReport.Image = ((System.Drawing.Image)(resources.GetObject("toolMenuSendOutWeeklyReport.Image")));
            this.toolMenuSendOutWeeklyReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolMenuSendOutWeeklyReport.Name = "toolMenuSendOutWeeklyReport";
            this.toolMenuSendOutWeeklyReport.Size = new System.Drawing.Size(23, 22);
            this.toolMenuSendOutWeeklyReport.Text = "Send Out Weekly Case Review Report";
            this.toolMenuSendOutWeeklyReport.Click += new System.EventHandler(this.toolMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 811);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.Text = "Smart Engineer - 2018";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseServerSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailServerSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rolesSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem groupSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jiraMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesforceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testRailMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolMenuExecuteImportNewCase;
        private System.Windows.Forms.ToolStripButton toolMenuSyncStatusBetweenSalesforceAndJira;
        private System.Windows.Forms.ToolStripMenuItem logoutSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCaseSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createSubTaskSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDBTicketSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workLogReportSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryProgressReportSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklyCaseSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanReleaseStatusSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanCaseStatusCrossProjectSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accelaFTPMonitorSubMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeAttachmentsSubMenuItem;
        private System.Windows.Forms.ToolStripButton toolMenuSendOutDailyReport;
        private System.Windows.Forms.ToolStripButton toolMenuSendOutWeeklyReport;
        private System.Windows.Forms.ToolStripButton toolMenuSendOutDailyWorkLogReport;
    }
}

