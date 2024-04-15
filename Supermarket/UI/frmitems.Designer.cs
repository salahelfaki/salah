
namespace Supermarket.UI
{
    partial class frmitems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmitems));
            this.btnclear = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btnadd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btndelete = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtname = new System.Windows.Forms.TextBox();
            this.lblname = new System.Windows.Forms.Label();
            this.lblrate = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.lblid = new System.Windows.Forms.Label();
            this.txtunit = new System.Windows.Forms.TextBox();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.dgvitems = new System.Windows.Forms.DataGridView();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.lblsearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.OrangeRed;
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(690, 465);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(136, 50);
            this.btnclear.TabIndex = 54;
            this.btnclear.Text = "Clear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.BackColor = System.Drawing.Color.DarkOrange;
            this.btnupdate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.Location = new System.Drawing.Point(295, 465);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(137, 48);
            this.btnupdate.TabIndex = 46;
            this.btnupdate.Text = "Update";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.LimeGreen;
            this.btnadd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.Location = new System.Drawing.Point(110, 465);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(137, 48);
            this.btnadd.TabIndex = 45;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(391, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "ITEMS";
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.Red;
            this.btndelete.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.Location = new System.Drawing.Point(494, 465);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(137, 48);
            this.btndelete.TabIndex = 47;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(884, 3);
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 34);
            this.panel2.TabIndex = 31;
            // 
            // txtname
            // 
            this.txtname.Location = new System.Drawing.Point(186, 149);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(197, 22);
            this.txtname.TabIndex = 32;
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(80, 145);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(87, 21);
            this.lblname.TabIndex = 33;
            this.lblname.Text = "Item Name";
            // 
            // lblrate
            // 
            this.lblrate.AutoSize = true;
            this.lblrate.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblrate.Location = new System.Drawing.Point(-37, 210);
            this.lblrate.Name = "lblrate";
            this.lblrate.Size = new System.Drawing.Size(41, 21);
            this.lblrate.TabIndex = 39;
            this.lblrate.Text = "Rate";
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(186, 91);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(197, 22);
            this.txtid.TabIndex = 40;
            // 
            // lblid
            // 
            this.lblid.AutoSize = true;
            this.lblid.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblid.Location = new System.Drawing.Point(80, 91);
            this.lblid.Name = "lblid";
            this.lblid.Size = new System.Drawing.Size(59, 21);
            this.lblid.TabIndex = 41;
            this.lblid.Text = "Item Id";
            // 
            // txtunit
            // 
            this.txtunit.Location = new System.Drawing.Point(186, 204);
            this.txtunit.Name = "txtunit";
            this.txtunit.Size = new System.Drawing.Size(197, 22);
            this.txtunit.TabIndex = 33;
            // 
            // lblpbarcode
            // 
            this.lblpbarcode.AutoSize = true;
            this.lblpbarcode.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpbarcode.Location = new System.Drawing.Point(80, 204);
            this.lblpbarcode.Name = "lblpbarcode";
            this.lblpbarcode.Size = new System.Drawing.Size(40, 21);
            this.lblpbarcode.TabIndex = 49;
            this.lblpbarcode.Text = "Unit";
            // 
            // dgvitems
            // 
            this.dgvitems.AllowUserToAddRows = false;
            this.dgvitems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvitems.Location = new System.Drawing.Point(399, 72);
            this.dgvitems.Name = "dgvitems";
            this.dgvitems.RowHeadersWidth = 51;
            this.dgvitems.RowTemplate.Height = 24;
            this.dgvitems.Size = new System.Drawing.Size(430, 332);
            this.dgvitems.TabIndex = 42;
            this.dgvitems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvitems_CellContentClick);
            this.dgvitems.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvitems_RowHeaderMouseClick);
            // 
            // txtsearch
            // 
            this.txtsearch.Location = new System.Drawing.Point(457, 44);
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(372, 22);
            this.txtsearch.TabIndex = 43;
            this.txtsearch.TextChanged += new System.EventHandler(this.txtsearch_TextChanged);
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.Location = new System.Drawing.Point(392, 45);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(56, 21);
            this.lblsearch.TabIndex = 44;
            this.lblsearch.Text = "Search";
            // 
            // frmitems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(921, 565);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.lblpbarcode);
            this.Controls.Add(this.txtunit);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.lblsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.dgvitems);
            this.Controls.Add(this.lblid);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.lblrate);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmitems";
            this.Text = "frmitems";
            this.Load += new System.EventHandler(this.frmitems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvitems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label lblid;
        private System.Windows.Forms.TextBox txtunit;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.DataGridView dgvitems;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Label lblsearch;
    }
}