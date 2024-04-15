
namespace Supermarket.UI
{
    partial class frmpayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpayment));
            this.label5 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblbilldate = new System.Windows.Forms.Label();
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.trtype = new System.Windows.Forms.TextBox();
            this.cmbcustomers = new System.Windows.Forms.ComboBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.txtcaddress = new System.Windows.Forms.TextBox();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.cmbpayment = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trno = new System.Windows.Forms.TextBox();
            this.txtacctcode = new System.Windows.Forms.TextBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvpayment = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.paneltop = new System.Windows.Forms.Panel();
            this.btnnew = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.btnjrn = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.paneltop.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtbalance
            // 
            resources.ApplyResources(this.txtbalance, "txtbalance");
            this.txtbalance.BackColor = System.Drawing.Color.LightGreen;
            this.txtbalance.Name = "txtbalance";
            this.txtbalance.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblbilldate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtpbilldate, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbalance, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtuser, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.trtype, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.cmbcustomers, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtvatno, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtcaddress, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtamount, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbpayment, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.trno, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtacctcode, 2, 1);
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
            // trtype
            // 
            resources.ApplyResources(this.trtype, "trtype");
            this.trtype.Name = "trtype";
            this.trtype.ReadOnly = true;
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
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtvatno
            // 
            resources.ApplyResources(this.txtvatno, "txtvatno");
            this.txtvatno.Name = "txtvatno";
            this.txtvatno.ReadOnly = true;
            // 
            // txtcaddress
            // 
            resources.ApplyResources(this.txtcaddress, "txtcaddress");
            this.txtcaddress.Name = "txtcaddress";
            this.txtcaddress.ReadOnly = true;
            // 
            // txtamount
            // 
            resources.ApplyResources(this.txtamount, "txtamount");
            this.txtamount.Name = "txtamount";
            // 
            // cmbpayment
            // 
            resources.ApplyResources(this.cmbpayment, "cmbpayment");
            this.cmbpayment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbpayment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbpayment.FormattingEnabled = true;
            this.cmbpayment.Name = "cmbpayment";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
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
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // trno
            // 
            resources.ApplyResources(this.trno, "trno");
            this.trno.Name = "trno";
            // 
            // txtacctcode
            // 
            resources.ApplyResources(this.txtacctcode, "txtacctcode");
            this.txtacctcode.Name = "txtacctcode";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvpayment);
            this.panel3.Name = "panel3";
            // 
            // dgvpayment
            // 
            resources.ApplyResources(this.dgvpayment, "dgvpayment");
            this.dgvpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvpayment.Name = "dgvpayment";
            this.dgvpayment.RowTemplate.Height = 24;
            this.dgvpayment.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvpayment_RowHeaderMouseClick);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtsearch);
            this.panel2.Name = "panel2";
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
            // frmpayment
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.paneltop);
            this.Name = "frmpayment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmpayment_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.paneltop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.TextBox trtype;
        private System.Windows.Forms.ComboBox cmbcustomers;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.TextBox txtcaddress;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.ComboBox cmbpayment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox trno;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvpayment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnjrn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.TextBox txtacctcode;
    }
}