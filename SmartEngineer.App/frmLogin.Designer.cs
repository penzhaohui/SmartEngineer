namespace SmartEngineer.Forms
{
    partial class frmLogin
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
            this.gpbConnect = new System.Windows.Forms.GroupBox();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.lblAccountType = new System.Windows.Forms.Label();
            this.lnkNewUser = new System.Windows.Forms.LinkLabel();
            this.lnkTechSupport = new System.Windows.Forms.LinkLabel();
            this.lblConnectStatus = new System.Windows.Forms.Label();
            this.gpbConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbConnect
            // 
            this.gpbConnect.Controls.Add(this.chkRememberMe);
            this.gpbConnect.Controls.Add(this.btnExit);
            this.gpbConnect.Controls.Add(this.btnConnect);
            this.gpbConnect.Controls.Add(this.txtPassword);
            this.gpbConnect.Controls.Add(this.lblPassword);
            this.gpbConnect.Controls.Add(this.txtUser);
            this.gpbConnect.Controls.Add(this.lblUser);
            this.gpbConnect.Controls.Add(this.cmbAccountType);
            this.gpbConnect.Controls.Add(this.lblAccountType);
            this.gpbConnect.Location = new System.Drawing.Point(65, 40);
            this.gpbConnect.Name = "gpbConnect";
            this.gpbConnect.Size = new System.Drawing.Size(344, 164);
            this.gpbConnect.TabIndex = 0;
            this.gpbConnect.TabStop = false;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Location = new System.Drawing.Point(84, 139);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(95, 17);
            this.chkRememberMe.TabIndex = 7;
            this.chkRememberMe.Text = "Remember Me";
            this.chkRememberMe.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(239, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 34);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(239, 35);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 40);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(84, 77);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(121, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "peter.peng";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(16, 84);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(84, 39);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(121, 20);
            this.txtUser.TabIndex = 3;
            this.txtUser.Text = "peter.peng@missionsky.com";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(38, 46);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(29, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User";
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.BackColor = System.Drawing.Color.White;
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.Location = new System.Drawing.Point(84, 108);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(121, 21);
            this.cmbAccountType.TabIndex = 1;
            // 
            // lblAccountType
            // 
            this.lblAccountType.AutoSize = true;
            this.lblAccountType.Location = new System.Drawing.Point(38, 116);
            this.lblAccountType.Name = "lblAccountType";
            this.lblAccountType.Size = new System.Drawing.Size(31, 13);
            this.lblAccountType.TabIndex = 0;
            this.lblAccountType.Text = "Type";
            // 
            // lnkNewUser
            // 
            this.lnkNewUser.AutoSize = true;
            this.lnkNewUser.Location = new System.Drawing.Point(62, 226);
            this.lnkNewUser.Name = "lnkNewUser";
            this.lnkNewUser.Size = new System.Drawing.Size(54, 13);
            this.lnkNewUser.TabIndex = 8;
            this.lnkNewUser.TabStop = true;
            this.lnkNewUser.Text = "New User";
            // 
            // lnkTechSupport
            // 
            this.lnkTechSupport.AutoSize = true;
            this.lnkTechSupport.Location = new System.Drawing.Point(122, 226);
            this.lnkTechSupport.Name = "lnkTechSupport";
            this.lnkTechSupport.Size = new System.Drawing.Size(72, 13);
            this.lnkTechSupport.TabIndex = 9;
            this.lnkTechSupport.TabStop = true;
            this.lnkTechSupport.Text = "Tech Support";
            // 
            // lblConnectStatus
            // 
            this.lblConnectStatus.AutoSize = true;
            this.lblConnectStatus.Location = new System.Drawing.Point(62, 24);
            this.lblConnectStatus.Name = "lblConnectStatus";
            this.lblConnectStatus.Size = new System.Drawing.Size(0, 13);
            this.lblConnectStatus.TabIndex = 11;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 276);
            this.ControlBox = false;
            this.Controls.Add(this.lblConnectStatus);
            this.Controls.Add(this.lnkTechSupport);
            this.Controls.Add(this.lnkNewUser);
            this.Controls.Add(this.gpbConnect);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Smart Engineer 2018";
            this.gpbConnect.ResumeLayout(false);
            this.gpbConnect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbConnect;
        private System.Windows.Forms.LinkLabel lnkNewUser;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label lblAccountType;
        private System.Windows.Forms.LinkLabel lnkTechSupport;
        private System.Windows.Forms.Label lblConnectStatus;
    }
}