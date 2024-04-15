using DGVPrinterHelper;

using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Microsoft.Reporting.WinForms;
using System.Globalization;
using System.Configuration;

namespace Supermarket.UI
{

    public partial class frmsales : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        // private PictureBox pic;

        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public frmsales()
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
        public string msave = "تأكيد";
        public string sess = "لا توجد جلسة مفتوحة";
        string keywords = "";
        TextBox suppacct = new TextBox();
        TextBox txtcaddress = new TextBox();
        TextBox txtolddiscount = new TextBox();
        TextBox txtbranch = new TextBox();
        TextBox txtstore = new TextBox();
        TextBox txtuser = new TextBox();
        TextBox txtbillno = new TextBox();
        TextBox txtcash = new TextBox();
        TextBox txtcard = new TextBox();
        TextBox txtcredit = new TextBox();
        TextBox txtpaid = new TextBox();
        public string isavt = "";
      
        public string vatinclude = "";
        public string vatamount = "";




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
        sessionDAL ssdal = new sessionDAL();
        transactionBLL transaction = new transactionBLL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();
        transactiondetailBLL transactionDetail = new transactiondetailBLL();
        TextBox txttrid = new TextBox();
        sessionDAL sessDAL = new sessionDAL();
        // opentableBLL c = new opentableBLL();
        salesDAL sdal = new salesDAL();
        DataTable tvat = new DataTable();
        public int sessionid;

        


        public double myvat = 0;
        TextBox muser = new TextBox();
        






        private void frmsales_Load(object sender, EventArgs e)
        {
            MessageBox.Show("start");
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                madd = "";
                fadd = "";
                mupdate = "";
                fupdate = "";
                mdelete = "";
                fdelete = "";
                mmseg = "الصنف غير موجود...اضافة";
                mconf = "تأكيد";
                msave = "تم الحفظ بنجاح!";
                sess = "لا توجد وردية مفتوحة";
            }
            else
            {
                madd = "";
                fadd = "";
                mupdate = "";
                fupdate = "";
                mdelete = "";
                fdelete = "";
                mmseg = "Product Not Exist...Add?";
                mconf = "Confirm";
                msave = "Saved Succesfully...";
                sess = "No open Sessio";

            }
            
            DataTable sdt = new DataTable();
            sdt = ssdal.Getsessions();
            if (sdt.Rows.Count > 0)
            {
                MessageBox.Show(sdt.Rows[0]["id"].ToString());
                string mysessionid = sdt.Rows[0]["id"].ToString();
                sessionid = int.Parse(mysessionid);
                label17.Text = mysessionid;
                label16.Text = sdt.Rows[0]["sessionuser"].ToString();



            }
            else
            {
                MessageBox.Show(sess);

                this.Hide();
            }
            
            


            DataTable dt = cmpdal.Select();
            txtbranch.Text = dt.Rows[0]["branch"].ToString();
            txtstore.Text = dt.Rows[0]["store"].ToString();
            txtuser.Text = frmlogin.loggedin;
            string cyvat = dt.Rows[0]["vatval"].ToString();
            string isvatincluded = dt.Rows[0]["vatincluded"].ToString();
            string isustdisplay = dt.Rows[0]["custdisplay"].ToString();


            myvat = double.Parse(cyvat)*0.01;
            
            txtbillno.Text = salesDAL.DisplayMaxSalesID();
            this.ActiveControl = dgvaddproduct;




            for (int i = 0; i < 5; i++)
            {
                AddAColumn(i);
            }
            //dgvaddproduct.RowHeadersDefaultCellStyle.Padding = new Padding(3);//helps to get rid of the selection triangle?
            /*
            for (int i = 0; i < 12; i++)
            {
                AddARow(i);
            }
            */


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
           

            

            txtsubtotal.Text = subtotal.ToString();
            

           

