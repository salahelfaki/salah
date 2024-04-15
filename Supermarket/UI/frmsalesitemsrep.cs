using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Supermarket.DAL;
using Supermarket.BLL;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Globalization;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmsalesitemsrep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmsalesitemsrep()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        salesDAL sdal = new salesDAL();
        productsDAL pdal = new productsDAL();
        printDAL prdal = new printDAL();

        private void frmitemsalerep_Load(object sender, EventArgs e)
        {
            string sdate = date1.Value.ToString("yyyy-MM-dd");
            string edate = date2.Value.ToString("yyyy-MM-dd");
            
            string sql = "Select Distinct barcode,productname from tbl_sdetail";
            SqlConnection conn = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "products");
            
            cmbproduct.DisplayMember = "productname";
            cmbproduct.ValueMember = "barcode";
            cmbproduct.DataSource = ds.Tables["products"];
            conn.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }



        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            string sdate = date1.Value.ToString("yyyy-MM-dd");
            string edate = date2.Value.ToString("yyyy-MM-dd");
            DisplayItemTrans();
        }
            
            

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string sdate = date1.Value.ToString("yyyy-MM-dd");
            string edate = date2.Value.ToString("yyyy-MM-dd");
            //string tpid = txtpid.Text;

            DisplayItemTrans();
        }
        private void DisplayItemTrans()
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            DataTable dti = sdal.DisplayStrans(sdate, edate, txtpid.Text);
            // MessageBox.Show(dti.Rows[0][0].ToString());

            dgvitemrep.DataSource = dti;

            dgvitemrep.Columns[0].HeaderText = "الرقم";
            dgvitemrep.Columns[1].HeaderText = "التاريخ";
            dgvitemrep.Columns[2].HeaderText = "الكمية";
            dgvitemrep.Columns[3].HeaderText = "السعر";
            dgvitemrep.Columns[4].HeaderText = "الاجمالي";

            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            double mtotal = 0;
            for (int i = 0; i < dgvitemrep.Rows.Count; ++i)
            {
                mtotal += Convert.ToDouble(dgvitemrep.Rows[i].Cells[4].Value);


            }
            txtsubtotal.Text = String.Format("{0:N2}", mtotal);

        }
    

        
        private void btnprnt_Click(object sender, EventArgs e)
        {
            printPreview.Document = printDoc;
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            printPreview.ShowDialog();
        }

        private void printPreview_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            printPreview.Document = printDoc;
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            printPreview.ShowDialog();
            */
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");
            string sdate = date1.Text;
            string edate = date2.Text;
            //string product = cmbproduct.Text;
            string pgtotal = txtsubtotal.Text;





            if (clogo != "")
            {
                System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                img2 = resizeImage(img2, new Size(100, 100));

            }
            else
            {
                //  System.Drawing.Image img2= System.Drawing.Image.FromFile("Q1.bmp");
                //img2 = resizeImage(img2, new Size(100, 100));
                //e.Graphics.DrawImage(img2, 90, 10);
            }

            //*************************


            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("product", cmbproduct.Text);
            ReportParameter rp6 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\itemsalessmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvitemrep.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvitemrep.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            //change columns names
            dt.Columns["invno"].ColumnName = "id";
            dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["qty"].ColumnName = "paid";
            dt.Columns["price"].ColumnName = "discount";
            dt.Columns["total"].ColumnName = "subtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);



        }

       
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            /*
            printPreview.Document = prntdocA4;
            prntdocA4.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 800, 1200);
            printPreview.ShowDialog();
        */

            DataTable dtc =prdal.GetCompanyData();
            
            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

           

            //DataTable dts = GetSalesData();
            
            string invdate = DateTime.Now.ToString("dd-MM-yyyy");
            string sdate = date1.Text;
            string edate = date2.Text;
            string product = cmbproduct.Text;
            string pgtotal = txtsubtotal.Text;




            
            if (clogo != "")
            {
                System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                img2 = resizeImage(img2, new Size(100, 100));

            }
            else
            {
                //  System.Drawing.Image img2= System.Drawing.Image.FromFile("Q1.bmp");
                //img2 = resizeImage(img2, new Size(100, 100));
                //e.Graphics.DrawImage(img2, 90, 10);
            }
            
            //*************************


            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("product", product);
            ReportParameter rp6 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\itemsales.rdlc";
            report.ReportPath = fullpath;

      

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7});
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
            //*************
            
            foreach (DataGridViewColumn col in dgvitemrep.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvitemrep.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            //change columns names
            dt.Columns["invno"].ColumnName = "id";
            dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["qty"].ColumnName = "paid";
            dt.Columns["price"].ColumnName = "discount";
            dt.Columns["total"].ColumnName = "subtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);



        }
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);
        }
        //**for samll
        public static void PrintToPrinter1(LocalReport report)
        {
            Export1(report);
        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
            @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            report.EnableExternalImages = true;
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
            if (print)
            {
                Print();
            }

        }

        public static void Export1(LocalReport report, bool print = true)
        {
            string deviceInfo =
            @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.2in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            report.EnableExternalImages = true;
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
            if (print)
            {
                Print();
            }

        }
        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cnnont find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }

        }
        public static Stream CreateStream(string name, string fileNmeExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //Adjust area
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            //draw white background
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            //draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            //prepare for the next page
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }



            private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void txtpid_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void dgvitemrep_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string invid = dgvitemrep.Rows[e.RowIndex].Cells[0].Value.ToString();
            using (var form = new frminvoiceview(invid))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    // string val = form.ReturnValue1;            //values preserved after close


                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dgvitemrep.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvitemrep.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvitemrep.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvitemrep.Columns.Count; j++)
                        {
                            if (dgvitemrep.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvitemrep.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        private void cmbproduct_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            // DataTable dt = sdal.DisplayVat(sdate, edate);
            //productsBLL p = pdal.getproductidfromCode(txtpid.Text);
            //txtpid.Text = p.id.ToString();
            //string myid = p.id.ToString();
           



            DataTable dtp = sdal.DisplaypALLtrans(cmbproduct.SelectedValue.ToString());
            dgvitemrep.DataSource = dtp;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvitemrep.Columns[0].HeaderText = "الرقم";
                dgvitemrep.Columns[1].HeaderText = "التاريخ";
                dgvitemrep.Columns[2].HeaderText = "الكمية";
                dgvitemrep.Columns[3].HeaderText = "السعر";
                dgvitemrep.Columns[4].HeaderText = "الاجمالي";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "No";
                dgvitemrep.Columns[1].HeaderText = "Date";
                dgvitemrep.Columns[2].HeaderText = "Qty";
                dgvitemrep.Columns[3].HeaderText = "Price";
                dgvitemrep.Columns[4].HeaderText = "Total";
            }
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            double mtotal = 0;
            for (int i = 0; i < dgvitemrep.Rows.Count; ++i)
            {
                mtotal += Convert.ToDouble(dgvitemrep.Rows[i].Cells[4].Value);


            }
            txtsubtotal.Text = String.Format("{0:N2}", mtotal);
        }
    }
}
