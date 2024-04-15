namespace supermarket.UI
{
    partial class frmproducts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmproducts));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbldescription = new System.Windows.Forms.Label();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.lblqty = new System.Windows.Forms.Label();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.lblrate = new System.Windows.Forms.Label();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.dgvproducts = new System.Windows.Forms.DataGridView();
            this.lblsearch = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.txtpbarcode = new System.Windows.Forms.TextBox();
            this.lblpcode = new System.Windows.Forms.Label();
            this.txtpcode = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(852, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 31);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(889, 34);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(973, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(350, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "PRODUCTS";
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(122, 161);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(197, 22);
            this.txtname.TabIndex = 4;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(28, 158);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(51, 21);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "Name";
            // 
            // cmbcategory
            // 
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Location = new System.Drawing.Point(122, 196);
            this.cmbcategory.Name = "cmbcategory";
            this.cmbcategory.Size = new System.Drawing.Size(197, 24);
            this.cmbcategory.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 7;
            this.label1.Text = "Category";
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldescription.Location = new System.Drawing.Point(28, 264);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(88, 21);
            this.lbldescription.TabIndex = 9;
            this.lbldescription.Text = "Description";
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(122, 267);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(197, 103);
            this.txtdescription.TabIndex = 8;
            // 
            // lblqty
            // 
            this.lblqty.AutoSize = true;
            this.lblqty.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblqty.Location = new System.Drawing.Point(28, 439);
            this.lblqty.Name = "lblqty";
            this.lblqty.Size = new System.Drawing.Size(70, 21);
            this.lblqty.TabIndex = 13;
            this.lblqty.Text = "Quantity";
            this.lblqty.Visible = false;
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(122, 438);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(197, 22);
            this.txtqty.TabIndex = 12;
            this.txtqty.Visible = false;
            // 
            // lblrate
            // 
            this.lblrate.AutoSize = true;
            this.lblrate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrate.Location = new System.Drawing.Point(28, 387);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(41, 21);
            this.lblrate.TabIndex = 15;
            this.lblrate.Text = "Rate";
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(122, 390);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(197, 22);
            this.txtrate.TabIndex = 14;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(28, 97);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(83, 21);
            this.lblid.TabIndex = 17;
            this.lblid.Text = "Product ID";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(122, 96);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(197, 22);
            this.txtid.TabIndex = 16;
            // 
            // dgvproducts
            // 
            this.dgvproducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvproducts.Location = new System.Drawing.Point(355, 125);
            this.dgvproducts.Name = "dgvproducts";
            this.dgvproducts.RowTemplate.Height = 24;
            this.dgvproducts.Size = new System.Drawing.Size(508, 335);
            this.dgvproducts.TabIndex = 18;
            this.dgvproducts.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvproducts_RowHeaderMouseClick);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(356, 98);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(56, 21);
            this.lblsearch.TabIndex = 20;
            this.lblsearch.Text = "Search";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(418, 97);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(445, 22);
            this.txtsearch.TabIndex = 19;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnadd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(172, 500);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(137, 48);
            this.btnadd.TabIndex = 21;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnupdate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(355, 500);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(137, 48);
            this.btnupdate.TabIndex = 22;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Red;
            this.btndelete.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(573, 500);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(137, 48);
            this.btndelete.TabIndex = 23;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // lblpbarcode
            // 
            this.lblpbarcode.AutoSize = true;
            this.lblpbarcode.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpbarcode.Location = new System.Drawing.Point(28, 126);
            this.lblpbarcode.Name = "lblpbarcode";
            this.lblpbarcode.Size = new System.Drawing.Size(68, 21);
            this.lblpbarcode.TabIndex = 25;
            this.lblpbarcode.Text = "BarCode";
            // 
            // txtpbarcode
            // 
            this.txtpbarcode.Location = new System.Drawing.Point(122, 129);
            this.txtpbarcode.Name = "txtpbarcode";
            this.txtpbarcode.Size = new System.Drawing.Size(197, 22);
            this.txtpbarcode.TabIndex = 24;
            // 
            // lblpcode
            // 
            this.lblpcode.AutoSize = true;
            this.lblpcode.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpcode.Location = new System.Drawing.Point(28, 236);
            this.lblpcode.Name = "lblpcode";
            this.lblpcode.Size = new System.Drawing.Size(45, 21);
            this.lblpcode.TabIndex = 27;
            this.lblpcode.Text = "Code";
            // 
            // txtpcode
            // 
            this.txtpcode.Location = new System.Drawing.Point(122, 239);
            this.txtpcode.Name = "txtpcode";
            this.txtpcode.Size = new System.Drawing.Size(197, 22);
            this.txtpcode.TabIndex = 26;
            // 
            // frmproducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(889, 566);
            this.Controls.Add(this.lblpcode);
            this.Controls.Add(this.txtpcode);
            this.Controls.Add(this.lblpbarcode);
            this.Controls.Add(this.txtpbarcode);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.dgvproducts);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblrate);
            this.Controls.Add(this.txtrate);
            this.Controls.Add(this.lblqty);
            this.Controls.Add(this.txtqty);
            this.Controls.Add(this.lbldescription);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbcategory);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmproducts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PRODUCTS";
            this.Load += new System.EventHandler(this.frmproducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvproducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label lblqty;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.DataGridView dgvproducts;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.TextBox txtpbarcode;
        private System.Windows.Forms.Label lblpcode;
        private System.Windows.Forms.TextBox txtpcode;
    }
}