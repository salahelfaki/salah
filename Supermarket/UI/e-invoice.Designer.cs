
namespace Supermarket.UI
{
    partial class e_invoice
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
            this.txt1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.Location = new System.Drawing.Point(234, 81);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(654, 30);
            this.txt1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seller\'s Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(234, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 61);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "VAT";
            // 
            // txt5
            // 
            this.txt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.Location = new System.Drawing.Point(234, 278);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(224, 30);
            this.txt5.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(115, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Invoice Total";
            // 
            // txt4
            // 
            this.txt4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt4.Location = new System.Drawing.Point(234, 221);
            this.txt4.Name = "txt4";
            this.txt4.Size = new System.Drawing.Size(224, 30);
            this.txt4.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Time Stamp";
            // 
            // txt3
            // 
            this.txt3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt3.Location = new System.Drawing.Point(234, 181);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(224, 30);
            this.txt3.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "VAT number";
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.Location = new System.Drawing.Point(234, 129);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(224, 30);
            this.txt2.TabIndex = 9;
            // 
            // txtcode
            // 
            this.txtcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcode.Location = new System.Drawing.Point(519, 312);
            this.txtcode.Multiline = true;
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(432, 138);
            this.txtcode.TabIndex = 11;
            // 
            // e_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 522);
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt1);
            this.Name = "e_invoice";
            this.Text = "e_invoice";
            this.Load += new System.EventHandler(this.e_invoice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt2;
        private System.Windows.Forms.TextBox txtcode;
    }
}