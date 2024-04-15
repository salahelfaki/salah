
namespace Supermarket.UI
{
    partial class frmfinalrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmfinalrep));
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnsuppliers = new System.Windows.Forms.Button();
            this.btncustomers = new System.Windows.Forms.Button();
            this.btncard = new System.Windows.Forms.Button();
            this.btncash = new System.Windows.Forms.Button();
            this.btnexpense = new System.Windows.Forms.Button();
            this.btnpurchase = new System.Windows.Forms.Button();
            this.balcustomers = new System.Windows.Forms.TextBox();
            this.crcustomers = new System.Windows.Forms.TextBox();
            this.dbcustomers = new System.Windows.Forms.TextBox();
            this.balcard = new System.Windows.Forms.TextBox();
            this.crcard = new System.Windows.Forms.TextBox();
            this.dbcard = new System.Windows.Forms.TextBox();
            this.balcash = new System.Windows.Forms.TextBox();
            this.crcash = new System.Windows.Forms.TextBox();
            this.dbcash = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dbsuppliers = new System.Windows.Forms.TextBox();
            this.crsuppliers = new System.Windows.Forms.TextBox();
            this.balsuppliers = new System.Windows.Forms.TextBox();
            this.btnsales = new System.Windows.Forms.Button();
            this.balsales = new System.Windows.Forms.TextBox();
            this.balpurchase = new System.Windows.Forms.TextBox();
            this.balexpense = new System.Windows.Forms.TextBox();
            this.txtnet = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.crvat = new System.Windows.Forms.TextBox();
            this.dbvat = new System.Windows.Forms.TextBox();
            this.balvat = new System.Windows.Forms.TextBox();
            this.btnvat = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // date2
            // 
            resources.ApplyResources(this.date2, "date2");
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Name = "date2";
            this.date2.ValueChanged += new System.EventHandler(this.date2_ValueChanged);
            // 
            // date1
            // 
            resources.ApplyResources(this.date1, "date1");
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Name = "date1";
            this.date1.ValueChanged += new System.EventHandler(this.date1_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.date2);
            this.panel2.Controls.Add(this.date1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Name = "panel2";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.btnsuppliers, 4, 9);
            this.tableLayoutPanel2.Controls.Add(this.btncustomers, 4, 8);
            this.tableLayoutPanel2.Controls.Add(this.btncard, 4, 7);
            this.tableLayoutPanel2.Controls.Add(this.btncash, 4, 6);
            this.tableLayoutPanel2.Controls.Add(this.btnexpense, 4, 3);
            this.tableLayoutPanel2.Controls.Add(this.btnpurchase, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.balcustomers, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.crcustomers, 2, 8);
            this.tableLayoutPanel2.Controls.Add(this.dbcustomers, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.balcard, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.crcard, 2, 7);
            this.tableLayoutPanel2.Controls.Add(this.dbcard, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.balcash, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.crcash, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.dbcash, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label17, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label16, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label15, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label14, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.dbsuppliers, 1, 9);
            this.tableLayoutPanel2.Controls.Add(this.crsuppliers, 2, 9);
            this.tableLayoutPanel2.Controls.Add(this.balsuppliers, 3, 9);
            this.tableLayoutPanel2.Controls.Add(this.btnsales, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.balsales, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.balpurchase, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.balexpense, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtnet, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.crvat, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.dbvat, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.balvat, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnvat, 4, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // btnsuppliers
            // 
            resources.ApplyResources(this.btnsuppliers, "btnsuppliers");
            this.btnsuppliers.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnsuppliers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsuppliers.Name = "btnsuppliers";
            this.btnsuppliers.UseVisualStyleBackColor = false;
            // 
            // btncustomers
            // 
            resources.ApplyResources(this.btncustomers, "btncustomers");
            this.btncustomers.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncustomers.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncustomers.Name = "btncustomers";
            this.btncustomers.UseVisualStyleBackColor = false;
            // 
            // btncard
            // 
            resources.ApplyResources(this.btncard, "btncard");
            this.btncard.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncard.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncard.Name = "btncard";
            this.btncard.UseVisualStyleBackColor = false;
            // 
            // btncash
            // 
            resources.ApplyResources(this.btncash, "btncash");
            this.btncash.BackColor = System.Drawing.Color.RoyalBlue;
            this.btncash.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btncash.Name = "btncash";
            this.btncash.UseVisualStyleBackColor = false;
            // 
            // btnexpense
            // 
            resources.ApplyResources(this.btnexpense, "btnexpense");
            this.btnexpense.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnexpense.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnexpense.Name = "btnexpense";
            this.btnexpense.UseVisualStyleBackColor = false;
            // 
            // btnpurchase
            // 
            resources.ApplyResources(this.btnpurchase, "btnpurchase");
            this.btnpurchase.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnpurchase.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnpurchase.Name = "btnpurchase";
            this.btnpurchase.UseVisualStyleBackColor = false;
            // 
            // balcustomers
            // 
            resources.ApplyResources(this.balcustomers, "balcustomers");
            this.balcustomers.Name = "balcustomers";
            // 
            // crcustomers
            // 
            resources.ApplyResources(this.crcustomers, "crcustomers");
            this.crcustomers.Name = "crcustomers";
            // 
            // dbcustomers
            // 
            resources.ApplyResources(this.dbcustomers, "dbcustomers");
            this.dbcustomers.Name = "dbcustomers";
            // 
            // balcard
            // 
            resources.ApplyResources(this.balcard, "balcard");
            this.balcard.Name = "balcard";
            // 
            // crcard
            // 
            resources.ApplyResources(this.crcard, "crcard");
            this.crcard.Name = "crcard";
            // 
            // dbcard
            // 
            resources.ApplyResources(this.dbcard, "dbcard");
            this.dbcard.Name = "dbcard";
            // 
            // balcash
            // 
            resources.ApplyResources(this.balcash, "balcash");
            this.balcash.Name = "balcash";
            // 
            // crcash
            // 
            resources.ApplyResources(this.crcash, "crcash");
            this.crcash.Name = "crcash";
            // 
            // dbcash
            // 
            resources.ApplyResources(this.dbcash, "dbcash");
            this.dbcash.Name = "dbcash";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dbsuppliers
            // 
            resources.ApplyResources(this.dbsuppliers, "dbsuppliers");
            this.dbsuppliers.Name = "dbsuppliers";
            // 
            // crsuppliers
            // 
            resources.ApplyResources(this.crsuppliers, "crsuppliers");
            this.crsuppliers.Name = "crsuppliers";
            // 
            // balsuppliers
            // 
            resources.ApplyResources(this.balsuppliers, "balsuppliers");
            this.balsuppliers.Name = "balsuppliers";
            // 
            // btnsales
            // 
            resources.ApplyResources(this.btnsales, "btnsales");
            this.btnsales.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnsales.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnsales.Name = "btnsales";
            this.btnsales.UseVisualStyleBackColor = false;
            // 
            // balsales
            // 
            resources.ApplyResources(this.balsales, "balsales");
            this.balsales.Name = "balsales";
            // 
            // balpurchase
            // 
            resources.ApplyResources(this.balpurchase, "balpurchase");
            this.balpurchase.Name = "balpurchase";
            // 
            // balexpense
            // 
            resources.ApplyResources(this.balexpense, "balexpense");
            this.balexpense.Name = "balexpense";
            // 
            // txtnet
            // 
            resources.ApplyResources(this.txtnet, "txtnet");
            this.txtnet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtnet.Name = "txtnet";
            this.txtnet.TextChanged += new System.EventHandler(this.txtnet_TextChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // crvat
            // 
            resources.ApplyResources(this.crvat, "crvat");
            this.crvat.Name = "crvat";
            // 
            // dbvat
            // 
            resources.ApplyResources(this.dbvat, "dbvat");
            this.dbvat.Name = "dbvat";
            // 
            // balvat
            // 
            resources.ApplyResources(this.balvat, "balvat");
            this.balvat.Name = "balvat";
            // 
            // btnvat
            // 
            resources.ApplyResources(this.btnvat, "btnvat");
            this.btnvat.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnvat.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnvat.Name = "btnvat";
            this.btnvat.UseVisualStyleBackColor = false;
            // 
            // btnexport
            // 
            resources.ApplyResources(this.btnexport, "btnexport");
            this.btnexport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnexport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnexport.Name = "btnexport";
            this.btnexport.UseVisualStyleBackColor = false;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnexport);
            this.panel1.Controls.Add(this.btnprntA4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnprnt);
            this.panel1.Name = "panel1";
            // 
            // btnprntA4
            // 
            resources.ApplyResources(this.btnprntA4, "btnprntA4");
            this.btnprntA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnprntA4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprntA4.Name = "btnprntA4";
            this.btnprntA4.UseVisualStyleBackColor = false;
            this.btnprntA4.Click += new System.EventHandler(this.btnprntA4_Click);
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
            // btnprnt
            // 
            resources.ApplyResources(this.btnprnt, "btnprnt");
            this.btnprnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnprnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprnt.Name = "btnprnt";
            this.btnprnt.UseVisualStyleBackColor = false;
            this.btnprnt.Click += new System.EventHandler(this.btnprnt_Click);
            // 
            // frmfinalrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmfinalrep";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmsalesrep_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnsuppliers;
        private System.Windows.Forms.Button btncustomers;
        private System.Windows.Forms.Button btncard;
        private System.Windows.Forms.Button btncash;
        private System.Windows.Forms.Button btnvat;
        private System.Windows.Forms.Button btnexpense;
        private System.Windows.Forms.Button btnpurchase;
        private System.Windows.Forms.TextBox balcustomers;
        private System.Windows.Forms.TextBox crcustomers;
        private System.Windows.Forms.TextBox dbcustomers;
        private System.Windows.Forms.TextBox balcard;
        private System.Windows.Forms.TextBox crcard;
        private System.Windows.Forms.TextBox dbcard;
        private System.Windows.Forms.TextBox balcash;
        private System.Windows.Forms.TextBox crcash;
        private System.Windows.Forms.TextBox dbcash;
        private System.Windows.Forms.TextBox txtnet;
        private System.Windows.Forms.TextBox balvat;
        private System.Windows.Forms.TextBox balexpense;
        private System.Windows.Forms.TextBox balpurchase;
        private System.Windows.Forms.TextBox balsales;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbsuppliers;
        private System.Windows.Forms.TextBox crsuppliers;
        private System.Windows.Forms.TextBox balsuppliers;
        private System.Windows.Forms.Button btnsales;
        private System.Windows.Forms.TextBox crvat;
        private System.Windows.Forms.TextBox dbvat;
    }
}