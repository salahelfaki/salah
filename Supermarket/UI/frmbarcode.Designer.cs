
namespace Supermarket.UI
{
    partial class frmbarcode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmbarcode));
            this.btncreate = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.txtbarcode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvproduct = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.prntprevDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbprinters = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btncreate
            // 
            this.btncreate.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.btncreate, "btncreate");
            this.btncreate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btncreate.Name = "btncreate";
            this.btncreate.UseVisualStyleBackColor = false;
            this.btncreate.Click += new System.EventHandler(this.txtgenerate_Click);
            // 
            // btnprint
            // 
            this.btnprint.BackColor = System.Drawing.Color.DodgerBlue;
            resources.ApplyResources(this.btnprint, "btnprint");
            this.btnprint.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnprint.Name = "btnprint";
            this.btnprint.UseVisualStyleBackColor = false;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // txtbarcode
            // 
            resources.ApplyResources(this.txtbarcode, "txtbarcode");
            this.txtbarcode.Name = "txtbarcode";
            this.txtbarcode.TextChanged += new System.EventHandler(this.txtbarcode_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.GhostWhite;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvproduct);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // dgvproduct
            // 
            this.dgvproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvproduct, "dgvproduct");
            this.dgvproduct.Name = "dgvproduct";
            this.dgvproduct.RowTemplate.Height = 24;
            this.dgvproduct.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvproduct_RowHeaderMouseClick);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtname
            // 
            resources.ApplyResources(this.txtname, "txtname");
            this.txtname.Name = "txtname";
            // 
            // lbl
            // 
            resources.ApplyResources(this.lbl, "lbl");
            this.lbl.Name = "lbl";
            // 
            // txtsearch
            // 
            resources.ApplyResources(this.txtsearch, "txtsearch");
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // prntprevDialog
            // 
            resources.ApplyResources(this.prntprevDialog, "prntprevDialog");
            this.prntprevDialog.Name = "prntprevDialog";
            // 
            // txtqty
            // 
            resources.ApplyResources(this.txtqty, "txtqty");
            this.txtqty.Name = "txtqty";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cmbprinters
            // 
            this.cmbprinters.FormattingEnabled = true;
            resources.ApplyResources(this.cmbprinters, "cmbprinters");
            this.cmbprinters.Name = "cmbprinters";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtqty);
            this.groupBox1.Controls.Add(this.txtbarcode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbprinters);
            this.groupBox1.Controls.Add(this.btncreate);
            this.groupBox1.Controls.Add(this.btnprint);
            this.groupBox1.Controls.Add(this.txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbl);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // frmbarcode
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmbarcode";
            this.Load += new System.EventHandler(this.frmbarcode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvproduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncreate;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.TextBox txtbarcode;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvproduct;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.PrintPreviewDialog prntprevDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.ComboBox cmbprinters;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}