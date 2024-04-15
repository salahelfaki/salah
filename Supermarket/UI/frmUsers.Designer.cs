namespace Supermarket.UI
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.lblfirstname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtusertype = new System.Windows.Forms.ComboBox();
            this.lblusertype = new System.Windows.Forms.Label();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.lbluserid = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dgvusers = new System.Windows.Forms.DataGridView();
            this.lblsearch = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblfirstname
            // 
            resources.ApplyResources(this.lblfirstname, "lblfirstname");
            this.lblfirstname.Name = "lblfirstname";
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            // 
            // txtusername
            // 
            resources.ApplyResources(this.txtusername, "txtusername");
            this.txtusername.Name = "txtusername";
            // 
            // lblusername
            // 
            resources.ApplyResources(this.lblusername, "lblusername");
            this.lblusername.Name = "lblusername";
            // 
            // txtpassword
            // 
            resources.ApplyResources(this.txtpassword, "txtpassword");
            this.txtpassword.Name = "txtpassword";
            // 
            // lblpassword
            // 
            resources.ApplyResources(this.lblpassword, "lblpassword");
            this.lblpassword.Name = "lblpassword";
            // 
            // txtusertype
            // 
            resources.ApplyResources(this.txtusertype, "txtusertype");
            this.txtusertype.FormattingEnabled = true;
            this.txtusertype.Items.AddRange(new object[] {
            resources.GetString("txtusertype.Items"),
            resources.GetString("txtusertype.Items1")});
            this.txtusertype.Name = "txtusertype";
            // 
            // lblusertype
            // 
            resources.ApplyResources(this.lblusertype, "lblusertype");
            this.lblusertype.Name = "lblusertype";
            // 
            // txtuserid
            // 
            resources.ApplyResources(this.txtuserid, "txtuserid");
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.ReadOnly = true;
            // 
            // lbluserid
            // 
            resources.ApplyResources(this.lbluserid, "lbluserid");
            this.lbluserid.Name = "lbluserid";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dgvusers
            // 
            resources.ApplyResources(this.dgvusers, "dgvusers");
            this.dgvusers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.dgvusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusers.Name = "dgvusers";
            this.dgvusers.RowTemplate.Height = 24;
            this.dgvusers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvusers_RowHeaderMouseClick);
            // 
            // lblsearch
            // 
            resources.ApplyResources(this.lblsearch, "lblsearch");
            this.lblsearch.Name = "lblsearch";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnadd);
            this.panel3.Controls.Add(this.btnupdate);
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Name = "panel3";
            // 
            // btnexit
            // 
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::Supermarket.Properties.Resources.exit;
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnadd
            // 
            resources.ApplyResources(this.btnadd, "btnadd");
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnadd.Image = global::Supermarket.Properties.Resources.Application_add;
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdate.Image = global::Supermarket.Properties.Resources.edit;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.button3_Click);
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndelete.Image = global::Supermarket.Properties.Resources.delete;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmUsers
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.dgvusers);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.lbluserid);
            this.Controls.Add(this.txtusertype);
            this.Controls.Add(this.lblusertype);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblfirstname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmUsers";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblfirstname;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.ComboBox txtusertype;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label lbluserid;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridView dgvusers;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
    }
}