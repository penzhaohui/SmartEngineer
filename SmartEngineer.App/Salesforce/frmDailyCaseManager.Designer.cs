namespace SmartEngineer.Forms
{
    partial class frmDailyCaseManager
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
            this.btnSyncSalesforceToJira = new System.Windows.Forms.Button();
            this.btnGetCommentedCasesFromSalesforce = new System.Windows.Forms.Button();
            this.btnGetNewCasesFromSalesforce = new System.Windows.Forms.Button();
            this.btnSendOutCaseSummary = new System.Windows.Forms.Button();
            this.btnSendOutClosedCases = new System.Windows.Forms.Button();
            this.btnPullDetailedInfo = new System.Windows.Forms.Button();
            this.btnGetPendingCasesFromJira = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInputCaseNOs = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCaseList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serverity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastReviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraNextStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSyncSalesforceToJira
            // 
            this.btnSyncSalesforceToJira.Location = new System.Drawing.Point(119, 123);
            this.btnSyncSalesforceToJira.Name = "btnSyncSalesforceToJira";
            this.btnSyncSalesforceToJira.Size = new System.Drawing.Size(129, 23);
            this.btnSyncSalesforceToJira.TabIndex = 0;
            this.btnSyncSalesforceToJira.Text = "Sync Salesforce To Jira";
            this.btnSyncSalesforceToJira.UseVisualStyleBackColor = true;
            this.btnSyncSalesforceToJira.Click += new System.EventHandler(this.btnSyncSalesforceToJira_Click);
            // 
            // btnGetCommentedCasesFromSalesforce
            // 
            this.btnGetCommentedCasesFromSalesforce.Location = new System.Drawing.Point(1071, 45);
            this.btnGetCommentedCasesFromSalesforce.Name = "btnGetCommentedCasesFromSalesforce";
            this.btnGetCommentedCasesFromSalesforce.Size = new System.Drawing.Size(111, 23);
            this.btnGetCommentedCasesFromSalesforce.TabIndex = 2;
            this.btnGetCommentedCasesFromSalesforce.Text = "Commented Cases";
            this.btnGetCommentedCasesFromSalesforce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetCommentedCasesFromSalesforce.UseVisualStyleBackColor = true;
            this.btnGetCommentedCasesFromSalesforce.Click += new System.EventHandler(this.btnGetCommentedCasesFromSalesforce_Click);
            // 
            // btnGetNewCasesFromSalesforce
            // 
            this.btnGetNewCasesFromSalesforce.Location = new System.Drawing.Point(1071, 17);
            this.btnGetNewCasesFromSalesforce.Name = "btnGetNewCasesFromSalesforce";
            this.btnGetNewCasesFromSalesforce.Size = new System.Drawing.Size(111, 23);
            this.btnGetNewCasesFromSalesforce.TabIndex = 3;
            this.btnGetNewCasesFromSalesforce.Text = "New Cases";
            this.btnGetNewCasesFromSalesforce.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetNewCasesFromSalesforce.UseVisualStyleBackColor = true;
            this.btnGetNewCasesFromSalesforce.Click += new System.EventHandler(this.btnGetNewCasesFromSalesforce_Click);
            // 
            // btnSendOutCaseSummary
            // 
            this.btnSendOutCaseSummary.Location = new System.Drawing.Point(254, 123);
            this.btnSendOutCaseSummary.Name = "btnSendOutCaseSummary";
            this.btnSendOutCaseSummary.Size = new System.Drawing.Size(138, 23);
            this.btnSendOutCaseSummary.TabIndex = 5;
            this.btnSendOutCaseSummary.Text = "Send Out Case Summary";
            this.btnSendOutCaseSummary.UseVisualStyleBackColor = true;
            this.btnSendOutCaseSummary.Click += new System.EventHandler(this.btnSendOutCaseSummary_Click);
            // 
            // btnSendOutClosedCases
            // 
            this.btnSendOutClosedCases.Location = new System.Drawing.Point(398, 123);
            this.btnSendOutClosedCases.Name = "btnSendOutClosedCases";
            this.btnSendOutClosedCases.Size = new System.Drawing.Size(129, 23);
            this.btnSendOutClosedCases.TabIndex = 6;
            this.btnSendOutClosedCases.Text = "Send Out Closed Cases";
            this.btnSendOutClosedCases.UseVisualStyleBackColor = true;
            this.btnSendOutClosedCases.Click += new System.EventHandler(this.btnSendOutClosedCases_Click);
            // 
            // btnPullDetailedInfo
            // 
            this.btnPullDetailedInfo.Location = new System.Drawing.Point(12, 123);
            this.btnPullDetailedInfo.Name = "btnPullDetailedInfo";
            this.btnPullDetailedInfo.Size = new System.Drawing.Size(101, 23);
            this.btnPullDetailedInfo.TabIndex = 7;
            this.btnPullDetailedInfo.Text = "Pull Detailed Info";
            this.btnPullDetailedInfo.UseVisualStyleBackColor = true;
            this.btnPullDetailedInfo.Click += new System.EventHandler(this.btnPullDetailedInfo_Click);
            // 
            // btnGetPendingCasesFromJira
            // 
            this.btnGetPendingCasesFromJira.Location = new System.Drawing.Point(1071, 74);
            this.btnGetPendingCasesFromJira.Name = "btnGetPendingCasesFromJira";
            this.btnGetPendingCasesFromJira.Size = new System.Drawing.Size(111, 23);
            this.btnGetPendingCasesFromJira.TabIndex = 8;
            this.btnGetPendingCasesFromJira.Text = "Pending Cases";
            this.btnGetPendingCasesFromJira.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGetPendingCasesFromJira.UseVisualStyleBackColor = true;
            this.btnGetPendingCasesFromJira.Click += new System.EventHandler(this.btnGetPendingCasesFromJira_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInputCaseNOs);
            this.groupBox1.Controls.Add(this.btnGetNewCasesFromSalesforce);
            this.groupBox1.Controls.Add(this.btnGetPendingCasesFromJira);
            this.groupBox1.Controls.Add(this.btnGetCommentedCasesFromSalesforce);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1190, 105);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Please enter case id list with comma or click one shortcut button at left side.";
            // 
            // txtInputCaseNOs
            // 
            this.txtInputCaseNOs.Location = new System.Drawing.Point(7, 17);
            this.txtInputCaseNOs.Multiline = true;
            this.txtInputCaseNOs.Name = "txtInputCaseNOs";
            this.txtInputCaseNOs.Size = new System.Drawing.Size(1058, 80);
            this.txtInputCaseNOs.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCaseList);
            this.groupBox2.Location = new System.Drawing.Point(12, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1190, 585);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // dgvCaseList
            // 
            this.dgvCaseList.AllowUserToAddRows = false;
            this.dgvCaseList.AllowUserToDeleteRows = false;
            this.dgvCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Product,
            this.CaseNo,
            this.JiraKey,
            this.Serverity,
            this.Version,
            this.CaseType,
            this.Customer,
            this.Origin,
            this.OpenDate,
            this.Summary,
            this.LastReviewer,
            this.CommentCount,
            this.CaseOwner,
            this.CaseStatus,
            this.JiraStatus,
            this.JiraNextStatus});
            this.dgvCaseList.Location = new System.Drawing.Point(6, 19);
            this.dgvCaseList.Name = "dgvCaseList";
            this.dgvCaseList.ReadOnly = true;
            this.dgvCaseList.Size = new System.Drawing.Size(1176, 560);
            this.dgvCaseList.TabIndex = 0;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // CaseNo
            // 
            this.CaseNo.DataPropertyName = "CaseNo";
            this.CaseNo.HeaderText = "Case No";
            this.CaseNo.Name = "CaseNo";
            this.CaseNo.ReadOnly = true;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.ReadOnly = true;
            // 
            // Serverity
            // 
            this.Serverity.DataPropertyName = "Serverity";
            this.Serverity.HeaderText = "Serverity";
            this.Serverity.Name = "Serverity";
            this.Serverity.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            this.Version.ReadOnly = true;
            // 
            // CaseType
            // 
            this.CaseType.DataPropertyName = "CaseType";
            this.CaseType.HeaderText = "Case Type";
            this.CaseType.Name = "CaseType";
            this.CaseType.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // Origin
            // 
            this.Origin.DataPropertyName = "Origin";
            this.Origin.HeaderText = "Origin";
            this.Origin.Name = "Origin";
            this.Origin.ReadOnly = true;
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
            // LastReviewer
            // 
            this.LastReviewer.DataPropertyName = "LastReviewer";
            this.LastReviewer.HeaderText = "Last Reviewer";
            this.LastReviewer.Name = "LastReviewer";
            this.LastReviewer.ReadOnly = true;
            // 
            // CommentCount
            // 
            this.CommentCount.DataPropertyName = "CommentCount";
            this.CommentCount.HeaderText = "Comment Count";
            this.CommentCount.Name = "CommentCount";
            this.CommentCount.ReadOnly = true;
            // 
            // CaseOwner
            // 
            this.CaseOwner.DataPropertyName = "CaseOwner";
            this.CaseOwner.HeaderText = "Case Owner";
            this.CaseOwner.Name = "CaseOwner";
            this.CaseOwner.ReadOnly = true;
            // 
            // CaseStatus
            // 
            this.CaseStatus.DataPropertyName = "CaseStatus";
            this.CaseStatus.HeaderText = "Case Status";
            this.CaseStatus.Name = "CaseStatus";
            this.CaseStatus.ReadOnly = true;
            // 
            // JiraStatus
            // 
            this.JiraStatus.DataPropertyName = "JiraStatus";
            this.JiraStatus.HeaderText = "Jira Status";
            this.JiraStatus.Name = "JiraStatus";
            this.JiraStatus.ReadOnly = true;
            // 
            // JiraNextStatus
            // 
            this.JiraNextStatus.DataPropertyName = "JiraNextStatus";
            this.JiraNextStatus.HeaderText = "Jira Next Status";
            this.JiraNextStatus.Name = "JiraNextStatus";
            this.JiraNextStatus.ReadOnly = true;
            // 
            // frmDailyCaseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPullDetailedInfo);
            this.Controls.Add(this.btnSendOutClosedCases);
            this.Controls.Add(this.btnSendOutCaseSummary);
            this.Controls.Add(this.btnSyncSalesforceToJira);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDailyCaseManager";
            this.ShowInTaskbar = false;
            this.Text = "Daily Case Manager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSyncSalesforceToJira;
        private System.Windows.Forms.Button btnGetCommentedCasesFromSalesforce;
        private System.Windows.Forms.Button btnGetNewCasesFromSalesforce;
        private System.Windows.Forms.Button btnSendOutCaseSummary;
        private System.Windows.Forms.Button btnSendOutClosedCases;
        private System.Windows.Forms.Button btnPullDetailedInfo;
        private System.Windows.Forms.Button btnGetPendingCasesFromJira;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCaseList;
        private System.Windows.Forms.TextBox txtInputCaseNOs;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serverity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastReviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraNextStatus;
    }
}