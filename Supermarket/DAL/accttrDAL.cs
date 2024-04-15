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
    class accttrDAL
    {
        public string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Method to display all transactions
        public DataTable DisplayAcctTrans(string acctname, DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT convert(Char(10),trdate,120) as Date,trno as Number,trtype as Type ,description, dbval  as Debit,crval as Credit from tbl_accttr where payacct=@acctcode AND CAST(trdate as Date) >=@sdate AND CAST(trdate as Date) < @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acctcode", acctname);
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
        #region select totals
        public DataTable DisplayTotals(string acctname, string sdate, string edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql1 = "SELECT sum(dbval)  as Debit,sum(crval) as Credit from tbl_accttr where acctname=@acctname AND convert(Char(10),trdate,120) Between @sdate AND @edate";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@acctname", acctname);
                cmd1.Parameters.AddWithValue("@sdate", sdate);
                cmd1.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                conn.Open();
                adapter.Fill(dtt);
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
        #region Display account Balance
        public DataTable DisplayAcctBalance()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql1 = "SELECT a.payacct,b.acctname,sum(a.dbval) as Debit, sum(a.crval) as Credit, sum(a.dbval)- sum(a.crval) as Balance from tbl_accttr a,tbl_accts b where a.payacct=b.acctcode GROUP by a.payacct,b.acctname";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                conn.Open();
                adapter.Fill(dtt);
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
        #region get account Balance
        public DataTable GetAcctBalance(string acctcode)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql1 = "SELECT sum(dbval)- sum(crval) as Balance from tbl_accttr where payacct=@acctcode";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@acctcode", acctcode);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                conn.Open();
                adapter.Fill(dtt);
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
        #region Get Totals
        public DataTable DisplayAcctBalanceTotals()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql1 = "SELECT sum(dbval) as Debit, sum(crval) as Credit, sum(dbval)- sum(crval) as Balance from tbl_accttr";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd1);
                conn.Open();
                adapter.Fill(dtt);
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
        #region Method to Select Payment Transactions
        public DataTable SelectPayments()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,acctname,dbval,crval,description,paymethod,payacct from tbl_accttr where trtype=@trtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "5");

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

        #region Method to Select Payment Transactions
        public DataTable SelectExpenses()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,acctname,dbval,crval,description,paymethod,payacct from tbl_accttr where trtype=@trtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "8");

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
        #region Method to Select Credit Note
        public DataTable SelectCreditNote()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,acctname,dbval,crval,description,paymethod,payacct from tbl_accttr where trtype=@trtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "6");
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
        #region Method to Search Credit Note
        public DataTable SearchCreditNote(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,acctname,dbval,crval,description,paymethod,payacct from tbl_accttr where acctname LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%' OR dbval LIKE '%" + keywords + "%'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "6");
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
        

        #region Method to Select Journal
        public DataTable SelectJournal()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,acctname,dbval,crval,description,paymethod,payacct from tbl_accttr where trtype=@trtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "7");
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
        #region Method to Get Journal for print
        public DataTable GetJournal(string trno)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT acctname,dbval,crval,description from tbl_accttr  where trno=@trno";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trno", trno);
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
        #region Method to Search Debit Note
        public DataTable SearchDebitNote(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno as Number,strftime('%d/%m/%Y',trdate) as Date,acctname,crval as amount,description,trtype as Type from tbl_accttr where trtype=@trtype AND(acctname LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%' OR dbval LIKE '%" + keywords + "%' )";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "5");
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
        #region Method to Search Journal
        public DataTable SearchJournal(string keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno as Number,strftime('%d/%m/%Y',trdate) as Date,acctname,dbval,crval,description from tbl_accttr where trtype=@trtype AND(acctname LIKE '%" + keywords + "%' OR description LIKE '%" + keywords + "%' OR dbval LIKE '%" + keywords + "%' OR crval LIKE '%" + keywords + "%')";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trtype", "7");
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
        #region Method to display Expenses two dates
        public DataTable GetExpenses(DateTime sdate, DateTime edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno,trdate,description,dbval from tbl_accttr  where substring(payacct,1,2)=@acct AND CAST(trdate as Date) >=@sdate AND CAST(trdate as Date)< @edate ORDER BY trdate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                cmd.Parameters.AddWithValue("@acct", "40");

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
        #region Method to display All Expenses 
        public DataTable GetAllExpenses()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT trno as Number,strftime('%d/%m/%Y',trdate) as Date,description,dbval,crval from tbl_accttr where substr(acctid,1,3)=@acct ORDER BY trdate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acct", "400");


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
        #region GET Total Daily Expenses
        public TotalBLL GetTotalDExpenses()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            TotalBLL p = new TotalBLL();
            try
            {
                string sql = "SELECT sum(dbval)-sum(crval) As total from tbl_accttr where acctid=@acct ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acct", "40001");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    p.total1 = dt.Rows[0]["total"].ToString();


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
        #region GET Total Daily Expenses between dates
        public TotalBLL GetTotalDExpensesDate(string sdate, string edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            TotalBLL p = new TotalBLL();
            try
            {
                string sql = "SELECT sum(dbval)-sum(crval) As total from tbl_accttr where acctid=@acct AND date(trdate) >=@sdate AND date(trdate)<=@edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acct", "40001");
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    p.total1 = dt.Rows[0]["total"].ToString();


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
        #region GET Total Monthly Expenses
        public TotalBLL GetTotalMExpenses()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            TotalBLL p = new TotalBLL();
            try
            {
                string sql = "SELECT sum(dbval)-sum(crval) As total from tbl_accttr where acctid=@acct ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acct", "40002");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    p.total2 = dt.Rows[0]["total"].ToString();


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
        #region GET Total Monthly Expenses between dates
        public TotalBLL GetTotalMExpensesDate(string sdate, string edate)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            TotalBLL p = new TotalBLL();
            try
            {
                string sql = "SELECT sum(dbval)-sum(crval) As total from tbl_accttr where acctid=@acct AND date(trdate) >=@sdate AND date(trdate)<=@edate ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acct", "40002");
                cmd.Parameters.AddWithValue("@sdate", sdate);
                cmd.Parameters.AddWithValue("@edate", edate);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    p.total2 = dt.Rows[0]["total"].ToString();


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

        #region Method to Select Total Balances
        public DataTable BalanceTotal(DateTime sdate,DateTime edate,string acctcode)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT sum(dbval) as dbval,sum(crval) as crval,(sum(dbval)-sum(crval)) as total from tbl_accttr where payacct=@acctcode AND CAST(trdate as Date) >=@sdate AND trdate < @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acctcode", acctcode);
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
        #region Method to Select Total Accounts Balances
        public DataTable AcctBalanceTotal(DateTime sdate, DateTime edate, string mainacct)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT sum(dbval) as dbval,sum(crval) as crval,(sum(dbval)-sum(crval)) as total from tbl_accttr where substring(payacct,1,1)=@mainacct AND CAST(trdate as Date) >=@sdate AND trdate < @edate";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mainacct", mainacct);
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
        #region Get  total Expenses 
        public decimal GetExpensesAll()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            decimal totalSales = 0;



            string sql = "SELECT ISNULL((SELECT sum(dbval) as total from tbl_accttr where trtype=@mtype),0) As total";
            try
            {
                using (SqlConnection connection = new SqlConnection(myconnstrng))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@mtype", "8");
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

