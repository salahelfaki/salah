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
    class mexpenseDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select(string mmonth, string myear)
        {

            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select id,salary,electricity,rent,water,others,total,month,year From tbl_mexpense where month='" + mmonth + "' AND year='" + myear + "'";
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
        public bool insert(mexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_mexpense(edate,electricity,rent,water,others,total,salary,month,year) VALUES (@edate,@electricity,@rent,@water,@others,@total,@salary,@month,@year)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@edate", c.edate);
                cmd.Parameters.AddWithValue("@electricity", c.electricity);
                cmd.Parameters.AddWithValue("@rent", c.rent);
                cmd.Parameters.AddWithValue("@water", c.water);
                cmd.Parameters.AddWithValue("@others", c.others);
                cmd.Parameters.AddWithValue("@total", c.total);
                cmd.Parameters.AddWithValue("@salary", c.salary);
                cmd.Parameters.AddWithValue("@month", c.month);
                cmd.Parameters.AddWithValue("@year", c.year);




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
        public bool update(mexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_mexpense SET edate=@edate, electricity=@electricity,rent=@rent,water=@water,others=@others,total=@total,salary=@salary,month=@month,year=@year where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@edate", c.edate);
                cmd.Parameters.AddWithValue("@electricity", c.electricity);
                cmd.Parameters.AddWithValue("@rent", c.rent);
                cmd.Parameters.AddWithValue("@water", c.water);
                cmd.Parameters.AddWithValue("@others", c.others);
                cmd.Parameters.AddWithValue("@total", c.total);
                cmd.Parameters.AddWithValue("@salary", c.salary);
                cmd.Parameters.AddWithValue("@month", c.month);
                cmd.Parameters.AddWithValue("@year", c.year);

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
        public bool delete(mexpenseBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_mexpense Where id=@id";
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
                string sql = "Select * from tbl_mexpense WHERE edate='" + tdate + "' ";
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
        #region To Get  Monthly expenses All
        public DataTable GetMonthlyExpenseAll()
        {
            string tdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select edate as date,electricity,rent,water,salary,others From tbl_mexpense";
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
        #region To Get  mONTHLY expenses by Date
        public DataTable GetMonthlyExpense(string sdate, string edate)
        {
            string tdate = DateTime.Now.ToString("yyyy-MM-dd");
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select edate as date,electricity,rent,water,salary,others From tbl_mexpense where convert(char(10),edate,120)>=@sdate  AND convert(char(10),edate,120)<=@edate";
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
