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
using System.Transactions;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmpurchasereturn : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmpurchasereturn()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
        printDAL prdal = new printDAL();
        purchaseDAL purdal = new purchaseDAL();
        DataTable detailsDT = new DataTable();
        transactionDAL tdal = new transactionDAL();
        transactionDetailDAL tddal = new transactionDetailDAL();

        public string msave = "";
        public string fsave = "";
        TextBox txtacctcode = new TextBox();
        TextBox oldno = new TextBox();

        private void frmpurchasereturn_Load(object sender, EventArgs e)
        {
            DataTable dt = purdal.GetInvoiceDetails(txtbillno.Text);
            dgvaddproduct.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvaddproduct.Columns[0].HeaderText = "الرقم";
                dgvaddproduct.Columns[1].HeaderText = "الاسم";
                dgvaddproduct.Columns[2].HeaderText = "الكمية";
                dgvaddproduct.Columns[3].HeaderText = "السعر";
                dgvaddproduct.Columns[4].HeaderText = "الاجمالي";
                //dgvaddproduct.Columns[5].HeaderText = "الخصم";
                //dgvaddproduct.Columns[6].HeaderText = "الصافى";
                msave = "تم الاسترجاع";
                fsave = "خطأ..فشل الاسترجاع";
            }
            else
            {
                dgvaddproduct.Columns[0].HeaderText = "Barcode";
                dgvaddproduct.Columns[1].HeaderText = "Name";
                dgvaddproduct.Columns[2].HeaderText = "Qty";
                dgvaddproduct.Columns[3].HeaderText = "Price";
                dgvaddproduct.Columns[4].HeaderText = "Total";
                //dgvaddproduct.Columns[5].HeaderText = "Discount";
                //dgvaddproduct.Columns[6].HeaderText = "NetValue";
                msave = "Return Successfull...";
                fsave = "Return Failed...";
            }


            //string product_id = "";
            //string productname = "";// txtpname.Text;
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
            //dgvaddproduct.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvaddproduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            // dgvaddproduct.Columns[8].Width = 50;


            txtsubtotal.Text = subtotal.ToString();
          //  cmbpayment.SelectedItem = "Cash";


            // Bills drop down list
            string sql2 = "Select id,dealer from tbl_purchase";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "purchase");

            //cmbbillno.DataSource = ds.Tables["sales"];
            // cmbbillno.DisplayMember = "id";
            // cmbbillno.ValueMember = "id";
            string mcat = txtbillno.Text;
            // Bills drop down list
            string sql3 = "Select mid,paymethod from tbl_paymethod";
            SqlCommand cmd3 = new SqlCommand(sql3, conn2);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "pay");

            cmbtype.DisplayMember = "paymethod";
            cmbtype.ValueMember = "mid";
            cmbtype.DataSource = ds3.Tables["pay"];

            conn2.Close();
            //***
           



        }

        private void txtbillno_Validated(object sender, EventArgs e)
        {
            string keywords = txtbillno.Text;
            if (keywords == "")
            {

                //  txtname.Text = "";
                //txtvatno.Text = "";

                return;


            }
            
            purchaseBLL rc = purdal.GetReturnNo(keywords);
            
            if (rc.returnno ==0)
            {


                purchaseBLL sc = purdal.GetInvoiceID(keywords);
                txtbillno.Text = sc.id.ToString();
                DataTable dts = purdal.GetInvoicePurchase(keywords);
                if (dts.Rows.Count > 0)
                {
                    string mdate = dts.Rows[0]["trdate"].ToString();
                    txtdate.Text = mdate.ToString();
                    txtdescription.Text = dts.Rows[0]["description"].ToString();
                    txtinvno.Text = dts.Rows[0]["invno"].ToString();
                    txtsubtotal.Text = dts.Rows[0]["subtotal"].ToString();
                    txtvat.Text = dts.Rows[0]["vat"].ToString();
                    txtdiscount.Text = dts.Rows[0]["discount"].ToString();
                    txtgrandtotal.Text = dts.Rows[0]["grandtotal"].ToString();
                    string spaymethod = dts.Rows[0]["paymethod"].ToString();
                    txtacctcode.Text = dts.Rows[0]["acctcode"].ToString();
                    //txtpaid.Text = dts.Rows[0]["paid"].ToString();
                    //txtreturn.Text = dts.Rows[0]["return"].ToString();
                    txtuser.Text = dts.Rows[0]["added_by"].ToString();
                    

                    cmbtype.SelectedValue = spaymethod;
                    txtsupplier.Text = dts.Rows[0]["dealer"].ToString();

                    acctsBLL cdat = dcdal.searchdealercustomerfortransaction(txtsupplier.Text);
                    txtvatno.Text = cdat.vatno;
                    oldno.Text = txtbillno.Text;

                }

                DataTable sdat = purdal.GetInvoiceDetails(txtbillno.Text);
                dgvaddproduct.DataSource = sdat;
            }
            else
            {
                MessageBox.Show("تم اجراء المرتجع...");
                return;
            }



        }

        private void txtbillno_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void frmpurchasereturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
               // e.SuppressKeyPress = true;
            }
        }

        private void dgvaddproduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;



            switch (e.ColumnIndex)
            {
                case 0:

                    string keywords = (Convert.ToString(dgvaddproduct.CurrentCell.Value));
                    if (keywords == "")
                    {


                        break; ;

                    }
                    else
                    {
                        int currentRow = dgvaddproduct.CurrentCell.RowIndex;
                        if (currentRow > 0)
                        {
                            string myoldbarvalue = this.dgvaddproduct.Rows[currentRow - 1].Cells[0].Value.ToString();
                            string myoldqtyval = this.dgvaddproduct.Rows[currentRow - 1].Cells[2].Value.ToString();
                            decimal myoldqty = decimal.Parse(myoldqtyval);

                        }



                        productsBLL dc = new productsBLL();
                        SqlConnection conn = new SqlConnection(myconnstrng);
                        DataTable dt = new DataTable();



                        try
                        {
                            string sql = "Select barcode,pname,qty,rate from tbl_products WHERE barcode LIKE '%" + keywords + "%' OR pname LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            conn.Open();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            //    while(dt.Rows.Count>0)
                            {

                                txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["pname"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt.Rows[0]["rate"].ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;


                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);
                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString();
                                //this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                //this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
                                double oldmdiscount = double.Parse(txtdiscount.Text);
                                double dsubtotal = double.Parse(txtsubtotal.Text);
                                double nsubtotal = ntotal + dsubtotal;
                                double newnet = nsubtotal - oldmdiscount;
                                dgvaddproduct.Update();
                                dgvaddproduct.Refresh();
                                txtsubtotal.Text = nsubtotal.ToString();
                                txtnetval.Text = newnet.ToString();
                                TransCalculations();

                            }
                            else
                            {
                                if (MessageBox.Show("الصنف غير موجود...إضافة", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    frmproducts padd = new frmproducts();
                                    padd.Show();
                                }
                                else
                                {

                                }

                            }




                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            conn.Close();

                        }





                        //






                    }





                    //dgvaddproduct.CurrentCell = dgvaddproduct.Rows[rowIndex].Cells[4];



                    break;
                case 3:
                case 2:
                    string mrate = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                    string mqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();

                    string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
                    //string name = this.dgvaddproduct.Rows[rowIndex].Cells["name"].Value.ToString();
                    double oldtotal = double.Parse(mtotal);


                    double newtotal1 = double.Parse(mrate) * double.Parse(mqty);
                    this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = newtotal1.ToString();
                    //this.dgvaddproduct.Columns["total"] = (Convert.ToDouble(row.Cells[dgvaddproduct.Columns["price"].Index].value) * (convert.todouble(rwo.cells[dgvaddproduct.columns["qty].index].value



                    double oldsubtotal = double.Parse(txtsubtotal.Text);
                    double oldmydiscount = double.Parse(txtdiscount.Text);
                    double newsubtotal1 = newtotal1 + oldsubtotal - oldtotal;
                    double newnetval1 = newsubtotal1 - oldmydiscount;
                    dgvaddproduct.Update();
                    dgvaddproduct.Refresh();
                    txtsubtotal.Text = newsubtotal1.ToString();
                    txtnetval.Text = newnetval1.ToString();
                    TransCalculations();
                    //-------------
                    /*
                    double vat = subtotal * 0.15;  // ((100+15)/100)*subtotal;
                    txtvat.Text = vat.ToString();
                    double grandtotalwithvat = vat + subtotal; //((100 + 15) / 100) * prevgrand;
                    txtgrandtotal.Text = grandtotalwithvat.ToString();
                    */
                    break;
                case 5:
                    string mytotal1 = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
                    //string mydiscount = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();


                    if (mytotal1 != "")
                    {

                        double mntotal = Convert.ToDouble(mytotal1);
                        //double ndiscount = Convert.ToDouble(mydiscount);
                       // double mgtotal = mntotal - ndiscount;
                       // this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = mgtotal.ToString();
                        //double noldsubtotal = double.Parse(txtsubtotal.Text);
                        double newsubtotal = double.Parse(txtsubtotal.Text);
                        double oldnetdiscount = double.Parse(txtolddiscount.Text);
                        double olddiscount2 = double.Parse(txtdiscount.Text);
                        double newdiscount = olddiscount2 - oldnetdiscount;
                        txtdiscount.Text = newdiscount.ToString();
                        double newnetval = newsubtotal - newdiscount;
                        txtnetval.Text = newnetval.ToString();

                        dgvaddproduct.Update();
                        dgvaddproduct.Refresh();
                        TransCalculations();





                    }
                    break;








                //-------------


                default:
                    //MessageBox.Show("Error");
                    break;

            }
        }
        private void TransCalculations()
        {
            dgvaddproduct.Update();
            dgvaddproduct.Refresh();

            double invnetval = double.Parse(txtnetval.Text);
            double nvat = invnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = nvat.ToString();
            double mygrandtotalwithvat = nvat + invnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            transactionBLL trans = new transactionBLL();
            trans.trdate = DateTime.Now;
            trans.description = txtdescription.Text;
            trans.subtotal = decimal.Parse(txtsubtotal.Text)*-1;
            trans.vat = decimal.Parse(txtvat.Text)*-1;
            trans.discount = decimal.Parse(txtdiscount.Text)*-1;
            trans.grandtotal = decimal.Parse(txtgrandtotal.Text)*-1;
            trans.added_by = frmlogin.loggedin;
            trans.trtype = "4";
            trans.customer = txtsupplier.Text;
            trans.ordertype = txtinvno.Text;
            trans.invdate = DateTime.Parse(txtdate.Text);
            trans.returnno = 0;
            trans.paymethod = cmbtype.SelectedValue.ToString();
            trans.branch = txtbranch.Text;
            trans.acctcode = txtacctcode.Text;
            trans.invno = int.Parse(txtbillno.Text);


            //DataTable detailsDT = sdal.GetTempDetails(int.Parse(txtid.Text));
            //DataTable detailsDT = new DataTable();

            //transaction.transactionDetails = detailsDT;

            bool Issuccess = false;
            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
                bool w = tdal.insertPurchaseReturnTransaction(trans, out transactionID);
                txtbillno.Text = transactionID.ToString();

                //for details
                transactiondetailBLL transactionDetail = new transactiondetailBLL();
                for (int i = 0; i < dgvaddproduct.Rows.Count; i++)

                {
                    string pcode = "";

                    if (dgvaddproduct.Rows[i].Cells[0].Value != null)
                    {


                        pcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();


                        productsBLL mypid = pdal.getproductidfromname(pcode);

                        int mproductid = mypid.id;
                        decimal mcost = mypid.costprice;
                        decimal qtyhand = mypid.qty;

                        decimal mbal = qtyhand + decimal.Parse(dgvaddproduct.Rows[i].Cells[2].Value.ToString())*-1;

                        transactionDetail.trid = transactionID;
                        transactionDetail.barcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                        transactionDetail.productname = dgvaddproduct.Rows[i].Cells[1].Value.ToString();
                        transactionDetail.productid = mproductid;
                        transactionDetail.costprice = mcost;
                        transactionDetail.qty = decimal.Parse(dgvaddproduct.Rows[i].Cells[2].Value.ToString())*-1;
                        transactionDetail.rate = decimal.Parse(dgvaddproduct.Rows[i].Cells[3].Value.ToString())*-1;
                        transactionDetail.total = decimal.Parse(dgvaddproduct.Rows[i].Cells[4].Value.ToString())*-1;
                        transactionDetail.balance = mbal;
                        transactionDetail.trtype = "4";
                        //insert details

                        bool x = tddal.insertPurchaseTransactionDetail(transactionDetail);
                        Issuccess = w && x;
                    }
                }



            

            if (Issuccess == true)
            {
                scope.Complete();
                MessageBox.Show("تم الحفظ....");
                btnprnt.Enabled = true;
                btnprntA4.Enabled = true;


            }
            else
            {
                MessageBox.Show("لم يتم الحفظ!!!");
            }

        }
    }



                   

        


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void frmClear()
        {
            this.Close();
            frmpurchasereturn main = new frmpurchasereturn();
            main.Show();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            

        }

        private void dgvaddproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {
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
            double mnetval = msubtotal + nvat;
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
            ReportParameter rp16 = new ReportParameter("reptitle", "مرتجع مشتريات");

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\purchaseRepA4.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15,rp16});
            //this.report.RefreshReport();
            DataTable dt = DisplayAllpurchase();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter(report);

            frmClear();



        }
        public DataTable GetpurchaseData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tbl_purchase where id='" + txtbillno.Text + "'";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

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
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select itemname as name,sum(itemqty) as qty ,itemprice as rate,itemprice*sum(qty) as total from tbl_purchaseitems where trid='" + txtbillno.Text + "' GROUP BY itemname";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

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
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.itemname As name,sum(itemqty) as qty,itemprice as rate, sum(b.itemtotal) as total from tbl_purchase a,tbl_purchaseitems b where b.trid=a.id and a.id='" + txtbillno.Text + "' group by b.itemname";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dtc = new DataTable();
            try
            {

                string mysql = "select cname,aname,caddress,cvatno,clogo from company where id=1";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

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
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dtcust = new DataTable();
            //MessageBox.Show(custname);
            try
            {

                string mysql = "select * from tbl_accts where name='" + custname + "'";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

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

        private void button3_Click(object sender, EventArgs e)
        {
            frmClear();
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
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
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();


            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            //DateTime mdate = Convert.ToDateTime(trdate, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal + nvat;
            string gnetval = mnetval.ToString();




            DataTable dtcust = GetCustomer(mcust);
            string custname = dtcust.Rows[0]["acctname"].ToString();
            string custadd = dtcust.Rows[0]["caddress"].ToString();
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
            ReportParameter rp16 = new ReportParameter("reptitle", "مرتجع مشتريات");

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\purchaseRepA4.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllpurchase();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            PrintToPrinter1(report);

            frmClear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvaddproduct_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
        }

        private void btnremove_Click_1(object sender, EventArgs e)
        {
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
            //string mdiscount = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();


            //double molddiscount = Convert.ToDouble(mdiscount);
            double olddiscount = double.Parse(txtdiscount.Text);

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);



            double subtotal = oldsubtotal - oldtotal;
            double discount = olddiscount;// - molddiscount;
            double nnetval = subtotal - discount;
            txtsubtotal.Text = subtotal.ToString("#,0.00");
            txtdiscount.Text = discount.ToString("#,0.00");
            txtnetval.Text = nnetval.ToString("#,0.00");

            double vat = nnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = vat.ToString();
            double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = grandtotalwithvat.ToString();
            dgvaddproduct.Rows.RemoveAt(rowIndex);
        }
    }
}
