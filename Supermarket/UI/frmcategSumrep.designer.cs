
namespace Supermarket.UI
{
    partial class frmcategSumrep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcategSumrep));
            this.dgvitemrep = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.txtpid = new System.Windows.Forms.TextBox();
            this.txtpname = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.prntdocA4 = new System.Drawing.Printing.PrintDocument();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvitemrep
            // 
            resources.ApplyResources(this.dgvitemrep, "dgvitemrep");
            this.dgvitemrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitemrep.Name = "dgvitemrep";
            this.dgvitemrep.RowTemplate.Height = 24;
            this.dgvitemrep.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvitemrep_RowHeaderMouseDoubleClick);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtsubtotal
            // 
            resources.ApplyResources(this.txtsubtotal, "txtsubtotal");
            this.txtsubtotal.ForeColor = System.Drawing.Color.Red;
            this.txtsubtotal.Name = "txtsubtotal";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // date2
            // 
            resources.ApplyResources(this.date2, "date2");
            this.date2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date2.Name = "date2";
            this.date2.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // date1
            // 
            resources.ApplyResources(this.date1, "date1");
            this.date1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.date1.Name = "date1";
            this.date1.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // printPreview
            // 
            resources.ApplyResources(this.printPreview, "printPreview");
            this.printPreview.Name = "printPreview";
            this.printPreview.Load += new System.EventHandler(this.printPreview_Load);
            // 
            // txtpid
            // 
            resources.ApplyResources(this.txtpid, "txtpid");
            this.txtpid.Name = "txtpid";
            // 
            // txtpname
            // 
            resources.ApplyResources(this.txtpname, "txtpname");
            this.txtpname.Name = "txtpname";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnprntA4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
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
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.txtpname);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtpid);
            this.panel2.Controls.Add(this.date1);
            this.panel2.Controls.Add(this.date2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvitemrep);
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtsubtotal);
            this.panel4.Name = "panel4";
            // 
            // frmcategSumrep
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmcategSumrep";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmitemsalerep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvitemrep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        
        private System.Windows.Forms.DataGridView dgvitemrep;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.TextBox txtpid;
        private System.Windows.Forms.TextBox txtpname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument prntdocA4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}