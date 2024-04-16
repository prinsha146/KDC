namespace KDC.DESKTOP
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCandidate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCandidate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCandidateVerify = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMedicalTest = new System.Windows.Forms.ToolStripMenuItem();
            this.addMedicalTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCandidate,
            this.mnuCandidateVerify,
            this.mnuMedicalTest,
            this.windowToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCandidate
            // 
            this.mnuCandidate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddCandidate});
            this.mnuCandidate.Name = "mnuCandidate";
            this.mnuCandidate.Size = new System.Drawing.Size(79, 21);
            this.mnuCandidate.Text = "Candidate";
            // 
            // mnuAddCandidate
            // 
            this.mnuAddCandidate.Name = "mnuAddCandidate";
            this.mnuAddCandidate.Size = new System.Drawing.Size(179, 22);
            this.mnuAddCandidate.Text = "Add Finger/Photo";
            this.mnuAddCandidate.Click += new System.EventHandler(this.mnuAddCandidate_Click);
            // 
            // mnuCandidateVerify
            // 
            this.mnuCandidateVerify.Name = "mnuCandidateVerify";
            this.mnuCandidateVerify.Size = new System.Drawing.Size(115, 21);
            this.mnuCandidateVerify.Text = "Candidate Verify";
            this.mnuCandidateVerify.Click += new System.EventHandler(this.mnuCandidateVerify_Click);
            // 
            // mnuMedicalTest
            // 
            this.mnuMedicalTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMedicalTestToolStripMenuItem});
            this.mnuMedicalTest.Name = "mnuMedicalTest";
            this.mnuMedicalTest.Size = new System.Drawing.Size(93, 21);
            this.mnuMedicalTest.Text = "Medical Test";
            // 
            // addMedicalTestToolStripMenuItem
            // 
            this.addMedicalTestToolStripMenuItem.Name = "addMedicalTestToolStripMenuItem";
            this.addMedicalTestToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.addMedicalTestToolStripMenuItem.Text = "Add Medical Test";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arrangeToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // arrangeToolStripMenuItem
            // 
            this.arrangeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.arrangeIconToolStripMenuItem});
            this.arrangeToolStripMenuItem.Name = "arrangeToolStripMenuItem";
            this.arrangeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.arrangeToolStripMenuItem.Text = "Arrange";
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "Cascade";
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile Vertical";
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile Horizontal";
            // 
            // arrangeIconToolStripMenuItem
            // 
            this.arrangeIconToolStripMenuItem.Name = "arrangeIconToolStripMenuItem";
            this.arrangeIconToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.arrangeIconToolStripMenuItem.Text = "Arrange Icon";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 493);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCandidateVerify;
        private System.Windows.Forms.ToolStripMenuItem mnuCandidate;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCandidate;
        private System.Windows.Forms.ToolStripMenuItem mnuMedicalTest;
        private System.Windows.Forms.ToolStripMenuItem addMedicalTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconToolStripMenuItem;
    }
}