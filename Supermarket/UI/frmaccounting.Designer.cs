
namespace Supermarket.UI
{
    partial class frmaccounting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmaccounting));
            this.btnpayment = new System.Windows.Forms.Button();
            this.btncreditnote = new System.Windows.Forms.Button();
            this.paneltop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnjrnl = new System.Windows.Forms.Button();
            this.btnexpense = new System.Windows.Forms.Button();
            this.paneltop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnpayment
            // 
            resources.ApplyResources(this.btnpayment, "btnpayment");
            this.btnpayment.BackColor = System.Drawing.Color.SteelBlue;
            this.btnpayment.FlatAppearance.BorderSize = 0;
            this.btnpayment.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnpayment.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnpayment.Name = "btnpayment";
            this.btnpayment.UseVisualStyleBackColor = false;
            this.btnpayment.Click += new System.EventHandler(this.btnpayment_Click);
            this.btnpayment.Paint += new System.Windows.Forms.PaintEventHandler(this.btnpayment_Paint);
            // 
            // btncreditnote
            // 
            resources.ApplyResources(this.btncreditnote, "btncreditnote");
            this.btncreditnote.BackColor = System.Drawing.Color.SteelBlue;
            this.btncreditnote.FlatAppearance.BorderSize = 0;
            this.btncreditnote.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btncreditnote.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncreditnote.Name = "btncreditnote";
            this.btncreditnote.UseVisualStyleBackColor = false;
            this.btncreditnote.Click += new System.EventHandler(this.btncreditnote_Click);
            this.btncreditnote.Paint += new System.Windows.Forms.PaintEventHandler(this.btncreditnote_Paint);
            // 
            // paneltop
            // 
            resources.ApplyResources(this.paneltop, "paneltop");
            this.paneltop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.paneltop.Controls.Add(this.label1);
            this.paneltop.Controls.Add(this.button2);
            this.paneltop.Name = "paneltop";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Name = "label1";
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnpayment, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btncreditnote, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnjrnl, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnexpense, 1, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnjrnl
            // 
            resources.ApplyResources(this.btnjrnl, "btnjrnl");
            this.btnjrnl.BackColor = System.Drawing.Color.SteelBlue;
            this.btnjrnl.FlatAppearance.BorderSize = 0;
            this.btnjrnl.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnjrnl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnjrnl.Name = "btnjrnl";
            this.btnjrnl.UseVisualStyleBackColor = false;
            this.btnjrnl.Click += new System.EventHandler(this.btnjrnl_Click);
            this.btnjrnl.Paint += new System.Windows.Forms.PaintEventHandler(this.btnjrnl_Paint);
            // 
            // btnexpense
            // 
            resources.ApplyResources(this.btnexpense, "btnexpense");
            this.btnexpense.BackColor = System.Drawing.Color.SteelBlue;
            this.btnexpense.FlatAppearance.BorderSize = 0;
            this.btnexpense.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnexpense.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexpense.Name = "btnexpense";
            this.btnexpense.UseVisualStyleBackColor = false;
            this.btnexpense.Click += new System.EventHandler(this.btnexpense_Click);
            this.btnexpense.Paint += new System.Windows.Forms.PaintEventHandler(this.btnexpense_Paint);
            // 
            // frmaccounting
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.paneltop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmaccounting";
            this.Load += new System.EventHandler(this.frmaccounting_Load);
            this.paneltop.ResumeLayout(false);
            this.paneltop.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnpayment;
        private System.Windows.Forms.Button btncreditnote;
        private System.Windows.Forms.Panel paneltop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnjrnl;
        private System.Windows.Forms.Button btnexpense;
    }
}