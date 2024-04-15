using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmbarcode : Form
    {
        public frmbarcode()
        {
            InitializeComponent();
        }
        productsDAL dal = new productsDAL();
        BarcodeLib.Barcode barCode = new BarcodeLib.Barcode();
        string nHeight = "130";
        string nWidth = "60";

        private void txtgenerate_Click(object sender, EventArgs e)
        {
            if(txtbarcode.Text.Trim()=="")
            {
                MessageBox.Show("Input Barcode", "Msg", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            errorProvider1.Clear();
            int nW = Convert.ToInt32(nHeight);
            int nH = Convert.ToInt32(nWidth);
            barCode.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;
            type = BarcodeLib.TYPE.CODE128;
            try
            {
                if(type !=BarcodeLib.TYPE.UNSPECIFIED)
                {
                    barCode.IncludeLabel = true;
                    barCode.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "RotateNoneFlipNone", true);
                    pictureBox1.Image = barCode.Encode(type, txtbarcode.Text, Color.Black, Color.White, nW, nH);

                }
                pictureBox1.Width = pictureBox1.Image.Width;
                pictureBox1.Height = pictureBox1.Image.Height;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int nofbarcode = Convert.ToInt32(txtqty.Text);
            Font printFont = new Font("3 of 9 Barcode", 17);
            Font printFont1 = new Font("Times New Roman", 9, FontStyle.Bold);

            SolidBrush br = new SolidBrush(Color.Black);
           // int rowY = 10;


            //int rowX = 0;
            /*
            for (int nI = 0; nI < nofbarcode; nI++)
            {


                e.Graphics.DrawString(txtbarcode.Text, printFont, br, rowY, rowX);
                e.Graphics.DrawString(txtbarcode.Text, printFont1, br, rowY, rowX+20);
                rowX = rowX + pictureBox1.Height + 32;
            }
           */
            using (Graphics graph= e.Graphics){
                int rowY = 70;
                
                
                    int rowX = 10;
                   // for(int nI=0; nI < nofbarcode; nI++)
                    //{

                        graph.DrawImage(pictureBox1.Image,rowY , 5+rowX);
                        rowX = rowX + pictureBox1.Height+40;
                    //}
                   
                

            }
           
        }

        private void btnprint_Click(object sender, EventArgs e)
        {

            int nofbarcode2 = Convert.ToInt32(txtqty.Text);
            int i = 0;

            PrintDialog printDlg = new PrintDialog();
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            prntprevDialog.Document = printDoc;
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 285,800 );
            printDoc.PrinterSettings.PrinterName = cmbprinters.Text;
            for (i= 0; i < nofbarcode2;i++)
            {
                printDoc.Print();

            }
            
            //prntprevDialog.ShowDialog();
           // printDoc.Print();
        }

        private void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void dgvproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            txtbarcode.Text = dgvproduct.Rows[rowindex].Cells[1].Value.ToString();
            txtname.Text = dgvproduct.Rows[rowindex].Cells[2].Value.ToString();


        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;

            if (txtsearch.Text.Length > 0)
            {
                (dgvproduct.DataSource as DataTable).DefaultView.RowFilter = string.Format("pname LIKE '{0}%'", txtsearch.Text);
                //DataTable dt = dal.SearchList(txtsearch.Text);
                //dgvproducts.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.SelectList();
                dgvproduct.DataSource = dt;
            }
        }

        private void frmbarcode_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            dgvproduct.DataSource = dt;
            dgvproduct.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvproduct.EnableHeadersVisualStyles = false;
            dgvproduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvproduct.Columns[0].HeaderText = "الرقم";
                dgvproduct.Columns[1].HeaderText = "الباركود";
                dgvproduct.Columns[2].HeaderText = "الاسم";
                dgvproduct.Columns[3].HeaderText = "الاسم اللاتيني";
                dgvproduct.Columns[4].HeaderText = "الوحدة";
                dgvproduct.Columns[5].HeaderText = "الكمية";
                dgvproduct.Columns[6].HeaderText = "السعر";
                dgvproduct.Columns[7].HeaderText = "المجموعة";
                dgvproduct.Columns[8].HeaderText = "اخر سعر";


            }
            else
            {
                dgvproduct.Columns[0].HeaderText = "ID";
                dgvproduct.Columns[1].HeaderText = "Barcode";
                dgvproduct.Columns[2].HeaderText = "Name";
                dgvproduct.Columns[3].HeaderText = "Alias ";
                dgvproduct.Columns[4].HeaderText = "Unit";
                dgvproduct.Columns[5].HeaderText = "Qty";
                dgvproduct.Columns[6].HeaderText = "Price";
                dgvproduct.Columns[7].HeaderText = "Main Group";
                dgvproduct.Columns[8].HeaderText = "Last Cost";



                dgvproduct.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
                dgvproduct.EnableHeadersVisualStyles = false;
                dgvproduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                // dgvproducts.RowHeadersWidth = 55;
                // dgvproducts.RowTemplate.MinimumHeight = 25;
                dgvproduct.Columns[0].Width = 20;
                dgvproduct.Columns[1].Width = 120;
                dgvproduct.Columns[2].Width = 200;
                dgvproduct.Columns[3].Width = 200;
            }

            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cmbprinters.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cmbprinters.SelectedIndex = cmbprinters.Items.IndexOf(strPrinter);
                }
            }
        }
    }
}
