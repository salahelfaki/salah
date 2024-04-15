namespace supermarket.UI
{
    partial class frmdeacust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdeacust));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.cmbtype = new System.Windows.Forms.ComboBox();
            this.dgvdeacust = new System.Windows.Forms.DataGridView();
            this.lblname = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lbltype = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.lblcontact = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeacust)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(986, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1023, 34);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(414, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dealers / Customers";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnadd.Location = new System.Drawing.Point(226, 480);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(124, 52);
            this.btnadd.TabIndex = 2;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // cmbtype
            // 
            this.cmbtype.FormattingEnabled = true;
            this.cmbtype.Items.AddRange(new object[] {
            "Dealer",
            "Customer"});
            this.cmbtype.Location = new System.Drawing.Point(99, 130);
            this.cmbtype.Name = "cmbtype";
            this.cmbtype.Size = new System.Drawing.Size(190, 29);
            this.cmbtype.TabIndex = 3;
            // 
            // dgvdeacust
            // 
            this.dgvdeacust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdeacust.Location = new System.Drawing.Point(327, 130);
            this.dgvdeacust.Name = "dgvdeacust";
            this.dgvdeacust.RowTemplate.Height = 24;
            this.dgvdeacust.Size = new System.Drawing.Size(642, 310);
            this.dgvdeacust.TabIndex = 4;
            this.dgvdeacust.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvdeacust_RowHeaderMouseClick);
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(12, 176);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(51, 21);
            this.lblname.TabIndex = 5;
            this.lblname.Text = "Name";
            this.lblname.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(99, 173);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(190, 28);
            this.txtname.TabIndex = 6;
            // 
            // lbltype
            // 
            this.lbltype.AutoSize = true;
            this.lbltype.Location = new System.Drawing.Point(12, 130);
            this.lbltype.Name = "lbltype";
            this.lbltype.Size = new System.Drawing.Size(42, 21);
            this.lbltype.TabIndex = 17;
            this.lbltype.Text = "Type";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(99, 222);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(190, 28);
            this.txtemail.TabIndex = 19;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(12, 225);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(53, 21);
            this.lblemail.TabIndex = 18;
            this.lblemail.Text = "E-mail";
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(99, 274);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(190, 28);
            this.txtcontact.TabIndex = 21;
            // 
            // lblcontact
            // 
            this.lblcontact.AutoSize = true;
            this.lblcontact.Location = new System.Drawing.Point(12, 277);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(64, 21);
            this.lblcontact.TabIndex = 20;
            this.lblcontact.Text = "Contact";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(84, 331);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(205, 109);
            this.txtaddress.TabIndex = 23;
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Location = new System.Drawing.Point(12, 334);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(66, 21);
            this.lbladdress.TabIndex = 22;
            this.lbladdress.Text = "Address";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(99, 85);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(190, 28);
            this.txtid.TabIndex = 25;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Location = new System.Drawing.Point(12, 88);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(24, 21);
            this.lblid.TabIndex = 24;
            this.lblid.Text = "ID";
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.Peru;
            this.btnupdate.Location = new System.Drawing.Point(432, 480);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(124, 52);
            this.btnupdate.TabIndex = 26;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.OrangeRed;
            this.btndelete.Location = new System.Drawing.Point(651, 480);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(124, 52);
            this.btndelete.TabIndex = 27;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(385, 96);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(584, 28);
            this.txtsearch.TabIndex = 29;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(332, 99);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(56, 21);
            this.lblsearch.TabIndex = 28;
            this.lblsearch.Text = "Search";
            // 
            // frmdeacust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1023, 555);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.txtcontact);
            this.Controls.Add(this.lblcontact);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.lbltype);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.dgvdeacust);
            this.Controls.Add(this.cmbtype);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmdeacust";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "deacust";
            this.Load += new System.EventHandler(this.frmdeacust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdeacust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.ComboBox cmbtype;
        private System.Windows.Forms.DataGridView dgvdeacust;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lbltype;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblsearch;
    }
}