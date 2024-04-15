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
    public partial class frmproforma : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmproforma()
        {
            InitializeComponent();
        }
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";
        public string mmseg = "الصنف غير موجود...اضافة";
        public string mconf = "تأكيد";
        public string msave = "تأكيد";
        public string compmess = "بيانات الشركة غير مكتملة";
        public string custmess = "لا يوجد عملاء";
        string keywords = "";
        TextBox suppacct = new TextBox();

        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();

        salesDAL sdal = new salesDAL();


        public double myvat = 0;
        DataTable dt3 = new DataTable();


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmproforma_Load(object sender, EventArgs e)
        {
            btnsave.Enabled = false;

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
                compmess = "بيانات الشركة غير مكتملة";
                custmess = "لا يوجد عملاء";
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
                compmess = "Company Data Missing...";
                custmess = "No Customers...";

            }
            


            DataTable dt = cmpdal.Select();
            txtbranch.Text = dt.Rows[0]["branch"].ToString();
            txtstore.Text = dt.Rows[0]["store"].ToString();
            txtuser.Text = frmlogin.loggedin;
            string cyvat = dt.Rows[0]["vatval"].ToString();
            myvat = double.Parse(cyvat) / 100;
            //cmbtype.SelectedIndex = 0;
            txtbillno.Text = salesDAL.DisplayMaxSalesID();
            this.ActiveControl = dgvaddproduct;




            for (int i = 0; i < 5; i++)
            {
                AddAColumn(i);
            }
            dgvaddproduct.RowHeadersDefaultCellStyle.Padding = new Padding(3);//helps to get rid of the selection triangle?
            for (int i = 0; i < 12; i++)
            {
                AddARow(i);
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
            // dgvaddproduct.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvaddproduct.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



            txtsubtotal.Text = subtotal.ToString();





            // Customers drop down list
            string sql2 = "Select id,name from tbl_accts where type='1'";
            SqlConnection conn = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            // Get the data from the database. I am using the Northwind database the customers table
            da.Fill(ds, "customers");
            
            cmbcustomers.DataSource = ds.Tables["customers"];
            // Tell the combo box what collumn to display to the user
            cmbcustomers.DisplayMember = "name";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbcustomers.ValueMember = "name";
            string mcat = cmbcustomers.Text;

            // Restored the event handler
            //this.cmbcategory.SelectedIndexChanged += new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            conn.Close();
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
                var ch = new string[5] { "الرمز", "الصنف", "الكمية", "السعر", "الاجمالي" };
                Acolumn.HeaderText = ch[i].ToString();
            }
            else
            {
                var ch = new string[5] { "Barcode", "Product", "Qty", "Price", "Total" };
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
                double mmdiscount = double.Parse(txtdiscount.Text);

                double mnetval = subtotal - mmdiscount;
                double vat = mnetval * myvat;  // ((100+15)/100)*subtotal;
                txtvat.Text = vat.ToString();
                txtnetval.Text = mnetval.ToString();
                double grandtotalwithvat = vat + mnetval; //((100 + 15) / 100) * prevgrand;
                txtgrandtotal.Text = grandtotalwithvat.ToString();
                dgvaddproduct.Rows.RemoveAt(rowIndex);
            }
        }

        private void dgvaddproduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            if (columnIndex == 5)
            {
                txtolddiscount.Text = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
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

                        //  txtname.Text = "";
                        //string munit = dgvaddproduct.Rows[0].Cells[2].ToString();

                        return;

                    }
                    else
                    {
                        int currentRow = dgvaddproduct.CurrentCell.RowIndex;

                        // Get the DAL function Here
                        productsBLL dc = new productsBLL();
                        SqlConnection conn = new SqlConnection(myconnstrng);
                        DataTable dt = new DataTable();
                        DataTable dt2 = new DataTable();





                        try
                        {



                            string sql = "Select barcode,name,qty,rate from tbl_products WHERE barcode LIKE '%" + keywords + "%'";// OR name LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            string sql2 = "Select name from tbl_products";// WHERE name LIKE '%" + keywords + "%'";// OR name LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter2 = new SqlDataAdapter(sql2, conn);
                            conn.Open();
                            adapter2.Fill(dt2);
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

                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString("0.00");
                                // this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                //this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;

                                double oldmdiscount = double.Parse(txtdiscount.Text);
                                double dsubtotal = double.Parse(txtsubtotal.Text);
                                double nsubtotal = ntotal + dsubtotal;
                                double newnet = nsubtotal - oldmdiscount;// - oldmdiscount;
                                dgvaddproduct.Update();
                                dgvaddproduct.Refresh();
                                txtsubtotal.Text = nsubtotal.ToString("0.00");
                                txtnetval.Text = newnet.ToString("0.00");
                                TransCalculations();
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
                                        //Do something here with these values
                                        // string sqlx = "Select barcode,name,qty,rate from tbl_products WHERE barcode LIKE '%" + val + "%'";
                                        // SQLiteDataAdapter adapterx = new SQLiteDataAdapter(sqlx, conn);
                                        //  conn.Open();
                                        //  adapterx.Fill(dt3);
                                        this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt3.Rows[0]["barcode"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt3.Rows[0]["name"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt3.Rows[0]["qty"].ToString();
                                        this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt3.Rows[0]["rate"].ToString();
                                        this.dgvaddproduct.Rows[rowIndex].Cells[2].Value = 1;

                                        string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                        string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[2].Value.ToString();
                                        double ntotal = double.Parse(uprice) * double.Parse(uqty);

                                        this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = ntotal.ToString("0.00");
                                        //  this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
                                        //  this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;

                                        double oldmdiscount = double.Parse(txtdiscount.Text);
                                        double dsubtotal = double.Parse(txtsubtotal.Text);
                                        double nsubtotal = ntotal + dsubtotal;
                                        double newnet = nsubtotal - oldmdiscount;
                                        dgvaddproduct.Update();
                                        dgvaddproduct.Refresh();
                                        txtsubtotal.Text = nsubtotal.ToString("0.00");
                                        txtnetval.Text = newnet.ToString("0.00");
                                        TransCalculations();
                                        //this.dgvaddproduct.Rows[currentRow].Cells[0].Value = val;
                                        //for example

                                    }
                                }

                            }
                            btnsave.Enabled = true;




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
                    int temp = 0;

                    if (string.IsNullOrEmpty(dgvaddproduct.Rows[rowIndex].Cells[3].Value as string))
                    {
                        MessageBox.Show("ادخل السعر!!!");
                        break;
                    }
                    else if (string.IsNullOrEmpty(dgvaddproduct.Rows[rowIndex].Cells[2].Value as string))
                    {
                        MessageBox.Show("ادخل الكمية!!!");
                        break;

                    }
                    else if (!int.TryParse(dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString(), out temp))
                    {

                        //    e.Cancel = true;
                        MessageBox.Show("must be numeric");
                    }
                    else
                    {


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
                        txtsubtotal.Text = newsubtotal1.ToString("0.00");
                        txtnetval.Text = newnetval1.ToString("0.00");
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
            DataTable dt = cmpdal.Select();
            string cyvat = dt.Rows[0]["vatval"].ToString();
            myvat = double.Parse(cyvat) / 100;

            dgvaddproduct.Update();
            dgvaddproduct.Refresh();

            double invnetval = double.Parse(txtsubtotal.Text);
            double findiscount = double.Parse(txtdiscount.Text);
            double fnetval = invnetval - findiscount;
            double nvat = fnetval * myvat;  // ((100+15)/100)*subtotal;
            double newtotal = fnetval + nvat;
            txtvat.Text = nvat.ToString("0.00");
            txtnetval.Text = fnetval.ToString("0.00");
            double mygrandtotalwithvat = newtotal; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString("0.00");

        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            double newdiscount2 = double.Parse(txtdiscount.Text);
            double newsub = double.Parse(txtsubtotal.Text);
            double nsub = double.Parse(txtnetval.Text);
            double nnetval = newsub - newdiscount2;
            txtnetval.Text = nnetval.ToString("0.00");
            TransCalculations();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            //double molddiscount = 0;
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();




            double olddiscount = double.Parse(txtdiscount.Text);

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);



            double subtotal = oldsubtotal - oldtotal;
            //   double discount = olddiscount - molddiscount;
            double nnetval = subtotal - olddiscount;
            txtsubtotal.Text = subtotal.ToString("0.00");
            // txtdiscount.Text = discount.ToString("0.00");
            txtnetval.Text = nnetval.ToString("0.00");

            double vat = nnetval * myvat;  // ((100+15)/100)*subtotal;
            txtvat.Text = vat.ToString();
            double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = grandtotalwithvat.ToString("0.00");
            dgvaddproduct.Rows.RemoveAt(rowIndex);







        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            con.Open();
            string sql = "INSERT INTO tmp_sales (trdate,description,branch,subtotal,vat,discount,grandtotal,paymethod,added_by,trtype,customer,returnno,status) VALUES(@trdate,@description,@branch,@subtotal,@vat,@discount,@grandtotal,@paymethod,@added_by,@trtype,@customer,@returnno,@status)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@trdate", DateTime.Now.ToString("yyy-MM-dd hh:mm:ss"));
            cmd.Parameters.AddWithValue("@description", txtdescription.Text);
            cmd.Parameters.AddWithValue("@branch", txtbranch.Text);
            cmd.Parameters.AddWithValue("@subtotal", txtsubtotal.Text);
            cmd.Parameters.AddWithValue("@vat", txtvat.Text);
            cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
            cmd.Parameters.AddWithValue("@grandtotal", txtgrandtotal.Text);
            cmd.Parameters.AddWithValue("@paymethod", txtpaymethod.Text);
            cmd.Parameters.AddWithValue("@customer", cmbcustomers.Text);
            cmd.Parameters.AddWithValue("@added_by", frmlogin.loggedin);
            cmd.Parameters.AddWithValue("@trtype", "Sales");
            cmd.Parameters.AddWithValue("@returnno", 0);
            cmd.Parameters.AddWithValue("@status", "0");

            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();

            string mysql1 = "select max(id) from tmp_sales";

            SqlCommand cmd2 = new SqlCommand(mysql1, con);
            var mytr = cmd2.ExecuteScalar();
            txtbillno.Text = mytr.ToString();
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
                    string msql = "insert into tmp_sdetail(trid,barcode,productid,productname,rate,qty,total) VALUES(@trid,@barcode,@productid,@productname,@rate,@qty,@total)";
                    SqlCommand cmd1 = new SqlCommand(msql, con);
                    cmd1.Parameters.AddWithValue("@trid", mytr);
                    //cmd1.Parameters.AddWithValue("@productid", );
                    cmd1.Parameters.AddWithValue("@barcode", dgvaddproduct.Rows[i].Cells[0].Value);
                    cmd1.Parameters.AddWithValue("@productid", mproductid);
                    cmd1.Parameters.AddWithValue("@productname", dgvaddproduct.Rows[i].Cells[1].Value);

                    cmd1.Parameters.AddWithValue("@rate", dgvaddproduct.Rows[i].Cells[3].Value);
                    cmd1.Parameters.AddWithValue("@qty", dgvaddproduct.Rows[i].Cells[2].Value);
                    cmd1.Parameters.AddWithValue("@total", dgvaddproduct.Rows[i].Cells[4].Value);
                    //cmd1.Parameters.AddWithValue("@discount", dgvaddproduct.Rows[i].Cells[5].Value);
                    //cmd1.Parameters.AddWithValue("@gtotal", dgvaddproduct.Rows[i].Cells[6].Value);

                    cmd1.ExecuteNonQuery();

                    con.Close();
                }
            }

            MessageBox.Show(msave);
            btnprnt.Enabled = true;
            btnprntA4.Enabled = true;



        }



        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public void frmClear()
        {
            this.Hide();
            frmsales main = new frmsales();
            main.Show();
        }

        private void frmproforma_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnprntA4_Click(object sender, EventArgs e)
        {

            //tablelayout frm = new tablelayout(txtbillno.Text);
            //frm.ShowDialog();

            DataTable dtc = GetCompanyData();
            if (dtc.Rows.Count == 0)
            {
                MessageBox.Show(compmess);
                return;
            }
            string compname = dtc.Rows[0]["cname"].ToString();
            string mcaddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;
            string reptitle = "فاتورة مبدئية";

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

            DateTime mdate = Convert.ToDateTime(trdate, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            // double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal - mdiscount;
            string gnetval = mnetval.ToString();




            DataTable dtcust = GetCustomer(mcust);
            if (dtcust.Rows.Count == 0)
            {
                MessageBox.Show(custmess);
                return;
            }
            string custname = dtcust.Rows[0]["name"].ToString();
            string custadd = dtcust.Rows[0]["address"].ToString();
            string custvat = dtcust.Rows[0]["vatno"].ToString();

            //********************
            String Seller = arname;
            String VatNo = cvatno;
            DateTime dTime = mdate;
            Double Total = Convert.ToDouble(gtotal);
            Double Tax = Convert.ToDouble(gvat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();
            //MessageBox.Show(mytotal);
            /*
            string Hexcode = text2hex(1, compname.Length, compname) + text2hex(2, cvatno.Length, cvatno) + text2hex(3, 20, mdate.ToString("yyyy-MM-ddTHH:mm:ssZ")) + text2hex(4, gtotal.Length, gtotal) + text2hex(5, gvat.Length, gvat);

            string enctext1 = HexToBase64(Hexcode);
            */

            //using QRcoder

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Base64txt, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("Q1.bmp");


            string imgpath = Path.GetFullPath("Q1.bmp");
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
            ReportParameter rp4 = new ReportParameter("compaddr", mcaddress);
            ReportParameter rp5 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp6 = new ReportParameter("description", mdescription);
            ReportParameter rp7 = new ReportParameter("invdate", trdate);
            ReportParameter rp8 = new ReportParameter("invno", invno);
            ReportParameter rp9 = new ReportParameter("payment", payment);
            ReportParameter rp10 = new ReportParameter("seller", adduser);

            //ReportParameter rp11 = new ReportParameter();// "qrcode",paramValue);
            //rp11.Name = "qrcode";
            //rp11.Values.Add(@"file:///" + imgpath);
            ReportParameter rp12 = new ReportParameter();
            rp12.Name = "logo";
            rp12.Values.Add(@"file:///" + clogo);

            ReportParameter rp13 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp14 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp15 = new ReportParameter("pnet", gnetval);
            ReportParameter rp16 = new ReportParameter("pvat", gvat);
            ReportParameter rp17 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp18 = new ReportParameter("arabicname", arname);
            ReportParameter rp19 = new ReportParameter("caddress", custadd);
            ReportParameter rp20 = new ReportParameter("reptitle", reptitle);
            

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\ProSalesRep.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp13, rp14, rp15, rp16, rp17, rp18, rp19,rp20 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllsales();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //report.DataSource = dt;

            //for (int i = 0; i < printQty; i++)
            //{
            PrintToPrinter(report);
            //}



            frmClear();



        }
        public DataTable GetSalesData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tmp_sales where id='" + txtbillno.Text + "'";

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

                string mysql = "select productname,sum(qty) as qty ,rate,rate*sum(qty) as total from tmp_sdetail where trid='" + txtbillno.Text + "' GROUP BY productname";

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

        private void button4_Click(object sender, EventArgs e)
        {
            frmClear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmproview proview = new frmproview();
            proview.Show();
        }

        private void cmbcustomers_SelectedIndexChanged(object sender, EventArgs e)
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
            suppacct.Text = dc.acctcode;
        }

        private void btnprnt_Click(object sender, EventArgs e)
        {

            string compname, caddress, arname, cvatno, clogo, cvatno2, custname = "";


            DataTable dtc = GetCompanyData();
            if (dtc.Rows.Count > 0)
            {
                compname = dtc.Rows[0]["cname"].ToString();
                caddress = dtc.Rows[0]["caddress"].ToString();
                arname = dtc.Rows[0]["aname"].ToString();
                cvatno = dtc.Rows[0]["cvatno"].ToString();
                clogo = dtc.Rows[0]["clogo"].ToString();

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
            //double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal - mdiscount;
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
            DateTime dTime = mdate;
            Double Total = Convert.ToDouble(gtotal);
            Double Tax = Convert.ToDouble(gvat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();
            //MessageBox.Show(mytotal);

            //using QRcoder

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(Base64txt, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("Q1.bmp");




            string imgpath = Path.GetFullPath("Q1.bmp");



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
            ReportParameter rp4 = new ReportParameter("compaddr", caddress);
            ReportParameter rp5 = new ReportParameter("cvatnumber", custvat);
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
            //DisposePrint();

            frmClear();

        }

        private void dgvaddproduct_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnremove.Enabled = true;
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

            /*
             foreach (string file in _emfFiles)
        {
            if (File.Exists(file))
                File.Delete(file);
        }
            */
        }
        public DataTable DisplayAllsales()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.productname As name,sum(qty) as qty,rate as rate, sum(b.total) as total from tmp_sales a,tmp_sdetail b where b.trid=a.id and a.id='" + txtbillno.Text + "' group by b.productid";
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

        private void salesdetailBLLBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            DataTable dt = DisplayAllsales();
            //salesdetailBLLBindingSource.DataSource = dt;

        }


    }
}

