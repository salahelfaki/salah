
using Supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket.DAL
{
    class usersDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        //Database Data;
        #region Select Data from Database
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_users";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                string sql = "insert into tbl_users (name, username, password,usertype) VALUES( @name,@username, @password, @usertype)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@usertype", u.usertype);

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
            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                string sql = "Update tbl_users SET name=@name, username=@username, password=@password,usertype=@usertype WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", u.name);
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@usertype", u.usertype);
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
            SqlConnection con = new SqlConnection(myconnstrng);

            try
            {
                string sql = "Delete From tbl_users where id=@id";
                SqlCommand cmd = new SqlCommand(sql, con);
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
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_users WHERE id LIKE '%"+keywords+"%' OR name LIKE '%"+keywords+ "%' OR username LIKE '%" + keywords+"%'";
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
        #region getting user id
        public usersBLL getidfromusername (string username)
        {
            usersBLL w = new usersBLL();
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select id from tbl_users where username='" + username + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
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
                con.Close();
            }
            return w;

        }
        #endregion
        #region Select specific user
        public DataTable UserList(string uname, string pass)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_users WHERE username= '" + uname + "' AND password='" + pass + "'";
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

    }
}
