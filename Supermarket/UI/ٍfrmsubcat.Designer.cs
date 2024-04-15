
namespace Supermarket.UI
{
    partial class frmsubcat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsubcat));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvsubcat = new System.Windows.Forms.DataGridView();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbldesc = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.lblcategid = new System.Windows.Forms.Label();
            this.txtsubcatid = new System.Windows.Forms.TextBox();
            this.cmbcategid = new System.Windows.Forms.ComboBox();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsubcat)).BeginInit();
            this.SuspendLayout();
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
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // dgvsubcat
            // 
            resources.ApplyResources(this.dgvsubcat, "dgvsubcat");
            this.dgvsubcat.AllowUserToAddRows = false;
            this.dgvsubcat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvsubcat.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.dgvsubcat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsubcat.Name = "dgvsubcat";
            this.dgvsubcat.RowTemplate.Height = 24;
            this.dgvsubcat.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvsubcat_RowHeaderMouseClick);
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            // 
            // lbldesc
            // 
            resources.ApplyResources(this.lbldesc, "lbldesc");
            this.lbldesc.Name = "lbldesc";
            // 
            // lbltitle
            // 
            resources.ApplyResources(this.lbltitle, "lbltitle");
            this.lbltitle.Name = "lbltitle";
            // 
            // lblcategid
            // 
            resources.ApplyResources(this.lblcategid, "lblcategid");
            this.lblcategid.Name = "lblcategid";
            // 
            // txtsubcatid
            // 
            resources.ApplyResources(this.txtsubcatid, "txtsubcatid");
            this.txtsubcatid.Name = "txtsubcatid";
            this.txtsubcatid.ReadOnly = true;
            this.txtsubcatid.ShortcutsEnabled = false;
            // 
            // cmbcategid
            // 
            resources.ApplyResources(this.cmbcategid, "cmbcategid");
            this.cmbcategid.FormattingEnabled = true;
            this.cmbcategid.Name = "cmbcategid";
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
            this.btnadd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnadd.Image = global::Supermarket.Properties.Resources.Application_add;
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdate.Image = global::Supermarket.Properties.Resources.edit;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btndelete.ForeColor = System.Drawing.Color.White;
            this.btndelete.Image = global::Supermarket.Properties.Resources.delete;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // frmsubcat
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.ControlBox = false;
            this.Controls.Add(this.cmbcategid);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvsubcat);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lbldesc);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.lblcategid);
            this.Controls.Add(this.txtsubcatid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmsubcat";
            this.Load += new System.EventHandler(this.frmsubcat_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsubcat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvsubcat;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label lblcategid;
        private System.Windows.Forms.TextBox txtsubcatid;
        private System.Windows.Forms.ComboBox cmbcategid;
        private System.Windows.Forms.Button btnexit;
    }
}