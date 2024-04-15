using Microsoft.Reporting.WinForms;
using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
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
    public partial class frmpayment : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmpayment()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;

        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";
        public string mmseg = "الصنف غير موجود...اضافة";
        public string mconf = "تأكيد";
        public string msave = "تم الحفظ";

        acctsDAL dcdal = new acctsDAL();
        companyDAL cmpdal = new companyDAL();

        accttrDAL acdal = new accttrDAL();
        printDAL prdal = new printDAL();

        public int myval;
        public string paytype;
        public int custid;

        private void frmpayment_Load(object sender, EventArgs e)
        {
            DataTable dt = acdal.SelectPayments();
            dgvpayment.DataSource = dt;
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvpayment.Columns[0].HeaderText = "الرقم";
                dgvpayment.Columns[1].HeaderText = "التاريخ";
                dgvpayment.Columns[2].HeaderText = "الحساب";
                dgvpayment.Columns[3].HeaderText = "مدين";
                dgvpayment.Columns[4].HeaderText = "دائن";
                dgvpayment.Columns[5].HeaderText = "البيان";
                dgvpayment.Columns[6].HeaderText = "الدفع";
                dgvpayment.Columns[7].HeaderText = "رقم الحساب";
                madd = "";
                fadd = "";
                mupdate = "";
                fupdate = "";
                mdelete = "";
                fdelete = "";
                mmseg = "الصنف غير موجود...اضافة";
                mconf = "تأكيد";
                msave = "تم الحفظ بنجاح!";
            }
            else
            {
                dgvpayment.Columns[0].HeaderText = "No";
                dgvpayment.Columns[1].HeaderText = "Date";
                dgvpayment.Columns[2].HeaderText = "Customer";
                dgvpayment.Columns[3].HeaderText = "Debit";
                dgvpayment.Columns[4].HeaderText = "Credit";
                dgvpayment.Columns[5].HeaderText = "Description";
                dgvpayment.Columns[6].HeaderText = "Paymethod";
                dgvpayment.Columns[7].HeaderText = "User";
                madd = "";
                fadd = "";
                mupdate = "";
                fupdate = "";
                mdelete = "";
                fdelete = "";
                mmseg = "Product Not Exist...Add?";
                mconf = "Confirm";
                msave = "Saved Succesfully...";

            }
            dgvpayment.Columns[0].Width = 80;
            dgvpayment.Columns[2].Width = 200;
            dgvpayment.Columns[4].Width = 300;
            dgvpayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            txtuser.Text = frmlogin.loggedin;
            string sql2 = "Select acctcode,acctname from tbl_accts";
            SqlConnection conn2 = new SqlConnection(myconnstrng);
            SqlCommand cmd = new SqlCommand(sql2, conn2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, "customers");

            

            cmbcustomers.DisplayMember = "acctname";

            cmbcustomers.ValueMember = "acctcode";
            cmbcustomers.DataSource = ds.Tables["customers"];
            //cmbcustomers.SelectedIndex = 1;

            conn2.Close();
            conn2.Open();
            string sql3 = "Select mid,paymethod from tbl_paymethod";
            
            SqlCommand cmd3 = new SqlCommand(sql3, conn2);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd3);
            DataSet ds1 = new DataSet();

            da1.Fill(ds1, "pay");

            

            cmbpayment.DisplayMember = "paymethod";

            cmbpayment.ValueMember = "mid";
            cmbpayment.DataSource = ds1.Tables["pay"];



            conn2.Close();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            
            con.Open();
            string sqli = "Select max(trno) from tbl_accttr where trtype='5'";
            SqlCommand cmdi = new SqlCommand(sqli, con);
            var mytr = cmdi.ExecuteScalar();
             string tr= mytr.ToString();
            string myacct = "";
            string myacctname = "";
            if (tr == "")
            {
                trno.Text = "500001";
            }
            else
            {
                trno.Text = (int.Parse(tr) + 1).ToString();
            }
            
            if (cmbpayment.SelectedValue.ToString() == "1")
            {
                myacct = "11001";
                myacctname = "الصندوق";
            }
            else if (cmbpayment.SelectedValue.ToString() == "2")
            {
                myacct = "11002";
                myacctname = "بطاقة - بنك";
            }

            //Credit
            string sql3 = "INSERT INTO tbl_accttr (trdate,trtype,payacct,acctname,description,dbval,crval,paymethod,trno,added_by) VALUES(@trdate,@trtype,@payacct,@acctname,@description,@dbval,@crval,@paymethod,@trno,@added_by)";
            SqlCommand cmd3 = new SqlCommand(sql3, con);
            cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
            cmd3.Parameters.AddWithValue("@trtype", "5");
            cmd3.Parameters.AddWithValue("@paymethod", cmbpayment.SelectedValue.ToString());
            cmd3.Parameters.AddWithValue("@acctname", cmbcustomers.Text);
            cmd3.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd3.Parameters.AddWithValue("@dbval", "0");
            cmd3.Parameters.AddWithValue("@crval", Convert.ToDecimal(txtamount.Text));
            cmd3.Parameters.AddWithValue("@payacct", custid);
            cmd3.Parameters.AddWithValue("@trno", trno.Text);
            cmd3.Parameters.AddWithValue("@added_by", txtuser.Text);

            cmd3.ExecuteNonQuery();
            //DEbit
            string sql4 = "INSERT INTO tbl_accttr (trdate,trtype,payacct,acctname,description,dbval,crval,paymethod,trno,added_by) VALUES(@trdate,@trtype,@payacct,@acctname,@description,@dbval,@crval,@paymethod,@trno,@added_by)";
            SqlCommand cmd4 = new SqlCommand(sql4, con);
            cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
            cmd4.Parameters.AddWithValue("@trtype", "5");
            cmd4.Parameters.AddWithValue("@paymethod", cmbpayment.SelectedValue.ToString());
            cmd4.Parameters.AddWithValue("@acctname", myacctname);
            cmd4.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd4.Parameters.AddWithValue("@dbval", Convert.ToDecimal(txtamount.Text));
            cmd4.Parameters.AddWithValue("@crval", "0");
            cmd4.Parameters.AddWithValue("@payacct", myacct);
            cmd4.Parameters.AddWithValue("@trno", trno.Text);
            cmd4.Parameters.AddWithValue("@added_by", txtuser.Text);

            cmd3.ExecuteNonQuery();
            con.Close();

            
            MessageBox.Show(msave);
           // ClearSpace(this);
            DataTable dt = acdal.SelectPayments();
            dgvpayment.DataSource = dt;

        }

        private void cmbcustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = cmbcustomers.SelectedValue.ToString();
            txtacctcode.Text = keywords;
            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }
           
            acctsBLL dc = dcdal.GetAcctInfo(keywords);
            
            //cmbcustomers.Text = dc.acctname;
            txtvatno.Text = dc.vatno;
            txtcaddress.Text = dc.caddress;
            //custid = dc.acctid;
           
            DataTable dta = new DataTable();
            dta = acdal.GetAcctBalance(keywords);
           
            if (dta.Rows.Count > 0)
            {
                if (dta.Rows[0]["balance"].ToString() != "")
                {
                    double bal = double.Parse(dta.Rows[0]["balance"].ToString());
                    txtbalance.Text = bal.ToString("#,0.00");
                }
            }
            else
            {
                txtbalance.Text = "0.00";
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate =dtpbilldate.Text;

            if (clogo != "")
            {
                if (File.Exists(clogo))
                {
                    System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                    img2 = resizeImage(img2, new Size(100, 100));
                }

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
            ReportParameter rp3 = new ReportParameter("trno", trno.Text);
            ReportParameter rp4 = new ReportParameter("balance", txtamount.Text);
            ReportParameter rp5 = new ReportParameter("payment", cmbpayment.Text);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            ReportParameter rp7 = new ReportParameter("descr", txtdescription.Text);
            ReportParameter rp8 = new ReportParameter("acctname", cmbcustomers.Text);
            ReportParameter rp9 = new ReportParameter("repuser", txtuser.Text);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DBnoteRep.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8,rp9 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************



            //change columns names
            // dt.Columns["acctname"].ColumnName = "description";
            //dt.Columns["balance"].ColumnName = "subtotal";
            //dt.Columns["debit"].ColumnName = "vat";
            //dt.Columns["credit"].ColumnName = "grandtotal";
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

        private void btnjrn_Click(object sender, EventArgs e)
        {
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = dtpbilldate.Value.ToString("dd-MM-yyyy");

            if (clogo != "")
            {
                if (File.Exists(clogo))
                {
                    System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                    img2 = resizeImage(img2, new Size(100, 100));
                }

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
            ReportParameter rp3 = new ReportParameter("trno", trno.Text);
            ReportParameter rp4 = new ReportParameter("balance", txtamount.Text);
            ReportParameter rp5 = new ReportParameter("payment", cmbpayment.Text);
            ReportParameter rp6 = new ReportParameter();
            rp6.Name = "logo";
            rp6.Values.Add(@"file:///" + clogo);
            ReportParameter rp7 = new ReportParameter("descr", txtdescription.Text);
            ReportParameter rp8 = new ReportParameter("acctname", cmbcustomers.Text);
            ReportParameter rp9 = new ReportParameter("repuser", txtuser.Text);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\DBnoteJournal.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8,rp9 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************



            //change columns names
            // dt.Columns["acctname"].ColumnName = "description";
            //dt.Columns["balance"].ColumnName = "subtotal";
            //dt.Columns["debit"].ColumnName = "vat";
            //dt.Columns["credit"].ColumnName = "grandtotal";
            //*******

            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);

        }

        private void dgvpayment_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnsave.Enabled = false;
            int rowindex = e.RowIndex;
            trno.Text = dgvpayment.Rows[rowindex].Cells[0].Value.ToString();
            dtpbilldate.Text = dgvpayment.Rows[rowindex].Cells[1].Value.ToString();
            cmbcustomers.Text = dgvpayment.Rows[rowindex].Cells[2].Value.ToString();
            txtamount.Text = dgvpayment.Rows[rowindex].Cells[3].Value.ToString();
            txtdescription.Text = dgvpayment.Rows[rowindex].Cells[4].Value.ToString();
            cmbpayment.Text = dgvpayment.Rows[rowindex].Cells[5].Value.ToString();
            txtuser.Text= dgvpayment.Rows[rowindex].Cells[6].Value.ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = acdal.SearchDebitNote(keywords);
                dgvpayment.DataSource = dt;

            }
            else
            {
                DataTable dt = acdal.SelectPayments();
                dgvpayment.DataSource = dt;
            }
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            ClearSpace(this);
            btnsave.Enabled = true;
            DataTable dt = acdal.SelectPayments();
            dgvpayment.DataSource = dt;
        }

        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;

                if (textBox != null)
                    (textBox).Clear();

                if (comboBox != null)
                    comboBox.SelectedIndex = -1;

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }
        
    }
}
