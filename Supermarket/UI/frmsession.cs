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
    public partial class frmsession : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmsession()
        {
            InitializeComponent();
        }
        public string madd = "";
        public string fadd = "";
        public string msess = "";
        sessionBLL c = new sessionBLL();
        sessionDAL dal = new sessionDAL();
        usersDAL udal = new usersDAL();
        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmsession_Load(object sender, EventArgs e)
        {
            string sdate = date1.Value.ToString("yyyy-MM-dd");
            if (t.CurrentCulture.Name == "ar-EG")
            {


                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                msess = "اغلاق جلسة العمل المفتوحة";



            }
            else
            {


                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                msess = "Close Opened Session";


            }
            string sql2 = "Select id,sessionuser from tbl_sessions where status=1";// AND date(startdate)='" + sdate + "'";
            SqlConnection conn = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand(sql2, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sessions");

            cmbproduct.DataSource = ds.Tables["sessions"];
            cmbproduct.DisplayMember = "id";
            cmbproduct.ValueMember = "id";
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show("لاتوجد ورديات");
                this.Close();
            }


            conn.Close();
            
        }

        private void cmbproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
           // string mysid = cmbproduct.Text.ToString();
            //MessageBox.Show(mysid);
            int sid = 0;
            bool parseOK = Int32.TryParse(cmbproduct.Text.ToString(), out sid);
            txtsno.Text = sid.ToString();
            DataTable sdat = sdal.GetSessionSales(sid);
            DataTable ssdat = dal.GetSessionDetails(sid);
            
            string startdate = ssdat.Rows[0]["startdate"].ToString();
            string enddate = ssdat.Rows[0]["enddate"].ToString();
            DateTime ms = DateTime.Parse(startdate);
            DateTime me = DateTime.Parse(enddate);
            txtsdate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", ms);
            txtedate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", me);
            dgvitemrep.DataSource = sdat;
            if (t.CurrentCulture.Name == "ar-EG")
            {


                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                msess = "اغلاق جلسة العمل المفتوحة";
                dgvitemrep.Columns[0].HeaderText = "رقم الفاتورة";
                // dgvitemrep.Columns[1].HeaderText = "العميل";
                // dgvitemrep.Columns[1].HeaderText = "نوع الطلب";
                dgvitemrep.Columns[1].HeaderText = "نقدا";
                dgvitemrep.Columns[2].HeaderText = "بطاقة-بنك";
                dgvitemrep.Columns[3].HeaderText = "آجل";


            }
            else
            {


                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                msess = "Close Opened Session";
                dgvitemrep.Columns[0].HeaderText = "Inv No";
                // dgvitemrep.Columns[1].HeaderText = "Customer";
                // dgvitemrep.Columns[1].HeaderText = "Type";
                dgvitemrep.Columns[1].HeaderText = "Cash";
                dgvitemrep.Columns[2].HeaderText = "Card-Bank";
                dgvitemrep.Columns[3].HeaderText = "Credit";

            }
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            for (int i = 0; i < dgvitemrep.Rows.Count; ++i)
            {
                sum1 += Convert.ToDouble(dgvitemrep.Rows[i].Cells[1].Value);
                sum2 += Convert.ToDouble(dgvitemrep.Rows[i].Cells[2].Value);
                sum3 += Convert.ToDouble(dgvitemrep.Rows[i].Cells[3].Value);
                txtcashtotal.Text = sum1.ToString();
                txtcardtotal.Text = sum2.ToString();
                txtcredittotal.Text = sum3.ToString();
                txttotalsales.Text = (sum1 + sum2 + sum3).ToString();
            }



        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            //DataTable dts = GetSalesData();


            string luser = frmlogin.loggedin;


            //*************************

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("sdate", txtsdate.Text);
            ReportParameter rp3 = new ReportParameter("edate", txtedate.Text);
            ReportParameter rp4 = new ReportParameter("luser", cmbproduct.Text);
            ReportParameter rp5 = new ReportParameter("stotal", txttotalsales.Text);
            ReportParameter rp7 = new ReportParameter("desc", txtsno.Text);
            ReportParameter rp8 = new ReportParameter("totalcash", txtcashtotal.Text);
            ReportParameter rp9 = new ReportParameter("totalcard", txtcardtotal.Text);
            ReportParameter rp10 = new ReportParameter("totalcredit", txtcredittotal.Text);
            ReportParameter rp11 = new ReportParameter("gtotal", txttotalsales.Text);

            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\sessionRepSmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11 });
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
            dt.Columns["id"].ColumnName = "id";
           // dt.Columns["ordertype"].ColumnName = "trtype";
            dt.Columns["paid"].ColumnName = "paid";
            dt.Columns["paycard"].ColumnName = "discount";
            dt.Columns["paycredit"].ColumnName = "subtotal";



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
    }
}

