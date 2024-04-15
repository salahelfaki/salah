using Microsoft.Reporting.WinForms;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmacctbalrep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmacctbalrep()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        accttrDAL sdal = new accttrDAL();
        printDAL prdal = new printDAL();

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmacctbalrep_Load(object sender, EventArgs e)
        {
            DataTable dtp = sdal.DisplayAcctBalance();
           

            

            dgvitemrep.DataSource = dtp;
            dgvitemrep.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvitemrep.EnableHeadersVisualStyles = false;
            dgvitemrep.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvitemrep.Columns[0].HeaderText = "رقم الحساب";
                dgvitemrep.Columns[1].HeaderText = "اسم الحساب";
                dgvitemrep.Columns[2].HeaderText = "مدين";
                dgvitemrep.Columns[3].HeaderText = "دائن";
                dgvitemrep.Columns[4].HeaderText = "الرصيد";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "AcctCode";
                dgvitemrep.Columns[1].HeaderText = "Account Name";
                dgvitemrep.Columns[2].HeaderText = "Debit";
                dgvitemrep.Columns[3].HeaderText = "Credit";
                dgvitemrep.Columns[4].HeaderText = "Balance";

            }

            
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvitemrep.Columns[0].Width = 280;
            double a = 0;
            double b = 0;
            double c = 0;
            foreach (DataGridViewRow r in dgvitemrep.Rows)
            {

                a += Convert.ToDouble(r.Cells[2].Value);
                b += Convert.ToDouble(r.Cells[3].Value);
                c += Convert.ToDouble(r.Cells[4].Value);

            }

            //Totals
            
            txtdbtotal.Text = a.ToString("#,0.00");
            txtcrtotal.Text= b.ToString("#,0.00");
            txtbalance.Text= c.ToString("#,0.00");





        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            string dbtotal = txtdbtotal.Text;
            string crtotal = txtcrtotal.Text;
            string balance = txtbalance.Text;
            





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
            ReportParameter rp3 = new ReportParameter("dbtotal", dbtotal);
            ReportParameter rp4 = new ReportParameter("crtotal", crtotal);
            ReportParameter rp5 = new ReportParameter("balance", balance);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\acctbalRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
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
            dt.Columns["payacct"].ColumnName = "description";
            dt.Columns["acctname"].ColumnName = "customer";
            dt.Columns["balance"].ColumnName = "subtotal";
            dt.Columns["debit"].ColumnName = "vat";
            dt.Columns["credit"].ColumnName = "grandtotal";
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
                PrintA4();
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

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            string dbtotal = txtdbtotal.Text;
            string crtotal = txtcrtotal.Text;
            string balance = txtbalance.Text;






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
            ReportParameter rp3 = new ReportParameter("dbtotal", dbtotal);
            ReportParameter rp4 = new ReportParameter("crtotal", crtotal);
            ReportParameter rp5 = new ReportParameter("balance", balance);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\acctbalRepsmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
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
            dt.Columns["payacct"].ColumnName = "description";
            dt.Columns["acctname"].ColumnName = "customer";
            dt.Columns["balance"].ColumnName = "subtotal";
            dt.Columns["debit"].ColumnName = "vat";
            dt.Columns["credit"].ColumnName = "grandtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);


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
    }
}
