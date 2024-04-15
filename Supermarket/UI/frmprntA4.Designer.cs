
namespace Supermarket.UI
{
    partial class frmprntA4
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtprntqty = new System.Windows.Forms.TextBox();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(385, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 43);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtprntqty
            // 
            this.txtprntqty.Location = new System.Drawing.Point(259, 218);
            this.txtprntqty.Name = "txtprntqty";
            this.txtprntqty.Size = new System.Drawing.Size(100, 22);
            this.txtprntqty.TabIndex = 1;
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(259, 274);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(100, 22);
            this.txtBox1.TabIndex = 2;
            this.txtBox1.Text = "5";
            // 
            // frmprntA4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.txtprntqty);
            this.Controls.Add(this.button1);
            this.Name = "frmprntA4";
            this.Text = "frmprntA4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtprntqty;
        private System.Windows.Forms.TextBox txtBox1;
    }
}