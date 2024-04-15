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
    public partial class frmbalancesheet : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmbalancesheet()
        {
            InitializeComponent();
        }
        salesDAL sdal = new salesDAL();
        productsDAL pdal = new productsDAL();
        printDAL prdal = new printDAL();
        accttrDAL acdal = new accttrDAL();
        purchaseDAL purdal = new purchaseDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

        public decimal dbsales, crsales, balsales = 0;
        public decimal dbpurchase, crpurchase, balpurchase = 0;
        public decimal dbexpense, crexpense, balexpense = 0;
        public decimal dbvat, crvat, balvat = 0;
        public decimal dbcash, crcash, balcash = 0;
        public decimal dbcard, crcard, balcard = 0;
        public decimal dbcustomers, crcustomers, balcustomers = 0;
        public decimal dbsuppliers, crsuppliers, balsuppliers = 0;
        public decimal stockval, stockqty, stockbal = 0;

        private void frmsalesrep_Load(object sender, EventArgs e)
        {
            
            DisplayTotals();
            DataTable dt = createDatatable();
            dgvbalance.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvbalance.Columns[0].HeaderText = "البيــان";
                dgvbalance.Columns[1].HeaderText = "مديـن";
                dgvbalance.Columns[2].HeaderText = "دائـن";
                dgvbalance.Columns[3].HeaderText = "الرصيـد";
                
            }
            else
            {
                dgvbalance.Columns[0].HeaderText = "Description";
                dgvbalance.Columns[1].HeaderText = "DR";
                dgvbalance.Columns[2].HeaderText = "CR";
                dgvbalance.Columns[3].HeaderText = "Balance";
                
            }
            dgvbalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            
        }
        public void DisplayTotals()
        {
            DateTime sdate = date1.Value.Date;
            DateTime edate = date2.Value.Date;
            DataTable dtp = purdal.GetTotalPurchase(sdate, edate);
            DataTable dts = sdal.GetSalesTotals(date1.Value.Date, date2.Value.Date);

            DataTable dtcash = acdal.BalanceTotal(sdate, edate, "11001");
            DataTable dtbank = acdal.BalanceTotal(sdate, edate, "11002");
            DataTable dtvat = acdal.BalanceTotal(sdate, edate, "15001");

            DataTable dtex = acdal.AcctBalanceTotal(sdate, edate, "4");
            DataTable dtdb = acdal.AcctBalanceTotal(sdate, edate, "2");
            DataTable dtcr = acdal.AcctBalanceTotal(sdate, edate, "3");
            DataTable dtcost = sdal.GetProductCost(sdate, edate);
            stockval = pdal.GetStockValue();
            stockqty = pdal.GetStockQtyAvailable();
            stockbal = pdal.GetStockAll();


            




            if (dts.Rows.Count > 0)
            {

                if (string.IsNullOrEmpty(dts.Rows[0]["total"].ToString()))
                {
                    balsales = 0;
                }


                else
                {
                    balsales = decimal.Parse(dts.Rows[0]["total"].ToString());
                   
                }


            }

            if (dtp.Rows.Count > 0)
            {

                if (string.IsNullOrEmpty(dtp.Rows[0]["total"].ToString()))
                {
                    balpurchase=0;
                }


                else
                {
                    balpurchase = decimal.Parse(dtp.Rows[0]["total"].ToString());
                    
                }
               

                if (dtex.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtex.Rows[0]["total"].ToString()))
                    {
                        balexpense=0;
                    }


                    else
                    {
                        balexpense = decimal.Parse(dtex.Rows[0]["total"].ToString());
                        
                    }
                }
                

                if (dtvat.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtvat.Rows[0]["total"].ToString()))
                    {
                        balvat=0;
                        dbvat=0;
                        crvat=0;

                    }


                    else
                    {
                        balvat = decimal.Parse(dtvat.Rows[0]["total"].ToString());
                        dbvat = decimal.Parse(dtvat.Rows[0]["dbval"].ToString());
                        crvat = decimal.Parse(dtvat.Rows[0]["crval"].ToString());
                        
                    }
                }
                if (dtcash.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcash.Rows[0]["total"].ToString()))
                    {
                        balcash=0;
                        dbcash=0;
                        crcash=0;

                    }


                    else
                    {
                        balcash = decimal.Parse(dtcash.Rows[0]["total"].ToString());
                        dbcash = decimal.Parse(dtcash.Rows[0]["dbval"].ToString());
                        crcash = decimal.Parse(dtcash.Rows[0]["crval"].ToString());
                        
                    }
                }

                
                
                if (dtbank.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtbank.Rows[0]["total"].ToString()))
                    {
                        balcard=0;
                        dbcard=0;
                        crcard=0;

                    }


                    else
                    {
                        balcard = decimal.Parse(dtbank.Rows[0]["total"].ToString());
                        dbcard = decimal.Parse(dtbank.Rows[0]["dbval"].ToString());
                        crcard = decimal.Parse(dtbank.Rows[0]["crval"].ToString());
                        
                    }
                }
                
                if (dtdb.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtdb.Rows[0]["total"].ToString()))
                    {
                        balcustomers=0;
                        dbcustomers=0;
                        crcustomers=0;

                    }


                    else
                    {
                        balcustomers = decimal.Parse(dtdb.Rows[0]["total"].ToString());
                        dbcustomers = decimal.Parse(dtdb.Rows[0]["dbval"].ToString());
                        crcustomers = decimal.Parse(dtdb.Rows[0]["crval"].ToString());
                        
                    }
                }
                
                if (dtcr.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcr.Rows[0]["total"].ToString()))
                    {
                        balsuppliers=0;
                        dbsuppliers=0;
                        crsuppliers=0;

                    }


                    else
                    {
                        balsuppliers = decimal.Parse(dtcr.Rows[0]["total"].ToString());
                        dbsuppliers = decimal.Parse(dtcr.Rows[0]["dbval"].ToString());
                        crsuppliers = decimal.Parse(dtcr.Rows[0]["crval"].ToString());
                        
                    }
                }

                if (dtcost.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcost.Rows[0]["total"].ToString()))
                    {
                        crsales = 0;
                        

                    }


                    else
                    {
                        crsales = decimal.Parse(dtcost.Rows[0]["total"].ToString());
                        
                    }
                }

            }

            txtnet.Text = (balsales - crsales).ToString("#,0.00");
            if (balsales != 0)
            {
                txtprofit.Text = ((balsales - crsales) / balsales).ToString("P2");
            }              if (balsales != 0)
            {
                txtpercent.Text = ((balsales - balexpense)/ balsales).ToString("P2");
            }
            if (stockval != 0)
            {
                txtstock.Text = (crsales / stockval).ToString("P2");
            }
            if (stockbal != 0)
            {
                txtproduct.Text = (stockqty / stockbal).ToString("P2");
            }
            DataTable dt = createDatatable();
            dgvbalance.DataSource = dt;
            foreach (DataGridViewRow dgvr in dgvbalance.Rows)
                if (dgvr.Cells[3].Value == null || dgvr.Cells[3].Value == DBNull.Value || String.IsNullOrWhiteSpace(dgvr.Cells[3].Value.ToString()))
                {
                    break;
                }
                else
                {



                    if (double.Parse(dgvr.Cells[3].Value.ToString()) < 0)
                    {
                        //dgvr.DefaultCellStyle.BackColor = Color.Red;
                        dgvr.DefaultCellStyle.ForeColor = Color.Red;
                    }
                    
                }

        }
        public DataTable createDatatable()
        {
            DataTable myTable = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                                //*************insert data in datatable
            myTable.Columns.Add("description", typeof(string));
            myTable.Columns.Add("subtotal", typeof(decimal));
            myTable.Columns.Add("discount", typeof(decimal));
            myTable.Columns.Add("grandtotal", typeof(decimal));

            DataRow row0 = myTable.NewRow();
            row0["description"] = "المبيعات";
            row0["subtotal"] = 0;
            row0["discount"] = balsales;
            row0["grandtotal"] = 0;
            myTable.Rows.Add(row0);
            
            DataRow row1 = myTable.NewRow();
            row1["description"] = "تكلفة البضاعة المباعة";
            row1["subtotal"] = crsales;
            row1["discount"] =0;
            row1["grandtotal"] = 0;
            myTable.Rows.Add(row1);

            DataRow row2 = myTable.NewRow();
            row2["description"] = "الربح/الخسارة";
            row2["subtotal"] = 0;
            row2["discount"] = 0;
            row2["grandtotal"] = decimal.Parse(txtnet.Text);
            myTable.Rows.Add(row2);

            DataRow row3 = myTable.NewRow();
            row3["description"] = "المشتريات";
            row3["subtotal"] = balpurchase;
            row3["discount"] = 0;
            row3["grandtotal"] = 0;
            myTable.Rows.Add(row3);

            DataRow row4 = myTable.NewRow();
            row4["description"] = "المصروفات";
            row4["subtotal"] = balexpense;
            row4["discount"] = 0;
            row4["grandtotal"] = 0;
            myTable.Rows.Add(row4);

            

            DataRow row5 = myTable.NewRow();
            row5["description"] = "رصيدالصندوق";
            row5["subtotal"] = dbcash;
            row5["discount"] = crcash;
            row5["grandtotal"] = balcash;
            myTable.Rows.Add(row5);

            DataRow row6 = myTable.NewRow();
            row6["description"] = "رصيدالبطاقة-البنك";
            row6["subtotal"] = dbcard;
            row6["discount"] = crcard;
            row6["grandtotal"] = balcard;
            myTable.Rows.Add(row6);

            DataRow row7 = myTable.NewRow();
            row7["description"] = "رصيدالعملاء";
            row7["subtotal"] = dbcustomers;
            row7["discount"] = crcustomers;
            row7["grandtotal"] = balcustomers;
            myTable.Rows.Add(row7);

            DataRow row8 = myTable.NewRow();
            row8["description"] = "رصيد الموردون";
            row8["subtotal"] = dbsuppliers;
            row8["discount"] = crsuppliers;
            row8["grandtotal"] = balsuppliers;
            myTable.Rows.Add(row8);

            



            return myTable;

        }
        private void date1_ValueChanged(object sender, EventArgs e)
        {
                DisplayTotals();
        }

        private void txtnet_TextChanged_1(object sender, EventArgs e)
        {
            if (double.Parse(txtnet.Text) > 0)
            {
                txtnet.ForeColor = Color.Green;
            }
            else
            {
                txtnet.ForeColor = Color.Red;
            }
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
                DisplayTotals();
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
            string sdate = date1.Value.Date.ToShortDateString();
            string edate = date2.Value.Date.ToShortDateString();
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");

            

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
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter();
            rp5.Name = "logo";
            rp5.Values.Add(@"file:///" + clogo);
            ReportParameter rp6 = new ReportParameter("netprofit", txtnet.Text);
            ReportParameter rp7 = new ReportParameter("pval", txtprofit.Text);
            ReportParameter rp8 = new ReportParameter("percent", txtpercent.Text);
            ReportParameter rp9 = new ReportParameter("stock", txtstock.Text);
            ReportParameter rp10 = new ReportParameter("product", txtproduct.Text);

            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\finalrepsamll.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5,rp6,rp7,rp8,rp9,rp10});
            //this.report.RefreshReport();

            DataTable dt = createDatatable();


            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);
            this.Hide();



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

        public static void Export1(LocalReport report, bool print = true)
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

        private void btnexport_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = true;
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                worksheet.Name = "Records";

                try
                {
                    for (int i = 0; i < dgvbalance.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvbalance.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvbalance.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvbalance.Columns.Count; j++)
                        {
                            if (dgvbalance.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvbalance.Rows[i].Cells[j].Value.ToString();
                            }
                            else
                            {
                                worksheet.Cells[i + 2, j + 1] = "";
                            }
                        }
                    }

                    //Getting the location and file name of the excel to save from user. 
                    SaveFileDialog saveDialog = new SaveFileDialog();
                    saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveDialog.FilterIndex = 2;

                    if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show("Export Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                finally
                {
                    app.Quit();
                    workbook = null;
                    worksheet = null;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); 
            }
        }

        private void txtnet_TextChanged(object sender, EventArgs e)
        {
            if (double.Parse(txtnet.Text) > 0)
            {
                txtnet.ForeColor = Color.Green;
            }
            else
            {
                txtnet.ForeColor = Color.Red;
            }
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
            string sdate = date1.Value.Date.ToShortDateString();
            string edate = date2.Value.Date.ToShortDateString();
            DataTable dtc = prdal.GetCompanyData();

            string arname = dtc.Rows[0]["aname"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();



            //DataTable dts = GetSalesData();

            string invdate = DateTime.Now.ToString("dd-MM-yyyy");



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
            ReportParameter rp3 = new ReportParameter("sdate", sdate);
            ReportParameter rp4 = new ReportParameter("edate", edate);
            ReportParameter rp5 = new ReportParameter();
            rp5.Name = "logo";
            rp5.Values.Add(@"file:///" + clogo);
            ReportParameter rp6 = new ReportParameter("netprofit", txtnet.Text);
            ReportParameter rp7 = new ReportParameter("pval", txtprofit.Text);
            ReportParameter rp8 = new ReportParameter("percent", txtpercent.Text);
            ReportParameter rp9 = new ReportParameter("stock", txtstock.Text);
            ReportParameter rp10 = new ReportParameter("product", txtproduct.Text);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\finalrepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5,rp6,rp7,rp8,rp9,rp10 });
            //this.report.RefreshReport();

            DataTable dt = createDatatable();


            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);
            this.Hide();



        }
    }
    
}
