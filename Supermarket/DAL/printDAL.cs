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
    class printDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Get company Data
        public DataTable GetCompanyData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dtc = new DataTable();
            try
            {

                string mysql = "select cname,aname,caddress,cvatno,clogo from company where id=1";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

                da.Fill(dtc);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dtc;
        }


        #endregion
        #region Display ITem Sales 
        public DataTable itemTrans(string sdate, string edate, string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {
                string sql = "SELECT a.id as id,strftime('%d/%m/%Y',a.trdate) as trdate,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productname='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.id=b.trid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dti);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dti;
        }
        #endregion
        #region Get customer data
        public DataTable GetCustomer(string custname)
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dtcust = new DataTable();
            //MessageBox.Show(custname);
            try
            {

                string mysql = "select * from tbl_accts where name LIKE '%'+@Cname+'%'";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                cmd3.Parameters.AddWithValue("@Cname", custname);
                SqlDataAdapter da = new SqlDataAdapter(cmd3);

                da.Fill(dtcust);
                //var mytr = cmd3.ExecuteScalar();
                //string myt = mytr.ToString();
                //txtinventory.Text = myt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myconn.Close();
            }

            return dtcust;
        }
        #endregion
    }


}
