using Microsoft.Reporting.WinForms;
using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
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
    public partial class frmbillview : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmbillview(string invid)
        {
            InitializeComponent();
            cmbbillno.Text = invid;
           

        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
        
        purchaseDAL purdal = new purchaseDAL();
        public string notmess = "";
        public string confmess = "";
        public string msave = "";
        private void frmpurchase_Load(object sender, EventArgs e)
        {
            string keywords = cmbbillno.Text;
            
            if (keywords == "")
            {

                //  txtname.Text = "";
                //txtvatno.Text = "";

                return;


            }
            
            DataTable dts = purdal.GetInvoicePurchase(keywords);
           
            if (dts.Rows.Count > 0)
            {
                string mdate = dts.Rows[0]["trdate"].ToString();
                txtbilldate.Text = mdate.ToString();
                txtinvno.Text = dts.Rows[0]["invno"].ToString();
                txtdescription.Text = dts.Rows[0]["description"].ToString();
                txtstore.Text = dts.Rows[0]["branch"].ToString();
                txtbranch.Text = dts.Rows[0]["store"].ToString();
                txtsubtotal.Text = dts.Rows[0]["subtotal"].ToString();
                txtvat.Text = dts.Rows[0]["vat"].ToString();
                txtdiscount.Text = dts.Rows[0]["discount"].ToString();
                txtgrandtotal.Text = dts.Rows[0]["gtotal"].ToString();
                // cmbpayment.Text = dts.Rows[0]["paymethod"].ToString();
                //txtpaid.Text = dts.Rows[0]["paid"].ToString();
                //txtreturn.Text = dts.Rows[0]["return"].ToString();
                txtuser.Text = dts.Rows[0]["added_by"].ToString();
                cmbtype.Text = dts.Rows[0]["paymethod"].ToString();
                txtname.Text = dts.Rows[0]["dealer"].ToString();
                txtnetval.Text = (double.Parse(dts.Rows[0]["subtotal"].ToString()) - double.Parse(dts.Rows[0]["discount"].ToString())).ToString();
                acctsBLL cdal = dcdal.searchdealercustomerfortransaction(txtname.Text);
                txtvatno.Text = cdal.vatno;


            }
            else
            {
                MessageBox.Show("No Invoice");

            }



            DataTable sdat = purdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = sdat;


            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvaddproduct.Columns[0].HeaderText = "الرقم";
                dgvaddproduct.Columns[1].HeaderText = "الاسم";
                dgvaddproduct.Columns[2].HeaderText = "الكمية";
                dgvaddproduct.Columns[3].HeaderText = "السعر";
                dgvaddproduct.Columns[4].HeaderText = "الاجمالي";
                msave = "تم الحفظ";
                

            }
            else
            {
                dgvaddproduct.Columns[0].HeaderText = "Barcode";
                dgvaddproduct.Columns[1].HeaderText = "Name";
                dgvaddproduct.Columns[2].HeaderText = "Qty";
                dgvaddproduct.Columns[3].HeaderText = "Price";
                dgvaddproduct.Columns[4].HeaderText = "Total";
                msave = "Save Successfull..";
                

            }
            decimal rate = 0;// decimal.Parse(txtrate.Text);
            decimal qty = 0;// decimal.Parse(txtqty.Text);
            decimal total = rate * qty;

            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;


            // transactiondt.Rows.Add(product_id, productname, rate, qty, total);
            //dgvaddproduct.DataSource = transactiondt;
            dgvaddproduct.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvaddproduct.EnableHeadersVisualStyles = false;
            dgvaddproduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvaddproduct.RowHeadersWidth = 55;
            dgvaddproduct.RowTemplate.MinimumHeight = 25;
           
            

             

            dgvaddproduct.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvaddproduct.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            // dgvaddproduct.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvaddproduct.Columns[1].Width = 350;
            dgvaddproduct.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvaddproduct.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            

            txtsubtotal.Text = subtotal.ToString();

            





        }
        
        
        

        
        

        


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void frmClear()
        {
            this.Close();
            frmpurchase main = new frmpurchase();
            main.Show();
        }

        

        private void prntpreview_Load(object sender, EventArgs e)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            prntpreview.Document = prntdoc;
            prntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 285, 600);
            prntdoc.PrinterSettings.PrinterName = defaultPrinterName;
            //prntdoc.Print();
          //  frmClear();

            prntpreview.ShowDialog();
            */
            DataTable dtc = GetCompanyData();
            string compname = dtc.Rows[0]["cname"].ToString();
            string caddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;

            DataTable dts = GetpurchaseData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["dealer"].ToString();
            string gtotal = dts.Rows[0]["gtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();


            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = Convert.ToDateTime(trdate, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal -mdiscount;
            string gnetval = mnetval.ToString();




            DataTable dtcust = GetCustomer(mcust);
            string custname = dtcust.Rows[0]["name"].ToString();
            string custadd = dtcust.Rows[0]["address"].ToString();
            string custvat = dtcust.Rows[0]["vatno"].ToString();


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


            if (custname == "")
            {
                custname = "  ";
            }
            if (custadd == "")
            {
                custadd = "  ";
            }
            if (custvat == "")
            {
                custvat = "   ";

            }
            if (mdescription == "")
            {
                mdescription = "   ";
            }
            if (adduser == "")
            {
                adduser = " ";
            }

            ReportParameter rp1 = new ReportParameter("customer", custname);
            ReportParameter rp2 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp3 = new ReportParameter("description", mdescription);
            ReportParameter rp4 = new ReportParameter("invdate", trdate);
            ReportParameter rp5 = new ReportParameter("invno", invno);
            ReportParameter rp6 = new ReportParameter("payment", payment);
            ReportParameter rp7 = new ReportParameter("seller", adduser);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);

            ReportParameter rp9 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp10 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp11 = new ReportParameter("pnet", gnetval);
            ReportParameter rp12 = new ReportParameter("pvat", gvat);
            ReportParameter rp13 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp14 = new ReportParameter("arabicname", arname);
            ReportParameter rp15 = new ReportParameter("sinvno", txtinvno.Text);

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\purchaseRepsmall.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllpurchase();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);

            frmClear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            prntpreview.Document = prntdocA4;
            prntdocA4.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 800, 1200);
            prntdocA4.PrinterSettings.PrinterName = defaultPrinterName;
            //prntdoc.Print();
            //  frmClear();

            prntpreview.ShowDialog();
            */

            DataTable dtc = GetCompanyData();
            string compname = dtc.Rows[0]["cname"].ToString();
            string caddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;

            DataTable dts = GetpurchaseData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["dealer"].ToString();
            string gtotal = dts.Rows[0]["gtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();


            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = Convert.ToDateTime(trdate, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal -mdiscount;
            string gnetval = mnetval.ToString();




            DataTable dtcust = GetCustomer(mcust);
            string custname = dtcust.Rows[0]["name"].ToString();
            string custadd = dtcust.Rows[0]["address"].ToString();
            string custvat = dtcust.Rows[0]["vatno"].ToString();

            
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
            

            if (custname == "")
            {
                custname = "  ";
            }
            if (custadd == "")
            {
                custadd = "  ";
            }
            if (custvat == "")
            {
                custvat = "   ";

            }
            if (mdescription == "")
            {
                mdescription = "   ";
            }
            if (adduser == "")
            {
                adduser = " ";
            }

            ReportParameter rp1 = new ReportParameter("customer", custname);
            ReportParameter rp2 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp3 = new ReportParameter("description", mdescription);
            ReportParameter rp4 = new ReportParameter("invdate", trdate);
            ReportParameter rp5 = new ReportParameter("invno", invno);
            ReportParameter rp6 = new ReportParameter("payment", payment);
            ReportParameter rp7 = new ReportParameter("seller", adduser);
            ReportParameter rp8 = new ReportParameter();
            rp8.Name = "logo";
            rp8.Values.Add(@"file:///" + clogo);

            ReportParameter rp9 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp10 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp11 = new ReportParameter("pnet", gnetval);
            ReportParameter rp12 = new ReportParameter("pvat", gvat);
            ReportParameter rp13 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp14 = new ReportParameter("arabicname", arname);
            ReportParameter rp15 = new ReportParameter("sinvno", txtinvno.Text);
            ReportParameter rp16 = new ReportParameter("reptitle", " مشتريات");

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath)+ @"\purchaseRepA4.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14,rp15,rp16 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllpurchase();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            
            PrintToPrinter(report);
            
            



        }
        public DataTable GetpurchaseData()
        {
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tbl_purchase where id='" + cmbbillno.Text + "'";

                myconn.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(mysql, myconn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(mysql, myconn);

                da.Fill(dts);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dts;
        }

        public DataTable GetPurchaseDetails()
        {
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select itemname as name,sum(itemqty) as qty ,itemprice as rate,itemprice*sum(qty) as total from tbl_purchaseitems where trid='" + cmbbillno.Text + "' GROUP BY itemname";

                myconn.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(mysql, myconn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(mysql, myconn);

                da.Fill(dts);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dts;
        }



        

        
        public static void PrintToPrinter1(LocalReport report)
        {
            Export1(report);
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
        // *********************************************** for A4 ******************
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);
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
        public DataTable DisplayAllpurchase()
        {
            SQLiteConnection conn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.itemname As name,sum(itemqty) as qty,itemprice as rate, sum(b.itemtotal) as total from tbl_purchase a,tbl_purchaseitems b where b.trid=a.id and a.id='" + cmbbillno.Text + "' group by b.itemname";
                SQLiteCommand cmd = new SQLiteCommand(sql, conn);
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        public DataTable GetCompanyData()
        {
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dtc = new DataTable();
            try
            {

                string mysql = "select cname,aname,caddress,cvatno,clogo from company where id=1";

                myconn.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(mysql, myconn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(mysql, myconn);

                da.Fill(dtc);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dtc;
        }


        public DataTable GetCustomer(string custname)
        {
            SQLiteConnection myconn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dtcust = new DataTable();
            //MessageBox.Show(custname);
            try
            {

                string mysql = "select * from tbl_accts where name='" + custname + "'";

                myconn.Open();
                SQLiteCommand cmd3 = new SQLiteCommand(mysql, myconn);
                SQLiteDataAdapter da = new SQLiteDataAdapter(mysql, myconn);

                da.Fill(dtcust);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dtcust;
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtdiscount_Validated(object sender, EventArgs e)
        {
            double oldgtotal = double.Parse(txtnetval.Text);
            double mdiscount= double.Parse(txtdiscount.Text);
            double newgrantotal = oldgtotal - mdiscount;
            txtgrandtotal.Text = newgrantotal.ToString("0.00");
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            frmpurchaseview frm = new frmpurchaseview();
            frm.Show();
        }

        private void dtpbilldate_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
