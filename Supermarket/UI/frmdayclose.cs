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
    public partial class frmdayclose : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmdayclose()
        {
            InitializeComponent();
        }
        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        string loggedinuser = frmlogin.loggedin;

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            // CultureInfo provider = new CultureInfo("en-US");

            //DateTime mdate = Convert.ToDateTime(dt1.Text, provider);
            string mdate = dt1.Value.ToString("yyyy-MM-dd");

            //string tdate = mdate.ToString("yyyy-MM-dd");
            //MessageBox.Show(mdate);

            DataTable dt = sdal.GetCloseDayTotalSales(mdate);

            dgvsalesrep.DataSource = dt;
            
            if (dt.Rows.Count > 0)
            {
                
                if (t.CurrentCulture.Name == "ar-EG")
                {
                    dgvsalesrep.Columns[0].HeaderText = "نقـدا";
                    dgvsalesrep.Columns[1].HeaderText = "بطاقة ائتمان";
                    dgvsalesrep.Columns[2].HeaderText = " اجمالي البيع";
                    dgvsalesrep.Columns[3].HeaderText = " الفرق";
                    


                }
                else
                {

                    dgvsalesrep.Columns[0].HeaderText = "Cash";
                    dgvsalesrep.Columns[1].HeaderText = "Credit Card";
                    dgvsalesrep.Columns[2].HeaderText = "Total Sales";
                    dgvsalesrep.Columns[3].HeaderText = "Difference";






                }

                dgvsalesrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                
                txtcash.Text = dt.Rows[0]["cash"].ToString();
                txtcard.Text = dt.Rows[0]["card"].ToString();
                txttotal.Text = dt.Rows[0]["total"].ToString();
                txtdiff.Text = dt.Rows[0]["diff"].ToString();







            }
            else
            {
                MessageBox.Show("No Transaction");
            }
        }

        private void printDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //************
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            // Get initial variables
            string tdate = dt1.Value.ToString("yyyy-MM-dd");
            string mysql = "select cname,caddress,cvatno,clogo from company where id=1";
            SqlConnection myconn = new SqlConnection(myconnstrng);
            myconn.Open();
            SqlCommand cmd3 = new SqlCommand(mysql, myconn);
            SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);
            DataTable dtr = new DataTable();
            da.Fill(dtr);

            string cname = dtr.Rows[0]["cname"].ToString();
            string caddress = dtr.Rows[0]["caddress"].ToString();
            string cvatno = dtr.Rows[0]["cvatno"].ToString();
            string clogo = dtr.Rows[0]["clogo"].ToString();
            //mitemname = dt.Rows[0]["name"].ToString();
            myconn.Close();
            Pen blackPen = new Pen(Color.Black, 1);
            int x1 = 10;
            int y1 = 90;
            int x2 = 280;
            int y2 = 90;
            PointF point1 = new PointF(10.0F, 10.0F);
            PointF point2 = new PointF(10.0F, 240.0F);




            e.Graphics.DrawString(cname, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(180, 10), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(caddress, new Font("arial", 10, FontStyle.Bold), Brushes.Black, new Point(180, 30), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            e.Graphics.DrawString(" تقرير اغلاق اليوم", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(180, 50), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("  تاريخ اليوم:   " + tdate, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(230, 70), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(" امين الصندوق   " + loggedinuser, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(230, 90), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            e.Graphics.DrawLine(blackPen, x1, 110, x2, 110);
            e.Graphics.DrawString("الدفع                                               المدفوع        ", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(280, 120), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, 140, x2, 140);


            e.Graphics.DrawString("نقـدا", new Font("arial", 8), Brushes.Black, new Point(280, 150), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtcash.Text, new Font("arial", 8), Brushes.Black, new Point(60, 150), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("بطاقة", new Font("arial", 8), Brushes.Black, new Point(280, 170), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtcard.Text, new Font("arial", 8), Brushes.Black, new Point(60, 170), new StringFormat(StringFormatFlags.DirectionRightToLeft));


            e.Graphics.DrawLine(blackPen, x1, 190, x2, 190);
            e.Graphics.DrawString("الاجمالي", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, 210), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txttotal.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, 210), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("الفرق", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, 230), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtdiff.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, 230), new StringFormat(StringFormatFlags.DirectionRightToLeft));



        }

        private void printDocA4_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //************
            StringFormat sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            // Get initial variables
            string tdate = dt1.Value.ToString("yyyy-MM-dd");
            string mysql = "select cname,caddress,cvatno,clogo from company where id=1";
            SqlConnection myconn = new SqlConnection(myconnstrng);
            myconn.Open();
            SqlCommand cmd3 = new SqlCommand(mysql, myconn);
            SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);
            DataTable dtr = new DataTable();
            da.Fill(dtr);

            string cname = dtr.Rows[0]["cname"].ToString();
            string caddress = dtr.Rows[0]["caddress"].ToString();
            string cvatno = dtr.Rows[0]["cvatno"].ToString();
            string clogo = dtr.Rows[0]["clogo"].ToString();
            //mitemname = dt.Rows[0]["name"].ToString();
            myconn.Close();
            Pen blackPen = new Pen(Color.Black, 1);
            int x1 = 10;
            int y1 = 90;
            int x2 = 750;
            int y2 = 90;
            PointF point1 = new PointF(10.0F, 10.0F);
            PointF point2 = new PointF(10.0F, 240.0F);




            e.Graphics.DrawString(cname, new Font("arial", 14, FontStyle.Bold), Brushes.Black, new Point(450, 10), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(caddress, new Font("arial", 12, FontStyle.Bold), Brushes.Black, new Point(450, 30), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            e.Graphics.DrawString(" تقرير اغلاق اليوم", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(450, 50), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("  تاريخ اليوم:   " + tdate, new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 70), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(" امين الصندوق   " + loggedinuser, new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 90), new StringFormat(StringFormatFlags.DirectionRightToLeft));

            e.Graphics.DrawLine(blackPen, x1, 110, x2, 110);
            e.Graphics.DrawString(" طريقة الدفع         ", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 120), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(" المبلغ المدفوع  ", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(100, 120), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, 140, x2, 140);


            e.Graphics.DrawString("نقـدا", new Font("arial", 10), Brushes.Black, new Point(750, 150), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtcash.Text, new Font("arial", 10), Brushes.Black, new Point(60, 150), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("بطاقة", new Font("arial", 10), Brushes.Black, new Point(750, 170), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtcard.Text, new Font("arial", 10), Brushes.Black, new Point(60, 170), new StringFormat(StringFormatFlags.DirectionRightToLeft));


            e.Graphics.DrawLine(blackPen, x1, 190, x2, 190);
            e.Graphics.DrawString("الاجمالي", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, 210), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txttotal.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(60, 210), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("الفرق", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, 230), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtdiff.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(60, 230), new StringFormat(StringFormatFlags.DirectionRightToLeft));


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            /*
            printPreview.Document = printDocA4;
            printDocA4.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 800, 1200);
            printPreview.ShowDialog();
            */
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            
            string luser =frmlogin.loggedin;
            
           
            string invdate = dt1.Text;
            string total = txttotal.Text;
            string diff = txtdiff.Text;

            string muser = "Not found!!!";




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
            if(luser=="")
            {
                muser = "tttttttttttt";
                
            }
            else
            {
                muser = luser;
            }

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("luser",luser);
            ReportParameter rp4 = new ReportParameter("stotal", total);
            ReportParameter rp5 = new ReportParameter("sdiff", diff);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\daycloseRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvsalesrep.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvsalesrep.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            //change columns names
            dt.Columns["cash"].ColumnName = "paid";
            dt.Columns["card"].ColumnName = "subtotal";
            dt.Columns["total"].ColumnName = "grandtotal";
            dt.Columns["diff"].ColumnName = "vat";
            
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




        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    

        private void btnprnt_Click(object sender, EventArgs e)
        {
            printPreview.Document = printDoc;
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            printPreview.ShowDialog();
        }
    }
}
