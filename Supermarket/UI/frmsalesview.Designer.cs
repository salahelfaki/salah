
namespace Supermarket.UI
{
    partial class frmsalesview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsalesview));
            this.lblbilldate = new System.Windows.Forms.Label();
            this.pnldatagrid = new System.Windows.Forms.Panel();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.txtpaycard = new System.Windows.Forms.TextBox();
            this.txtpaycash = new System.Windows.Forms.TextBox();
            this.lblreturn = new System.Windows.Forms.Label();
            this.lblpaid = new System.Windows.Forms.Label();
            this.prntdoc = new System.Drawing.Printing.PrintDocument();
            this.prntDialog = new System.Windows.Forms.PrintDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbpayment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.prntpreview = new System.Windows.Forms.PrintPreviewDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblpay = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtnetval = new System.Windows.Forms.TextBox();
            this.txtbranch = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbbillno = new System.Windows.Forms.ComboBox();
            this.txtinvdate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtstore = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.prntdoc2 = new System.Drawing.Printing.PrintDocument();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pnldatagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.paneltop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblbilldate
            // 
            resources.ApplyResources(this.lblbilldate, "lblbilldate");
            this.lblbilldate.Name = "lblbilldate";
            // 
            // pnldatagrid
            // 
            resources.ApplyResources(this.pnldatagrid, "pnldatagrid");
            this.pnldatagrid.Controls.Add(this.dgvaddproduct);
            this.pnldatagrid.Name = "pnldatagrid";
            // 
            // dgvaddproduct
            // 
            resources.ApplyResources(this.dgvaddproduct, "dgvaddproduct");
            this.dgvaddproduct.AllowDrop = true;
            this.dgvaddproduct.AllowUserToDeleteRows = false;
            this.dgvaddproduct.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvaddproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaddproduct.Name = "dgvaddproduct";
            this.dgvaddproduct.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvaddproduct.RowTemplate.Height = 35;
            this.dgvaddproduct.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvaddproduct.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvaddproduct_CellBeginEdit);
            this.dgvaddproduct.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvaddproduct_CellEndEdit);
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
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(211)))));
            this.txtvat.Name = "txtvat";
            // 
            // txtdiscount
            // 
            resources.ApplyResources(this.txtdiscount, "txtdiscount");
            this.txtdiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.txtdiscount.Name = "txtdiscount";
            // 
            // txtsubtotal
            // 
            resources.ApplyResources(this.txtsubtotal, "txtsubtotal");
            this.txtsubtotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
            this.txtsubtotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            // 
            // lblsubtotal
            // 
            resources.ApplyResources(this.lblsubtotal, "lblsubtotal");
            this.lblsubtotal.Name = "lblsubtotal";
            // 
            // txtpaycard
            // 
            resources.ApplyResources(this.txtpaycard, "txtpaycard");
            this.txtpaycard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(233)))));
            this.txtpaycard.ForeColor = System.Drawing.Color.Red;
            this.txtpaycard.Name = "txtpaycard";
            this.txtpaycard.ReadOnly = true;
            // 
            // txtpaycash
            // 
            resources.ApplyResources(this.txtpaycash, "txtpaycash");
            this.txtpaycash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(201)))));
            this.txtpaycash.Name = "txtpaycash";
            // 
            // lblreturn
            // 
            resources.ApplyResources(this.lblreturn, "lblreturn");
            this.lblreturn.Name = "lblreturn";
            // 
            // lblpaid
            // 
            resources.ApplyResources(this.lblpaid, "lblpaid");
            this.lblpaid.Name = "lblpaid";
            // 
            // prntDialog
            // 
            this.prntDialog.UseEXDialog = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // cmbpayment
            // 
            resources.ApplyResources(this.cmbpayment, "cmbpayment");
            this.cmbpayment.FormattingEnabled = true;
            this.cmbpayment.Items.AddRange(new object[] {
            resources.GetString("cmbpayment.Items"),
            resources.GetString("cmbpayment.Items1")});
            this.cmbpayment.Name = "cmbpayment";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // prntpreview
            // 
            resources.ApplyResources(this.prntpreview, "prntpreview");
            this.prntpreview.Document = this.prntdoc;
            this.prntpreview.Name = "prntpreview";
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
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.paneltop.Controls.Add(this.button3);
            this.paneltop.Controls.Add(this.button2);
            this.paneltop.Controls.Add(this.btnsave);
            this.paneltop.Name = "paneltop";
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = global::Supermarket.Properties.Resources.Printer;
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
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
            this.btnsave.Image = global::Supermarket.Properties.Resources.Printer;
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
            // lblpay
            // 
            resources.ApplyResources(this.lblpay, "lblpay");
            this.lblpay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lblpay.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblpay.Name = "lblpay";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // txtnetval
            // 
            resources.ApplyResources(this.txtnetval, "txtnetval");
            this.txtnetval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(253)))));
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
            // cmbbillno
            // 
            resources.ApplyResources(this.cmbbillno, "cmbbillno");
            this.cmbbillno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbbillno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbbillno.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbbillno.FormattingEnabled = true;
            this.cmbbillno.Name = "cmbbillno";
            this.cmbbillno.SelectedIndexChanged += new System.EventHandler(this.cmbbillno_SelectedIndexChanged);
            // 
            // txtinvdate
            // 
            resources.ApplyResources(this.txtinvdate, "txtinvdate");
            this.txtinvdate.Name = "txtinvdate";
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
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel1.Controls.Add(this.txtuser, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtstore, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtinvdate, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbbillno, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbranch, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblbilldate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtvatno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(226)))), ((int)(((byte)(254)))));
            this.tableLayoutPanel2.Controls.Add(this.lblsubtotal, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblpay, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblreturn, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblpaid, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtpaycard, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtpaycash, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbpayment, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtsubtotal, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtvat, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtnetval, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtgrandtotal, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtdiscount, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // frmsalesview
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Honeydew;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.paneltop);
            this.Controls.Add(this.pnldatagrid);
            this.KeyPreview = true;
            this.Name = "frmsalesview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmsales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmsales_KeyDown);
            this.pnldatagrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.Panel pnldatagrid;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.TextBox txtpaycard;
        private System.Windows.Forms.TextBox txtpaycash;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.Label lblpaid;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Button btnsave;
        private System.Drawing.Printing.PrintDocument prntdoc;
        private System.Windows.Forms.PrintDialog prntDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbpayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PrintPreviewDialog prntpreview;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument prntdoc2;
        private System.Windows.Forms.TextBox txtinvdate;
        private System.Windows.Forms.ComboBox cmbbillno;
        private System.Windows.Forms.Label lblpay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}