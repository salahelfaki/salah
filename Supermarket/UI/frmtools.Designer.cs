
namespace Supermarket.UI
{
    partial class frmtools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmtools));
            this.btnclear = new System.Windows.Forms.Button();
            this.Btnback = new System.Windows.Forms.Button();
            this.btnrestore = new System.Windows.Forms.Button();
            this.btnbarcode = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnclear.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnclear, "btnclear");
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnclear.Name = "btnclear";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // Btnback
            // 
            this.Btnback.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.Btnback.FlatAppearance.BorderSize = 0;
            this.Btnback.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.Btnback, "Btnback");
            this.Btnback.Name = "Btnback";
            this.Btnback.UseVisualStyleBackColor = false;
            this.Btnback.Click += new System.EventHandler(this.Btnback_Click);
            // 
            // btnrestore
            // 
            this.btnrestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnrestore.FlatAppearance.BorderSize = 0;
            this.btnrestore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btnrestore, "btnrestore");
            this.btnrestore.Name = "btnrestore";
            this.btnrestore.UseVisualStyleBackColor = false;
            this.btnrestore.Click += new System.EventHandler(this.btnrestore_Click);
            // 
            // btnbarcode
            // 
            this.btnbarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnbarcode.FlatAppearance.BorderSize = 0;
            this.btnbarcode.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.btnbarcode, "btnbarcode");
            this.btnbarcode.Name = "btnbarcode";
            this.btnbarcode.UseVisualStyleBackColor = false;
            this.btnbarcode.Click += new System.EventHandler(this.btnbarcode_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnexport
            // 
            this.btnexport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnexport.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnexport, "btnexport");
            this.btnexport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnexport.Name = "btnexport";
            this.btnexport.UseVisualStyleBackColor = false;
            this.btnexport.Click += new System.EventHandler(this.btnexport_Click);
            // 
            // btnimport
            // 
            this.btnimport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(97)))), ((int)(((byte)(158)))));
            this.btnimport.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnimport, "btnimport");
            this.btnimport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnimport.Name = "btnimport";
            this.btnimport.UseVisualStyleBackColor = false;
            this.btnimport.Click += new System.EventHandler(this.btnimport_Click);
            // 
            // txtcode
            // 
            resources.ApplyResources(this.txtcode, "txtcode");
            this.txtcode.Name = "txtcode";
            this.txtcode.TextChanged += new System.EventHandler(this.txtcode_TextChanged);
            // 
            // frmtools
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.Controls.Add(this.txtcode);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnbarcode);
            this.Controls.Add(this.btnrestore);
            this.Controls.Add(this.Btnback);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnexport);
            this.Controls.Add(this.btnimport);
            this.Name = "frmtools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button Btnback;
        private System.Windows.Forms.Button btnrestore;
        private System.Windows.Forms.Button btnbarcode;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.TextBox txtcode;
    }
}