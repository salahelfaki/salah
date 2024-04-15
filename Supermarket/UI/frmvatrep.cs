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
using System.IO;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Configuration;

namespace Supermarket.UI
{
    
    public partial class frmvatrep : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public frmvatrep()
        {
            InitializeComponent();
        }
        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        purchaseDAL pdal = new purchaseDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmvatrep_Load(object sender, EventArgs e)
        {
            DisplaySum();

        }
        public void DisplaySum()
        {
            DateTime sdate = date11.Value.Date;
            DateTime edate = date12.Value.Date;
            DataTable dt = sdal.GetVatTotals(sdate, edate);
            DataTable dtp = pdal.GetVatTotals(sdate, edate);
            DataTable dtall = dt.Copy();
            dtall.Merge(dtp);
            
            var sumofsales = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "1").Sum(x => x.Field<decimal>("subtotal")).ToString();
            var sumofsales1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "2").Sum(x => x.Field<decimal>("subtotal")).ToString();
            var sumofsalesv = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "1").Sum(x => x.Field<decimal>("vat")).ToString();
            var sumofsalesv1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "2").Sum(x => x.Field<decimal>("vat")).ToString();
            var sumofsalest = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "1").Sum(x => x.Field<decimal>("grandtotal")).ToString();
            var sumofsalest1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "2").Sum(x => x.Field<decimal>("grandtotal")).ToString();
            
            var sumofpur = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "3").Sum(x => x.Field<decimal>("subtotal")).ToString();
            var sumofpur1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "4").Sum(x => x.Field<decimal>("subtotal")).ToString();
            var sumofpurv = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "3").Sum(x => x.Field<decimal>("vat")).ToString();
            var sumofpurv1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "4").Sum(x => x.Field<decimal>("vat")).ToString();
            var sumofpurt = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "3").Sum(x => x.Field<decimal>("grandtotal")).ToString();
            var sumofpurt1 = dtall.AsEnumerable().Where(x => x.Field<string>("trtype") == "4").Sum(x => x.Field<decimal>("grandtotal")).ToString();

            double ssub = double.Parse(sumofsales) + double.Parse(sumofsales1);
            double svat = double.Parse(sumofsalesv) + double.Parse(sumofsalesv1);
            double stot = double.Parse(sumofsalest) + double.Parse(sumofsalest1);

            double psub = double.Parse(sumofpur) + double.Parse(sumofpur1);
            double pvat = double.Parse(sumofpurv) + double.Parse(sumofpurv1);
            double ptot = double.Parse(sumofpurt) + double.Parse(sumofpurt1);
            double vatnet = svat - pvat;

            // Get Sum totals

            if (dtall.Rows.Count > 0)
            {
                for (int i = 0; i < dtall.Rows.Count; i++)
                {
                    string mtype = dtall.Rows[i]["trtype"].ToString();
                    switch (mtype)
                    {
                        case "1":
                            dtall.Rows[i][5] = "مبيعات";
                            break;
                        case "2":
                            dtall.Rows[i][5] = "مرتجع مبيعات";
                            break;
                        case "3":
                            dtall.Rows[i][5] = "مشتريات";
                            break;
                        case "4":
                            dtall.Rows[i][5] = "مرتجع مشتريات";
                            break;
                        
                        default:

                            break;

                    }

                }

            
            }
            dgvvat.DataSource = dtall;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvvat.Columns[0].HeaderText = "الرقم";
                dgvvat.Columns[1].HeaderText = "التاريخ";
                dgvvat.Columns[2].HeaderText = "القيمة";
                dgvvat.Columns[3].HeaderText = "ضريبة القيمة المضافة";
                dgvvat.Columns[4].HeaderText = "الاجمالي";
                dgvvat.Columns[5].HeaderText = "العملية";
            }
            else
            {
                dgvvat.Columns[0].HeaderText = "No";
                dgvvat.Columns[1].HeaderText = "Date";
                dgvvat.Columns[2].HeaderText = "Amount";
                dgvvat.Columns[3].HeaderText = "VAT";
                dgvvat.Columns[4].HeaderText = "Total";
                dgvvat.Columns[5].HeaderText = "Type";
            }

            dgvvat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            txtssubtotal.Text = ssub.ToString("#,0.00");
            txtsvat.Text = svat.ToString("#,0.00");
            txtsgrandtotal.Text = stot.ToString("#,0.00");

            txtpsubtotal.Text = psub.ToString("#,0.00");
            txtpvat.Text = pvat.ToString("#,0.00");
            txtpgrandtotal.Text = ptot.ToString("#,0.00");

            txtnetvat.Text = vatnet.ToString("#,0.00");

        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            

        }

        
            
    

        
        private void btnprnt_Click(object sender, EventArgs e)
        {
            
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {
            
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void btnprnt_Click_1(object sender, EventArgs e)
        {
            

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            //*************************
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


            ReportParameter rp1 = new ReportParameter("invdate", invdate);
            ReportParameter rp2 = new ReportParameter("sdate", date11.Value.ToString());
            ReportParameter rp3 = new ReportParameter("edate", date12.Value.ToString());
            ReportParameter rp4 = new ReportParameter("ssubtotal", txtssubtotal.Text);
            ReportParameter rp5 = new ReportParameter("svat", txtsvat.Text);
            ReportParameter rp6 = new ReportParameter("snet", txtsgrandtotal.Text);
            ReportParameter rp7 = new ReportParameter("psubtotal", txtpsubtotal.Text);
            ReportParameter rp8 = new ReportParameter("pvat", txtpvat.Text);
            ReportParameter rp9 = new ReportParameter("pnet", txtpgrandtotal.Text);
            ReportParameter rp10 = new ReportParameter("pgtotal", txtpvat.Text);
            ReportParameter rp11 = new ReportParameter();
            rp11.Name = "logo";
            rp11.Values.Add(@"file:///" + clogo);
            ReportParameter rp12 = new ReportParameter("arabicname", arname);


            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\vatA4.rdlc";
            report.ReportPath = fullpath;

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11,rp12 });
            //this.report.RefreshReport();
            DataTable dt2 = new DataTable();//prdal.itemTrans(sdate,edate,product);
            foreach (DataGridViewColumn col in dgvvat.Columns)
            {
                dt2.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in dgvvat.Rows)
            {
                DataRow dRow = dt2.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt2.Rows.Add(dRow);
            }

            dt2.Columns["trtype"].ColumnName = "type";

            report.DataSources.Add(new ReportDataSource("DataSet1", dt2));
           

            PrintToPrinter(report);
           

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


        private void btnprntA4_Click(object sender, EventArgs e)
        {
            /*

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            string subtotal = txtsubtotal.Text;
            string pvat = txtvat.Text;

            string sdate = date11.Text;
            string edate = date12.Text;






            //*************************



            ReportParameter rp1 = new ReportParameter("invdate", invdate);
            ReportParameter rp2 = new ReportParameter("sdate", sdate);
            ReportParameter rp3 = new ReportParameter("edate", edate);
            ReportParameter rp4 = new ReportParameter("subtotal", txtsubtotal.Text);
            ReportParameter rp5 = new ReportParameter("svat", txtvat.Text);
            ReportParameter rp6 = new ReportParameter("salestotal", txtsalestotal.Text);
            ReportParameter rp7 = new ReportParameter("svattotal", txtsalesvattotal.Text);
            ReportParameter rp8 = new ReportParameter("purchase", txtpurchase.Text);
            ReportParameter rp9 = new ReportParameter("purchasetotal", txtptotal.Text);
            ReportParameter rp10 = new ReportParameter("pvat", txtpvat.Text);
            ReportParameter rp11 = new ReportParameter("pvattotal", txtpvattotal.Text);
            ReportParameter rp12 = new ReportParameter("netvat", txtnetvat.Text);



            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\vatRepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12 });
            //this.report.RefreshReport();
            DataTable dt = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                           //*************



            report.DataSources.Add(new ReportDataSource("DataSet1", dt));


            PrintToPrinter(report);

            */

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

    

    private void btnshow_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void sdate_ValueChanged(object sender, EventArgs e)
        {
            string sdate = date11.Value.ToString("yyyy-MM-dd");
            string edate = date12.Value.ToString("yyyy-MM-dd");

            DisplaySum();
        }

        private void date12_ValueChanged(object sender, EventArgs e)
        {
            string sdate = date11.Value.ToString("yyyy-MM-dd");
            string edate = date12.Value.ToString("yyyy-MM-dd");

            DisplaySum();
        }
    }
}
