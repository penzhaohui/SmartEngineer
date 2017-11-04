namespace SmartEngineer.UserControls
{
    partial class PerformanceModule
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
            this.grbPerformance = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grbPerformance
            // 
            this.grbPerformance.Location = new System.Drawing.Point(0, 0);
            this.grbPerformance.Name = "grbPerformance";
            this.grbPerformance.Size = new System.Drawing.Size(490, 290);
            this.grbPerformance.TabIndex = 3;
            this.grbPerformance.TabStop = false;
            this.grbPerformance.Text = "Performance Setting";
            // 
            // PerformanceModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbPerformance);
            this.Name = "PerformanceModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbPerformance;
    }
}
