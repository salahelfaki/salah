namespace supermarket.UI
{
    partial class frmpurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpurchase));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblfrm = new System.Windows.Forms.Label();
            this.pnldeacust = new System.Windows.Forms.Panel();
            this.txtcustid = new System.Windows.Forms.TextBox();
            this.dtpbilldate = new System.Windows.Forms.DateTimePicker();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtcontact = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.txtname = new System.Windows.Forms.TextBox();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblbilldate = new System.Windows.Forms.Label();
            this.lbladdress = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lblcontact = new System.Windows.Forms.Label();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblsearch = new System.Windows.Forms.Label();
            this.lbldeacust = new System.Windows.Forms.Label();
            this.pnlproduct = new System.Windows.Forms.Panel();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtqty = new System.Windows.Forms.TextBox();
            this.txtrate = new System.Windows.Forms.TextBox();
            this.txtinventory = new System.Windows.Forms.TextBox();
            this.txtpname = new System.Windows.Forms.TextBox();
            this.txtpsearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrate = new System.Windows.Forms.Label();
            this.lblinventory = new System.Windows.Forms.Label();
            this.lblpname = new System.Windows.Forms.Label();
            this.lblpsearch = new System.Windows.Forms.Label();
            this.lblproduct = new System.Windows.Forms.Label();
            this.pnldatagrid = new System.Windows.Forms.Panel();
            this.dgvaddproduct = new System.Windows.Forms.DataGridView();
            this.lbldatagrid = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtreturn = new System.Windows.Forms.TextBox();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.txtgrandtotal = new System.Windows.Forms.TextBox();
            this.txtvat = new System.Windows.Forms.TextBox();
            this.txtdiscount = new System.Windows.Forms.TextBox();
            this.txtsubtotal = new System.Windows.Forms.TextBox();
            this.lblreturn = new System.Windows.Forms.Label();
            this.lblpaid = new System.Windows.Forms.Label();
            this.lblgrandtotal = new System.Windows.Forms.Label();
            this.lblvat = new System.Windows.Forms.Label();
            this.lbldiscount = new System.Windows.Forms.Label();
            this.lblsubtotal = new System.Windows.Forms.Label();
            this.lblpcalc = new System.Windows.Forms.Label();
            this.txtpid = new System.Windows.Forms.TextBox();
            this.prntdoc = new System.Drawing.Printing.PrintDocument();
            this.prntDialog = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnldeacust.SuspendLayout();
            this.pnlproduct.SuspendLayout();
            this.pnldatagrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1328, 3);
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
            this.panel1.Controls.Add(this.lblfrm);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1366, 34);
            this.panel1.TabIndex = 2;
            // 
            // lblfrm
            // 
            this.lblfrm.AutoSize = true;
            this.lblfrm.Location = new System.Drawing.Point(608, 5);
            this.lblfrm.Name = "lblfrm";
            this.lblfrm.Size = new System.Drawing.Size(103, 25);
            this.lblfrm.TabIndex = 0;
            this.lblfrm.Text = "Purchase";
            this.lblfrm.Click += new System.EventHandler(this.label1_Click);
            // 
            // pnldeacust
            // 
            this.pnldeacust.Controls.Add(this.txtcustid);
            this.pnldeacust.Controls.Add(this.dtpbilldate);
            this.pnldeacust.Controls.Add(this.txtaddress);
            this.pnldeacust.Controls.Add(this.txtcontact);
            this.pnldeacust.Controls.Add(this.txtemail);
            this.pnldeacust.Controls.Add(this.txtname);
            this.pnldeacust.Controls.Add(this.txtsearch);
            this.pnldeacust.Controls.Add(this.lblbilldate);
            this.pnldeacust.Controls.Add(this.lbladdress);
            this.pnldeacust.Controls.Add(this.lblname);
            this.pnldeacust.Controls.Add(this.lblcontact);
            this.pnldeacust.Controls.Add(this.lblemail);
            this.pnldeacust.Controls.Add(this.lblsearch);
            this.pnldeacust.Controls.Add(this.lbldeacust);
            this.pnldeacust.Location = new System.Drawing.Point(12, 41);
            this.pnldeacust.Name = "pnldeacust";
            this.pnldeacust.Size = new System.Drawing.Size(1353, 100);
            this.pnldeacust.TabIndex = 3;
            // 
            // txtcustid
            // 
            this.txtcustid.Location = new System.Drawing.Point(988, 60);
            this.txtcustid.Name = "txtcustid";
            this.txtcustid.Size = new System.Drawing.Size(234, 28);
            this.txtcustid.TabIndex = 13;
            this.txtcustid.Visible = false;
            // 
            // dtpbilldate
            // 
            this.dtpbilldate.Location = new System.Drawing.Point(1058, 22);
            this.dtpbilldate.Name = "dtpbilldate";
            this.dtpbilldate.Size = new System.Drawing.Size(265, 28);
            this.dtpbilldate.TabIndex = 12;
            // 
            // txtaddress
            // 
            this.txtaddress.Location = new System.Drawing.Point(724, 22);
            this.txtaddress.Multiline = true;
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.Size = new System.Drawing.Size(234, 70);
            this.txtaddress.TabIndex = 11;
            // 
            // txtcontact
            // 
            this.txtcontact.Location = new System.Drawing.Point(406, 64);
            this.txtcontact.Name = "txtcontact";
            this.txtcontact.Size = new System.Drawing.Size(234, 28);
            this.txtcontact.TabIndex = 10;
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(406, 22);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(234, 28);
            this.txtemail.TabIndex = 9;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(65, 64);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(234, 28);
            this.txtname.TabIndex = 8;
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(65, 22);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(234, 28);
            this.txtsearch.TabIndex = 7;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblbilldate
            // 
            this.lblbilldate.AutoSize = true;
            this.lblbilldate.Location = new System.Drawing.Point(984, 22);
            this.lblbilldate.Name = "lblbilldate";
            this.lblbilldate.Size = new System.Drawing.Size(67, 21);
            this.lblbilldate.TabIndex = 6;
            this.lblbilldate.Text = "Bill Date";
            // 
            // lbladdress
            // 
            this.lbladdress.AutoSize = true;
            this.lbladdress.Location = new System.Drawing.Point(652, 22);
            this.lbladdress.Name = "lbladdress";
            this.lbladdress.Size = new System.Drawing.Size(66, 21);
            this.lbladdress.TabIndex = 5;
            this.lbladdress.Text = "Address";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Location = new System.Drawing.Point(3, 67);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(51, 21);
            this.lblname.TabIndex = 4;
            this.lblname.Text = "Name";
            // 
            // lblcontact
            // 
            this.lblcontact.AutoSize = true;
            this.lblcontact.Location = new System.Drawing.Point(339, 67);
            this.lblcontact.Name = "lblcontact";
            this.lblcontact.Size = new System.Drawing.Size(64, 21);
            this.lblcontact.TabIndex = 3;
            this.lblcontact.Text = "Contact";
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Location = new System.Drawing.Point(339, 22);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(48, 21);
            this.lblemail.TabIndex = 2;
            this.lblemail.Text = "Email";
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Location = new System.Drawing.Point(3, 22);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(56, 21);
            this.lblsearch.TabIndex = 1;
            this.lblsearch.Text = "Search";
            // 
            // lbldeacust
            // 
            this.lbldeacust.AutoSize = true;
            this.lbldeacust.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldeacust.Location = new System.Drawing.Point(3, 1);
            this.lbldeacust.Name = "lbldeacust";
            this.lbldeacust.Size = new System.Drawing.Size(213, 21);
            this.lbldeacust.TabIndex = 0;
            this.lbldeacust.Text = "Dealer and Customer Details";
            // 
            // pnlproduct
            // 
            this.pnlproduct.Controls.Add(this.btnadd);
            this.pnlproduct.Controls.Add(this.txtqty);
            this.pnlproduct.Controls.Add(this.txtrate);
            this.pnlproduct.Controls.Add(this.txtinventory);
            this.pnlproduct.Controls.Add(this.txtpname);
            this.pnlproduct.Controls.Add(this.txtpsearch);
            this.pnlproduct.Controls.Add(this.label2);
            this.pnlproduct.Controls.Add(this.lblrate);
            this.pnlproduct.Controls.Add(this.lblinventory);
            this.pnlproduct.Controls.Add(this.lblpname);
            this.pnlproduct.Controls.Add(this.lblpsearch);
            this.pnlproduct.Controls.Add(this.lblproduct);
            this.pnlproduct.Location = new System.Drawing.Point(14, 159);
            this.pnlproduct.Name = "pnlproduct";
            this.pnlproduct.Size = new System.Drawing.Size(1351, 54);
            this.pnlproduct.TabIndex = 4;
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.PaleGreen;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(1249, 12);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(81, 39);
            this.btnadd.TabIndex = 18;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtqty
            // 
            this.txtqty.Location = new System.Drawing.Point(1035, 18);
            this.txtqty.Name = "txtqty";
            this.txtqty.Size = new System.Drawing.Size(186, 28);
            this.txtqty.TabIndex = 17;
            // 
            // txtrate
            // 
            this.txtrate.Location = new System.Drawing.Point(798, 18);
            this.txtrate.Name = "txtrate";
            this.txtrate.Size = new System.Drawing.Size(186, 28);
            this.txtrate.TabIndex = 16;
            // 
            // txtinventory
            // 
            this.txtinventory.Location = new System.Drawing.Point(569, 18);
            this.txtinventory.Name = "txtinventory";
            this.txtinventory.Size = new System.Drawing.Size(186, 28);
            this.txtinventory.TabIndex = 15;
            // 
            // txtpname
            // 
            this.txtpname.Location = new System.Drawing.Point(304, 18);
            this.txtpname.Name = "txtpname";
            this.txtpname.Size = new System.Drawing.Size(186, 28);
            this.txtpname.TabIndex = 14;
            // 
            // txtpsearch
            // 
            this.txtpsearch.Location = new System.Drawing.Point(63, 18);
            this.txtpsearch.Name = "txtpsearch";
            this.txtpsearch.Size = new System.Drawing.Size(186, 28);
            this.txtpsearch.TabIndex = 13;
            this.txtpsearch.TextChanged += new System.EventHandler(this.txtpsearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(996, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Qty";
            // 
            // lblrate
            // 
            this.lblrate.AutoSize = true;
            this.lblrate.Location = new System.Drawing.Point(761, 21);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(41, 21);
            this.lblrate.TabIndex = 4;
            this.lblrate.Text = "Rate";
            // 
            // lblinventory
            // 
            this.lblinventory.AutoSize = true;
            this.lblinventory.Location = new System.Drawing.Point(494, 21);
            this.lblinventory.Name = "lblinventory";
            this.lblinventory.Size = new System.Drawing.Size(77, 21);
            this.lblinventory.TabIndex = 3;
            this.lblinventory.Text = "Inventory";
            // 
            // lblpname
            // 
            this.lblpname.AutoSize = true;
            this.lblpname.Location = new System.Drawing.Point(255, 21);
            this.lblpname.Name = "lblpname";
            this.lblpname.Size = new System.Drawing.Size(51, 21);
            this.lblpname.TabIndex = 2;
            this.lblpname.Text = "Name";
            // 
            // lblpsearch
            // 
            this.lblpsearch.AutoSize = true;
            this.lblpsearch.Location = new System.Drawing.Point(5, 21);
            this.lblpsearch.Name = "lblpsearch";
            this.lblpsearch.Size = new System.Drawing.Size(56, 21);
            this.lblpsearch.TabIndex = 1;
            this.lblpsearch.Text = "Search";
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
            // pnldatagrid
            // 
            this.pnldatagrid.Controls.Add(this.dgvaddproduct);
            this.pnldatagrid.Controls.Add(this.lbldatagrid);
            this.pnldatagrid.Location = new System.Drawing.Point(13, 219);
            this.pnldatagrid.Name = "pnldatagrid";
            this.pnldatagrid.Size = new System.Drawing.Size(793, 321);
            this.pnldatagrid.TabIndex = 5;
            // 
            // dgvaddproduct
            // 
            this.dgvaddproduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvaddproduct.Location = new System.Drawing.Point(3, 24);
            this.dgvaddproduct.Name = "dgvaddproduct";
            this.dgvaddproduct.RowTemplate.Height = 24;
            this.dgvaddproduct.Size = new System.Drawing.Size(787, 294);
            this.dgvaddproduct.TabIndex = 1;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnsave);
            this.panel2.Controls.Add(this.txtreturn);
            this.panel2.Controls.Add(this.txtpaid);
            this.panel2.Controls.Add(this.txtgrandtotal);
            this.panel2.Controls.Add(this.txtvat);
            this.panel2.Controls.Add(this.txtdiscount);
            this.panel2.Controls.Add(this.txtsubtotal);
            this.panel2.Controls.Add(this.lblreturn);
            this.panel2.Controls.Add(this.lblpaid);
            this.panel2.Controls.Add(this.lblgrandtotal);
            this.panel2.Controls.Add(this.lblvat);
            this.panel2.Controls.Add(this.lbldiscount);
            this.panel2.Controls.Add(this.lblsubtotal);
            this.panel2.Controls.Add(this.lblpcalc);
            this.panel2.Location = new System.Drawing.Point(812, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(553, 318);
            this.panel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(15, 264);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 40);
            this.button1.TabIndex = 25;
            this.button1.Text = "print";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.Teal;
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Location = new System.Drawing.Point(215, 264);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(143, 40);
            this.btnsave.TabIndex = 19;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtreturn
            // 
            this.txtreturn.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturn.ForeColor = System.Drawing.Color.Red;
            this.txtreturn.Location = new System.Drawing.Point(168, 209);
            this.txtreturn.Name = "txtreturn";
            this.txtreturn.ReadOnly = true;
            this.txtreturn.Size = new System.Drawing.Size(233, 44);
            this.txtreturn.TabIndex = 24;
            // 
            // txtpaid
            // 
            this.txtpaid.Location = new System.Drawing.Point(168, 172);
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.Size = new System.Drawing.Size(233, 28);
            this.txtpaid.TabIndex = 23;
            this.txtpaid.TextChanged += new System.EventHandler(this.txtpaid_TextChanged);
            // 
            // txtgrandtotal
            // 
            this.txtgrandtotal.Location = new System.Drawing.Point(168, 135);
            this.txtgrandtotal.Name = "txtgrandtotal";
            this.txtgrandtotal.ReadOnly = true;
            this.txtgrandtotal.Size = new System.Drawing.Size(233, 28);
            this.txtgrandtotal.TabIndex = 22;
            // 
            // txtvat
            // 
            this.txtvat.Location = new System.Drawing.Point(168, 98);
            this.txtvat.Name = "txtvat";
            this.txtvat.Size = new System.Drawing.Size(233, 28);
            this.txtvat.TabIndex = 21;
            this.txtvat.TextChanged += new System.EventHandler(this.txtvat_TextChanged);
            // 
            // txtdiscount
            // 
            this.txtdiscount.Location = new System.Drawing.Point(168, 61);
            this.txtdiscount.Name = "txtdiscount";
            this.txtdiscount.Size = new System.Drawing.Size(233, 28);
            this.txtdiscount.TabIndex = 20;
            this.txtdiscount.TextChanged += new System.EventHandler(this.txtdiscount_TextChanged);
            // 
            // txtsubtotal
            // 
            this.txtsubtotal.Location = new System.Drawing.Point(168, 26);
            this.txtsubtotal.Name = "txtsubtotal";
            this.txtsubtotal.ReadOnly = true;
            this.txtsubtotal.Size = new System.Drawing.Size(233, 28);
            this.txtsubtotal.TabIndex = 19;
            this.txtsubtotal.Text = "0.00";
            // 
            // lblreturn
            // 
            this.lblreturn.AutoSize = true;
            this.lblreturn.Location = new System.Drawing.Point(3, 212);
            this.lblreturn.Name = "lblreturn";
            this.lblreturn.Size = new System.Drawing.Size(135, 21);
            this.lblreturn.TabIndex = 18;
            this.lblreturn.Text = "Returned Amount";
            // 
            // lblpaid
            // 
            this.lblpaid.AutoSize = true;
            this.lblpaid.Location = new System.Drawing.Point(3, 175);
            this.lblpaid.Name = "lblpaid";
            this.lblpaid.Size = new System.Drawing.Size(101, 21);
            this.lblpaid.TabIndex = 17;
            this.lblpaid.Text = "Paid Amount";
            // 
            // lblgrandtotal
            // 
            this.lblgrandtotal.AutoSize = true;
            this.lblgrandtotal.Location = new System.Drawing.Point(3, 135);
            this.lblgrandtotal.Name = "lblgrandtotal";
            this.lblgrandtotal.Size = new System.Drawing.Size(90, 21);
            this.lblgrandtotal.TabIndex = 16;
            this.lblgrandtotal.Text = "Grand Total";
            // 
            // lblvat
            // 
            this.lblvat.AutoSize = true;
            this.lblvat.Location = new System.Drawing.Point(3, 98);
            this.lblvat.Name = "lblvat";
            this.lblvat.Size = new System.Drawing.Size(58, 21);
            this.lblvat.TabIndex = 15;
            this.lblvat.Text = "VAT(%)";
            // 
            // lbldiscount
            // 
            this.lbldiscount.AutoSize = true;
            this.lbldiscount.Location = new System.Drawing.Point(3, 61);
            this.lbldiscount.Name = "lbldiscount";
            this.lbldiscount.Size = new System.Drawing.Size(93, 21);
            this.lbldiscount.TabIndex = 14;
            this.lbldiscount.Text = "Discount(%)";
            // 
            // lblsubtotal
            // 
            this.lblsubtotal.AutoSize = true;
            this.lblsubtotal.Location = new System.Drawing.Point(3, 33);
            this.lblsubtotal.Name = "lblsubtotal";
            this.lblsubtotal.Size = new System.Drawing.Size(73, 21);
            this.lblsubtotal.TabIndex = 13;
            this.lblsubtotal.Text = "Sub Total";
            // 
            // lblpcalc
            // 
            this.lblpcalc.AutoSize = true;
            this.lblpcalc.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpcalc.Location = new System.Drawing.Point(3, 1);
            this.lblpcalc.Name = "lblpcalc";
            this.lblpcalc.Size = new System.Drawing.Size(140, 21);
            this.lblpcalc.TabIndex = 2;
            this.lblpcalc.Text = "Calculation Details";
            // 
            // txtpid
            // 
            this.txtpid.Location = new System.Drawing.Point(77, 546);
            this.txtpid.Name = "txtpid";
            this.txtpid.Size = new System.Drawing.Size(186, 28);
            this.txtpid.TabIndex = 19;
            this.txtpid.Visible = false;
            // 
            // prntdoc
            // 
            this.prntdoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // prntDialog
            // 
            this.prntDialog.UseEXDialog = true;
            // 
            // frmpurchasesales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(1366, 575);
            this.Controls.Add(this.txtpid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnldatagrid);
            this.Controls.Add(this.pnlproduct);
            this.Controls.Add(this.pnldeacust);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmpurchasesales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmpurchasesales";
            this.Load += new System.EventHandler(this.frmpurchasesales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnldeacust.ResumeLayout(false);
            this.pnldeacust.PerformLayout();
            this.pnlproduct.ResumeLayout(false);
            this.pnlproduct.PerformLayout();
            this.pnldatagrid.ResumeLayout(false);
            this.pnldatagrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvaddproduct)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblfrm;
        private System.Windows.Forms.Panel pnldeacust;
        private System.Windows.Forms.DateTimePicker dtpbilldate;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtcontact;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblbilldate;
        private System.Windows.Forms.Label lbladdress;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblcontact;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.Label lbldeacust;
        private System.Windows.Forms.Panel pnlproduct;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtqty;
        private System.Windows.Forms.TextBox txtrate;
        private System.Windows.Forms.TextBox txtinventory;
        private System.Windows.Forms.TextBox txtpname;
        private System.Windows.Forms.TextBox txtpsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.Label lblinventory;
        private System.Windows.Forms.Label lblpname;
        private System.Windows.Forms.Label lblpsearch;
        private System.Windows.Forms.Label lblproduct;
        private System.Windows.Forms.Panel pnldatagrid;
        private System.Windows.Forms.DataGridView dgvaddproduct;
        private System.Windows.Forms.Label lbldatagrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtreturn;
        private System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.TextBox txtgrandtotal;
        private System.Windows.Forms.TextBox txtvat;
        private System.Windows.Forms.TextBox txtdiscount;
        private System.Windows.Forms.TextBox txtsubtotal;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.Label lblpaid;
        private System.Windows.Forms.Label lblgrandtotal;
        private System.Windows.Forms.Label lblvat;
        private System.Windows.Forms.Label lbldiscount;
        private System.Windows.Forms.Label lblsubtotal;
        private System.Windows.Forms.Label lblpcalc;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtpid;
        private System.Windows.Forms.TextBox txtcustid;
        private System.Drawing.Printing.PrintDocument prntdoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PrintDialog prntDialog;
    }
}