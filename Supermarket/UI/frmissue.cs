using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Supermarket.DAL;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmissue : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmissue()
        {
            InitializeComponent();
        }

        acctsDAL dcdal = new acctsDAL();
        itemsDAL pdal = new itemsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
       
        private bool isComboBoxBound = false;
        string mitemname = "";
        
        string trtype = "Issue";

        private void frmissue_Load(object sender, EventArgs e)
        {
            //transaction data table
            transactiondt.Columns.Add("Product ID");
            transactiondt.Columns.Add("Product Name");
            transactiondt.Columns.Add("Qty");
            transactiondt.Columns.Add("Price");
            transactiondt.Columns.Add("Total");

            dgvaddproduct.DataSource = transactiondt;
            //txtsubtotal.Text = subtotal.ToString();

            
            SqlConnection conn = new SqlConnection(myconnstrng);

           string sql2 = "Select * from tbl_items";

            SqlCommand cmd1 = new SqlCommand(sql2, conn);
            SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();

            da1.Fill(ds1, "tbl_items");

            cmbitem.DataSource = ds1.Tables["tbl_items"];
            cmbitem.SelectedIndex = -1;

            cmbitem.DisplayMember = "name";

            cmbitem.ValueMember = "id";
            isComboBoxBound = true;


        }

        private void cmbitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isComboBoxBound)
            {

                string mtest = this.cmbitem.SelectedValue.ToString();
                //txtinventory.Text =mtest;
                //MessageBox.Show(mtest);
                string mysql3 = "select name,qtyhand,price from tbl_items where id='" + mtest + "'";
                SqlConnection con = new SqlConnection(myconnstrng);
                con.Open();

                SqlCommand cmd3 = new SqlCommand(mysql3, con);
                SqlDataAdapter da = new SqlDataAdapter(mysql3, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;
                txtinventory.Text = dt.Rows[0]["qtyhand"].ToString();
                mitemname = dt.Rows[0]["name"].ToString();
                txtrate.Text= dt.Rows[0]["price"].ToString();
                con.Close();

            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string product_id = cmbitem.SelectedValue.ToString();
            string productname = mitemname;
            decimal rate = decimal.Parse(txtrate.Text);
            decimal qty = decimal.Parse(txtqty.Text);
            decimal total = rate * qty;
            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;




            transactiondt.Rows.Add(product_id, productname, rate, qty, total);
            dgvaddproduct.DataSource = transactiondt;
            txtsubtotal.Text = subtotal.ToString();
            
            


            txtinventory.Text = "0.00";
            txtrate.Text = "0.00";
            txtqty.Text = "0.00";


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            con.Open();
            string sql = "INSERT INTO tbl_purchase (trdate,dealer,invno,invdate,subtotal,vat,discount,gtotal,added_by,trtype) VALUES(@trdate,@dealer,@invno,@invdate,@subtotal,@vat,@discount,@gtotal,@added_by,@trtype)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@trdate", DateTime.Now);
            cmd.Parameters.AddWithValue("@dealer", "Issue");
            cmd.Parameters.AddWithValue("@invno", "");
            cmd.Parameters.AddWithValue("@invdate", "");
            cmd.Parameters.AddWithValue("@subtotal", txtsubtotal.Text);
            cmd.Parameters.AddWithValue("@vat", 0);
            cmd.Parameters.AddWithValue("@discount", 0);
            cmd.Parameters.AddWithValue("@gtotal", txtsubtotal.Text);
            cmd.Parameters.AddWithValue("@added_by", frmlogin.loggedin);
            cmd.Parameters.AddWithValue("@trtype", trtype);

            cmd.ExecuteNonQuery();
            con.Close();

            con.Open();

            string mysql1 = "select max(id) from tbl_purchase";

            SqlCommand cmd2 = new SqlCommand(mysql1, con);
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



            for (int i = 0; i < dgvaddproduct.Rows.Count - 1; i++)
            {

                con.Open();
                string msql = "insert into tbl_purchaseitems(trid,itemid,itemname,itemqty,itemprice,itemtotal) VALUES(@trid,@itemid,@itemname,@itemqty,@itemprice,@itemtotal)";
                SqlCommand cmd1 = new SqlCommand(msql, con);
                cmd1.Parameters.AddWithValue("@itemid", dgvaddproduct.Rows[i].Cells[0].Value);
                cmd1.Parameters.AddWithValue("@itemname", dgvaddproduct.Rows[i].Cells[1].Value);
                cmd1.Parameters.AddWithValue("@itemqty", dgvaddproduct.Rows[i].Cells[2].Value);
                cmd1.Parameters.AddWithValue("@itemprice", dgvaddproduct.Rows[i].Cells[3].Value);
                cmd1.Parameters.AddWithValue("@itemtotal", dgvaddproduct.Rows[i].Cells[4].Value);
                cmd1.Parameters.AddWithValue("@trid", mytr);
                cmd1.ExecuteNonQuery();
                var mproductid = dgvaddproduct.Rows[i].Cells[0].Value;

                int MyPid = Convert.ToInt32(mproductid);
                var pqty = dgvaddproduct.Rows[i].Cells[2].Value;
                var mrate = dgvaddproduct.Rows[i].Cells[3].Value;
                decimal rate = Convert.ToDecimal(mrate);
                decimal Mpqty = Convert.ToDecimal(pqty);
                //MessageBox.Show("Product id   " + MyPid);
                decimal Qty_hand = pdal.GetitemtQty(MyPid);
                //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                //*************************Update inventory values ***********



                bool x = false;

                x = pdal.DecreaseProduct(MyPid, Mpqty, Qty_hand, rate);


                con.Close();
            }

            // Printing invoice
            prntPreview.Document = prntdoc;
            prntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            prntPreview.ShowDialog();
            //finish printing

            MessageBox.Show("Successfully Added", "VINSMOKE MJ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvaddproduct.DataSource = null;
            dgvaddproduct.Rows.Clear();

            txtinvdate.Text = "";
            


            txtinventory.Text = "0";
            txtrate.Text = "0";
            txtqty.Text = "0";
            txtsubtotal.Text = "0";
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void prntdoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string mdate = DateTime.Today.Year.ToString();
           

            e.Graphics.DrawString("Issue Date:"+ txtinvdate.Value.ToString("dd-mm-yyyy"), new Font("calibri", 12, FontStyle.Bold), Brushes.Black, new Point(10, 10));
            

            e.Graphics.DrawString("ID  Name                  Qty     Unit Price   Total", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(10, 80));
            int j = 100;
            for (int i = 0; i < dgvaddproduct.Rows.Count - 1; i++)
            {

                string mpid = dgvaddproduct.Rows[i].Cells[0].Value.ToString();
                string mpname = dgvaddproduct.Rows[i].Cells[1].Value.ToString();
                string mqty = dgvaddproduct.Rows[i].Cells[2].Value.ToString();
                string mrate = dgvaddproduct.Rows[i].Cells[3].Value.ToString();
                string mtotal = dgvaddproduct.Rows[i].Cells[4].Value.ToString();
                e.Graphics.DrawString(mpid, new Font("arial", 10), Brushes.Black, new Point(10, j));
                e.Graphics.DrawString(mpname, new Font("arial", 10), Brushes.Black, new Point(30, j));
                e.Graphics.DrawString(mqty, new Font("arial", 10), Brushes.Black, new Point(130, j));
                e.Graphics.DrawString(mrate, new Font("arial", 10), Brushes.Black, new Point(180, j));
                e.Graphics.DrawString(mtotal, new Font("arial", 10), Brushes.Black, new Point(240, j));

                j = j + 20;
            }
            e.Graphics.DrawString("Total", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(120, j));
            e.Graphics.DrawString(txtsubtotal.Text, new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(220, j));
            



        }

        private void button1_Click(object sender, EventArgs e)
        {
            prntPreview.Document = prntdoc;
            prntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            prntPreview.ShowDialog();
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells["total"].Value.ToString();

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);

            double subtotal = oldsubtotal - oldtotal;

            txtsubtotal.Text = subtotal.ToString();
            
            dgvaddproduct.Rows.RemoveAt(rowIndex);

        }
    }
}
