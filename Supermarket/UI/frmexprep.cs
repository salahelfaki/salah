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
    public partial class frmexprep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmexprep()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        accttrDAL acdal = new accttrDAL();
        printDAL prdal = new printDAL();
        DataTable dt = new DataTable();

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmexprep_Load(object sender, EventArgs e)
        {
            
            DisplayExpense();
           
        }
        private void DisplayExpense()
        {
            DateTime sdate = dtp1.Value.Date;
            DateTime edate = dtp2.Value.Date;
            dt = acdal.GetExpenses(sdate,edate);

            dgvitemrep.DataSource = dt;

            dgvitemrep.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvitemrep.EnableHeadersVisualStyles = false;
            dgvitemrep.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvitemrep.Columns[0].HeaderText = "الرقم";
                dgvitemrep.Columns[1].HeaderText = "التاريخ";
                dgvitemrep.Columns[2].HeaderText = "البيان";
                dgvitemrep.Columns[3].HeaderText = "المبلغ";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "No.";
                dgvitemrep.Columns[1].HeaderText = "Date";
                dgvitemrep.Columns[2].HeaderText = "Description";
                dgvitemrep.Columns[3].HeaderText = "Amount";

            }


            dgvitemrep.Columns[1].Width = 300;
            dgvitemrep.AutoSizeColumnsMode = (DataGridViewAutoSizeColumnsMode)DataGridViewAutoSizeColumnMode.Fill;
            dgvitemrep.Columns[3].DefaultCellStyle.Format = "N2";
            dgvitemrep.Columns[1].DefaultCellStyle.Format = "dd-MM-yyyy";
            dgvitemrep.Columns[1].ValueType = typeof(DateTime);



            int a = 0;
            foreach (DataGridViewRow r in dgvitemrep.Rows)
            {

                a += Convert.ToInt32(r.Cells[3].Value);
            }
            txtbalance.Text = a.ToString("#,0.00");
        }
        
        private void btnprint_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            //string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            // string dbtotal = txtdbtotal.Text;
            //string crtotal = txtcrtotal.Text;
            string balance = txtbalance.Text;
            string sdate = dtp1.Text;
            string edate = dtp2.Text;






            //*************************


            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("sdate", sdate);
            ReportParameter rp3 = new ReportParameter("edate", edate);
            ReportParameter rp4 = new ReportParameter("balance", balance);
            // ReportParameter rp8 = new ReportParameter();
            //rp8.Name = "logo";
            //rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ExpRepSmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
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

            dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["amount"].ColumnName = "subtotal";
            dt.Columns["description"].ColumnName = "description";
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

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            //string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            // string dbtotal = txtdbtotal.Text;
            //string crtotal = txtcrtotal.Text;
            string balance = txtbalance.Text;
            string sdate = dtp1.Text;
            string edate = dtp2.Text;






            //*************************


            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("sdate", sdate);
            ReportParameter rp3 = new ReportParameter("edate", edate);
            ReportParameter rp4 = new ReportParameter("balance", balance);
            // ReportParameter rp8 = new ReportParameter();
            //rp8.Name = "logo";
            //rp8.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ExpRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4 });
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

            dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["amount"].ColumnName = "subtotal";
            dt.Columns["description"].ColumnName = "description";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);

        }

        private void dtp1_ValueChanged(object sender, EventArgs e)
        {
            DisplayExpense();
        }

        private void dtp2_ValueChanged(object sender, EventArgs e)
        {
            DisplayExpense();
        }
    }
}
