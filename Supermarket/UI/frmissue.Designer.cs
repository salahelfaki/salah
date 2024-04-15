
namespace Supermarket.UI
{
    partial class frmissue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmissue));
            this.button1 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.cmbitem = new System.Windows.Forms.ComboBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.txtinventory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrate = new System.Windows.Forms.Label();
            this.lblinventory = new System.Windows.Forms.Label();
            this.prntdoc = new System.Drawing.Printing.PrintDocument();
            this.prntDialog = new System.Windows.Forms.PrintDialog();
            this.lblpname = new System.Windows.Forms.Label();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.pnldatagrid = new System.Windows.Forms.Panel();
            this.lbldatagrid = new System.Windows.Forms.Label();
            this.lblproduct = new System.Windows.Forms.Label();
            this.prntPreview = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlproduct = new System.Windows.Forms.Panel();
            this.txtinvdate = new System.Windows.Forms.DateTimePicker();
            this.lblemail = new System.Windows.Forms.Label();
            this.pnldeacust = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblfrm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnremove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.pnldatagrid.SuspendLayout();
            this.pnlproduct.SuspendLayout();
            this.pnldeacust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(229, 608);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 23;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Teal;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Location = new System.Drawing.Point(429, 608);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(143, 40);
            this.btnsave.TabIndex = 24;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(489, 561);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(233, 22);
            this.txtsubtotal.TabIndex = 25;
            this.txtsubtotal.Text = "0.00";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(324, 568);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(69, 17);
            this.lblsubtotal.TabIndex = 13;
            this.lblsubtotal.Text = "Sub Total";
            // 
            // cmbitem
            // 
            this.cmbitem.FormattingEnabled = true;
            this.cmbitem.Location = new System.Drawing.Point(39, 18);
            this.cmbitem.Name = "cmbitem";
            this.cmbitem.Size = new System.Drawing.Size(204, 24);
            this.cmbitem.TabIndex = 1;
            this.cmbitem.SelectedIndexChanged += new System.EventHandler(this.cmbitem_SelectedIndexChanged);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(410, 62);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(81, 39);
            this.btnadd.TabIndex = 3;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(39, 67);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(149, 22);
            this.txtqty.TabIndex = 2;
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(541, 17);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(178, 22);
            this.txtrate.TabIndex = 5;
            // 
            // txtinventory
            // 
            this.txtinventory.Location = new System.Drawing.Point(325, 19);
            this.txtinventory.Name = "txtinventory";
            this.txtinventory.Size = new System.Drawing.Size(143, 22);
            this.txtinventory.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Qty";
            // 
            // lblrate
            // 
            this.lblrate.AutoSize = true;
            this.lblrate.Location = new System.Drawing.Point(492, 21);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(40, 17);
            this.lblrate.TabIndex = 4;
            this.lblrate.Text = "Price";
            // 
            // lblinventory
            // 
            this.lblinventory.AutoSize = true;
            this.lblinventory.Location = new System.Drawing.Point(250, 22);
            this.lblinventory.Name = "lblinventory";
            this.lblinventory.Size = new System.Drawing.Size(66, 17);
            this.lblinventory.TabIndex = 3;
            this.lblinventory.Text = "Inventory";
            // 
            // prntdoc
            // 
            this.prntdoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.prntdoc_PrintPage);
            // 
            // prntDialog
            // 
            this.prntDialog.UseEXDialog = true;
            // 
            // lblpname
            // 
            this.lblpname.AutoSize = true;
            this.lblpname.Location = new System.Drawing.Point(2, 22);
            this.lblpname.Name = "lblpname";
            this.lblpname.Size = new System.Drawing.Size(34, 17);
            this.lblpname.TabIndex = 2;
            this.lblpname.Text = "Item";
            // 
            // dgvaddproduct
            // 
            this.dgvaddproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaddproduct.Location = new System.Drawing.Point(3, 24);
            this.dgvaddproduct.Name = "dgvaddproduct";
            this.dgvaddproduct.RowHeadersWidth = 51;
            this.dgvaddproduct.RowTemplate.Height = 24;
            this.dgvaddproduct.Size = new System.Drawing.Size(735, 294);
            this.dgvaddproduct.TabIndex = 1;
            // 
            // pnldatagrid
            // 
            this.pnldatagrid.Controls.Add(this.dgvaddproduct);
            this.pnldatagrid.Controls.Add(this.lbldatagrid);
            this.pnldatagrid.Location = new System.Drawing.Point(16, 237);
            this.pnldatagrid.Name = "pnldatagrid";
            this.pnldatagrid.Size = new System.Drawing.Size(709, 321);
            this.pnldatagrid.TabIndex = 10;
            // 
            // lbldatagrid
            // 
            this.lbldatagrid.AutoSize = true;
            this.lbldatagrid.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldatagrid.Location = new System.Drawing.Point(2, 1);
            this.lbldatagrid.Name = "lbldatagrid";
            this.lbldatagrid.Size = new System.Drawing.Size(122, 21);
            this.lbldatagrid.TabIndex = 0;
            this.lbldatagrid.Text = "Added Products";
            // 
            // lblproduct
            // 
            this.lblproduct.AutoSize = true;
            this.lblproduct.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblproduct.Location = new System.Drawing.Point(3, 0);
            this.lblproduct.Name = "lblproduct";
            this.lblproduct.Size = new System.Drawing.Size(118, 21);
            this.lblproduct.TabIndex = 0;
            this.lblproduct.Text = "Product Details";
            // 
            // prntPreview
            // 
            this.prntPreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.prntPreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.prntPreview.ClientSize = new System.Drawing.Size(400, 300);
            this.prntPreview.Enabled = true;
            this.prntPreview.Icon = ((System.Drawing.Icon)(resources.GetObject("prntPreview.Icon")));
            this.prntPreview.Name = "prntPreview";
            this.prntPreview.Visible = false;
            // 
            // pnlproduct
            // 
            this.pnlproduct.Controls.Add(this.cmbitem);
            this.pnlproduct.Controls.Add(this.btnadd);
            this.pnlproduct.Controls.Add(this.txtqty);
            this.pnlproduct.Controls.Add(this.txtrate);
            this.pnlproduct.Controls.Add(this.txtinventory);
            this.pnlproduct.Controls.Add(this.label2);
            this.pnlproduct.Controls.Add(this.lblrate);
            this.pnlproduct.Controls.Add(this.lblinventory);
            this.pnlproduct.Controls.Add(this.lblpname);
            this.pnlproduct.Controls.Add(this.lblproduct);
            this.pnlproduct.Location = new System.Drawing.Point(19, 111);
            this.pnlproduct.Name = "pnlproduct";
            this.pnlproduct.Size = new System.Drawing.Size(735, 104);
            this.pnlproduct.TabIndex = 9;
            // 
            // txtinvdate
            // 
            this.txtinvdate.Location = new System.Drawing.Point(120, 18);
            this.txtinvdate.Name = "txtinvdate";
            this.txtinvdate.Size = new System.Drawing.Size(265, 22);
            this.txtinvdate.TabIndex = 12;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(11, 23);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(75, 17);
            this.lblemail.TabIndex = 2;
            this.lblemail.Text = "Issue Date";
            // 
            // pnldeacust
            // 
            this.pnldeacust.Controls.Add(this.txtinvdate);
            this.pnldeacust.Controls.Add(this.lblemail);
            this.pnldeacust.Location = new System.Drawing.Point(16, 49);
            this.pnldeacust.Name = "pnldeacust";
            this.pnldeacust.Size = new System.Drawing.Size(738, 56);
            this.pnldeacust.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(718, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblfrm
            // 
            this.lblfrm.AutoSize = true;
            this.lblfrm.Location = new System.Drawing.Point(295, 3);
            this.lblfrm.Name = "lblfrm";
            this.lblfrm.Size = new System.Drawing.Size(64, 25);
            this.lblfrm.TabIndex = 0;
            this.lblfrm.Text = "Issue";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkTurquoise;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lblfrm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(757, 34);
            this.panel1.TabIndex = 7;
            // 
            // btnremove
            // 
            this.btnremove.BackColor = System.Drawing.Color.Teal;
            this.btnremove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnremove.Location = new System.Drawing.Point(30, 608);
            this.btnremove.Name = "btnremove";
            this.btnremove.Size = new System.Drawing.Size(143, 40);
            this.btnremove.TabIndex = 32;
            this.btnremove.Text = "Remove";
            this.btnremove.UseVisualStyleBackColor = false;
            this.btnremove.Click += new System.EventHandler(this.btnremove_Click);
            // 
            // frmissue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(757, 650);
            this.Controls.Add(this.btnremove);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.pnldatagrid);
            this.Controls.Add(this.txtsubtotal);
            this.Controls.Add(this.pnlproduct);
            this.Controls.Add(this.lblsubtotal);
            this.Controls.Add(this.pnldeacust);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmissue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmissue";
            this.Load += new System.EventHandler(this.frmissue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.pnldatagrid.ResumeLayout(false);
            this.pnldatagrid.PerformLayout();
            this.pnlproduct.ResumeLayout(false);
            this.pnlproduct.PerformLayout();
            this.pnldeacust.ResumeLayout(false);
            this.pnldeacust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.ComboBox cmbitem;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.TextBox txtinventory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.Label lblinventory;
        private System.Drawing.Printing.PrintDocument prntdoc;
        private System.Windows.Forms.PrintDialog prntDialog;
        private System.Windows.Forms.Label lblpname;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.Panel pnldatagrid;
        private System.Windows.Forms.Label lbldatagrid;
        private System.Windows.Forms.Label lblproduct;
        private System.Windows.Forms.PrintPreviewDialog prntPreview;
        private System.Windows.Forms.Panel pnlproduct;
        private System.Windows.Forms.DateTimePicker txtinvdate;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Panel pnldeacust;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblfrm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnremove;
    }
}