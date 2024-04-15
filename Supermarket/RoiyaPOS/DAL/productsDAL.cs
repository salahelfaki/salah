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
    class productsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From tbl_products";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
        #endregion
        #region Insert new Category
        public bool insert(productsBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_products(name,description,category,rate,qty,added_date,added_by,pcode,pbarcode) VALUES (@name,@description,@category,@rate,@qty,@added_date,@added_by,@pcode,@pbarcode)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@category", c.category);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@rate", c.rate);
                cmd.Parameters.AddWithValue("@qty", c.qty);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@pcode", c.pcode);
                cmd.Parameters.AddWithValue("@pbarcode", c.pbarcode);

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
        public bool update(productsBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_products SET name=@name,category=@category, description=@description,rate=@rate, qty=@qty,added_date=@added_date, added_by=@added_by, pcode=@pcode, pbarcode=@pbarcode where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@category", c.category);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@rate", c.rate);
                cmd.Parameters.AddWithValue("@qty", c.qty);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
                cmd.Parameters.AddWithValue("@pcode", c.pcode);
                cmd.Parameters.AddWithValue("@pbarcode", c.pbarcode);

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
        public bool delete(productsBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_products Where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
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
            MySqlConnection con = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_products WHERE id LIKE '%" + keywords + "%' OR pbarcode LIKE '%" + keywords + "%' OR pcode LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%' ";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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
        #region Method to search for products in Transaction Module
        public productsBLL GetproductForTransaction(string keyword)
        {
            productsBLL p = new productsBLL();
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select id,name,rate,qty from tbl_products WHERE pbarcode LIKE '%" + keyword + "%' OR pcode LIKE '%" + keyword + "%'  ";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql,conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.name = dt.Rows[0]["name"].ToString();
                    p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());


                }

            }
            catch(Exception ex)
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
        #region Method to get product id based on name
        public productsBLL getproductidfromname(string productname)
        {
            productsBLL p = new productsBLL();
            MySqlConnection con1 = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect id from tbl_products where name='" + productname + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con1);
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
        public decimal GetProductQty(int ProductID)
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            decimal qty = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT qty from tbl_products where id=" + ProductID;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                }

            }
            catch(Exception ex)
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
        public bool UpdateQty(int ProductID, decimal Qty)
        {
            bool success = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_products set qty=@qty where id=@id ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty", Qty);
                cmd.Parameters.AddWithValue("@id", ProductID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows >0)
                {
                    success = true;
                    //MessageBox.Show("Updated successfully");

                }
                else
                {
                    success = false;
                }


            }
            catch(Exception ex)
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
        public bool IncreaseProdcuct(int ProductID, decimal IncreaseQty, decimal currentQty)
        {
            bool success = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                //MessageBox.Show("Product Id  " + ProductID + "New Qty= " + NewQty);
                success = UpdateQty(ProductID, NewQty);

            }
            catch(Exception ex)
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
        public bool DecreaseProduct(int ProductID, decimal Qty, decimal currentQty)
        {
            bool success = false;
            MySqlConnection con = new MySqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty - Qty;
                success = UpdateQty(ProductID, NewQty);


            }
            catch(Exception ex)
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
        #region Method to display products based on category
        public DataTable DisplayProductsByCategory(string category)
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * from tbl_products WHERE category='" + category + "'";
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
