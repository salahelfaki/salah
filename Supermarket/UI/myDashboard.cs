using Supermarket.DAL;
using Supermarket.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Supermarket.UI
{
    public partial class myDashboard : Form
    {
        companyDAL dal = new companyDAL();
        public myDashboard()
        {
            DataTable dt = dal.Select();
            string lang = dt.Rows[0]["lang"].ToString();
            switch (lang)
            {
                case "Arabic":
                    //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-SA");
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ar-EG");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ar-EG");
                    break;
                case "English":
                    //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    break;
            }

            InitializeComponent();
           
        }

        purchaseDAL purdal = new purchaseDAL();
        salesDAL sdal = new salesDAL();
        accttrDAL acdal = new accttrDAL();
        productsDAL pdal = new productsDAL();

        public decimal dbsales, crsales, balsales = 0;
        public decimal dbpurchase, crpurchase, balpurchase = 0;
        public decimal dbexpense, crexpense, balexpense = 0;
        public decimal dbvat, crvat, balvat = 0;
        public decimal dbcash, crcash, balcash = 0;

        private void btnmain_Click(object sender, EventArgs e)
        {
            myDashboard frm = new myDashboard();
            frm.Show();
        }

        public decimal dbcard, crcard, balcard = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            frmaccounting frm = new frmaccounting();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmpurchaseStock frm = new frmpurchaseStock();
            frm.Show();
        }

        private void btnsales_KeyDown_1(object sender, KeyEventArgs e)
        {

        }

        public decimal dbcustomers, crcustomers, balcustomers = 0;
        public decimal dbsuppliers, crsuppliers, balsuppliers = 0;
        public decimal stockval, stockqty, stockbal = 0;
        public decimal salestotal, expensetotal, profittotals,purchasetotal = 0;

        
        private void myDashboard_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            string remdays = "";
            string mver = "";
            lbldate.Text = DateTime.Now.ToString();
            System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("nl-NL");
           label9.Text = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);

            label10.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label11.Text = DateTime.Now.ToShortTimeString();

            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            loguser.Text = frmlogin.loggedin;
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                remdays = "    الايام المتبقية للنسخة التجريبية:  ";
                mver = "برنامج ادارة السيوبرماركت نسخة 1";
            }
            else
            {
                remdays = "Trial Remaining Days:";

            }
            /*
            if (Settings.Default.IsLicensed == true)
            {
                lbltrial.Text = "License Activated";
            }
            else
            {
                lbltrial.Text = remdays + FrmLicense.lbldays;


                timer1.Start();
            }
            
            if (frmlogin.userrole == "User")
            {
               
                btnacct.Enabled = false;
                btnpurchase.Enabled = false;
                btnrep.Enabled = false;
                btnreturn.Enabled = false;
                btnsettings.Enabled = false;
                btntools.Enabled = false;
                btnusers.Enabled = false;

                btnusers.BackColor = Color.Gray;
                btnacct.BackColor = Color.Gray;
                btnpurchase.BackColor = Color.Gray;
                btnrep.BackColor = Color.Gray;
                btnreturn.BackColor = Color.Gray;
                btnsettings.BackColor = Color.Gray;
                btntools.BackColor = Color.Gray;

                purchaseToolStripMenuItem.Enabled = false;
                reportsToolStripMenuItem.Enabled = false;
                accountingToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;

                toolStripMenuItem2.Enabled = false;
                الحساباتToolStripMenuItem.Enabled = false;
                الأدواتToolStripMenuItem.Enabled = false;
            }
            string myimage = @"C:\images";
            if (Directory.Exists(myimage))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(myimage);
            }
                */
            DisplayTotals();

        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show("Ctrl-F was Pressed.");
            btnsales.FlatStyle = FlatStyle.Flat; // Apply flat style
            frminvoice frm = new frminvoice();
            frm.Show();
            btnsales.FlatStyle = FlatStyle.Standard; // Restore standard style
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F10))
            {
                btnsales.PerformClick(); // Simulate button click
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnmenu_Click(object sender, EventArgs e)
        {
            if (panelmenu.Visible == true)
            {
                panelmenu.Visible = false;
            }
            else
            {
                panelmenu.Visible = true;
            }
            

        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        public void DisplayTotals()
        {
            DateTime sdate = DateTime.Now.Date;
            DateTime edate = DateTime.Now.Date.AddDays(1);
           
            DataTable dtp = purdal.GetTotalPurchase(sdate, edate);
            DataTable dts = sdal.GetSalesTotals(sdate, edate);

           // DataTable dtcash = acdal.BalanceTotal(sdate, edate, "11001");
            //DataTable dtbank = acdal.BalanceTotal(sdate, edate, "11002");
            //DataTable dtvat = acdal.BalanceTotal(sdate, edate, "15001");

            DataTable dtex = acdal.AcctBalanceTotal(sdate, edate, "4");
            //DataTable dtdb = acdal.AcctBalanceTotal(sdate, edate, "2");
            //DataTable dtcr = acdal.AcctBalanceTotal(sdate, edate, "3");
            DataTable dtcost = sdal.GetProductCost(sdate, edate);
            stockval = pdal.GetStockValue();
            stockqty = pdal.GetStockQtyAvailable();
            stockbal = pdal.GetStockAll();
            salestotal = sdal.GetSalesALL();
            expensetotal = acdal.GetExpensesAll();
            purchasetotal = purdal.GetPurchaseALL();
            profittotals = salestotal - expensetotal;

            txtsales.Text = salestotal.ToString("#,0.00");
            txtexpense.Text = expensetotal.ToString("#,0.00");
            txtprofit.Text = profittotals.ToString("#,0.00");






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
                    balpurchase = 0;
                }


                else
                {
                    balpurchase = decimal.Parse(dtp.Rows[0]["total"].ToString());

                }


                if (dtex.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtex.Rows[0]["total"].ToString()))
                    {
                        balexpense = 0;
                    }


                    else
                    {
                        balexpense = decimal.Parse(dtex.Rows[0]["total"].ToString());

                    }
                }

                /*
                if (dtvat.Rows.Count > 0)
                {

                    if (string.IsNullOrEmpty(dtvat.Rows[0]["total"].ToString()))
                    {
                        balvat = 0;
                        dbvat = 0;
                        crvat = 0;

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
                        balcash = 0;
                        dbcash = 0;
                        crcash = 0;

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
                        balcard = 0;
                        dbcard = 0;
                        crcard = 0;

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
                        balcustomers = 0;
                        dbcustomers = 0;
                        crcustomers = 0;

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
                        balsuppliers = 0;
                        dbsuppliers = 0;
                        crsuppliers = 0;

                    }


                    else
                    {
                        balsuppliers = decimal.Parse(dtcr.Rows[0]["total"].ToString());
                        dbsuppliers = decimal.Parse(dtcr.Rows[0]["dbval"].ToString());
                        crsuppliers = decimal.Parse(dtcr.Rows[0]["crval"].ToString());

                    }
                }
                */
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

            txtdayprofit.Text = (balsales - balexpense).ToString("#,0.00");
            txtdaysales.Text = balsales.ToString("#,0.00");
            txtdayexpense.Text = balexpense.ToString("#,0.00");

            /*
            if (balsales != 0)
            {
                txtprofit.Text = ((balsales - crsales) / balsales).ToString("P2");
            }
            if (balsales != 0)
            {
                txtpercent.Text = ((balsales - balexpense) / balsales).ToString("P2");
            }
            if (stockval != 0)
            {
                txtstock.Text = (crsales / stockval).ToString("P2");
            }
            if (stockbal != 0)
            {
                txtproduct.Text = (stockqty / stockbal).ToString("P2");
            }
            */

            // Create datatable and bind data to the chart
            DataTable myTable = new DataTable();//prdal.itemTrans(sdate,edate,product);
                                                //*************insert data in datatable
            //myTable.Columns.Add("description", typeof(string));
            myTable.Columns.Add("sales", typeof(decimal));
            myTable.Columns.Add("purchase", typeof(decimal));
            myTable.Columns.Add("expense", typeof(decimal));
            myTable.Columns.Add("month", typeof(decimal));

            DataRow row0 = myTable.NewRow();
            row0["sales"] = salestotal;
            row0["purchase"] = purchasetotal;
            row0["expense"] = expensetotal;
            row0["month"] =1 ;
            myTable.Rows.Add(row0);
            /*
            DataRow row1 = myTable.NewRow();
            row1["sales"] = salestotal;
            row1["purchase"] = purchasetotal;
            row1["expense"] = expensetotal;
            row1["month"] = 2;
            myTable.Rows.Add(row1);
            
            */

            // Set the chart's data source
            DataSet ds = new DataSet();
            ds.Tables.Add(myTable);

            // this.chart2.DataSource = ds.Tables[0];
            chart2.Series.Clear();

            // Create series for UnitPrice
            var series1 = new Series("مبيعات")
                {
                    ChartType = SeriesChartType.Column // Choose the appropriate chart type
            };

            // Create series for Quantity (example)
            var series2 = new Series("مشتريات")
            {
                ChartType = SeriesChartType.Column // Choose the appropriate chart type
            };
            var series3 = new Series("مصروفات")
            {
                ChartType = SeriesChartType.Column // Choose the appropriate chart type
            };

            foreach (DataRow row in myTable.Rows)
            {
                
                double sales = Convert.ToDouble(row["sales"]);
                double purchase = Convert.ToDouble(row["purchase"]);
                double expense = Convert.ToDouble(row["expense"]);
                string month = row["month"].ToString();

                series1.Points.AddXY(month, sales);
                series2.Points.AddXY(month, purchase);
                series3.Points.AddXY(month, expense);
            }

            // Add the series to the chart
            chart2.Series.Add(series1);
            chart2.Series.Add(series2); // Add other series as needed
            chart2.Series.Add(series3);


            chart3.Series.Clear();

            
            var series4 = new Series("مبيعات")
            {
                ChartType = SeriesChartType.Pie // Choose the appropriate chart type
            };

            // Create series for Quantity (example)
            var series5 = new Series("مشتريات")
            {
                ChartType = SeriesChartType.Pie // Choose the appropriate chart type
            };
            var series6 = new Series("مصروفات")
            {
                ChartType = SeriesChartType.Pie // Choose the appropriate chart type
            };
            
            foreach (DataRow row in myTable.Rows)
            {
           
                double sales1 = Convert.ToDouble(row["sales"]);
                double purchase1 = Convert.ToDouble(row["purchase"]);
                double expense1 = Convert.ToDouble(row["expense"]);
                //string month = row["month"].ToString();

                series4.Points.AddXY("Sales",sales1);
                series5.Points.AddXY("Purchase",purchase1);
                series6.Points.AddXY("Expense",expense1);
            }

            // Add the series to the chart
            chart3.Series.Add(series4);
            chart3.Series.Add(series5); // Add other series as needed
            chart3.Series.Add(series6);
            /*
            // Map a field with x-values of the chart
            this.chart2.Series[0].XValueMember = "month";
            this.chart2.Series[0].YValueMembers = "subtotal";
            
            this.chart2.Series[1].XValueMember = "description";
            this.chart2.Series[1].YValueMembers = "subtotal";

            this.chart2.Series[2].XValueMember = "description";
            this.chart2.Series[2].YValueMembers = "subtotal";
            */

        }



    }
}
