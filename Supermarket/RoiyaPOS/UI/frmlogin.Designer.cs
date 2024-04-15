namespace supermarket.UI
{
    partial class frmlogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmlogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnlogin = new System.Windows.Forms.Button();
            this.cmbutype = new System.Windows.Forms.ComboBox();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.lblutype = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnlang = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnlogin);
            this.panel1.Controls.Add(this.cmbutype);
            this.panel1.Controls.Add(this.txtpass);
            this.panel1.Controls.Add(this.lblutype);
            this.panel1.Controls.Add(this.lblpass);
            this.panel1.Controls.Add(this.lblusername);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtuname);
            this.panel1.Name = "panel1";
            // 
            // btnlogin
            // 
            resources.ApplyResources(this.btnlogin, "btnlogin");
            this.btnlogin.BackColor = System.Drawing.Color.Green;
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // cmbutype
            // 
            resources.ApplyResources(this.cmbutype, "cmbutype");
            this.cmbutype.FormattingEnabled = true;
            this.cmbutype.Items.AddRange(new object[] {
            resources.GetString("cmbutype.Items"),
            resources.GetString("cmbutype.Items1")});
            this.cmbutype.Name = "cmbutype";
            // 
            // txtpass
            // 
            resources.ApplyResources(this.txtpass, "txtpass");
            this.txtpass.Name = "txtpass";
            // 
            // lblutype
            // 
            resources.ApplyResources(this.lblutype, "lblutype");
            this.lblutype.Name = "lblutype";
            // 
            // lblpass
            // 
            resources.ApplyResources(this.lblpass, "lblpass");
            this.lblpass.Name = "lblpass";
            // 
            // lblusername
            // 
            resources.ApplyResources(this.lblusername, "lblusername");
            this.lblusername.Name = "lblusername";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtuname
            // 
            resources.ApplyResources(this.txtuname, "txtuname");
            this.txtuname.Name = "txtuname";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnlang
            // 
            resources.ApplyResources(this.btnlang, "btnlang");
            this.btnlang.Name = "btnlang";
            this.btnlang.UseVisualStyleBackColor = true;
            this.btnlang.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmlogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.Controls.Add(this.btnlang);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmlogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.Label lblutype;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.ComboBox cmbutype;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnlang;
    }
}