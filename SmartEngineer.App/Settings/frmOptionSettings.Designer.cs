namespace SmartEngineer.Forms
{
    partial class frmOptionSettings
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Performance");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Audit Log");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("System", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Salesforce");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Jira");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("GitHub");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("TestRail");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Synchronous", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.optionTree = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.optionTree);
            this.splitContainer.Size = new System.Drawing.Size(808, 488);
            this.splitContainer.SplitterDistance = 189;
            this.splitContainer.TabIndex = 0;
            // 
            // optionTree
            // 
            this.optionTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionTree.Location = new System.Drawing.Point(0, 0);
            this.optionTree.Name = "optionTree";
            treeNode1.Name = "Performance";
            treeNode1.Tag = "Performance";
            treeNode1.Text = "Performance";
            treeNode2.Name = "AuditLog";
            treeNode2.Tag = "AuditLog";
            treeNode2.Text = "Audit Log";
            treeNode3.Name = "System";
            treeNode3.Tag = "System";
            treeNode3.Text = "System";
            treeNode4.Name = "Salesforce";
            treeNode4.Tag = "Salesforce";
            treeNode4.Text = "Salesforce";
            treeNode5.Name = "Jira";
            treeNode5.Tag = "Jira";
            treeNode5.Text = "Jira";
            treeNode6.Name = "GitHub";
            treeNode6.Tag = "GitHub";
            treeNode6.Text = "GitHub";
            treeNode6.ToolTipText = "GitHub";
            treeNode7.Name = "TestRail";
            treeNode7.Tag = "TestRail";
            treeNode7.Text = "TestRail";
            treeNode8.Name = "Synchronous";
            treeNode8.Tag = "Synchronous";
            treeNode8.Text = "Synchronous";
            this.optionTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode8});
            this.optionTree.Size = new System.Drawing.Size(189, 488);
            this.optionTree.TabIndex = 0;
            this.optionTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.optionTree_AfterSelect);
            // 
            // frmOptionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 488);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOptionSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView optionTree;
    }
}