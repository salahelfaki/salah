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
    public partial class frmStockrep : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmStockrep()
        {
            InitializeComponent();
        }
        salesDAL sdal = new salesDAL();
        productsDAL pdal = new productsDAL();
        categoriesDAL cdal = new categoriesDAL();
        printDAL prdal = new printDAL();

        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        public int choice=1;
        DataTable dt = new DataTable();

        private void frmStockrep_Load(object sender, EventArgs e)
        {
            
            //Combo box
            string sql3 = "Select id,title from tbl_categories ";


            SqlConnection conn2 = new SqlConnection(myconnstrng);


            SqlCommand cmd3 = new SqlCommand(sql3, conn2);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "category");


            cmbcateg.DisplayMember = "title";
            cmbcateg.ValueMember = "id";
            cmbcateg.DataSource = ds3.Tables["category"];
            //string mcat = cmbcateg.Text;


            txtcatid.Text = cmbcateg.SelectedValue.ToString();

            conn2.Close();
            

            DisplayStock();


        }

        private void DisplayStock()
        {
            
            if (choice == 0) {
                dt = pdal.DisplayAllStock();
                
            }
            else
            {
                dt= pdal.DisplayProductsByCategory(txtcatid.Text);
            }
            dgvstock.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvstock.Columns[0].HeaderText = "الرقم";
                dgvstock.Columns[1].HeaderText = "الباركود";
                dgvstock.Columns[2].HeaderText = "الصنف";
                dgvstock.Columns[3].HeaderText = "الكمية";
                dgvstock.Columns[4].HeaderText = "التكلفة";
                dgvstock.Columns[5].HeaderText = "السعر";
                dgvstock.Columns[6].HeaderText = "الاجمالي";
            }
            else
            {

                dgvstock.Columns[0].HeaderText = "ID";
                dgvstock.Columns[1].HeaderText = "BarCode";
                dgvstock.Columns[2].HeaderText = "Product";
                dgvstock.Columns[3].HeaderText = "Qty";
                dgvstock.Columns[4].HeaderText = "Cost";
                dgvstock.Columns[5].HeaderText = "Price";
                dgvstock.Columns[6].HeaderText = "Total";
            }

            dgvstock.Columns[0].Width = 100;
            dgvstock.Columns[1].Width = 120;
            dgvstock.Columns[2].Width = 280;

            dgvstock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            double a = 0;
            double b = 0;
            double c = 0;
            foreach (DataGridViewRow r in dgvstock.Rows)
            {

                a += Convert.ToDouble(r.Cells[3].Value);
                b += Convert.ToDouble(r.Cells[6].Value);
                //c += Convert.ToDouble(r.Cells[4].Value);

            }

            //Totals

            txttotal.Text = b.ToString("#,0.00");
            DataTable dtt = pdal.GetAllStockTotals();
            txtsales.Text = dtt.Rows[0]["Total"].ToString();
        }
        

        private void btnshowall_Click(object sender, EventArgs e)
        {
            DataTable dt = pdal.DisplayAllStock();
            dgvstock.DataSource = dt;
            DataTable dtt = pdal.GetAllStockTotals();
            txttotal.Text = dtt.Rows[0]["Total"].ToString();

        }

        
        private void btnprnt_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string product = "";
            if (choice == 0)
            {
                product = radall.Text;
            }
            else
            {
                product = cmbcateg.Text;
            }

            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString();


            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("pval", txtsales.Text);
            ReportParameter rp4 = new ReportParameter("product", product);
            ReportParameter rp5 = new ReportParameter("pgtotal", txttotal.Text);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\stockRepsmall.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvstock.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvstock.Rows)
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
            dt.Columns["total"].ColumnName = "subtotal";
            dt.Columns["qty"].ColumnName = "paid";
            dt.Columns["costprice"].ColumnName = "vat";
            dt.Columns["rate"].ColumnName = "discount";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            PrintToPrinter1(report);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string product = "";
            if (choice == 0)
            {
                product = radall.Text;
            }
            else
            {
                product = cmbcateg.Text;
            }

            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString();
            

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("invdate", invdate);
            ReportParameter rp3 = new ReportParameter("pval", txtsales.Text);
            ReportParameter rp4 = new ReportParameter("product", product);
            ReportParameter rp5 = new ReportParameter("pgtotal", txttotal.Text);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\stockRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************

            foreach (DataGridViewColumn col in dgvstock.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvstock.Rows)
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
            dt.Columns["total"].ColumnName = "subtotal";
            dt.Columns["qty"].ColumnName = "paid";
            dt.Columns["costprice"].ColumnName = "vat";
            dt.Columns["rate"].ColumnName = "discount";
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



        private void radall_CheckedChanged(object sender, EventArgs e)
        {
            if (radall.Checked)
            {
                choice = 0;
                DisplayStock();
            }
        }

        private void radcateg_CheckedChanged(object sender, EventArgs e)
        {
            if (radcateg.Checked)
            {
                choice = 1;
                DisplayStock();
            }
        }

        private void cmbcateg_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtcatid.Text = cmbcateg.SelectedValue.ToString();
            DisplayStock();
        }
    }

    
}

