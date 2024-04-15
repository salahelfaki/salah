using Microsoft.Reporting.WinForms;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    
    public partial class frmpurchaserep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmpurchaserep()
        {
            InitializeComponent();
        }
        purchaseDAL sdal = new purchaseDAL();
        productsDAL pdal = new productsDAL();
        printDAL prdal = new printDAL();

        System.Threading.Thread t = System.Threading.Thread.CurrentThread;

        private void frmpurchaserep_Load(object sender, EventArgs e)
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            DataTable dt = sdal.DisplayPurchase(sdate, edate);

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            DisplayPurchases();
        }
        public void DisplayPurchases()
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            DataTable dt = sdal.DisplayPurchase(sdate, edate);

            dgvpurchase.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvpurchase.Columns[0].HeaderText = "الرقم";
                dgvpurchase.Columns[1].HeaderText = "التاريخ";
                dgvpurchase.Columns[2].HeaderText = "المـورد";
                dgvpurchase.Columns[3].HeaderText = "القيمة";
                dgvpurchase.Columns[4].HeaderText = "الخصم";
                dgvpurchase.Columns[5].HeaderText = "الضريبة";
                dgvpurchase.Columns[6].HeaderText = "الاجمالي";
                dgvpurchase.Columns[7].HeaderText = "المعاملة";
            }
            else
            {
                dgvpurchase.Columns[0].HeaderText = "Inv.No";
                dgvpurchase.Columns[1].HeaderText = "Date";
                dgvpurchase.Columns[2].HeaderText = "Vendor";
                dgvpurchase.Columns[3].HeaderText = "Amount";
                dgvpurchase.Columns[4].HeaderText = "Discount";
                dgvpurchase.Columns[5].HeaderText = "VAT";
                dgvpurchase.Columns[6].HeaderText = "Total";
                dgvpurchase.Columns[7].HeaderText = "Type";

            }

            dgvpurchase.Columns[2].Width = 200;
            dgvpurchase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvpurchase.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvpurchase.Columns[3].DefaultCellStyle.Format = "N2";
            dgvpurchase.Columns[4].DefaultCellStyle.Format = "N2";
            dgvpurchase.Columns[5].DefaultCellStyle.Format = "N2";
            dgvpurchase.Columns[6].DefaultCellStyle.Format = "N2";
            foreach (DataGridViewRow dgvr in dgvpurchase.Rows)
            {
                if (dgvr.Cells[7].Value == null || dgvr.Cells[7].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvr.Cells[7].Value.ToString()))
                {
                    break;
                }
                else
                {

                    string mtype = dgvr.Cells[7].Value.ToString();


                    if (mtype == "4")
                    {

                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                        dgvr.DefaultCellStyle.ForeColor = Color.White;

                    }
                    else
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.White;
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

            }



           
                double subtot = 0;
                double discount = 0;
                double vat = 0;
                double gtotal = 0;


                for (int i = 0; i < dgvpurchase.Rows.Count; ++i)
                {
                    subtot += Convert.ToDouble(dgvpurchase.Rows[i].Cells[3].Value);
                    discount += Convert.ToDouble(dgvpurchase.Rows[i].Cells[4].Value);
                    vat += Convert.ToDouble(dgvpurchase.Rows[i].Cells[5].Value);
                    gtotal += Convert.ToDouble(dgvpurchase.Rows[i].Cells[6].Value);

                }


                
                double mnet = subtot - discount;
                
                txtsubtotal.Text =subtot.ToString("#,0.00");
                txtdiscount.Text = discount.ToString("#,0.00");
                txtnetval.Text = mnet.ToString("#,0.00");
                txtvat.Text = vat.ToString("#,0.00");
                txtgrandtotal.Text = gtotal.ToString("#,0.00");
            
            

        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            DisplayPurchases();
        }

        

        private void btnprnt_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void btnprntA4_Click_1(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            string psubtotal = txtsubtotal.Text;
            string pvat = txtvat.Text;
            string pnet = txtnetval.Text;
            string pdiscount = txtdiscount.Text;
            string pgtotal = txtgrandtotal.Text;
            string sdate = date1.Text;
            string edate = date2.Text;





            if (clogo != "")
            {
                if (File.Exists(clogo))
                {
                    System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                    img2 = resizeImage(img2, new Size(100, 100));
                }

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
            ReportParameter rp3 = new ReportParameter("psubtotal", psubtotal);
            ReportParameter rp4 = new ReportParameter("pvat", pvat);
            ReportParameter rp5 = new ReportParameter("sdate", sdate);
            ReportParameter rp6 = new ReportParameter("edate", edate);
            ReportParameter rp7 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp9 = new ReportParameter("pnet", pnet);
            ReportParameter rp10 = new ReportParameter("pdiscount", pdiscount);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PurRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvpurchase.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvpurchase.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            //change columns names
            dt.Columns["dealer"].ColumnName = "type";
            

            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);
            this.Hide();



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

        private void date1_ValueChanged_1(object sender, EventArgs e)
        {
            DisplayPurchases();
        }

        private void date2_ValueChanged_1(object sender, EventArgs e)
        {
            DisplayPurchases();
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            if (txtsearch.Text.Length > 0)
            {
                
                (dgvpurchase.DataSource as DataTable).DefaultView.RowFilter = $"[id]={txtsearch.Text}";
                //DataTable dt = dal.SearchList(txtsearch.Text);
                //dgvproducts.DataSource = dt;
            }
            else
            {
                DisplayPurchases();
            }


            foreach (DataGridViewRow dgvr in dgvpurchase.Rows)
            {
                if (dgvr.Cells[7].Value == null || dgvr.Cells[7].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvr.Cells[7].Value.ToString()))
                {
                    return;
                }
                else
                {

                    string mtype = dgvr.Cells[7].Value.ToString();


                    if (mtype == "4")
                    {

                        dgvr.DefaultCellStyle.BackColor = Color.Red;
                        dgvr.DefaultCellStyle.ForeColor = Color.White;

                    }
                    else
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.White;
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void btnprnt_Click_1(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            string psubtotal = txtsubtotal.Text;
            string pvat = txtvat.Text;
            string pnet = txtnetval.Text;
            string pdiscount = txtdiscount.Text;
            string pgtotal = txtgrandtotal.Text;
            string sdate = date1.Text;
            string edate = date2.Text;





            if (clogo != "")
            {
                if (File.Exists(clogo))
                {
                    System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                    img2 = resizeImage(img2, new Size(100, 100));
                }

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
            ReportParameter rp3 = new ReportParameter("psubtotal", psubtotal);
            ReportParameter rp4 = new ReportParameter("pvat", pvat);
            ReportParameter rp5 = new ReportParameter("sdate", sdate);
            ReportParameter rp6 = new ReportParameter("edate", edate);
            ReportParameter rp7 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp9 = new ReportParameter("pnet", pnet);
            ReportParameter rp10 = new ReportParameter("pdiscount", pdiscount);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\PurchaseTotalRep.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvpurchase.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvpurchase.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            //change columns names
            dt.Columns["dealer"].ColumnName = "type";
            //dt.Columns["gtotal"].ColumnName = "grandtotal";

            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);
            this.Hide();



        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    for (int i = 0; i < dgvpurchase.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvpurchase.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvpurchase.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvpurchase.Columns.Count; j++)
                        {
                            if (dgvpurchase.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvpurchase.Rows[i].Cells[j].Value.ToString();
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

        private void dgvpurchase_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string invid = dgvpurchase.Rows[e.RowIndex].Cells[0].Value.ToString();
            using (var form = new frmbillview(invid))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {

                    // string val = form.ReturnValue1;            //values preserved after close


                }
            }
        }
    }
}
