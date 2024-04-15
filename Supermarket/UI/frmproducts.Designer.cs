namespace Supermarket.UI
{
    partial class frmproducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmproducts));
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldescription = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.lblrate = new System.Windows.Forms.Label();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.lblsearch = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelbtn = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.lblvalid = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbunit = new System.Windows.Forms.ComboBox();
            this.txtlastprice = new System.Windows.Forms.TextBox();
            this.txtcostprice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.txtsearchname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtpimage = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).BeginInit();
            this.panelbtn.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            // 
            // lblname
            // 
            resources.ApplyResources(this.lblname, "lblname");
            this.lblname.Name = "lblname";
            // 
            // cmbcategory
            // 
            resources.ApplyResources(this.cmbcategory, "cmbcategory");
            this.cmbcategory.AllowDrop = true;
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.SelectedValueChanged += new System.EventHandler(this.cmbcategory_SelectedValueChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbldescription
            // 
            resources.ApplyResources(this.lbldescription, "lbldescription");
            this.lbldescription.Name = "lbldescription";
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescription_KeyDown);
            // 
            // lblrate
            // 
            resources.ApplyResources(this.lblrate, "lblrate");
            this.lblrate.Name = "lblrate";
            // 
            // txtrate
            // 
            resources.ApplyResources(this.txtrate, "txtrate");
            this.txtrate.Name = "txtrate";
            // 
            // lblid
            // 
            resources.ApplyResources(this.lblid, "lblid");
            this.lblid.Name = "lblid";
            // 
            // txtid
            // 
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            // 
            // dgvproducts
            // 
            resources.ApplyResources(this.dgvproducts, "dgvproducts");
            this.dgvproducts.AllowUserToAddRows = false;
            this.dgvproducts.AllowUserToDeleteRows = false;
            this.dgvproducts.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(226)))), ((int)(((byte)(250)))));
            this.dgvproducts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproducts.GridColor = System.Drawing.Color.PowderBlue;
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvproducts_CellContentClick);
            this.dgvproducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvproducts_RowHeaderMouseClick);
            // 
            // lblsearch
            // 
            resources.ApplyResources(this.lblsearch, "lblsearch");
            this.lblsearch.Name = "lblsearch";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblpbarcode
            // 
            resources.ApplyResources(this.lblpbarcode, "lblpbarcode");
            this.lblpbarcode.Name = "lblpbarcode";
            // 
            // txtbarcode
            // 
            resources.ApplyResources(this.txtbarcode, "txtbarcode");
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Validated += new System.EventHandler(this.txtbarcode_Validated);
            // 
            // txtqty
            // 
            resources.ApplyResources(this.txtqty, "txtqty");
            this.txtqty.Name = "txtqty";
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
            // panelbtn
            // 
            resources.ApplyResources(this.panelbtn, "panelbtn");
            this.panelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panelbtn.Controls.Add(this.btnexit);
            this.panelbtn.Controls.Add(this.btnupdate);
            this.panelbtn.Controls.Add(this.btnadd);
            this.panelbtn.Controls.Add(this.btndelete);
            this.panelbtn.Controls.Add(this.btnclear);
            this.panelbtn.Name = "panelbtn";
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
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btndelete.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btndelete.Image = global::Supermarket.Properties.Resources.delete;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnclear
            // 
            resources.ApplyResources(this.btnclear, "btnclear");
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Image = global::Supermarket.Properties.Resources.clear_form;
            this.btnclear.Name = "btnclear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // lblvalid
            // 
            resources.ApplyResources(this.lblvalid, "lblvalid");
            this.lblvalid.ForeColor = System.Drawing.Color.Red;
            this.lblvalid.Name = "lblvalid";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtid, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblpbarcode, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbarcode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblname, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtname, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblrate, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtrate, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbcategory, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbldescription, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cmbunit, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtqty, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtlastprice, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtcostprice, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 9);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // cmbunit
            // 
            resources.ApplyResources(this.cmbunit, "cmbunit");
            this.cmbunit.FormattingEnabled = true;
            this.cmbunit.Items.AddRange(new object[] {
            resources.GetString("cmbunit.Items"),
            resources.GetString("cmbunit.Items1"),
            resources.GetString("cmbunit.Items2")});
            this.cmbunit.Name = "cmbunit";
            // 
            // txtlastprice
            // 
            resources.ApplyResources(this.txtlastprice, "txtlastprice");
            this.txtlastprice.Name = "txtlastprice";
            // 
            // txtcostprice
            // 
            resources.ApplyResources(this.txtcostprice, "txtcostprice");
            this.txtcostprice.Name = "txtcostprice";
            this.txtcostprice.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.txtsearchname, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.lblsearch, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.txtsearch, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // txtsearchname
            // 
            resources.ApplyResources(this.txtsearchname, "txtsearchname");
            this.txtsearchname.Name = "txtsearchname";
            this.txtsearchname.TextChanged += new System.EventHandler(this.txtsearchname_TextChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.pictureBox, 0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.txtpimage);
            this.panel2.Controls.Add(this.btnbrowse);
            this.panel2.Name = "panel2";
            // 
            // txtpimage
            // 
            resources.ApplyResources(this.txtpimage, "txtpimage");
            this.txtpimage.Name = "txtpimage";
            // 
            // btnbrowse
            // 
            resources.ApplyResources(this.btnbrowse, "btnbrowse");
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.dgvproducts);
            this.panel1.Name = "panel1";
            // 
            // frmproducts
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.lblvalid);
            this.Controls.Add(this.panelbtn);
            this.Name = "frmproducts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmproducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).EndInit();
            this.panelbtn.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelbtn;
        private System.Windows.Forms.Label lblvalid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtlastprice;
        private System.Windows.Forms.ComboBox cmbunit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcostprice;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtpimage;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsearchname;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Panel panel1;
    }
}