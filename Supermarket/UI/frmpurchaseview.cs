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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmpurchaseview : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        TextBox trtype = new TextBox();
        public frmpurchaseview()
        {
            InitializeComponent();
            //trtype.Text = mtype;
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
         purchaseDAL purdal= new purchaseDAL();
        transactionBLL transaction = new transactionBLL();
        transactionDAL tDAL = new transactionDAL();
        transactionDetailDAL tdDAL = new transactionDetailDAL();
        transactiondetailBLL transactionDetail = new transactiondetailBLL();
        public string msave = "";
        private void frmpurchase_Load(object sender, EventArgs e)
        {
            DataTable dt = purdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvaddproduct.Columns[0].HeaderText = "الرقم";
                dgvaddproduct.Columns[1].HeaderText = "الاسم";
                //dgvaddproduct.Columns[2].HeaderText = "الوحدة";
                dgvaddproduct.Columns[2].HeaderText = "الكمية";
                dgvaddproduct.Columns[3].HeaderText = "السعر";
                dgvaddproduct.Columns[4].HeaderText = "الاجمالي";
                //dgvaddproduct.Columns[5].HeaderText = "الضريبة 15%";
                //dgvaddproduct.Columns[6].HeaderText = "الضريبة 100%";
            }
            else
            {
                dgvaddproduct.Columns[0].HeaderText = "Barcode";
                dgvaddproduct.Columns[1].HeaderText = "Name";
                // dgvaddproduct.Columns[2].HeaderText = "Unit";
                dgvaddproduct.Columns[2].HeaderText = "Qty";
                dgvaddproduct.Columns[3].HeaderText = "Price";
                dgvaddproduct.Columns[4].HeaderText = "Total";
                //dgvaddproduct.Columns[5].HeaderText = "VAT 15%";
                //dgvaddproduct.Columns[6].HeaderText = "VAT 100%";
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


            dgvaddproduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtsubtotal.Text = subtotal.ToString();
            cmbtype.SelectedItem = "Cash";


            // Bills drop down list
            string sql2 = "Select id,dealer from tbl_purchase where trtype=@trtype";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@trtype", "3");
            DataSet ds = new DataSet();
            da.Fill(ds, "purchase");

            
            cmbbillno.DisplayMember = "id";
            cmbbillno.ValueMember = "id";
            cmbbillno.DataSource = ds.Tables["purchase"];
            string mcat = cmbbillno.Text;
            conn2.Close();




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
            deacustBLL dc = dcdal.searchdealercustomerfortransaction(keywords);

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
                    if (String.IsNullOrEmpty(keywords))
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
                            string sql = "Select barcode,name,unit,qtyhand,price,tobvat from tbl_items WHERE barcode LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            conn.Open();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            //    while(dt.Rows.Count>0)
                            {
                                double nvat100 = 0;
                                double nvat15 = 0;
                                string mytobvat = dt.Rows[0]["tobvat"].ToString();
                                txtcurrentvalue.Text = dt.Rows[0]["qtyhand"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["name"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = 1;
                                this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt.Rows[0]["price"].ToString();
                                //this.dgvaddproduct.Rows[currentRow].Cells[4].Value = ;


                                this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;
                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);

                                if (mytobvat == "1")
                                {
                                    nvat100 = ntotal;
                                    nvat15 = ntotal * 0.15;

                                }
                                else
                                {
                                    nvat100 = 0;
                                    nvat15 = ntotal * 0.15;
                                }
                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = nvat100.ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = nvat15.ToString();

                                double oldmdiscount = double.Parse(txtdiscount.Text);
                                double dsubtotal = double.Parse(txtsubtotal.Text);
                                double nsubtotal = ntotal + dsubtotal;

                                double noldvat100 = double.Parse(txtvat100.Text);
                                double nnewvat100 = noldvat100 + nvat100;

                                double noldvat15 = double.Parse(txtvat.Text);
                                double nnewvat15 = noldvat15 + nvat15;

                                double newnet = nsubtotal + nnewvat100 + nnewvat15;
                                double dueamount = newnet - oldmdiscount;
                                dgvaddproduct.Update();
                                dgvaddproduct.Refresh();
                                txtsubtotal.Text = nsubtotal.ToString();
                                txtvat.Text = nnewvat15.ToString();
                                txtvat100.Text = nnewvat100.ToString();
                                txtnetval.Text = newnet.ToString();
                                txtgrandtotal.Text = dueamount.ToString();

                                //TransCalculations();

                            }
                            else
                            {
                                using (var form = new frmprodlist())
                                {
                                    var result = form.ShowDialog();
                                    if (result == DialogResult.OK)
                                    {
                                        string val = form.ReturnValue1;            //values preserved after close

                                        DataTable dt3 = pdal.getproductforSales(val);
                                        this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt3.Rows[0]["barcode"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt3.Rows[0]["name"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt3.Rows[0]["qty"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt3.Rows[0]["rate"].ToString();
                                        // this.dgvaddproduct.Rows[currentRow].Cells[4].Value = dt3.Rows[0]["rate"].ToString();
                                        this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;

                                        string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                        string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();


                                        double ntotal = double.Parse(uprice) * double.Parse(uqty);
                                        string myntobvat = dt3.Rows[0]["tobvat"].ToString();
                                        this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString("0.00");
                                        //  this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                        //  this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
                                        double nvat100 = 0;
                                        double nvat15 = 0;

                                        
                                        double oldmdiscount = double.Parse(txtdiscount.Text);
                                        double dsubtotal = double.Parse(txtsubtotal.Text);
                                        double nsubtotal = ntotal + dsubtotal;

                                        double noldvat100 = double.Parse(txtvat100.Text);
                                        double nnewvat100 = noldvat100 + nvat100;

                                        double noldvat15 = double.Parse(txtvat.Text);
                                        double nnewvat15 = noldvat15 + nvat15;
                                        double newnet = nsubtotal + nnewvat100 + nnewvat15;

                                        double dueamount = newnet - oldmdiscount;

                                       // txtvat.Text = nnewvat15.ToString();
                                        //txtvat100.Text = nnewvat100.ToString();


                                        dgvaddproduct.Update();
                                        dgvaddproduct.Refresh();
                                        txtsubtotal.Text = nsubtotal.ToString("0.00");
                                        txtnetval.Text = newnet.ToString("0.00");
                                        txtgrandtotal.Text = dueamount.ToString();
                                        // TransCalculations();
                                        //this.dgvaddproduct.Rows[currentRow].Cells[0].Value = val;
                                        //for example

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





                        //






                    }





                    //dgvaddproduct.CurrentCell = dgvaddproduct.Rows[rowIndex].Cells[4];



                    break;
                case 2:
                case 3:
                    string mrate = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                    string mqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();

                    string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
                    //string name = this.dgvaddproduct.Rows[rowIndex].Cells["name"].Value.ToString();
                    double oldtotal = double.Parse(mtotal);


                    double newtotal1 = double.Parse(mrate) * double.Parse(mqty);
                    this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = newtotal1.ToString();
                    //this.dgvaddproduct.Columns["total"] = (Convert.ToDouble(row.Cells[dgvaddproduct.Columns["price"].Index].value) * (convert.todouble(rwo.cells[dgvaddproduct.columns["qty].index].value
                    double newvat = newtotal1 * 0.15;
                    this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = newvat.ToString();


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

            double invnetval = double.Parse(txtsubtotal.Text);
            double nvat = invnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = nvat.ToString();
            txtnetval.Text = (invnetval + nvat).ToString("0.00");
            double mygrandtotalwithvat = nvat + invnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            /*
             string mytr=cmbbillno.Text;
           
           int myid = int.Parse(mytr);

           

            SqlConnection con = new SqlConnection(myconnstrng);
            
                con.Open();
                //string sql = "INSERT INTO tbl_purchase (trdate,description,subtotal,vat,discount,gtotal,added_by,trtype,dealer,invno,invdate,returnno) VALUES(@trdate,@description,@subtotal,@vat,@discount,@gtotal,@added_by,@trtype,@dealer,@invno,@invdate,@returnno)";
                string sql = "Update tbl_purchase set trdate=@trdate,description=@description,subtotal=@subtotal,vat=@vat,discount=@discount,gtotal=@gtotal,added_by=@added_by,trtype=@trtype,dealer=@dealer,invno=@invno,invdate=@invdate,returnno=@returnno WHERE id=@id";

            SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@trdate", dtpbilldate.Value);
                cmd.Parameters.AddWithValue("@description", txtdescription.Text);
                cmd.Parameters.AddWithValue("@subtotal", txtsubtotal.Text);
                cmd.Parameters.AddWithValue("@vat", txtvat.Text);
                cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
                cmd.Parameters.AddWithValue("@gtotal", txtgrandtotal.Text);
                cmd.Parameters.AddWithValue("@added_by", frmlogin.loggedin);
                cmd.Parameters.AddWithValue("@trtype", "Purchase");
                cmd.Parameters.AddWithValue("@dealer", cmbbillno.Text);
                cmd.Parameters.AddWithValue("@invno", txtdealer.Text);
                cmd.Parameters.AddWithValue("@invdate", dtinvdate.Text);
                cmd.Parameters.AddWithValue("@returnno", "");
                cmd.Parameters.AddWithValue("@id", myid);


            cmd.ExecuteNonQuery();
               
            
            string sql2 = "delete from tbl_purchaseitems where trid=@id";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            cmd2.Parameters.AddWithValue("@id", myid);
            cmd2.ExecuteNonQuery();

            string sqltr = "delete from tbl_strans where trno=@id";
            SqlCommand cmdtr = new SqlCommand(sqltr, con);
            cmdtr.Parameters.AddWithValue("@id", myid);
            cmdtr.ExecuteNonQuery();

            string sqlacct = "delete from tbl_accttr where trno=@id";
            SqlCommand cmdacct = new SqlCommand(sqlacct, con);
            cmdacct.Parameters.AddWithValue("@id", myid);
            cmdacct.ExecuteNonQuery();
            con.Close();


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


                        string msql = "insert into tbl_purchaseitems(trid,itemid,itemname,itemprice,itemqty,itemtotal) VALUES(@trid,@itemid,@itemname,@itemprice,@itemqty,@itemtotal)";
                        SqlCommand cmd1 = new SqlCommand(msql, con);
                        cmd1.Parameters.AddWithValue("@trid", myid);
                        cmd1.Parameters.AddWithValue("@itemid", dgvaddproduct.Rows[i].Cells[0].Value);
                        cmd1.Parameters.AddWithValue("@itemname", dgvaddproduct.Rows[i].Cells[1].Value);
                        cmd1.Parameters.AddWithValue("@itemprice", dgvaddproduct.Rows[i].Cells[4].Value);
                        cmd1.Parameters.AddWithValue("@itemqty", dgvaddproduct.Rows[i].Cells[3].Value);
                        cmd1.Parameters.AddWithValue("@itemtotal", dgvaddproduct.Rows[i].Cells[5].Value);
                        //cmd1.Parameters.AddWithValue("@discount", dgvaddproduct.Rows[i].Cells[5].Value);
                        //cmd1.Parameters.AddWithValue("@gtotal", dgvaddproduct.Rows[i].Cells[6].Value);


                        cmd1.ExecuteNonQuery();

                        string mbarcode = dgvaddproduct.Rows[i].Cells[0].Value.ToString();


                        var pqty = dgvaddproduct.Rows[i].Cells[3].Value;
                        var mrate = dgvaddproduct.Rows[i].Cells[4].Value;
                        decimal rate = Convert.ToDecimal(mrate);
                        decimal Mpqty = Convert.ToDecimal(pqty);
                        //MessageBox.Show("Product id   " + MyPid);
                        decimal Qty_hand = pdal.GetProductQty(mbarcode);
                        //MessageBox.Show("Product id   " + mbarcode + "qty  " + Qty_hand +"new qty" + Mpqty);
                        //*************************Update inventory values ***********



                        bool x = false;

                        x = pdal.IncreaseProduct(mbarcode, Mpqty, Qty_hand, rate);
                        // add to stock trans
                        decimal itembalance = Qty_hand + decimal.Parse(dgvaddproduct.Rows[i].Cells[3].Value.ToString());

                        string sql5 = "insert into tbl_strans(trno,item,price,qty,balance,sdate,trtype,description) VALUES(@trno,@item,@price,@qty,@balance,@sdate,@trtype,@description)";
                        SqlCommand cmd5 = new SqlCommand(sql5, con);
                        cmd5.Parameters.AddWithValue("@trno", myid);
                        cmd5.Parameters.AddWithValue("@item", mpname);
                        cmd5.Parameters.AddWithValue("@price", dgvaddproduct.Rows[i].Cells[4].Value);
                        cmd5.Parameters.AddWithValue("@qty", dgvaddproduct.Rows[i].Cells[3].Value);
                        cmd5.Parameters.AddWithValue("@balance", itembalance);
                        cmd5.Parameters.AddWithValue("@sdate", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@trtype", 1);
                        cmd5.Parameters.AddWithValue("@description", "Purchase");


                        cmd5.ExecuteNonQuery();
                        con.Close();
                    }


                }
                con.Open();
                deacustBLL cs = dcdal.getcustidfromname(cmbbillno.Text);
                int custid = cs.id;
                string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,acctid) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@acctid)";
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd3.Parameters.AddWithValue("@trno", txtbillno.Text);
                cmd3.Parameters.AddWithValue("@trtype", "Purchase");
                cmd3.Parameters.AddWithValue("@payacct", cmbtype.Text);
                cmd3.Parameters.AddWithValue("@acctname", cmbbillno.Text);
                cmd3.Parameters.AddWithValue("@description", txtdescription.Text);
                cmd3.Parameters.AddWithValue("@dbval", "0");
                cmd3.Parameters.AddWithValue("@crval", txtgrandtotal.Text);
                cmd3.Parameters.AddWithValue("@acctid", custid);

                cmd3.ExecuteNonQuery();
            
            con.Close();
            MessageBox.Show(msave);
            btnprntA4.Enabled = true;
            btnprnt.Enabled = true;

*/

        }
        public DataTable GetTransDetails()
        {
                DataTable dtLocalC = new DataTable();
                dtLocalC.Columns.Add("barcode");
                dtLocalC.Columns.Add("product");
                dtLocalC.Columns.Add("unit");
                dtLocalC.Columns.Add("qty");
                dtLocalC.Columns.Add("price");
                dtLocalC.Columns.Add("total");

                DataRow drLocal = null;
                foreach (DataGridViewRow dr in dgvaddproduct.Rows)
                {
                    drLocal = dtLocalC.NewRow();
                    drLocal["barcode"] = dr.Cells[0].Value;
                    drLocal["product"] = dr.Cells[1].Value;
                    drLocal["unit"] = dr.Cells[2].Value;
                    drLocal["qty"] = dr.Cells[3].Value;
                    drLocal["price"] = dr.Cells[4].Value;
                    drLocal["total"] = dr.Cells[5].Value;
                    dtLocalC.Rows.Add(drLocal);
                }

                return dtLocalC;
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
           // string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust =dts.Rows[0]["dealer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();
            string paymethod = dts.Rows[0]["paymethod"].ToString();
            string dealerinv = dts.Rows[0]["invno"].ToString();
            

            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

           // DateTime mdate = Convert.ToDateTime(trdate, provider);
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
            ReportParameter rp5 = new ReportParameter("invno", cmbbillno.Text);
            ReportParameter rp6 = new ReportParameter("payment", paymethod);
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
            ReportParameter rp15 = new ReportParameter("sinvno",dealerinv );
            

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
            DataTable dt = GetPurchaseDetails();
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
            DialogResult result=MessageBox.Show("حذف الفاتورة؟", "تحذير", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                InvDel();
            }
            else if (result == DialogResult.No)
            {
                // Perform action when No button is clicked
            }
        }

        private void InvDel()
        {
            int myid = int.Parse(cmbbillno.Text);
            SqlConnection myconn = new SqlConnection(myconnstrng);
            myconn.Open();
            string sql1 = "delete from tbl_purchaseitems where trid=@id";
            SqlCommand cmdel1 = new SqlCommand(sql1, myconn);
            cmdel1.Parameters.AddWithValue("@id", myid);
            cmdel1.ExecuteNonQuery();

            string sql2 = "delete from tbl_purchase where id=@id";
            SqlCommand cmdel2 = new SqlCommand(sql2, myconn);
            cmdel2.Parameters.AddWithValue("@id", myid);
            cmdel2.ExecuteNonQuery();
            myconn.Close();
            MessageBox.Show("تم الحذف...");



        }
        private void button4_Click(object sender, EventArgs e)
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
            //string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust =dts.Rows[0]["dealer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();
            string paymethod = dts.Rows[0]["paymethod"].ToString();
            string dealerinv = dts.Rows[0]["invno"].ToString();
            


            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

           

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
            ReportParameter rp5 = new ReportParameter("invno", dealerinv);
            ReportParameter rp6 = new ReportParameter("payment",paymethod );
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
            ReportParameter rp15 = new ReportParameter("sinvno", txtdealer.Text);
            ReportParameter rp16 = new ReportParameter("reptitle", " مشتريات");
            

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\purchaseRepA4.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16 });
            //this.report.RefreshReport();
            DataTable dt = GetPurchaseDetails();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));

            dt.Columns["name"].ColumnName = "productname";

            PrintToPrinter(report);

            frmClear();



        }
        public DataTable GetpurchaseData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tbl_purchase where id='" + cmbbillno.Text + "'";

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

                string mysql = "select itemname as name,itemqty as qty ,itemprice as rate,itemtotal as total,barcode from tbl_purchaseitems where trid='" + cmbbillno.Text + "'";

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
        public DataTable DisplayAllpurchase()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.itemname As name,itemqty as qty,itemprice as rate, b.itemtotal as total from tbl_purchase a,tbl_purchaseitems b where b.trid=a.id and a.id=@billno";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@billno", txtbillno.Text);
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

                string mysql = "select cname,aname,caddress,cvatno,clogo from company";

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


        public DataTable GetCustomer(string  custname)
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable newdtcust = new DataTable();
            //MessageBox.Show(custname);
            //int mcustid = int.Parse(custid);
            try
            {
                //MessageBox.Show(custname);
                
                    string mysql = "select * from tbl_accts where acctname=@custname";

                    myconn.Open();
                    SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                    cmd3.Parameters.AddWithValue("@custname", custname);
                    SqlDataAdapter da = new SqlDataAdapter(cmd3);

                    da.Fill(newdtcust);
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

            return newdtcust;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbsupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

            string keywords = cmbbillno.Text;
            if (String.IsNullOrEmpty(keywords))
            {

                //  txtname.Text = "";
                //txtvatno.Text = "";

                return;


            }
            //salesBLL sc = sdal.GetInvoiceID(keywords);
            //string myid = sc.id.ToString();
            //cmbbillno.Text = myid;
            DataTable dts = purdal.GetInvoicePurchase(keywords);
            
            if (dts.Rows.Count > 0)
            {
               
                double subtotal = Convert.ToDouble(dts.Rows[0]["subtotal"].ToString());
                double vat= Convert.ToDouble(dts.Rows[0]["vat"].ToString());
                
                string mdate = dts.Rows[0]["trdate"].ToString();
                //txtinvdate.Text = mdate.ToString();
                txtdescription.Text = dts.Rows[0]["description"].ToString();
                //txtbranch.Text = dts.Rows[0]["branch"].ToString();
                txtsubtotal.Text = dts.Rows[0]["subtotal"].ToString();
                txtvat.Text = dts.Rows[0]["vat"].ToString();
                txtdiscount.Text = dts.Rows[0]["discount"].ToString();
                txtgrandtotal.Text = dts.Rows[0]["grandtotal"].ToString();
                cmbtype.Text = dts.Rows[0]["paymethod"].ToString();

                //txtcard.Text = dts.Rows[0]["paycard"].ToString();
               // txtvat1.Text = dts.Rows[0]["vat1"].ToString();
                txtuser.Text = dts.Rows[0]["added_by"].ToString();
                txtdealer.Text = dts.Rows[0]["dealer"].ToString();
                txtinvno.Text = dts.Rows[0]["invno"].ToString();
                dtinvdate.Text = dts.Rows[0]["invdate"].ToString();
                
                txtnetval.Text = (subtotal+vat).ToString();


            }

            DataTable sdat =purdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = sdat;




        }

        private void btnview_Click(object sender, EventArgs e)
        {
           
        }

        private void txtvat_Validated(object sender, EventArgs e)
        {
            double oldsubt = double.Parse(txtsubtotal.Text);
            double olddiscount = double.Parse(txtdiscount.Text);
            
            double newvat = double.Parse(txtvat.Text);
            double newnetval = oldsubt + newvat;
            double newgrand = newnetval - olddiscount;
            txtnetval.Text = newnetval.ToString("0.00");
            txtgrandtotal.Text = newgrand.ToString("0.00");




        }

        private void txtdiscount_Validated(object sender, EventArgs e)
        {
            double oldnetval = double.Parse(txtnetval.Text);
            double newdiscount = double.Parse(txtdiscount.Text);
          
            double newgrand2 = oldnetval - newdiscount;
            txtgrandtotal.Text = newgrand2.ToString("0.00");

        }
    }
}
