
namespace Supermarket.UI
{
    partial class frmmexpense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmexpense));
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvmexpense = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtrent = new System.Windows.Forms.TextBox();
            this.txtwater = new System.Windows.Forms.TextBox();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtelectricity = new System.Windows.Forms.TextBox();
            this.txtsalary = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtothers = new System.Windows.Forms.TextBox();
            this.txtmonth = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.txtyear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dpicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmexpense)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.dgvmexpense);
            this.panel4.Name = "panel4";
            // 
            // dgvmexpense
            // 
            resources.ApplyResources(this.dgvmexpense, "dgvmexpense");
            this.dgvmexpense.AllowUserToAddRows = false;
            this.dgvmexpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmexpense.Name = "dgvmexpense";
            this.dgvmexpense.RowTemplate.Height = 24;
            this.dgvmexpense.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvmexpense_RowHeaderMouseClick);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label8.Name = "label8";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.btnexit);
            this.panel3.Controls.Add(this.panel1);
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
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
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
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtrent
            // 
            resources.ApplyResources(this.txtrent, "txtrent");
            this.txtrent.Name = "txtrent";
            this.txtrent.Validated += new System.EventHandler(this.txtrent_Validated);
            // 
            // txtwater
            // 
            resources.ApplyResources(this.txtwater, "txtwater");
            this.txtwater.Name = "txtwater";
            this.txtwater.Validated += new System.EventHandler(this.txtwater_Validated);
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtelectricity
            // 
            resources.ApplyResources(this.txtelectricity, "txtelectricity");
            this.txtelectricity.Name = "txtelectricity";
            this.txtelectricity.Validated += new System.EventHandler(this.txtelectricity_Validated);
            // 
            // txtsalary
            // 
            resources.ApplyResources(this.txtsalary, "txtsalary");
            this.txtsalary.Name = "txtsalary";
            this.txtsalary.Validated += new System.EventHandler(this.txtsalary_Validated);
            // 
            // lblid
            // 
            resources.ApplyResources(this.lblid, "lblid");
            this.lblid.Name = "lblid";
            // 
            // txttotal
            // 
            resources.ApplyResources(this.txttotal, "txttotal");
            this.txttotal.Name = "txttotal";
            this.txttotal.ReadOnly = true;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtothers
            // 
            resources.ApplyResources(this.txtothers, "txtothers");
            this.txtothers.Name = "txtothers";
            this.txtothers.Validated += new System.EventHandler(this.txtothers_Validated);
            // 
            // txtmonth
            // 
            resources.ApplyResources(this.txtmonth, "txtmonth");
            this.txtmonth.Name = "txtmonth";
            // 
            // txtid
            // 
            resources.ApplyResources(this.txtid, "txtid");
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            // 
            // txtyear
            // 
            resources.ApplyResources(this.txtyear, "txtyear");
            this.txtyear.Name = "txtyear";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // dpicker
            // 
            resources.ApplyResources(this.dpicker, "dpicker");
            this.dpicker.Name = "dpicker";
            this.dpicker.ValueChanged += new System.EventHandler(this.dpicker_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtrent, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtwater, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblpbarcode, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblname, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtelectricity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtsalary, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txttotal, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtothers, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtmonth, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtid, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtyear, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.dpicker, 1, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // frmmexpense
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmmexpense";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmmexpense_Load);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmexpense)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvmexpense;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtrent;
        private System.Windows.Forms.TextBox txtwater;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtelectricity;
        private System.Windows.Forms.TextBox txtsalary;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtothers;
        private System.Windows.Forms.TextBox txtmonth;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.TextBox txtyear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dpicker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
    }
}