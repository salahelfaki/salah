namespace Supermarket.UI
{
    partial class frmsales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsales));
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.lblbilldate = new System.Windows.Forms.Label();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btnremove = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpart = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtnetval = new System.Windows.Forms.TextBox();
            this.cmbcustomers = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtpaymethod = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnpay = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.itemsearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.paneltop.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(255)))), ((int)(((byte)(211)))));
            this.txtvat.Name = "txtvat";
            // 
            // txtdiscount
            // 
            resources.ApplyResources(this.txtdiscount, "txtdiscount");
            this.txtdiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(237)))), ((int)(((byte)(255)))));
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
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
            this.paneltop.Controls.Add(this.btnprnt);
            this.paneltop.Controls.Add(this.btnremove);
            this.paneltop.Controls.Add(this.button5);
            this.paneltop.Controls.Add(this.button4);
            this.paneltop.Controls.Add(this.btnprntA4);
            this.paneltop.Controls.Add(this.button2);
            this.paneltop.Controls.Add(this.btnsave);
            this.paneltop.Name = "paneltop";
            // 
            // btnprnt
            // 
            resources.ApplyResources(this.btnprnt, "btnprnt");
            this.btnprnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
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
            // button4
            // 
            resources.ApplyResources(this.button4, "button4");
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnprntA4
            // 
            resources.ApplyResources(this.btnprntA4, "btnprntA4");
            this.btnprntA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnprntA4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprntA4.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnprntA4.Name = "btnprntA4";
            this.btnprntA4.UseVisualStyleBackColor = false;
            this.btnprntA4.Click += new System.EventHandler(this.button3_Click);
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
            // txtpart
            // 
            resources.ApplyResources(this.txtpart, "txtpart");
            this.txtpart.Name = "txtpart";
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
            // cmbcustomers
            // 
            resources.ApplyResources(this.cmbcustomers, "cmbcustomers");
            this.cmbcustomers.FormattingEnabled = true;
            this.cmbcustomers.Name = "cmbcustomers";
            this.cmbcustomers.SelectedIndexChanged += new System.EventHandler(this.cmbcustomers_SelectedIndexChanged);
            this.cmbcustomers.Validated += new System.EventHandler(this.cmbcustomers_Validated);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // txtpaymethod
            // 
            resources.ApplyResources(this.txtpaymethod, "txtpaymethod");
            this.txtpaymethod.Name = "txtpaymethod";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Name = "label15";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Name = "label4";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtpaymethod);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtpart);
            this.panel3.Name = "panel3";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtname.Name = "txtname";
            this.txtname.Validated += new System.EventHandler(this.txtname_Validated);
            // 
            // txtbarcode
            // 
            resources.ApplyResources(this.txtbarcode, "txtbarcode");
            this.txtbarcode.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtbarcode.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.Validated += new System.EventHandler(this.txtbarcode_Validated);
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel1, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // tableLayoutPanel4
            // 
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel4.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblbilldate, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.dtpbilldate, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtdescription, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.cmbcustomers, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtvatno, 1, 2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblsubtotal, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtsubtotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtdiscount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtvat, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtnetval, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel5
            // 
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel5.Controls.Add(this.txtgrandtotal, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnpay, 0, 1);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            // 
            // btnpay
            // 
            resources.ApplyResources(this.btnpay, "btnpay");
            this.btnpay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnpay.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnpay.Name = "btnpay";
            this.btnpay.TabStop = false;
            this.btnpay.UseVisualStyleBackColor = false;
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.itemsearch, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtbarcode, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtname, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label20, 2, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // itemsearch
            // 
            resources.ApplyResources(this.itemsearch, "itemsearch");
            this.itemsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.itemsearch.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.itemsearch.Image = global::Supermarket.Properties.Resources.search_icon;
            this.itemsearch.Name = "itemsearch";
            this.itemsearch.UseVisualStyleBackColor = false;
            this.itemsearch.Click += new System.EventHandler(this.itemsearch_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.dgvaddproduct);
            this.panel1.Name = "panel1";
            // 
            // frmsales
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.paneltop);
            this.Name = "frmsales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmsales_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmsales_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.paneltop.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnremove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtnetval;
        private System.Windows.Forms.TextBox txtpart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtpaymethod;
        private System.Windows.Forms.ComboBox cmbcustomers;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button itemsearch;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
    }
}