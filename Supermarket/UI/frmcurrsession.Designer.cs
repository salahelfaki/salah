
namespace Supermarket.UI
{
    partial class frmcurrsession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcurrsession));
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvitemrep = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtedate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbproduct = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtsdate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtpname = new System.Windows.Forms.TextBox();
            this.txtpid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtsno = new System.Windows.Forms.TextBox();
            this.btnprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvitemrep);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // dgvitemrep
            // 
            this.dgvitemrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvitemrep, "dgvitemrep");
            this.dgvitemrep.Name = "dgvitemrep";
            this.dgvitemrep.RowTemplate.Height = 24;
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtedate
            // 
            resources.ApplyResources(this.txtedate, "txtedate");
            this.txtedate.Name = "txtedate";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cmbproduct
            // 
            this.cmbproduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbproduct.FormattingEnabled = true;
            resources.ApplyResources(this.cmbproduct, "cmbproduct");
            this.cmbproduct.Name = "cmbproduct";
            this.cmbproduct.SelectedIndexChanged += new System.EventHandler(this.cmbproduct_SelectedIndexChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtsdate
            // 
            resources.ApplyResources(this.txtsdate, "txtsdate");
            this.txtsdate.Name = "txtsdate";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtpname
            // 
            resources.ApplyResources(this.txtpname, "txtpname");
            this.txtpname.Name = "txtpname";
            // 
            // txtpid
            // 
            resources.ApplyResources(this.txtpid, "txtpid");
            this.txtpid.Name = "txtpid";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtsno
            // 
            resources.ApplyResources(this.txtsno, "txtsno");
            this.txtsno.Name = "txtsno";
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            resources.ApplyResources(this.btnprint, "btnprint");
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprint.Name = "btnprint";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtedate);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtsdate);
            this.panel2.Controls.Add(this.cmbproduct);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtsno);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnprntA4
            // 
            this.btnprntA4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            resources.ApplyResources(this.btnprntA4, "btnprntA4");
            this.btnprntA4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprntA4.Name = "btnprntA4";
            this.btnprntA4.UseVisualStyleBackColor = false;
            this.btnprntA4.Click += new System.EventHandler(this.btnprntA4_Click);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.btnclose, "btnclose");
            this.btnclose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclose.Image = global::Supermarket.Properties.Resources.exit;
            this.btnclose.Name = "btnclose";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnprntA4);
            this.panel1.Controls.Add(this.btnclose);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // frmcurrsession
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txtpname);
            this.Controls.Add(this.txtpid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label8);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmcurrsession";
            this.Load += new System.EventHandler(this.frmcurrsession_Load);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvitemrep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtedate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbproduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtsdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtpname;
        private System.Windows.Forms.TextBox txtpid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtsno;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
    }
}