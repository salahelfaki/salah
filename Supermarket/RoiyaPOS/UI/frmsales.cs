using DGVPrinterHelper;
using MySql.Data.MySqlClient;
using supermarket.BLL;
using supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace supermarket.UI
{
    public partial class frmsales : Form
    {
        public frmsales()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        deacustDAL dcdal = new deacustDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        transactionDAL tdal = new transactionDAL();
        transactiondetailDAL tddal = new transactiondetailDAL();


        private void frmsales_Load(object sender, EventArgs e)
        {
            //string type = frmUserdashboard.transactontype;
            lblfrm.Text = "Sales";
            //transaction data table
            transactiondt.Columns.Add("Product ID");
            transactiondt.Columns.Add("Product Name");
            transactiondt.Columns.Add("Rate");
            transactiondt.Columns.Add("Qty");
            transactiondt.Columns.Add("Total");

            //===
            int product_id = 0;
            string productname = "";// txtpname.Text;
            decimal rate = 0;// decimal.Parse(txtrate.Text);
            decimal qty = 0;// decimal.Parse(txtqty.Text);
            decimal total = rate * qty;
            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;

            transactiondt.Rows.Add(product_id, productname, rate, qty, total);
            dgvaddproduct.DataSource = transactiondt;
            txtsubtotal.Text = subtotal.ToString();

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords == "")
            {
                txtcustid.Text = "";
                txtname.Text = "";
                txtemail.Text = "";
                txtcontact.Text = "";
                txtaddress.Text = "";
                return;


            }
            deacustBLL dc = dcdal.searchdealercustomerfortransaction(keywords);
            txtcustid.Text = dc.id.ToString();
            txtname.Text = dc.name;
            txtemail.Text = dc.email;
            txtcontact.Text = dc.contact;
            txtaddress.Text = dc.address;

        }

   /*     private void txtpsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtpsearch.Text;
            if (keyword == "")
            {
                txtpid.Text = "";
                txtpname.Text = "";
                txtinventory.Text = "";
                txtrate.Text = "";
                txtqty.Text = "";
                return;

            }
            productsBLL p = pdal.GetproductForTransaction(keyword);
            txtpid.Text = p.id.ToString();
            txtpname.Text = p.name;
            txtinventory.Text = p.qty.ToString();
            txtrate.Text = p.rate.ToString();

            //add to grid
            int product_id = int.Parse(txtpid.Text);
            string productname = txtpname.Text;
            decimal rate = decimal.Parse(txtrate.Text);
            decimal qty = 1; // decimal.Parse(txtqty.Text);
            decimal total = rate * qty;
            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;

            if (productname == "")
            {
                MessageBox.Show("Select the Product First. Try again");
            }
            else
            {
                transactiondt.Rows.Add(product_id, productname, rate, qty, total);
                dgvaddproduct.DataSource = transactiondt;
                txtsubtotal.Text = subtotal.ToString();

                txtpsearch.Text = "";
                txtpname.Text = "";
                txtinventory.Text = "0.00";
                txtrate.Text = "0.00";
                txtqty.Text = "0.00";
            }


        }*/

        private void btnadd_Click(object sender, EventArgs e)
        {
            int product_id = int.Parse(txtpid.Text);
            string productname = txtpname.Text;
            decimal rate = decimal.Parse(txtrate.Text);
            decimal qty = decimal.Parse(txtqty.Text);
            decimal total = rate * qty;
            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;

            if (productname == "")
            {
                MessageBox.Show("Select the Product First. Try again");
            }
            else
            {
                transactiondt.Rows.Add(product_id,productname, rate, qty, total);
                dgvaddproduct.DataSource = transactiondt;
                txtsubtotal.Text = subtotal.ToString();

                txtpsearch.Text = "";
                txtpname.Text = "";
                txtinventory.Text = "0.00";
                txtrate.Text = "0.00";
                txtqty.Text = "0.00";
            }

        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            string value = txtdiscount.Text;
            if (value == "")
            {
                MessageBox.Show("Add Discount first");
            }
            else
            {
                decimal subtotal = decimal.Parse(txtsubtotal.Text);
                decimal discount = decimal.Parse(txtdiscount.Text);
                decimal grandtotal = ((100 - discount) / 100) * subtotal;
                txtgrandtotal.Text = grandtotal.ToString();
            }
        }

        private void txtvat_TextChanged(object sender, EventArgs e)
        {
            
            string check = txtgrandtotal.Text;
            if (check == "")
            {
                MessageBox.Show("Calacualte the Discount first");
            }
            else
            {
                decimal prevgrand = decimal.Parse(txtgrandtotal.Text);
                decimal vat = decimal.Parse(txtvat.Text);
                decimal grandtotalwithvat = ((100 + vat) / 100) * prevgrand;
                txtgrandtotal.Text = grandtotalwithvat.ToString();

            }
        }

        private void txtpaid_TextChanged(object sender, EventArgs e)
        {
            decimal grandtotal = decimal.Parse(txtgrandtotal.Text);
            decimal paidamount = decimal.Parse(txtpaid.Text);
            decimal returnamount = paidamount - grandtotal;
            txtreturn.Text = returnamount.ToString();


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("datasource= localhost; database=supermarket;port=3306; username = root; password= P@ssw0rd");
            con.Open();
            string sql = "INSERT INTO tbl_transactions (type, dea_cust_id,grandtotal, transaction_date,subtotal, tax, discount,added_by,added_date) VALUES(@type, @dea_cust_id,@grandtotal, @transaction_date,@subtotal, @tax, @discount,@added_by,@added_date)";
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@type", lblfrm.Text);
            cmd.Parameters.AddWithValue("@dea_cust_id", txtcustid.Text);
            cmd.Parameters.AddWithValue("@grandtotal", txtgrandtotal.Text);
            cmd.Parameters.AddWithValue("@transaction_date", DateTime.Now);
            cmd.Parameters.AddWithValue("@subtotal", txtsubtotal.Text);
            cmd.Parameters.AddWithValue("@tax", txtvat.Text);
            cmd.Parameters.AddWithValue("@discount", txtdiscount.Text);
            cmd.Parameters.AddWithValue("@added_by", frmlogin.loggedin);
            cmd.Parameters.AddWithValue("@added_date", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();

            string mysql1 = "select max(id) from tbl_transactions";
            
            MySqlCommand cmd2 = new MySqlCommand(mysql1, con);
            var mytr = cmd2.ExecuteScalar();
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



            for (int i = 0; i < dgvaddproduct.Rows.Count-1; i++)
        {
            //MySqlConnection con = new MySqlConnection("datasource= localhost; database=sampledb;port=3306; username = root; password= db1234");
            con.Open();
                string msql = "insert into tbl_detail(product_id,productname,rate,qty,transaction_id) VALUES(@product_id,@productname,@rate,@qty,@transaction_id)";
                MySqlCommand cmd1 = new MySqlCommand(msql, con);
                cmd1.Parameters.AddWithValue("@product_id", dgvaddproduct.Rows[i].Cells[0].Value);
                cmd1.Parameters.AddWithValue("@productname", dgvaddproduct.Rows[i].Cells[1].Value);
                cmd1.Parameters.AddWithValue("@rate", dgvaddproduct.Rows[i].Cells[2].Value);
                cmd1.Parameters.AddWithValue("@qty", dgvaddproduct.Rows[i].Cells[3].Value);
                cmd1.Parameters.AddWithValue("@transaction_id", mytr);
                cmd1.ExecuteNonQuery();
                var mproductid =dgvaddproduct.Rows[i].Cells[0].Value;
                
                int MyPid = Convert.ToInt32(mproductid);
                var pqty = dgvaddproduct.Rows[i].Cells[3].Value;
                decimal Mpqty = Convert.ToDecimal(pqty);
                //MessageBox.Show("Product id   " + MyPid);
               decimal Qty_hand = pdal.GetProductQty(MyPid);
                //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand);
                //*************************Update inventory values ***********


                string transactionType = lblfrm.Text;
                bool x = false;
                if (transactionType == "Purchase")
                {
                   x=pdal.IncreaseProdcuct(MyPid, Mpqty,Qty_hand);
                    
                }
                else if (transactionType == "Sales")
                {
                   x=pdal.DecreaseProduct(MyPid,Mpqty, Qty_hand);
                   
                }
                //**********************
                
                con.Close();
        }
            //printing bill
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "\r\n\r\n RoiyaSoft \r\n\r\n";
            printer.SubTitle = "Oliya - Alkhaleej \r\n Phone: 9662152169 \r\n\r\n";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Discount" + txtdiscount.Text + "% \r\n" + "VAT: " + txtvat.Text + "% \r\n" + "Grand Total: " + txtgrandtotal.Text + "\r\n\r\n" + "Thank you for doing business with us";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvaddproduct);





        MessageBox.Show("Successfully Added", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvaddproduct.DataSource = null;
            dgvaddproduct.Rows.Clear();
            txtsearch.Text = "";
            txtname.Text = "";
            txtemail.Text = "";
            txtcontact.Text = "";
            txtaddress.Text = "";
            txtpsearch.Text = "";
            txtpname.Text = "";
            txtinventory.Text = "0";
            txtrate.Text = "0";
            txtqty.Text = "0";
            txtsubtotal.Text = "0";
            txtdiscount.Text = "0";
            txtvat.Text = "0";
            txtgrandtotal.Text = "0";
            txtpaid.Text = "0";
            txtreturn.Text = "0";
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Calibri", 12);
            float fontweight = font.GetHeight();
            int startx = 190;
            int starty = 40;
            int offset = 20;
            float leftmargin = e.MarginBounds.Left;
            float topmargin = e.MarginBounds.Top;
            graphics.DrawString("Welcome TO Any Store", new Font("Calibri new", 20), new SolidBrush(Color.Black), startx, starty);
            string top = "Date: " + dtpbilldate.Text.PadRight(0);
            offset = offset + 20;
            graphics.DrawString(top, font, new SolidBrush(Color.Black), startx, starty+offset);
            offset = offset + (int)FontHeight;
            graphics.DrawString("-----------------------------------------------------", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 30;
            graphics.DrawString("Items\t\t      Price \t  Qty\tTotal", font,new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 30;
            for(int x=0;x< dgvaddproduct.RowCount; x++)
            {
                graphics.DrawString(dgvaddproduct.Rows[x].Cells[1].Value+"\t\t"+ dgvaddproduct.Rows[x].Cells[2].Value +"\t    "+ dgvaddproduct.Rows[x].Cells[3].Value +"\t"+ dgvaddproduct.Rows[x].Cells[4].Value +"\t", new Font("Calibri", 10), new SolidBrush(Color.Black), startx, starty+offset);
                offset = offset + 20;
            }
            offset = offset + (int)FontHeight+5;
            graphics.DrawString("-----------------------------------------------------", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 15;
           graphics.DrawString("Sub Total    "+txtsubtotal.Text, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("Discount    " + txtdiscount.Text, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("VAT    " + txtvat.Text, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("Grand Total     " + txtgrandtotal.Text + ".00", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("Paid Amount    " + txtpaid.Text, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("Return Amount    " + txtreturn.Text, font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 20;
            graphics.DrawString("-----------------------------------------------------", font, new SolidBrush(Color.Black), startx, starty + offset);
            offset = offset + 15;
            graphics.DrawString("Thanks for your visit", font, new SolidBrush(Color.Black), startx, starty + offset);
          







        }

        private void button1_Click(object sender, EventArgs e)
        {
            prntDialog.Document = prntdoc;
            DialogResult result = prntDialog.ShowDialog();
            if(result==DialogResult.OK)
            {
                prntdoc.Print();
            }
        }

        private void txtpsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string keyword = txtpsearch.Text;
                if (keyword == "")
                {
                    txtpid.Text = "";
                    txtpname.Text = "";
                    txtinventory.Text = "";
                    txtrate.Text = "";
                    txtqty.Text = "";
                    return;

                }
                productsBLL p = pdal.GetproductForTransaction(keyword);
                txtpid.Text = p.id.ToString();
                txtpname.Text = p.name;
                txtinventory.Text = p.qty.ToString();
                txtrate.Text = p.rate.ToString();

                //add to grid
                int product_id = int.Parse(txtpid.Text);
                string productname = txtpname.Text;
                decimal rate = decimal.Parse(txtrate.Text);
                decimal qty = 1; // decimal.Parse(txtqty.Text);
                decimal total = rate * qty;
                decimal subtotal = decimal.Parse(txtsubtotal.Text);
                subtotal = subtotal + total;

                if (productname == "")
                {
                    MessageBox.Show("Select the Product First. Try again");
                }
                else
                {
                    transactiondt.Rows.Add(product_id, productname, rate, qty, total);
                    dgvaddproduct.DataSource = transactiondt;
                    txtsubtotal.Text = subtotal.ToString();

                    txtpsearch.Text = "";
                    txtpname.Text = "";
                    txtinventory.Text = "0.00";
                    txtrate.Text = "0.00";
                    txtqty.Text = "0.00";
                }


            }
        }

        private void txtpsearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

        

