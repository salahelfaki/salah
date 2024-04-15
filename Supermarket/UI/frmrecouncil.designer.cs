
namespace Supermarket.UI
{
    partial class frmrecouncil
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmrecouncil));
            this.dgvpayment = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblbilldate = new System.Windows.Forms.Label();
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trno = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbcustomers = new System.Windows.Forms.ComboBox();
            this.cmbacct2 = new System.Windows.Forms.ComboBox();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.txtbalance2 = new System.Windows.Forms.TextBox();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtamount2 = new System.Windows.Forms.TextBox();
            this.txtacctcode1 = new System.Windows.Forms.TextBox();
            this.txtacctcode2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btnjrn = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvpayment
            // 
            resources.ApplyResources(this.dgvpayment, "dgvpayment");
            this.dgvpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayment.Name = "dgvpayment";
            this.dgvpayment.RowTemplate.Height = 24;
            this.dgvpayment.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvpayment_RowHeaderMouseClick);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Name = "panel1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvpayment);
            this.panel3.Name = "panel3";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtsearch);
            this.panel2.Name = "panel2";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblbilldate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpbilldate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtuser, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.trno, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbcustomers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbacct2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbalance, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbalance2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtamount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtamount2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtacctcode1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtacctcode2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // lblbilldate
            // 
            resources.ApplyResources(this.lblbilldate, "lblbilldate");
            this.lblbilldate.Name = "lblbilldate";
            // 
            // dtpbilldate
            // 
            resources.ApplyResources(this.dtpbilldate, "dtpbilldate");
            this.dtpbilldate.Name = "dtpbilldate";
            // 
            // txtuser
            // 
            resources.ApplyResources(this.txtuser, "txtuser");
            this.txtuser.Name = "txtuser";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // trno
            // 
            resources.ApplyResources(this.trno, "trno");
            this.trno.Name = "trno";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // cmbcustomers
            // 
            resources.ApplyResources(this.cmbcustomers, "cmbcustomers");
            this.cmbcustomers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbcustomers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbcustomers.FormattingEnabled = true;
            this.cmbcustomers.Name = "cmbcustomers";
            this.cmbcustomers.SelectedIndexChanged += new System.EventHandler(this.cmbcustomers_SelectedIndexChanged);
            // 
            // cmbacct2
            // 
            resources.ApplyResources(this.cmbacct2, "cmbacct2");
            this.cmbacct2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbacct2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbacct2.FormattingEnabled = true;
            this.cmbacct2.Name = "cmbacct2";
            this.cmbacct2.SelectedIndexChanged += new System.EventHandler(this.cmbacct2_SelectedIndexChanged);
            // 
            // txtbalance
            // 
            resources.ApplyResources(this.txtbalance, "txtbalance");
            this.txtbalance.BackColor = System.Drawing.Color.LightGreen;
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.ReadOnly = true;
            // 
            // txtbalance2
            // 
            resources.ApplyResources(this.txtbalance2, "txtbalance2");
            this.txtbalance2.BackColor = System.Drawing.Color.LightGreen;
            this.txtbalance2.Name = "txtbalance2";
            this.txtbalance2.ReadOnly = true;
            // 
            // txtamount
            // 
            resources.ApplyResources(this.txtamount, "txtamount");
            this.txtamount.Name = "txtamount";
            this.txtamount.TextChanged += new System.EventHandler(this.txtamount_TextChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // txtamount2
            // 
            resources.ApplyResources(this.txtamount2, "txtamount2");
            this.txtamount2.Name = "txtamount2";
            // 
            // txtacctcode1
            // 
            resources.ApplyResources(this.txtacctcode1, "txtacctcode1");
            this.txtacctcode1.Name = "txtacctcode1";
            // 
            // txtacctcode2
            // 
            resources.ApplyResources(this.txtacctcode2, "txtacctcode2");
            this.txtacctcode2.Name = "txtacctcode2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Name = "label3";
            // 
            // paneltop
            // 
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.paneltop.Controls.Add(this.btnnew);
            this.paneltop.Controls.Add(this.label3);
            this.paneltop.Controls.Add(this.btnprnt);
            this.paneltop.Controls.Add(this.btnjrn);
            this.paneltop.Controls.Add(this.btnclose);
            this.paneltop.Controls.Add(this.btnsave);
            this.paneltop.Name = "paneltop";
            // 
            // btnnew
            // 
            resources.ApplyResources(this.btnnew, "btnnew");
            this.btnnew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnnew.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnnew.Name = "btnnew";
            this.btnnew.UseVisualStyleBackColor = false;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
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
            // btnjrn
            // 
            resources.ApplyResources(this.btnjrn, "btnjrn");
            this.btnjrn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnjrn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnjrn.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnjrn.Name = "btnjrn";
            this.btnjrn.UseVisualStyleBackColor = false;
            this.btnjrn.Click += new System.EventHandler(this.btnjrn_Click);
            // 
            // btnclose
            // 
            resources.ApplyResources(this.btnclose, "btnclose");
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnclose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclose.Image = global::Supermarket.Properties.Resources.exit;
            this.btnclose.Name = "btnclose";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
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
            // frmrecouncil
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paneltop);
            this.Name = "frmrecouncil";
            this.Load += new System.EventHandler(this.frmrecouncil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvpayment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.ComboBox cmbcustomers;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox trno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btnjrn;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbacct2;
        private System.Windows.Forms.TextBox txtbalance2;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.TextBox txtamount2;
        private System.Windows.Forms.TextBox txtacctcode1;
        private System.Windows.Forms.TextBox txtacctcode2;
    }
}