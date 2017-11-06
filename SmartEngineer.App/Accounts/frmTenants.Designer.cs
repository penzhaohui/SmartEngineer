namespace SmartEngineer.Forms
{
    partial class frmTenants
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
            this.btnForbiddenTenant = new System.Windows.Forms.Button();
            this.btnActivateTenant = new System.Windows.Forms.Button();
            this.btnNewTenant = new System.Windows.Forms.Button();
            this.dgrTenantList = new System.Windows.Forms.DataGridView();
            this.Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DomainPattern = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDomainPattern = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSaveTenant = new System.Windows.Forms.Button();
            this.txtTenantID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgrTenantList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnForbiddenTenant
            // 
            this.btnForbiddenTenant.Location = new System.Drawing.Point(99, 12);
            this.btnForbiddenTenant.Name = "btnForbiddenTenant";
            this.btnForbiddenTenant.Size = new System.Drawing.Size(75, 23);
            this.btnForbiddenTenant.TabIndex = 10;
            this.btnForbiddenTenant.Text = "Forbidden";
            this.btnForbiddenTenant.UseVisualStyleBackColor = true;
            this.btnForbiddenTenant.Click += new System.EventHandler(this.btnForbiddenTenant_Click);
            // 
            // btnActivateTenant
            // 
            this.btnActivateTenant.Location = new System.Drawing.Point(12, 12);
            this.btnActivateTenant.Name = "btnActivateTenant";
            this.btnActivateTenant.Size = new System.Drawing.Size(75, 23);
            this.btnActivateTenant.TabIndex = 9;
            this.btnActivateTenant.Text = "Activate";
            this.btnActivateTenant.UseVisualStyleBackColor = true;
            this.btnActivateTenant.Click += new System.EventHandler(this.btnActivateTenant_Click);
            // 
            // btnNewTenant
            // 
            this.btnNewTenant.Location = new System.Drawing.Point(184, 12);
            this.btnNewTenant.Name = "btnNewTenant";
            this.btnNewTenant.Size = new System.Drawing.Size(75, 23);
            this.btnNewTenant.TabIndex = 7;
            this.btnNewTenant.Text = "New";
            this.btnNewTenant.UseVisualStyleBackColor = true;
            this.btnNewTenant.Click += new System.EventHandler(this.btnNewTenant_Click);
            // 
            // dgrTenantList
            // 
            this.dgrTenantList.AllowUserToAddRows = false;
            this.dgrTenantList.AllowUserToDeleteRows = false;
            this.dgrTenantList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrTenantList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Select,
            this.TenantName,
            this.Active,
            this.DomainPattern,
            this.RegisterDate});
            this.dgrTenantList.Location = new System.Drawing.Point(12, 41);
            this.dgrTenantList.Name = "dgrTenantList";
            this.dgrTenantList.ReadOnly = true;
            this.dgrTenantList.Size = new System.Drawing.Size(334, 682);
            this.dgrTenantList.TabIndex = 13;
            this.dgrTenantList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgrTenantList_CellContentClick);
            // 
            // Select
            // 
            this.Select.DataPropertyName = "TenantID";
            this.Select.HeaderText = "";
            this.Select.Name = "Select";
            this.Select.ReadOnly = true;
            this.Select.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Select.Visible = false;
            this.Select.Width = 30;
            // 
            // TenantName
            // 
            this.TenantName.DataPropertyName = "TenantName";
            this.TenantName.HeaderText = "Tenant";
            this.TenantName.Name = "TenantName";
            this.TenantName.ReadOnly = true;
            this.TenantName.Width = 70;
            // 
            // Active
            // 
            this.Active.DataPropertyName = "Active";
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.ReadOnly = true;
            this.Active.Width = 50;
            // 
            // DomainPattern
            // 
            this.DomainPattern.DataPropertyName = "DomainPattern";
            this.DomainPattern.HeaderText = "Domain Pattern";
            this.DomainPattern.Name = "DomainPattern";
            this.DomainPattern.ReadOnly = true;
            this.DomainPattern.Width = 70;
            // 
            // RegisterDate
            // 
            this.RegisterDate.DataPropertyName = "RegisterDate";
            this.RegisterDate.HeaderText = "Register Date";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTenantID);
            this.groupBox1.Controls.Add(this.txtDomainPattern);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.txtMaxUserCount);
            this.groupBox1.Controls.Add(this.lblMaxUserCount);
            this.groupBox1.Controls.Add(this.cmbTimeZone);
            this.groupBox1.Controls.Add(this.lblTimeZone);
            this.groupBox1.Controls.Add(this.chkIsActive);
            this.groupBox1.Controls.Add(this.lblIsActive);
            this.groupBox1.Controls.Add(this.lblTenantNmae);
            this.groupBox1.Controls.Add(this.txtTenantName);
            this.groupBox1.Location = new System.Drawing.Point(352, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 218);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // txtDomainPattern
            // 
            this.txtDomainPattern.Location = new System.Drawing.Point(97, 47);
            this.txtDomainPattern.Name = "txtDomainPattern";
            this.txtDomainPattern.Size = new System.Drawing.Size(135, 20);
            this.txtDomainPattern.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Domain Pattern:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(96, 152);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(516, 58);
            this.txtDescription.TabIndex = 29;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(27, 152);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(63, 13);
            this.lblDescription.TabIndex = 28;
            this.lblDescription.Text = "Description:";
            // 
            // txtMaxUserCount
            // 
            this.txtMaxUserCount.Location = new System.Drawing.Point(97, 101);
            this.txtMaxUserCount.Name = "txtMaxUserCount";
            this.txtMaxUserCount.Size = new System.Drawing.Size(55, 20);
            this.txtMaxUserCount.TabIndex = 27;
            // 
            // lblMaxUserCount
            // 
            this.lblMaxUserCount.AutoSize = true;
            this.lblMaxUserCount.Location = new System.Drawing.Point(5, 104);
            this.lblMaxUserCount.Name = "lblMaxUserCount";
            this.lblMaxUserCount.Size = new System.Drawing.Size(86, 13);
            this.lblMaxUserCount.TabIndex = 26;
            this.lblMaxUserCount.Text = "Max User Count:";
            // 
            // cmbTimeZone
            // 
            this.cmbTimeZone.FormattingEnabled = true;
            this.cmbTimeZone.Location = new System.Drawing.Point(97, 72);
            this.cmbTimeZone.Name = "cmbTimeZone";
            this.cmbTimeZone.Size = new System.Drawing.Size(300, 21);
            this.cmbTimeZone.TabIndex = 25;
            // 
            // lblTimeZone
            // 
            this.lblTimeZone.AutoSize = true;
            this.lblTimeZone.Location = new System.Drawing.Point(29, 80);
            this.lblTimeZone.Name = "lblTimeZone";
            this.lblTimeZone.Size = new System.Drawing.Size(61, 13);
            this.lblTimeZone.TabIndex = 24;
            this.lblTimeZone.Text = "Time Zone:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(96, 129);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(254, 17);
            this.chkIsActive.TabIndex = 23;
            this.chkIsActive.Text = "(WARNING: Disactive will affect many engineer)";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Location = new System.Drawing.Point(47, 131);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(40, 13);
            this.lblIsActive.TabIndex = 22;
            this.lblIsActive.Text = "Active:";
            // 
            // lblTenantNmae
            // 
            this.lblTenantNmae.AutoSize = true;
            this.lblTenantNmae.Location = new System.Drawing.Point(47, 23);
            this.lblTenantNmae.Name = "lblTenantNmae";
            this.lblTenantNmae.Size = new System.Drawing.Size(44, 13);
            this.lblTenantNmae.TabIndex = 21;
            this.lblTenantNmae.Text = "Tenant:";
            // 
            // txtTenantName
            // 
            this.txtTenantName.Location = new System.Drawing.Point(97, 20);
            this.txtTenantName.Name = "txtTenantName";
            this.txtTenantName.Size = new System.Drawing.Size(135, 20);
            this.txtTenantName.TabIndex = 20;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(352, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(850, 458);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advance Settings";
            // 
            // btnSaveTenant
            // 
            this.btnSaveTenant.Location = new System.Drawing.Point(271, 12);
            this.btnSaveTenant.Name = "btnSaveTenant";
            this.btnSaveTenant.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTenant.TabIndex = 16;
            this.btnSaveTenant.Text = "Save";
            this.btnSaveTenant.UseVisualStyleBackColor = true;
            this.btnSaveTenant.Click += new System.EventHandler(this.btnSaveTenant_Click);
            // 
            // txtTenantID
            // 
            this.txtTenantID.Location = new System.Drawing.Point(238, 20);
            this.txtTenantID.Name = "txtTenantID";
            this.txtTenantID.Size = new System.Drawing.Size(100, 20);
            this.txtTenantID.TabIndex = 32;
            this.txtTenantID.Visible = false;
            // 
            // frmTenants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.btnSaveTenant);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgrTenantList);
            this.Controls.Add(this.btnForbiddenTenant);
            this.Controls.Add(this.btnActivateTenant);
            this.Controls.Add(this.btnNewTenant);
            this.Name = "frmTenants";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tenants Management";
            ((System.ComponentModel.ISupportInitialize)(this.dgrTenantList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnForbiddenTenant;
        private System.Windows.Forms.Button btnActivateTenant;
        private System.Windows.Forms.Button btnNewTenant;
        private System.Windows.Forms.DataGridView dgrTenantList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveTenant;
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
        private System.Windows.Forms.TextBox txtDomainPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenantName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewTextBoxColumn DomainPattern;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.TextBox txtTenantID;
    }
}