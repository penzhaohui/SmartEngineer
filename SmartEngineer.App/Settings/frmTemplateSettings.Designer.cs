namespace SmartEngineer.Forms
{
    partial class frmTemplateSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.templatePanel = new System.Windows.Forms.Panel();
            this.outlookBar = new SmartEngineer.OutlookBar.OutlookBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(635, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // templatePanel
            // 
            this.templatePanel.Location = new System.Drawing.Point(218, 12);
            this.templatePanel.Name = "templatePanel";
            this.templatePanel.Size = new System.Drawing.Size(984, 747);
            this.templatePanel.TabIndex = 2;
            // 
            // outlookBar
            // 
            this.outlookBar.ButtonHeight = 25;
            this.outlookBar.Location = new System.Drawing.Point(12, 12);
            this.outlookBar.Name = "outlookBar";
            this.outlookBar.SelectedBand = 0;
            this.outlookBar.Size = new System.Drawing.Size(200, 100);
            this.outlookBar.TabIndex = 0;
            // 
            // frmTemplateSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 761);
            this.ControlBox = false;
            this.Controls.Add(this.templatePanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outlookBar);
            this.Name = "frmTemplateSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OutlookBar.OutlookBar outlookBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel templatePanel;
    }
}