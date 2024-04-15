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
    public partial class frmvaluesrep : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmvaluesrep()
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

        private void frmsalesrep_Load(object sender, EventArgs e)
        {
            
            DisplayTotals();

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


            double dbs,crs,bals = 0;
            double dbp,crp,balp = 0;
            double dbex,crex,balex = 0;
            double dbv,crv,balv = 0;
            double dbch,crch,balch = 0;
            double dbcrd,crcrd,balcrd = 0;
            double dbcu, crcu, balcu = 0;
            double dbsp, crsp, balsp = 0;




            if (dts.Rows.Count > 0)
            {

                if (string.IsNullOrEmpty(dts.Rows[0]["total"].ToString()))
                {
                    balsales.Text = "0.00";
                }


                else
                {
                    bals = double.Parse(dts.Rows[0]["total"].ToString());
                    balsales.Text = bals.ToString("#,0.00");

                }


            }

            if (dtp.Rows.Count > 0)
            {

                if (string.IsNullOrEmpty(dtp.Rows[0]["total"].ToString()))
                {
                    balpurchase.Text = "0.00";
                }


                else
                {
                    balp = double.Parse(dtp.Rows[0]["total"].ToString());
                    balpurchase.Text = balp.ToString("#,0.00");

                }
               

                if (dtex.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtex.Rows[0]["total"].ToString()))
                    {
                        balexpense.Text = "0.00";
                    }


                    else
                    {
                        balex = double.Parse(dtex.Rows[0]["total"].ToString());
                        balexpense.Text = balex.ToString("#,0.00");

                    }
                }
                txtnet.Text = (bals - balp - balex).ToString("#,0.00");

                if (dtvat.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtvat.Rows[0]["total"].ToString()))
                    {
                        balvat.Text = "0.00";
                        dbvat.Text = "0.00";
                        crvat.Text = "0.00";

                    }


                    else
                    {
                        balv = double.Parse(dtvat.Rows[0]["total"].ToString());
                        dbv = double.Parse(dtvat.Rows[0]["dbval"].ToString());
                        crv = double.Parse(dtvat.Rows[0]["crval"].ToString());
                        dbvat.Text = dbv.ToString("#,0.00");
                        crvat.Text = crv.ToString("#,0.00");
                        balvat.Text = balv.ToString("#,0.00");

                    }
                }
                if (dtcash.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcash.Rows[0]["total"].ToString()))
                    {
                        balcash.Text = "0.00";
                        dbcash.Text = "0.00";
                        crcash.Text = "0.00";

                    }


                    else
                    {
                        balch = double.Parse(dtcash.Rows[0]["total"].ToString());
                        dbch = double.Parse(dtcash.Rows[0]["dbval"].ToString());
                        crch = double.Parse(dtcash.Rows[0]["crval"].ToString());
                        dbcash.Text = dbch.ToString("#,0.00");
                        crcash.Text = crch.ToString("#,0.00");
                        balcash.Text = balch.ToString("#,0.00");

                    }
                }

                if (dtcash.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcash.Rows[0]["total"].ToString()))
                    {
                        balcash.Text = "0.00";
                        dbcash.Text = "0.00";
                        crcash.Text = "0.00";

                    }


                    else
                    {
                        balch = double.Parse(dtcash.Rows[0]["total"].ToString());
                        dbch = double.Parse(dtcash.Rows[0]["dbval"].ToString());
                        crch = double.Parse(dtcash.Rows[0]["crval"].ToString());
                        dbcash.Text = dbch.ToString("#,0.00");
                        crcash.Text = crch.ToString("#,0.00");
                        balcash.Text = balch.ToString("#,0.00");

                    }
                }
                
                if (dtbank.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtbank.Rows[0]["total"].ToString()))
                    {
                        balcard.Text = "0.00";
                        dbcard.Text = "0.00";
                        crcard.Text = "0.00";

                    }


                    else
                    {
                        balcrd = double.Parse(dtbank.Rows[0]["total"].ToString());
                        dbcrd = double.Parse(dtbank.Rows[0]["dbval"].ToString());
                        crcrd = double.Parse(dtbank.Rows[0]["crval"].ToString());
                        dbcard.Text = dbcrd.ToString("#,0.00");
                        crcard.Text = crcrd.ToString("#,0.00");
                        balcard.Text = balcrd.ToString("#,0.00");

                    }
                }
                
                if (dtdb.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtdb.Rows[0]["total"].ToString()))
                    {
                        balcustomers.Text = "0.00";
                        dbcustomers.Text = "0.00";
                        crcustomers.Text = "0.00";

                    }


                    else
                    {
                        balcu = double.Parse(dtdb.Rows[0]["total"].ToString());
                        dbcu = double.Parse(dtdb.Rows[0]["dbval"].ToString());
                        crcu = double.Parse(dtdb.Rows[0]["crval"].ToString());
                        dbcustomers.Text = dbcu.ToString("#,0.00");
                        crcustomers.Text = crcu.ToString("#,0.00");
                        balcustomers.Text = balcu.ToString("#,0.00");

                    }
                }
                
                if (dtcr.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtcr.Rows[0]["total"].ToString()))
                    {
                        balsuppliers.Text = "0.00";
                        dbsuppliers.Text = "0.00";
                        crsuppliers.Text = "0.00";

                    }


                    else
                    {
                        balsp = double.Parse(dtcr.Rows[0]["total"].ToString());
                        dbsp = double.Parse(dtcr.Rows[0]["dbval"].ToString());
                        crsp = double.Parse(dtcr.Rows[0]["crval"].ToString());
                        dbsuppliers.Text = dbsp.ToString("#,0.00");
                        crsuppliers.Text = crsp.ToString("#,0.00");
                        balsuppliers.Text = balsp.ToString("#,0.00");

                    }
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

            DataRow row = myTable.NewRow();

            row["description"] = "المبيعات";
            row["subtotal"] = 0;
            row["discount"] = decimal.Parse(balsales.Text);
            row["grandtotal"] = 0;
            myTable.Rows.Add(row);

            DataRow row1 = myTable.NewRow();
            row1["description"] = "المشتريات";
            row1["subtotal"] = decimal.Parse(balpurchase.Text);
            row1["discount"] = 0;
            row1["grandtotal"] = 0;
            myTable.Rows.Add(row1);

            DataRow row2 = myTable.NewRow();
            row2["description"] = "المصروفات";
            row2["subtotal"] = decimal.Parse(balexpense.Text);
            row2["discount"] = 0;
            row2["grandtotal"] = 0;
            myTable.Rows.Add(row2);

            DataRow row3 = myTable.NewRow();
            row3["description"] = "الربح/الخسارة";
            row3["subtotal"] = 0;
            row3["discount"] = 0;
            row3["grandtotal"] = decimal.Parse(txtnet.Text);
            myTable.Rows.Add(row3);

            DataRow row4 = myTable.NewRow();
            row4["description"] = "رصيدالصندوق";
            row4["subtotal"] = decimal.Parse(dbcash.Text);
            row4["discount"] = decimal.Parse(crcash.Text);
            row4["grandtotal"] = decimal.Parse(balcash.Text);
            myTable.Rows.Add(row4);

            DataRow row5 = myTable.NewRow();
            row5["description"] = "رصيدالبطاقة-البنك";
            row5["subtotal"] = decimal.Parse(dbcard.Text);
            row5["discount"] = decimal.Parse(crcard.Text);
            row5["grandtotal"] = decimal.Parse(balcard.Text);
            myTable.Rows.Add(row5);

            DataRow row6 = myTable.NewRow();
            row6["description"] = "رصيدالعملاء";
            row6["subtotal"] = decimal.Parse(dbcustomers.Text);
            row6["discount"] = decimal.Parse(crcustomers.Text);
            row6["grandtotal"] = decimal.Parse(balcustomers.Text);
            myTable.Rows.Add(row6);
            DataRow row7 = myTable.NewRow();
            row7["description"] = "رصيد الموردون";
            row7["subtotal"] = decimal.Parse(dbsuppliers.Text);
            row7["discount"] = decimal.Parse(crsuppliers.Text);
            row7["grandtotal"] = decimal.Parse(balsuppliers.Text);
            myTable.Rows.Add(row7);
            return myTable;

        }
        private void date1_ValueChanged(object sender, EventArgs e)
        {
                DisplayTotals();
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
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\finalrepsamll.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5});
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
        {/*
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
                    for (int i = 0; i < dgvpurchase.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvpurchase.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dgvpurchase.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvpurchase.Columns.Count; j++)
                        {
                            if (dgvpurchase.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvpurchase.Rows[i].Cells[j].Value.ToString();
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
            }*/
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
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\finalrepA4.rdlc";
            report.ReportPath = fullpath;



            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5 });
            //this.report.RefreshReport();

            DataTable dt = createDatatable();


            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);
            this.Hide();



        }
    }
    
}
