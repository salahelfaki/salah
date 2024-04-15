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
    public partial class frmaccttrep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmaccttrep()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        accttrDAL sdal = new accttrDAL();
        acctsDAL pdal = new acctsDAL();
        printDAL prdal = new printDAL();

        private void frmaccttrep_Load(object sender, EventArgs e)
        {
            string sdate = dt1.Value.ToString("yyyy-MM-dd");
            string edate = dt2.Value.ToString("yyyy-MM-dd");
            //DataTable dt = sdal.DisplayVat(sdate, edate);

            string sql2 = "Select acctcode,acctname from tbl_accts";
            SqlConnection conn2 = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand(sql2, conn2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, "accts");

            

            cmbacctname.DisplayMember = "acctname";

            cmbacctname.ValueMember = "acctcode";
            cmbacctname.DataSource = ds.Tables["accts"];
            
            conn2.Close();
        }

       

        private void cmbacctname_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            DateTime sdate = dt1.Value.Date;
            DateTime edate = dt2.Value.Date;
            DataTable dtp = sdal.DisplayAcctTrans(cmbacctname.SelectedValue.ToString(),sdate,edate);

            dgvitemrep.DataSource = dtp;
            
            
            
            dgvitemrep.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvitemrep.EnableHeadersVisualStyles = false;
            dgvitemrep.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvitemrep.Columns[0].HeaderText = "التاريخ";
                dgvitemrep.Columns[1].HeaderText = "الرقم";
                dgvitemrep.Columns[2].HeaderText = "المعاملة";
                dgvitemrep.Columns[3].HeaderText = "البيان";
                dgvitemrep.Columns[4].HeaderText = "مدين";
                dgvitemrep.Columns[5].HeaderText = "دائن";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "Date";
                dgvitemrep.Columns[1].HeaderText = "No.";
                dgvitemrep.Columns[2].HeaderText = "Type";
                dgvitemrep.Columns[3].HeaderText = "Description";
                dgvitemrep.Columns[4].HeaderText = "DR";
                dgvitemrep.Columns[5].HeaderText = "CR";

            }
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvitemrep.Columns[1].Width = 70;
            dgvitemrep.Columns[3].Width = 180;

            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;

            double f = 0;
            foreach (DataGridViewRow dgvr in dgvitemrep.Rows)
            {
                if (dgvr.Cells[2].Value == null || dgvr.Cells[2].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvr.Cells[2].Value.ToString()))
                {
                    break;
                }
                else
                {

                    string mtype = dgvr.Cells[2].Value.ToString();


                    if (mtype == "1")
                    {

                        dgvr.Cells[2].Value = "مبيعات";
                        //dgvr.DefaultCellStyle.ForeColor = Color.Red;

                    }
                    else
                    {
                        dgvr.DefaultCellStyle.BackColor = Color.White;
                        dgvr.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }

                a += Convert.ToDouble(dgvr.Cells[4].Value);
                b += Convert.ToDouble(dgvr.Cells[5].Value);
                //c += Convert.ToDouble(dgvr.Cells[5].Value);
                //d += Convert.ToDouble(dgvr.Cells[6].Value);
                f = a - b;

            }

            txtdbtotal.Text = a.ToString("#,0.00");
            txtcrtotal.Text = b.ToString("#,0.00");
            
            txtbalance.Text = f.ToString("#,0.00");

        }

        

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
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
            string sdate = dt1.Text;
            string edate = dt2.Text;





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
            ReportParameter rp5 = new ReportParameter("sdate", sdate);
            ReportParameter rp6 = new ReportParameter("edate", edate);
            ReportParameter rp7 = new ReportParameter("balance", balance);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            ReportParameter rp9 = new ReportParameter("acctname", cmbacctname.Text);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\acctRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8,rp9 });
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
            dt.Columns["number"].ColumnName = "id";
            dt.Columns["type"].ColumnName = "trtype";
            dt.Columns["date"].ColumnName = "trdate";
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
            string sdate = dt1.Text;
            string edate = dt2.Text;





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
            ReportParameter rp5 = new ReportParameter("sdate", sdate);
            ReportParameter rp6 = new ReportParameter("edate", edate);
            ReportParameter rp7 = new ReportParameter("balance", balance);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);
            ReportParameter rp9 = new ReportParameter("acctname", cmbacctname.Text);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\acctRepsmall.rdlc";
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
            dt.Columns["number"].ColumnName = "id";
            dt.Columns["type"].ColumnName = "trtype";
            dt.Columns["date"].ColumnName = "trdate";
            dt.Columns["debit"].ColumnName = "vat";
            dt.Columns["credit"].ColumnName = "grandtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);

        }
    }
}
