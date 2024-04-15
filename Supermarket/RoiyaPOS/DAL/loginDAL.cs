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
    class loginDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            bool isSuccess = false;
            MySqlConnection conn = new MySqlConnection(myconnstrng);

            try
            {
                string sql = "Select * from tbl_users where username=@username AND password=@password AND user_type=@user_type";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
                cmd.Parameters.AddWithValue("@user_type", l.user_type);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
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

    }
}
