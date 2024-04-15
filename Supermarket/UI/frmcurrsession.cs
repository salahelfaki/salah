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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmcurrsession : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmcurrsession()
        {
            InitializeComponent();
        }
        public string madd = "";
        public string fadd = "";
        public string msess = "";
        public string sessopen = "";
        sessionBLL c = new sessionBLL();
        sessionDAL dal = new sessionDAL();
        usersDAL udal = new usersDAL();
        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmcurrsession_Load(object sender, EventArgs e)
        {
            string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
            if (t.CurrentCulture.Name == "ar-EG")
            {


                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                msess = "اغلاق جلسة العمل المفتوحة";
                sessopen = "لا توجد وردية مفتوحة";


            }
            else
            {


                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                msess = "Close Opened Session";
                sessopen = "No open shift";

            }
            SqlConnection conn = new SqlConnection(myconnstrng);
            string sql2 = "Select id,sessionuser from tbl_sessions where status='0' ";
            SqlCommand cmd = new SqlCommand(sql2, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sessions");
            conn.Close();
            if (ds.Tables[0].Rows.Count == 0)
            {
                MessageBox.Show(sessopen);
                this.Close();
            }
            else
            {
                cmbproduct.DataSource = ds.Tables["sessions"];
                cmbproduct.DisplayMember = "id";
                cmbproduct.ValueMember = "id";


                

            //
            int sid=0;
            
                bool parseOK = Int32.TryParse(cmbproduct.SelectedValue.ToString(), out sid);
                txtsno.Text = sid.ToString();

                DataTable sdat = sdal.GetSessionSalesSummary(sid);
                DataTable ssdat = dal.GetSessionDetails(sid);

                if (ssdat.Rows.Count > 0)
                {
                    string startdate = ssdat.Rows[0]["startdate"].ToString();
                    DateTime ms = DateTime.Parse(startdate);
                    DateTime me = DateTime.Now;// DateTime.Parse(ssdat.Rows[0]["enddate"].ToString());
                    txtsdate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", ms);
                    txtedate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", me);
                }
                else
                {
                    MessageBox.Show("لاتوجد وردية مفتوحة");
                    return;
                }

                if (sdat.Rows.Count > 0)
                {
                    dgvitemrep.DataSource = sdat;
                    if (t.CurrentCulture.Name == "ar-EG")
                    {


                        madd = "تمت الاضافة بنجاح...";
                        fadd = "خطأ..فشلت الإضافة";
                        msess = "اغلاق جلسة العمل المفتوحة";

                        dgvitemrep.Columns[0].HeaderText = "نقدا";
                        dgvitemrep.Columns[1].HeaderText = "بطاقة-بنك";
                        dgvitemrep.Columns[2].HeaderText = "آجل";
                        dgvitemrep.Columns[3].HeaderText = "الاجمالي";


                    }
                    else
                    {


                        madd = "Added successfuly";
                        fadd = "Failed To Add Category";
                        msess = "Close Opened Session";

                        dgvitemrep.Columns[0].HeaderText = "Cash";
                        dgvitemrep.Columns[1].HeaderText = "Card-Bank";
                        dgvitemrep.Columns[2].HeaderText = "Credit";
                        dgvitemrep.Columns[3].HeaderText = "Total";

                    }
                }
                else
                {
                    MessageBox.Show("لا توجد مبيعات...");
                    return;
                }

                dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }


        }

        private void cmbproduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            int sid;
            bool parseOK = Int32.TryParse(cmbproduct.SelectedValue.ToString(), out sid);
            
            txtsno.Text = sid.ToString();
            MessageBox.Show(txtsno.Text);
            DataTable sdat = sdal.GetSessionSalesSummary(sid);
            DataTable ssdat = dal.GetSessionDetails(sid);

            if (ssdat.Rows.Count > 0)
            {
                DateTime ms = DateTime.ParseExact(ssdat.Rows[0]["startdate"].ToString(), "dd/MM/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                DateTime me = DateTime.Now;// DateTime.Parse(ssdat.Rows[0]["enddate"].ToString());
                txtsdate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", ms);
                txtedate.Text = String.Format("{0:yyyy-MM-dd   hh:mm:ss}", me);
            }
            else
            {
                MessageBox.Show("لاتوجد وردية مفتوحة");
                return;
            }
            dgvitemrep.DataSource = sdat;
            if (t.CurrentCulture.Name == "ar-EG")
            {


                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                msess = "اغلاق جلسة العمل المفتوحة";

                dgvitemrep.Columns[0].HeaderText = "نقدا";
                dgvitemrep.Columns[1].HeaderText = "بطاقة-بنك";
                dgvitemrep.Columns[2].HeaderText = "آجل";
                dgvitemrep.Columns[3].HeaderText = "الاجمالي";


            }
            else
            {


                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                msess = "Close Opened Session";

                dgvitemrep.Columns[0].HeaderText = "Cash";
                dgvitemrep.Columns[1].HeaderText = "Card-Bank";
                dgvitemrep.Columns[2].HeaderText = "Credit";
                dgvitemrep.Columns[3].HeaderText = "Total";

            }
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            */

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
            ReportParameter rp5 = new ReportParameter("desc", txtsno.Text);
            //ReportParameter rp5 = new ReportParameter("stotal", txttotalsales.Text);
            //ReportParameter rp7 = new ReportParameter("desc", txtsno.Text);
            //ReportParameter rp8 = new ReportParameter("totalcash", txtcashtotal.Text);
            //ReportParameter rp9 = new ReportParameter("totalcard", txtcardtotal.Text);
            //ReportParameter rp10 = new ReportParameter("totalcredit", txtcredittotal.Text);
            //ReportParameter rp11 = new ReportParameter("gtotal", txttotalsales.Text);

            // ReportParameter rp6 = new ReportParameter();
            //rp6.Name = "logo";
            //rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\sessionSumRep.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5 });
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
            dt.Columns["cash"].ColumnName = "subtotal";
            dt.Columns["card"].ColumnName = "discount";
            dt.Columns["credit"].ColumnName = "paid";
            dt.Columns["total"].ColumnName = "grandtotal";




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
            string clogo = dtc.Rows[0]["clogo"].ToString();

            //DataTable dts = GetSalesData();


            string luser = frmlogin.loggedin;


            //*************************

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("sdate", txtsdate.Text);
            ReportParameter rp3 = new ReportParameter("edate", txtedate.Text);
            ReportParameter rp4 = new ReportParameter("luser", cmbproduct.Text);
            ReportParameter rp5 = new ReportParameter("desc", txtsno.Text);
            //ReportParameter rp5 = new ReportParameter("stotal", txttotalsales.Text);
            //ReportParameter rp7 = new ReportParameter("desc", txtsno.Text);
            //ReportParameter rp8 = new ReportParameter("totalcash", txtcashtotal.Text);
            //ReportParameter rp9 = new ReportParameter("totalcard", txtcardtotal.Text);
            //ReportParameter rp10 = new ReportParameter("totalcredit", txtcredittotal.Text);
            //ReportParameter rp11 = new ReportParameter("gtotal", txttotalsales.Text);

            // ReportParameter rp6 = new ReportParameter();
            //rp6.Name = "logo";
            //rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\sessionSumRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5 });
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
            dt.Columns["cash"].ColumnName = "subtotal";
            dt.Columns["card"].ColumnName = "discount";
            dt.Columns["credit"].ColumnName = "paid";
            dt.Columns["total"].ColumnName = "grandtotal";




            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);



        }
    }
    
}
