namespace Supermarket.UI
{
    partial class frmaccts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmaccts));
            this.dgvdeacust = new System.Windows.Forms.DataGridView();
            this.lblname = new System.Windows.Forms.Label();
            this.txtacctname = new System.Windows.Forms.TextBox();
            this.txtcreg = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.txttleno = new System.Windows.Forms.TextBox();
            this.lblcontact = new System.Windows.Forms.Label();
            this.txtcaddress = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.txtobalance = new System.Windows.Forms.TextBox();
            this.txtacctcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbmainacct = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.txtcemail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeacust)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvdeacust
            // 
            resources.ApplyResources(this.dgvdeacust, "dgvdeacust");
            this.dgvdeacust.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.dgvdeacust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdeacust.Name = "dgvdeacust";
            this.dgvdeacust.RowTemplate.Height = 24;
            this.dgvdeacust.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdeacust_RowHeaderMouseClick);
            // 
            // lblname
            // 
            resources.ApplyResources(this.lblname, "lblname");
            this.lblname.Name = "lblname";
            this.lblname.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtacctname
            // 
            resources.ApplyResources(this.txtacctname, "txtacctname");
            this.txtacctname.Name = "txtacctname";
            // 
            // txtcreg
            // 
            resources.ApplyResources(this.txtcreg, "txtcreg");
            this.txtcreg.Name = "txtcreg";
            // 
            // lblemail
            // 
            resources.ApplyResources(this.lblemail, "lblemail");
            this.lblemail.Name = "lblemail";
            // 
            // txttleno
            // 
            resources.ApplyResources(this.txttleno, "txttleno");
            this.txttleno.Name = "txttleno";
            // 
            // lblcontact
            // 
            resources.ApplyResources(this.lblcontact, "lblcontact");
            this.lblcontact.Name = "lblcontact";
            // 
            // txtcaddress
            // 
            resources.ApplyResources(this.txtcaddress, "txtcaddress");
            this.txtcaddress.Name = "txtcaddress";
            this.txtcaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // lbladdress
            // 
            resources.ApplyResources(this.lbladdress, "lbladdress");
            this.lbladdress.Name = "lbladdress";
            // 
            // txtid
            // 
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            // 
            // lblid
            // 
            resources.ApplyResources(this.lblid, "lblid");
            this.lblid.Name = "lblid";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblsearch
            // 
            resources.ApplyResources(this.lblsearch, "lblsearch");
            this.lblsearch.Name = "lblsearch";
            // 
            // txtvat
            // 
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.Name = "txtvat";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnnew);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnadd);
            this.panel3.Controls.Add(this.btnupdate);
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Name = "panel3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Name = "label1";
            // 
            // btnnew
            // 
            resources.ApplyResources(this.btnnew, "btnnew");
            this.btnnew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnnew.FlatAppearance.BorderSize = 0;
            this.btnnew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnnew.Image = global::Supermarket.Properties.Resources.delete;
            this.btnnew.Name = "btnnew";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
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
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnadd.FlatAppearance.BorderSize = 0;
            this.btnadd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnadd.Image = global::Supermarket.Properties.Resources.Application_add;
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnupdate.FlatAppearance.BorderSize = 0;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdate.Image = global::Supermarket.Properties.Resources.edit;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.button2_Click);
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btndelete.FlatAppearance.BorderSize = 0;
            this.btndelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndelete.Image = global::Supermarket.Properties.Resources.delete;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.txtobalance, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtacctcode, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblid, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtid, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtacctname, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblname, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.cmbmainacct, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // txtobalance
            // 
            resources.ApplyResources(this.txtobalance, "txtobalance");
            this.txtobalance.Name = "txtobalance";
            // 
            // txtacctcode
            // 
            resources.ApplyResources(this.txtacctcode, "txtacctcode");
            this.txtacctcode.Name = "txtacctcode";
            this.txtacctcode.Validated += new System.EventHandler(this.txtacctcode_Validated);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmbmainacct
            // 
            resources.ApplyResources(this.cmbmainacct, "cmbmainacct");
            this.cmbmainacct.FormattingEnabled = true;
            this.cmbmainacct.Name = "cmbmainacct";
            this.cmbmainacct.SelectedIndexChanged += new System.EventHandler(this.cmbmainacct_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.txtcemail, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtcaddress, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtvat, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbladdress, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtcreg, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblcontact, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txttleno, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblemail, 0, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // txtcemail
            // 
            resources.ApplyResources(this.txtcemail, "txtcemail");
            this.txtcemail.Name = "txtcemail";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.txtsearch);
            this.panel1.Controls.Add(this.lblsearch);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.dgvdeacust);
            this.panel2.Name = "panel2";
            // 
            // frmaccts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Name = "frmaccts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmdeacust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeacust)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvdeacust;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtacctname;
        private System.Windows.Forms.TextBox txtcreg;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.TextBox txttleno;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.TextBox txtcaddress;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtobalance;
        private System.Windows.Forms.TextBox txtacctcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbmainacct;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtcemail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}