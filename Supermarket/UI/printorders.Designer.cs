
namespace Supermarket.UI
{
    partial class printorders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printorders));
            this.fromdate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvorders = new System.Windows.Forms.DataGridView();
            this.btnload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.todate = new System.Windows.Forms.DateTimePicker();
            this.btnprint = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvorders)).BeginInit();
            this.SuspendLayout();
            // 
            // fromdate
            // 
            this.fromdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromdate.Location = new System.Drawing.Point(86, 13);
            this.fromdate.Name = "fromdate";
            this.fromdate.Size = new System.Drawing.Size(113, 22);
            this.fromdate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "From";
            // 
            // dgvorders
            // 
            this.dgvorders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvorders.Location = new System.Drawing.Point(33, 41);
            this.dgvorders.Name = "dgvorders";
            this.dgvorders.RowHeadersWidth = 51;
            this.dgvorders.RowTemplate.Height = 24;
            this.dgvorders.Size = new System.Drawing.Size(433, 374);
            this.dgvorders.TabIndex = 2;
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(471, 6);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(94, 31);
            this.btnload.TabIndex = 3;
            this.btnload.Text = "Load";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.btnload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "To:";
            // 
            // todate
            // 
            this.todate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.todate.Location = new System.Drawing.Point(317, 13);
            this.todate.Name = "todate";
            this.todate.Size = new System.Drawing.Size(113, 22);
            this.todate.TabIndex = 4;
            // 
            // btnprint
            // 
            this.btnprint.Location = new System.Drawing.Point(709, 421);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(94, 31);
            this.btnprint.TabIndex = 6;
            this.btnprint.Text = "Print";
            this.btnprint.UseVisualStyleBackColor = true;
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printorders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 450);
            this.Controls.Add(this.btnprint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.todate);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.dgvorders);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fromdate);
            this.Name = "printorders";
            this.Text = "printorders";
            ((System.ComponentModel.ISupportInitialize)(this.dgvorders)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvorders;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker todate;
        private System.Windows.Forms.Button btnprint;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}