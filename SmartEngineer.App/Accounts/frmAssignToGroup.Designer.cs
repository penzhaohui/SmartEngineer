namespace SmartEngineer.Forms
{
    partial class frmAssignToGroup
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
            this.lbxUnassignedGroups = new System.Windows.Forms.ListBox();
            this.lbxAssignedGroups = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMoveToRight = new System.Windows.Forms.Button();
            this.btnMoveToLeft = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMoveAllToRight = new System.Windows.Forms.Button();
            this.btnMoveAllToLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbxUnassignedGroups
            // 
            this.lbxUnassignedGroups.FormattingEnabled = true;
            this.lbxUnassignedGroups.Location = new System.Drawing.Point(29, 59);
            this.lbxUnassignedGroups.Name = "lbxUnassignedGroups";
            this.lbxUnassignedGroups.Size = new System.Drawing.Size(139, 238);
            this.lbxUnassignedGroups.TabIndex = 0;
            // 
            // lbxAssignedGroups
            // 
            this.lbxAssignedGroups.FormattingEnabled = true;
            this.lbxAssignedGroups.Location = new System.Drawing.Point(250, 59);
            this.lbxAssignedGroups.Name = "lbxAssignedGroups";
            this.lbxAssignedGroups.Size = new System.Drawing.Size(139, 238);
            this.lbxAssignedGroups.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(219, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnMoveToRight
            // 
            this.btnMoveToRight.Location = new System.Drawing.Point(186, 128);
            this.btnMoveToRight.Name = "btnMoveToRight";
            this.btnMoveToRight.Size = new System.Drawing.Size(48, 23);
            this.btnMoveToRight.TabIndex = 4;
            this.btnMoveToRight.Text = ">";
            this.btnMoveToRight.UseVisualStyleBackColor = true;
            this.btnMoveToRight.Click += new System.EventHandler(this.btnMoveToRight_Click);
            // 
            // btnMoveToLeft
            // 
            this.btnMoveToLeft.Location = new System.Drawing.Point(186, 174);
            this.btnMoveToLeft.Name = "btnMoveToLeft";
            this.btnMoveToLeft.Size = new System.Drawing.Size(48, 23);
            this.btnMoveToLeft.TabIndex = 5;
            this.btnMoveToLeft.Text = "<";
            this.btnMoveToLeft.UseVisualStyleBackColor = true;
            this.btnMoveToLeft.Click += new System.EventHandler(this.btnMoveToLeft_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Unassigned Groups";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Assigned Groups";
            // 
            // btnMoveAllToRight
            // 
            this.btnMoveAllToRight.Location = new System.Drawing.Point(186, 87);
            this.btnMoveAllToRight.Name = "btnMoveAllToRight";
            this.btnMoveAllToRight.Size = new System.Drawing.Size(48, 23);
            this.btnMoveAllToRight.TabIndex = 8;
            this.btnMoveAllToRight.Text = ">>";
            this.btnMoveAllToRight.UseVisualStyleBackColor = true;
            this.btnMoveAllToRight.Click += new System.EventHandler(this.btnMoveAllToRight_Click);
            // 
            // btnMoveAllToLeft
            // 
            this.btnMoveAllToLeft.Location = new System.Drawing.Point(186, 216);
            this.btnMoveAllToLeft.Name = "btnMoveAllToLeft";
            this.btnMoveAllToLeft.Size = new System.Drawing.Size(48, 23);
            this.btnMoveAllToLeft.TabIndex = 9;
            this.btnMoveAllToLeft.Text = "<<";
            this.btnMoveAllToLeft.UseVisualStyleBackColor = true;
            this.btnMoveAllToLeft.Click += new System.EventHandler(this.btnMoveAllToLeft_Click);
            // 
            // frmAssignToGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.btnMoveAllToLeft);
            this.Controls.Add(this.btnMoveAllToRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnMoveToLeft);
            this.Controls.Add(this.btnMoveToRight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbxAssignedGroups);
            this.Controls.Add(this.lbxUnassignedGroups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssignToGroup";
            this.Text = "Assign To Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxUnassignedGroups;
        private System.Windows.Forms.ListBox lbxAssignedGroups;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMoveToRight;
        private System.Windows.Forms.Button btnMoveToLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMoveAllToRight;
        private System.Windows.Forms.Button btnMoveAllToLeft;
    }
}