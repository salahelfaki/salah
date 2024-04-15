
namespace Supermarket.UI
{
    partial class frmaccttrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmaccttrep));
            this.label8 = new System.Windows.Forms.Label();
            this.dgvitemrep = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcrtotal = new System.Windows.Forms.TextBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.cmbacctname = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.txtdbtotal = new System.Windows.Forms.TextBox();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.dt2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // dgvitemrep
            // 
            resources.ApplyResources(this.dgvitemrep, "dgvitemrep");
            this.dgvitemrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitemrep.Name = "dgvitemrep";
            this.dgvitemrep.RowTemplate.Height = 24;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtcrtotal
            // 
            resources.ApplyResources(this.txtcrtotal, "txtcrtotal");
            this.txtcrtotal.Name = "txtcrtotal";
            // 
            // cmbacctname
            // 
            resources.ApplyResources(this.cmbacctname, "cmbacctname");
            this.cmbacctname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbacctname.FormattingEnabled = true;
            this.cmbacctname.Name = "cmbacctname";
            this.cmbacctname.SelectedIndexChanged += new System.EventHandler(this.cmbacctname_SelectedIndexChanged);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnprint);
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Name = "panel1";
            // 
            // btnprint
            // 
            resources.ApplyResources(this.btnprint, "btnprint");
            this.btnprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.btnprint.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnprint.Image = global::Supermarket.Properties.Resources.Printer;
            this.btnprint.Name = "btnprint";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
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
            // txtdbtotal
            // 
            resources.ApplyResources(this.txtdbtotal, "txtdbtotal");
            this.txtdbtotal.Name = "txtdbtotal";
            // 
            // txtbalance
            // 
            resources.ApplyResources(this.txtbalance, "txtbalance");
            this.txtbalance.Name = "txtbalance";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            // 
            // dt1
            // 
            resources.ApplyResources(this.dt1, "dt1");
            this.dt1.Name = "dt1";
            // 
            // dt2
            // 
            resources.ApplyResources(this.dt2, "dt2");
            this.dt2.Name = "dt2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = global::Supermarket.Properties.Resources.Printer;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmaccttrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dt2);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.txtdbtotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbacctname);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvitemrep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcrtotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmaccttrep";
            this.Load += new System.EventHandler(this.frmaccttrep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvitemrep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcrtotal;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.ComboBox cmbacctname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.TextBox txtdbtotal;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.DateTimePicker dt2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
    }
}