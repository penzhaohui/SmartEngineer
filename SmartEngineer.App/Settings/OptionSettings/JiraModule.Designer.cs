namespace SmartEngineer.UserControls
{
    partial class JiraModule
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
            this.grbJira = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.cmbUpdateInterval = new System.Windows.Forms.ComboBox();
            this.lblUpdateInterbalUnit = new System.Windows.Forms.Label();
            this.grbJira.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbJira
            // 
            this.grbJira.Controls.Add(this.cmbUpdateInterval);
            this.grbJira.Controls.Add(this.lblUpdateInterbalUnit);
            this.grbJira.Controls.Add(this.lblUpdateInterval);
            this.grbJira.Controls.Add(this.checkBox1);
            this.grbJira.Controls.Add(this.textBox2);
            this.grbJira.Controls.Add(this.label4);
            this.grbJira.Controls.Add(this.textBox1);
            this.grbJira.Controls.Add(this.textBox3);
            this.grbJira.Controls.Add(this.label3);
            this.grbJira.Controls.Add(this.label2);
            this.grbJira.Controls.Add(this.label1);
            this.grbJira.Location = new System.Drawing.Point(0, 0);
            this.grbJira.Name = "grbJira";
            this.grbJira.Size = new System.Drawing.Size(490, 290);
            this.grbJira.TabIndex = 2;
            this.grbJira.TabStop = false;
            this.grbJira.Text = "Jira Account Setting";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enable Cache:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(108, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(108, 89);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "API Base URL:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 31);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 20);
            this.textBox2.TabIndex = 8;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(108, 125);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(19, 150);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(83, 13);
            this.lblUpdateInterval.TabIndex = 29;
            this.lblUpdateInterval.Text = "Update Interval:";
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
            this.cmbUpdateInterval.Location = new System.Drawing.Point(108, 147);
            this.cmbUpdateInterval.Name = "cmbUpdateInterval";
            this.cmbUpdateInterval.Size = new System.Drawing.Size(44, 21);
            this.cmbUpdateInterval.TabIndex = 33;
            // 
            // lblUpdateInterbalUnit
            // 
            this.lblUpdateInterbalUnit.AutoSize = true;
            this.lblUpdateInterbalUnit.Location = new System.Drawing.Point(158, 155);
            this.lblUpdateInterbalUnit.Name = "lblUpdateInterbalUnit";
            this.lblUpdateInterbalUnit.Size = new System.Drawing.Size(36, 13);
            this.lblUpdateInterbalUnit.TabIndex = 32;
            this.lblUpdateInterbalUnit.Text = "(Hour)";
            // 
            // JiraModule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grbJira);
            this.Name = "JiraModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.grbJira.ResumeLayout(false);
            this.grbJira.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbJira;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.ComboBox cmbUpdateInterval;
        private System.Windows.Forms.Label lblUpdateInterbalUnit;
    }
}
