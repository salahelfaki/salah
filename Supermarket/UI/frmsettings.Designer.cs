
namespace Supermarket.UI
{
    partial class frmsettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmsettings));
            this.panelbtn = new System.Windows.Forms.Panel();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.lblpbarcode = new System.Windows.Forms.Label();
            this.txtcompany = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtstore = new System.Windows.Forms.TextBox();
            this.txtvatval = new System.Windows.Forms.TextBox();
            this.lblrate = new System.Windows.Forms.Label();
            this.txtvatno = new System.Windows.Forms.TextBox();
            this.lbldescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbcategory = new System.Windows.Forms.ComboBox();
            this.lblname = new System.Windows.Forms.Label();
            this.txtaddress = new System.Windows.Forms.TextBox();
            this.txtbranch = new System.Windows.Forms.TextBox();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.txtlogo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictbox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtaname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtregno = new System.Windows.Forms.TextBox();
            this.chkscreen = new System.Windows.Forms.CheckBox();
            this.txtvatok = new System.Windows.Forms.CheckBox();
            this.panelbtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictbox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelbtn
            // 
            resources.ApplyResources(this.panelbtn, "panelbtn");
            this.panelbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.panelbtn.Controls.Add(this.btnexit);
            this.panelbtn.Controls.Add(this.btnupdate);
            this.panelbtn.Name = "panelbtn";
            // 
            // btnexit
            // 
            resources.ApplyResources(this.btnexit, "btnexit");
            this.btnexit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnexit.Image = global::Supermarket.Properties.Resources.exit;
            this.btnexit.Name = "btnexit";
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnupdate
            // 
            resources.ApplyResources(this.btnupdate, "btnupdate");
            this.btnupdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(86)))), ((int)(((byte)(134)))));
            this.btnupdate.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnupdate.Image = global::Supermarket.Properties.Resources.edit;
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.UseVisualStyleBackColor = false;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // lblpbarcode
            // 
            resources.ApplyResources(this.lblpbarcode, "lblpbarcode");
            this.lblpbarcode.Name = "lblpbarcode";
            // 
            // txtcompany
            // 
            resources.ApplyResources(this.txtcompany, "txtcompany");
            this.txtcompany.Name = "txtcompany";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtstore
            // 
            resources.ApplyResources(this.txtstore, "txtstore");
            this.txtstore.Name = "txtstore";
            // 
            // txtvatval
            // 
            resources.ApplyResources(this.txtvatval, "txtvatval");
            this.txtvatval.Name = "txtvatval";
            // 
            // lblrate
            // 
            resources.ApplyResources(this.lblrate, "lblrate");
            this.lblrate.Name = "lblrate";
            // 
            // txtvatno
            // 
            resources.ApplyResources(this.txtvatno, "txtvatno");
            this.txtvatno.Name = "txtvatno";
            // 
            // lbldescription
            // 
            resources.ApplyResources(this.lbldescription, "lbldescription");
            this.lbldescription.Name = "lbldescription";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cmbcategory
            // 
            resources.ApplyResources(this.cmbcategory, "cmbcategory");
            this.cmbcategory.AllowDrop = true;
            this.cmbcategory.FormattingEnabled = true;
            this.cmbcategory.Items.AddRange(new object[] {
            resources.GetString("cmbcategory.Items"),
            resources.GetString("cmbcategory.Items1")});
            this.cmbcategory.Name = "cmbcategory";
            // 
            // lblname
            // 
            resources.ApplyResources(this.lblname, "lblname");
            this.lblname.Name = "lblname";
            this.lblname.Click += new System.EventHandler(this.lblname_Click);
            // 
            // txtaddress
            // 
            resources.ApplyResources(this.txtaddress, "txtaddress");
            this.txtaddress.Name = "txtaddress";
            this.txtaddress.TextChanged += new System.EventHandler(this.txtaddress_TextChanged);
            // 
            // txtbranch
            // 
            resources.ApplyResources(this.txtbranch, "txtbranch");
            this.txtbranch.Name = "txtbranch";
            // 
            // btnbrowse
            // 
            resources.ApplyResources(this.btnbrowse, "btnbrowse");
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.UseVisualStyleBackColor = true;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // txtlogo
            // 
            resources.ApplyResources(this.txtlogo, "txtlogo");
            this.txtlogo.Name = "txtlogo";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // pictbox
            // 
            resources.ApplyResources(this.pictbox, "pictbox");
            this.pictbox.Name = "pictbox";
            this.pictbox.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txtaname
            // 
            resources.ApplyResources(this.txtaname, "txtaname");
            this.txtaname.Name = "txtaname";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtregno
            // 
            resources.ApplyResources(this.txtregno, "txtregno");
            this.txtregno.Name = "txtregno";
            // 
            // chkscreen
            // 
            resources.ApplyResources(this.chkscreen, "chkscreen");
            this.chkscreen.Name = "chkscreen";
            this.chkscreen.UseVisualStyleBackColor = true;
            this.chkscreen.CheckedChanged += new System.EventHandler(this.chkscreen_CheckedChanged);
            // 
            // txtvatok
            // 
            resources.ApplyResources(this.txtvatok, "txtvatok");
            this.txtvatok.Name = "txtvatok";
            this.txtvatok.UseVisualStyleBackColor = true;
            this.txtvatok.CheckedChanged += new System.EventHandler(this.txtvatok_CheckedChanged);
            // 
            // frmsettings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.chkscreen);
            this.Controls.Add(this.txtvatok);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtregno);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtaname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtlogo);
            this.Controls.Add(this.btnbrowse);
            this.Controls.Add(this.pictbox);
            this.Controls.Add(this.panelbtn);
            this.Controls.Add(this.lblpbarcode);
            this.Controls.Add(this.txtcompany);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtstore);
            this.Controls.Add(this.txtvatval);
            this.Controls.Add(this.lblrate);
            this.Controls.Add(this.txtvatno);
            this.Controls.Add(this.lbldescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbcategory);
            this.Controls.Add(this.lblname);
            this.Controls.Add(this.txtaddress);
            this.Controls.Add(this.txtbranch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmsettings";
            this.Load += new System.EventHandler(this.frmsettings_Load);
            this.panelbtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelbtn;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Label lblpbarcode;
        private System.Windows.Forms.TextBox txtcompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtstore;
        private System.Windows.Forms.TextBox txtvatval;
        private System.Windows.Forms.Label lblrate;
        private System.Windows.Forms.TextBox txtvatno;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbcategory;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtaddress;
        private System.Windows.Forms.TextBox txtbranch;
        private System.Windows.Forms.PictureBox pictbox;
        private System.Windows.Forms.Button btnbrowse;
        private System.Windows.Forms.TextBox txtlogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtaname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtregno;
        private System.Windows.Forms.CheckBox chkscreen;
        private System.Windows.Forms.CheckBox txtvatok;
    }
}