using Supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Supermarket.DAL
{
    class transactionpurDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Transaction

        public bool insert_trans(transactionBLL t, out int transID)
        {
            bool isSuccess = false;
            transID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_purchase (trdate,description,subtotal,vat,discount,gtotal,added_by,trtype,dealer,invno,invdate) VALUES(@trdate,@description,@subtotal,@vat,@discount,@gtotal,@added_by,@trtype,@dealer,@invno,@invdate);SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                //cmd.Parameters.AddWithValue("@gtotal", t.gtotal);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                //cmd.Parameters.AddWithValue("@dealer", t.dealer);
                //cmd.Parameters.AddWithValue("@invno", t.invno);
                cmd.Parameters.AddWithValue("@invdate", t.invdate);

                conn.Open();
                object o = cmd.ExecuteScalar();
                if(o!=null)
                {
                    transID = int.Parse(o.ToString());
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
        
    }
}
