namespace supermarket
{
    partial class frmUserdashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserdashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.purchaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbloggedinuser = new System.Windows.Forms.Label();
            this.lbluser = new System.Windows.Forms.Label();
            this.panelfooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelfooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purchaseToolStripMenuItem,
            this.salesToolStripMenuItem,
            this.inventoryToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // purchaseToolStripMenuItem
            // 
            resources.ApplyResources(this.purchaseToolStripMenuItem, "purchaseToolStripMenuItem");
            this.purchaseToolStripMenuItem.Name = "purchaseToolStripMenuItem";
            this.purchaseToolStripMenuItem.Click += new System.EventHandler(this.purchaseToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            resources.ApplyResources(this.salesToolStripMenuItem, "salesToolStripMenuItem");
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            resources.ApplyResources(this.inventoryToolStripMenuItem, "inventoryToolStripMenuItem");
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lbloggedinuser
            // 
            resources.ApplyResources(this.lbloggedinuser, "lbloggedinuser");
            this.lbloggedinuser.ForeColor = System.Drawing.Color.Green;
            this.lbloggedinuser.Name = "lbloggedinuser";
            // 
            // lbluser
            // 
            resources.ApplyResources(this.lbluser, "lbluser");
            this.lbluser.Name = "lbluser";
            // 
            // panelfooter
            // 
            resources.ApplyResources(this.panelfooter, "panelfooter");
            this.panelfooter.BackColor = System.Drawing.Color.DarkCyan;
            this.panelfooter.Controls.Add(this.label1);
            this.panelfooter.Name = "panelfooter";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // frmUserdashboard
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbloggedinuser);
            this.Controls.Add(this.lbluser);
            this.Controls.Add(this.panelfooter);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmUserdashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUserdashboard_FormClosed);
            this.Load += new System.EventHandler(this.frmUserdashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelfooter.ResumeLayout(false);
            this.panelfooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem purchaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbloggedinuser;
        private System.Windows.Forms.Label lbluser;
        private System.Windows.Forms.Panel panelfooter;
        private System.Windows.Forms.Label label1;
    }
}