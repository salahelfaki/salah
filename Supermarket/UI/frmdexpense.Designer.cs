
namespace Supermarket.UI
{
    partial class frmdexpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdexpense));
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvdexpense = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.lblid = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.dpicker = new System.Windows.Forms.DateTimePicker();
            this.txtid = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdexpense)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.dgvdexpense);
            this.panel4.Name = "panel4";
            // 
            // dgvdexpense
            // 
            resources.ApplyResources(this.dgvdexpense, "dgvdexpense");
            this.dgvdexpense.AllowUserToAddRows = false;
            this.dgvdexpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdexpense.Name = "dgvdexpense";
            this.dgvdexpense.RowTemplate.Height = 24;
            this.dgvdexpense.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdexpense_RowHeaderMouseClick);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Name = "label1";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.btnadd);
            this.panel3.Controls.Add(this.btnupdate);
            this.panel3.Controls.Add(this.btndelete);
            this.panel3.Controls.Add(this.btnclear);
            this.panel3.Name = "panel3";
            // 
            // btnexit
            // 
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnexit.Image = global::Supermarket.Properties.Resources.exit;
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnadd
            // 
            resources.ApplyResources(this.btnadd, "btnadd");
            this.btnadd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnadd.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnadd.Name = "btnadd";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            resources.ApplyResources(this.btndelete, "btndelete");
            this.btndelete.BackColor = System.Drawing.Color.RoyalBlue;
            this.btndelete.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btndelete.Name = "btndelete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnclear
            // 
            resources.ApplyResources(this.btnclear, "btnclear");
            this.btnclear.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnclear.Name = "btnclear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // lblid
            // 
            resources.ApplyResources(this.lblid, "lblid");
            this.lblid.Name = "lblid";
            // 
            // txtamount
            // 
            resources.ApplyResources(this.txtamount, "txtamount");
            this.txtamount.Name = "txtamount";
            // 
            // lblpbarcode
            // 
            resources.ApplyResources(this.lblpbarcode, "lblpbarcode");
            this.lblpbarcode.Name = "lblpbarcode";
            // 
            // lblname
            // 
            resources.ApplyResources(this.lblname, "lblname");
            this.lblname.Name = "lblname";
            // 
            // txtdescription
            // 
            resources.ApplyResources(this.txtdescription, "txtdescription");
            this.txtdescription.Name = "txtdescription";
            // 
            // dpicker
            // 
            resources.ApplyResources(this.dpicker, "dpicker");
            this.dpicker.Name = "dpicker";
            this.dpicker.ValueChanged += new System.EventHandler(this.dpicker_ValueChanged);
            // 
            // txtid
            // 
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.lblid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtamount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblpbarcode, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblname, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtdescription, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dpicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtid, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Name = "panel1";
            // 
            // frmdexpense
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmdexpense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmdexpense_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdexpense)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvdexpense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.DateTimePicker dpicker;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}