namespace SmartEngineer.Forms
{
    partial class frmTenantNew
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtMaxUserCount = new System.Windows.Forms.TextBox();
            this.lblMaxUserCount = new System.Windows.Forms.Label();
            this.cmbTimeZone = new System.Windows.Forms.ComboBox();
            this.lblTimeZone = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.lblTenantNmae = new System.Windows.Forms.Label();
            this.txtTenantName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDomainPattern = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 144);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(516, 58);
            this.txtDescription.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(26, 144);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "Description:";
            // 
            // txtMaxUserCount
            // 
            this.txtMaxUserCount.Location = new System.Drawing.Point(96, 91);
            this.txtMaxUserCount.Name = "txtMaxUserCount";
            this.txtMaxUserCount.Size = new System.Drawing.Size(55, 20);
            this.txtMaxUserCount.TabIndex = 17;
            // 
            // lblMaxUserCount
            // 
            this.lblMaxUserCount.AutoSize = true;
            this.lblMaxUserCount.Location = new System.Drawing.Point(3, 94);
            this.lblMaxUserCount.Name = "lblMaxUserCount";
            this.lblMaxUserCount.Size = new System.Drawing.Size(86, 13);
            this.lblMaxUserCount.TabIndex = 16;
            this.lblMaxUserCount.Text = "Max User Count:";
            // 
            // cmbTimeZone
            // 
            this.cmbTimeZone.FormattingEnabled = true;
            this.cmbTimeZone.Location = new System.Drawing.Point(95, 63);
            this.cmbTimeZone.Name = "cmbTimeZone";
            this.cmbTimeZone.Size = new System.Drawing.Size(300, 21);
            this.cmbTimeZone.TabIndex = 15;
            // 
            // lblTimeZone
            // 
            this.lblTimeZone.AutoSize = true;
            this.lblTimeZone.Location = new System.Drawing.Point(28, 71);
            this.lblTimeZone.Name = "lblTimeZone";
            this.lblTimeZone.Size = new System.Drawing.Size(61, 13);
            this.lblTimeZone.TabIndex = 14;
            this.lblTimeZone.Text = "Time Zone:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(95, 118);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(254, 17);
            this.chkIsActive.TabIndex = 13;
            this.chkIsActive.Text = "(WARNING: Disactive will affect many engineer)";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(49, 119);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(40, 13);
            this.lblIsActive.TabIndex = 12;
            this.lblIsActive.Text = "Active:";
            // 
            // lblTenantNmae
            // 
            this.lblTenantNmae.AutoSize = true;
            this.lblTenantNmae.Location = new System.Drawing.Point(45, 13);
            this.lblTenantNmae.Name = "lblTenantNmae";
            this.lblTenantNmae.Size = new System.Drawing.Size(44, 13);
            this.lblTenantNmae.TabIndex = 11;
            this.lblTenantNmae.Text = "Tenant:";
            // 
            // txtTenantName
            // 
            this.txtTenantName.Location = new System.Drawing.Point(95, 10);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.Size = new System.Drawing.Size(135, 20);
            this.txtTenantName.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(488, 219);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(391, 219);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Domain Pattern:";
            // 
            // txtDomainPattern
            // 
            this.txtDomainPattern.Location = new System.Drawing.Point(95, 36);
            this.txtDomainPattern.Name = "txtDomainPattern";
            this.txtDomainPattern.Size = new System.Drawing.Size(135, 20);
            this.txtDomainPattern.TabIndex = 23;
            // 
            // frmTenantNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 261);
            this.ControlBox = false;
            this.Controls.Add(this.txtDomainPattern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtMaxUserCount);
            this.Controls.Add(this.lblMaxUserCount);
            this.Controls.Add(this.cmbTimeZone);
            this.Controls.Add(this.lblTimeZone);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.lblIsActive);
            this.Controls.Add(this.lblTenantNmae);
            this.Controls.Add(this.txtTenantName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTenantNew";
            this.Text = "New Tenant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtMaxUserCount;
        private System.Windows.Forms.Label lblMaxUserCount;
        private System.Windows.Forms.ComboBox cmbTimeZone;
        private System.Windows.Forms.Label lblTimeZone;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label lblTenantNmae;
        private System.Windows.Forms.TextBox txtTenantName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDomainPattern;
    }
}