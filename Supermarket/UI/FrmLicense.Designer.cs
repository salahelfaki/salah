
namespace Supermarket.UI
{
    partial class FrmLicense
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
            this.lblPeriod = new System.Windows.Forms.Label();
            this.btnActivate = new System.Windows.Forms.Button();
            this.txt1 = new System.Windows.Forms.TextBox();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.btnTrial = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.lbld = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblPeriod
            // 
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.Red;
            this.lblPeriod.Location = new System.Drawing.Point(52, 9);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(94, 21);
            this.lblPeriod.TabIndex = 0;
            this.lblPeriod.Text = "Trial Period";
            // 
            // btnActivate
            // 
            this.btnActivate.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnActivate.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnActivate.Location = new System.Drawing.Point(27, 115);
            this.btnActivate.Name = "btnActivate";
            this.btnActivate.Size = new System.Drawing.Size(124, 35);
            this.btnActivate.TabIndex = 1;
            this.btnActivate.Text = "Activate";
            this.btnActivate.UseVisualStyleBackColor = false;
            this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // txt1
            // 
            this.txt1.Location = new System.Drawing.Point(57, 55);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(77, 28);
            this.txt1.TabIndex = 2;
            // 
            // txt2
            // 
            this.txt2.Location = new System.Drawing.Point(140, 55);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(77, 28);
            this.txt2.TabIndex = 3;
            // 
            // txt3
            // 
            this.txt3.Location = new System.Drawing.Point(223, 55);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(77, 28);
            this.txt3.TabIndex = 4;
            // 
            // txt4
            // 
            this.txt4.Location = new System.Drawing.Point(306, 55);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(77, 28);
            this.txt4.TabIndex = 5;
            // 
            // btnTrial
            // 
            this.btnTrial.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnTrial.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTrial.Location = new System.Drawing.Point(158, 115);
            this.btnTrial.Name = "btnTrial";
            this.btnTrial.Size = new System.Drawing.Size(122, 35);
            this.btnTrial.TabIndex = 6;
            this.btnTrial.Text = "Trial";
            this.btnTrial.UseVisualStyleBackColor = false;
            this.btnTrial.Click += new System.EventHandler(this.btnTrial_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExit.Location = new System.Drawing.Point(286, 115);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 35);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.ForeColor = System.Drawing.Color.Red;
            this.lblDays.Location = new System.Drawing.Point(142, 9);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(28, 21);
            this.lblDays.TabIndex = 8;
            this.lblDays.Text = "10";
            // 
            // lbld
            // 
            this.lbld.AutoSize = true;
            this.lbld.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbld.ForeColor = System.Drawing.Color.Red;
            this.lbld.Location = new System.Drawing.Point(169, 9);
            this.lbld.Name = "lbld";
            this.lbld.Size = new System.Drawing.Size(47, 21);
            this.lbld.TabIndex = 11;
            this.lbld.Text = "Days";
            // 
            // FrmLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(509, 200);
            this.ControlBox = false;
            this.Controls.Add(this.lbld);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTrial);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.txt1);
            this.Controls.Add(this.btnActivate);
            this.Controls.Add(this.lblPeriod);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License";
            this.Load += new System.EventHandler(this.FrmLicense_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Button btnActivate;
        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Button btnTrial;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lbld;
        private System.Windows.Forms.Timer timer1;
    }
}