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
    class deacustDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * From tbl_dea_cust";
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
        #region Insert new Customer
        public bool insert(deacustBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_dea_cust(type,name,email,contact,address,added_date,added_by) VALUES (@type,@name,@email,@contact,@address,@added_date,@added_by)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", c.type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@address", c.address);
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
        public bool update(deacustBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_dea_cust SET type=@type,name=@name,email=@email, contact=@contact,address=@address,added_date=@added_date, added_by=@added_by where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@type", c.type);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@contact", c.contact);
                cmd.Parameters.AddWithValue("@address", c.address);
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
        public bool delete(deacustBLL c)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_dea_cust Where id=@id";
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
                string sql = "Select * from tbl_dea_cust WHERE id LIKE '%" + keywords + "%' OR name LIKE '%" + keywords + "%' OR email LIKE '%" + keywords + "%'  OR contact LIKE '%" + keywords + "%' ";
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
        #region Method to search dealer or customer for transaction module
        public deacustBLL searchdealercustomerfortransaction(string keywords)
        {
            deacustBLL dc = new deacustBLL();
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql="select id,name,email,contact,address from tbl_dea_cust WHERE id LIKE '%"+keywords+"%' OR name LIKE '%"+keywords+"%'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());
                    dc.name = dt.Rows[0]["name"].ToString();
                    dc.email = dt.Rows[0]["email"].ToString();
                    dc.contact = dt.Rows[0]["contact"].ToString();
                    dc.address = dt.Rows[0]["address"].ToString();

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


            return dc;


            
        }


        #endregion
        #region Method to get customer ID
        public deacustBLL getcustidfromname(string name)
        {
            deacustBLL dc = new deacustBLL();
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect id from tbl_dea_cust where name='" + name + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    dc.id = int.Parse(dt.Rows[0]["id"].ToString());

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
            return dc;
        }
        #endregion
    }
}
