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
    public partial class frmpurchaseretview : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmpurchaseretview()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
        salesDAL sdal = new salesDAL();
        purchaseDAL purdal = new purchaseDAL();
        public string notmess = "";
        public string confmess = "";
        public string msave = "";
        private void frmpurchase_Load(object sender, EventArgs e)
        {
            DataTable dt = purdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = dt;
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
            // Bills drop down list
            string sqlx = "Select id,dealer from tbl_purchase where trtype='PurchaseReturn'";
            SQLiteConnection connx = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");

            SQLiteCommand cmdx = new SQLiteCommand(sqlx, connx);
            SQLiteDataAdapter dax = new SQLiteDataAdapter(cmdx);
            DataSet dsx = new DataSet();
            dax.Fill(dsx, "purchase");

            cmbbillno.DataSource = dsx.Tables["purchase"];
            cmbbillno.DisplayMember = "id";
            cmbbillno.ValueMember = "id";
            string mcatx = cmbbillno.Text;
            connx.Close();
            //***
            /*
            // Supplier drop down list
            string sql2 = "Select id,name from tbl_accts where type='2'";
            SQLiteConnection conn2 = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            SQLiteCommand cmd = new SQLiteCommand(sql2, conn2);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "customers");
            cmbsupplier.DataSource = ds.Tables["customers"];
            cmbsupplier.DisplayMember = "name";
            cmbsupplier.ValueMember = "name";
            string mcat = cmbsupplier.Text;
            conn2.Close();
        */




        }
        
        
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            /*
            string keywords = txtname.Text;
            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }
            acctsBLL dc = dcdal.searchdealercustomerfortransaction(keywords);

            txtname.Text = dc.name;
            txtvatno.Text = dc.vatno;
            */
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
                        SQLiteConnection conn = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
                        DataTable dt = new DataTable();



                        try
                        {
                            string sql = "Select barcode,name,qty,rate from tbl_products WHERE barcode LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";
                            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
                            conn.Open();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            //    while(dt.Rows.Count>0)
                            {

                                txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["name"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt.Rows[0]["rate"].ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;


                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);
                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString();
                               // this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
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
                                if (MessageBox.Show(notmess, confmess, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                

                default:
                    //MessageBox.Show("Error");
                    break;

            }
        }
        private void TransCalculations()
        {
            dgvaddproduct.Update();
            dgvaddproduct.Refresh();

            double invsubtotal = double.Parse(txtsubtotal.Text);
            double newdiscount = double.Parse(txtdiscount.Text);
            
            
            double mnetval = invsubtotal - newdiscount;
            double nvat = mnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = nvat.ToString();
            txtnetval.Text = mnetval.ToString("0.00");
            
            

            double mygrandtotalwithvat = mnetval+nvat; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"Data Source=Supermarket.db; Version=3");
            con.Open();
            string sql = "update tbl_purchase set trdate=@trdate,description=@description,subtotal=@subtotal,vat=@vat,discount=@discount,gtotal=@gtotal,added_by=@added_by,trtype=@trtype,dealer=@dealer,invno=@invno,invdate=@invdate,returnno=@returnno where id='"+cmbbillno.Text+"'";
            
            SQLiteCommand cmd = new SQLiteCommand(sql, con);
            double msub = double.Parse(txtsubtotal.Text) * -1;
            double mvat = double.Parse(txtvat.Text) * -1;
            double mgrand = double.Parse(txtgrandtotal.Text) * -1;
            double mdisc = double.Parse(txtdiscount.Text) * -1;
            

            cmd.Parameters.AddWithValue("@trdate", DateTime.Parse(dtpicker.Text));
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.Parameters.AddWithValue("@subtotal", msub);
            cmd.Parameters.AddWithValue("@vat", mvat);
            cmd.Parameters.AddWithValue("@discount", mdisc);
            cmd.Parameters.AddWithValue("@gtotal", mgrand);
            cmd.Parameters.AddWithValue("@added_by", frmlogin.loggedin);
            cmd.Parameters.AddWithValue("@trtype", "PurchaseReturn");
            cmd.Parameters.AddWithValue("@dealer", txtname.Text);
            cmd.Parameters.AddWithValue("@invno", txtinvno.Text);
            cmd.Parameters.AddWithValue("@invdate", txtbilldate.Text);
            cmd.Parameters.AddWithValue("@returnno", "");

            cmd.ExecuteNonQuery();
            con.Close();
            /*
                        con.Open();

                        string mysql1 = "select max(id) from tbl_purchase";

                        SQLiteCommand cmd2 = new SQLiteCommand(mysql1, con);
                        var mytr = cmd2.ExecuteScalar();
                        cmbbillno.Text = mytr.ToString();
                        int myid;

                        if (mytr != null)
                        {
                            myid = Convert.ToInt32(mytr);
                        }

                        else
                        {
                            myid = 0;
                        }


                        con.Close();
            */
            // Delete old details
            con.Open();
            DataTable trdt = purdal.GetInvoiceDetails(cmbbillno.Text);
            for(int i=0; i < trdt.Rows.Count - 1; i++)
            {
                if ((string)trdt.Rows[i][1] == null)
                {
                    break;
                }
                else
                {
                    string itname = trdt.Rows[i][1].ToString();
                    productsBLL itpid = pdal.getproductidfromname(itname);
                    int MyPid = itpid.id;
                    
                    var pqty = trdt.Rows[i][2].ToString();

                    decimal Mpqty = Convert.ToDecimal(pqty);
                    //MessageBox.Show("Product id   " + MyPid);
                    decimal Qty_hand = pdal.GetProductQty(MyPid);
                    //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                    //*************************Update inventory values ***********



                    bool x = false;

                    x = pdal.DecreaseProduct(MyPid, Mpqty, Qty_hand);


                }
            }
            con.Close();
            string sql2 = "delete from tbl_purchaseitems where trid='" + cmbbillno.Text + "'";
            con.Open();
            SQLiteCommand cmd2 = new SQLiteCommand(sql2, con);
            cmd2.ExecuteNonQuery();
            con.Close();
            int mytr = int.Parse(cmbbillno.Text);
            


            for (int i = 0; i < dgvaddproduct.Rows.Count - 1; i++)
            {


                if ((String)dgvaddproduct.Rows[i].Cells[1].Value == null)
                {
                    break;
                }
                else
                {
                    con.Open();
                    string mpname = dgvaddproduct.Rows[i].Cells[1].Value.ToString();
                    productsBLL mypid = pdal.getproductidfromname(mpname);
                    int mproductid = mypid.id;
                    string msql = "insert into tbl_purchaseitems(trid,barcode,itemname,itemprice,itemqty,itemtotal,discount,gtotal) VALUES(@trid,@barcode,@itemname,@itemprice,@itemqty,@itemtotal,@discount,@gtotal)";
                    SQLiteCommand cmd1 = new SQLiteCommand(msql, con);
                    cmd1.Parameters.AddWithValue("@trid", mytr);
                    //cmd1.Parameters.AddWithValue("@productid", );
                    cmd1.Parameters.AddWithValue("@barcode", dgvaddproduct.Rows[i].Cells[0].Value);
                    cmd1.Parameters.AddWithValue("@itemname", dgvaddproduct.Rows[i].Cells[1].Value);

                    cmd1.Parameters.AddWithValue("@itemprice", dgvaddproduct.Rows[i].Cells[3].Value);
                    cmd1.Parameters.AddWithValue("@itemqty", dgvaddproduct.Rows[i].Cells[2].Value);
                    cmd1.Parameters.AddWithValue("@itemtotal", dgvaddproduct.Rows[i].Cells[4].Value);
                    cmd1.Parameters.AddWithValue("@discount", "0.00");
                    cmd1.Parameters.AddWithValue("@gtotal", "0.00");

                    cmd1.ExecuteNonQuery();

                    //var mproductid = dgvaddproduct.Rows[i].Cells[0].Value;
                    var mmprice = dgvaddproduct.Rows[i].Cells[3].Value;
                    decimal pprice = Convert.ToDecimal(mmprice);
                    int MyPid = Convert.ToInt32(mproductid);
                    var pqty = dgvaddproduct.Rows[i].Cells[2].Value;
                    // var mrate = dgvaddproduct.Rows[i].Cells[3].Value;
                    // decimal rate = Convert.ToDecimal(mrate);
                    decimal Mpqty = Convert.ToDecimal(pqty);
                    //MessageBox.Show("Product id   " + MyPid);
                    decimal Qty_hand = pdal.GetProductQty(MyPid);
                    //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                    //*************************Update inventory values ***********



                    bool x = false;

                    x = pdal.IncreaseProdcuct2(MyPid, Mpqty, Qty_hand,pprice);


                    con.Close();
                }
            }
            con.Open();
            string sql3 = "update tbl_accttr set trdate=@trdate,trno=@trno,trtype=@trtype,payacct=@payacct,acctname=@acctname,description=@description,dbval=@dbval,crval=@crval where trno='"+cmbbillno.Text+"'";
            SQLiteCommand cmd3 = new SQLiteCommand(sql3, con);
            cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
            cmd3.Parameters.AddWithValue("@trno", cmbbillno.Text);
            cmd3.Parameters.AddWithValue("@trtype", "Purchase");
            cmd3.Parameters.AddWithValue("@payacct", cmbtype.Text);
            cmd3.Parameters.AddWithValue("@acctname", txtname.Text);
            cmd3.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd3.Parameters.AddWithValue("@dbval", "0");
            cmd3.Parameters.AddWithValue("@crval", txtgrandtotal.Text);

            cmd3.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msave);
            btnprntA4.Enabled = true;
            btnprnt.Enabled = true;

            /*
                        prntpreview.Document = prntdoc;
                        prntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
                        prntpreview.ShowDialog();
            */
            

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

        private void btnremove_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
            string mdiscount = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();


            double molddiscount = Convert.ToDouble(mdiscount);
            double olddiscount = double.Parse(txtdiscount.Text);

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);



            double subtotal = oldsubtotal - oldtotal;
            double discount = olddiscount - molddiscount;
            double nnetval = subtotal - discount;
            txtsubtotal.Text = subtotal.ToString("{0:#,0.00}");
            txtdiscount.Text = discount.ToString("{0:#,0.00}");
            txtnetval.Text = nnetval.ToString("{0:#,0.00}");

            double vat = nnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = vat.ToString();
            double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = grandtotalwithvat.ToString();
            dgvaddproduct.Rows.RemoveAt(rowIndex);

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

        private void button3_Click(object sender, EventArgs e)
        {
            frmClear();
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
            
            frmClear();



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



        

        private void dgvaddproduct_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            /*
            this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[7].Value = 0;
            */
            if (columnIndex == 5)
            {
                txtolddiscount.Text = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
            }
        }

        private void dgvaddproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
        }
        /*
        private void cmbsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = cmbsupplier.Text;
            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }
            acctsBLL dc = dcdal.searchdealercustomerfortransaction(keywords);

            cmbsupplier.Text = dc.name;
            txtvatno.Text = dc.vatno;
            

        }
        */
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
            double oldgtotal = double.Parse(txtsubtotal.Text);
            double mdiscount= double.Parse(txtdiscount.Text);
            double newnetval = oldgtotal - mdiscount;
            txtnetval.Text = newnetval.ToString("0.00");
            TransCalculations();
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            frmpurchaseview frm = new frmpurchaseview();
            frm.Show();
        }

        private void dtpbilldate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbbillno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = cmbbillno.Text;
            if (keywords == "")
            {

                //  txtname.Text = "";
                //txtvatno.Text = "";

                return;


            }
            purchaseBLL sc = purdal.GetInvoiceID(keywords);
            cmbbillno.Text = sc.id.ToString();
            DataTable dts = purdal.GetInvoicePurchase(keywords);
            purchaseBLL rt = purdal.GetPurID(cmbbillno.Text);
            txtreturnno.Text = rt.id.ToString();
               
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
                //txtreturnno.Text = dts.Rows[0]["returnno"].ToString();
                txtnetval.Text = (double.Parse(dts.Rows[0]["subtotal"].ToString()) - double.Parse(dts.Rows[0]["discount"].ToString())).ToString();
                acctsBLL cdal = dcdal.searchdealercustomerfortransaction(txtname.Text);
                txtvatno.Text = cdal.vatno;



            }

            DataTable sdat = purdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = sdat;
            

        }
    }
}
