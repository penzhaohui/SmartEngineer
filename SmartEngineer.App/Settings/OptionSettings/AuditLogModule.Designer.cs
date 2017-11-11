namespace SmartEngineer.UserControls
{
    partial class AuditLogModule
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
            this.grbAuditLog = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.grbAuditLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbAuditLog
            // 
            this.grbAuditLog.Controls.Add(this.checkBox7);
            this.grbAuditLog.Controls.Add(this.checkBox6);
            this.grbAuditLog.Controls.Add(this.checkBox5);
            this.grbAuditLog.Controls.Add(this.checkBox4);
            this.grbAuditLog.Controls.Add(this.checkBox2);
            this.grbAuditLog.Controls.Add(this.checkBox1);
            this.grbAuditLog.Location = new System.Drawing.Point(0, 0);
            this.grbAuditLog.Name = "grbAuditLog";
            this.grbAuditLog.Size = new System.Drawing.Size(490, 290);
            this.grbAuditLog.TabIndex = 0;
            this.grbAuditLog.TabStop = false;
            this.grbAuditLog.Text = "Audit Log Setting";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(16, 30);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(220, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Enable Audit Log while interact with JIRA";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(16, 53);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(247, 17);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Text = "Enable Audit Log while interact with Salesforce";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(16, 76);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(228, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "Enable Audit Log while interact with Github";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(16, 99);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(236, 17);
            this.checkBox5.TabIndex = 4;
            this.checkBox5.Text = "Enable Audit Log while interact with TestRail";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(16, 122);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(277, 17);
            this.checkBox6.TabIndex = 5;
            this.checkBox6.Text = "Enable Audit Log while interact with JIRA Confluence";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Location = new System.Drawing.Point(16, 145);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(213, 17);
            this.checkBox7.TabIndex = 6;
            this.checkBox7.Text = "Enable Audit Log while send out reports";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // AuditLogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbAuditLog);
            this.Name = "AuditLogModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.grbAuditLog.ResumeLayout(false);
            this.grbAuditLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbAuditLog;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox7;
    }
}
