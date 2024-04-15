using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.BLL;
using Supermarket.DAL;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Supermarket.DAL
{
    class itemsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From tbl_items";
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
        public bool insert(itemsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_items(name,unit) VALUES (@name,@unit)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@unit", c.unit);
                


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
        public bool update(itemsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_items SET name=@name, unit=@unit where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@unit", c.unit);
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
        public bool delete(itemsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_items Where id=@id";
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
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_items WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' ";
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
        public bool DecreaseProduct(int ProductID, decimal Qty, decimal currentQty, decimal rate )
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty - Qty;
                success = UpdateQty(ProductID, NewQty,rate);


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
    }
}

