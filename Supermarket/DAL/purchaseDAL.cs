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
    class purchaseDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Display Max PurchaseID
        public static string DisplayMaxPurchaseID()
        {
            // DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection(myconnstrng);
            //   try
            // {
            string mysql1 = "select max(id) from tbl_purchase";
            conn.Open();
            SqlCommand cmd2 = new SqlCommand(mysql1, conn);
            var mytr = cmd2.ExecuteScalar();
            string myvno = mytr.ToString();
            conn.Close();

            return myvno;



        }
        #endregion
        #region Get Invoice Details

        public DataTable GetInvoiceDetails(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {
                //   string sql = "SELECT a.id as InvNo,strftime('%d/%m/%Y',a.trdate) as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productid='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.trtype='Sales' AND a.id=b.trid";
                string sql = "SELECT barcode,itemname,itemqty,itemprice,itemtotal from tbl_purchaseitems where trid=@tpid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tpid", tpid);
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
        #region GET Return ID
        public purchaseBLL GetReturnNo(string keyword)
        {

            purchaseBLL r = new purchaseBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            int myid = int.Parse(keyword);


            try
            {
                string sql = "Select returnno from tbl_purchase WHERE id=@myid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myid", myid);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {

                   
                    

                      r.returnno = int.Parse(dt.Rows[0][0].ToString());
                    //p.title = dt.Rows[0]["title"].ToString();

                    return r;

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
            return r;


        }
        #endregion
        #region Get Invoice ID
        public purchaseBLL GetInvoiceID(string keyword)
        {

            purchaseBLL p = new purchaseBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id from tbl_purchase WHERE id LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {



                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    //p.title = dt.Rows[0]["title"].ToString();

                    return p;

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
            return p;


        }
        #endregion
        #region Get Invoice Purchase
        public DataTable GetInvoicePurchase(string tpid)
        {
            
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            int myid = int.Parse(tpid);
            try
            {
                //string mret = "0";
                //   string sql = "SELECT a.id as InvNo,strftime('%d/%m/%Y',a.trdate) as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productid='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.trtype='Sales' AND a.id=b.trid";
                string sql = "SELECT * from tbl_purchase where id=@myid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myid", myid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dts;
        }
        #endregion
        #region Display Purchase
        public DataTable DisplayPurchase(DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,dealer,subtotal,discount,vat,grandtotal,trtype from tbl_purchase where CAST(trdate as Date) >= @sdate AND CAST(trdate as Date)< @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
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
        #region Get total purchase
        public DataTable GetTotalPurchase(DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {
                string sql = "SELECT sum(subtotal) as total from tbl_purchase where CAST(trdate as Date) >=@sdate AND trdate < @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                conn.Open();
                adapter1.Fill(dts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dts;

        }

        #endregion
        #region Display purchase by item
        public DataTable DisplaypPurchase(DateTime sdate, DateTime edate, string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();

            


            try
            {
                string sql = "SELECT a.id as InvNo,a.trdate,b.itemqty as Qty, b.itemprice as Price, itemtotal as Total from tbl_purchase a,tbl_purchaseitems b WHERE b.barcode=@mypid AND a.id=b.trid AND CAST(trdate as Date) >=@msdate AND CAST(trdate as Date)< @medate";//>= @msdate AND trdate <= @medate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mypid", tpid);
                cmd.Parameters.AddWithValue("@msdate", sdate);
                cmd.Parameters.AddWithValue("@medate", edate);

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
        #region Display All item purchases
        public DataTable DisplayAllpPurchase(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();

            int.TryParse(tpid, out int mypid);
            MessageBox.Show(mypid.ToString());


            try
            {
                string sql = "SELECT a.id as InvNo,a.trdate as Date,b.itemqty as Qty, b.itemprice as Price, itemtotal as Total from tbl_purchase a,tbl_purchaseitems b WHERE b.itemid=@mypid AND a.id=b.trid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mypid", mypid);
                

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
        #region Search purchase
        public DataTable SearchPurchase(string keywords, string sdate, string edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,dealer,subtotal,discount,vat,gtotal,trtype from tbl_purchase  where (subtotal LIKE '%" + keywords + "%' OR id LIKE '%" + keywords + "%' OR dealer LIKE '%" + keywords + "%') AND convert(char(10),trdate,120)>=@sdate  AND convert(char(10),trdate,120)<=@edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
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
        #region Get PurID using returnno
        public purchaseBLL GetPurID(string keyword)
        {

            purchaseBLL p = new purchaseBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id from tbl_purchase WHERE returnno LIKE '%" + keyword + "%'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {



                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    //p.title = dt.Rows[0]["title"].ToString();

                    return p;

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
            return p;


        }
        #endregion
        #region Get Vat totals
        public DataTable GetVatTotals(DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,subtotal,vat,grandtotal,trtype from tbl_purchase where CAST(trdate as Date) >=@sdate AND CAST(trdate as Date) < @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter1 = new SqlDataAdapter(cmd);
                conn.Open();
                adapter1.Fill(dtt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return dtt;

        }
        #endregion

        #region Get  purchase sales 
        public decimal GetPurchaseALL()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            decimal totalSales = 0;



            string sql = "SELECT ISNULL((SELECT sum(grandtotal) as total from tbl_purchase),0) As total";
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnstrng))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        totalSales = Convert.ToDecimal(command.ExecuteScalar());

                        // Display the result (you can update this based on your UI)
                        //txtsales.Text = $"Total Sales: {totalSales:C}"; // Example: "$123.45"
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }



            return totalSales;

        }
        #endregion
    }
}
