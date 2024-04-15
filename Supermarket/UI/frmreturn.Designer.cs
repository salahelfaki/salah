
namespace Supermarket.UI
{
    partial class frmreturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmreturn));
            this.lblbilldate = new System.Windows.Forms.Label();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.txtreturn = new System.Windows.Forms.TextBox();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcurrentvalue = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtnetval = new System.Windows.Forms.TextBox();
            this.txtbranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtreturnno = new System.Windows.Forms.TextBox();
            this.txtbillno = new System.Windows.Forms.TextBox();
            this.txtinvdate = new System.Windows.Forms.TextBox();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtstore = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtcredit = new System.Windows.Forms.TextBox();
            this.txtcard = new System.Windows.Forms.TextBox();
            this.txtcash = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.paneltop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblbilldate
            // 
            resources.ApplyResources(this.lblbilldate, "lblbilldate");
            this.lblbilldate.Name = "lblbilldate";
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
            this.dgvaddproduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaddproduct_CellContentClick_1);
            this.dgvaddproduct.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaddproduct_CellEndEdit);
            this.dgvaddproduct.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvaddproduct_RowHeaderMouseClick);
            // 
            // txtgrandtotal
            // 
            resources.ApplyResources(this.txtgrandtotal, "txtgrandtotal");
            this.txtgrandtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(212)))), ((int)(((byte)(210)))));
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.ReadOnly = true;
            // 
            // txtvat
            // 
            this.txtvat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(211)))));
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.Name = "txtvat";
            // 
            // txtdiscount
            // 
            this.txtdiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            resources.ApplyResources(this.txtdiscount, "txtdiscount");
            this.txtdiscount.Name = "txtdiscount";
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.txtsubtotal, "txtsubtotal");
            this.txtsubtotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            // 
            // lblsubtotal
            // 
            resources.ApplyResources(this.lblsubtotal, "lblsubtotal");
            this.lblsubtotal.Name = "lblsubtotal";
            // 
            // txtreturn
            // 
            this.txtreturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            resources.ApplyResources(this.txtreturn, "txtreturn");
            this.txtreturn.ForeColor = System.Drawing.Color.Red;
            this.txtreturn.Name = "txtreturn";
            this.txtreturn.ReadOnly = true;
            // 
            // txtpaid
            // 
            this.txtpaid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.txtpaid, "txtpaid");
            this.txtpaid.ForeColor = System.Drawing.Color.Red;
            this.txtpaid.Name = "txtpaid";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtvatno
            // 
            resources.ApplyResources(this.txtvatno, "txtvatno");
            this.txtvatno.Name = "txtvatno";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // paneltop
            // 
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.paneltop.Controls.Add(this.btnprnt);
            this.paneltop.Controls.Add(this.btnremove);
            this.paneltop.Controls.Add(this.button5);
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
            resources.ApplyResources(this.btnremove, "btnremove");
            this.btnremove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
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
            // btnprntA4
            // 
            this.btnprntA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnprntA4, "btnprntA4");
            this.btnprntA4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprntA4.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnprntA4.Name = "btnprntA4";
            this.btnprntA4.UseVisualStyleBackColor = false;
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
            resources.ApplyResources(this.btnsave, "btnsave");
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.Image = global::Supermarket.Properties.Resources.save;
            this.btnsave.Name = "btnsave";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtcurrentvalue
            // 
            this.txtcurrentvalue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.txtcurrentvalue, "txtcurrentvalue");
            this.txtcurrentvalue.ForeColor = System.Drawing.Color.ForestGreen;
            this.txtcurrentvalue.Name = "txtcurrentvalue";
            this.txtcurrentvalue.ReadOnly = true;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.ForeColor = System.Drawing.Color.ForestGreen;
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtnetval
            // 
            this.txtnetval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            resources.ApplyResources(this.txtnetval, "txtnetval");
            this.txtnetval.Name = "txtnetval";
            // 
            // txtbranch
            // 
            resources.ApplyResources(this.txtbranch, "txtbranch");
            this.txtbranch.Name = "txtbranch";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtreturnno
            // 
            resources.ApplyResources(this.txtreturnno, "txtreturnno");
            this.txtreturnno.Name = "txtreturnno";
            // 
            // txtbillno
            // 
            resources.ApplyResources(this.txtbillno, "txtbillno");
            this.txtbillno.Name = "txtbillno";
            this.txtbillno.TextChanged += new System.EventHandler(this.txtbillno_TextChanged);
            this.txtbillno.Validated += new System.EventHandler(this.txtbillno_Validated);
            // 
            // txtinvdate
            // 
            resources.ApplyResources(this.txtinvdate, "txtinvdate");
            this.txtinvdate.Name = "txtinvdate";
            // 
            // cmbtype
            // 
            this.cmbtype.BackColor = System.Drawing.SystemColors.Highlight;
            resources.ApplyResources(this.cmbtype, "cmbtype");
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            resources.GetString("cmbtype.Items"),
            resources.GetString("cmbtype.Items1")});
            this.cmbtype.Name = "cmbtype";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // txtstore
            // 
            resources.ApplyResources(this.txtstore, "txtstore");
            this.txtstore.Name = "txtstore";
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtuser
            // 
            resources.ApplyResources(this.txtuser, "txtuser");
            this.txtuser.Name = "txtuser";
            this.txtuser.ReadOnly = true;
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txtuser, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtstore, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtinvdate, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtreturnno, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbranch, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblbilldate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbillno, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbtype, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtvatno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvaddproduct);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.lblsubtotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtcurrentvalue, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtgrandtotal, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtsubtotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtnetval, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtvat, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtdiscount, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.button1, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.button3, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.button4, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtpaid, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtcredit, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtreturn, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtcard, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtcash, 5, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // txtcredit
            // 
            resources.ApplyResources(this.txtcredit, "txtcredit");
            this.txtcredit.Name = "txtcredit";
            // 
            // txtcard
            // 
            resources.ApplyResources(this.txtcard, "txtcard");
            this.txtcard.Name = "txtcard";
            // 
            // txtcash
            // 
            this.txtcash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            resources.ApplyResources(this.txtcash, "txtcash");
            this.txtcash.ForeColor = System.Drawing.Color.Red;
            this.txtcash.Name = "txtcash";
            this.txtcash.ReadOnly = true;
            // 
            // frmreturn
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.paneltop);
            this.KeyPreview = true;
            this.Name = "frmreturn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmsales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmsales_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.TextBox txtreturn;
        private System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtstore;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtnetval;
        private System.Windows.Forms.TextBox txtcurrentvalue;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtinvdate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbillno;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.TextBox txtreturnno;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtcard;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtcredit;
        private System.Windows.Forms.TextBox txtcash;
    }
}