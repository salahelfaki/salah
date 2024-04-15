using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmcleardata : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmcleardata()
        {
            InitializeComponent();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (checkcateg.Checked)
            {
                delcateg();
                MessageBox.Show("Categories Deleted Successfully");
            }
            if (checkproducts.Checked)
            {
                delproduct();
                MessageBox.Show("Products Deleted Successfully");
            }
            if (checkSales.Checked)
            {
                delsales();
                MessageBox.Show("Transactions Deleted Successfully");
            }
            if (checkcustomers.Checked)
            {
                delcustomers();
                MessageBox.Show("Customers Deleted Successfully");
            }
            if (checkpurchase.Checked)
            {
                delpurchase();
                MessageBox.Show("Purchases Deleted Successfully");
            }
            if (checkpayment.Checked)
            {
                delpayment();
                MessageBox.Show("Payments Deleted Successfully");
            }
            if (checkcrnote.Checked)
            {
                delcrnote();
                MessageBox.Show("CR Notes Deleted Successfully");
            }
            if (checkexpense.Checked)
            {
                delexpense();
                MessageBox.Show("Daily Expenses Deleted Successfully");
            }
            if (checkmexpense.Checked)
            {
                delmexpense();
                MessageBox.Show("Monthly Expenses Deleted Successfully");
            }
            if (chktables.Checked)
            {
                cleartables();
                MessageBox.Show("Tables Cleared Successfully");
            }


        }
        // public bool delete(categoriesBLL c)
        public void delcateg()

        {
            //bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "truncate tbl_Categories";
                string sql1 = "DBCC CHECKIDENT(tbl_categories, RESEED, 0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                //DbContext.ExecuteCommand("TRUNCATE TABLE <tableName>");
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }

        public void delcustomers()

        {

            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_deacust";
                string sql1 = "DBCC CHECKIDENT(tbl_deacust, RESEED, 0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }


        public void delproduct()

        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_products";
                string sql1 = "DBCC CHECKIDENT(tbl_products, RESEED, 0)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }

        public void cleartables()
        {
            /*
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql10 = "DELETE From tbl_tempsales";
                string sql9 = "DELETE From tbl_tempdetails";
                string sql11 = "DELETE From tbl_temporders";
                string sql13 = "DBCC CHECKIDENT(tbl_tempsales, RESEED, 0)";
                string sql12 = "DBCC CHECKIDENT(tbl_tempdetails, RESEED, 0)";
                string sql14 = "DBCC CHECKIDENT(tbl_temporders, RESEED, 0)";
               // string sql15 = "update tbl_sales set paymethod='بطاقة' where paymethod='بطاقة ائتمانية'";
                SqlCommand cmd9 = new SqlCommand(sql9, conn);
                SqlCommand cmd10 = new SqlCommand(sql10, conn);
                SqlCommand cmd11 = new SqlCommand(sql11, conn);
                SqlCommand cmd12 = new SqlCommand(sql12, conn);
                SqlCommand cmd13 = new SqlCommand(sql13, conn);
                SqlCommand cmd14 = new SqlCommand(sql14, conn);
                //SqlCommand cmd15 = new SqlCommand(sql15, conn);

                conn.Open();
                cmd9.ExecuteNonQuery();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();
                cmd12.ExecuteNonQuery();
                cmd13.ExecuteNonQuery();
                cmd14.ExecuteNonQuery();
                //cmd15.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
            */
        }

    public void delsales()

        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_sales";
                string sql1 = "DELETE From tbl_sdetail";
                string sql2 = "DELETE From tbl_accttr where trtype='1' OR trtype='2'";
                string sql3 = "DELETE From tbl_sessions";
                //string sql4 = "DELETE From tbl_orders";

                string sql5= "DBCC CHECKIDENT(tbl_sales, RESEED, 0)";
                string sql6 = "DBCC CHECKIDENT(tbl_sdetail, RESEED, 0)";
                string sql7 = "DBCC CHECKIDENT(tbl_sessions, RESEED, 0)";
                //string sql8 = "DBCC CHECKIDENT(tbl_orders, RESEED, 0)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                //SqlCommand cmd4 = new SqlCommand(sql4, conn);
                SqlCommand cmd5 = new SqlCommand(sql5, conn);
                SqlCommand cmd6 = new SqlCommand(sql6, conn);
                SqlCommand cmd7 = new SqlCommand(sql7, conn);
                //SqlCommand cmd8 = new SqlCommand(sql8, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                //cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();
               // cmd8.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }
        private void delpurchase()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {

                string sql5 = "DELETE From tbl_accttr where trtype='3' OR trtype='4'";
                string sql3 = "DELETE From tbl_purchase";
                string sql4 = "DELETE From tbl_purchaseitems";

                string sql6 = "DBCC CHECKIDENT(tbl_purchase, RESEED, 0)";
                string sql7 = "DBCC CHECKIDENT(tbl_purchaseitems, RESEED, 0)";

                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                SqlCommand cmd5 = new SqlCommand(sql5, conn);
                SqlCommand cmd6 = new SqlCommand(sql6, conn);
                SqlCommand cmd7 = new SqlCommand(sql7, conn);

                conn.Open();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
                cmd5.ExecuteNonQuery();
                cmd6.ExecuteNonQuery();
                cmd7.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }
        private void delexpense()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //string sql7 = "DELETE From tbl_dexpense";
                string sql8 = "DELETE From tbl_accttr where trtype='8'";
                //string sql9 = "DBCC CHECKIDENT(tbl_dexpense, RESEED, 0)";

                //SqlCommand cmd7 = new SqlCommand(sql7, conn);
                SqlCommand cmd8 = new SqlCommand(sql8, conn);
                //SqlCommand cmd9 = new SqlCommand(sql9, conn);

                conn.Open();
                //cmd7.ExecuteNonQuery();
                cmd8.ExecuteNonQuery();
                //cmd9.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }
        private void delmexpense()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql13 = "DELETE From tbl_accttr where trtype='7'";

                SqlCommand cmd13 = new SqlCommand(sql13, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();

                cmd13.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
            /*
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql10 = "DELETE From tbl_mexpense";

                string sql11 = "DBCC CHECKIDENT(tbl_mexpense, RESEED, 0)";
                SqlCommand cmd10 = new SqlCommand(sql10, conn);
                SqlCommand cmd11 = new SqlCommand(sql11, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                cmd10.ExecuteNonQuery();
                cmd11.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
            */
        }
        private void delcrnote()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql12 = "DELETE From tbl_accttr where trtype='6'";

                SqlCommand cmd12 = new SqlCommand(sql12, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();

                cmd12.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }
        private void delpayment()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql13 = "DELETE From tbl_accttr where trtype='5'";

                SqlCommand cmd13 = new SqlCommand(sql13, conn);
                //cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();

                cmd13.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkcateg_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chktables_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
