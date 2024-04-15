
using Supermarket.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Supermarket.DAL
{
    class acctsDAL
    {
        public string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region Select Method
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select acctid,acctcode,acctname,mainname,vatno,telno,cemail,caddress,cregno,obalance From tbl_accts a, tbl_mainacct b where a.mainacct=b.mid ";
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
        #region Insert new Customer
        public bool insert(acctsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_accts(acctcode,acctname,mainacct,crval,dbval,obalance,balance,vatno,telno,caddress,cemail,cregno,added_date,added_by) VALUES (@acctcode,@acctname,@mainacct,@crval,@dbval,@obalance,@balance,@vatno,@telno,@caddress,@cemail,@cregno,@added_date,@added_by)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mainacct", c.mainacct);
                cmd.Parameters.AddWithValue("@acctcode", c.acctcode);
                cmd.Parameters.AddWithValue("@acctname", c.acctname);
                cmd.Parameters.AddWithValue("@crval", 0);
                cmd.Parameters.AddWithValue("@dbval", 0);
                cmd.Parameters.AddWithValue("@obalance", c.obalance);
                cmd.Parameters.AddWithValue("@balance", 0);
                cmd.Parameters.AddWithValue("@vatno", c.vatno);
                cmd.Parameters.AddWithValue("@cemail", c.cemail);
                cmd.Parameters.AddWithValue("@telno", c.telno);
                cmd.Parameters.AddWithValue("@caddress", c.caddress);
                cmd.Parameters.AddWithValue("@cregno", c.cregno);
                cmd.Parameters.AddWithValue("@added_date", c.added_date);
                cmd.Parameters.AddWithValue("@added_by", c.added_by);

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
        public bool update(acctsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_accts SET mainacct=@mainacct,acctcode=@acctcode,acctname=@acctname,obalance=@obalance,vatno=@vatno,cemail=@cemail,telno=@telno,caddress=@caddress,cregno=@cregno where acctid=@acctid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mainacct", c.mainacct);
                cmd.Parameters.AddWithValue("@acctcode", c.acctcode);
                cmd.Parameters.AddWithValue("@acctname", c.acctname);
                cmd.Parameters.AddWithValue("@obalance", c.obalance);
                cmd.Parameters.AddWithValue("@vatno", c.vatno);
                cmd.Parameters.AddWithValue("@cemail", c.cemail);
                cmd.Parameters.AddWithValue("@telno", c.telno);
                cmd.Parameters.AddWithValue("@caddress", c.caddress);
                cmd.Parameters.AddWithValue("@cregno", c.cregno);
                cmd.Parameters.AddWithValue("@acctid", c.acctid);
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
        #region Delete Method
        public bool delete(acctsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_accts Where acctid=@acctid";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acctid", c.acctid);
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
        #region Search
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select * from tbl_accts WHERE acctcode LIKE '%" + keywords + "%' OR acctname LIKE '%" + keywords + "%' OR cemail LIKE '%" + keywords + "%'  OR telno LIKE '%" + keywords + "%' ";
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
        #region Method to search dealer or customer for transaction module
        public acctsBLL searchdealercustomerfortransaction(string keywords)
        {
            acctsBLL dc = new acctsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            

            try
            {

                
               

                string sql="select acctid,acctcode,acctname,vatno,caddress from tbl_accts WHERE acctname LIKE '%'+@Cname+'%'";

                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddWithValue ("@Cname", keywords);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    dc.acctid = int.Parse(dt.Rows[0]["acctid"].ToString());
                    dc.acctname = dt.Rows[0]["acctname"].ToString();
                    dc.acctcode = dt.Rows[0]["acctcode"].ToString();
                    dc.vatno = dt.Rows[0]["vatno"].ToString();
                    dc.caddress = dt.Rows[0]["caddress"].ToString();
                    



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


            return dc;


            
        }


        #endregion
        #region Method to get account info using barcode
        public acctsBLL GetAcctInfo(string keywords)
        {
            
            acctsBLL dc = new acctsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();


            try
            {
              
                string sql = "select acctid,acctname,vatno,caddress from tbl_accts WHERE acctcode=@acctcode";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@acctcode", keywords);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    
                    dc.acctid = int.Parse(dt.Rows[0]["acctid"].ToString());
                    dc.acctname = dt.Rows[0]["acctname"].ToString();
                    //dc.acctcode = dt.Rows[0]["acctcode"].ToString();
                    dc.vatno = dt.Rows[0]["vatno"].ToString();
                    dc.caddress = dt.Rows[0]["caddress"].ToString();


                }
                else
                {
                    dc.acctid = 0;
                    dc.acctname = "";
                    dc.vatno = "";
                    dc.caddress = "";
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


            return dc;



        }


        #endregion
        #region Method to get customer ID
        public acctsBLL getcustidfromname(string name)
        {
            acctsBLL dc = new acctsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect acctid from tbl_accts where acctname='" + name + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    dc.acctid = int.Parse(dt.Rows[0]["acctid"].ToString());

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
            return dc;
        }
        #endregion
        #region Method to get Max customer ID
        public acctsBLL GetMaxId(string mtype)
        {
            acctsBLL dc = new acctsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "Select max(acctcode) as acctcode from tbl_accts where mainacct=@mtype";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@mtype", int.Parse(mtype));
                adapter.Fill(dt);
                conn.Open();
                
                
                
                if (dt.Rows.Count > 0)
                {
                    string maxacctcode = dt.Rows[0]["acctcode"].ToString();
                    dc.acctcode = (decimal.Parse(maxacctcode)+1).ToString();
                    

                }
                else
                {
                    dc.acctcode = "0";
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dc;
        }
        #endregion
    }
}
