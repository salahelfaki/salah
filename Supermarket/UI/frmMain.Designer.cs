
namespace Supermarket.UI
{
    partial class frmMain
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
            this.panelmenu = new System.Windows.Forms.Panel();
            this.panellogo = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lbllogo = new System.Windows.Forms.Label();
            this.btncategories = new System.Windows.Forms.Button();
            this.btnproducts = new System.Windows.Forms.Button();
            this.btnsales = new System.Windows.Forms.Button();
            this.btnpurchase = new System.Windows.Forms.Button();
            this.btndeacust = new System.Windows.Forms.Button();
            this.btnusers = new System.Windows.Forms.Button();
            this.btnsettings = new System.Windows.Forms.Button();
            this.panelDesktoppanel = new System.Windows.Forms.Panel();
            this.panelmenu.SuspendLayout();
            this.panellogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.SlateBlue;
            this.panelmenu.Controls.Add(this.btnsettings);
            this.panelmenu.Controls.Add(this.btnusers);
            this.panelmenu.Controls.Add(this.btndeacust);
            this.panelmenu.Controls.Add(this.btnpurchase);
            this.panelmenu.Controls.Add(this.btnsales);
            this.panelmenu.Controls.Add(this.btnproducts);
            this.panelmenu.Controls.Add(this.btncategories);
            this.panelmenu.Controls.Add(this.panellogo);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(220, 583);
            this.panelmenu.TabIndex = 0;
            // 
            // panellogo
            // 
            this.panellogo.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panellogo.Controls.Add(this.lbllogo);
            this.panellogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panellogo.Location = new System.Drawing.Point(0, 0);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(220, 80);
            this.panellogo.TabIndex = 0;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(769, 80);
            this.panelTitleBar.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.Location = new System.Drawing.Point(306, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(99, 31);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "HOME";
            // 
            // lbllogo
            // 
            this.lbllogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbllogo.AutoSize = true;
            this.lbllogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.lbllogo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbllogo.Location = new System.Drawing.Point(28, 23);
            this.lbllogo.Name = "lbllogo";
            this.lbllogo.Size = new System.Drawing.Size(142, 31);
            this.lbllogo.TabIndex = 2;
            this.lbllogo.Text = "RoiyaSoft";
            // 
            // btncategories
            // 
            this.btncategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncategories.FlatAppearance.BorderSize = 0;
            this.btncategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btncategories.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncategories.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategories.Location = new System.Drawing.Point(0, 80);
            this.btncategories.Name = "btncategories";
            this.btncategories.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btncategories.Size = new System.Drawing.Size(220, 70);
            this.btncategories.TabIndex = 1;
            this.btncategories.Text = "Categories";
            this.btncategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategories.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncategories.UseVisualStyleBackColor = true;
            this.btncategories.Click += new System.EventHandler(this.btncategories_Click);
            // 
            // btnproducts
            // 
            this.btnproducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnproducts.FlatAppearance.BorderSize = 0;
            this.btnproducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnproducts.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnproducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducts.Location = new System.Drawing.Point(0, 150);
            this.btnproducts.Name = "btnproducts";
            this.btnproducts.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnproducts.Size = new System.Drawing.Size(220, 70);
            this.btnproducts.TabIndex = 2;
            this.btnproducts.Text = "Products";
            this.btnproducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproducts.UseVisualStyleBackColor = true;
            this.btnproducts.Click += new System.EventHandler(this.btnproducts_Click);
            // 
            // btnsales
            // 
            this.btnsales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsales.FlatAppearance.BorderSize = 0;
            this.btnsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsales.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnsales.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsales.Location = new System.Drawing.Point(0, 220);
            this.btnsales.Name = "btnsales";
            this.btnsales.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnsales.Size = new System.Drawing.Size(220, 70);
            this.btnsales.TabIndex = 3;
            this.btnsales.Text = "Orders";
            this.btnsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsales.UseVisualStyleBackColor = true;
            this.btnsales.Click += new System.EventHandler(this.btnsales_Click);
            // 
            // btnpurchase
            // 
            this.btnpurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnpurchase.FlatAppearance.BorderSize = 0;
            this.btnpurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpurchase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnpurchase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnpurchase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpurchase.Location = new System.Drawing.Point(0, 290);
            this.btnpurchase.Name = "btnpurchase";
            this.btnpurchase.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnpurchase.Size = new System.Drawing.Size(220, 70);
            this.btnpurchase.TabIndex = 4;
            this.btnpurchase.Text = "Purchase";
            this.btnpurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnpurchase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnpurchase.UseVisualStyleBackColor = true;
            this.btnpurchase.Click += new System.EventHandler(this.btnpurchase_Click);
            // 
            // btndeacust
            // 
            this.btndeacust.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndeacust.FlatAppearance.BorderSize = 0;
            this.btndeacust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeacust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btndeacust.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndeacust.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeacust.Location = new System.Drawing.Point(0, 360);
            this.btndeacust.Name = "btndeacust";
            this.btndeacust.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btndeacust.Size = new System.Drawing.Size(220, 70);
            this.btndeacust.TabIndex = 5;
            this.btndeacust.Text = "Dealers/Customer";
            this.btndeacust.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndeacust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndeacust.UseVisualStyleBackColor = true;
            this.btndeacust.Click += new System.EventHandler(this.btndeacust_Click);
            // 
            // btnusers
            // 
            this.btnusers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnusers.FlatAppearance.BorderSize = 0;
            this.btnusers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnusers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnusers.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnusers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnusers.Location = new System.Drawing.Point(0, 430);
            this.btnusers.Name = "btnusers";
            this.btnusers.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnusers.Size = new System.Drawing.Size(220, 70);
            this.btnusers.TabIndex = 6;
            this.btnusers.Text = "Users";
            this.btnusers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnusers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnusers.UseVisualStyleBackColor = true;
            this.btnusers.Click += new System.EventHandler(this.btnusers_Click);
            // 
            // btnsettings
            // 
            this.btnsettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsettings.FlatAppearance.BorderSize = 0;
            this.btnsettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btnsettings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsettings.Location = new System.Drawing.Point(0, 500);
            this.btnsettings.Name = "btnsettings";
            this.btnsettings.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.btnsettings.Size = new System.Drawing.Size(220, 70);
            this.btnsettings.TabIndex = 7;
            this.btnsettings.Text = "Settings";
            this.btnsettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsettings.UseVisualStyleBackColor = true;
            this.btnsettings.Click += new System.EventHandler(this.btnsettings_Click);
            // 
            // panelDesktoppanel
            // 
            this.panelDesktoppanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktoppanel.Location = new System.Drawing.Point(220, 80);
            this.panelDesktoppanel.Name = "panelDesktoppanel";
            this.panelDesktoppanel.Size = new System.Drawing.Size(769, 503);
            this.panelDesktoppanel.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 583);
            this.Controls.Add(this.panelDesktoppanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelmenu);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.panelmenu.ResumeLayout(false);
            this.panellogo.ResumeLayout(false);
            this.panellogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Panel panellogo;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lbllogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btncategories;
        private System.Windows.Forms.Button btnsettings;
        private System.Windows.Forms.Button btnusers;
        private System.Windows.Forms.Button btndeacust;
        private System.Windows.Forms.Button btnpurchase;
        private System.Windows.Forms.Button btnsales;
        private System.Windows.Forms.Button btnproducts;
        private System.Windows.Forms.Panel panelDesktoppanel;
    }
}