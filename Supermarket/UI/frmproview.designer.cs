
namespace Supermarket.UI
{
    partial class frmproview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmproview));
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtnetval = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.txtstore = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcaddress = new System.Windows.Forms.TextBox();
            this.txtbranch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbcustomers = new System.Windows.Forms.ComboBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.lblbilldate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbbillno = new System.Windows.Forms.ComboBox();
            this.txtcurrentvalue = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblreturn = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtpaymethod = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnallcash = new System.Windows.Forms.Button();
            this.txtreturn = new System.Windows.Forms.TextBox();
            this.txtpaycredit = new System.Windows.Forms.TextBox();
            this.txtcard = new System.Windows.Forms.TextBox();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.btnallcard = new System.Windows.Forms.Button();
            this.btncredit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.txtolddiscount = new System.Windows.Forms.TextBox();
            this.paneltop = new System.Windows.Forms.Panel();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtpart = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.paneltop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.ForestGreen;
            this.label13.Name = "label13";
            // 
            // txtnetval
            // 
            this.txtnetval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.txtnetval, "txtnetval");
            this.txtnetval.Name = "txtnetval";
            // 
            // txtuser
            // 
            resources.ApplyResources(this.txtuser, "txtuser");
            this.txtuser.Name = "txtuser";
            this.txtuser.ReadOnly = true;
            // 
            // txtstore
            // 
            resources.ApplyResources(this.txtstore, "txtstore");
            this.txtstore.Name = "txtstore";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtcaddress
            // 
            resources.ApplyResources(this.txtcaddress, "txtcaddress");
            this.txtcaddress.Name = "txtcaddress";
            // 
            // txtbranch
            // 
            resources.ApplyResources(this.txtbranch, "txtbranch");
            this.txtbranch.Name = "txtbranch";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cmbcustomers
            // 
            this.cmbcustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbcustomers, "cmbcustomers");
            this.cmbcustomers.FormattingEnabled = true;
            this.cmbcustomers.Name = "cmbcustomers";
            this.cmbcustomers.SelectedIndexChanged += new System.EventHandler(this.cmbcustomers_SelectedIndexChanged);
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txtuser, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtstore, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtcaddress, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbranch, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbcustomers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtvatno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpbilldate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblbilldate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbbillno, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtvatno
            // 
            resources.ApplyResources(this.txtvatno, "txtvatno");
            this.txtvatno.Name = "txtvatno";
            // 
            // dtpbilldate
            // 
            resources.ApplyResources(this.dtpbilldate, "dtpbilldate");
            this.dtpbilldate.Name = "dtpbilldate";
            // 
            // lblbilldate
            // 
            resources.ApplyResources(this.lblbilldate, "lblbilldate");
            this.lblbilldate.Name = "lblbilldate";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmbbillno
            // 
            resources.ApplyResources(this.cmbbillno, "cmbbillno");
            this.cmbbillno.FormattingEnabled = true;
            this.cmbbillno.Name = "cmbbillno";
            this.cmbbillno.SelectedIndexChanged += new System.EventHandler(this.cmbbillno_SelectedIndexChanged);
            // 
            // txtcurrentvalue
            // 
            this.txtcurrentvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtcurrentvalue, "txtcurrentvalue");
            this.txtcurrentvalue.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtcurrentvalue.Name = "txtcurrentvalue";
            this.txtcurrentvalue.ReadOnly = true;
            // 
            // lblsubtotal
            // 
            resources.ApplyResources(this.lblsubtotal, "lblsubtotal");
            this.lblsubtotal.Name = "lblsubtotal";
            // 
            // txtgrandtotal
            // 
            resources.ApplyResources(this.txtgrandtotal, "txtgrandtotal");
            this.txtgrandtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(210)))));
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.ReadOnly = true;
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.txtsubtotal, "txtsubtotal");
            this.txtsubtotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            // 
            // lblreturn
            // 
            resources.ApplyResources(this.lblreturn, "lblreturn");
            this.lblreturn.Name = "lblreturn";
            // 
            // txtbalance
            // 
            this.txtbalance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            resources.ApplyResources(this.txtbalance, "txtbalance");
            this.txtbalance.ForeColor = System.Drawing.Color.Red;
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.ReadOnly = true;
            // 
            // txtdiscount
            // 
            this.txtdiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtdiscount, "txtdiscount");
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
            // 
            // txtvat
            // 
            this.txtvat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(211)))));
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.Name = "txtvat";
            // 
            // txtpaymethod
            // 
            resources.ApplyResources(this.txtpaymethod, "txtpaymethod");
            this.txtpaymethod.Name = "txtpaymethod";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lblsubtotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtpaymethod, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnallcash, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtcurrentvalue, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtgrandtotal, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtsubtotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtnetval, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtreturn, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblreturn, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtpaycredit, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtcard, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtpaid, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnallcard, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.btncredit, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtbalance, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtdiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtvat, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnallcash
            // 
            this.btnallcash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnallcash, "btnallcash");
            this.btnallcash.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnallcash.Name = "btnallcash";
            this.btnallcash.UseVisualStyleBackColor = false;
            // 
            // txtreturn
            // 
            this.txtreturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            resources.ApplyResources(this.txtreturn, "txtreturn");
            this.txtreturn.ForeColor = System.Drawing.Color.Red;
            this.txtreturn.Name = "txtreturn";
            this.txtreturn.ReadOnly = true;
            // 
            // txtpaycredit
            // 
            this.txtpaycredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(201)))));
            resources.ApplyResources(this.txtpaycredit, "txtpaycredit");
            this.txtpaycredit.Name = "txtpaycredit";
            // 
            // txtcard
            // 
            this.txtcard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(201)))));
            resources.ApplyResources(this.txtcard, "txtcard");
            this.txtcard.Name = "txtcard";
            // 
            // txtpaid
            // 
            this.txtpaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(201)))));
            resources.ApplyResources(this.txtpaid, "txtpaid");
            this.txtpaid.Name = "txtpaid";
            // 
            // btnallcard
            // 
            this.btnallcard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnallcard, "btnallcard");
            this.btnallcard.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnallcard.Name = "btnallcard";
            this.btnallcard.UseVisualStyleBackColor = false;
            // 
            // btncredit
            // 
            this.btncredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btncredit, "btncredit");
            this.btncredit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncredit.Name = "btncredit";
            this.btncredit.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // dgvaddproduct
            // 
            this.dgvaddproduct.AllowDrop = true;
            this.dgvaddproduct.AllowUserToDeleteRows = false;
            this.dgvaddproduct.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvaddproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvaddproduct, "dgvaddproduct");
            this.dgvaddproduct.Name = "dgvaddproduct";
            this.dgvaddproduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvaddproduct.RowTemplate.Height = 35;
            this.dgvaddproduct.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvaddproduct.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvaddproduct_CellBeginEdit);
            this.dgvaddproduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaddproduct_CellContentClick);
            this.dgvaddproduct.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaddproduct_CellEndEdit);
            this.dgvaddproduct.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvaddproduct_RowHeaderMouseClick);
            // 
            // txtolddiscount
            // 
            resources.ApplyResources(this.txtolddiscount, "txtolddiscount");
            this.txtolddiscount.Name = "txtolddiscount";
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.paneltop.Controls.Add(this.btnprnt);
            this.paneltop.Controls.Add(this.btnremove);
            this.paneltop.Controls.Add(this.button5);
            this.paneltop.Controls.Add(this.button4);
            this.paneltop.Controls.Add(this.btnprntA4);
            this.paneltop.Controls.Add(this.button2);
            this.paneltop.Controls.Add(this.btnsave);
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.Name = "paneltop";
            // 
            // btnprnt
            // 
            this.btnprnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnprnt, "btnprnt");
            this.btnprnt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprnt.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnprnt.Name = "btnprnt";
            this.btnprnt.UseVisualStyleBackColor = false;
            this.btnprnt.Click += new System.EventHandler(this.btnprnt_Click);
            // 
            // btnremove
            // 
            this.btnremove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnremove, "btnremove");
            this.btnremove.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnremove.Image = global::Supermarket.Properties.Resources.delete;
            this.btnremove.Name = "btnremove";
            this.btnremove.UseVisualStyleBackColor = false;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Image = global::Supermarket.Properties.Resources.search_icon;
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnprntA4
            // 
            this.btnprntA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnprntA4, "btnprntA4");
            this.btnprntA4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprntA4.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnprntA4.Name = "btnprntA4";
            this.btnprntA4.UseVisualStyleBackColor = false;
            this.btnprntA4.Click += new System.EventHandler(this.btnprntA4_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Supermarket.Properties.Resources.exit;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnsave, "btnsave");
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.Image = global::Supermarket.Properties.Resources.save;
            this.btnsave.Name = "btnsave";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.dgvaddproduct);
            this.panel2.Name = "panel2";
            // 
            // txtpart
            // 
            resources.ApplyResources(this.txtpart, "txtpart");
            this.txtpart.Name = "txtpart";
            // 
            // frmproview
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.txtolddiscount);
            this.Controls.Add(this.paneltop);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtpart);
            this.Name = "frmproview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmproview_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmproview_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtnetval;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox txtstore;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtcaddress;
        private System.Windows.Forms.TextBox txtbranch;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbcustomers;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbbillno;
        private System.Windows.Forms.TextBox txtcurrentvalue;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtpaymethod;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.TextBox txtolddiscount;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtpart;
        private System.Windows.Forms.Button btnallcash;
        private System.Windows.Forms.TextBox txtreturn;
        private System.Windows.Forms.TextBox txtpaycredit;
        private System.Windows.Forms.TextBox txtcard;
        private System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.Button btnallcard;
        private System.Windows.Forms.Button btncredit;
        private System.Windows.Forms.Panel panel2;
    }
}