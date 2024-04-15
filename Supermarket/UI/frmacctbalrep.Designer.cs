
namespace Supermarket.UI
{
    partial class frmacctbalrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmacctbalrep));
            this.dgvitemrep = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcrtotal = new System.Windows.Forms.TextBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbalance = new System.Windows.Forms.TextBox();
            this.txtdbtotal = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprint = new System.Windows.Forms.Button();
            this.btnclose = new System.Windows.Forms.Button();
            this.cmbacctname = new System.Windows.Forms.ComboBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtbalance
            // 
            resources.ApplyResources(this.txtbalance, "txtbalance");
            this.txtbalance.Name = "txtbalance";
            // 
            // txtdbtotal
            // 
            resources.ApplyResources(this.txtdbtotal, "txtdbtotal");
            this.txtdbtotal.Name = "txtdbtotal";
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
            // cmbacctname
            // 
            resources.ApplyResources(this.cmbacctname, "cmbacctname");
            this.cmbacctname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbacctname.FormattingEnabled = true;
            this.cmbacctname.Name = "cmbacctname";
            // 
            // printPreviewDialog1
            // 
            resources.ApplyResources(this.printPreviewDialog1, "printPreviewDialog1");
            this.printPreviewDialog1.Name = "printPreviewDialog1";
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
            // frmacctbalrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.dgvitemrep);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtcrtotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbalance);
            this.Controls.Add(this.txtdbtotal);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbacctname);
            this.Name = "frmacctbalrep";
            this.Load += new System.EventHandler(this.frmacctbalrep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvitemrep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcrtotal;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbalance;
        private System.Windows.Forms.TextBox txtdbtotal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.ComboBox cmbacctname;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button button1;
    }
}