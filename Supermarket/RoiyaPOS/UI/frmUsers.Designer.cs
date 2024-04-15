namespace supermarket.UI
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblfirstname = new System.Windows.Forms.Label();
            this.txtfirstname = new System.Windows.Forms.TextBox();
            this.txtlastname = new System.Windows.Forms.TextBox();
            this.lbllastname = new System.Windows.Forms.Label();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.lblpassword = new System.Windows.Forms.Label();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.lblcontact = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblgender = new System.Windows.Forms.Label();
            this.txtgender = new System.Windows.Forms.ComboBox();
            this.txtusertype = new System.Windows.Forms.ComboBox();
            this.lblusertype = new System.Windows.Forms.Label();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.lbluserid = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.dgvusers = new System.Windows.Forms.DataGridView();
            this.lblsearch = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).BeginInit();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(1013, 34);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(973, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Users";
            // 
            // lblfirstname
            // 
            this.lblfirstname.AutoSize = true;
            this.lblfirstname.Location = new System.Drawing.Point(12, 84);
            this.lblfirstname.Name = "lblfirstname";
            this.lblfirstname.Size = new System.Drawing.Size(76, 17);
            this.lblfirstname.TabIndex = 1;
            this.lblfirstname.Text = "First Name";
            // 
            // txtfirstname
            // 
            this.txtfirstname.Location = new System.Drawing.Point(110, 81);
            this.txtfirstname.Name = "txtfirstname";
            this.txtfirstname.Size = new System.Drawing.Size(161, 22);
            this.txtfirstname.TabIndex = 2;
            // 
            // txtlastname
            // 
            this.txtlastname.Location = new System.Drawing.Point(110, 119);
            this.txtlastname.Name = "txtlastname";
            this.txtlastname.Size = new System.Drawing.Size(161, 22);
            this.txtlastname.TabIndex = 4;
            // 
            // lbllastname
            // 
            this.lbllastname.AutoSize = true;
            this.lbllastname.Location = new System.Drawing.Point(12, 122);
            this.lbllastname.Name = "lbllastname";
            this.lbllastname.Size = new System.Drawing.Size(76, 17);
            this.lbllastname.TabIndex = 3;
            this.lbllastname.Text = "Last Name";
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(110, 158);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(161, 22);
            this.txtemail.TabIndex = 6;
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(12, 161);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(42, 17);
            this.lblemail.TabIndex = 5;
            this.lblemail.Text = "Email";
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(110, 192);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(161, 22);
            this.txtusername.TabIndex = 8;
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Location = new System.Drawing.Point(12, 195);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(73, 17);
            this.lblusername.TabIndex = 7;
            this.lblusername.Text = "Username";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(110, 227);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(161, 22);
            this.txtpassword.TabIndex = 10;
            // 
            // lblpassword
            // 
            this.lblpassword.AutoSize = true;
            this.lblpassword.Location = new System.Drawing.Point(12, 230);
            this.lblpassword.Name = "lblpassword";
            this.lblpassword.Size = new System.Drawing.Size(69, 17);
            this.lblpassword.TabIndex = 9;
            this.lblpassword.Text = "Password";
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(110, 265);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(161, 22);
            this.txtcontact.TabIndex = 12;
            // 
            // lblcontact
            // 
            this.lblcontact.AutoSize = true;
            this.lblcontact.Location = new System.Drawing.Point(12, 268);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(56, 17);
            this.lblcontact.TabIndex = 11;
            this.lblcontact.Text = "Contact";
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(110, 305);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(161, 73);
            this.txtaddress.TabIndex = 14;
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Location = new System.Drawing.Point(12, 308);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(60, 17);
            this.lbladdress.TabIndex = 13;
            this.lbladdress.Text = "Address";
            // 
            // lblgender
            // 
            this.lblgender.AutoSize = true;
            this.lblgender.Location = new System.Drawing.Point(12, 394);
            this.lblgender.Name = "lblgender";
            this.lblgender.Size = new System.Drawing.Size(56, 17);
            this.lblgender.TabIndex = 15;
            this.lblgender.Text = "Gender";
            // 
            // txtgender
            // 
            this.txtgender.FormattingEnabled = true;
            this.txtgender.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Not Specified"});
            this.txtgender.Location = new System.Drawing.Point(110, 391);
            this.txtgender.Name = "txtgender";
            this.txtgender.Size = new System.Drawing.Size(157, 24);
            this.txtgender.TabIndex = 16;
            // 
            // txtusertype
            // 
            this.txtusertype.FormattingEnabled = true;
            this.txtusertype.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.txtusertype.Location = new System.Drawing.Point(110, 426);
            this.txtusertype.Name = "txtusertype";
            this.txtusertype.Size = new System.Drawing.Size(157, 24);
            this.txtusertype.TabIndex = 18;
            // 
            // lblusertype
            // 
            this.lblusertype.AutoSize = true;
            this.lblusertype.Location = new System.Drawing.Point(12, 429);
            this.lblusertype.Name = "lblusertype";
            this.lblusertype.Size = new System.Drawing.Size(74, 17);
            this.lblusertype.TabIndex = 17;
            this.lblusertype.Text = "User Type";
            // 
            // txtuserid
            // 
            this.txtuserid.Location = new System.Drawing.Point(110, 48);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.ReadOnly = true;
            this.txtuserid.Size = new System.Drawing.Size(161, 22);
            this.txtuserid.TabIndex = 20;
            // 
            // lbluserid
            // 
            this.lbluserid.AutoSize = true;
            this.lbluserid.Location = new System.Drawing.Point(12, 51);
            this.lbluserid.Name = "lbluserid";
            this.lbluserid.Size = new System.Drawing.Size(51, 17);
            this.lbluserid.TabIndex = 19;
            this.lbluserid.Text = "UserID";
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(373, 51);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(565, 22);
            this.txtsearch.TabIndex = 21;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // dgvusers
            // 
            this.dgvusers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvusers.Location = new System.Drawing.Point(308, 79);
            this.dgvusers.Name = "dgvusers";
            this.dgvusers.RowTemplate.Height = 24;
            this.dgvusers.Size = new System.Drawing.Size(693, 371);
            this.dgvusers.TabIndex = 22;
            this.dgvusers.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvusers_RowHeaderMouseDoubleClick);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(316, 56);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(53, 17);
            this.lblsearch.TabIndex = 23;
            this.lblsearch.Text = "Search";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.Color.Transparent;
            this.btnadd.Location = new System.Drawing.Point(152, 501);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(157, 44);
            this.btnadd.TabIndex = 24;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Firebrick;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(554, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 44);
            this.button1.TabIndex = 25;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.LawnGreen;
            this.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnupdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.Black;
            this.btnupdate.Location = new System.Drawing.Point(338, 501);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnupdate.Size = new System.Drawing.Size(157, 44);
            this.btnupdate.TabIndex = 26;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1013, 598);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.dgvusers);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.txtuserid);
            this.Controls.Add(this.lbluserid);
            this.Controls.Add(this.txtusertype);
            this.Controls.Add(this.lblusertype);
            this.Controls.Add(this.txtgender);
            this.Controls.Add(this.lblgender);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.lbladdress);
            this.Controls.Add(this.txtcontact);
            this.Controls.Add(this.lblcontact);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.lblpassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.txtlastname);
            this.Controls.Add(this.lbllastname);
            this.Controls.Add(this.txtfirstname);
            this.Controls.Add(this.lblfirstname);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvusers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblfirstname;
        private System.Windows.Forms.TextBox txtfirstname;
        private System.Windows.Forms.TextBox txtlastname;
        private System.Windows.Forms.Label lbllastname;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Label lblpassword;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblgender;
        private System.Windows.Forms.ComboBox txtgender;
        private System.Windows.Forms.ComboBox txtusertype;
        private System.Windows.Forms.Label lblusertype;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label lbluserid;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.DataGridView dgvusers;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnupdate;
    }
}