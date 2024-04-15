using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.BLL;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;

namespace Supermarket.DAL
{
    class salesDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Get Sales ID
        public static string DisplayMaxSalesID()
        {
            // DataTable dt = new DataTable();
            
            SqlConnection conn = new SqlConnection(myconnstrng);
         //   try
           // {
                string mysql1 = "select max(id) from tbl_sales";
                conn.Open();
                SqlCommand cmd2 = new SqlCommand(mysql1, conn);
                var mytr = cmd2.ExecuteScalar();
               string myvno = mytr.ToString();
                conn.Close();

                return myvno;
            
                

                
            
        }
        /*    catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return myvno;
        }*/




        #endregion
        #region Display Close Day Totals
        public DataTable GetCloseDayTotalSales(string sdate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT ROUND(sum(paid),2)-ROUND(sum(returned),2) as cash,ROUND(sum(paycard),2) as card,ROUND(sum(grandtotal),2) as total,ROUND(sum(grandtotal),2)-ROUND(sum(paid),2)-ROUND(sum(paycard),2)+ROUND(sum(returned),2) as diff from tbl_sales where convert(char(10),trdate,120)=@sdate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
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

        #region Method to display all transactions
        public DataTable DisplayAllsales(string trid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.productname As name,qty,rate as rate, b.total as total from tbl_sales a,tbl_sdetail b where b.trid=a.id and a.id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", trid);
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
        #region Method to Display Total Sales
        public DataTable GetTotalSales()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {
                string sql = "SELECT ROUND(sum(subtotal),2) as tsubtotal,ROUND(sum(vat),2) as tvat,ROUND(sum(grandtotal),2) as tgrand from tbl_sales";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
        #region Method to display Sales Based on Date
        public DataTable DisplaySalesByDate(string tdate)
        {
           // MessageBox.Show(tdate);
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT b.productid as ID,b.productname As Item,sum(b.qty) as Qty,rate as Price,sum(b.total) as Amount from tbl_sales a,tbl_sdetail b where b.trid=a.id AND Convert(Char(10),a.trdate,120)= @tdate group by b.productid,b.productname,rate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@tdate", tdate);
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
        #region display return by date
        public DataTable DisplayReturnByDate(string tdate)
        {
            // MessageBox.Show(tdate);
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT b.productid as ID,b.productname As Item,sum(b.qty) as Qty,rate as Price,sum(b.total) as Amount from tbl_sales a,tbl_sdetail b where b.trid=a.id AND date(a.trdate) ='" + tdate + "' AND a.trtype='Return'  group by productid";
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
        #region Method to get daily sales totals
        public DataTable GetDailyTotalSales(string sdate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT ROUND(sum(subtotal),2) as tsubtotal,ROUND(sum(discount),2) as tdiscount,ROUND(sum(vat),2) as tvat,ROUND(sum(grandtotal),2) as tgrand from tbl_sales where Convert(Char(10),trdate,120)=@sdate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
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
        #region Display Vat
        public DataTable DisplayVat(string sdate, string edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id as InvNo,trdate as Date,trtype,ROUND((subtotal-discount),2) as Amount, ROUND((vat),2) as Vat, ROUND((grandtotal),2) as Total from tbl_sales where convert(Char(10),trdate,120) Between @sdate AND @edate";
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
        #region Display All Vat
        public DataTable DisplayVatAll()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id as InvNo,trdate as Date,trtype,(subtotal-discount) as Amount, vat as Vat, grandtotal as Total from tbl_sales";
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
        #region Get VAt Totals
        public DataTable GetVatTotals(DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,subtotal,vat,grandtotal,trtype from tbl_sales where CAST(trdate as Date) >=@sdate AND CAST(trdate as Date) < @edate";
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
        #region Display All VAT totals
        public DataTable GetAllVatTotals()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT trtype,ROUND(sum(subtotal-discount),2) as tsubtotal,ROUND(sum(vat),2) as tvat,ROUND(sum(grandtotal),2) as tgrand from tbl_sales group by trtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
        #region Display product transaction
        public DataTable  Displayptrans(DateTime sdate, DateTime edate, string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();

            try
            {
                string sql = "SELECT invno,trdate,trtype,inqty,outqty,balance from tbl_ptrans WHERE barcode=@mypid AND CAST(trdate as Date) >= @sdate AND CAST(trdate as Date ) < @edate  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mypid", tpid);
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

        #region Display product Sales transaction
        public DataTable DisplayStrans(DateTime sdate, DateTime edate, string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();

            try
            {
                string sql = "SELECT a.id as invno,trdate,qty,rate,total from tbl_sales a,tbl_sdetail b WHERE a.id=b.trid AND barcode=@mypid AND CAST(trdate as Date ) >= @sdate AND CAST(trdate as Date ) < @edate  ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mypid", tpid);
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
        #region Display All Item trans
        public DataTable DisplaypALLtrans(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtp = new DataTable();
            
            try
            {
                string sql = "SELECT a.id as InvNo,a.trdate as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.barcode=@myid AND a.id=b.trid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@myid", tpid);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dtp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dtp;
        }

        #endregion
        #region Display item sales total
        public DataTable GetpTotals(string sdate,string edate, string pid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            DateTime msdate = DateTime.Parse(sdate);
            DateTime medate = DateTime.Parse(edate);
            int myid = int.Parse(pid);

            try
            {
                string sql = "SELECT sum(b.total) as Total from tbl_sales a,tbl_sdetail b where b.productid=@myid AND a.id=b.trid AND a.trdate Between @msdate AND @medate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@msdate", sdate);
                cmd.Parameters.AddWithValue("@medate", edate);
                cmd.Parameters.AddWithValue("@myid", myid);

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
        #region Get item total sales 
        public decimal GetpALLTotals(string barcode)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            
            decimal totalSales = 0;

           

                string sql = "SELECT ISNULL((SELECT sum(total) as total from tbl_sdetail where barcode=@mypid),0) As total";
                try
                {
                    using (SqlConnection connection = new SqlConnection(myconnstrng))
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@mypid", barcode);

                            // Execute the query and retrieve the result
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
 
        #region Get Invoice Details

        public DataTable GetInvoiceDetails(string tpid)
        {
            
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            int mytrid = int.Parse(tpid);
            try
            {
             //   string sql = "SELECT a.id as InvNo,strftime('%d/%m/%Y',a.trdate) as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productid='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.trtype='Sales' AND a.id=b.trid";
                string sql = "SELECT barcode,productname,qty,rate,total from tbl_sdetail where trid=@trid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trid",mytrid);
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
        #region Get Invoice No
        public salesBLL GetInvoiceID(string keyword)
        {

            salesBLL p = new salesBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id from tbl_sales WHERE id LIKE '%" + keyword + "%'";
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
        #region Get Invoice Sales
        public DataTable GetInvoiceSales(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            
            int myid = int.Parse(tpid);
           
            try
            {
                string sql = "SELECT * from tbl_sales where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", myid);
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
        #region Get Return no.
        public salesBLL GetReturnNo(string keyword)
        {

            salesBLL r = new salesBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select returnno from tbl_sales WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(keyword));
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                //    while(dt.Rows.Count>0)
                {



                    r.returnno = int.Parse(dt.Rows[0]["returnno"].ToString());
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
        #region Display  summary Sessions Sales
        public DataTable GetSessionSalesSummary(int sid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
         //   int mysid = int.Parse(sid);

            try
            {
                string sql = "SELECT sum(paycash) as cash,sum(paycard) as card,sum(paycredit) as credit,sum(grandtotal) as total from tbl_sales where sessionid=@sessionid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sessionid", sid);
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
            if (dtt.Rows.Count > 0)
            {
                return dtt;
            }
            else
            {
                MessageBox.Show("لاتوجد مبيعات");
                return null;
            }

            
        }

        #endregion
        #region Method to display Sales between two Dates
        public DataTable DisplaySales(string sdate, string edate)
        {

           
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,sessionid,subtotal,discount,vat,grandtotal,trtype from tbl_sales  where convert(char(10),trdate,120)>=@sdate  AND convert(char(10),trdate,120)<=@edate";
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
        #region Display  Sessions Sales
        public DataTable GetSessionSales(int sid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            //int myid = int.Parse(sid);
            try
            {
                string sql = "SELECT id,paid,paycard,paycredit from tbl_sales where sessionid=@sessionid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("sessionid", sid);
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
        #region Method to Search Sales between two Dates
        public DataTable Search(string keywords, string sdate, string edate)
        {
            // MessageBox.Show(tdate);
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,trdate,customer,subtotal,discount,vat,grandtotal,trtype from tbl_sales  where (subtotal LIKE '%" + keywords + "%' OR id LIKE '%" + keywords + "%' OR customer LIKE '%" + keywords + "%')AND convert(char(10),trdate,120)>=@sdate AND convert(char(10),trdate,120)<=@edate";
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
        
        #region Get ProInvoice  Details

        public DataTable GetProInvoiceDetails(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {
                //   string sql = "SELECT a.id as InvNo,strftime('%d/%m/%Y',a.trdate) as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productid='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.trtype='Sales' AND a.id=b.trid";
                string sql = "SELECT productid,productname,qty,rate,total from tmp_sdetail where trid='" + tpid + "'";
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

        #region Get Invoice ID
        public salesBLL GetProInvoiceID(string keyword)
        {

            salesBLL p = new salesBLL();
            SqlConnection conn = new SqlConnection(@"Data Source=Supermarket.db; Version=3");
            DataTable dt = new DataTable();



            try
            {
                string sql = "Select id from tmp_sales WHERE id LIKE '%" + keyword + "%'";
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
        #region Get invoice sales
        public DataTable GetProInvoiceSales(string tpid)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {
                //   string sql = "SELECT a.id as InvNo,strftime('%d/%m/%Y',a.trdate) as Date,b.qty as Qty, b.rate as Price, b.total as Total from tbl_sales a,tbl_sdetail b where b.productid='" + tpid + "' AND date(trdate) >='" + sdate + "' AND date(trdate)<='" + edate + "' AND a.trtype='Sales' AND a.id=b.trid";
                string sql = "SELECT trdate,description,branch,subtotal,vat,discount,grandtotal,paymethod,paid,return,added_by,trtype,customer,paycard,paycredit from tmp_sales where id='" + tpid + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
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

        #region Get Sales Totals
        public DataTable GetSalesTotals(DateTime sdate, DateTime edate)
        {
            
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            
            try
            {
                string sql = "SELECT ROUND(sum(subtotal-discount),2) as total from tbl_sales where CAST(trdate as Date) >=@sdate AND trdate < @edate";
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

        #region Get Sales Totals
        public DataTable GetProductCost(DateTime sdate, DateTime edate)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();

            try
            {
                string sql = "SELECT ROUND(sum(costprice*qty),2) as total from tbl_sales a, tbl_sdetail b where a.id=b.trid AND CAST(trdate as Date) >=@sdate AND trdate < @edate";
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
        #region Display Categories Sales 
        public DataTable DisplayCategtrans(DateTime sdate, DateTime edate, string tpid)
        {

            
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {

                string sql = "SELECT b.barcode,c.pname,sum(b.total) as Total,c.category from tbl_sales a,tbl_sdetail b,tbl_products c where c.category=@tpid AND b.barcode=c.barcode AND a.id=b.trid AND CAST(trdate as Date) >=@sdate AND CAST(trdate as Date)< @edate Group by b.barcode,c.pname,c.category";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                cmd.Parameters.AddWithValue("@tpid", tpid);
                conn.Open();
                //decimal stotal = Convert.ToDecimal(cmd.ExecuteScalar());
                
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    
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

        #region Display ITem Sales 
        public DataTable DisplayCategSum(DateTime sdate, DateTime edate)
        {

            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dti = new DataTable();
            try
            {

                string sql = "SELECT d.title as productname,sum(b.total) as Total from tbl_sales a,tbl_sdetail b,tbl_products c,tbl_categories d where b.barcode=c.barcode AND c.category=d.id AND CAST(trdate as Date)>=@sdate AND CAST(trdate as Date) < @edate AND a.id=b.trid Group by d.title";
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

        #region Get  total sales 
        public decimal GetSalesALL()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            decimal totalSales = 0;



            string sql = "SELECT ISNULL((SELECT sum(grandtotal) as total from tbl_sales),0) As total";
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
