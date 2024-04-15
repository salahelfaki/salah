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
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmdailysales : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmdailysales()
        {
            InitializeComponent();
           

        }

        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmdailysales_Load(object sender, EventArgs e)
        {
            
            // DataTable dt = sdal.DisplayAllsales();
           // string mdate = dt1.Value.ToString("yyyy-MM-dd");
            


        }

        private void dt1_ValueChanged(object sender, EventArgs e)
        {
            // CultureInfo provider = new CultureInfo("en-US");

            //DateTime mdate = Convert.ToDateTime(dt1.Text, provider);
            string mdate = dt1.Value.ToString("yyyy-MM-dd");

            //string tdate = mdate.ToString("yyyy-MM-dd");
            //MessageBox.Show(mdate);
            
            DataTable dt = sdal.DisplaySalesByDate(mdate);
            

            
           
            dgvsalesrep.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                if (t.CurrentCulture.Name == "ar-EG")
                {
                    dgvsalesrep.Columns[0].HeaderText = "الرقم";
                    dgvsalesrep.Columns[1].HeaderText = "الصنف";
                    dgvsalesrep.Columns[2].HeaderText = "الكمية";
                    dgvsalesrep.Columns[3].HeaderText = "السعر";
                    dgvsalesrep.Columns[4].HeaderText = "الاجمالي";
                }
                else
                {

                    dgvsalesrep.Columns[0].HeaderText = "No";
                    dgvsalesrep.Columns[1].HeaderText = "Product";
                    dgvsalesrep.Columns[2].HeaderText = "Qty";
                    dgvsalesrep.Columns[3].HeaderText = "Price";
                    dgvsalesrep.Columns[4].HeaderText = "Total";
                }

                dgvsalesrep.Columns[0].Width = 120;
                dgvsalesrep.Columns[1].Width = 320;
                dgvsalesrep.Columns[2].Width = 120;
                dgvsalesrep.Columns[3].Width = 120;
                dgvsalesrep.Columns[4].Width = 120;

                DataTable dtt = sdal.GetDailyTotalSales(mdate);
                if (dtt.Rows.Count > 0)
                {
                    txtsubtotal.Text = dtt.Rows[0]["tsubtotal"].ToString();
                    txtdiscount.Text = dtt.Rows[0]["tdiscount"].ToString();
                    txtgrandtotal.Text = dtt.Rows[0]["tgrand"].ToString();
                    txtvat.Text = dtt.Rows[0]["tvat"].ToString();
                    
                    double netval = double.Parse(txtsubtotal.Text);
                    double ndiscount = double.Parse(txtdiscount.Text);
                    double nvat = double.Parse(txtvat.Text);
                    txtnet.Text = String.Format("{0:#,0.00}",(netval +nvat));
                    txtgrandtotal.Text = String.Format("{0:#,0.00}",(netval+nvat - ndiscount));
                   // string dbvalstring = String.Format("{0:#,0.00}", mdbval);
                }
            }


        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            /*
            DataTable dtall = sdal.DisplayAllsales();
            dgvsalesrep.DataSource = dtall;
            DataTable dts = sdal.GetTotalSales();
            txtsubtotal.Text = dts.Rows[0]["tsubtotal"].ToString();
            txtnet.Text = dts.Rows[0]["tvat"].ToString();
            txtgrandtotal.Text = dts.Rows[0]["tgrand"].ToString();
            */
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
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
            //var mytr = cmd3.ExecuteScalar();
            //string myt = mytr.ToString();
            //txtinventory.Text = myt;
            string cname = dtr.Rows[0]["cname"].ToString();
            string caddress = dtr.Rows[0]["caddress"].ToString();
            string cvatno = dtr.Rows[0]["cvatno"].ToString();
            string clogo = dtr.Rows[0]["clogo"].ToString();
            //mitemname = dt.Rows[0]["name"].ToString();
            myconn.Close();
            Pen blackPen = new Pen(Color.Black, 1);
            int x1 = 10;
            int y1 = 50;
            int x2 = 280;
            int y2 = 50;
            PointF point1 = new PointF(10.0F, 10.0F);
            PointF point2 = new PointF(10.0F, 240.0F);

            // System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);

            //img2 = resizeImage(img2, new Size(50, 50));



          
            e.Graphics.DrawString("المبيعات اليومية", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(180, 10), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("  تاريخ اليوم:   " + tdate , new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(230, 30), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
            e.Graphics.DrawString("الصنف                      الكمية       السعر       الاجمالي ", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(280, 70), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, y1 + 40, x2, y2 + 40);
            int j = 100;

            for (int i = 0; i < dgvsalesrep.Rows.Count - 1; i++)
            {

                //string mpid = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                string mpname = dgvsalesrep.Rows[i].Cells[1].Value.ToString();
                string mqty = dgvsalesrep.Rows[i].Cells[2].Value.ToString();
                string mrate = dgvsalesrep.Rows[i].Cells[3].Value.ToString();
                string mtotal = dgvsalesrep.Rows[i].Cells[4].Value.ToString();

                e.Graphics.DrawString(mpname, new Font("arial", 8), Brushes.Black, new Point(280, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mqty, new Font("arial", 8), Brushes.Black, new Point(160, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mrate, new Font("arial", 8), Brushes.Black, new Point(110, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mtotal, new Font("arial", 8), Brushes.Black, new Point(50, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                

                j = j + 20;
            }
            e.Graphics.DrawLine(blackPen, x1, j, x2, j);
            e.Graphics.DrawString("اجمالي المبيعات", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtsubtotal.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("اجمالي الخصم", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, j+20), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtdiscount.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, j + 20), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("اجمالي خاضع للضريبة", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, j+40), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtnet.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, j+40), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("ضريبة القيمة المضافة", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, j + 60), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtvat.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, j + 60), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("الاجمالي ", new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(280, j + 80), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtgrandtotal.Text, new Font("arial", 8, FontStyle.Regular), Brushes.Black, new Point(60, j + 80), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            
            
        }

        private void btnprnt_Click(object sender, EventArgs e)
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

            string invdate = dt1.Text;

            string psubtotal = txtsubtotal.Text;
            string pvat = txtvat.Text;
            string pnet = txtnet.Text;
            string pdiscount = txtdiscount.Text;
            string pgtotal = txtgrandtotal.Text;





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
            ReportParameter rp3 = new ReportParameter("psubtotal", psubtotal);
            ReportParameter rp4 = new ReportParameter("pvat", pvat);
            ReportParameter rp5 = new ReportParameter("pnet", pnet);
            ReportParameter rp6 = new ReportParameter("pdiscount", pdiscount);
            ReportParameter rp7 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\dysalesRepsmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
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
            dt.Columns["item"].ColumnName = "name";
            dt.Columns["price"].ColumnName = "rate";
            dt.Columns["amount"].ColumnName = "total";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
            DataTable dt = new DataTable();
            da.Fill(dt);
            //var mytr = cmd3.ExecuteScalar();
            //string myt = mytr.ToString();
            //txtinventory.Text = myt;
            string cname = dt.Rows[0]["cname"].ToString();
            string caddress = dt.Rows[0]["caddress"].ToString();
            string cvatno = dt.Rows[0]["cvatno"].ToString();
            string clogo = dt.Rows[0]["clogo"].ToString();
            //mitemname = dt.Rows[0]["name"].ToString();
            myconn.Close();
            Pen blackPen = new Pen(Color.Black, 1);
            int x1 = 10;
            int y1 = 70;
            int x2 = 750;
            int y2 = 70;
            PointF point1 = new PointF(10.0F, 10.0F);
            PointF point2 = new PointF(10.0F, 240.0F);

            // System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);

            //img2 = resizeImage(img2, new Size(50, 50));


            e.Graphics.DrawString(cname, new Font("arial", 14, FontStyle.Bold), Brushes.Black, new Point(450, 10), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            
            e.Graphics.DrawString("المبيعات اليومية", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 50), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("  تاريخ اليوم:   " + tdate, new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(200, 50), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, y1, x2, y2);
            e.Graphics.DrawString("الصنف                                                                      الكمية                السعر                               الاجمالي ", new Font("arial", 12, FontStyle.Regular), Brushes.Black, new Point(750, 90), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, y1 + 40, x2, y2 + 40);
            int j = 130;

            for (int i = 0; i < dgvsalesrep.Rows.Count - 1; i++)
            {

                //string mpid = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                string mpname = dgvsalesrep.Rows[i].Cells[1].Value.ToString();
                string mqty = dgvsalesrep.Rows[i].Cells[2].Value.ToString();
                string mrate = dgvsalesrep.Rows[i].Cells[3].Value.ToString();
                string mtotal = dgvsalesrep.Rows[i].Cells[4].Value.ToString();

                e.Graphics.DrawString(mpname, new Font("arial", 10), Brushes.Black, new Point(750, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mqty, new Font("arial", 10), Brushes.Black, new Point(390, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mrate, new Font("arial", 10), Brushes.Black, new Point(280, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));
                e.Graphics.DrawString(mtotal, new Font("arial", 10), Brushes.Black, new Point(100, j), new StringFormat(StringFormatFlags.DirectionRightToLeft));


                j = j + 20;
            }
            
            e.Graphics.DrawLine(blackPen, x1, j, x2, j);
            e.Graphics.DrawString("اجمالي المبيعات", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, j+20), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtsubtotal.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(100, j+20), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("اجمالي الخصم", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, j +40), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtdiscount.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(100, j + 40), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("اجمالي خاضع للضريبة", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, j + 60), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtnet.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(100, j + 60), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("ضريبة القيمة المضافة", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, j + 80), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtvat.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(100, j + 80), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString("الاجمالي ", new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(750, j + 100), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawString(txtgrandtotal.Text, new Font("arial", 10, FontStyle.Regular), Brushes.Black, new Point(100, j + 100), new StringFormat(StringFormatFlags.DirectionRightToLeft));
            e.Graphics.DrawLine(blackPen, x1, j+120, x2, j+120);

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

            string invdate = dt1.Text;

            string psubtotal = txtsubtotal.Text;
            string pvat = txtvat.Text;
            string pnet = txtnet.Text;
            string pdiscount = txtdiscount.Text;
            string pgtotal = txtgrandtotal.Text;





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
            ReportParameter rp3 = new ReportParameter("psubtotal", psubtotal);
            ReportParameter rp4 = new ReportParameter("pvat", pvat);
            ReportParameter rp5 = new ReportParameter("pnet", pnet);
            ReportParameter rp6 = new ReportParameter("pdiscount", pdiscount);
            ReportParameter rp7 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\dysalesRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7,rp8 });
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
            dt.Columns["item"].ColumnName = "name";
            dt.Columns["price"].ColumnName = "rate";
            dt.Columns["amount"].ColumnName = "total";
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


        private void btnprnt2_Click(object sender, EventArgs e)
        {
            printPreview.Document = printDoc;
            printDoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            printPreview.ShowDialog();
        }
    }
}
