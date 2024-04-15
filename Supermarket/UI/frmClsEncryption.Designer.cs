
namespace Supermarket.UI
{
    partial class frmClsEncryption
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
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PlainText = new System.Windows.Forms.TextBox();
            this.txtencrypted = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(91, 216);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(109, 42);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Plain Text";
            // 
            // PlainText
            // 
            this.PlainText.Location = new System.Drawing.Point(92, 33);
            this.PlainText.Multiline = true;
            this.PlainText.Name = "PlainText";
            this.PlainText.Size = new System.Drawing.Size(391, 72);
            this.PlainText.TabIndex = 2;
            // 
            // txtencrypted
            // 
            this.txtencrypted.Location = new System.Drawing.Point(92, 121);
            this.txtencrypted.Multiline = true;
            this.txtencrypted.Name = "txtencrypted";
            this.txtencrypted.Size = new System.Drawing.Size(391, 72);
            this.txtencrypted.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Encrypted";
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Location = new System.Drawing.Point(374, 216);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(109, 42);
            this.btnDecrypt.TabIndex = 5;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            // 
            // ClsEncryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 270);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtencrypted);
            this.Controls.Add(this.PlainText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEncrypt);
            this.Name = "ClsEncryption";
            this.Text = "ClsEncryption";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PlainText;
        private System.Windows.Forms.TextBox txtencrypted;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDecrypt;
    }
}