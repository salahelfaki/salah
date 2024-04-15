
namespace Supermarket.UI
{
    partial class frmsalesmenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btninvoice = new System.Windows.Forms.Button();
            this.btnproforma = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnconvert = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.btninvoice, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnproforma, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnexit, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnconvert, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(990, 575);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btninvoice
            // 
            this.btninvoice.BackColor = System.Drawing.Color.SlateBlue;
            this.btninvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btninvoice.FlatAppearance.BorderSize = 0;
            this.btninvoice.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btninvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btninvoice.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btninvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btninvoice.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btninvoice.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btninvoice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btninvoice.Location = new System.Drawing.Point(548, 130);
            this.btninvoice.Name = "btninvoice";
            this.btninvoice.Size = new System.Drawing.Size(241, 153);
            this.btninvoice.TabIndex = 2;
            this.btninvoice.Text = "فاتورة ضريبيـة";
            this.btninvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btninvoice.UseVisualStyleBackColor = false;
            this.btninvoice.Click += new System.EventHandler(this.btninvoice_Click);
            // 
            // btnproforma
            // 
            this.btnproforma.BackColor = System.Drawing.Color.DarkRed;
            this.btnproforma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnproforma.FlatAppearance.BorderSize = 0;
            this.btnproforma.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnproforma.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnproforma.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnproforma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnproforma.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnproforma.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnproforma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnproforma.Location = new System.Drawing.Point(202, 130);
            this.btnproforma.Name = "btnproforma";
            this.btnproforma.Size = new System.Drawing.Size(241, 153);
            this.btnproforma.TabIndex = 3;
            this.btnproforma.Text = "فاتورة مبدئيـة";
            this.btnproforma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnproforma.UseVisualStyleBackColor = false;
            this.btnproforma.Click += new System.EventHandler(this.btnproforma_Click);
            // 
            // btnexit
            // 
            this.btnexit.BackColor = System.Drawing.Color.Red;
            this.btnexit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnexit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnexit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnexit.Location = new System.Drawing.Point(202, 352);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(241, 153);
            this.btnexit.TabIndex = 4;
            this.btnexit.Text = "خـروج";
            this.btnexit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnexit.UseVisualStyleBackColor = false;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnconvert
            // 
            this.btnconvert.BackColor = System.Drawing.Color.Salmon;
            this.btnconvert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnconvert.FlatAppearance.BorderSize = 0;
            this.btnconvert.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnconvert.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnconvert.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnconvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconvert.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnconvert.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnconvert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnconvert.Location = new System.Drawing.Point(548, 352);
            this.btnconvert.Name = "btnconvert";
            this.btnconvert.Size = new System.Drawing.Size(241, 153);
            this.btnconvert.TabIndex = 5;
            this.btnconvert.Text = "تحويل الى فاتورة";
            this.btnconvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnconvert.UseVisualStyleBackColor = false;
            this.btnconvert.Click += new System.EventHandler(this.btnconvert_Click);
            // 
            // frmsalesmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 575);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmsalesmenu";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "المبيعات";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btninvoice;
        private System.Windows.Forms.Button btnproforma;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnconvert;
    }
}