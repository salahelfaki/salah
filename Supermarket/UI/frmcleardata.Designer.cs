
namespace Supermarket.UI
{
    partial class frmcleardata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcleardata));
            this.checkcateg = new System.Windows.Forms.CheckBox();
            this.checkproducts = new System.Windows.Forms.CheckBox();
            this.checkcustomers = new System.Windows.Forms.CheckBox();
            this.checkSales = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chktables = new System.Windows.Forms.CheckBox();
            this.checkmexpense = new System.Windows.Forms.CheckBox();
            this.checkexpense = new System.Windows.Forms.CheckBox();
            this.checkcrnote = new System.Windows.Forms.CheckBox();
            this.checkpayment = new System.Windows.Forms.CheckBox();
            this.checkpurchase = new System.Windows.Forms.CheckBox();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkcateg
            // 
            resources.ApplyResources(this.checkcateg, "checkcateg");
            this.checkcateg.Name = "checkcateg";
            this.checkcateg.UseVisualStyleBackColor = true;
            this.checkcateg.CheckedChanged += new System.EventHandler(this.checkcateg_CheckedChanged);
            // 
            // checkproducts
            // 
            resources.ApplyResources(this.checkproducts, "checkproducts");
            this.checkproducts.Name = "checkproducts";
            this.checkproducts.UseVisualStyleBackColor = true;
            // 
            // checkcustomers
            // 
            resources.ApplyResources(this.checkcustomers, "checkcustomers");
            this.checkcustomers.Name = "checkcustomers";
            this.checkcustomers.UseVisualStyleBackColor = true;
            // 
            // checkSales
            // 
            resources.ApplyResources(this.checkSales, "checkSales");
            this.checkSales.Name = "checkSales";
            this.checkSales.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Controls.Add(this.chktables);
            this.panel1.Controls.Add(this.checkmexpense);
            this.panel1.Controls.Add(this.checkexpense);
            this.panel1.Controls.Add(this.checkcrnote);
            this.panel1.Controls.Add(this.checkpayment);
            this.panel1.Controls.Add(this.checkpurchase);
            this.panel1.Controls.Add(this.checkcateg);
            this.panel1.Controls.Add(this.checkproducts);
            this.panel1.Controls.Add(this.checkcustomers);
            this.panel1.Controls.Add(this.checkSales);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // chktables
            // 
            resources.ApplyResources(this.chktables, "chktables");
            this.chktables.Name = "chktables";
            this.chktables.UseVisualStyleBackColor = true;
            this.chktables.CheckedChanged += new System.EventHandler(this.chktables_CheckedChanged);
            // 
            // checkmexpense
            // 
            resources.ApplyResources(this.checkmexpense, "checkmexpense");
            this.checkmexpense.Name = "checkmexpense";
            this.checkmexpense.UseVisualStyleBackColor = true;
            // 
            // checkexpense
            // 
            resources.ApplyResources(this.checkexpense, "checkexpense");
            this.checkexpense.Name = "checkexpense";
            this.checkexpense.UseVisualStyleBackColor = true;
            // 
            // checkcrnote
            // 
            resources.ApplyResources(this.checkcrnote, "checkcrnote");
            this.checkcrnote.Name = "checkcrnote";
            this.checkcrnote.UseVisualStyleBackColor = true;
            // 
            // checkpayment
            // 
            resources.ApplyResources(this.checkpayment, "checkpayment");
            this.checkpayment.Name = "checkpayment";
            this.checkpayment.UseVisualStyleBackColor = true;
            // 
            // checkpurchase
            // 
            resources.ApplyResources(this.checkpurchase, "checkpurchase");
            this.checkpurchase.Name = "checkpurchase";
            this.checkpurchase.UseVisualStyleBackColor = true;
            // 
            // btncancel
            // 
            resources.ApplyResources(this.btncancel, "btncancel");
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btncancel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncancel.Name = "btncancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnok
            // 
            resources.ApplyResources(this.btnok, "btnok");
            this.btnok.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnok.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnok.Name = "btnok";
            this.btnok.UseVisualStyleBackColor = false;
            this.btnok.Click += new System.EventHandler(this.btnok_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // frmcleardata
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnok);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmcleardata";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkcateg;
        private System.Windows.Forms.CheckBox checkproducts;
        private System.Windows.Forms.CheckBox checkcustomers;
        private System.Windows.Forms.CheckBox checkSales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkmexpense;
        private System.Windows.Forms.CheckBox checkexpense;
        private System.Windows.Forms.CheckBox checkcrnote;
        private System.Windows.Forms.CheckBox checkpayment;
        private System.Windows.Forms.CheckBox checkpurchase;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chktables;
    }
}