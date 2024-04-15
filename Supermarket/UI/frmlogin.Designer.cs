namespace Supermarket.UI
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
            this.components = new System.ComponentModel.Container();
            this.lblGreetings = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button16 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuname = new System.Windows.Forms.TextBox();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblpass = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.radlang1 = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblGreetings.Location = new System.Drawing.Point(44, 13);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(0, 17);
            this.lblGreetings.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtpass);
            this.panel2.Controls.Add(this.txtuname);
            this.panel2.Controls.Add(this.lblusername);
            this.panel2.Controls.Add(this.lblpass);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 476);
            this.panel2.TabIndex = 18;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.button16, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button15, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.button14, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.button12, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button11, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button8, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button7, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 126);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 273);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.ForestGreen;
            this.button16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button16.Image = global::Supermarket.Properties.Resources.enter__1_;
            this.button16.Location = new System.Drawing.Point(193, 207);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(89, 63);
            this.button16.TabIndex = 14;
            this.button16.UseVisualStyleBackColor = false;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button15.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button15.Location = new System.Drawing.Point(98, 207);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(89, 63);
            this.button15.TabIndex = 13;
            this.button15.Text = "0";
            this.button15.UseVisualStyleBackColor = false;
            this.button15.Click += new System.EventHandler(this.button2_Click);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Orange;
            this.button14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button14.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button14.Location = new System.Drawing.Point(3, 207);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(89, 63);
            this.button14.TabIndex = 12;
            this.button14.Text = "Clear";
            this.button14.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button14.UseVisualStyleBackColor = false;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button12.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(193, 139);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(89, 62);
            this.button12.TabIndex = 10;
            this.button12.Text = "9";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button2_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button11.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(98, 139);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(89, 62);
            this.button11.TabIndex = 9;
            this.button11.Text = "8";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button2_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button10.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(3, 139);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(89, 62);
            this.button10.TabIndex = 8;
            this.button10.Text = "7";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(193, 71);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(89, 62);
            this.button8.TabIndex = 6;
            this.button8.Text = "6";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button2_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(98, 71);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 62);
            this.button7.TabIndex = 5;
            this.button7.Text = "5";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button2_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(3, 71);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(89, 62);
            this.button6.TabIndex = 4;
            this.button6.Text = "4";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(193, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 62);
            this.button4.TabIndex = 2;
            this.button4.Text = "3";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(98, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 62);
            this.button3.TabIndex = 1;
            this.button3.Text = "2";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 62);
            this.button2.TabIndex = 0;
            this.button2.Text = "1";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtpass
            // 
            this.txtpass.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.txtpass.Location = new System.Drawing.Point(131, 60);
            this.txtpass.MinimumSize = new System.Drawing.Size(150, 40);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '*';
            this.txtpass.Size = new System.Drawing.Size(217, 35);
            this.txtpass.TabIndex = 5;
            this.txtpass.Enter += new System.EventHandler(this.txtpass_Enter);
            // 
            // txtuname
            // 
            this.txtuname.Font = new System.Drawing.Font("Tahoma", 13.8F);
            this.txtuname.Location = new System.Drawing.Point(131, 10);
            this.txtuname.MinimumSize = new System.Drawing.Size(150, 40);
            this.txtuname.Name = "txtuname";
            this.txtuname.Size = new System.Drawing.Size(217, 35);
            this.txtuname.TabIndex = 0;
            this.txtuname.Enter += new System.EventHandler(this.txtuname_Enter);
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblusername.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblusername.Location = new System.Drawing.Point(7, 16);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(108, 24);
            this.lblusername.TabIndex = 2;
            this.lblusername.Text = "User Name";
            // 
            // lblpass
            // 
            this.lblpass.AutoSize = true;
            this.lblpass.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblpass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblpass.Location = new System.Drawing.Point(7, 66);
            this.lblpass.Name = "lblpass";
            this.lblpass.Size = new System.Drawing.Size(94, 24);
            this.lblpass.TabIndex = 3;
            this.lblpass.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Log In";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 43);
            this.panel1.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.button1.BackgroundImage = global::Supermarket.Properties.Resources.power_on__1_;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(182, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(46, 43);
            this.button1.TabIndex = 14;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.ForestGreen;
            this.label2.Location = new System.Drawing.Point(44, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 17);
            this.label2.TabIndex = 16;
            // 
            // radlang1
            // 
            this.radlang1.AutoSize = true;
            this.radlang1.Checked = true;
            this.radlang1.Font = new System.Drawing.Font("Tahoma", 10.2F);
            this.radlang1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radlang1.Location = new System.Drawing.Point(294, 264);
            this.radlang1.Name = "radlang1";
            this.radlang1.Size = new System.Drawing.Size(70, 25);
            this.radlang1.TabIndex = 15;
            this.radlang1.TabStop = true;
            this.radlang1.Text = "عربي";
            this.radlang1.UseVisualStyleBackColor = true;
            // 
            // frmlogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(432, 520);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radlang1);
            this.Controls.Add(this.lblGreetings);
            this.Font = new System.Drawing.Font("Calibri", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmlogin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign In";
            this.Load += new System.EventHandler(this.frmlogin_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtuname;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblpass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radlang1;
    }
}