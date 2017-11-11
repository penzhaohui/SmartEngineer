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
            this.cmbUpdateInterval = new System.Windows.Forms.ComboBox();
            this.lblUpdateInterbalUnit = new System.Windows.Forms.Label();
            this.lblUpdateInterval = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grbTestRail.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbTestRail
            // 
            this.grbTestRail.Controls.Add(this.textBox2);
            this.grbTestRail.Controls.Add(this.label4);
            this.grbTestRail.Location = new System.Drawing.Point(0, 0);
            this.grbTestRail.Name = "grbTestRail";
            this.grbTestRail.Size = new System.Drawing.Size(490, 290);
            this.grbTestRail.TabIndex = 4;
            this.grbTestRail.TabStop = false;
            this.grbTestRail.Text = "TestRail Setting";
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
            this.cmbUpdateInterval.Location = new System.Drawing.Point(115, 155);
            this.cmbUpdateInterval.Name = "cmbUpdateInterval";
            this.cmbUpdateInterval.Size = new System.Drawing.Size(44, 21);
            this.cmbUpdateInterval.TabIndex = 43;
            // 
            // lblUpdateInterbalUnit
            // 
            this.lblUpdateInterbalUnit.AutoSize = true;
            this.lblUpdateInterbalUnit.Location = new System.Drawing.Point(165, 163);
            this.lblUpdateInterbalUnit.Name = "lblUpdateInterbalUnit";
            this.lblUpdateInterbalUnit.Size = new System.Drawing.Size(36, 13);
            this.lblUpdateInterbalUnit.TabIndex = 42;
            this.lblUpdateInterbalUnit.Text = "(Hour)";
            // 
            // lblUpdateInterval
            // 
            this.lblUpdateInterval.AutoSize = true;
            this.lblUpdateInterval.Location = new System.Drawing.Point(26, 158);
            this.lblUpdateInterval.Name = "lblUpdateInterval";
            this.lblUpdateInterval.Size = new System.Drawing.Size(83, 13);
            this.lblUpdateInterval.TabIndex = 41;
            this.lblUpdateInterval.Text = "Update Interval:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(115, 133);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 40;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(115, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 38;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(115, 66);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Enable Cache:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Account:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(116, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(314, 20);
            this.textBox2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "API Base URL:";
            // 
            // TestRailModule
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
            this.Controls.Add(this.grbTestRail);
            this.Name = "TestRailModule";
            this.Size = new System.Drawing.Size(500, 300);
            this.grbTestRail.ResumeLayout(false);
            this.grbTestRail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTestRail;
        private System.Windows.Forms.ComboBox cmbUpdateInterval;
        private System.Windows.Forms.Label lblUpdateInterbalUnit;
        private System.Windows.Forms.Label lblUpdateInterval;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
    }
}
