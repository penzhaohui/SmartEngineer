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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Memcache");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Audit Log");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Performance");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("System", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Salesforce");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Jira");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("GitHub");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("TestRail");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Synchronous", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
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
            treeNode1.Name = "Memcache";
            treeNode1.Tag = "Memcache";
            treeNode1.Text = "Memcache";
            treeNode2.Name = "AuditLog";
            treeNode2.Tag = "AuditLog";
            treeNode2.Text = "Audit Log";
            treeNode3.Name = "Performance";
            treeNode3.Tag = "Performance";
            treeNode3.Text = "Performance";
            treeNode4.Name = "System";
            treeNode4.Tag = "System";
            treeNode4.Text = "System";
            treeNode5.Name = "Salesforce";
            treeNode5.Tag = "Salesforce";
            treeNode5.Text = "Salesforce";
            treeNode6.Name = "Jira";
            treeNode6.Tag = "Jira";
            treeNode6.Text = "Jira";
            treeNode7.Name = "GitHub";
            treeNode7.Tag = "GitHub";
            treeNode7.Text = "GitHub";
            treeNode7.ToolTipText = "GitHub";
            treeNode8.Name = "TestRail";
            treeNode8.Tag = "TestRail";
            treeNode8.Text = "TestRail";
            treeNode9.Name = "Synchronous";
            treeNode9.Tag = "Synchronous";
            treeNode9.Text = "Synchronous";
            this.optionTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode9});
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