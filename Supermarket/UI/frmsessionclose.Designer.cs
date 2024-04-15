
namespace Supermarket.UI
{
    partial class frmsessionclose
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsessionclose));
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtcash = new System.Windows.Forms.TextBox();
            this.txtdiff = new System.Windows.Forms.TextBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcard = new System.Windows.Forms.TextBox();
            this.printDocA4 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.printPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.dgvsalesrep = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtcash);
            this.panel2.Controls.Add(this.txtdiff);
            this.panel2.Controls.Add(this.txttotal);
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtcard);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // txtcash
            // 
            resources.ApplyResources(this.txtcash, "txtcash");
            this.txtcash.Name = "txtcash";
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
            // txtid
            // 
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Name = "txtid";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtcard
            // 
            resources.ApplyResources(this.txtcard, "txtcard");
            this.txtcard.Name = "txtcard";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(139)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = global::Supermarket.Properties.Resources.exit;
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // printPreview
            // 
            resources.ApplyResources(this.printPreview, "printPreview");
            this.printPreview.Name = "printPreview";
            // 
            // dgvsalesrep
            // 
            this.dgvsalesrep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dgvsalesrep, "dgvsalesrep");
            this.dgvsalesrep.Name = "dgvsalesrep";
            this.dgvsalesrep.RowTemplate.Height = 24;
            this.dgvsalesrep.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvsalesrep_RowHeaderMouseClick);
            // 
            // frmsessionclose
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.dgvsalesrep);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmsessionclose";
            this.Load += new System.EventHandler(this.frmsessionclose_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvsalesrep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtcash;
        private System.Windows.Forms.TextBox txtdiff;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcard;
        private System.Drawing.Printing.PrintDocument printDocA4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PrintPreviewDialog printPreview;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.DataGridView dgvsalesrep;
    }
}