namespace SmartEngineer.Forms
{
    partial class frmScanCaseStatusCrossProject
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
            this.grbCaseStatusCrossProject = new System.Windows.Forms.GroupBox();
            this.grdAccelaCaseStatus = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppJiraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppJiraAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkedJiraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkedJiraAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SuppJiraStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkedJiraStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sync = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpImportedCaseList = new System.Windows.Forms.GroupBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnScanCaseCrossProject = new System.Windows.Forms.Button();
            this.txtCaseIdList = new System.Windows.Forms.TextBox();
            this.grpScanJiraIssues = new System.Windows.Forms.GroupBox();
            this.btnScanCrossProjects = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkProjectPMA = new System.Windows.Forms.CheckBox();
            this.chkProjectAATHETA = new System.Windows.Forms.CheckBox();
            this.chkProjectCAGAMMA = new System.Windows.Forms.CheckBox();
            this.chkProjectENGSUPP = new System.Windows.Forms.CheckBox();
            this.lblSelectProject = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.grbCaseStatusCrossProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAccelaCaseStatus)).BeginInit();
            this.grpImportedCaseList.SuspendLayout();
            this.grpScanJiraIssues.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbCaseStatusCrossProject
            // 
            this.grbCaseStatusCrossProject.Controls.Add(this.grdAccelaCaseStatus);
            this.grbCaseStatusCrossProject.Location = new System.Drawing.Point(13, 219);
            this.grbCaseStatusCrossProject.Name = "grbCaseStatusCrossProject";
            this.grbCaseStatusCrossProject.Size = new System.Drawing.Size(1176, 530);
            this.grbCaseStatusCrossProject.TabIndex = 5;
            this.grbCaseStatusCrossProject.TabStop = false;
            this.grbCaseStatusCrossProject.Text = "3. Case Status List";
            // 
            // grdAccelaCaseStatus
            // 
            this.grdAccelaCaseStatus.AllowUserToAddRows = false;
            this.grdAccelaCaseStatus.AllowUserToDeleteRows = false;
            this.grdAccelaCaseStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAccelaCaseStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SFID,
            this.SuppJiraID,
            this.SuppJiraAssignee,
            this.LinkedJiraID,
            this.LinkedJiraAssignee,
            this.Summary,
            this.SFQueue,
            this.SFStatus,
            this.SuppJiraStatus,
            this.LinkedJiraStatus,
            this.Sync});
            this.grdAccelaCaseStatus.Location = new System.Drawing.Point(6, 19);
            this.grdAccelaCaseStatus.Name = "grdAccelaCaseStatus";
            this.grdAccelaCaseStatus.ReadOnly = true;
            this.grdAccelaCaseStatus.Size = new System.Drawing.Size(1157, 491);
            this.grdAccelaCaseStatus.TabIndex = 0;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // SFID
            // 
            this.SFID.DataPropertyName = "SFID";
            this.SFID.FillWeight = 50F;
            this.SFID.HeaderText = "SF ID";
            this.SFID.Name = "SFID";
            this.SFID.ReadOnly = true;
            // 
            // SuppJiraID
            // 
            this.SuppJiraID.DataPropertyName = "SuppJiraID";
            this.SuppJiraID.HeaderText = "Supp JIRA ID";
            this.SuppJiraID.Name = "SuppJiraID";
            this.SuppJiraID.ReadOnly = true;
            this.SuppJiraID.Width = 120;
            // 
            // SuppJiraAssignee
            // 
            this.SuppJiraAssignee.DataPropertyName = "SuppJiraAssignee";
            this.SuppJiraAssignee.HeaderText = "SUPP JIRA Assignee";
            this.SuppJiraAssignee.Name = "SuppJiraAssignee";
            this.SuppJiraAssignee.ReadOnly = true;
            this.SuppJiraAssignee.Width = 150;
            // 
            // LinkedJiraID
            // 
            this.LinkedJiraID.DataPropertyName = "LinkedJiraID";
            this.LinkedJiraID.HeaderText = "Linked JIRA ID";
            this.LinkedJiraID.Name = "LinkedJiraID";
            this.LinkedJiraID.ReadOnly = true;
            this.LinkedJiraID.Width = 120;
            // 
            // LinkedJiraAssignee
            // 
            this.LinkedJiraAssignee.DataPropertyName = "LinkedJiraAssignee";
            this.LinkedJiraAssignee.HeaderText = "Linked JIRA Assignee";
            this.LinkedJiraAssignee.Name = "LinkedJiraAssignee";
            this.LinkedJiraAssignee.ReadOnly = true;
            this.LinkedJiraAssignee.Width = 150;
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            this.Summary.Width = 150;
            // 
            // SFQueue
            // 
            this.SFQueue.DataPropertyName = "SFQueue";
            this.SFQueue.HeaderText = "SF Queue";
            this.SFQueue.Name = "SFQueue";
            this.SFQueue.ReadOnly = true;
            // 
            // SFStatus
            // 
            this.SFStatus.DataPropertyName = "SFStatus";
            this.SFStatus.HeaderText = "SF Status";
            this.SFStatus.Name = "SFStatus";
            this.SFStatus.ReadOnly = true;
            // 
            // SuppJiraStatus
            // 
            this.SuppJiraStatus.DataPropertyName = "SuppJiraStatus";
            this.SuppJiraStatus.HeaderText = "Supp JIRA Status";
            this.SuppJiraStatus.Name = "SuppJiraStatus";
            this.SuppJiraStatus.ReadOnly = true;
            this.SuppJiraStatus.Width = 120;
            // 
            // LinkedJiraStatus
            // 
            this.LinkedJiraStatus.DataPropertyName = "LinkedJiraStatus";
            this.LinkedJiraStatus.HeaderText = "Linked JIRA Status";
            this.LinkedJiraStatus.Name = "LinkedJiraStatus";
            this.LinkedJiraStatus.ReadOnly = true;
            this.LinkedJiraStatus.Width = 150;
            // 
            // Sync
            // 
            this.Sync.DataPropertyName = "Sync";
            this.Sync.HeaderText = "Sync";
            this.Sync.Name = "Sync";
            this.Sync.ReadOnly = true;
            this.Sync.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sync.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // grpImportedCaseList
            // 
            this.grpImportedCaseList.Controls.Add(this.btnSendEmail);
            this.grpImportedCaseList.Controls.Add(this.btnScanCaseCrossProject);
            this.grpImportedCaseList.Controls.Add(this.txtCaseIdList);
            this.grpImportedCaseList.Location = new System.Drawing.Point(13, 119);
            this.grpImportedCaseList.Name = "grpImportedCaseList";
            this.grpImportedCaseList.Size = new System.Drawing.Size(1176, 94);
            this.grpImportedCaseList.TabIndex = 4;
            this.grpImportedCaseList.TabStop = false;
            this.grpImportedCaseList.Text = "2. Enter Case List";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Location = new System.Drawing.Point(1072, 19);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(91, 61);
            this.btnSendEmail.TabIndex = 13;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            // 
            // btnScanCaseCrossProject
            // 
            this.btnScanCaseCrossProject.Location = new System.Drawing.Point(975, 19);
            this.btnScanCaseCrossProject.Name = "btnScanCaseCrossProject";
            this.btnScanCaseCrossProject.Size = new System.Drawing.Size(91, 61);
            this.btnScanCaseCrossProject.TabIndex = 12;
            this.btnScanCaseCrossProject.Text = "Scan";
            this.btnScanCaseCrossProject.UseVisualStyleBackColor = true;
            // 
            // txtCaseIdList
            // 
            this.txtCaseIdList.Location = new System.Drawing.Point(6, 19);
            this.txtCaseIdList.Multiline = true;
            this.txtCaseIdList.Name = "txtCaseIdList";
            this.txtCaseIdList.Size = new System.Drawing.Size(963, 61);
            this.txtCaseIdList.TabIndex = 0;
            // 
            // grpScanJiraIssues
            // 
            this.grpScanJiraIssues.Controls.Add(this.btnScanCrossProjects);
            this.grpScanJiraIssues.Controls.Add(this.label1);
            this.grpScanJiraIssues.Controls.Add(this.chkProjectPMA);
            this.grpScanJiraIssues.Controls.Add(this.chkProjectAATHETA);
            this.grpScanJiraIssues.Controls.Add(this.chkProjectCAGAMMA);
            this.grpScanJiraIssues.Controls.Add(this.chkProjectENGSUPP);
            this.grpScanJiraIssues.Controls.Add(this.lblSelectProject);
            this.grpScanJiraIssues.Controls.Add(this.dtpEndDate);
            this.grpScanJiraIssues.Controls.Add(this.lblEndDate);
            this.grpScanJiraIssues.Controls.Add(this.dtpStartDate);
            this.grpScanJiraIssues.Controls.Add(this.lblStartDate);
            this.grpScanJiraIssues.Location = new System.Drawing.Point(13, 10);
            this.grpScanJiraIssues.Name = "grpScanJiraIssues";
            this.grpScanJiraIssues.Size = new System.Drawing.Size(1176, 90);
            this.grpScanJiraIssues.TabIndex = 3;
            this.grpScanJiraIssues.TabStop = false;
            this.grpScanJiraIssues.Text = "1. Scan JIRA Issue Status from Selected Projects";
            // 
            // btnScanCrossProjects
            // 
            this.btnScanCrossProjects.Location = new System.Drawing.Point(975, 19);
            this.btnScanCrossProjects.Name = "btnScanCrossProjects";
            this.btnScanCrossProjects.Size = new System.Drawing.Size(188, 61);
            this.btnScanCrossProjects.TabIndex = 11;
            this.btnScanCrossProjects.Text = "Scan Cross Projects";
            this.btnScanCrossProjects.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Please set the date period";
            // 
            // chkProjectPMA
            // 
            this.chkProjectPMA.AutoSize = true;
            this.chkProjectPMA.Checked = true;
            this.chkProjectPMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProjectPMA.Location = new System.Drawing.Point(436, 67);
            this.chkProjectPMA.Name = "chkProjectPMA";
            this.chkProjectPMA.Size = new System.Drawing.Size(49, 17);
            this.chkProjectPMA.TabIndex = 9;
            this.chkProjectPMA.Text = "PMA";
            this.chkProjectPMA.UseVisualStyleBackColor = true;
            // 
            // chkProjectAATHETA
            // 
            this.chkProjectAATHETA.AutoSize = true;
            this.chkProjectAATHETA.Checked = true;
            this.chkProjectAATHETA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProjectAATHETA.Location = new System.Drawing.Point(339, 66);
            this.chkProjectAATHETA.Name = "chkProjectAATHETA";
            this.chkProjectAATHETA.Size = new System.Drawing.Size(76, 17);
            this.chkProjectAATHETA.TabIndex = 8;
            this.chkProjectAATHETA.Text = "AATHETA";
            this.chkProjectAATHETA.UseVisualStyleBackColor = true;
            // 
            // chkProjectCAGAMMA
            // 
            this.chkProjectCAGAMMA.AutoSize = true;
            this.chkProjectCAGAMMA.Checked = true;
            this.chkProjectCAGAMMA.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProjectCAGAMMA.Location = new System.Drawing.Point(436, 44);
            this.chkProjectCAGAMMA.Name = "chkProjectCAGAMMA";
            this.chkProjectCAGAMMA.Size = new System.Drawing.Size(80, 17);
            this.chkProjectCAGAMMA.TabIndex = 7;
            this.chkProjectCAGAMMA.Text = "CAGAMMA";
            this.chkProjectCAGAMMA.UseVisualStyleBackColor = true;
            // 
            // chkProjectENGSUPP
            // 
            this.chkProjectENGSUPP.AutoSize = true;
            this.chkProjectENGSUPP.Location = new System.Drawing.Point(339, 44);
            this.chkProjectENGSUPP.Name = "chkProjectENGSUPP";
            this.chkProjectENGSUPP.Size = new System.Drawing.Size(78, 17);
            this.chkProjectENGSUPP.TabIndex = 6;
            this.chkProjectENGSUPP.Text = "ENGSUPP";
            this.chkProjectENGSUPP.UseVisualStyleBackColor = true;
            // 
            // lblSelectProject
            // 
            this.lblSelectProject.AutoSize = true;
            this.lblSelectProject.Location = new System.Drawing.Point(336, 24);
            this.lblSelectProject.Name = "lblSelectProject";
            this.lblSelectProject.Size = new System.Drawing.Size(163, 13);
            this.lblSelectProject.TabIndex = 5;
            this.lblSelectProject.Text = "Please select at least one project";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(93, 64);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 20);
            this.dtpEndDate.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(21, 70);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(52, 13);
            this.lblEndDate.TabIndex = 2;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(93, 41);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 20);
            this.dtpStartDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(21, 47);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "Start Date";
            // 
            // frmScanCaseStatusCrossProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.grbCaseStatusCrossProject);
            this.Controls.Add(this.grpImportedCaseList);
            this.Controls.Add(this.grpScanJiraIssues);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanCaseStatusCrossProject";
            this.ShowInTaskbar = false;
            this.Text = "Scan Case Status Cross Project";
            this.grbCaseStatusCrossProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAccelaCaseStatus)).EndInit();
            this.grpImportedCaseList.ResumeLayout(false);
            this.grpImportedCaseList.PerformLayout();
            this.grpScanJiraIssues.ResumeLayout(false);
            this.grpScanJiraIssues.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbCaseStatusCrossProject;
        private System.Windows.Forms.DataGridView grdAccelaCaseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppJiraID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppJiraAssignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkedJiraID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkedJiraAssignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SuppJiraStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkedJiraStatus;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sync;
        private System.Windows.Forms.GroupBox grpImportedCaseList;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnScanCaseCrossProject;
        private System.Windows.Forms.TextBox txtCaseIdList;
        private System.Windows.Forms.GroupBox grpScanJiraIssues;
        private System.Windows.Forms.Button btnScanCrossProjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkProjectPMA;
        private System.Windows.Forms.CheckBox chkProjectAATHETA;
        private System.Windows.Forms.CheckBox chkProjectCAGAMMA;
        private System.Windows.Forms.CheckBox chkProjectENGSUPP;
        private System.Windows.Forms.Label lblSelectProject;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblStartDate;
    }
}