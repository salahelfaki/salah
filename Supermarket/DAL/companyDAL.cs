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

namespace Supermarket.DAL
{
    class companyDAL
    {
        public string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Data from Database
        public DataTable Select()
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from company";
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
        #region Update Data in Database
        
        public bool update(companyBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "Update company SET cname=@cname, aname=@aname,regno=@regno,caddress=@caddress, cvatno=@cvatno,clogo=@clogo,branch=@branch,vatval=@vatval,store=@store,lang=@lang,vatincluded=@vatincluded,custdisplay=@custdisplay WHERE id=1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@cname",c.cname );
                cmd.Parameters.AddWithValue("@aname", c.aname);
                cmd.Parameters.AddWithValue("@regno", c.regno);
                cmd.Parameters.AddWithValue("@caddress",c.caddress);
                cmd.Parameters.AddWithValue("@cvatno", c.cvatno);
                cmd.Parameters.AddWithValue("@clogo", c.clogo);
                cmd.Parameters.AddWithValue("@branch", c.branch); 
                cmd.Parameters.AddWithValue("@vatval", c.vatval);
                cmd.Parameters.AddWithValue("@store", c.store);
                cmd.Parameters.AddWithValue("@lang", c.lang);
                cmd.Parameters.AddWithValue("@vatincluded", c.vatincluded);
                cmd.Parameters.AddWithValue("@custdisplay", c.custdisplay);
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
        
    }
}
