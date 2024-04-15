
namespace Supermarket.UI
{
    partial class frmpurchaseStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmpurchaseStock));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnitems = new System.Windows.Forms.Button();
            this.btnreturn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.btnreturn, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnitems, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // btnitems
            // 
            resources.ApplyResources(this.btnitems, "btnitems");
            this.btnitems.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnitems.FlatAppearance.BorderSize = 0;
            this.btnitems.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnitems.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnitems.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnitems.Name = "btnitems";
            this.btnitems.UseVisualStyleBackColor = false;
            this.btnitems.Click += new System.EventHandler(this.btnitems_Click);
            // 
            // btnreturn
            // 
            resources.ApplyResources(this.btnreturn, "btnreturn");
            this.btnreturn.BackColor = System.Drawing.Color.Lime;
            this.btnreturn.FlatAppearance.BorderSize = 0;
            this.btnreturn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnreturn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnreturn.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnreturn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreturn.Name = "btnreturn";
            this.btnreturn.UseCompatibleTextRendering = true;
            this.btnreturn.UseVisualStyleBackColor = false;
            this.btnreturn.Click += new System.EventHandler(this.btnreturn_Click);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // frmpurchaseStock
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmpurchaseStock";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnitems;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnreturn;
    }
}