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
    class categoriesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From tbl_categories";
                MySqlCommand cmd = new MySqlCommand(sql,conn);
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
        #region Insert new Category
        public bool insert(categoriesBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_categories(title,description,added_date,added_by) VALUES (@title,@description,@added_date,@added_by)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

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
            catch(Exception ex)
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
        public bool update(categoriesBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_categories SET title=@title, description=@description,added_date=@added_date, added_by=@added_by where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@title", c.title);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);
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
            catch(Exception ex)
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
        public bool delete(categoriesBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_Categories Where id=@id";
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
            catch(Exception ex)
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
                string sql = "Select * from tbl_categories WHERE id LIKE '%" + keywords + "%' OR title LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%' ";
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
    }
}
