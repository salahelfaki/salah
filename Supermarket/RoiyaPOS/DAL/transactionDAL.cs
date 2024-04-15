using MySql.Data.MySqlClient;
using supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket.DAL
{
    class transactionDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Insert Transaction Method
        public bool insert_transaction(transactionBLL t, out int transactionID)
        {
            bool isSuccess = false;
            transactionID = -1;
            MySqlConnection conn = new MySqlConnection(myconnstrng);


            try
            {
                string sql = "INSERT INTO tbl_transactions (type, dea_cust_id,grandtotal, transaction_date, tax, discount,added_by) VALUES(@type, @dea_cust_id,@grandtotal, @transaction_date, @tax, @discount,@added_by)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", t.type);
                cmd.Parameters.AddWithValue("@dea_cust_id", t.dea_cust_id);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@transaction_date", t.transaction_date);
                cmd.Parameters.AddWithValue("@tax", t.tax);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);

                conn.Open();
                object o = cmd.ExecuteScalar();
                if(o != null)
                {
                    transactionID = int.Parse(o.ToString());
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
            return isSuccess;
        }
        #endregion
        #region Method to display all transactions
        public DataTable DisplayAllTransactions()
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * from tbl_transactions";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt); 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            return dt;
        }
        #endregion
        #region Method to display Transaction Based on Transaction type
        public DataTable DisplayTransactionbyType(string type)
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql ="SELECT * from tbl_transactions where type='"+type+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        #endregion


    }
}
