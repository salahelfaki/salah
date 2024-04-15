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
    class transactionDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Transaction
        public bool insertTransaction(transactionBLL t, out int transactionID)
        {
            
            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
              string sql1 = "INSERT INTO tbl_sales (trdate,description,branch,subtotal,vat,discount,grandtotal,paymethod,paycash,returned,added_by,trtype,customer,paycard,paycredit,returnno,sessionid,paid,acctcode) VALUES(@trdate,@description,@branch,@subtotal,@vat,@discount,@grandtotal,@paymethod,@paycash,@returned,@added_by,@trtype,@customer,@paycard,@paycredit,@returnno,@sessionid,@paid,@acctcode);SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@branch", t.branch);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd.Parameters.AddWithValue("@paycash", t.paycash);
                cmd.Parameters.AddWithValue("@returned", t.returned);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                cmd.Parameters.AddWithValue("@customer", t.customer);
                cmd.Parameters.AddWithValue("@paycard", t.paycard);
                cmd.Parameters.AddWithValue("@paycredit", t.paycredit);
                cmd.Parameters.AddWithValue("@returnno", t.returnno);
                cmd.Parameters.AddWithValue("@sessionid", t.sessionid);
                cmd.Parameters.AddWithValue("@paid", t.paid);
                cmd.Parameters.AddWithValue("@acctcode", t.acctcode);
                
                conn.Open();
                object o = cmd.ExecuteScalar();
                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
                    Issuccess = true;
                    //MessageBox.Show("Sales Invoice Ok");
                    
                    // Journal Creation
                    //Sales Account
                    string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,added_by,paymethod) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@added_by,@paymethod)";
                    string mdesc="تسوية الفاتورة رقم: " + transactionID.ToString();
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd3.Parameters.AddWithValue("@trno", transactionID);
                    cmd3.Parameters.AddWithValue("@trtype", "1");
                    cmd3.Parameters.AddWithValue("@payacct", "14001");
                    cmd3.Parameters.AddWithValue("@acctname", "المبيعات");
                    cmd3.Parameters.AddWithValue("@description", mdesc);
                    cmd3.Parameters.AddWithValue("@dbval", "0");
                    cmd3.Parameters.AddWithValue("@crval", t.subtotal);
                    cmd3.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd3.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd3.ExecuteNonQuery();
                   // MessageBox.Show("Sales Account Ok");
                    //VAT Account
                    
                    SqlCommand cmd4 = new SqlCommand(sql3, conn);
                    cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd4.Parameters.AddWithValue("@trno", transactionID);
                    cmd4.Parameters.AddWithValue("@trtype", "1");
                    cmd4.Parameters.AddWithValue("@payacct", "15001");
                    cmd4.Parameters.AddWithValue("@acctname", "ضريبة القيمة المضافة");
                    cmd4.Parameters.AddWithValue("@description", mdesc);
                    cmd4.Parameters.AddWithValue("@dbval", "0");
                    cmd4.Parameters.AddWithValue("@crval", t.vat);
                    cmd4.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd4.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd4.ExecuteNonQuery();
                    //MessageBox.Show("Sales VAT Ok");
                    //Accounts Debit
                    if (t.paymethod == "4")
                    {
                        SqlCommand cmd5 = new SqlCommand(sql3, conn);
                        cmd5.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@trno", transactionID);
                        cmd5.Parameters.AddWithValue("@trtype", "1");
                        cmd5.Parameters.AddWithValue("@payacct", t.acctcode);
                        cmd5.Parameters.AddWithValue("@acctname", t.customer);
                        cmd5.Parameters.AddWithValue("@description", mdesc);
                        cmd5.Parameters.AddWithValue("@dbval",t.grandtotal );
                        cmd5.Parameters.AddWithValue("@crval", "0");
                        cmd5.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd5.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd5.ExecuteNonQuery();
                      //  MessageBox.Show("DB Ok");
                    }
                    else if (t.paymethod == "3")
                    {
                        SqlCommand cmd6 = new SqlCommand(sql3, conn);
                        cmd6.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd6.Parameters.AddWithValue("@trno", transactionID);
                        cmd6.Parameters.AddWithValue("@trtype", "1");
                        cmd6.Parameters.AddWithValue("@payacct", "11001");
                        cmd6.Parameters.AddWithValue("@acctname", "الصندوق");
                        cmd6.Parameters.AddWithValue("@description", mdesc);
                        cmd6.Parameters.AddWithValue("@dbval", t.paycash);
                        cmd6.Parameters.AddWithValue("@crval", "0");
                        cmd6.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd6.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd6.ExecuteNonQuery();
                        SqlCommand cmd7 = new SqlCommand(sql3, conn);
                        cmd7.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd7.Parameters.AddWithValue("@trno", transactionID);
                        cmd7.Parameters.AddWithValue("@trtype", "1");
                        cmd7.Parameters.AddWithValue("@payacct", "11002");
                        cmd7.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                        cmd7.Parameters.AddWithValue("@description", mdesc);
                        cmd7.Parameters.AddWithValue("@dbval", t.paycard);
                        cmd7.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd7.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd7.Parameters.AddWithValue("@crval", "0");
                        cmd7.ExecuteNonQuery();
                       // MessageBox.Show("DB2 Ok");
                    }
                    else if (t.paymethod == "2")
                    {
                        SqlCommand cmd8 = new SqlCommand(sql3, conn);
                        cmd8.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd8.Parameters.AddWithValue("@trno", transactionID);
                        cmd8.Parameters.AddWithValue("@trtype", "1");
                        cmd8.Parameters.AddWithValue("@payacct", "11002");
                        cmd8.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                        cmd8.Parameters.AddWithValue("@description", mdesc);
                        cmd8.Parameters.AddWithValue("@dbval", t.paycard);
                        cmd8.Parameters.AddWithValue("@crval", "0");
                        cmd8.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd8.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd8.ExecuteNonQuery();
                    }else if (t.paymethod == "1")
                    {
                        SqlCommand cmd9 = new SqlCommand(sql3, conn);
                        cmd9.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd9.Parameters.AddWithValue("@trno", transactionID);
                        cmd9.Parameters.AddWithValue("@trtype", "1");
                        cmd9.Parameters.AddWithValue("@payacct", "11001");
                        cmd9.Parameters.AddWithValue("@acctname", "الصندوق");
                        cmd9.Parameters.AddWithValue("@description", mdesc);
                        cmd9.Parameters.AddWithValue("@dbval", t.paycash);
                        cmd9.Parameters.AddWithValue("@crval", "0");
                        cmd9.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd9.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd9.ExecuteNonQuery();
                    }
                    
                       
                   



                    // MessageBox.Show("Sales DB3 Ok");

                }
                else
                {
                    Issuccess = false;
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
            return Issuccess;
        }
        #endregion

        #region Insert Return Transaction
        public bool insertReturnTransaction(transactionBLL t, out int transactionID)
        {

            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql1 = "INSERT INTO tbl_sales (trdate,description,branch,subtotal,vat,discount,grandtotal,paymethod,paycash,returned,added_by,trtype,customer,paycard,paycredit,returnno,sessionid,paid,acctcode) VALUES(@trdate,@description,@branch,@subtotal,@vat,@discount,@grandtotal,@paymethod,@paycash,@returned,@added_by,@trtype,@customer,@paycard,@paycredit,@returnno,@sessionid,@paid,@acctcode);SELECT @@IDENTITY;";
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@branch", t.branch);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd.Parameters.AddWithValue("@paycash", t.paycash);
                cmd.Parameters.AddWithValue("@returned", t.returned);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                cmd.Parameters.AddWithValue("@customer", t.customer);
                cmd.Parameters.AddWithValue("@paycard", t.paycard);
                cmd.Parameters.AddWithValue("@paycredit", t.paycredit);
                cmd.Parameters.AddWithValue("@returnno", t.returnno);
                cmd.Parameters.AddWithValue("@sessionid", t.sessionid);
                cmd.Parameters.AddWithValue("@paid", t.paid);
                cmd.Parameters.AddWithValue("@acctcode", t.acctcode);

                conn.Open();
                object o = cmd.ExecuteScalar();
                if (o != null)
                {
                    transactionID = int.Parse(o.ToString());
                    Issuccess = true;
                    //MessageBox.Show("Sales Invoice Ok");

                    // Journal Creation
                    //Sales Account
                    string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,added_by,paymethod) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@added_by,@paymethod)";
                    string mdesc = "تسوية المرتجع رقم: " + transactionID.ToString();
                    SqlCommand cmd3 = new SqlCommand(sql3, conn);
                    cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd3.Parameters.AddWithValue("@trno", transactionID);
                    cmd3.Parameters.AddWithValue("@trtype", "2");
                    cmd3.Parameters.AddWithValue("@payacct", "14001");
                    cmd3.Parameters.AddWithValue("@acctname", "المبيعات");
                    cmd3.Parameters.AddWithValue("@description", mdesc);
                    cmd3.Parameters.AddWithValue("@dbval", "0");
                    cmd3.Parameters.AddWithValue("@crval", t.subtotal);
                    cmd3.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd3.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd3.ExecuteNonQuery();
                    // MessageBox.Show("Sales Account Ok");
                    //VAT Account

                    SqlCommand cmd4 = new SqlCommand(sql3, conn);
                    cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd4.Parameters.AddWithValue("@trno", transactionID);
                    cmd4.Parameters.AddWithValue("@trtype", "2");
                    cmd4.Parameters.AddWithValue("@payacct", "15001");
                    cmd4.Parameters.AddWithValue("@acctname", "ضريبة القيمة المضافة");
                    cmd4.Parameters.AddWithValue("@description", mdesc);
                    cmd4.Parameters.AddWithValue("@dbval", "0");
                    cmd4.Parameters.AddWithValue("@crval", t.vat);
                    cmd4.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd4.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd4.ExecuteNonQuery();
                    //MessageBox.Show("Sales VAT Ok");
                    //Accounts Debit
                    if (t.paymethod == "4")
                    {
                        SqlCommand cmd5 = new SqlCommand(sql3, conn);
                        cmd5.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd5.Parameters.AddWithValue("@trno", transactionID);
                        cmd5.Parameters.AddWithValue("@trtype", "2");
                        cmd5.Parameters.AddWithValue("@payacct", t.acctcode);
                        cmd5.Parameters.AddWithValue("@acctname", t.customer);
                        cmd5.Parameters.AddWithValue("@description", mdesc);
                        cmd5.Parameters.AddWithValue("@dbval", t.grandtotal);
                        cmd5.Parameters.AddWithValue("@crval", "0");
                        cmd5.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd5.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd5.ExecuteNonQuery();
                        //  MessageBox.Show("DB Ok");
                    }
                    else if (t.paymethod == "3")
                    {
                        SqlCommand cmd6 = new SqlCommand(sql3, conn);
                        cmd6.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd6.Parameters.AddWithValue("@trno", transactionID);
                        cmd6.Parameters.AddWithValue("@trtype", "2");
                        cmd6.Parameters.AddWithValue("@payacct", "11001");
                        cmd6.Parameters.AddWithValue("@acctname", "الصندوق");
                        cmd6.Parameters.AddWithValue("@description", mdesc);
                        cmd6.Parameters.AddWithValue("@dbval", t.paycash);
                        cmd6.Parameters.AddWithValue("@crval", "0");
                        cmd6.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd6.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd6.ExecuteNonQuery();
                        SqlCommand cmd7 = new SqlCommand(sql3, conn);
                        cmd7.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd7.Parameters.AddWithValue("@trno", transactionID);
                        cmd7.Parameters.AddWithValue("@trtype", "2");
                        cmd7.Parameters.AddWithValue("@payacct", "11002");
                        cmd7.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                        cmd7.Parameters.AddWithValue("@description", mdesc);
                        cmd7.Parameters.AddWithValue("@dbval", t.paycard);
                        cmd7.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd7.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd7.Parameters.AddWithValue("@crval", "0");
                        cmd7.ExecuteNonQuery();
                        // MessageBox.Show("DB2 Ok");
                    }
                    else if (t.paymethod == "2")
                    {
                        SqlCommand cmd8 = new SqlCommand(sql3, conn);
                        cmd8.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd8.Parameters.AddWithValue("@trno", transactionID);
                        cmd8.Parameters.AddWithValue("@trtype", "2");
                        cmd8.Parameters.AddWithValue("@payacct", "11002");
                        cmd8.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                        cmd8.Parameters.AddWithValue("@description", mdesc);
                        cmd8.Parameters.AddWithValue("@dbval", t.paycard);
                        cmd8.Parameters.AddWithValue("@crval", "0");
                        cmd8.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd8.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd8.ExecuteNonQuery();
                    }
                    else if (t.paymethod == "1")
                    {
                        SqlCommand cmd9 = new SqlCommand(sql3, conn);
                        cmd9.Parameters.AddWithValue("@trdate", DateTime.Now);
                        cmd9.Parameters.AddWithValue("@trno", transactionID);
                        cmd9.Parameters.AddWithValue("@trtype", "2");
                        cmd9.Parameters.AddWithValue("@payacct", "11001");
                        cmd9.Parameters.AddWithValue("@acctname", "الصندوق");
                        cmd9.Parameters.AddWithValue("@description", mdesc);
                        cmd9.Parameters.AddWithValue("@dbval", t.paycash);
                        cmd9.Parameters.AddWithValue("@crval", "0");
                        cmd9.Parameters.AddWithValue("@added_by", t.added_by);
                        cmd9.Parameters.AddWithValue("@paymethod", t.paymethod);
                        cmd9.ExecuteNonQuery();
                    }

                    string sql10 = "update tbl_sales set returnno=@retno where id=@idno";
                    SqlCommand cmd10 = new SqlCommand(sql10, conn);
                    cmd10.Parameters.AddWithValue("@retno", transactionID);
                    cmd10.Parameters.AddWithValue("@idno", t.invno);
                    cmd10.ExecuteNonQuery();





                    // MessageBox.Show("Sales DB3 Ok");

                }
                else
                {
                    Issuccess = false;
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
            return Issuccess;
        }
        #endregion
        /*
        #region Insert Temp Transaction
        public bool insertTempTransaction(transactionBLL t, out int transactionID)
        {

            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                
                string sql1 = "INSERT INTO tbl_tempsales (trdate,description,subtotal,vat,discount,grandtotal,added_by,trtype,sessionid,ordertype,tableno,vat1,status) VALUES(@trdate,@description,@subtotal,@vat,@discount,@grandtotal,@added_by,@trtype,@sessionid,@ordertype,@tableno,@vat1,@status);SELECT @@IDENTITY;";
               
                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@status", t.paid);
                cmd.Parameters.AddWithValue("@sessionid", t.sessionid);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                cmd.Parameters.AddWithValue("@ordertype", t.ordertype);
                cmd.Parameters.AddWithValue("@tableno", t.tableno);
                cmd.Parameters.AddWithValue("@vat1", t.vat1);
                conn.Open();
                object o = cmd.ExecuteScalar();
                
                if (o != null)
                {
                    
                    transactionID = int.Parse(o.ToString());
                    Issuccess = true;

                }
                else
                {
                    Issuccess = false;
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
            return Issuccess;
        }
        #endregion
        
        #region Insert Transaction
        public bool updateTempTransaction(transactionBLL t, out int transactionID)
        {

            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {

                string sql = "Update tbl_tempsales set subtotal=@subtotal,vat=@vat,discount=@discount,grandtotal=@grandtotal,vat1=@vat1 where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", t.id);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@vat1", t.vat1);
                conn.Open();
                object o = cmd.ExecuteScalar();
                if (o != null)
                {
                    
                    transactionID = int.Parse(o.ToString());
                    Issuccess = true;

                }
                else
                {
                    Issuccess = false;
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
            return Issuccess;
        }
        #endregion
        */
        #region Insert Account Trans
        public bool insertAccountTrans(transactionBLL t)
        {
           
            bool Issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                acctsDAL dcdal = new acctsDAL();
                
                acctsBLL cs = dcdal.getcustidfromname(t.customer);
                
                string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,acctid) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@acctid)";
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd3.Parameters.AddWithValue("@trno", t.id);
                cmd3.Parameters.AddWithValue("@trtype", "Purchase");
                cmd3.Parameters.AddWithValue("@payacct", cs.acctid);
                cmd3.Parameters.AddWithValue("@acctname", t.customer);
                cmd3.Parameters.AddWithValue("@description", t.description);
                cmd3.Parameters.AddWithValue("@dbval", "0");
                cmd3.Parameters.AddWithValue("@crval", t.grandtotal);
                cmd3.Parameters.AddWithValue("@acctid", cs.acctid);

                conn.Open();
                int rows = cmd3.ExecuteNonQuery();

                if (rows > 0)
                {
                    Issuccess = true;
                    
                }
                else
                {
                    Issuccess = false;
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
            return Issuccess;
        }
        #endregion
        #region Insert Purchase Transaction
        public bool insertPurchaseTransaction(transactionBLL t, out int transactionID)
        {
            acctsDAL cdal = new acctsDAL();

            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);
            
            try
            {
                string sql1 = "INSERT INTO tbl_purchase (trdate,description,subtotal,vat,discount,grandtotal,added_by,trtype,dealer,invno,invdate,returnno,paymethod,branch,acctcode) VALUES(@trdate,@description,@subtotal,@vat,@discount,@grandtotal,@added_by,@trtype,@dealer,@invno,@invdate,@returnno,@paymethod,@branch,@acctcode);SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@trdate", t.trdate);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                cmd.Parameters.AddWithValue("@dealer", t.customer);
                cmd.Parameters.AddWithValue("@invno", t.ordertype);
                cmd.Parameters.AddWithValue("@invdate", t.invdate);
                cmd.Parameters.AddWithValue("@returnno", t.returnno);
                cmd.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd.Parameters.AddWithValue("@branch", t.branch);
                cmd.Parameters.AddWithValue("@acctcode", t.acctcode);


                conn.Open();
                //int rows = cmd.ExecuteNonQuery();
                var op = cmd.ExecuteScalar();
                
                
                if (op != null)
                {
                    transactionID = int.Parse(op.ToString());
                    Issuccess = true;


                }
                else
                {
                    Issuccess = false;
                }
                
                // Journal Creation
                //Sales Account
                string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,added_by,paymethod) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@added_by,@paymethod)";
                string mdesc = "تسوية مشتريات رقم: " + transactionID.ToString();
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd3.Parameters.AddWithValue("@trno", transactionID);
                cmd3.Parameters.AddWithValue("@trtype", "3");
                cmd3.Parameters.AddWithValue("@payacct", "12001");
                cmd3.Parameters.AddWithValue("@acctname", "المشتريات");
                cmd3.Parameters.AddWithValue("@description", mdesc);
                cmd3.Parameters.AddWithValue("@dbval", t.subtotal);
                cmd3.Parameters.AddWithValue("@crval","0" );
                cmd3.Parameters.AddWithValue("@added_by", t.added_by);
                cmd3.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd3.ExecuteNonQuery();
                
                //VAT Account
                SqlCommand cmd4 = new SqlCommand(sql3, conn);
                cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd4.Parameters.AddWithValue("@trno", transactionID);
                cmd4.Parameters.AddWithValue("@trtype", "3");
                cmd4.Parameters.AddWithValue("@payacct", "15001");
                cmd4.Parameters.AddWithValue("@acctname", "ضريبة القيمة المضافة");
                cmd4.Parameters.AddWithValue("@description", mdesc);
                cmd4.Parameters.AddWithValue("@dbval", t.vat);
                cmd4.Parameters.AddWithValue("@crval", "0");
                cmd4.Parameters.AddWithValue("@added_by", t.added_by);
                cmd4.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd4.ExecuteNonQuery();
                // MessageBox.Show("Sales VAT Ok");
                //Accounts Debit
                if (t.paymethod == "4")
                {
                    SqlCommand cmd5 = new SqlCommand(sql3, conn);
                    cmd5.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd5.Parameters.AddWithValue("@trno", transactionID);
                    cmd5.Parameters.AddWithValue("@trtype", "3");
                    cmd5.Parameters.AddWithValue("@payacct", t.acctcode);
                    cmd5.Parameters.AddWithValue("@acctname", t.customer);
                    cmd5.Parameters.AddWithValue("@description", mdesc);
                    cmd5.Parameters.AddWithValue("@dbval", "0");
                    cmd5.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd5.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd5.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd5.ExecuteNonQuery();
                }
                else if (t.paymethod == "3")
                {
                    
                    SqlCommand cmd6 = new SqlCommand(sql3, conn);
                    cmd6.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd6.Parameters.AddWithValue("@trno", transactionID);
                    cmd6.Parameters.AddWithValue("@trtype", "3");
                    cmd6.Parameters.AddWithValue("@payacct", "11001");
                    cmd6.Parameters.AddWithValue("@acctname", "الصندوق");
                    cmd6.Parameters.AddWithValue("@description", mdesc);
                    cmd6.Parameters.AddWithValue("@dbval", "0");
                    cmd6.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd6.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd6.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd6.ExecuteNonQuery();
                    /*
                    SqlCommand cmd7 = new SqlCommand(sql3, conn);
                    cmd7.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd7.Parameters.AddWithValue("@trno", transactionID);
                    cmd7.Parameters.AddWithValue("@trtype", "1");
                    cmd7.Parameters.AddWithValue("@payacct", "11002");
                    cmd7.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                    cmd7.Parameters.AddWithValue("@description", mdesc);
                    cmd7.Parameters.AddWithValue("@dbval", t.paycard);
                    cmd7.Parameters.AddWithValue("@crval", "0");
                    cmd7.ExecuteNonQuery();
                    */
                }
                else if (t.paymethod == "2")
                {
                    SqlCommand cmd8 = new SqlCommand(sql3, conn);
                    cmd8.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd8.Parameters.AddWithValue("@trno", transactionID);
                    cmd8.Parameters.AddWithValue("@trtype", "3");
                    cmd8.Parameters.AddWithValue("@payacct", "11002");
                    cmd8.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                    cmd8.Parameters.AddWithValue("@description", mdesc);
                    cmd8.Parameters.AddWithValue("@dbval", "0");
                    cmd8.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd8.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd8.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd8.ExecuteNonQuery();
                }
                else if (t.paymethod == "1")
                {
                    SqlCommand cmd9 = new SqlCommand(sql3, conn);
                    cmd9.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd9.Parameters.AddWithValue("@trno", transactionID);
                    cmd9.Parameters.AddWithValue("@trtype", "3");
                    cmd9.Parameters.AddWithValue("@payacct", "11001");
                    cmd9.Parameters.AddWithValue("@acctname", "الصندوق");
                    cmd9.Parameters.AddWithValue("@description", mdesc);
                    cmd9.Parameters.AddWithValue("@dbval", "0");
                    cmd9.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd9.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd9.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd9.ExecuteNonQuery();
                }
                //MessageBox.Show("purchase cr Ok");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return Issuccess;
        }
        #endregion
        #region Insert Purchase Return Transaction
        public bool insertPurchaseReturnTransaction(transactionBLL t, out int transactionID)
        {

            acctsDAL cdal = new acctsDAL();

            bool Issuccess = false;
            transactionID = -1;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql1 = "INSERT INTO tbl_purchase (trdate,description,subtotal,vat,discount,grandtotal,added_by,trtype,dealer,invno,invdate,returnno,paymethod,branch,acctcode) VALUES(@trdate,@description,@subtotal,@vat,@discount,@grandtotal,@added_by,@trtype,@dealer,@invno,@invdate,@returnno,@paymethod,@branch,@acctcode);SELECT SCOPE_IDENTITY();";

                SqlCommand cmd = new SqlCommand(sql1, conn);
                cmd.Parameters.AddWithValue("@trdate", t.trdate);
                cmd.Parameters.AddWithValue("@description", t.description);
                cmd.Parameters.AddWithValue("@subtotal", t.subtotal);
                cmd.Parameters.AddWithValue("@vat", t.vat);
                cmd.Parameters.AddWithValue("@discount", t.discount);
                cmd.Parameters.AddWithValue("@grandtotal", t.grandtotal);
                cmd.Parameters.AddWithValue("@added_by", t.added_by);
                cmd.Parameters.AddWithValue("@trtype", t.trtype);
                cmd.Parameters.AddWithValue("@dealer", t.customer);
                cmd.Parameters.AddWithValue("@invno", t.ordertype);
                cmd.Parameters.AddWithValue("@invdate", t.invdate);
                cmd.Parameters.AddWithValue("@returnno", t.returnno);
                cmd.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd.Parameters.AddWithValue("@branch", t.branch);
                cmd.Parameters.AddWithValue("@acctcode", t.acctcode);


                conn.Open();
                //int rows = cmd.ExecuteNonQuery();
                var op = cmd.ExecuteScalar();


                if (op != null)
                {
                    transactionID = int.Parse(op.ToString());
                    Issuccess = true;


                }
                else
                {
                    Issuccess = false;
                }

                // Journal Creation
                //Sales Account
                string sql3 = "INSERT INTO tbl_accttr (trdate,trno,trtype,payacct,acctname,description,dbval,crval,added_by,paymethod) VALUES(@trdate,@trno,@trtype,@payacct,@acctname,@description,@dbval,@crval,@added_by,@paymethod)";
                string mdesc = "تسوية مرتجع مشتريات رقم: " + transactionID.ToString();
                SqlCommand cmd3 = new SqlCommand(sql3, conn);
                cmd3.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd3.Parameters.AddWithValue("@trno", transactionID);
                cmd3.Parameters.AddWithValue("@trtype", "4");
                cmd3.Parameters.AddWithValue("@payacct", "12001");
                cmd3.Parameters.AddWithValue("@acctname", "المشتريات");
                cmd3.Parameters.AddWithValue("@description", mdesc);
                cmd3.Parameters.AddWithValue("@dbval", t.subtotal);
                cmd3.Parameters.AddWithValue("@crval", "0");
                cmd3.Parameters.AddWithValue("@added_by", t.added_by);
                cmd3.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd3.ExecuteNonQuery();

                //VAT Account
                SqlCommand cmd4 = new SqlCommand(sql3, conn);
                cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd4.Parameters.AddWithValue("@trno", transactionID);
                cmd4.Parameters.AddWithValue("@trtype", "4");
                cmd4.Parameters.AddWithValue("@payacct", "15001");
                cmd4.Parameters.AddWithValue("@acctname", "ضريبة القيمة المضافة");
                cmd4.Parameters.AddWithValue("@description", mdesc);
                cmd4.Parameters.AddWithValue("@dbval", t.vat);
                cmd4.Parameters.AddWithValue("@crval", "0");
                cmd4.Parameters.AddWithValue("@added_by", t.added_by);
                cmd4.Parameters.AddWithValue("@paymethod", t.paymethod);
                cmd4.ExecuteNonQuery();
                // MessageBox.Show("Sales VAT Ok");
                //Accounts Debit
                if (t.paymethod == "4")
                {
                    SqlCommand cmd5 = new SqlCommand(sql3, conn);
                    cmd5.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd5.Parameters.AddWithValue("@trno", transactionID);
                    cmd5.Parameters.AddWithValue("@trtype", "4");
                    cmd5.Parameters.AddWithValue("@payacct", t.acctcode);
                    cmd5.Parameters.AddWithValue("@acctname", t.customer);
                    cmd5.Parameters.AddWithValue("@description", mdesc);
                    cmd5.Parameters.AddWithValue("@dbval", "0");
                    cmd5.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd5.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd5.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd5.ExecuteNonQuery();
                }
                else if (t.paymethod == "3")
                {

                    SqlCommand cmd6 = new SqlCommand(sql3, conn);
                    cmd6.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd6.Parameters.AddWithValue("@trno", transactionID);
                    cmd6.Parameters.AddWithValue("@trtype", "4");
                    cmd6.Parameters.AddWithValue("@payacct", "11001");
                    cmd6.Parameters.AddWithValue("@acctname", "الصندوق");
                    cmd6.Parameters.AddWithValue("@description", mdesc);
                    cmd6.Parameters.AddWithValue("@dbval", "0");
                    cmd6.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd6.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd6.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd6.ExecuteNonQuery();
                    /*
                    SqlCommand cmd7 = new SqlCommand(sql3, conn);
                    cmd7.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd7.Parameters.AddWithValue("@trno", transactionID);
                    cmd7.Parameters.AddWithValue("@trtype", "1");
                    cmd7.Parameters.AddWithValue("@payacct", "11002");
                    cmd7.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                    cmd7.Parameters.AddWithValue("@description", mdesc);
                    cmd7.Parameters.AddWithValue("@dbval", t.paycard);
                    cmd7.Parameters.AddWithValue("@crval", "0");
                    cmd7.ExecuteNonQuery();
                    */
                }
                else if (t.paymethod == "2")
                {
                    SqlCommand cmd8 = new SqlCommand(sql3, conn);
                    cmd8.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd8.Parameters.AddWithValue("@trno", transactionID);
                    cmd8.Parameters.AddWithValue("@trtype", "4");
                    cmd8.Parameters.AddWithValue("@payacct", "11002");
                    cmd8.Parameters.AddWithValue("@acctname", "بطاقة - بنك");
                    cmd8.Parameters.AddWithValue("@description", mdesc);
                    cmd8.Parameters.AddWithValue("@dbval", "0");
                    cmd8.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd8.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd8.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd8.ExecuteNonQuery();
                }
                else if (t.paymethod == "1")
                {
                    SqlCommand cmd9 = new SqlCommand(sql3, conn);
                    cmd9.Parameters.AddWithValue("@trdate", DateTime.Now);
                    cmd9.Parameters.AddWithValue("@trno", transactionID);
                    cmd9.Parameters.AddWithValue("@trtype", "4");
                    cmd9.Parameters.AddWithValue("@payacct", "11001");
                    cmd9.Parameters.AddWithValue("@acctname", "الصندوق");
                    cmd9.Parameters.AddWithValue("@description", mdesc);
                    cmd9.Parameters.AddWithValue("@dbval", "0");
                    cmd9.Parameters.AddWithValue("@crval", t.grandtotal);
                    cmd9.Parameters.AddWithValue("@added_by", t.added_by);
                    cmd9.Parameters.AddWithValue("@paymethod", t.paymethod);
                    cmd9.ExecuteNonQuery();

                    string sql10 = "update tbl_purchase set returnno=@retno where id=@idno";
                    SqlCommand cmd10 = new SqlCommand(sql10, conn);
                    cmd10.Parameters.AddWithValue("@retno", transactionID);
                    cmd10.Parameters.AddWithValue("@idno", t.invno);
                    cmd10.ExecuteNonQuery();
                }
                //MessageBox.Show("purchase cr Ok");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return Issuccess;
        }
        #endregion
    }
}
