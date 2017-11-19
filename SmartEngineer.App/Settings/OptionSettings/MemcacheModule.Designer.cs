namespace SmartEngineer.UserControls
{
    partial class MemcacheModule
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
            this.grbMemcacheSetting = new System.Windows.Forms.GroupBox();
            this.dgvMencacheSetting = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.MemcacheName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Active = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Test = new System.Windows.Forms.DataGridViewButtonColumn();
            this.grbMemcacheSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMencacheSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // grbMemcacheSetting
            // 
            this.grbMemcacheSetting.Controls.Add(this.label1);
            this.grbMemcacheSetting.Controls.Add(this.dgvMencacheSetting);
            this.grbMemcacheSetting.Location = new System.Drawing.Point(0, 0);
            this.grbMemcacheSetting.Name = "grbMemcacheSetting";
            this.grbMemcacheSetting.Size = new System.Drawing.Size(490, 290);
            this.grbMemcacheSetting.TabIndex = 0;
            this.grbMemcacheSetting.TabStop = false;
            this.grbMemcacheSetting.Text = "Memcache Setting";
            // 
            // dgvMencacheSetting
            // 
            this.dgvMencacheSetting.AllowUserToAddRows = false;
            this.dgvMencacheSetting.AllowUserToDeleteRows = false;
            this.dgvMencacheSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMencacheSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MemcacheName,
            this.IPAddress,
            this.Port,
            this.Active,
            this.Test});
            this.dgvMencacheSetting.Location = new System.Drawing.Point(3, 16);
            this.dgvMencacheSetting.Name = "dgvMencacheSetting";
            this.dgvMencacheSetting.Size = new System.Drawing.Size(481, 235);
            this.dgvMencacheSetting.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notice: Any change will affect next time when server is restarted.";
            // 
            // MemcacheName
            // 
            this.MemcacheName.HeaderText = "Name";
            this.MemcacheName.Name = "MemcacheName";
            this.MemcacheName.Width = 150;
            // 
            // IPAddress
            // 
            this.IPAddress.HeaderText = "IPAddress";
            this.IPAddress.Name = "IPAddress";
            // 
            // Port
            // 
            this.Port.HeaderText = "Port";
            this.Port.Name = "Port";
            this.Port.Width = 50;
            // 
            // Active
            // 
            this.Active.HeaderText = "Active";
            this.Active.Name = "Active";
            this.Active.Width = 50;
            // 
            // Test
            // 
            this.Test.HeaderText = "Test";
            this.Test.Name = "Test";
            this.Test.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Test.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Test.Width = 85;
            // 
            // MemcacheModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbMemcacheSetting);
            this.Name = "MemcacheModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.grbMemcacheSetting.ResumeLayout(false);
            this.grbMemcacheSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMencacheSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbMemcacheSetting;
        private System.Windows.Forms.DataGridView dgvMencacheSetting;
        private System.Windows.Forms.DataGridViewTextBoxColumn MencacheName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemcacheName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn Active;
        private System.Windows.Forms.DataGridViewButtonColumn Test;
    }
}
