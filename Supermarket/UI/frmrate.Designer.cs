namespace Supermarket.UI
{
    partial class frmrate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrate));
            this.lblcategid = new System.Windows.Forms.Label();
            this.txtcategoryid = new System.Windows.Forms.TextBox();
            this.lbltitle = new System.Windows.Forms.Label();
            this.txtexrate = new System.Windows.Forms.TextBox();
            this.lbldesc = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.dgvcategories = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpexdate = new System.Windows.Forms.DateTimePicker();
            this.cmbfrom = new System.Windows.Forms.ComboBox();
            this.cmbto = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategories)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcategid
            // 
            resources.ApplyResources(this.lblcategid, "lblcategid");
            this.lblcategid.Name = "lblcategid";
            // 
            // txtcategoryid
            // 
            resources.ApplyResources(this.txtcategoryid, "txtcategoryid");
            this.txtcategoryid.Name = "txtcategoryid";
            this.txtcategoryid.ReadOnly = true;
            this.txtcategoryid.ShortcutsEnabled = false;
            // 
            // lbltitle
            // 
            resources.ApplyResources(this.lbltitle, "lbltitle");
            this.lbltitle.Name = "lbltitle";
            // 
            // txtexrate
            // 
            resources.ApplyResources(this.txtexrate, "txtexrate");
            this.txtexrate.Name = "txtexrate";
            // 
            // lbldesc
            // 
            resources.ApplyResources(this.lbldesc, "lbldesc");
            this.lbldesc.Name = "lbldesc";
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
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // btnadd
            // 
            resources.ApplyResources(this.btnadd, "btnadd");
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnclear);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Controls.Add(this.btnupdate);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Name = "panel1";
            // 
            // btnclear
            // 
            resources.ApplyResources(this.btnclear, "btnclear");
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnclear.FlatAppearance.BorderSize = 0;
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnclear.Name = "btnclear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click_1);
            // 
            // btnexit
            // 
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnexit.Image = global::Supermarket.Properties.Resources.exit;
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // dgvcategories
            // 
            resources.ApplyResources(this.dgvcategories, "dgvcategories");
            this.dgvcategories.AllowUserToAddRows = false;
            this.dgvcategories.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgvcategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvcategories.Name = "dgvcategories";
            this.dgvcategories.RowTemplate.Height = 24;
            this.dgvcategories.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvcategories_RowHeaderMouseClick);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Lavender;
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.dgvcategories);
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtsearch, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtcategoryid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblcategid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbltitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtpexdate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtexrate, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbldesc, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbfrom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbto, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // dtpexdate
            // 
            resources.ApplyResources(this.dtpexdate, "dtpexdate");
            this.dtpexdate.Name = "dtpexdate";
            // 
            // cmbfrom
            // 
            resources.ApplyResources(this.cmbfrom, "cmbfrom");
            this.cmbfrom.FormattingEnabled = true;
            this.cmbfrom.Items.AddRange(new object[] {
            resources.GetString("cmbfrom.Items"),
            resources.GetString("cmbfrom.Items1")});
            this.cmbfrom.Name = "cmbfrom";
            this.cmbfrom.SelectedIndexChanged += new System.EventHandler(this.cmbfrom_SelectedIndexChanged);
            // 
            // cmbto
            // 
            resources.ApplyResources(this.cmbto, "cmbto");
            this.cmbto.FormattingEnabled = true;
            this.cmbto.Items.AddRange(new object[] {
            resources.GetString("cmbto.Items"),
            resources.GetString("cmbto.Items1")});
            this.cmbto.Name = "cmbto";
            // 
            // frmrate
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmrate";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmcategories_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvcategories)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblcategid;
        private System.Windows.Forms.TextBox txtcategoryid;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TextBox txtexrate;
        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvcategories;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.DateTimePicker dtpexdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbfrom;
        private System.Windows.Forms.ComboBox cmbto;
    }
}