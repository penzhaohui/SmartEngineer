namespace SmartEngineer.UserControls
{
    partial class TestRailModule
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
            this.grbTestRail = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // grbTestRail
            // 
            this.grbTestRail.Location = new System.Drawing.Point(0, 0);
            this.grbTestRail.Name = "grbTestRail";
            this.grbTestRail.Size = new System.Drawing.Size(490, 290);
            this.grbTestRail.TabIndex = 4;
            this.grbTestRail.TabStop = false;
            this.grbTestRail.Text = "TestRail Setting";
            // 
            // TestRailModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbTestRail);
            this.Name = "TestRailModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTestRail;
    }
}
