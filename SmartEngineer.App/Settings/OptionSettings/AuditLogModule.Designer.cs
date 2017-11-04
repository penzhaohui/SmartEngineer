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
            this.SuspendLayout();
            // 
            // grbAuditLog
            // 
            this.grbAuditLog.Location = new System.Drawing.Point(0, 0);
            this.grbAuditLog.Name = "grbAuditLog";
            this.grbAuditLog.Size = new System.Drawing.Size(490, 290);
            this.grbAuditLog.TabIndex = 0;
            this.grbAuditLog.TabStop = false;
            this.grbAuditLog.Text = "Audit Log Setting";
            // 
            // AuditLogModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbAuditLog);
            this.Name = "AuditLogModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbAuditLog;
    }
}
