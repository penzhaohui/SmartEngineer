namespace SmartEngineer.Forms
{
    partial class frmAssignToRole
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
            this.lbxUnassignedRoles = new System.Windows.Forms.ListBox();
            this.lbxAssignedRoles = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnMoveToRight = new System.Windows.Forms.Button();
            this.btnMoveToLeft = new System.Windows.Forms.Button();
            this.lblUnassignedRoles = new System.Windows.Forms.Label();
            this.lblAssignedRoles = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxUnassignedRoles
            // 
            this.lbxUnassignedRoles.FormattingEnabled = true;
            this.lbxUnassignedRoles.Location = new System.Drawing.Point(33, 59);
            this.lbxUnassignedRoles.Name = "lbxUnassignedRoles";
            this.lbxUnassignedRoles.Size = new System.Drawing.Size(139, 238);
            this.lbxUnassignedRoles.TabIndex = 0;
            // 
            // lbxAssignedRoles
            // 
            this.lbxAssignedRoles.FormattingEnabled = true;
            this.lbxAssignedRoles.Location = new System.Drawing.Point(254, 59);
            this.lbxAssignedRoles.Name = "lbxAssignedRoles";
            this.lbxAssignedRoles.Size = new System.Drawing.Size(139, 238);
            this.lbxAssignedRoles.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(128, 332);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 332);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnMoveToRight
            // 
            this.btnMoveToRight.Location = new System.Drawing.Point(190, 128);
            this.btnMoveToRight.Name = "btnMoveToRight";
            this.btnMoveToRight.Size = new System.Drawing.Size(48, 23);
            this.btnMoveToRight.TabIndex = 4;
            this.btnMoveToRight.Text = ">>";
            this.btnMoveToRight.UseVisualStyleBackColor = true;
            // 
            // btnMoveToLeft
            // 
            this.btnMoveToLeft.Location = new System.Drawing.Point(190, 174);
            this.btnMoveToLeft.Name = "btnMoveToLeft";
            this.btnMoveToLeft.Size = new System.Drawing.Size(48, 23);
            this.btnMoveToLeft.TabIndex = 5;
            this.btnMoveToLeft.Text = "<<";
            this.btnMoveToLeft.UseVisualStyleBackColor = true;
            // 
            // lblUnassignedRoles
            // 
            this.lblUnassignedRoles.AutoSize = true;
            this.lblUnassignedRoles.Location = new System.Drawing.Point(33, 40);
            this.lblUnassignedRoles.Name = "lblUnassignedRoles";
            this.lblUnassignedRoles.Size = new System.Drawing.Size(93, 13);
            this.lblUnassignedRoles.TabIndex = 6;
            this.lblUnassignedRoles.Text = "Unassigned Roles";
            // 
            // lblAssignedRoles
            // 
            this.lblAssignedRoles.AutoSize = true;
            this.lblAssignedRoles.Location = new System.Drawing.Point(251, 40);
            this.lblAssignedRoles.Name = "lblAssignedRoles";
            this.lblAssignedRoles.Size = new System.Drawing.Size(80, 13);
            this.lblAssignedRoles.TabIndex = 7;
            this.lblAssignedRoles.Text = "Assigned Roles";
            // 
            // frmAssignToRole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 386);
            this.Controls.Add(this.lblAssignedRoles);
            this.Controls.Add(this.lblUnassignedRoles);
            this.Controls.Add(this.btnMoveToLeft);
            this.Controls.Add(this.btnMoveToRight);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbxAssignedRoles);
            this.Controls.Add(this.lbxUnassignedRoles);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAssignToRole";
            this.Text = "Assign To Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxUnassignedRoles;
        private System.Windows.Forms.ListBox lbxAssignedRoles;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnMoveToRight;
        private System.Windows.Forms.Button btnMoveToLeft;
        private System.Windows.Forms.Label lblUnassignedRoles;
        private System.Windows.Forms.Label lblAssignedRoles;
    }
}