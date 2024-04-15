using DGVPrinterHelper;
using Microsoft.Reporting.WinForms;
using QRCoder;
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
    public partial class frmreturn : Form
    {
        // private PictureBox pic;

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmreturn()
        {
            InitializeComponent();
        }
        public string msave = "";

        System.Threading.Thread t = System.Threading.Thread.CurrentThread;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();

        salesDAL sdal = new salesDAL();
        TextBox txtolddiscount = new TextBox();
        TextBox txtpart = new TextBox();
        transactionBLL transaction = new transactionBLL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();
        transactiondetailBLL transactionDetail = new transactiondetailBLL();
        TextBox paymethod = new TextBox();
        public string mtrtype = "";
        public string sessid = "";
        public string custcode = "";
        public string txtid = "";


        private void frmsales_Load(object sender, EventArgs e)
        {
            DataTable dt = sdal.GetInvoiceDetails(txtbillno.Text);
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
                msave = "Return Succssfull...";
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


            /*
            DataGridViewButtonColumn bcol = new DataGridViewButtonColumn();
            bcol.HeaderText = "حذف ";
            bcol.Text = "X";
            bcol.Name = "btnRemove";
            

            bcol.UseColumnTextForButtonValue = true;
            dgvaddproduct.Columns.Add(bcol);
            */

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
            


            // Bills drop down list
            string sql2 = "Select id,customer from tbl_sales where trtype=@trtype";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);
            cmd.Parameters.AddWithValue("@trtype", "1");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sales");

            //cmbbillno.DataSource = ds.Tables["sales"];
           // cmbbillno.DisplayMember = "id";
           // cmbbillno.ValueMember = "id";
            string mcat = txtbillno.Text;
            conn2.Close();
            //***



        }


        private void dgvaddproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = cmpdal.Select();
            string cyvat = dt.Rows[0]["vatval"].ToString();
            double myvat = double.Parse(cyvat) / 100;
            if (e.ColumnIndex == 8)
            {
                MessageBox.Show("Delete");

                int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
                string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells["total"].Value.ToString();

                double oldsubtotal = double.Parse(txtsubtotal.Text);
                double oldtotal = Convert.ToDouble(mtotal);

                double subtotal = oldsubtotal - oldtotal;

                txtsubtotal.Text = subtotal.ToString();
                double vat = subtotal * myvat;  // ((100+15)/100)*subtotal;
                txtvat.Text = vat.ToString();
                double grandtotalwithvat = vat + subtotal; //((100 + 15) / 100) * prevgrand;
                txtgrandtotal.Text = grandtotalwithvat.ToString();
                dgvaddproduct.Rows.RemoveAt(rowIndex);
            }
        }

        
        private void dgvaddproduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            /*
            this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[7].Value = 0;
            */
            //txtolddiscount.Text = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();


        }
        private void dgvaddproduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            
            DataTable dtc = cmpdal.Select();
            string cyvat = dtc.Rows[0]["vatval"].ToString();
            double myvat = double.Parse(cyvat) / 100;



            switch (e.ColumnIndex)
            {
                case 0:
                    /*
                    string keywords = (Convert.ToString(dgvaddproduct.CurrentCell.Value));
                    if (keywords == "")
                    {

                        //  txtname.Text = "";
                        //string munit = dgvaddproduct.Rows[0].Cells[2].ToString();

                        return;

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
                            string sql = "Select barcode,name,qty,rate from tbl_products WHERE barcode LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            conn.Open();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            //    while(dt.Rows.Count>0)
                            {

                                txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["name"].ToString();
                                
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[3].Value = dt.Rows[0]["rate"].ToString();


                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);
                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;

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


                    */
                    break;
                    
                case 3:
                    break;
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
                    /*
                    string mytotal1 = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
                    string mydiscount = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();




                    double mntotal = Convert.ToDouble(mytotal1);
                    double ndiscount = Convert.ToDouble(mydiscount);
                    double mgtotal = mntotal - ndiscount;
                    this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = mgtotal.ToString();
                    //double noldsubtotal = double.Parse(txtsubtotal.Text);
                    double newsubtotal = double.Parse(txtsubtotal.Text);
                    double oldnetdiscount = double.Parse(txtolddiscount.Text);
                    double olddiscount2 = double.Parse(txtdiscount.Text);
                    double newdiscount = ndiscount + olddiscount2 - oldnetdiscount;
                    txtdiscount.Text = newdiscount.ToString();
                    double newnetval = newsubtotal - newdiscount;
                    txtnetval.Text = newnetval.ToString();

                    dgvaddproduct.Update();
                    dgvaddproduct.Refresh();
                    TransCalculations();




                    */

                    break;








                //-------------


                default:
                    //MessageBox.Show("Error");
                    break;
            }




        }
        /*
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {

            double newdiscount2 = double.Parse(txtdiscount.Text);
            double nsub = double.Parse(txtsubtotal.Text);
            double nnetval = nsub - newdiscount2;
            txtnetval.Text = nnetval.ToString();
            TransCalculations();


        }
        */
        private void TransCalculations()
        {
            DataTable dtc = cmpdal.Select();
            string cyvat = dtc.Rows[0]["vatval"].ToString();
            double myvat = double.Parse(cyvat) / 100;
            dgvaddproduct.Update();
            dgvaddproduct.Refresh();

            double invnetval = double.Parse(txtnetval.Text);
            double nvat = invnetval * myvat;  // ((100+15)/100)*subtotal;
            txtvat.Text = nvat.ToString();
            double mygrandtotalwithvat = nvat + invnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString();

        }


        private void btnremove_Click(object sender, EventArgs e)
        {
            DataTable dtc = cmpdal.Select();
            string cyvat = dtc.Rows[0]["vatval"].ToString();
            double myvat = double.Parse(cyvat) / 100;
            //double molddiscount = 0;
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
            //string mdiscount = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();


            //double molddiscount = Convert.ToDouble(mdiscount);
            double olddiscount = double.Parse(txtdiscount.Text);

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);



            double subtotal = oldsubtotal - oldtotal;
            double discount = olddiscount;// - molddiscount;
            double nnetval = subtotal - discount;
            txtsubtotal.Text = subtotal.ToString();
            txtdiscount.Text = discount.ToString();
            txtnetval.Text = nnetval.ToString();
            

            double vat = nnetval * myvat;  // ((100+15)/100)*subtotal;
            txtvat.Text = vat.ToString();
            double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = grandtotalwithvat.ToString();

            if (cmbtype.Text == "1")
            {
                txtcash.Text = txtgrandtotal.Text;
            }
            else if (cmbtype.Text == "2")
            {
                txtcard.Text = txtgrandtotal.Text;
            }
            else if (cmbtype.Text == "4")
            {
                txtcredit.Text = txtgrandtotal.Text;
            }
            else
            {
                txtcash.Text = txtgrandtotal.Text;
            }
            dgvaddproduct.Rows.RemoveAt(rowIndex);







        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            ReturnSave();
        }
        private void ReturnSave()
        { 

            SqlConnection con = new SqlConnection(myconnstrng);
                      

            
            //Get Transaction Data Values
            transaction.paycard = decimal.Parse(txtcard.Text)*-1;
            transaction.paycredit = decimal.Parse(txtcredit.Text)*-1;
            transaction.paycash = decimal.Parse(txtcash.Text)*-1;
            transaction.subtotal = decimal.Parse(txtsubtotal.Text)*-1;
            transaction.vat = decimal.Parse(txtvat.Text)*-1;
            transaction.discount = decimal.Parse(txtdiscount.Text)*-1;
            transaction.grandtotal = decimal.Parse(txtgrandtotal.Text)*-1;
            transaction.acctcode = custcode;
            transaction.customer = txtname.Text;
            transaction.sessionid = int.Parse(sessid);
            transaction.trdate = DateTime.Now;
            transaction.description = "مرتجع الفاتورة رقم: " + txtbillno.ToString(); 
            transaction.branch = txtbranch.Text;
            transaction.paymethod = paymethod.Text;
            transaction.returned = 0;
            transaction.trtype = "2";
            transaction.returnno = 0;
            transaction.paid = decimal.Parse(txtpaid.Text);
            transaction.added_by = frmlogin.loggedin;
            transaction.invno = int.Parse(txtbillno.Text);

            //DataTable detailsDT = sdal.GetTempDetails(int.Parse(txtid.Text));
            //DataTable detailsDT = new DataTable();

            //transaction.transactionDetails = detailsDT;

            bool Issuccess = false;
            using (TransactionScope scope = new TransactionScope())
            {
               
                int transactionID = -1;
                bool w = tDAL.insertReturnTransaction(transaction, out transactionID);
                //MessageBox.Show("Sales OK");
                txtid = transactionID.ToString();
                
                

                //for details
                for (int i = 0; i < dgvaddproduct.Rows.Count - 1; i++)
                {
                    
                    string pcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                    productsBLL mypid = pdal.getproductidfromname(pcode);
                    int mproductid = mypid.id;
                    decimal mcost = mypid.costprice;
                    decimal qtyhand = mypid.qty;
                    decimal mbal = qtyhand - decimal.Parse(dgvaddproduct.Rows[i].Cells[2].Value.ToString());
                    

                    transactionDetail.trid = transactionID;
                    transactionDetail.barcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                    transactionDetail.productname = dgvaddproduct.Rows[i].Cells[1].Value.ToString();
                    transactionDetail.productid = mproductid;
                    transactionDetail.costprice = mcost;
                    transactionDetail.qty = decimal.Parse(dgvaddproduct.Rows[i].Cells[2].Value.ToString())*-1;
                    transactionDetail.rate = decimal.Parse(dgvaddproduct.Rows[i].Cells[3].Value.ToString())*-1;
                    transactionDetail.total = decimal.Parse(dgvaddproduct.Rows[i].Cells[4].Value.ToString())*-1;
                    transactionDetail.balance = mbal;

                    //MessageBox.Show("start details");
                    //insert details
                    bool xy = tdDAL.insertTransactionDetail(transactionDetail);
                    //MessageBox.Show("details ok");
                    Issuccess = w && xy;

                    


                }

                if (Issuccess == true)
                {
                    scope.Complete();
                    // Update Return number
                    
                    

                    MessageBox.Show("تم الحفظ....");



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



        private void button1_Click(object sender, EventArgs e)
        {


            frmClear();
        }
        public void frmClear()
        {
            this.Close();
            frmreturn main = new frmreturn();
            main.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void frmsales_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            frmClear();
        }


        private void btnprnt_Click(object sender, EventArgs e)
        {
            int trid = int.Parse(txtid);

            DataTable companyDT = cmpdal.Select();
            // MessageBox.Show(companyDT.Rows.Count.ToString());

            if (companyDT.Rows.Count == 0)
            {
                MessageBox.Show("بيانات الشركة غير مكتملة...");
                return;
            }
            string compname = companyDT.Rows[0]["cname"].ToString();
            string caddress = companyDT.Rows[0]["caddress"].ToString();
            string arname = companyDT.Rows[0]["aname"].ToString();
            string cvatno = companyDT.Rows[0]["cvatno"].ToString();
            string clogo = companyDT.Rows[0]["clogo"].ToString();
            //printordersOk = dtc.Rows[0]["printorder"].ToString();
            string isvatincluded = companyDT.Rows[0]["vatincluded"].ToString();
            string noofcopies = companyDT.Rows[0]["printqty"].ToString();
            string txtpvat = "";
            /*
            if(isvatincluded=="1")
            {
                txtpvat = "**الأسعار شاملة لضريبة القيمة المضافة";

            }
            */
            string cvatno2 = "الرقم الضريبي:   " + cvatno;
            string reptitle = "اشعار خصم- مرتجع";



            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);



            String Seller = arname;
            String VatNo = cvatno;
            DateTime dTime = transaction.trdate;
            Double Total = Convert.ToDouble(transaction.grandtotal);
            Double Tax = Convert.ToDouble(transaction.vat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();

            Bitmap qrCodeImage = tlv.toQrCode();
            qrCodeImage.Save("Q1.bmp");



            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");



            ReportParameter rp1 = new ReportParameter("cname", compname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);

            ReportParameter rp3 = new ReportParameter("customer", transaction.customer);
            ReportParameter rp4 = new ReportParameter("maddress", caddress);
            ReportParameter rp5 = new ReportParameter("tableno", "");
            ReportParameter rp6 = new ReportParameter("description", transaction.description);
            ReportParameter rp7 = new ReportParameter("invdate", transaction.trdate.ToString());
            ReportParameter rp8 = new ReportParameter("invno", txtid);
            ReportParameter rp9 = new ReportParameter("payment", transaction.paymethod);
            ReportParameter rp10 = new ReportParameter("seller", frmlogin.loggedin);

            ReportParameter rp11 = new ReportParameter();
            rp11.Name = "qrcode";
            rp11.Values.Add(@"file:///" + imgpath);
            ReportParameter rp12 = new ReportParameter();
            rp12.Name = "logo";
            rp12.Values.Add(@"file:///" + clogo);

            ReportParameter rp13 = new ReportParameter("psubtotal", transaction.subtotal.ToString());
            ReportParameter rp14 = new ReportParameter("pdiscount", transaction.discount.ToString());
            ReportParameter rp15 = new ReportParameter("pnet", (transaction.subtotal - transaction.discount).ToString());
            ReportParameter rp16 = new ReportParameter("pvat", transaction.vat.ToString());
            ReportParameter rp17 = new ReportParameter("pgtotal", transaction.grandtotal.ToString());
            ReportParameter rp18 = new ReportParameter("arabicname", arname);
            ReportParameter rp19 = new ReportParameter("orderno", "");
            ReportParameter rp20 = new ReportParameter("pricevat", txtpvat);
            ReportParameter rp21 = new ReportParameter("reptitle", reptitle);
            ReportParameter rp22 = new ReportParameter("pvat1", "");
            ReportParameter rp23 = new ReportParameter("pcash", txtcash.Text);
            ReportParameter rp24 = new ReportParameter("pcard", txtcard.Text);


            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);

            string exeFolder = Application.StartupPath;

            //string fullpath = Path.Combine(path, @"\smallInv.rdlc");
            //string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\smallInv.rdlc";
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\smallInv.rdlc";


            report.ReportPath = fullpath;

            int printQty = Convert.ToInt32(noofcopies);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18, rp19, rp20, rp21, rp22, rp23, rp24 });
            //this.report.RefreshReport();
            DataTable dt = sdal.DisplayAllsales(txtid);


            report.DataSources.Add(new ReportDataSource("DataSet2", dt));
            //report.DataSource = dt;

            for (int i = 0; i < printQty; i++)
            {
                PrintToPrinter1(report);
            }

            this.Close();
            frmClear();



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
            DisposePrint();

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

            if ((m_streams != null))
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;

            }


        }

    

    private void txtbillno_Validated(object sender, EventArgs e)
        {
            string keywords = txtbillno.Text;
            if (string.IsNullOrEmpty(keywords))
            {

                //  txtname.Text = "";
                //txtvatno.Text = "";

                return;


            }
            salesBLL rc = sdal.GetReturnNo(keywords);
            if (rc.returnno != 0)
            {
                MessageBox.Show("تم اجراء المرتجع...");
                return;
            }
            //salesBLL sc = sdal.GetInvoiceID(keywords);
            //txtbillno.Text = sc.id.ToString();
            DataTable dts = sdal.GetInvoiceSales(keywords);
            if (dts.Rows.Count > 0)
            {

                string mdate = dts.Rows[0]["trdate"].ToString();
                txtinvdate.Text = mdate.ToString();
                txtdescription.Text = dts.Rows[0]["description"].ToString();
                txtbranch.Text = dts.Rows[0]["branch"].ToString();
                txtsubtotal.Text = dts.Rows[0]["subtotal"].ToString();
                txtvat.Text = dts.Rows[0]["vat"].ToString();
                txtdiscount.Text = dts.Rows[0]["discount"].ToString();
                txtgrandtotal.Text = dts.Rows[0]["grandtotal"].ToString();
                paymethod.Text = dts.Rows[0]["paymethod"].ToString();
                txtpaid.Text = dts.Rows[0]["paid"].ToString();
                txtreturn.Text = dts.Rows[0]["returned"].ToString();
                txtuser.Text = dts.Rows[0]["added_by"].ToString();
                cmbtype.Text = dts.Rows[0]["trtype"].ToString();
                txtname.Text = dts.Rows[0]["customer"].ToString();
                mtrtype= dts.Rows[0]["trtype"].ToString();
                sessid=dts.Rows[0]["sessionid"].ToString();
                custcode= dts.Rows[0]["acctcode"].ToString();
                txtcard.Text= dts.Rows[0]["paycard"].ToString();
                txtcash.Text = dts.Rows[0]["paycash"].ToString();
                txtcredit.Text = dts.Rows[0]["paycredit"].ToString();
                acctsBLL cdat= dcdal.searchdealercustomerfortransaction(txtname.Text);
                txtvatno.Text = cdat.vatno;

            }

            DataTable sdat = sdal.GetInvoiceDetails(txtbillno.Text);
            dgvaddproduct.DataSource = sdat;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmsalesview frm = new frmsalesview();
            frm.Show();
        }

        private void txtbillno_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvaddproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
        }

        private void dgvaddproduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}





