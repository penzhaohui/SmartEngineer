namespace SmartEngineer.Forms
{
    partial class frmScanReleaseStatus
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
            this.grbExportTodayCaseList = new System.Windows.Forms.GroupBox();
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orgin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssignedQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InternalType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EngStaus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BZID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TargetedRelease = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FixVersions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSendSummaryReport = new System.Windows.Forms.Button();
            this.btnSyncWithJiraAndSF = new System.Windows.Forms.Button();
            this.lblExportTodayCaseList = new System.Windows.Forms.Label();
            this.grbImportTodayCaseList = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImportTodayCaseList = new System.Windows.Forms.Label();
            this.txtCaseIDList = new System.Windows.Forms.TextBox();
            this.grbExportTodayCaseList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.panel3.SuspendLayout();
            this.grbImportTodayCaseList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbExportTodayCaseList
            // 
            this.grbExportTodayCaseList.Controls.Add(this.grdCaseList);
            this.grbExportTodayCaseList.Controls.Add(this.panel3);
            this.grbExportTodayCaseList.Location = new System.Drawing.Point(6, 141);
            this.grbExportTodayCaseList.Name = "grbExportTodayCaseList";
            this.grbExportTodayCaseList.Size = new System.Drawing.Size(1196, 596);
            this.grbExportTodayCaseList.TabIndex = 12;
            this.grbExportTodayCaseList.TabStop = false;
            this.grbExportTodayCaseList.Text = "2, Export Today Case List";
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.No,
            this.Product,
            this.SalesforceID,
            this.JiraKey,
            this.Severity,
            this.Version,
            this.Type,
            this.Customer,
            this.Orgin,
            this.OpenDate,
            this.Summary,
            this.Reviewer,
            this.Assignee,
            this.AssignedQA,
            this.Status,
            this.SFQueue,
            this.SFStatus,
            this.InternalType,
            this.EngStaus,
            this.BZID,
            this.ReleaseInfo,
            this.TargetedRelease,
            this.FixVersions});
            this.grdCaseList.Location = new System.Drawing.Point(13, 80);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1177, 510);
            this.grdCaseList.TabIndex = 7;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 50;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.FillWeight = 50F;
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 20;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "ProductForUI";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // SalesforceID
            // 
            this.SalesforceID.DataPropertyName = "SalesforceID";
            this.SalesforceID.HeaderText = "Salesforce ID";
            this.SalesforceID.Name = "SalesforceID";
            this.SalesforceID.ReadOnly = true;
            this.SalesforceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesforceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JiraKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Severity
            // 
            this.Severity.DataPropertyName = "Severity";
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "IssueCategory";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Orgin
            // 
            this.Orgin.DataPropertyName = "Orgin";
            this.Orgin.HeaderText = "Orgin";
            this.Orgin.Name = "Orgin";
            // 
            // OpenDate
            // 
            this.OpenDate.DataPropertyName = "OpenDate";
            this.OpenDate.HeaderText = "Open Date";
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.ReadOnly = true;
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // Reviewer
            // 
            this.Reviewer.DataPropertyName = "Reviewer";
            this.Reviewer.HeaderText = "Reviewer";
            this.Reviewer.Name = "Reviewer";
            this.Reviewer.ReadOnly = true;
            // 
            // Assignee
            // 
            this.Assignee.DataPropertyName = "Assignee";
            this.Assignee.HeaderText = "Jira Assignee";
            this.Assignee.Name = "Assignee";
            this.Assignee.ReadOnly = true;
            // 
            // AssignedQA
            // 
            this.AssignedQA.DataPropertyName = "AssigneeQA";
            this.AssignedQA.HeaderText = "Jira Assigned QA";
            this.AssignedQA.Name = "AssignedQA";
            this.AssignedQA.ReadOnly = true;
            this.AssignedQA.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "JiraStatus";
            this.Status.HeaderText = "Jira Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
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
            // InternalType
            // 
            this.InternalType.DataPropertyName = "InternalType";
            this.InternalType.HeaderText = "SF Internal Type";
            this.InternalType.Name = "InternalType";
            this.InternalType.ReadOnly = true;
            this.InternalType.Width = 150;
            // 
            // EngStaus
            // 
            this.EngStaus.DataPropertyName = "EngineeringStatus";
            this.EngStaus.HeaderText = "SF Engineering Status";
            this.EngStaus.Name = "EngStaus";
            this.EngStaus.ReadOnly = true;
            this.EngStaus.Width = 150;
            // 
            // BZID
            // 
            this.BZID.DataPropertyName = "BZID";
            this.BZID.HeaderText = "SF BZID";
            this.BZID.Name = "BZID";
            this.BZID.ReadOnly = true;
            // 
            // ReleaseInfo
            // 
            this.ReleaseInfo.DataPropertyName = "ReleaseInfo";
            this.ReleaseInfo.HeaderText = "SF Release Info";
            this.ReleaseInfo.Name = "ReleaseInfo";
            this.ReleaseInfo.ReadOnly = true;
            this.ReleaseInfo.Width = 300;
            // 
            // TargetedRelease
            // 
            this.TargetedRelease.DataPropertyName = "TargetedRelease";
            this.TargetedRelease.HeaderText = "SF Targeted Release";
            this.TargetedRelease.Name = "TargetedRelease";
            this.TargetedRelease.ReadOnly = true;
            this.TargetedRelease.Width = 300;
            // 
            // FixVersions
            // 
            this.FixVersions.DataPropertyName = "FixVersions";
            this.FixVersions.HeaderText = "Jira Fix Versions";
            this.FixVersions.Name = "FixVersions";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSendSummaryReport);
            this.panel3.Controls.Add(this.btnSyncWithJiraAndSF);
            this.panel3.Controls.Add(this.lblExportTodayCaseList);
            this.panel3.Location = new System.Drawing.Point(13, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1151, 55);
            this.panel3.TabIndex = 9;
            // 
            // btnSendSummaryReport
            // 
            this.btnSendSummaryReport.Location = new System.Drawing.Point(147, 28);
            this.btnSendSummaryReport.Name = "btnSendSummaryReport";
            this.btnSendSummaryReport.Size = new System.Drawing.Size(138, 23);
            this.btnSendSummaryReport.TabIndex = 21;
            this.btnSendSummaryReport.Text = "Send Summary Report";
            this.btnSendSummaryReport.UseVisualStyleBackColor = true;
            // 
            // btnSyncWithJiraAndSF
            // 
            this.btnSyncWithJiraAndSF.Location = new System.Drawing.Point(3, 28);
            this.btnSyncWithJiraAndSF.Name = "btnSyncWithJiraAndSF";
            this.btnSyncWithJiraAndSF.Size = new System.Drawing.Size(138, 23);
            this.btnSyncWithJiraAndSF.TabIndex = 10;
            this.btnSyncWithJiraAndSF.Text = "Sync with JIRA and SF";
            this.btnSyncWithJiraAndSF.UseVisualStyleBackColor = true;
            // 
            // lblExportTodayCaseList
            // 
            this.lblExportTodayCaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExportTodayCaseList.Location = new System.Drawing.Point(0, 0);
            this.lblExportTodayCaseList.Name = "lblExportTodayCaseList";
            this.lblExportTodayCaseList.Size = new System.Drawing.Size(1151, 55);
            this.lblExportTodayCaseList.TabIndex = 20;
            this.lblExportTodayCaseList.Text = "Please inform the QA owner to update salesforce accordingly in time if it is read" +
    "y for release";
            // 
            // grbImportTodayCaseList
            // 
            this.grbImportTodayCaseList.Controls.Add(this.panel1);
            this.grbImportTodayCaseList.Controls.Add(this.txtCaseIDList);
            this.grbImportTodayCaseList.Location = new System.Drawing.Point(6, 11);
            this.grbImportTodayCaseList.Name = "grbImportTodayCaseList";
            this.grbImportTodayCaseList.Size = new System.Drawing.Size(1196, 124);
            this.grbImportTodayCaseList.TabIndex = 11;
            this.grbImportTodayCaseList.TabStop = false;
            this.grbImportTodayCaseList.Text = "1. Enter Case List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblImportTodayCaseList);
            this.panel1.Location = new System.Drawing.Point(10, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 23);
            this.panel1.TabIndex = 4;
            // 
            // lblImportTodayCaseList
            // 
            this.lblImportTodayCaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImportTodayCaseList.Location = new System.Drawing.Point(0, 0);
            this.lblImportTodayCaseList.Name = "lblImportTodayCaseList";
            this.lblImportTodayCaseList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblImportTodayCaseList.Size = new System.Drawing.Size(685, 23);
            this.lblImportTodayCaseList.TabIndex = 8;
            this.lblImportTodayCaseList.Text = "Input case list with comma as seperator like \"15ACC-00001,15ACC-00002\" into the b" +
    "elow box and then click \"Sync with JIRA and SF\" button.";
            // 
            // txtCaseIDList
            // 
            this.txtCaseIDList.Location = new System.Drawing.Point(13, 45);
            this.txtCaseIDList.Multiline = true;
            this.txtCaseIDList.Name = "txtCaseIDList";
            this.txtCaseIDList.Size = new System.Drawing.Size(1177, 73);
            this.txtCaseIDList.TabIndex = 2;
            // 
            // frmScanReleaseStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.grbExportTodayCaseList);
            this.Controls.Add(this.grbImportTodayCaseList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmScanReleaseStatus";
            this.ShowInTaskbar = false;
            this.Text = "Scan Release Status";
            this.grbExportTodayCaseList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.grbImportTodayCaseList.ResumeLayout(false);
            this.grbImportTodayCaseList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbExportTodayCaseList;
        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewLinkColumn SalesforceID;
        private System.Windows.Forms.DataGridViewLinkColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orgin;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignedQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn InternalType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EngStaus;
        private System.Windows.Forms.DataGridViewTextBoxColumn BZID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TargetedRelease;
        private System.Windows.Forms.DataGridViewTextBoxColumn FixVersions;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSendSummaryReport;
        private System.Windows.Forms.Button btnSyncWithJiraAndSF;
        private System.Windows.Forms.Label lblExportTodayCaseList;
        private System.Windows.Forms.GroupBox grbImportTodayCaseList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblImportTodayCaseList;
        private System.Windows.Forms.TextBox txtCaseIDList;
    }
}