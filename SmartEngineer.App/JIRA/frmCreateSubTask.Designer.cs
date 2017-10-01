namespace SmartEngineer.Forms
{
    partial class frmCreateSubTask
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
            this.chkBypassStatusValidation = new System.Windows.Forms.CheckBox();
            this.btnSyncSubTask = new System.Windows.Forms.Button();
            this.dgvCaseList = new System.Windows.Forms.DataGridView();
            this.checkedFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssigneeQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviewAndRecreateByQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviewAndRecreateByDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResearchRootCauseByDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeFixByDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WriteTestCaseByQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExecuteTestCaseByQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WriteReleaseNotesByDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReviewReleaseNotesByQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCloseSubTask = new System.Windows.Forms.Button();
            this.btnSyncAssignee = new System.Windows.Forms.Button();
            this.btnCreateSubTask = new System.Windows.Forms.Button();
            this.gpbChooseSubTask = new System.Windows.Forms.GroupBox();
            this.chkReviewReleaseNotes = new System.Windows.Forms.CheckBox();
            this.chkWriteReleaseNotes = new System.Windows.Forms.CheckBox();
            this.chkExecuteTestCase = new System.Windows.Forms.CheckBox();
            this.chkWriteTestCase = new System.Windows.Forms.CheckBox();
            this.chkCodeFix = new System.Windows.Forms.CheckBox();
            this.chkResearchRootCause = new System.Windows.Forms.CheckBox();
            this.chkReviewAndRecreateQA = new System.Windows.Forms.CheckBox();
            this.chkReviewAndRecreateDev = new System.Windows.Forms.CheckBox();
            this.gpbEnterCaseList = new System.Windows.Forms.GroupBox();
            this.txtCaseIDList = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseList)).BeginInit();
            this.gpbChooseSubTask.SuspendLayout();
            this.gpbEnterCaseList.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkBypassStatusValidation
            // 
            this.chkBypassStatusValidation.AutoSize = true;
            this.chkBypassStatusValidation.Location = new System.Drawing.Point(1039, 171);
            this.chkBypassStatusValidation.Name = "chkBypassStatusValidation";
            this.chkBypassStatusValidation.Size = new System.Drawing.Size(142, 17);
            this.chkBypassStatusValidation.TabIndex = 26;
            this.chkBypassStatusValidation.Text = "Bypass Status Validation";
            this.chkBypassStatusValidation.UseVisualStyleBackColor = true;
            // 
            // btnSyncSubTask
            // 
            this.btnSyncSubTask.Location = new System.Drawing.Point(13, 165);
            this.btnSyncSubTask.Name = "btnSyncSubTask";
            this.btnSyncSubTask.Size = new System.Drawing.Size(123, 23);
            this.btnSyncSubTask.TabIndex = 24;
            this.btnSyncSubTask.Text = "Sync Sub Task";
            this.btnSyncSubTask.UseVisualStyleBackColor = true;
            // 
            // dgvCaseList
            // 
            this.dgvCaseList.AllowUserToAddRows = false;
            this.dgvCaseList.AllowUserToDeleteRows = false;
            this.dgvCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkedFlag,
            this.SFID,
            this.JiraKey,
            this.IssueType,
            this.Status,
            this.Assignee,
            this.AssigneeQA,
            this.ReviewAndRecreateByQA,
            this.Assignee1,
            this.Status1,
            this.ReviewAndRecreateByDev,
            this.Assignee2,
            this.Status2,
            this.ResearchRootCauseByDev,
            this.Assignee3,
            this.Status3,
            this.CodeFixByDev,
            this.Assignee4,
            this.Status4,
            this.WriteTestCaseByQA,
            this.Assignee5,
            this.Status5,
            this.ExecuteTestCaseByQA,
            this.Assignee6,
            this.Status6,
            this.WriteReleaseNotesByDev,
            this.Assignee7,
            this.Status7,
            this.ReviewReleaseNotesByQA,
            this.Assignee8,
            this.Status8});
            this.dgvCaseList.Location = new System.Drawing.Point(13, 216);
            this.dgvCaseList.Name = "dgvCaseList";
            this.dgvCaseList.Size = new System.Drawing.Size(1189, 525);
            this.dgvCaseList.TabIndex = 23;
            // 
            // checkedFlag
            // 
            this.checkedFlag.DataPropertyName = "Checked";
            this.checkedFlag.HeaderText = "";
            this.checkedFlag.Name = "checkedFlag";
            this.checkedFlag.Width = 30;
            // 
            // SFID
            // 
            this.SFID.DataPropertyName = "SFID";
            this.SFID.HeaderText = "SF ID";
            this.SFID.Name = "SFID";
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            // 
            // IssueType
            // 
            this.IssueType.DataPropertyName = "IssueType";
            this.IssueType.HeaderText = "Issue Type";
            this.IssueType.Name = "IssueType";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Assignee
            // 
            this.Assignee.DataPropertyName = "Assignee";
            this.Assignee.HeaderText = "Assignee";
            this.Assignee.Name = "Assignee";
            // 
            // AssigneeQA
            // 
            this.AssigneeQA.DataPropertyName = "AssigneeQA";
            this.AssigneeQA.HeaderText = "AssigneeQA";
            this.AssigneeQA.Name = "AssigneeQA";
            // 
            // ReviewAndRecreateByQA
            // 
            this.ReviewAndRecreateByQA.DataPropertyName = "ReviewAndRecreateByQA";
            this.ReviewAndRecreateByQA.HeaderText = "Review and Recreate(QA)";
            this.ReviewAndRecreateByQA.Name = "ReviewAndRecreateByQA";
            this.ReviewAndRecreateByQA.Width = 170;
            // 
            // Assignee1
            // 
            this.Assignee1.DataPropertyName = "Assignee1";
            this.Assignee1.HeaderText = "Assignee1";
            this.Assignee1.Name = "Assignee1";
            // 
            // Status1
            // 
            this.Status1.DataPropertyName = "Status1";
            this.Status1.HeaderText = "Status1";
            this.Status1.Name = "Status1";
            // 
            // ReviewAndRecreateByDev
            // 
            this.ReviewAndRecreateByDev.DataPropertyName = "ReviewAndRecreateByDev";
            this.ReviewAndRecreateByDev.HeaderText = "Review and Recreate(Dev)";
            this.ReviewAndRecreateByDev.Name = "ReviewAndRecreateByDev";
            this.ReviewAndRecreateByDev.Width = 170;
            // 
            // Assignee2
            // 
            this.Assignee2.DataPropertyName = "Assignee2";
            this.Assignee2.HeaderText = "Assignee2";
            this.Assignee2.Name = "Assignee2";
            // 
            // Status2
            // 
            this.Status2.DataPropertyName = "Status2";
            this.Status2.HeaderText = "Status2";
            this.Status2.Name = "Status2";
            // 
            // ResearchRootCauseByDev
            // 
            this.ResearchRootCauseByDev.DataPropertyName = "ResearchRootCauseByDev";
            this.ResearchRootCauseByDev.HeaderText = "Research Root Cause";
            this.ResearchRootCauseByDev.Name = "ResearchRootCauseByDev";
            this.ResearchRootCauseByDev.Width = 170;
            // 
            // Assignee3
            // 
            this.Assignee3.DataPropertyName = "Assignee3";
            this.Assignee3.HeaderText = "Assignee3";
            this.Assignee3.Name = "Assignee3";
            // 
            // Status3
            // 
            this.Status3.DataPropertyName = "Status3";
            this.Status3.HeaderText = "Status3";
            this.Status3.Name = "Status3";
            // 
            // CodeFixByDev
            // 
            this.CodeFixByDev.DataPropertyName = "CodeFixByDev";
            this.CodeFixByDev.HeaderText = "Code Fix(Dev)";
            this.CodeFixByDev.Name = "CodeFixByDev";
            this.CodeFixByDev.Width = 170;
            // 
            // Assignee4
            // 
            this.Assignee4.DataPropertyName = "Assignee4";
            this.Assignee4.HeaderText = "Assignee4";
            this.Assignee4.Name = "Assignee4";
            // 
            // Status4
            // 
            this.Status4.DataPropertyName = "Status4";
            this.Status4.HeaderText = "Status4";
            this.Status4.Name = "Status4";
            // 
            // WriteTestCaseByQA
            // 
            this.WriteTestCaseByQA.DataPropertyName = "WriteTestCaseByQA";
            this.WriteTestCaseByQA.HeaderText = "Write Test Case";
            this.WriteTestCaseByQA.Name = "WriteTestCaseByQA";
            this.WriteTestCaseByQA.Width = 170;
            // 
            // Assignee5
            // 
            this.Assignee5.DataPropertyName = "Assignee5";
            this.Assignee5.HeaderText = "Assignee5";
            this.Assignee5.Name = "Assignee5";
            // 
            // Status5
            // 
            this.Status5.DataPropertyName = "Status5";
            this.Status5.HeaderText = "Status5";
            this.Status5.Name = "Status5";
            // 
            // ExecuteTestCaseByQA
            // 
            this.ExecuteTestCaseByQA.DataPropertyName = "ExecuteTestCaseByQA";
            this.ExecuteTestCaseByQA.HeaderText = "Execute Test Case";
            this.ExecuteTestCaseByQA.Name = "ExecuteTestCaseByQA";
            this.ExecuteTestCaseByQA.Width = 170;
            // 
            // Assignee6
            // 
            this.Assignee6.DataPropertyName = "Assignee6";
            this.Assignee6.HeaderText = "Assignee6";
            this.Assignee6.Name = "Assignee6";
            // 
            // Status6
            // 
            this.Status6.DataPropertyName = "Status6";
            this.Status6.HeaderText = "Status6";
            this.Status6.Name = "Status6";
            // 
            // WriteReleaseNotesByDev
            // 
            this.WriteReleaseNotesByDev.DataPropertyName = "WriteReleaseNotesByDev";
            this.WriteReleaseNotesByDev.HeaderText = "Write Release Notes(Dev)";
            this.WriteReleaseNotesByDev.Name = "WriteReleaseNotesByDev";
            this.WriteReleaseNotesByDev.Width = 170;
            // 
            // Assignee7
            // 
            this.Assignee7.DataPropertyName = "Assignee7";
            this.Assignee7.HeaderText = "Assignee7";
            this.Assignee7.Name = "Assignee7";
            // 
            // Status7
            // 
            this.Status7.DataPropertyName = "Status7";
            this.Status7.HeaderText = "Status7";
            this.Status7.Name = "Status7";
            // 
            // ReviewReleaseNotesByQA
            // 
            this.ReviewReleaseNotesByQA.DataPropertyName = "ReviewReleaseNotesByQA";
            this.ReviewReleaseNotesByQA.HeaderText = "Review Release Notes(QA)";
            this.ReviewReleaseNotesByQA.Name = "ReviewReleaseNotesByQA";
            this.ReviewReleaseNotesByQA.Width = 170;
            // 
            // Assignee8
            // 
            this.Assignee8.DataPropertyName = "Assignee8";
            this.Assignee8.HeaderText = "Assignee8";
            this.Assignee8.Name = "Assignee8";
            // 
            // Status8
            // 
            this.Status8.DataPropertyName = "Status8";
            this.Status8.HeaderText = "Status8";
            this.Status8.Name = "Status8";
            // 
            // btnCloseSubTask
            // 
            this.btnCloseSubTask.Location = new System.Drawing.Point(433, 165);
            this.btnCloseSubTask.Name = "btnCloseSubTask";
            this.btnCloseSubTask.Size = new System.Drawing.Size(108, 23);
            this.btnCloseSubTask.TabIndex = 22;
            this.btnCloseSubTask.Text = "Close Sub Task";
            this.btnCloseSubTask.UseVisualStyleBackColor = true;
            // 
            // btnSyncAssignee
            // 
            this.btnSyncAssignee.Location = new System.Drawing.Point(300, 165);
            this.btnSyncAssignee.Name = "btnSyncAssignee";
            this.btnSyncAssignee.Size = new System.Drawing.Size(108, 23);
            this.btnSyncAssignee.TabIndex = 21;
            this.btnSyncAssignee.Text = "Sync Assignee";
            this.btnSyncAssignee.UseVisualStyleBackColor = true;
            // 
            // btnCreateSubTask
            // 
            this.btnCreateSubTask.Location = new System.Drawing.Point(155, 165);
            this.btnCreateSubTask.Name = "btnCreateSubTask";
            this.btnCreateSubTask.Size = new System.Drawing.Size(123, 23);
            this.btnCreateSubTask.TabIndex = 20;
            this.btnCreateSubTask.Text = "Create Sub Task";
            this.btnCreateSubTask.UseVisualStyleBackColor = true;
            // 
            // gpbChooseSubTask
            // 
            this.gpbChooseSubTask.Controls.Add(this.chkReviewReleaseNotes);
            this.gpbChooseSubTask.Controls.Add(this.chkWriteReleaseNotes);
            this.gpbChooseSubTask.Controls.Add(this.chkExecuteTestCase);
            this.gpbChooseSubTask.Controls.Add(this.chkWriteTestCase);
            this.gpbChooseSubTask.Controls.Add(this.chkCodeFix);
            this.gpbChooseSubTask.Controls.Add(this.chkResearchRootCause);
            this.gpbChooseSubTask.Controls.Add(this.chkReviewAndRecreateQA);
            this.gpbChooseSubTask.Controls.Add(this.chkReviewAndRecreateDev);
            this.gpbChooseSubTask.Location = new System.Drawing.Point(833, 20);
            this.gpbChooseSubTask.Name = "gpbChooseSubTask";
            this.gpbChooseSubTask.Size = new System.Drawing.Size(369, 130);
            this.gpbChooseSubTask.TabIndex = 19;
            this.gpbChooseSubTask.TabStop = false;
            this.gpbChooseSubTask.Text = "Step 2, Choose Sub Task Template";
            // 
            // chkReviewReleaseNotes
            // 
            this.chkReviewReleaseNotes.AutoSize = true;
            this.chkReviewReleaseNotes.Location = new System.Drawing.Point(206, 98);
            this.chkReviewReleaseNotes.Name = "chkReviewReleaseNotes";
            this.chkReviewReleaseNotes.Size = new System.Drawing.Size(156, 17);
            this.chkReviewReleaseNotes.TabIndex = 16;
            this.chkReviewReleaseNotes.Text = "Review Release Notes(QA)";
            this.chkReviewReleaseNotes.UseVisualStyleBackColor = true;
            // 
            // chkWriteReleaseNotes
            // 
            this.chkWriteReleaseNotes.AutoSize = true;
            this.chkWriteReleaseNotes.Location = new System.Drawing.Point(25, 101);
            this.chkWriteReleaseNotes.Name = "chkWriteReleaseNotes";
            this.chkWriteReleaseNotes.Size = new System.Drawing.Size(150, 17);
            this.chkWriteReleaseNotes.TabIndex = 15;
            this.chkWriteReleaseNotes.Text = "Write Release Notes(Dev)";
            this.chkWriteReleaseNotes.UseVisualStyleBackColor = true;
            // 
            // chkExecuteTestCase
            // 
            this.chkExecuteTestCase.AutoSize = true;
            this.chkExecuteTestCase.Location = new System.Drawing.Point(206, 75);
            this.chkExecuteTestCase.Name = "chkExecuteTestCase";
            this.chkExecuteTestCase.Size = new System.Drawing.Size(137, 17);
            this.chkExecuteTestCase.TabIndex = 14;
            this.chkExecuteTestCase.Text = "Execute Test Case(QA)";
            this.chkExecuteTestCase.UseVisualStyleBackColor = true;
            // 
            // chkWriteTestCase
            // 
            this.chkWriteTestCase.AutoSize = true;
            this.chkWriteTestCase.Location = new System.Drawing.Point(206, 49);
            this.chkWriteTestCase.Name = "chkWriteTestCase";
            this.chkWriteTestCase.Size = new System.Drawing.Size(123, 17);
            this.chkWriteTestCase.TabIndex = 13;
            this.chkWriteTestCase.Text = "Write Test Case(QA)";
            this.chkWriteTestCase.UseVisualStyleBackColor = true;
            // 
            // chkCodeFix
            // 
            this.chkCodeFix.AutoSize = true;
            this.chkCodeFix.Location = new System.Drawing.Point(206, 26);
            this.chkCodeFix.Name = "chkCodeFix";
            this.chkCodeFix.Size = new System.Drawing.Size(93, 17);
            this.chkCodeFix.TabIndex = 12;
            this.chkCodeFix.Text = "Code Fix(Dev)";
            this.chkCodeFix.UseVisualStyleBackColor = true;
            // 
            // chkResearchRootCause
            // 
            this.chkResearchRootCause.AutoSize = true;
            this.chkResearchRootCause.Location = new System.Drawing.Point(26, 78);
            this.chkResearchRootCause.Name = "chkResearchRootCause";
            this.chkResearchRootCause.Size = new System.Drawing.Size(131, 17);
            this.chkResearchRootCause.TabIndex = 11;
            this.chkResearchRootCause.Text = "Research Root Cause";
            this.chkResearchRootCause.UseVisualStyleBackColor = true;
            // 
            // chkReviewAndRecreateQA
            // 
            this.chkReviewAndRecreateQA.AutoSize = true;
            this.chkReviewAndRecreateQA.Location = new System.Drawing.Point(26, 26);
            this.chkReviewAndRecreateQA.Name = "chkReviewAndRecreateQA";
            this.chkReviewAndRecreateQA.Size = new System.Drawing.Size(151, 17);
            this.chkReviewAndRecreateQA.TabIndex = 8;
            this.chkReviewAndRecreateQA.Tag = "\"Notice: Just log QA effort for review and recreate the assicaited production cas" +
    "e\"";
            this.chkReviewAndRecreateQA.Text = "Review and Recreate(QA)";
            this.chkReviewAndRecreateQA.UseVisualStyleBackColor = true;
            // 
            // chkReviewAndRecreateDev
            // 
            this.chkReviewAndRecreateDev.AutoSize = true;
            this.chkReviewAndRecreateDev.Location = new System.Drawing.Point(26, 52);
            this.chkReviewAndRecreateDev.Name = "chkReviewAndRecreateDev";
            this.chkReviewAndRecreateDev.Size = new System.Drawing.Size(156, 17);
            this.chkReviewAndRecreateDev.TabIndex = 9;
            this.chkReviewAndRecreateDev.Text = "Review and Recreate(Dev)";
            this.chkReviewAndRecreateDev.UseVisualStyleBackColor = true;
            // 
            // gpbEnterCaseList
            // 
            this.gpbEnterCaseList.Controls.Add(this.txtCaseIDList);
            this.gpbEnterCaseList.Location = new System.Drawing.Point(7, 19);
            this.gpbEnterCaseList.Name = "gpbEnterCaseList";
            this.gpbEnterCaseList.Size = new System.Drawing.Size(736, 131);
            this.gpbEnterCaseList.TabIndex = 18;
            this.gpbEnterCaseList.TabStop = false;
            this.gpbEnterCaseList.Text = "Step 1, Enter Case List(<50)";
            // 
            // txtCaseIDList
            // 
            this.txtCaseIDList.Location = new System.Drawing.Point(6, 22);
            this.txtCaseIDList.Multiline = true;
            this.txtCaseIDList.Name = "txtCaseIDList";
            this.txtCaseIDList.Size = new System.Drawing.Size(718, 91);
            this.txtCaseIDList.TabIndex = 1;
            // 
            // frmCreateSubTask
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.chkBypassStatusValidation);
            this.Controls.Add(this.btnSyncSubTask);
            this.Controls.Add(this.dgvCaseList);
            this.Controls.Add(this.btnCloseSubTask);
            this.Controls.Add(this.btnSyncAssignee);
            this.Controls.Add(this.btnCreateSubTask);
            this.Controls.Add(this.gpbChooseSubTask);
            this.Controls.Add(this.gpbEnterCaseList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateSubTask";
            this.ShowInTaskbar = false;
            this.Text = "Create Sub Task";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaseList)).EndInit();
            this.gpbChooseSubTask.ResumeLayout(false);
            this.gpbChooseSubTask.PerformLayout();
            this.gpbEnterCaseList.ResumeLayout(false);
            this.gpbEnterCaseList.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkBypassStatusValidation;
        private System.Windows.Forms.Button btnSyncSubTask;
        private System.Windows.Forms.DataGridView dgvCaseList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkedFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssigneeQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewAndRecreateByQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewAndRecreateByDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResearchRootCauseByDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status3;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeFixByDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status4;
        private System.Windows.Forms.DataGridViewTextBoxColumn WriteTestCaseByQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExecuteTestCaseByQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status6;
        private System.Windows.Forms.DataGridViewTextBoxColumn WriteReleaseNotesByDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReviewReleaseNotesByQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status8;
        private System.Windows.Forms.Button btnCloseSubTask;
        private System.Windows.Forms.Button btnSyncAssignee;
        private System.Windows.Forms.Button btnCreateSubTask;
        private System.Windows.Forms.GroupBox gpbChooseSubTask;
        private System.Windows.Forms.CheckBox chkReviewReleaseNotes;
        private System.Windows.Forms.CheckBox chkWriteReleaseNotes;
        private System.Windows.Forms.CheckBox chkExecuteTestCase;
        private System.Windows.Forms.CheckBox chkWriteTestCase;
        private System.Windows.Forms.CheckBox chkCodeFix;
        private System.Windows.Forms.CheckBox chkResearchRootCause;
        private System.Windows.Forms.CheckBox chkReviewAndRecreateQA;
        private System.Windows.Forms.CheckBox chkReviewAndRecreateDev;
        private System.Windows.Forms.GroupBox gpbEnterCaseList;
        private System.Windows.Forms.TextBox txtCaseIDList;
    }
}