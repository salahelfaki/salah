using Microsoft.Reporting.WinForms;
using Supermarket.BLL;
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
    public partial class frmitemtr : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmitemtr()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        salesDAL sdal = new salesDAL();
        productsDAL pdal = new productsDAL();
        printDAL prdal = new printDAL();
        purchaseDAL purdal = new purchaseDAL();

        private void frmitemtr_Load(object sender, EventArgs e)
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            
            txtbarcode.Focus();
            
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            DisplayData();
          
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {

            DisplayData();
          
        }

        private void DisplayData()
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            string tpid = txtbarcode.Text;

            DataTable dti = sdal.Displayptrans(sdate, edate, tpid);

            

            for (int i = 0; i < dti.Rows.Count; i++)
            {
                string mtype = dti.Rows[i]["trtype"].ToString();
                switch(mtype){
                    case "1":
                        dti.Rows[i][2] = "مبيعات";
                        break;
                    case "2":
                        dti.Rows[i][2] = "مرتجع مبيعات";
                        break;
                    case "3":
                        dti.Rows[i][2] = "مشتريات";
                        break;
                    case "4":
                        dti.Rows[i][2] = "مرتجع مشتريات";
                        break;
                    case "9":
                        dti.Rows[i][2] = "تسوية مخزون";
                        break;
                    default:
                        
                        break;

                }
                
            }
            
            dgvitemrep.DataSource = dti;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvitemrep.Columns[0].HeaderText = "الرقم";
                dgvitemrep.Columns[1].HeaderText = "التاريخ";
                dgvitemrep.Columns[2].HeaderText = "البيان";
                dgvitemrep.Columns[3].HeaderText = "الوارد";
                dgvitemrep.Columns[4].HeaderText = "المنصرف";
                dgvitemrep.Columns[5].HeaderText = "الرصيد";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "No";
                dgvitemrep.Columns[1].HeaderText = "Date";
                dgvitemrep.Columns[2].HeaderText = "Description";
                dgvitemrep.Columns[3].HeaderText = "Received";
                dgvitemrep.Columns[4].HeaderText = "Issued";
                dgvitemrep.Columns[5].HeaderText = "Balance";
            }

            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void txtbarcode_KeyDown(object sender, KeyEventArgs e)
        {
            getValues();
        }
        private void getValues()
        {
            productsBLL p = pdal.GetProduct(txtbarcode.Text);
            txtpname.Text = p.pname;
            txtqtyhand.Text = p.qty.ToString();
            GetproductTotalSales(txtbarcode.Text);
           
            //txtsales.Text = tsales.ToString("#,0.00");
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            using (var form = new frmprodlist())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close

                    txtbarcode.Text = val;

                    txtbarcode.Focus();
                }
            }
            getValues();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetproductTotalSales(string barcode)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            decimal totalSales = 0;



            string sql = "SELECT ISNULL((SELECT sum(total) as total from tbl_sdetail where barcode=@mypid),0) As total";
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnstrng))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@mypid", barcode);

                        // Execute the query and retrieve the result
                        totalSales = Convert.ToDecimal(command.ExecuteScalar());

                        // Display the result (you can update this based on your UI)
                        txtsales.Text = totalSales.ToString("#,0.00");
                        
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            //return totalSales;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            
            string sdate = date1.Text;
            string edate = date2.Text;
            





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
            ReportParameter rp2 = new ReportParameter("barcode", txtbarcode.Text);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("pname", txtpname.Text);
            ReportParameter rp6 = new ReportParameter("pgtotal", txtsales.Text);
            ReportParameter rp8 = new ReportParameter("qtyhand", txtqtyhand.Text);
            ReportParameter rp9 = new ReportParameter("invdate", DateTime.Now.ToString("yyyy-MM-dd"));
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\itemtranssmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7,rp8,rp9 });
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
            //dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["balance"].ColumnName = "grandtotal";
            dt.Columns["inqty"].ColumnName = "discount";
            dt.Columns["outqty"].ColumnName = "subtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);



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
                PrintA4();
            }

        }
        public static void PrintA4()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();

            printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
            PrintDialog pdi = new PrintDialog();
            m_currentPageIndex = 0;

            pdi.Document = printDoc;
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                // printDoc.DocumentName = documentName;
                printDoc.Print();
            }
            else
            {
                MessageBox.Show("Print Cancelled");
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



        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();


            string sdate = date1.Text;
            string edate = date2.Text;






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
            ReportParameter rp2 = new ReportParameter("barcode", txtbarcode.Text);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("pname", txtpname.Text);
            ReportParameter rp6 = new ReportParameter("pgtotal", txtsales.Text);
            ReportParameter rp8 = new ReportParameter("qtyhand", txtqtyhand.Text);
            ReportParameter rp9 = new ReportParameter("invdate", DateTime.Now.ToString("yyyy-MM-dd"));
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\itemtransA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9 });
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
            //dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["balance"].ColumnName = "grandtotal";
            dt.Columns["inqty"].ColumnName = "discount";
            dt.Columns["outqty"].ColumnName = "subtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);



        }
    }
}
