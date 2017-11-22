namespace SmartEngineer.UserControls
{
    partial class SubTaskTemplate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSubTaskName = new System.Windows.Forms.Label();
            this.txtSubTaskName = new System.Windows.Forms.TextBox();
            this.lblSubTaskTemplateContent = new System.Windows.Forms.Label();
            this.txtSubTaskTemplateContent = new System.Windows.Forms.TextBox();
            this.lblEnable = new System.Windows.Forms.Label();
            this.chkEnableSubTask = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbProjects = new System.Windows.Forms.ComboBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblDefaultSubTask = new System.Windows.Forms.Label();
            this.chkDefaultSubTask = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblSubTaskName
            // 
            this.lblSubTaskName.AutoSize = true;
            this.lblSubTaskName.Location = new System.Drawing.Point(16, 19);
            this.lblSubTaskName.Name = "lblSubTaskName";
            this.lblSubTaskName.Size = new System.Drawing.Size(87, 13);
            this.lblSubTaskName.TabIndex = 0;
            this.lblSubTaskName.Text = "Sub Task Name:";
            // 
            // txtSubTaskName
            // 
            this.txtSubTaskName.Location = new System.Drawing.Point(109, 16);
            this.txtSubTaskName.Name = "txtSubTaskName";
            this.txtSubTaskName.Size = new System.Drawing.Size(309, 20);
            this.txtSubTaskName.TabIndex = 1;
            // 
            // lblSubTaskTemplateContent
            // 
            this.lblSubTaskTemplateContent.AutoSize = true;
            this.lblSubTaskTemplateContent.Location = new System.Drawing.Point(16, 107);
            this.lblSubTaskTemplateContent.Name = "lblSubTaskTemplateContent";
            this.lblSubTaskTemplateContent.Size = new System.Drawing.Size(118, 13);
            this.lblSubTaskTemplateContent.TabIndex = 2;
            this.lblSubTaskTemplateContent.Text = "Task Template Content";
            // 
            // txtSubTaskTemplateContent
            // 
            this.txtSubTaskTemplateContent.Location = new System.Drawing.Point(19, 123);
            this.txtSubTaskTemplateContent.Multiline = true;
            this.txtSubTaskTemplateContent.Name = "txtSubTaskTemplateContent";
            this.txtSubTaskTemplateContent.Size = new System.Drawing.Size(881, 529);
            this.txtSubTaskTemplateContent.TabIndex = 3;
            // 
            // lblEnable
            // 
            this.lblEnable.AutoSize = true;
            this.lblEnable.Location = new System.Drawing.Point(60, 50);
            this.lblEnable.Name = "lblEnable";
            this.lblEnable.Size = new System.Drawing.Size(43, 13);
            this.lblEnable.TabIndex = 4;
            this.lblEnable.Text = "Enable:";
            // 
            // chkEnableSubTask
            // 
            this.chkEnableSubTask.AutoSize = true;
            this.chkEnableSubTask.Location = new System.Drawing.Point(109, 50);
            this.chkEnableSubTask.Name = "chkEnableSubTask";
            this.chkEnableSubTask.Size = new System.Drawing.Size(15, 14);
            this.chkEnableSubTask.TabIndex = 5;
            this.chkEnableSubTask.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(825, 40);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbProjects
            // 
            this.cmbProjects.FormattingEnabled = true;
            this.cmbProjects.Location = new System.Drawing.Point(492, 16);
            this.cmbProjects.Name = "cmbProjects";
            this.cmbProjects.Size = new System.Drawing.Size(121, 21);
            this.cmbProjects.TabIndex = 7;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(438, 21);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(48, 13);
            this.lblProject.TabIndex = 8;
            this.lblProject.Text = "Projects:";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(825, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblDefaultSubTask
            // 
            this.lblDefaultSubTask.AutoSize = true;
            this.lblDefaultSubTask.Location = new System.Drawing.Point(10, 79);
            this.lblDefaultSubTask.Name = "lblDefaultSubTask";
            this.lblDefaultSubTask.Size = new System.Drawing.Size(93, 13);
            this.lblDefaultSubTask.TabIndex = 10;
            this.lblDefaultSubTask.Text = "Default Sub Task:";
            // 
            // chkDefaultSubTask
            // 
            this.chkDefaultSubTask.AutoSize = true;
            this.chkDefaultSubTask.Location = new System.Drawing.Point(109, 79);
            this.chkDefaultSubTask.Name = "chkDefaultSubTask";
            this.chkDefaultSubTask.Size = new System.Drawing.Size(15, 14);
            this.chkDefaultSubTask.TabIndex = 11;
            this.chkDefaultSubTask.UseVisualStyleBackColor = true;
            // 
            // SubTaskTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkDefaultSubTask);
            this.Controls.Add(this.lblDefaultSubTask);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.cmbProjects);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkEnableSubTask);
            this.Controls.Add(this.lblEnable);
            this.Controls.Add(this.txtSubTaskTemplateContent);
            this.Controls.Add(this.lblSubTaskTemplateContent);
            this.Controls.Add(this.txtSubTaskName);
            this.Controls.Add(this.lblSubTaskName);
            this.Name = "SubTaskTemplate";
            this.Size = new System.Drawing.Size(914, 655);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubTaskName;
        private System.Windows.Forms.TextBox txtSubTaskName;
        private System.Windows.Forms.Label lblSubTaskTemplateContent;
        private System.Windows.Forms.TextBox txtSubTaskTemplateContent;
        private System.Windows.Forms.Label lblEnable;
        private System.Windows.Forms.CheckBox chkEnableSubTask;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbProjects;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblDefaultSubTask;
        private System.Windows.Forms.CheckBox chkDefaultSubTask;
    }
}
