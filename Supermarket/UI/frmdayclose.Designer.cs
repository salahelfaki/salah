
namespace Supermarket.UI
{
    partial class frmdayclose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdayclose));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtdiff = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtcard = new System.Windows.Forms.TextBox();
            this.txtcash = new System.Windows.Forms.TextBox();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.lbltype = new System.Windows.Forms.Label();
            this.printDocA4 = new System.Drawing.Printing.PrintDocument();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnprnt = new System.Windows.Forms.Button();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.dgvsalesrep = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.txtdiff);
            this.panel2.Controls.Add(this.txttotal);
            this.panel2.Controls.Add(this.txtcard);
            this.panel2.Controls.Add(this.txtcash);
            this.panel2.Controls.Add(this.dt1);
            this.panel2.Controls.Add(this.lbltype);
            this.panel2.Name = "panel2";
            // 
            // txtdiff
            // 
            resources.ApplyResources(this.txtdiff, "txtdiff");
            this.txtdiff.Name = "txtdiff";
            // 
            // txttotal
            // 
            resources.ApplyResources(this.txttotal, "txttotal");
            this.txttotal.Name = "txttotal";
            // 
            // txtcard
            // 
            resources.ApplyResources(this.txtcard, "txtcard");
            this.txtcard.Name = "txtcard";
            // 
            // txtcash
            // 
            resources.ApplyResources(this.txtcash, "txtcash");
            this.txtcash.Name = "txtcash";
            // 
            // dt1
            // 
            resources.ApplyResources(this.dt1, "dt1");
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Name = "dt1";
            this.dt1.ValueChanged += new System.EventHandler(this.dt1_ValueChanged);
            // 
            // lbltype
            // 
            resources.ApplyResources(this.lbltype, "lbltype");
            this.lbltype.Name = "lbltype";
            // 
            // printDocA4
            // 
            this.printDocA4.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocA4_PrintPage);
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnprntA4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnprnt);
            this.panel1.Name = "panel1";
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
            // printPreview
            // 
            resources.ApplyResources(this.printPreview, "printPreview");
            this.printPreview.Name = "printPreview";
            // 
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // dgvsalesrep
            // 
            resources.ApplyResources(this.dgvsalesrep, "dgvsalesrep");
            this.dgvsalesrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsalesrep.Name = "dgvsalesrep";
            this.dgvsalesrep.RowTemplate.Height = 24;
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.dgvsalesrep);
            this.panel3.Name = "panel3";
            // 
            // frmdayclose
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmdayclose";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtdiff;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtcard;
        private System.Windows.Forms.TextBox txtcash;
        private System.Windows.Forms.DateTimePicker dt1;
        private System.Windows.Forms.Label lbltype;
        private System.Drawing.Printing.PrintDocument printDocA4;
        private System.Windows.Forms.Button btnprntA4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprnt;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.DataGridView dgvsalesrep;
        private System.Windows.Forms.Panel panel3;
    }
}