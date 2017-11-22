namespace SmartEngineer.UserControls
{
    partial class ReportEmailModule
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
            this.rtbEmailContent = new System.Windows.Forms.RichTextBox();
            this.grpEmailSetting = new System.Windows.Forms.GroupBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkUseDefaultAutoSender = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnUploadFile = new System.Windows.Forms.Button();
            this.txtSignature = new System.Windows.Forms.TextBox();
            this.lblSignature = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtBCC = new System.Windows.Forms.TextBox();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.txtTO = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblBCC = new System.Windows.Forms.Label();
            this.lblCC = new System.Windows.Forms.Label();
            this.lblTO = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.lblEmailContent = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.grpEmailSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbEmailContent
            // 
            this.rtbEmailContent.Location = new System.Drawing.Point(7, 247);
            this.rtbEmailContent.Name = "rtbEmailContent";
            this.rtbEmailContent.Size = new System.Drawing.Size(970, 477);
            this.rtbEmailContent.TabIndex = 4;
            this.rtbEmailContent.Text = "";
            // 
            // grpEmailSetting
            // 
            this.grpEmailSetting.Controls.Add(this.chkEnable);
            this.grpEmailSetting.Controls.Add(this.chkUseDefaultAutoSender);
            this.grpEmailSetting.Controls.Add(this.txtPassword);
            this.grpEmailSetting.Controls.Add(this.lblPassword);
            this.grpEmailSetting.Controls.Add(this.txtUserName);
            this.grpEmailSetting.Controls.Add(this.lblUserName);
            this.grpEmailSetting.Controls.Add(this.btnUploadFile);
            this.grpEmailSetting.Controls.Add(this.txtSignature);
            this.grpEmailSetting.Controls.Add(this.lblSignature);
            this.grpEmailSetting.Controls.Add(this.txtDisplayName);
            this.grpEmailSetting.Controls.Add(this.lblDisplayName);
            this.grpEmailSetting.Controls.Add(this.txtBCC);
            this.grpEmailSetting.Controls.Add(this.txtCC);
            this.grpEmailSetting.Controls.Add(this.txtTO);
            this.grpEmailSetting.Controls.Add(this.txtFrom);
            this.grpEmailSetting.Controls.Add(this.lblBCC);
            this.grpEmailSetting.Controls.Add(this.lblCC);
            this.grpEmailSetting.Controls.Add(this.lblTO);
            this.grpEmailSetting.Controls.Add(this.lblFrom);
            this.grpEmailSetting.Location = new System.Drawing.Point(7, 3);
            this.grpEmailSetting.Name = "grpEmailSetting";
            this.grpEmailSetting.Size = new System.Drawing.Size(639, 206);
            this.grpEmailSetting.TabIndex = 20;
            this.grpEmailSetting.TabStop = false;
            this.grpEmailSetting.Text = "Email Settings";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(474, 53);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(59, 17);
            this.chkEnable.TabIndex = 38;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkUseDefaultAutoSender
            // 
            this.chkUseDefaultAutoSender.AutoSize = true;
            this.chkUseDefaultAutoSender.Location = new System.Drawing.Point(474, 28);
            this.chkUseDefaultAutoSender.Name = "chkUseDefaultAutoSender";
            this.chkUseDefaultAutoSender.Size = new System.Drawing.Size(157, 17);
            this.chkUseDefaultAutoSender.TabIndex = 37;
            this.chkUseDefaultAutoSender.Text = "Use the default auto sender";
            this.chkUseDefaultAutoSender.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(312, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(145, 20);
            this.txtPassword.TabIndex = 36;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(250, 57);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 35;
            this.lblPassword.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(109, 54);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(133, 20);
            this.txtUserName.TabIndex = 34;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(40, 57);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 33;
            this.lblUserName.Text = "User Name:";
            // 
            // btnUploadFile
            // 
            this.btnUploadFile.Location = new System.Drawing.Point(401, 163);
            this.btnUploadFile.Name = "btnUploadFile";
            this.btnUploadFile.Size = new System.Drawing.Size(57, 23);
            this.btnUploadFile.TabIndex = 32;
            this.btnUploadFile.Text = "...";
            this.btnUploadFile.UseVisualStyleBackColor = true;
            // 
            // txtSignature
            // 
            this.txtSignature.Location = new System.Drawing.Point(109, 165);
            this.txtSignature.Name = "txtSignature";
            this.txtSignature.Size = new System.Drawing.Size(288, 20);
            this.txtSignature.TabIndex = 31;
            // 
            // lblSignature
            // 
            this.lblSignature.AutoSize = true;
            this.lblSignature.Location = new System.Drawing.Point(48, 168);
            this.lblSignature.Name = "lblSignature";
            this.lblSignature.Size = new System.Drawing.Size(55, 13);
            this.lblSignature.TabIndex = 30;
            this.lblSignature.Text = "Signature:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(109, 26);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(133, 20);
            this.txtDisplayName.TabIndex = 29;
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(28, 29);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(75, 13);
            this.lblDisplayName.TabIndex = 28;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // txtBCC
            // 
            this.txtBCC.Location = new System.Drawing.Point(109, 137);
            this.txtBCC.Name = "txtBCC";
            this.txtBCC.Size = new System.Drawing.Size(349, 20);
            this.txtBCC.TabIndex = 27;
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(109, 110);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(349, 20);
            this.txtCC.TabIndex = 26;
            // 
            // txtTO
            // 
            this.txtTO.Location = new System.Drawing.Point(109, 83);
            this.txtTO.Name = "txtTO";
            this.txtTO.Size = new System.Drawing.Size(349, 20);
            this.txtTO.TabIndex = 25;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(312, 26);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(146, 20);
            this.txtFrom.TabIndex = 24;
            // 
            // lblBCC
            // 
            this.lblBCC.AutoSize = true;
            this.lblBCC.Location = new System.Drawing.Point(72, 139);
            this.lblBCC.Name = "lblBCC";
            this.lblBCC.Size = new System.Drawing.Size(31, 13);
            this.lblBCC.TabIndex = 23;
            this.lblBCC.Text = "BCC:";
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(79, 113);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(24, 13);
            this.lblCC.TabIndex = 22;
            this.lblCC.Text = "CC:";
            // 
            // lblTO
            // 
            this.lblTO.AutoSize = true;
            this.lblTO.Location = new System.Drawing.Point(78, 86);
            this.lblTO.Name = "lblTO";
            this.lblTO.Size = new System.Drawing.Size(25, 13);
            this.lblTO.TabIndex = 21;
            this.lblTO.Text = "TO:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(273, 32);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 20;
            this.lblFrom.Text = "From:";
            // 
            // lblEmailContent
            // 
            this.lblEmailContent.AutoSize = true;
            this.lblEmailContent.Location = new System.Drawing.Point(4, 231);
            this.lblEmailContent.Name = "lblEmailContent";
            this.lblEmailContent.Size = new System.Drawing.Size(72, 13);
            this.lblEmailContent.TabIndex = 21;
            this.lblEmailContent.Text = "Email Content";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(902, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(902, 41);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 23;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // ReportEmailModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblEmailContent);
            this.Controls.Add(this.grpEmailSetting);
            this.Controls.Add(this.rtbEmailContent);
            this.Name = "ReportEmailModule";
            this.Size = new System.Drawing.Size(987, 727);
            this.grpEmailSetting.ResumeLayout(false);
            this.grpEmailSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtbEmailContent;
        private System.Windows.Forms.GroupBox grpEmailSetting;
        private System.Windows.Forms.CheckBox chkUseDefaultAutoSender;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnUploadFile;
        private System.Windows.Forms.TextBox txtSignature;
        private System.Windows.Forms.Label lblSignature;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtBCC;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.TextBox txtTO;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblBCC;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.Label lblTO;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblEmailContent;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chkEnable;
    }
}
