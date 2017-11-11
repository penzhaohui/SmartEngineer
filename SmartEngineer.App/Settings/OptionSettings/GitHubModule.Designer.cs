namespace SmartEngineer.UserControls
{
    partial class GitHubModule
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
            this.grbGitHub = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cmbUpdateInterval = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.lblUpdateInterbalUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grbGitHub
            // 
            this.grbGitHub.Location = new System.Drawing.Point(0, 0);
            this.grbGitHub.Name = "grbGitHub";
            this.grbGitHub.Size = new System.Drawing.Size(490, 290);
            this.grbGitHub.TabIndex = 1;
            this.grbGitHub.TabStop = false;
            this.grbGitHub.Text = "GitHub Account Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Enable Cache:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(96, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 37;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 38;
            // 
            // cmbUpdateInterval
            // 
            this.cmbUpdateInterval.FormattingEnabled = true;
            this.cmbUpdateInterval.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24"});
            this.cmbUpdateInterval.Location = new System.Drawing.Point(96, 119);
            this.cmbUpdateInterval.Name = "cmbUpdateInterval";
            this.cmbUpdateInterval.Size = new System.Drawing.Size(44, 21);
            this.cmbUpdateInterval.TabIndex = 43;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(96, 97);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(7, 122);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(83, 13);
            this.lblUpdateInterval.TabIndex = 41;
            this.lblUpdateInterval.Text = "Update Interval:";
            // 
            // lblUpdateInterbalUnit
            // 
            this.lblUpdateInterbalUnit.AutoSize = true;
            this.lblUpdateInterbalUnit.Location = new System.Drawing.Point(146, 127);
            this.lblUpdateInterbalUnit.Name = "lblUpdateInterbalUnit";
            this.lblUpdateInterbalUnit.Size = new System.Drawing.Size(36, 13);
            this.lblUpdateInterbalUnit.TabIndex = 42;
            this.lblUpdateInterbalUnit.Text = "(Hour)";
            // 
            // GitHubModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbUpdateInterval);
            this.Controls.Add(this.lblUpdateInterbalUnit);
            this.Controls.Add(this.lblUpdateInterval);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbGitHub);
            this.Name = "GitHubModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGitHub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox cmbUpdateInterval;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.Label lblUpdateInterbalUnit;
    }
}
