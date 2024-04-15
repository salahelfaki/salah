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
    
    class transactionDetailDAL
    {
        productsDAL pdal = new productsDAL();
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Insert Sales details
        public bool insertTransactionDetail(transactiondetailBLL td)
        {
            
            
            bool Issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql2 = "insert into tbl_sdetail(trid,productid,productname,rate,qty,total,costprice,balance,barcode) VALUES(@trid,@productid,@productname,@rate,@qty,@total,@costprice,@balance,@barcode)";
                SqlCommand cmd1 = new SqlCommand(sql2, conn);
                cmd1.Parameters.AddWithValue("@trid", td.trid);
                cmd1.Parameters.AddWithValue("@productid", td.productid);
                cmd1.Parameters.AddWithValue("@productname", td.productname);
                cmd1.Parameters.AddWithValue("@rate", td.rate);
                cmd1.Parameters.AddWithValue("@qty",td.qty);
                cmd1.Parameters.AddWithValue("@total", td.total);
                cmd1.Parameters.AddWithValue("@costprice", td.costprice);
                cmd1.Parameters.AddWithValue("@balance", td.balance);
                cmd1.Parameters.AddWithValue("@barcode", td.barcode);

                //stock transaction
                string sql4 = "insert into tbl_ptrans(invno,barcode,trtype,trdate,oldqty,inqty,outqty,balance,price,costprice) VALUES(@invno,@barcode,@trtype,@trdate,@oldqty,@inqty,@outqty,@balance,@price,@costprice)";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@invno", td.trid);
                cmd4.Parameters.AddWithValue("@trtype", "1");
                cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd4.Parameters.AddWithValue("@price", td.rate);
                cmd4.Parameters.AddWithValue("@oldqty",td.oldqty);
                cmd4.Parameters.AddWithValue("@inqty", 0);
                cmd4.Parameters.AddWithValue("@outqty", td.qty);
                cmd4.Parameters.AddWithValue("@costprice", td.costprice);
                cmd4.Parameters.AddWithValue("@balance", td.balance);
                cmd4.Parameters.AddWithValue("@barcode", td.barcode);
                conn.Open();
                int rows = cmd1.ExecuteNonQuery();
                
                int rows4= cmd4.ExecuteNonQuery();
               
                if (rows > 0)
                {
                    Issuccess = true;
                    //Update Quantities
                    //MessageBox.Show("Product id   " + MyPid);
                    decimal Qty_hand = pdal.GetProductQty(td.productid);
                    //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                    //*************************Update inventory values ***********
                 
                    bool x = false;

                    x = pdal.DecreaseProduct(td.productid, td.qty, Qty_hand);
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
        #region Insert Temp details
        public bool insertTempTransactionDetail(transactiondetailBLL td)
        {
            bool Issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql2 = "insert into tbl_tempdetails(trid,productid,productname,rate,qty,total) VALUES(@trid,@productid,@productname,@rate,@qty,@total)";
                SqlCommand cmd1 = new SqlCommand(sql2, conn);
                cmd1.Parameters.AddWithValue("@trid", td.trid);
                cmd1.Parameters.AddWithValue("@productid", td.productid);
                cmd1.Parameters.AddWithValue("@productname", td.productname);
                cmd1.Parameters.AddWithValue("@rate", td.rate);
                cmd1.Parameters.AddWithValue("@qty", td.qty);
                cmd1.Parameters.AddWithValue("@total", td.total);

                conn.Open();


                int rows = cmd1.ExecuteNonQuery();
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
       
        
        #region Insert Purchase details
        public bool insertPurchaseTransactionDetail(transactiondetailBLL td)
        {
            
            bool Issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string msql = "insert into tbl_purchaseitems(trid,itemid,itemname,itemprice,itemqty,itemtotal,balance,barcode) VALUES(@trid,@itemid,@itemname,@itemprice,@itemqty,@itemtotal,@balance,@barcode)";
                SqlCommand cmd1 = new SqlCommand(msql, conn);
                cmd1.Parameters.AddWithValue("@trid", td.trid);
                cmd1.Parameters.AddWithValue("@itemid",td.productid);
                cmd1.Parameters.AddWithValue("@itemname", td.productname);
                cmd1.Parameters.AddWithValue("@itemprice", td.rate);
                cmd1.Parameters.AddWithValue("@itemqty", td.qty);
                cmd1.Parameters.AddWithValue("@itemtotal", td.total);
                cmd1.Parameters.AddWithValue("@balance", td.balance);
                cmd1.Parameters.AddWithValue("@barcode", td.barcode);
                
                //stock transaction
                string sql4 = "insert into tbl_ptrans(invno,barcode,trtype,trdate,oldqty,inqty,outqty,balance,price,costprice) VALUES(@invno,@barcode,@trtype,@trdate,@oldqty,@inqty,@outqty,@balance,@price,@costprice)";
                SqlCommand cmd4 = new SqlCommand(sql4, conn);
                cmd4.Parameters.AddWithValue("@invno", td.trid);
                cmd4.Parameters.AddWithValue("@trtype", td.trtype);
                cmd4.Parameters.AddWithValue("@trdate", DateTime.Now);
                cmd4.Parameters.AddWithValue("@price", td.rate);
                cmd4.Parameters.AddWithValue("@oldqty", td.oldqty);
                cmd4.Parameters.AddWithValue("@inqty", td.qty);
                cmd4.Parameters.AddWithValue("@outqty", 0);
                cmd4.Parameters.AddWithValue("@costprice", td.costprice);
                cmd4.Parameters.AddWithValue("@balance", td.balance);
                cmd4.Parameters.AddWithValue("@barcode", td.barcode);
                conn.Open();
                int rows = cmd1.ExecuteNonQuery();
                int rows4 = cmd4.ExecuteNonQuery();
               

                if (rows > 0)
                {
                    Issuccess = true;
                    //Update Quantities
                    //MessageBox.Show("Product id   " + MyPid);
                    decimal Qty_hand = pdal.GetProductQty(td.productid);
                    //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                    //*************************Update inventory values ***********

                    bool x = false;

                    x = pdal.IncreaseProdcuct2(td.productid, td.qty, Qty_hand,td.rate);
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
        #region Insert Trans Stock
        public bool insertTransStock(transactiondetailBLL td)
        {
            bool Issuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql5 = "insert into tbl_strans(trno,item,price,qty,balance,sdate,trtype,description) VALUES(@trno,@item,@price,@qty,@balance,@sdate,@trtype,@description)";
                SqlCommand cmd5 = new SqlCommand(sql5, conn);
                cmd5.Parameters.AddWithValue("@trno", td.trid);
                cmd5.Parameters.AddWithValue("@item", td.productname);
                cmd5.Parameters.AddWithValue("@price", td.rate);
                cmd5.Parameters.AddWithValue("@qty", td.qty);
                cmd5.Parameters.AddWithValue("@balance", td.balance);
                cmd5.Parameters.AddWithValue("@sdate", DateTime.Now);
                cmd5.Parameters.AddWithValue("@trtype", 1);
                cmd5.Parameters.AddWithValue("@description", "Purchase");

                conn.Open();
                int rows = cmd5.ExecuteNonQuery();
                if (rows > 0)
                {
                    Issuccess = true;
                    decimal Qty_hand = pdal.GetProductQty(td.productid);
                    //MessageBox.Show("Product id   " + MyPid + "qty  " + Qty_hand +"new qty" + Mpqty);
                    //*************************Update inventory values ***********
                    MessageBox.Show("Details Ok");


                    bool x = false;

                    x = pdal.DecreaseProduct(td.productid, td.qty, Qty_hand);
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
        



    }
}
