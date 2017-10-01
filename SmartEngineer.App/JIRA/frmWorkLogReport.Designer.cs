namespace SmartEngineer.Forms
{
    partial class frmWorkLogReport
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
            this.dgvWorkLogReport = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Effort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbFunctionArea = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkLogReport)).BeginInit();
            this.gpbFunctionArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvWorkLogReport
            // 
            this.dgvWorkLogReport.AllowUserToAddRows = false;
            this.dgvWorkLogReport.AllowUserToDeleteRows = false;
            this.dgvWorkLogReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkLogReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Assignee,
            this.Effort,
            this.SubTaskID,
            this.SubTaskSummary,
            this.SubTaskAssignee,
            this.SubTaskComment,
            this.JiraKey,
            this.JiraSummary});
            this.dgvWorkLogReport.Location = new System.Drawing.Point(5, 126);
            this.dgvWorkLogReport.Name = "dgvWorkLogReport";
            this.dgvWorkLogReport.ReadOnly = true;
            this.dgvWorkLogReport.Size = new System.Drawing.Size(1197, 605);
            this.dgvWorkLogReport.TabIndex = 3;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 150;
            // 
            // Assignee
            // 
            this.Assignee.DataPropertyName = "Name";
            this.Assignee.HeaderText = "Name";
            this.Assignee.Name = "Assignee";
            this.Assignee.ReadOnly = true;
            // 
            // Effort
            // 
            this.Effort.DataPropertyName = "Effort";
            this.Effort.HeaderText = "Effort";
            this.Effort.Name = "Effort";
            this.Effort.ReadOnly = true;
            // 
            // SubTaskID
            // 
            this.SubTaskID.DataPropertyName = "SubTaskID";
            this.SubTaskID.HeaderText = "Sub Task[ID]";
            this.SubTaskID.Name = "SubTaskID";
            this.SubTaskID.ReadOnly = true;
            // 
            // SubTaskSummary
            // 
            this.SubTaskSummary.DataPropertyName = "SubTaskSummary";
            this.SubTaskSummary.HeaderText = "Sub Task[Summary]";
            this.SubTaskSummary.Name = "SubTaskSummary";
            this.SubTaskSummary.ReadOnly = true;
            this.SubTaskSummary.Width = 200;
            // 
            // SubTaskAssignee
            // 
            this.SubTaskAssignee.DataPropertyName = "SubTaskAssignee";
            this.SubTaskAssignee.HeaderText = "Sub Task[Assignee]";
            this.SubTaskAssignee.Name = "SubTaskAssignee";
            this.SubTaskAssignee.ReadOnly = true;
            this.SubTaskAssignee.Width = 150;
            // 
            // SubTaskComment
            // 
            this.SubTaskComment.DataPropertyName = "SubTaskComment";
            this.SubTaskComment.HeaderText = "Sub Task[Comment]";
            this.SubTaskComment.Name = "SubTaskComment";
            this.SubTaskComment.ReadOnly = true;
            this.SubTaskComment.Width = 250;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.FillWeight = 150F;
            this.JiraKey.HeaderText = "Associated Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.ReadOnly = true;
            this.JiraKey.Width = 150;
            // 
            // JiraSummary
            // 
            this.JiraSummary.DataPropertyName = "JiraSummary";
            this.JiraSummary.HeaderText = "Associated Jira Summary";
            this.JiraSummary.Name = "JiraSummary";
            this.JiraSummary.ReadOnly = true;
            this.JiraSummary.Width = 200;
            // 
            // gpbFunctionArea
            // 
            this.gpbFunctionArea.Controls.Add(this.label1);
            this.gpbFunctionArea.Controls.Add(this.btnSend);
            this.gpbFunctionArea.Controls.Add(this.btnAssign);
            this.gpbFunctionArea.Controls.Add(this.dtpTo);
            this.gpbFunctionArea.Controls.Add(this.dtpFrom);
            this.gpbFunctionArea.Controls.Add(this.btnSync);
            this.gpbFunctionArea.Controls.Add(this.lblTo);
            this.gpbFunctionArea.Controls.Add(this.lblFrom);
            this.gpbFunctionArea.Location = new System.Drawing.Point(5, 12);
            this.gpbFunctionArea.Name = "gpbFunctionArea";
            this.gpbFunctionArea.Size = new System.Drawing.Size(1197, 101);
            this.gpbFunctionArea.TabIndex = 2;
            this.gpbFunctionArea.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(413, 15);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 79);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send Out Report";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(297, 16);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(110, 76);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Reassign Assignee";
            this.btnAssign.UseVisualStyleBackColor = true;
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(69, 45);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(106, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(69, 19);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(106, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(40, 52);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(30, 25);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(181, 16);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(110, 76);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Query Work Log";
            this.btnSync.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(74, 83);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(106, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Assignee:";
            // 
            // frmWorkLogReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dgvWorkLogReport);
            this.Controls.Add(this.gpbFunctionArea);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWorkLogReport";
            this.ShowInTaskbar = false;
            this.Text = "Work Log Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkLogReport)).EndInit();
            this.gpbFunctionArea.ResumeLayout(false);
            this.gpbFunctionArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWorkLogReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Effort;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskAssignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraSummary;
        private System.Windows.Forms.GroupBox gpbFunctionArea;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}