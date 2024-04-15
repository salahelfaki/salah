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
    class sessionDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                
                string sql = "Select * From tbl_sessions";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        #region Insert new Session
        public bool insert(sessionBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_sessions(sessionname,sessionuser,startdate,status) VALUES (@sessionname,@sessionuser,@startdate,@status)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sessionname", c.sessionname);
                cmd.Parameters.AddWithValue("@sessionuser", c.sessionuser);
                cmd.Parameters.AddWithValue("@startdate", SqlDbType.DateTime).Value = DateTime.Now.ToString("yyy-MM-dd hh:mm:ss");
                //cmd.Parameters.AddWithValue("@enddate", c.enddate);
                cmd.Parameters.AddWithValue("@status", c.status);


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
        public bool update(sessionBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_sessions SET status=@status,enddate=@enddate where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@status", c.status);
                cmd.Parameters.AddWithValue("@enddate", DateTime.Now);
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


        #region 
        public DataTable Getsessions()
        {


            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id,startdate,sessionuser,sessionname as total from tbl_sessions WHERE status=0";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                con.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {




                    return dt;

                }




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
        #region Get MAx no
        public DataTable GetMaxId()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select max(id) as id from tbl_sessions";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {




                    return dt;

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
            return dt;


        }
        #endregion
        #region Get current SessionId
        public DataTable GetCurrentSessId()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id from tbl_sessions where status='0'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {




                    return dt;

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
            return dt;


        }
        #endregion
        #region Get MAx no
        public DataTable GetInvCount(string ssid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select distinct sessionid,count(id) as total from tbl_sales where sessionid=@ssid GROUP by sessionid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ssid", ssid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {




                    return dt;

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
            return dt;


        }
        #endregion

        #region Get session details
        public DataTable GetSessionDetails(int ssid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select * from tbl_sessions where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", ssid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {




                    return dt;

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
            return dt;


        }
        #endregion
    }
}
