using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Supermarket.DAL;
using Supermarket.BLL;
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Configuration;
using System.Data.SqlClient;

namespace Supermarket.UI
{
    public partial class frmcategsalerep : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        bool Iscateg = false;
        bool Isprod = false;
        public frmcategsalerep()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        salesDAL sdal = new salesDAL();
        productsDAL pdal = new productsDAL();
        printDAL prdal = new printDAL();

        private void frmitemsalerep_Load(object sender, EventArgs e)
        {
            
            
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            
           

            // combo box list
            
            string sql3 = "Select id,title from tbl_categories ";


            SqlConnection conn2 = new SqlConnection(myconnstrng);

            
            SqlCommand cmd3 = new SqlCommand(sql3, conn2);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3,"category");
            
            
            cmbcateg.DisplayMember = "title";
            cmbcateg.ValueMember = "id";
            cmbcateg.DataSource = ds3.Tables["category"];
            //string mcat = cmbcateg.Text;
            
                txtcateg.Text = cmbcateg.SelectedValue.ToString();
            

            conn2.Close();

            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

       private void categDisplayTrans()
        {

            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;

            string mycateg = txtcateg.Text;
            
            DataTable dti = new DataTable();
            DataTable dtsum = new DataTable();
            DataTable dtgroup = new DataTable();

            dti = sdal.DisplayCategtrans(sdate, edate, mycateg);

            dgvitemrep.DataSource = dti;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvitemrep.Columns[0].HeaderText = "الباركود";
                dgvitemrep.Columns[1].HeaderText = "الصنف";
                dgvitemrep.Columns[2].HeaderText = "الاجمالي";
                dgvitemrep.Columns[3].HeaderText = "القسم";
            }
            else
            {
                dgvitemrep.Columns[0].HeaderText = "Barcode";
                dgvitemrep.Columns[1].HeaderText = "Description";
                dgvitemrep.Columns[2].HeaderText = "Total";
                dgvitemrep.Columns[3].HeaderText = "Category";
            }

            dgvitemrep.Columns[2].DefaultCellStyle.Format = "N2";
           
            dgvitemrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            double a = 0;
            foreach (DataGridViewRow r in dgvitemrep.Rows)
            {

                a += Convert.ToDouble(r.Cells[2].Value);
                
            }
            txtsubtotal.Text = a.ToString("#,0.00");
            

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

            categDisplayTrans();


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            categDisplayTrans();
        }

        

        private void btnprnt_Click(object sender, EventArgs e)
        {
            

        }

        private void printPreview_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString();
            string sdate = date1.Value.ToString("dd-MM-yyyy HH:mm:ss");
            string edate = date2.Value.ToString("dd-MM-yyyy HH:mm:ss");

            string pgtotal = txtsubtotal.Text;

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("categname", cmbcateg.Text);
            ReportParameter rp6 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp8 = new ReportParameter("categcode", txtcateg.Text);
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\categsalessmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7,rp8 });
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
            dt.Columns["pname"].ColumnName = "description";
            dt.Columns["barcode"].ColumnName = "customer";
            dt.Columns["total"].ColumnName = "grandtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);

        }



        private void btnprntA4_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString();
            string sdate = date1.Value.ToString("dd-MM-yyyy HH:mm:ss");
            string edate = date2.Value.ToString("dd-MM-yyyy HH:mm:ss");

            string pgtotal = txtsubtotal.Text;

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter("categname", cmbcateg.Text);
            ReportParameter rp6 = new ReportParameter("pgtotal", pgtotal);
            ReportParameter rp8 = new ReportParameter("categcode", txtcateg.Text);
            ReportParameter rp7 = new ReportParameter();
            rp7.Name = "logo";
            rp7.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\categsalesA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8 });
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
            dt.Columns["pname"].ColumnName = "description";
            dt.Columns["barcode"].ColumnName = "customer";
            dt.Columns["total"].ColumnName = "grandtotal";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        

        private void cmbcateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcateg.Text = cmbcateg.SelectedValue.ToString();

            categDisplayTrans();
        }
    }
}
