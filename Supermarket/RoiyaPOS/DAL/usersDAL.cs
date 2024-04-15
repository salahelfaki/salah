using MySql.Data.MySqlClient;
using supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket.DAL
{
    class usersDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Data from Database
        public DataTable Select()
        {
            MySqlConnection con = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_users";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                con.Open();
                adapter.Fill(dt);



            }
            catch(Exception ex)
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
        #region Insert Data in Database
        public bool insert(usersBLL u)
        {
            bool isSuccess = false;
            MySqlConnection con = new MySqlConnection(myconnstrng);
            try
            {
                string sql = "insert into tbl_users (first_name, last_name, email, username, password, contact, address, gender,user_type,added_date, added_by) VALUES( @first_name, @last_name, @email, @username, @password, @contact, @address, @gender,@user_type,@added_date, @added_by)";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);

                con.Open();
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
                con.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Update Data in database
        public bool update(usersBLL u)
        {
            bool isSuccess = false;
            MySqlConnection con = new MySqlConnection(myconnstrng);

            try
            {
                string sql = "Update tbl_users SET first_name=@first_name, last_name=@last_name, email=@email, username=@username, password=@password, contact=@contact, address=@address, gender=@gender,user_type=@user_type,added_date=@added_date, added_by=@added_by WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@first_name", u.first_name);
                cmd.Parameters.AddWithValue("@last_name", u.last_name);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@contact", u.contact);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@gender", u.gender);
                cmd.Parameters.AddWithValue("@user_type", u.user_type);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@added_by", u.added_by);
                cmd.Parameters.AddWithValue("@id", u.id);
                con.Open();

                int rows = cmd.ExecuteNonQuery();
                if(rows > 0)
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
                con.Close();
            }
            return isSuccess;
        }
        #endregion
        #region Delete Data 
        public bool delete(usersBLL u)
        {
            bool isSuccess = false;
            MySqlConnection con = new MySqlConnection(myconnstrng);
           
            try
            {
                string sql = "Delete From tbl_users where id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", u.id);
                con.Open();
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
                con.Close();
            }
            return isSuccess;

        }
        #endregion
        #region Search User
        public DataTable Search(string keywords)
        {
            MySqlConnection con = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_users WHERE id LIKE '%"+keywords+"%' OR first_name LIKE '%"+keywords+ "%' OR last_name LIKE '%" + keywords + "%' OR username LIKE '%" + keywords+"%'";
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
        #region getting user id
        public usersBLL getidfromusername (string username)
        {
            usersBLL w = new usersBLL();
            MySqlConnection conn = new MySqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from tbl_users where username='" + username + "'";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    w.id = int.Parse(dt.Rows[0]["id"].ToString());
                     
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
            return w;

        }
        #endregion

    }
}
