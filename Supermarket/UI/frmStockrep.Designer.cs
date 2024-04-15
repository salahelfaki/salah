
namespace Supermarket.UI
{
    partial class frmStockrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockrep));
            this.txtcatid = new System.Windows.Forms.TextBox();
            this.dgvstock = new System.Windows.Forms.DataGridView();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbcateg = new System.Windows.Forms.ComboBox();
            this.radcateg = new System.Windows.Forms.RadioButton();
            this.radall = new System.Windows.Forms.RadioButton();
            this.txtsales = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstock)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtcatid
            // 
            resources.ApplyResources(this.txtcatid, "txtcatid");
            this.txtcatid.Name = "txtcatid";
            // 
            // dgvstock
            // 
            resources.ApplyResources(this.dgvstock, "dgvstock");
            this.dgvstock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstock.Name = "dgvstock";
            this.dgvstock.RowTemplate.Height = 24;
            // 
            // txttotal
            // 
            resources.ApplyResources(this.txttotal, "txttotal");
            this.txttotal.Name = "txttotal";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
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
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.cmbcateg);
            this.panel2.Controls.Add(this.radcateg);
            this.panel2.Controls.Add(this.radall);
            this.panel2.Controls.Add(this.txtcatid);
            this.panel2.Name = "panel2";
            // 
            // cmbcateg
            // 
            resources.ApplyResources(this.cmbcateg, "cmbcateg");
            this.cmbcateg.FormattingEnabled = true;
            this.cmbcateg.Name = "cmbcateg";
            this.cmbcateg.SelectedIndexChanged += new System.EventHandler(this.cmbcateg_SelectedIndexChanged);
            // 
            // radcateg
            // 
            resources.ApplyResources(this.radcateg, "radcateg");
            this.radcateg.Checked = true;
            this.radcateg.Name = "radcateg";
            this.radcateg.TabStop = true;
            this.radcateg.UseVisualStyleBackColor = true;
            this.radcateg.CheckedChanged += new System.EventHandler(this.radcateg_CheckedChanged);
            // 
            // radall
            // 
            resources.ApplyResources(this.radall, "radall");
            this.radall.Name = "radall";
            this.radall.UseVisualStyleBackColor = true;
            this.radall.CheckedChanged += new System.EventHandler(this.radall_CheckedChanged);
            // 
            // txtsales
            // 
            resources.ApplyResources(this.txtsales, "txtsales");
            this.txtsales.Name = "txtsales";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtsales, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txttotal, 4, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvstock);
            this.panel3.Name = "panel3";
            // 
            // frmStockrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmStockrep";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmStockrep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstock)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtcatid;
        private System.Windows.Forms.DataGridView dgvstock;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radall;
        private System.Windows.Forms.RadioButton radcateg;
        private System.Windows.Forms.ComboBox cmbcateg;
        private System.Windows.Forms.TextBox txtsales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Panel panel3;
    }
}