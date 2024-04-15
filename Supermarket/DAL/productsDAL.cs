
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
    class productsDAL
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        #region Select Method
        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select a.id,barcode,pname,unit,qty,rate,costprice,b.title,pimage From tbl_products a,tbl_categories b where b.id=a.category";
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
        #region Insert new Category
        public bool insert(productsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO tbl_products(barcode,pname,description,unit,category,subcatid,rate,qty,lastprice,pimage,costprice) VALUES (@barcode,@pname,@description,@unit,@category,@subcatid,@rate,@qty,@lastprice,@pimage,@costprice)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@barcode", c.barcode);
                cmd.Parameters.AddWithValue("@pname", c.pname);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@unit", c.unit);
                cmd.Parameters.AddWithValue("@category", c.category);
                cmd.Parameters.AddWithValue("@subcatid", c.subcatid);
                cmd.Parameters.AddWithValue("@rate", c.rate);
                cmd.Parameters.AddWithValue("@qty", c.qty);
                cmd.Parameters.AddWithValue("@lastprice", c.lastprice);
                cmd.Parameters.AddWithValue("@costprice", c.costprice);
                cmd.Parameters.AddWithValue("@pimage", c.pimage);


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
        public bool update(productsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_products SET barcode=@barcode,pname=@pname,description=@description,unit=@unit,category=@category,subcatid=@subcatid,rate=@rate, qty=@qty,lastprice=@lastprice,costprice=@costprice where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@barcode", c.barcode);
                cmd.Parameters.AddWithValue("@pname", c.pname);
                cmd.Parameters.AddWithValue("@description", c.description);
                cmd.Parameters.AddWithValue("@unit", c.unit);
                cmd.Parameters.AddWithValue("@category", c.category);
                cmd.Parameters.AddWithValue("@subcatid", c.subcatid);
                cmd.Parameters.AddWithValue("@rate", c.rate);
                cmd.Parameters.AddWithValue("@qty", c.qty);
                cmd.Parameters.AddWithValue("@lastprice", c.lastprice);
                cmd.Parameters.AddWithValue("@costprice", c.costprice);


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
        #region Delete Method
        public bool delete(productsBLL c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE From tbl_products Where id=@id";
                SqlCommand cmd = new SqlCommand(sql, conn);
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
        #region Search barcode
        public DataTable Search(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select a.id,barcode,pname,unit,qty,rate,costprice,b.title,pimage From tbl_products a,tbl_categories b WHERE  (barcode LIKE '%" + keywords + "%' OR pname LIKE '%" + keywords + "%') AND b.id=a.category ";
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
        #region Search by name
        public DataTable SearchName(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select a.id,barcode,pname,unit,qty,rate,costprice,b.title,pimage From tbl_products a,tbl_categories b WHERE  (pname LIKE '%" + keywords + "%') AND b.id=a.category ";
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
        #region Method to search for products in Transaction Module
        public productsBLL GetproductForTransaction(string keyword)
        {
           
            productsBLL p = new productsBLL();
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
           


                try
                {
                    string sql = "Select id,barcode,pname,unit,rate,qty from tbl_products WHERE barcode LIKE '%" + keyword + "%' OR pname LIKE '%" + keyword + "%'";
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                    conn.Open();
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    //    while(dt.Rows.Count>0)
                    {



                        p.id = int.Parse(dt.Rows[0]["id"].ToString());
                        p.barcode = dt.Rows[0]["barcode"].ToString();
                        p.pname = dt.Rows[0]["pname"].ToString();
                        p.unit = dt.Rows[0]["unit"].ToString();
                        p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                        p.rate = decimal.Parse(dt.Rows[0]["rate"].ToString());
                        //   p.pimage = dt.Rows[0]["pimage"].ToString();
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
        #region Method to get product id based on name
        public productsBLL getproductidfromname(string barcode)
        {
            productsBLL p = new productsBLL();
            SqlConnection con1 = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect id,costprice,qty from tbl_products where barcode=@barcode";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.Parameters.AddWithValue("@barcode", barcode);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con1.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.costprice= decimal.Parse(dt.Rows[0]["costprice"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return p;
        }
        #endregion
        #region Method to get product data using barcode
        public productsBLL GetProduct(string barcode)
        {
            productsBLL p = new productsBLL();
            SqlConnection con1 = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect * from tbl_products where barcode=@barcode";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.Parameters.AddWithValue("@barcode", barcode);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con1.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.costprice = decimal.Parse(dt.Rows[0]["costprice"].ToString());
                    p.qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
                    p.pname = dt.Rows[0]["pname"].ToString();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return p;
        }
        #endregion

        #region Method to get Current qty from database
        public decimal GetProductQty(int ProductID)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            decimal qty = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT qty from tbl_products where id=" + ProductID;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if(dt.Rows.Count >0)
                {
                    qty = decimal.Parse(dt.Rows[0]["qty"].ToString());
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
            return qty;
        }
        #endregion
        #region Method to update qty
        public bool UpdateQty(int ProductID, decimal Qty)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_products set qty=@qty where id=@id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@qty", Qty);
                cmd.Parameters.AddWithValue("@id", ProductID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if(rows >0)
                {
                    success = true;
                    //MessageBox.Show("Updated successfully");

                }
                else
                {
                    success = false;
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
            return success;

        }
        #endregion
        #region Method increase product
        public bool IncreaseProdcuct(int ProductID, decimal IncreaseQty, decimal currentQty)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                //MessageBox.Show("Product Id  " + ProductID + "New Qty= " + NewQty);
                success = UpdateQty(ProductID, NewQty);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion
        #region Method to decrease product qty
        public bool DecreaseProduct(int ProductID, decimal Qty, decimal currentQty)
        {
            bool success = false;
            SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty - Qty;
                success = UpdateQty(ProductID, NewQty);


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return success;
        }
        #endregion
        #region Method to display products based on category
        public DataTable DisplayProductsByCategory(string category)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,barcode,pname,qty,costprice,rate, (qty*costprice) as total from tbl_products WHERE category=@categ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@categ", category);
                conn.Open();
                adapter.Fill(dt);

            }
            catch(Exception ex)
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
        #region Display all stock items
        public DataTable DisplayAllStock()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT id,barcode,pname,qty,costprice,rate,(qty*costprice) as total  from tbl_products order by id";
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
        #region GEt All Stock Totals
        public DataTable GetAllStockTotals()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT ROUND(sum(rate*qty),2) as total from tbl_products";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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
        #region GetStock Totals by Category
        public DataTable GetCatStockTotals(string category)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dtt = new DataTable();
            try
            {
                string sql = "SELECT ROUND(sum(rate*qty),2) as total from tbl_products WHERE category='" + category + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
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

        #region Barcode Validate
        public DataTable BarcodeValidate(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            
            try
            {
               // MessageBox.Show(keywords);
                string sql = "Select * from tbl_products WHERE barcode ='"+keywords+"' ";
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
        #region Method to get product id based on barocde
        public productsBLL getproductidfromCode(string productname)
        {
            productsBLL p = new productsBLL();
            SqlConnection con1 = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();

            try
            {
                string sql = "SElect id,pname from tbl_products where barcode=@productname";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.Parameters.AddWithValue("@productname", productname);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con1.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    p.id = int.Parse(dt.Rows[0]["id"].ToString());
                    p.pname = dt.Rows[0]["pname"].ToString();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return p;
        }
        #endregion
        #region Method increase purchase product2
        public bool IncreaseProdcuct2(int ProductID, decimal IncreaseQty, decimal currentQty, decimal pprice)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //decimal currentQty = GetProductQty(ProductID);
                decimal NewQty = currentQty + IncreaseQty;
                //MessageBox.Show("Product Id  " + ProductID + "New Qty= " + NewQty);
                success = UpdateQtyPrice(ProductID, NewQty, pprice);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return success;
        }
        #endregion
        #region Method to update qty
        public bool UpdateQtyPrice(int ProductID, decimal qty, decimal pprice)
        {
            bool success = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE tbl_products set qty=@qty,lastprice=@pprice where id=@id ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@pprice", pprice);
                cmd.Parameters.AddWithValue("@qty", qty);
                cmd.Parameters.AddWithValue("@id", ProductID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    success = true;
                    //MessageBox.Show("Updated successfully");

                }
                else
                {
                    success = false;
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
            return success;

        }
        #endregion
        #region Method for Get Product for sales
        public DataTable getproductforSales(string productname)
        {
            productsBLL p = new productsBLL();
            SqlConnection con1 = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            
            try
            {
                string sql = "SElect barcode,pname,qty,rate from tbl_products where barcode=@barcode";
                SqlCommand cmd = new SqlCommand(sql, con1);
                cmd.Parameters.AddWithValue("@barcode",productname);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                con1.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con1.Close();
            }
            return dt;
        }
        #endregion
        #region Select List
        public DataTable SelectList()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select barcode,pname,qty,rate From tbl_products";
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
        #region Search for Product List
        public DataTable SearchList(string keywords)
        {
            SqlConnection con = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "Select barcode,pname,qty,rate  from tbl_products WHERE pname LIKE '%" + keywords + "%' ";
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

        #region Method to get average stock value
        public decimal GetStockValue()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            decimal val1 = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT sum(qty*costprice)/count(barcode) As val from tbl_products";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    val1 = decimal.Parse(dt.Rows[0]["val"].ToString());
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
            return val1;
        }
        #endregion

        #region Method to get All stock with qty >0 
        public decimal GetStockQtyAvailable()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            decimal val1 = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT count(barcode) As val from tbl_products where qty >0";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    val1 = decimal.Parse(dt.Rows[0]["val"].ToString());
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
            return val1;
        }
        #endregion
        #region get all stock count
        public decimal GetStockAll()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            decimal val1 = 0;
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT count(barcode) As val from tbl_products";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    val1 = decimal.Parse(dt.Rows[0]["val"].ToString());
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
            return val1;
        }
        #endregion


    }
}
