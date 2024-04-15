
namespace Supermarket.UI
{
    partial class frmvatrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmvatrep));
            this.label6 = new System.Windows.Forms.Label();
            this.btnshowall = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.date12 = new System.Windows.Forms.DateTimePicker();
            this.lbltype = new System.Windows.Forms.Label();
            this.date11 = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvvat = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtnetvat = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtssubtotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtsvat = new System.Windows.Forms.TextBox();
            this.txtsgrandtotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtpsubtotal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpvat = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtpgrandtotal = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvvat)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // btnshowall
            // 
            resources.ApplyResources(this.btnshowall, "btnshowall");
            this.btnshowall.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnshowall.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnshowall.Name = "btnshowall";
            this.btnshowall.UseVisualStyleBackColor = false;
            this.btnshowall.Click += new System.EventHandler(this.btnshowall_Click);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnshow);
            this.panel1.Controls.Add(this.btnprnt);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Supermarket.Properties.Resources.exit;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnshow
            // 
            resources.ApplyResources(this.btnshow, "btnshow");
            this.btnshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnshow.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnshow.Name = "btnshow";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnprnt
            // 
            resources.ApplyResources(this.btnprnt, "btnprnt");
            this.btnprnt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnprnt.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprnt.Name = "btnprnt";
            this.btnprnt.UseVisualStyleBackColor = false;
            this.btnprnt.Click += new System.EventHandler(this.btnprnt_Click_1);
            // 
            // date12
            // 
            resources.ApplyResources(this.date12, "date12");
            this.date12.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date12.Name = "date12";
            this.date12.ValueChanged += new System.EventHandler(this.date12_ValueChanged);
            // 
            // lbltype
            // 
            resources.ApplyResources(this.lbltype, "lbltype");
            this.lbltype.Name = "lbltype";
            // 
            // date11
            // 
            resources.ApplyResources(this.date11, "date11");
            this.date11.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date11.Name = "date11";
            this.date11.ValueChanged += new System.EventHandler(this.sdate_ValueChanged);
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.txtsearch);
            this.panel2.Controls.Add(this.lbltype);
            this.panel2.Controls.Add(this.date11);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.date12);
            this.panel2.Name = "panel2";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvvat);
            this.panel3.Name = "panel3";
            // 
            // dgvvat
            // 
            resources.ApplyResources(this.dgvvat, "dgvvat");
            this.dgvvat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvvat.Name = "dgvvat";
            this.dgvvat.RowTemplate.Height = 26;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.txtnetvat, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtssubtotal, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtsvat, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtsgrandtotal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtpsubtotal, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtpvat, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtpgrandtotal, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // txtnetvat
            // 
            resources.ApplyResources(this.txtnetvat, "txtnetvat");
            this.txtnetvat.BackColor = System.Drawing.Color.LightGreen;
            this.txtnetvat.Name = "txtnetvat";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // txtssubtotal
            // 
            resources.ApplyResources(this.txtssubtotal, "txtssubtotal");
            this.txtssubtotal.Name = "txtssubtotal";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtsvat
            // 
            resources.ApplyResources(this.txtsvat, "txtsvat");
            this.txtsvat.Name = "txtsvat";
            // 
            // txtsgrandtotal
            // 
            resources.ApplyResources(this.txtsgrandtotal, "txtsgrandtotal");
            this.txtsgrandtotal.Name = "txtsgrandtotal";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtpsubtotal
            // 
            resources.ApplyResources(this.txtpsubtotal, "txtpsubtotal");
            this.txtpsubtotal.Name = "txtpsubtotal";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtpvat
            // 
            resources.ApplyResources(this.txtpvat, "txtpvat");
            this.txtpvat.Name = "txtpvat";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtpgrandtotal
            // 
            resources.ApplyResources(this.txtpgrandtotal, "txtpgrandtotal");
            this.txtpgrandtotal.Name = "txtpgrandtotal";
            // 
            // frmvatrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnshowall);
            this.Name = "frmvatrep";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmvatrep_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvvat)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnshowall;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.DateTimePicker date12;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.DateTimePicker date11;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtnetvat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtssubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtsvat;
        private System.Windows.Forms.TextBox txtsgrandtotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtpsubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpvat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtpgrandtotal;
        private System.Windows.Forms.DataGridView dgvvat;
    }
}