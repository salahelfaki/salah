using Supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.DAL
{

    class dexpenseDAL
    {
        public string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            string tdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From tbl_dexpense where edate='" + tdate + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;




        }
        #endregion
        #region Insert new Item
        public bool insert(dexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_dexpense(edate,description,amount,trtype) VALUES (@edate,@description,@amount,@trtype)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@edate", c.edate);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@amount", c.amount);
                cmd.Parameters.AddWithValue("@trtype", "");



                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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

            return isSuccess;
        }
        #endregion
        #region Update Method
        public bool update(dexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_dexpense SET edate=@edate, description=@description,amount=@amount where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@edate", c.edate);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@amount", c.amount);
                //cmd.Parameters.AddWithValue("@trtype", c.trtype);
                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }
        #endregion
        #region Delete Method
        public bool delete(dexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_dexpense Where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", c.id);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
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
            return isSuccess;
        }
        #endregion
        #region Search
        public DataTable Search(string keywords)
        {
            string tdate = DateTime.Parse(keywords).ToString("yyyy-MM-dd");

            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_dexpense WHERE edate='" + tdate + "' ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                con.Close();

            }
            return dt;

        }
        #endregion
        #region Method to search for items in Transaction Module

        public itemsBLL GetitemForTransaction(string keyword)
        {
            itemsBLL p = new itemsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select id,name,rate from tbl_items WHERE name LIKE '%" + keyword + "%' ";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.name = dt.Rows[0]["name"].ToString();
                    p.qtyhand = decimal.Parse(dt.Rows[0]["qtyhand"].ToString());
                    p.price = decimal.Parse(dt.Rows[0]["price"].ToString());


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
            return p;


        }
        #endregion
        #region Method to get item id based on name
        public itemsBLL getitemidfromname(string itemname)
        {
            itemsBLL p = new itemsBLL();
            SqlConnection con1 = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect id from tbl_items where name='" + itemname + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con1);
                con1.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return p;
        }
        #endregion
        #region Method to get Current qty from database
        public decimal GetitemtQty(int ProductID)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            decimal qty = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT qtyhand from tbl_items where id=" + ProductID;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qtyhand"].ToString());
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
            return qty;
        }
        #endregion
        #region Method to update qty
        public bool UpdateQty(int ProductID, decimal Qty, decimal rate)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_items set qtyhand=@qtyhand, price=@price where id=@id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qtyhand", Qty);
                cmd.Parameters.AddWithValue("@price", rate);
                cmd.Parameters.AddWithValue("@id", ProductID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                    //MessageBox.Show("Updated successfully");

                }
                else
                {
                    success = false;
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
            return success;

        }
        #endregion
        #region Method increase product
        public bool IncreaseProdcuct(int ProductID, decimal IncreaseQty, decimal currentQty, decimal rate)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                //MessageBox.Show("Product Id  " + ProductID + "New Qty= " + NewQty);
                success = UpdateQty(ProductID, NewQty, rate);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion
        #region Method to decrease product qty
        public bool DecreaseProduct(int ProductID, decimal Qty, decimal currentQty, decimal rate)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty - Qty;
                success = UpdateQty(ProductID, NewQty, rate);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;
        }
        #endregion
        #region To Get  Daily expenses All
        public DataTable GetDailyExpenseAll()
        {
            string tdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {

                string sql = "Select edate as date,description,amount From tbl_dexpense";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;

        }

        #endregion
        #region To Get  Daily expenses by Date
        public DataTable GetDailyExpense(string sdate, string edate)
        {
            string tdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select edate as date,description,amount From tbl_dexpense where convert(char(10),edate,120)>=@sdate  AND convert(char(10),edate,120)<=@edate";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con.Open();

                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;




        }

        #endregion
    }
}