            // Customers drop down list
            string sql2 = "Select acctcode,acctname from tbl_accts where mainacct=2";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);


            
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
           
            da.Fill(ds, "customers");
            
            cmbcustomers.DisplayMember = "acctname";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbcustomers.ValueMember = "acctcode";
            cmbcustomers.DataSource = ds.Tables["customers"];
            
            conn2.Close();
            //***
        }
        private void AddARow(int i)
        {
            DataGridViewRow Arow = new DataGridViewRow();
            Arow.HeaderCell.Value = i.ToString();
            Arow.Height = 25;
            if (i % 2 == 0)
            {
                Arow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#eae2fa");
            }
            else
            {
                Arow.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#efefef");
            }

            dgvaddproduct.Rows.Add(Arow);
        }

        private void AddAColumn(int i)
        {
            DataGridViewTextBoxColumn Acolumn = new DataGridViewTextBoxColumn();
            //OK I know this only works normally for 26 chars(columns)
            // I leave the rest of the Excel columns up to you to figure out :o)
            //var ch = { };
            if (t.CurrentCulture.Name == "ar-EG")
            {
                var ch = new string[5] { "الرمز", "الصنف", "الكمية", "السعر",  "الاجمالي" };
                Acolumn.HeaderText = ch[i].ToString();
            }
            else
            {
                var ch = new string[5] { "Barcode","Product", "Qty", "Price","Total" };
                Acolumn.HeaderText = ch[i].ToString();
            }
            
            
            Acolumn.Name = "Column" + i.ToString();
            Acolumn.Width = 60;
            Acolumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            //make a Style template to be used in the grid
            DataGridViewCell Acell = new DataGridViewTextBoxCell();
            //Acell.Style.BackColor = Color.LightCyan;
            //Acell.Style.SelectionBackColor = Color.FromArgb(128, 255, 255);
            Acell.Style.Font = new Font("Calibri", 12);
            Acolumn.CellTemplate = Acell;
            dgvaddproduct.Columns.Add(Acolumn);
        }

        private void dgvaddproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = cmpdal.Select();
            string cyvat = dt.Rows[0]["vatval"].ToString();
            myvat = double.Parse(cyvat) / 100;
            btnremove.Enabled = true;
            if (e.ColumnIndex == 7)
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
            
            if(columnIndex==5)
            {
                txtolddiscount.Text = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
            }
            //  
            

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

                        //  txtname.Text = "";
                        //string munit = dgvaddproduct.Rows[0].Cells[2].ToString();

                        return;

                    }
                    else
                    {
                        int currentRow = dgvaddproduct.CurrentCell.RowIndex;
                        
                        //if (currentRow > 0)
                        //{
                           // string myoldbarvalue = this.dgvaddproduct.Rows[currentRow - 1].Cells[0].Value.ToString();
                            //string myoldqtyval = this.dgvaddproduct.Rows[currentRow - 1].Cells[2].Value.ToString();
                            //decimal myoldqty = decimal.Parse(myoldqtyval);
                          
                        //}
                    

                        //productsBLL dc = pdal.GetproductForTransaction(keywords);
                        //MessageBox.Show(dc.name);
                        // Get the DAL function Here
                        productsBLL dc= new productsBLL();
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
                                string prod_barcode = dt.Rows[0]["barcode"].ToString();
                                string productname = dt.Rows[0]["name"].ToString();
                                double qty = 1;
                                double rate =double.Parse(dt.Rows[0]["rate"].ToString());
                                double total = qty*rate;

                                /*
                                //search begin
                                // Search DataGrid for product_id
                                
                                if (dgvaddproduct.Rows.Count > 0)
                                {


                                    bool found = false;


                                    foreach (DataGridViewRow row in dgvaddproduct.Rows)
                                    {
                                        //int currentRow = dgvaddproduct.CurrentCell.RowIndex;

                                        if (Convert.ToString(row.Cells[0].Value) == prod_barcode) // && Convert.ToString(row.Cells[3].Value)==rate.ToString())
                                        {

                                            row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[2].Value));

                                            found = true;
                                            double nrate = double.Parse(row.Cells[3].Value.ToString());
                                            double nqty = double.Parse(row.Cells[2].Value.ToString());
                                            double goldtotal= double.Parse(row.Cells[4].Value.ToString());
                                            double ntotal = nrate * nqty;
                                            row.Cells[4].Value = ntotal.ToString("0.00");
                                            //this.dgvaddproduct.Rows[currentRow].Cells[4].Value = ntotal.ToString("0.00");
                                            double oldmdiscount = double.Parse(txtdiscount.Text);
                                            double dsubtotal = double.Parse(txtsubtotal.Text);
                                            double nsubtotal = ntotal + dsubtotal-goldtotal;
                                            double newnet = nsubtotal - oldmdiscount;
                                            //dgvaddproduct.Update();
                                            //dgvaddproduct.Refresh();
                                            txtsubtotal.Text = nsubtotal.ToString("0.00");
                                            txtnetval.Text = newnet.ToString("0.00");
                                            
                                        }
                                        dgvaddproduct.CurrentCell = dgvaddproduct.Rows[rowIndex].Cells[0];
                                       // dgvaddproduct.BeginEdit(true);
                                    }
                                    
                                    if (!found)
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

                                        this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString("0.00");
                                        //this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                        //this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;

                                        double oldmdiscount = double.Parse(txtdiscount.Text);
                                        double dsubtotal = double.Parse(txtsubtotal.Text);
                                        double nsubtotal = ntotal + dsubtotal;
                                        double newnet = nsubtotal;// - oldmdiscount;
                                        dgvaddproduct.Update();
                                        dgvaddproduct.Refresh();
                                        txtsubtotal.Text = nsubtotal.ToString("0.00");
                                        txtnetval.Text = newnet.ToString("0.00");
                                        



                                    }
                                    
                                    TransCalculations();

                                }

                                    //search end
                                    */
                            
                                //txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["name"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt.Rows[0]["rate"].ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;


                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);

                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString("0.00");
                              //  this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                               // this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;

                                double oldmdiscount = double.Parse(txtdiscount.Text);
                                double dsubtotal = double.Parse(txtsubtotal.Text);
                                double nsubtotal = ntotal + dsubtotal;
                                double newnet = nsubtotal - oldmdiscount;
                                dgvaddproduct.Update();
                                dgvaddproduct.Refresh();
                                txtsubtotal.Text = nsubtotal.ToString("0.00");
                                txtnetval.Text= newnet.ToString("0.00");
                                TransCalculations();
                                
                                
                                
                            }
                            else
                            {
                                if (MessageBox.Show(mmseg, mconf, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                case 2: case 3:
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
                    double newnetval1 = newsubtotal1;// - oldmydiscount;
                    dgvaddproduct.Update();
                    dgvaddproduct.Refresh();
                    txtsubtotal.Text = newsubtotal1.ToString("0.00");
                    txtnetval.Text = newnetval1.ToString("0.00");
                    TransCalculations();
                    //-------------
                    /*
                    double vat = subtotal * 0.15;  // ((100+15)/100)*subtotal;
                    txtvat.Text = vat.ToString();
                    double grandtotalwithvat = vat + subtotal; //((100 + 15) / 100) * prevgrand;
                    txtgrandtotal.Text = grandtotalwithvat.ToString();
                    */
                    break;
              
                    //-------------
                    

                default:
                    //MessageBox.Show("Error");
                    break;
            }
            
            
            
            
        }
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            
            double newdiscount2 = double.Parse(txtdiscount.Text);
            double nsub = double.Parse(txtsubtotal.Text);
            double nnetval = nsub - newdiscount2;
            txtnetval.Text = nnetval.ToString("0.00");
            TransCalculations();


        }
        private void TransCalculations()
        {
            DataTable dt = cmpdal.Select();
            string cyvat = dt.Rows[0]["vatval"].ToString();
            int isvatincluded =int.Parse(dt.Rows[0]["vatincluded"].ToString());
            myvat = double.Parse(cyvat) / 100;
            double invnetval = double.Parse(txtnetval.Text);
            
            if (isvatincluded == 1)
            {
                double mnetval = invnetval / (1 + myvat);

                double vat = invnetval - mnetval;
                
                lblsubtotal.Text = "الاجمالي شامل الضريبة";
                label12.Text = "المبلغ خاضع للضريبة";

                txtsubtotal.Text = invnetval.ToString("0.00");
                txtvat.Text = vat.ToString("0.00");
                txtnetval.Text = mnetval.ToString("0.00");
                txtgrandtotal.Text = invnetval.ToString("0.00");

            }
            else
            {
                double vat = invnetval * myvat;
                //mnetval = subtotal + vat;
                double grandtotalwithvat = invnetval + vat;
                //txtsubtotal.Text = subtotal.ToString("0.00");
                txtvat.Text = vat.ToString("0.00");
                //txtnetval.Text = enetval.ToString("0.00");
                txtgrandtotal.Text = grandtotalwithvat.ToString("0.00");
            }

        }


        private void btnremove_Click(object sender, EventArgs e)
        {
            //double molddiscount = 0;
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
           

                
                double discount = double.Parse(txtdiscount.Text);

                double oldsubtotal = double.Parse(txtsubtotal.Text);
                double oldtotal = Convert.ToDouble(mtotal);



                double subtotal = oldsubtotal - oldtotal;
                
                double nnetval = subtotal - discount;
                txtsubtotal.Text = subtotal.ToString("0.00");
                txtdiscount.Text = discount.ToString("0.00");
                txtnetval.Text = nnetval.ToString("0.00");

                double vat = nnetval * myvat;  // ((100+15)/100)*subtotal;
                txtvat.Text = vat.ToString();
                double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
                txtgrandtotal.Text = grandtotalwithvat.ToString("0.00");
                dgvaddproduct.Rows.RemoveAt(rowIndex);
            

            


            

        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            CreateInvoice();
        }

        
        public void CreateInvoice()
        {
            if (txtpaymethod.Text == "4")
            {
                txtcredit.Text = txtgrandtotal.Text;
                txtcard.Text = "0";
                txtcash.Text = "0";
                txtpaid.Text = "0";

            }else 
            {
                txtcredit.Text = "0";
                txtpaid.Text = "1";
            }

            //Get Transaction Data Values
            transaction.paycard = decimal.Parse(txtcard.Text);
            transaction.paycredit = decimal.Parse(txtcredit.Text);
            transaction.paycash = decimal.Parse(txtcash.Text);
            transaction.subtotal = decimal.Parse(txtsubtotal.Text);
            transaction.vat = decimal.Parse(txtvat.Text);
            transaction.discount = decimal.Parse(txtdiscount.Text);
            transaction.grandtotal = decimal.Parse(txtgrandtotal.Text);
            //transaction.tableno = tableno;
            transaction.acctcode = cmbcustomers.SelectedValue.ToString();
            transaction.customer = cmbcustomers.Text;
            transaction.sessionid = sessionid;
            transaction.trdate = DateTime.Now;
            transaction.description = "";
            transaction.branch = txtbranch.Text;
            transaction.paymethod = txtpaymethod.Text;
            transaction.returned = 0;
            transaction.trtype = "1";
            transaction.returnno = 0;
            transaction.paid = decimal.Parse(txtpaid.Text);
            transaction.added_by = frmlogin.loggedin;

            //DataTable detailsDT = sdal.GetTempDetails(int.Parse(txtid.Text));
            //DataTable detailsDT = new DataTable();

            //transaction.transactionDetails = detailsDT;

            bool Issuccess = false;
            using (TransactionScope scope = new TransactionScope())
            {
                int transactionID = -1;
                bool w = tDAL.insertTransaction(transaction, out transactionID);
                txttrid.Text = transactionID.ToString();
                
                //for details
                
                for (int i = 0; i < dgvaddproduct.Rows.Count - 1; i++)
                {
                    
                    string pcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                    productsBLL mypid = pdal.getproductidfromname(pcode);
                    int mproductid = mypid.id;
                    decimal mcost = mypid.costprice;
                    decimal qtyhand = mypid.qty;
                    decimal mbal=qtyhand- decimal.Parse(dgvaddproduct.Rows[i].Cells[2].ToString());

                    transactionDetail.trid = transactionID;
                    transactionDetail.barcode = dgvaddproduct.Rows[i].Cells[0].ToString();
                    transactionDetail.productname = dgvaddproduct.Rows[i].Cells[1].ToString();
                    transactionDetail.productid = mproductid;
                    transactionDetail.costprice = mcost;
                    transactionDetail.qty = decimal.Parse(dgvaddproduct.Rows[i].Cells[2].ToString());
                    transactionDetail.rate = decimal.Parse(dgvaddproduct.Rows[i].Cells[3].ToString());
                    transactionDetail.total = decimal.Parse(dgvaddproduct.Rows[i].Cells[4].ToString());
                    transactionDetail.balance = mbal;
                    transactionDetail.oldqty = qtyhand;
                    transactionDetail.trdate = DateTime.Now;
                    transactionDetail.trtype = "1";
                    
                    //insert details
                    bool x = tdDAL.insertTransactionDetail(transactionDetail);
                    Issuccess = w && x;


                }

                if (Issuccess == true)
                {
                    scope.Complete();
                    MessageBox.Show("تم الحفظ....");


                }
                else
                {
                    MessageBox.Show("لم يتم الحفظ!!!");
                }

            }
            if (Issuccess == true)
            {
                InvoicePrint(txttrid.Text);
            }
        }
        
        private void InvoicePrint(string transID)
        {
            int trid = int.Parse(transID);

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
            string reptitle = "فاتورة ضريبية مبسطة";
            


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
            ReportParameter rp8 = new ReportParameter("invno", txttrid.Text);
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
            ReportParameter rp15 = new ReportParameter("pnet", (transaction.subtotal-transaction.discount).ToString());
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
            DataTable dt = sdal.DisplayAllsales(transID);


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


        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

       
        public void frmClear()
        {
            this.Close();
            frmsales main = new frmsales();
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

        private void button3_Click(object sender, EventArgs e)
        {

            //tablelayout frm = new tablelayout(txtbillno.Text);
            //frm.ShowDialog();

            DataTable dtc = GetCompanyData();
            string compname = dtc.Rows[0]["cname"].ToString();
            string caddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;

            DataTable dts = GetSalesData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["customer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();
           

            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = DateTime.Parse(trdate);//, provider);
            


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

            //********************
            String Seller = arname;
            String VatNo = cvatno;
            DateTime dTime = dtpbilldate.Value;
            Double Total = Convert.ToDouble(gtotal);
            Double Tax = Convert.ToDouble(gvat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();
            

            
            //using QRcoder


            Bitmap qrCodeImage = tlv.toQrCode();
            qrCodeImage.Save("Q1.bmp");
            //**************for report
            using (MemoryStream ms=new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Bmp);
            }
            //*******************************
            
            System.Drawing.Image img = System.Drawing.Image.FromFile("Q1.bmp");
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
          //  img = resizeImage(img, new Size(120, 120));
            byte[] imgBytes = File.ReadAllBytes("Q1.bmp");
            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");

            string imagePath = new Uri("file:///" + "Q1.bmp").AbsoluteUri;

            string myimage = Convert.ToBase64String(imgBytes);
            //MessageBox.Show(imgpath.ToString());

            ReportParameter rp1 = new ReportParameter("cname", compname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);
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

            ReportParameter rp3 = new ReportParameter("customer", custname);
            ReportParameter rp4 = new ReportParameter("caddress", caddress);
            ReportParameter rp5 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp6 = new ReportParameter("description", mdescription);
            ReportParameter rp7 = new ReportParameter("invdate", mdate.ToString());
            ReportParameter rp8 = new ReportParameter("invno", invno);
            ReportParameter rp9 = new ReportParameter("payment", payment);
            ReportParameter rp10 = new ReportParameter("seller", adduser);

            ReportParameter rp11 = new ReportParameter();
            rp11.Name = "qrcode";
            rp11.Values.Add(@"file:///" + imgpath);
            ReportParameter rp12 = new ReportParameter();
            rp12.Name = "logo";
            rp12.Values.Add(@"file:///" + clogo);

            ReportParameter rp13 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp14 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp15 = new ReportParameter("pnet", gnetval);
            ReportParameter rp16 = new ReportParameter("pvat", gvat);
            ReportParameter rp17 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp18 = new ReportParameter("arabicname", arname);

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\SalesRep.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllsales();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //report.DataSource = dt;

            //for (int i = 0; i < printQty; i++)
            //{
            PrintToPrinter(report);
            //}


            /*

            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            prntpreview.Document = prntdoc2;
            prntdoc2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 800, 1200);
            prntdoc2.PrinterSettings.PrinterName = defaultPrinterName;
            prntpreview.ShowDialog();
            //prntdoc2.Print();
            */
            frmClear();

            

        }
        public DataTable GetSalesData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();

            try
            {

                string mysql = "select * from tbl_sales where id='" + txtbillno.Text + "'";

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

        public DataTable GetSalesDetails()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select productname,sum(qty) as qty ,rate,rate*sum(qty) as total from tbl_sdetail where trid='%'+@trid+'%' GROUP BY productname";
                
                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                cmd3.Parameters.Add("@trid", SqlDbType.Int).Value = int.Parse(txtbillno.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);

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

        
        private void button4_Click(object sender, EventArgs e)
        {
            frmClear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmsalesview salesview = new frmsalesview();
            salesview.Show();
        }

        private void cmbcustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            string keywords = cmbcustomers.Text;
            
            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }
            
            acctsBLL dc = dcdal.searchdealercustomerfortransaction(keywords);

            cmbcustomers.Text = dc.name;
            txtvatno.Text = dc.vatno;
            txtcaddress.Text = dc.address;
            */
        }

        private void cmbpayment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void prntpreview_Load(object sender, EventArgs e)
        {

        }

        private void btnprnt_Click(object sender, EventArgs e)
        {
           
            string compname,caddress,arname,cvatno,clogo,cvatno2,custname = "";
            string txtpvat = "";

            DataTable dtc = GetCompanyData();
            if (dtc.Rows.Count > 0)
            {
                 compname = dtc.Rows[0]["cname"].ToString();
                 caddress = dtc.Rows[0]["caddress"].ToString();
                 arname = dtc.Rows[0]["aname"].ToString();
                 cvatno = dtc.Rows[0]["cvatno"].ToString();
                 clogo = dtc.Rows[0]["clogo"].ToString();
                string isvatincluded = dtc.Rows[0]["vatincluded"].ToString();
                
                
                if (isvatincluded == "1")
                {
                     txtpvat = "**الأسعار شاملة لضريبة القيمة المضافة";

                }

                cvatno2 = "الرقم الضريبي:   " + cvatno;
            }
            else
            {
                compname = "";
                caddress = "";
                arname = "";
                cvatno = "";
                clogo = "";
                cvatno2 = "الرقم الضريبي";

            }

            DataTable dts = GetSalesData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["customer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();

            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = Convert.ToDateTime(trdate);//, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal + nvat;
            string gnetval = mnetval.ToString();




            DataTable dtcust = GetCustomer(mcust);
            if (dtcust.Rows.Count > 0)
            {
                 custname = dtcust.Rows[0]["name"].ToString();
                
            }
            else
            {
                custname = "";
            }
            //string custname = "";
            string custadd = "";
            string custvat = "";

            //********************

            String Seller = arname;
            String VatNo = cvatno;
            DateTime dTime = dtpbilldate.Value;
            Double Total = Convert.ToDouble(gtotal);
            Double Tax = Convert.ToDouble(gvat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();

            //using QRcoder

           
            Bitmap qrCodeImage = tlv.toQrCode();
            qrCodeImage.Save("Q1.bmp");



            //*************************

           


            System.Drawing.Image img = System.Drawing.Image.FromFile("Q1.bmp");
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
            //img = resizeImage(img, new Size(120, 120));
            byte[] imgBytes = File.ReadAllBytes("Q1.bmp");
            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");

            string imagePath = new Uri("file:///" + "Q1.bmp").AbsoluteUri;

            string myimage = Convert.ToBase64String(imgBytes);
            //MessageBox.Show(imgpath.ToString());

            ReportParameter rp1 = new ReportParameter("cname", compname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);
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
            ReportParameter rp3 = new ReportParameter("customer", custname);
            ReportParameter rp4 = new ReportParameter("maddress", caddress);
            ReportParameter rp5 = new ReportParameter("pricevat", custvat);
            ReportParameter rp6 = new ReportParameter("description", mdescription);
            ReportParameter rp7 = new ReportParameter("invdate", trdate);
            ReportParameter rp8 = new ReportParameter("invno", invno);
            ReportParameter rp9 = new ReportParameter("payment", payment);
            ReportParameter rp10 = new ReportParameter("seller", adduser);

            ReportParameter rp11 = new ReportParameter();
            rp11.Name = "qrcode";
            rp11.Values.Add(@"file:///" + imgpath);
            ReportParameter rp12 = new ReportParameter();
            rp12.Name = "logo";
            rp12.Values.Add(@"file:///" + clogo);

            ReportParameter rp13 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp14 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp15 = new ReportParameter("pnet", gnetval);
            ReportParameter rp16 = new ReportParameter("pvat", gvat);
            ReportParameter rp17 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp18 = new ReportParameter("arabicname", arname);
           


            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\smallInv.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllsales();
            report.DataSources.Add(new ReportDataSource("DataSet2", dt));
            //report.DataSource = dt;

            //for (int i = 0; i < printQty; i++)
            //{
            PrintToPrinter1(report);
            //}

            frmClear();



        }

        private void dgvaddproduct_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvaddproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
        }
        //**************************************************for small
       
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
        
        public DataTable DisplayAllsales()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.productname As name,sum(qty) as qty,rate as rate, sum(b.total) as total from tbl_sales a,tbl_sdetail b where b.trid=a.id and a.id='" + txtbillno.Text + "' group by b.productname,a.trdate,rate";
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

                string mysql = "select * from company where id=1";

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

                string mysql = "select * from tbl_accts where acctname LIKE '%'+@Cname+'%'"; 

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                cmd3.Parameters.AddWithValue("@Cname", custname);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);

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

        private void salesdetailBLLBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            DataTable dt = DisplayAllsales();
            //salesdetailBLLBindingSource.DataSource = dt;

        }

        

        

        
        private void txtpaid_Validated(object sender, EventArgs e)
        {

        }

        private void cmbcustomers_Validated(object sender, EventArgs e)
        {
            string keywords = cmbcustomers.Text;

            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }

            acctsBLL dc = dcdal.searchdealercustomerfortransaction(keywords);
            
            cmbcustomers.Text = dc.acctname;
            txtvatno.Text = dc.vatno;
            txtcaddress.Text = dc.caddress;

        }
        // scanner handler*****************************************************************************
        private BarCodeListener ScannerListener;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool res = false;
            if (ScannerListener != null)
            {
                res = ScannerListener.ProcessCmdKey(ref msg, keyData);
            }
            res = keyData == Keys.Enter ? res : base.ProcessCmdKey(ref msg, keyData);
            return res;
        }
        public class BarcodeScannedEventArgs : EventArgs
        {

            public BarcodeScannedEventArgs(string text)
            {
                mText = text;
            }
            public string ScannedText { get { return mText; } }

            private readonly string mText;
        }

        public class BarCodeListener : IDisposable
        {
            DateTime _lastKeystroke = new DateTime(0);
            string _barcode = string.Empty;
            Form _form;
            bool isKeyPreview;

            public bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                bool res = processKey(keyData);
                return keyData == Keys.Enter ? res : false;
            }

            protected bool processKey(Keys key)
            {
                // check timing (>7 keystrokes within 50 ms ending with "return" char)
                TimeSpan elapsed = (DateTime.Now - _lastKeystroke);
                if (elapsed.TotalMilliseconds > 50)
                {
                    _barcode = string.Empty;
                }

                // record keystroke & timestamp -- do NOT add return at the end of the barcode line
                if (key != Keys.Enter)
                {
                    _barcode += (char)key;
                }
                _lastKeystroke = DateTime.Now;

                // process barcode only if the return char is entered and the entered barcode is at least 7 digits long.
                // This is a "magical" rule working well for EAN-13 and EAN-8, which both have at least 8 digits...
                if (key == Keys.Enter && _barcode.Length > 7)
                {
                    if (BarCodeScanned != null)
                    {
                        BarCodeScanned(_form, new BarcodeScannedEventArgs(_barcode));
                    }
                    _barcode = string.Empty;
                    return true;
                }
                return false;
            }

            public event EventHandler<BarcodeScannedEventArgs> BarCodeScanned;

            public BarCodeListener(Form f)
            {
                _form = f;
                isKeyPreview = f.KeyPreview;
                // --- set preview and register event...
                f.KeyPreview = true;
            }

            public void Dispose()
            {
                if (_form != null)
                {
                    _form.KeyPreview = isKeyPreview;
                    //_form.KeyPress -= KeyPress_scanner_preview;
                }
            }
        }

        private void txtbarcode_Validated(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt2 = new DataTable();
            if (txtbarcode.Text != "")
            {


                try
                {
                    
                    con.Open();
                    string sql = "Select barcode,name,qty,rate,total From tbl_products where barcode=@barcode ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    // cmd.Parameters.Add("@id", (DbType)SqlDbType.Int).Value = pid;
                    cmd.Parameters.AddWithValue("@barcode", txtbarcode.Text);


                    adapter.Fill(dt2);


                    //string type = frmUserdashboard.transactontype;

                    //===
                    if (dt2.Rows.Count > 0)
                    {

                        string productbarcode = dt2.Rows[0]["barcode"].ToString();
                        string productname = dt2.Rows[0]["name"].ToString();
                        double rate = double.Parse(dt2.Rows[0]["rate"].ToString());
                        double qty = 1;
                        // if (isdelivery.ToString() == "1")
                        //  {
                        //     rate = rate * 1.15;
                        //}
                        double total = rate * qty;

                        // Search DataGrid for product_id
                        if (dgvaddproduct.Rows.Count > 0)
                        {


                            bool found = false;


                            foreach (DataGridViewRow row in dgvaddproduct.Rows)
                            {

                                if (Convert.ToString(row.Cells[0].Value) == productbarcode) // && Convert.ToString(row.Cells[3].Value)==rate.ToString())
                                {

                                    row.Cells[2].Value = Convert.ToString(1 + Convert.ToInt16(row.Cells[2].Value));

                                    found = true;
                                    double nrate = double.Parse(row.Cells[3].Value.ToString());
                                    double nqty = double.Parse(row.Cells[2].Value.ToString());
                                    double ntotal = nrate * nqty;
                                    double oldtotal = double.Parse(row.Cells[4].Value.ToString());
                                    row.Cells[4].Value = ntotal.ToString();
                                    // txtsubtotal.Text = ntotal.ToString();
                                    double nsubtotal = double.Parse(txtsubtotal.Text);
                                    nsubtotal = nsubtotal + ntotal - oldtotal;
                                    txtsubtotal.Text = nsubtotal.ToString("0.00");


                                }
                                txtbarcode.Text = "";
                                txtbarcode.Focus();
                            }
                            if (!found)
                            {
                                dgvaddproduct.Rows.Add(productbarcode, productname, qty, rate, total);
                                double ototal = rate * qty;
                                double osubtotal = double.Parse(txtsubtotal.Text);
                                osubtotal = osubtotal + ototal;
                                txtsubtotal.Text = osubtotal.ToString("0.00");
                                txtbarcode.Text = "";
                                txtbarcode.Focus();


                            }

                            tvat = cmpdal.Select();
                            string vatpercent = tvat.Rows[0]["vatval"].ToString();
                            string isvatincluded = tvat.Rows[0]["vatincluded"].ToString();
                            string custdip = tvat.Rows[0]["custdisplay"].ToString();
                            //string tabno = tvat.Rows[0]["tablesno"].ToString();
                            //nooftables = int.Parse(tabno);
                            //iscreen = int.Parse(custdip);
                            double vat = 0;
                            double mnetval = 0;
                            double grandtotalwithvat = 0;
                            double subtotal = double.Parse(txtsubtotal.Text);
                            double myvatval = (double.Parse(vatpercent)) / 100;
                            double mdiscount = double.Parse(txtdiscount.Text);
                            double enetval = subtotal - mdiscount;





                            if (isvatincluded == "1")
                            {
                                mnetval = enetval / (1 + myvatval);

                                vat = enetval - mnetval;
                                grandtotalwithvat = enetval;
                               // lblsubtotal.Text = vatinclude;
                                //label6.Text = vatamount;

                                txtsubtotal.Text = subtotal.ToString("0.00");
                                txtvat.Text = vat.ToString("0.00");
                                txtnetval.Text = mnetval.ToString("0.00");
                                txtgrandtotal.Text = grandtotalwithvat.ToString("0.00");

                            }
                            else
                            {
                                vat = enetval * myvatval;
                                //mnetval = subtotal + vat;
                                grandtotalwithvat = enetval + vat;
                                txtsubtotal.Text = subtotal.ToString("0.00");
                                txtvat.Text = vat.ToString("0.00");
                                txtnetval.Text = enetval.ToString("0.00");
                                txtgrandtotal.Text = grandtotalwithvat.ToString("0.00");
                            }

                            // ((100+15)/100)*subtotal;


                        }
                        else
                        {
                            dgvaddproduct.Rows.Add(productbarcode, productname, qty, rate, total);
                            txtbarcode.Text = "";
                            txtbarcode.Focus();
                        }
                    }


                    else
                    {
                        //MessageBox.Show(madd);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();

                }
            }
            else
            {
                return;
            }
           

        }

        private void txtname_Validated(object sender, EventArgs e)
        {
            productsBLL dc = new productsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            keywords = txtname.Text;
            if (keywords != "")
            {

                try
                {

                    string sql = "Select barcode,name,qty,rate from tbl_products WHERE name LIKE '%" + keywords + "%'";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    string sql2 = "Select name from tbl_products";// WHERE name LIKE '%" + keywords + "%'";// OR name LIKE '%" + keywords + "%'";
                    SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                    conn.Open();
                    adapter2.Fill(dt2);
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    //    while(dt.Rows.Count>0)
                    {

                        //txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                        txtbarcode.Text = dt.Rows[0]["barcode"].ToString();
                        txtname.Text = dt.Rows[0]["name"].ToString();
                        //txtprice.Text = dt.Rows[0]["rate"].ToString();
                        txtbarcode.Focus();
                    }
                    else
                    {
                        using (var form = new frmprodlist())
                        {
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                string val = form.ReturnValue1;            //values preserved after close

                                txtbarcode.Text = val; // dt3.Rows[0]["barcode"].ToString();
                                                       // txtname.Text = dt3.Rows[0]["name"].ToString();
                                                       //txtprice.Text = dt3.Rows[0]["rate"].ToString();

                            }
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
            }
        }

        private void itemsearch_Click(object sender, EventArgs e)
        {
            using (var form = new frmprodlist())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val = form.ReturnValue1;            //values preserved after close

                    txtbarcode.Text = val;
                    
                    txtbarcode.Focus();
                }
            }
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            using (var form = new frmpayconfirm(txtgrandtotal.Text))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string val1 = form.ReturnValue1; // Retrieve the values
                    string val2 = form.ReturnValue2;
                    string val3 = form.ReturnValue2;
                    string val4 = form.ReturnValue2;
                    string val5 = form.ReturnValue2;
                    // Do something with these values (e.g., update text boxes)
                    this.txtpaymethod.Text = val1;
                    this.txtcash.Text = val2;
                    this.txtcard.Text = val3;
                    this.txtdiscount.Text = val4;
                    this.txtgrandtotal.Text = val5;
                }
            }

            
        }
    }
  
}






