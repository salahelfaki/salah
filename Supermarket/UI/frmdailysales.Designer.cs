
namespace Supermarket.UI
{
    partial class frmdailysales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdailysales));
            this.dgvsalesrep = new System.Windows.Forms.DataGridView();
            this.btnshow = new System.Windows.Forms.Button();
            this.lbltype = new System.Windows.Forms.Label();
            this.dt1 = new System.Windows.Forms.DateTimePicker();
            this.btnprnt = new System.Windows.Forms.Button();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtnet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnprntA4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printDocA4 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvsalesrep
            // 
            resources.ApplyResources(this.dgvsalesrep, "dgvsalesrep");
            this.dgvsalesrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvsalesrep.Name = "dgvsalesrep";
            this.dgvsalesrep.RowTemplate.Height = 24;
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
            // lbltype
            // 
            resources.ApplyResources(this.lbltype, "lbltype");
            this.lbltype.Name = "lbltype";
            // 
            // dt1
            // 
            resources.ApplyResources(this.dt1, "dt1");
            this.dt1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt1.Name = "dt1";
            this.dt1.ValueChanged += new System.EventHandler(this.dt1_ValueChanged);
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
            // printDoc
            // 
            this.printDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDoc_PrintPage);
            // 
            // printPreview
            // 
            resources.ApplyResources(this.printPreview, "printPreview");
            this.printPreview.Name = "printPreview";
            // 
            // txtsubtotal
            // 
            resources.ApplyResources(this.txtsubtotal, "txtsubtotal");
            this.txtsubtotal.Name = "txtsubtotal";
            // 
            // txtgrandtotal
            // 
            resources.ApplyResources(this.txtgrandtotal, "txtgrandtotal");
            this.txtgrandtotal.Name = "txtgrandtotal";
            // 
            // txtnet
            // 
            resources.ApplyResources(this.txtnet, "txtnet");
            this.txtnet.Name = "txtnet";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txtdiscount
            // 
            resources.ApplyResources(this.txtdiscount, "txtdiscount");
            this.txtdiscount.Name = "txtdiscount";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtvat
            // 
            resources.ApplyResources(this.txtvat, "txtvat");
            this.txtvat.Name = "txtvat";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.btnprntA4);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.btnshow);
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
            // printDocA4
            // 
            this.printDocA4.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocA4_PrintPage);
            // 
            // frmdailysales
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtvat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtdiscount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnet);
            this.Controls.Add(this.txtgrandtotal);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.dt1);
            this.Controls.Add(this.dgvsalesrep);
            this.Controls.Add(this.lbltype);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmdailysales";
            this.Load += new System.EventHandler(this.frmdailysales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvsalesrep;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.Button btnprnt;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtnet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnprntA4;
        private System.Drawing.Printing.PrintDocument printDocA4;
        private System.Windows.Forms.DateTimePicker dt1;
    }
}