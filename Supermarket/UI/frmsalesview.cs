using DGVPrinterHelper;
using Microsoft.Reporting.WinForms;
using QRCoder;
using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmsalesview : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        // private PictureBox pic;

        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public frmsalesview()
        {
            InitializeComponent();
        }

        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        public string cmpname;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        acctsDAL dcdal = new acctsDAL();
        productsDAL pdal = new productsDAL();
        DataTable transactiondt = new DataTable();
        usersDAL udal = new usersDAL();
        companyDAL cmpdal = new companyDAL();
        printDAL prdal = new printDAL();

        salesDAL sdal = new salesDAL();

        TextBox txtolddiscount = new TextBox();






        private void frmsales_Load(object sender, EventArgs e)
        {
            DataTable dt = sdal.GetInvoiceDetails(cmbbillno.Text);
            dgvaddproduct.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvaddproduct.Columns[0].HeaderText = "الرقم";
                dgvaddproduct.Columns[1].HeaderText = "الاسم";
                dgvaddproduct.Columns[2].HeaderText = "الكمية";
                dgvaddproduct.Columns[3].HeaderText = "السعر";
                dgvaddproduct.Columns[4].HeaderText = "الاجمالي";
               // dgvaddproduct.Columns[5].HeaderText = "الخصم";
               // dgvaddproduct.Columns[6].HeaderText = "الصافى";

            }
            else
            {
                dgvaddproduct.Columns[0].HeaderText = "Barcode";
                dgvaddproduct.Columns[1].HeaderText = "Name";
                dgvaddproduct.Columns[2].HeaderText = "Qty";
                dgvaddproduct.Columns[3].HeaderText = "Price";
                dgvaddproduct.Columns[4].HeaderText = "Total";
              //  dgvaddproduct.Columns[5].HeaderText = "Discount";
               // dgvaddproduct.Columns[6].HeaderText = "Unit";

            }

            //string product_id = "";
            //string productname = "";// txtpname.Text;
            decimal rate = 0;// decimal.Parse(txtrate.Text);
            decimal qty = 0;// decimal.Parse(txtqty.Text);
            decimal total = rate * qty;

            decimal subtotal = decimal.Parse(txtsubtotal.Text);
            subtotal = subtotal + total;


            // transactiondt.Rows.Add(product_id, productname, rate, qty, total);
            //dgvaddproduct.DataSource = transactiondt;
            dgvaddproduct.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvaddproduct.EnableHeadersVisualStyles = false;
            dgvaddproduct.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvaddproduct.RowHeadersWidth = 55;
            dgvaddproduct.RowTemplate.MinimumHeight = 25;



            dgvaddproduct.Columns[0].Width = 120;
            dgvaddproduct.Columns[1].Width = 300;
            
            dgvaddproduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // dgvaddproduct.Columns[8].Width = 50;


            txtsubtotal.Text = subtotal.ToString();
            cmbpayment.SelectedItem = "Cash";


            // Bills drop down list
            string sql2 = "Select id from tbl_sales where trtype='1' order by id";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "sales");
            
            
            cmbbillno.DisplayMember = "id";
            cmbbillno.ValueMember = "id";
            cmbbillno.DataSource = ds.Tables["sales"];
            conn2.Close();
            //***



        }


        private void dgvaddproduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                MessageBox.Show("Delete");

                int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
                string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells["total"].Value.ToString();

                double oldsubtotal = double.Parse(txtsubtotal.Text);
                double oldtotal = Convert.ToDouble(mtotal);

                double subtotal = oldsubtotal - oldtotal;

                txtsubtotal.Text = subtotal.ToString();
                double vat = subtotal * 0.15;  // ((100+15)/100)*subtotal;
                txtvat.Text = vat.ToString();
                double grandtotalwithvat = vat + subtotal; //((100 + 15) / 100) * prevgrand;
                txtgrandtotal.Text = grandtotalwithvat.ToString();
                dgvaddproduct.Rows.RemoveAt(rowIndex);
            }
        }

        /*
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtname.Text;
            if (keywords == "")
            {

                //  txtname.Text = "";
                txtvatno.Text = "";

                return;


            }
            acctsBLL dc = dcdal.searchdealercustomerfortransaction(keywords);

            txtname.Text = dc.name;
            txtvatno.Text = dc.vatno;

        }
     
        private void txtpaid_TextChanged_1(object sender, EventArgs e)
        {
            double grandtotal = double.Parse(txtgrandtotal.Text);
            double paidamount = double.Parse(txtpaid.Text);
            double returnamount = paidamount - grandtotal;
            txtreturn.Text = returnamount.ToString("0.##");
        }
        */
        private void dgvaddproduct_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;
            /*
            this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
            this.dgvaddproduct.Rows[rowIndex].Cells[7].Value = 0;
            */
            //txtolddiscount.Text = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();


        }
        private void dgvaddproduct_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;



            switch (e.ColumnIndex)
            {
                case 0:

                    string keywords = (Convert.ToString(dgvaddproduct.CurrentCell.Value));
                    if (keywords == "")
                    {

                        //  txtname.Text = "";
                        //string munit = dgvaddproduct.Rows[0].Cells[2].ToString();

                        return;

                    }
                    else
                    {
                        int currentRow = dgvaddproduct.CurrentCell.RowIndex;
                        if (currentRow > 0)
                        {
                            string myoldbarvalue = this.dgvaddproduct.Rows[currentRow - 1].Cells[0].Value.ToString();
                            string myoldqtyval = this.dgvaddproduct.Rows[currentRow - 1].Cells[4].Value.ToString();
                            decimal myoldqty = decimal.Parse(myoldqtyval);
                            /*  if (keywords == myoldbarvalue)
                              {
                                  this.dgvaddproduct.Rows[currentRow - 1].Cells[4].Value = myoldqty + 1;
                                  dgvaddproduct.ClearSelection();
                                  dgvaddproduct.CurrentCell.Selected = true;
                                 // this.dgvaddproduct.Rows[currentRow].Cells[0].clear();



                                  break;


                              }
                            */
                        }


                        //productsBLL dc = pdal.GetproductForTransaction(keywords);
                        //MessageBox.Show(dc.name);
                        // Get the DAL function Here
                        productsBLL dc = new productsBLL();
                        SqlConnection conn = new SqlConnection(myconnstrng);
                        DataTable dt = new DataTable();



                        try
                        {
                            string sql = "Select id,barcode,name,unit,rate,qty from tbl_products WHERE barcode LIKE '%" + keywords + "%' OR pname LIKE '%" + keywords + "%'";
                            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                            conn.Open();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                            //    while(dt.Rows.Count>0)
                            {

                                //txtcurrentvalue.Text = dt.Rows[0]["qty"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[0].Value = dt.Rows[0]["barcode"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[1].Value = dt.Rows[0]["name"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[2].Value = dt.Rows[0]["unit"].ToString();
                                this.dgvaddproduct.Rows[currentRow].Cells[3].Value = dt.Rows[0]["rate"].ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[4].Value = 1;


                                string uprice = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                                string uqty = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();
                                double ntotal = double.Parse(uprice) * double.Parse(uqty);
                                this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = ntotal.ToString();
                                this.dgvaddproduct.Rows[rowIndex].Cells[6].Value = 0;
                                this.dgvaddproduct.Rows[rowIndex].Cells[7].Value = 0;

                                double oldmdiscount = double.Parse(txtdiscount.Text);
                                double dsubtotal = double.Parse(txtsubtotal.Text);
                                double nsubtotal = ntotal + dsubtotal;
                                double newnet = nsubtotal - oldmdiscount;
                                dgvaddproduct.Update();
                                dgvaddproduct.Refresh();
                                txtsubtotal.Text = nsubtotal.ToString();
                                txtnetval.Text = newnet.ToString();
                                TransCalculations();
                                /*
                                foreach (DataGridViewRow item in this.dgvaddproduct.Rows)
                                {
                                    if (item.Cells[0].Value.ToString() == txtpart.Text)
                                    {
                                        item.ReadOnly = false;
                                        this.dgvaddproduct.Rows[currentRow].Cells[4].Value = 2;
                                    }
                                }
                                
                                */
                            }
                            else
                            {
                                if (MessageBox.Show("الصنف غير موجود...إضافة", "تأكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    frmproducts padd = new frmproducts();
                                    padd.Show();
                                }
                                else
                                {

                                }

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





                        //






                    }





                    //dgvaddproduct.CurrentCell = dgvaddproduct.Rows[rowIndex].Cells[4];



                    break;
                case 3:
                case 4:
                    string mrate = this.dgvaddproduct.Rows[rowIndex].Cells[3].Value.ToString();
                    string mqty = this.dgvaddproduct.Rows[rowIndex].Cells[4].Value.ToString();

                    string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
                    //string name = this.dgvaddproduct.Rows[rowIndex].Cells["name"].Value.ToString();
                    double oldtotal = double.Parse(mtotal);


                    double newtotal1 = double.Parse(mrate) * double.Parse(mqty);
                    this.dgvaddproduct.Rows[rowIndex].Cells[5].Value = newtotal1.ToString();
                    //this.dgvaddproduct.Columns["total"] = (Convert.ToDouble(row.Cells[dgvaddproduct.Columns["price"].Index].value) * (convert.todouble(rwo.cells[dgvaddproduct.columns["qty].index].value



                    double oldsubtotal = double.Parse(txtsubtotal.Text);
                    double oldmydiscount = double.Parse(txtdiscount.Text);
                    double newsubtotal1 = newtotal1 + oldsubtotal - oldtotal;
                    double newnetval1 = newsubtotal1 - oldmydiscount;
                    dgvaddproduct.Update();
                    dgvaddproduct.Refresh();
                    txtsubtotal.Text = newsubtotal1.ToString();
                    txtnetval.Text = newnetval1.ToString();
                    TransCalculations();
                    //-------------
                    /*
                    double vat = subtotal * 0.15;  // ((100+15)/100)*subtotal;
                    txtvat.Text = vat.ToString();
                    double grandtotalwithvat = vat + subtotal; //((100 + 15) / 100) * prevgrand;
                    txtgrandtotal.Text = grandtotalwithvat.ToString();
                    */
                    break;
                case 6:
                    string mytotal1 = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
                    string mydiscount = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();




                    double mntotal = Convert.ToDouble(mytotal1);
                    double ndiscount = Convert.ToDouble(mydiscount);
                    double mgtotal = mntotal - ndiscount;
                    this.dgvaddproduct.Rows[rowIndex].Cells[7].Value = mgtotal.ToString();
                    //double noldsubtotal = double.Parse(txtsubtotal.Text);
                    double newsubtotal = double.Parse(txtsubtotal.Text);
                    double oldnetdiscount = double.Parse(txtolddiscount.Text);
                    double olddiscount2 = double.Parse(txtdiscount.Text);
                    double newdiscount = ndiscount + olddiscount2 - oldnetdiscount;
                    txtdiscount.Text = newdiscount.ToString();
                    double newnetval = newsubtotal - newdiscount;
                    txtnetval.Text = newnetval.ToString();

                    dgvaddproduct.Update();
                    dgvaddproduct.Refresh();
                    TransCalculations();






                    break;








                //-------------


                default:
                    //MessageBox.Show("Error");
                    break;
            }




        }
        /*
        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {

            double newdiscount2 = double.Parse(txtdiscount.Text);
            double nsub = double.Parse(txtsubtotal.Text);
            double nnetval = nsub - newdiscount2;
            txtnetval.Text = nnetval.ToString();
            TransCalculations();


        }
        */
        private void TransCalculations()
        {
            dgvaddproduct.Update();
            dgvaddproduct.Refresh();

            double invnetval = double.Parse(txtnetval.Text);
            double nvat = invnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = nvat.ToString();
            double mygrandtotalwithvat = nvat + invnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = mygrandtotalwithvat.ToString();

        }


        private void btnremove_Click(object sender, EventArgs e)
        {
            //double molddiscount = 0;
            int rowIndex = dgvaddproduct.CurrentCell.RowIndex;
            string mtotal = this.dgvaddproduct.Rows[rowIndex].Cells[5].Value.ToString();
            string mdiscount = this.dgvaddproduct.Rows[rowIndex].Cells[6].Value.ToString();


            double molddiscount = Convert.ToDouble(mdiscount);
            double olddiscount = double.Parse(txtdiscount.Text);

            double oldsubtotal = double.Parse(txtsubtotal.Text);
            double oldtotal = Convert.ToDouble(mtotal);



            double subtotal = oldsubtotal - oldtotal;
            double discount = olddiscount - molddiscount;
            double nnetval = subtotal - discount;
            txtsubtotal.Text = subtotal.ToString();
            txtdiscount.Text = discount.ToString();
            txtnetval.Text = nnetval.ToString();

            double vat = nnetval * 0.15;  // ((100+15)/100)*subtotal;
            txtvat.Text = vat.ToString();
            double grandtotalwithvat = vat + nnetval; //((100 + 15) / 100) * prevgrand;
            txtgrandtotal.Text = grandtotalwithvat.ToString();
            dgvaddproduct.Rows.RemoveAt(rowIndex);







        }
        
        
        private void btnsave_Click(object sender, EventArgs e)
        {
            string compname, caddress, arname, cvatno, clogo, cvatno2, custname = "";


            DataTable dtc =prdal.GetCompanyData();
            if (dtc.Rows.Count > 0)
            {
                compname = dtc.Rows[0]["cname"].ToString();
                caddress = dtc.Rows[0]["caddress"].ToString();
                arname = dtc.Rows[0]["aname"].ToString();
                cvatno = dtc.Rows[0]["cvatno"].ToString();
                clogo = dtc.Rows[0]["clogo"].ToString();

                cvatno2 = "الرقم الضريبي:   " + cvatno;
            }
            else
            {
                compname = "";
                caddress = "";
                arname = "";
                cvatno = "";
                clogo = "";
                cvatno2 = "الرقم الضريبي";

            }
            string reptitle = "فاتورة ضريبية مبسطة";

            DataTable dts = GetSalesData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["customer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();
            string paycash = dts.Rows[0]["paycash"].ToString();
            string paycard = dts.Rows[0]["paycard"].ToString();

            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = Convert.ToDateTime(trdate);//, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal + nvat;
            string gnetval = mnetval.ToString();




            

            String Seller = arname;
            String VatNo = cvatno;
            DateTime dTime = DateTime.Parse(txtinvdate.Text);
            Double Total = Convert.ToDouble(gtotal);
            Double Tax = Convert.ToDouble(gvat);

            ztca tlv = new ztca(Seller, VatNo, dTime, Total, Tax);

            string Hex_txt = tlv.ToString();
            string Base64txt = tlv.ToBase64();

            //using QRcoder


            Bitmap qrCodeImage = tlv.toQrCode();
            qrCodeImage.Save("Q1.bmp");



            if (string.IsNullOrEmpty(clogo))
            {
            }
            else { 
                System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                img2 = resizeImage(img2, new Size(100, 100));

            }
            
            
            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");

            string imagePath = new Uri("file:///" + "Q1.bmp").AbsoluteUri;

            

            ReportParameter rp1 = new ReportParameter("arabicname", arname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);
            
            ReportParameter rp3 = new ReportParameter("customer", custname);
            ReportParameter rp4 = new ReportParameter("maddress", caddress);
            ReportParameter rp5 = new ReportParameter("invdate", trdate);
            ReportParameter rp6 = new ReportParameter("invno", invno);
            ReportParameter rp7 = new ReportParameter("payment", payment);
            ReportParameter rp8 = new ReportParameter("seller", adduser);

            ReportParameter rp9 = new ReportParameter();
            rp9.Name = "qrcode";
            rp9.Values.Add(@"file:///" + imgpath);
            ReportParameter rp10 = new ReportParameter();
            rp10.Name = "logo";
            rp10.Values.Add(@"file:///" + clogo);

            ReportParameter rp11 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp12 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp13 = new ReportParameter("pvat", gvat);
            ReportParameter rp14 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp15 = new ReportParameter("pcash", paycash);
            ReportParameter rp16 = new ReportParameter("pcard", paycard);
            ReportParameter rp17 = new ReportParameter("reptitle", reptitle);


            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath) + @"\smallInv.rdlc";
            report.ReportPath = fullpath;

            //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4,rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllsales();
            report.DataSources.Add(new ReportDataSource("DataSet2", dt));
            //report.DataSource = dt;

            //for (int i = 0; i < printQty; i++)
            //{
            PrintToPrinter1(report);
            //}

            frmClear();



            




        }
        public static void PrintToPrinter1(LocalReport report)
        {
            Export1(report);
        }

        public static void Export1(LocalReport report, bool print = true)
        {
            string deviceInfo =
            @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.2in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            report.EnableExternalImages = true;
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
            if (print)
            {
                Print();
            }

        }



        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static String text2hex(Int32 Tagnum, Int32 TagLength, String TagVal)
        {



            string binary = Convert.ToString(TagLength, 2);
            string binary2 = Convert.ToString(Tagnum, 2);

            ushort ulen = Convert.ToUInt16(binary, 2);
            ushort unum = Convert.ToUInt16(binary2, 2);



            //string hexval = String.Concat(TagVal.Select(x => ((int)x).ToString("x")));

            string hextag = unum.ToString("X2");
            string hexlen = ulen.ToString("X2");

            //string valbinary = Convert.ToString(TagVal, 2);
            byte[] arr = System.Text.Encoding.UTF8.GetBytes(TagVal);
            // string hexval = Convert.ToInt32(arr,2).ToString("X2");
            string hexval = String.Concat(TagVal.Select(x => ((int)x).ToString("x")));



            // int i = 0;
            // for Arabic 
            /*
             while(i <= TagVal.Length)
                 {
                 foreach (char c in TagVal)
                 {
                     int value = (int)c;
                     string hex[i] = value.ToString("X2");

                 }
                 i = i++;
             }
            */



            return (hextag + hexlen + hexval);


        }
        public string HexToBase64(string strInput)
        {
            //try
            //{
            var bytes = new byte[strInput.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(strInput.Substring(i * 2, 2), 16);
            }
            return Convert.ToBase64String(bytes);
            // }

            //catch (Exception)
            //{
            //  return "-1";
            //}

        }

        public DataTable GetSalesData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tbl_sales where id='" + cmbbillno.Text + "'";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

                da.Fill(dts);
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

            return dts;
        }

        public DataTable GetSalesDetails()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select productname,qty ,rate,rate*sum(qty) as total from tbl_sdetail where trid='" + cmbbillno.Text + "' GROUP BY productname";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

                da.Fill(dts);
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

            return dts;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {


            prntpreview.Document = prntdoc;
            prntdoc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            prntpreview.ShowDialog();

            frmClear();
        }
        public void frmClear()
        {
            this.Close();
            frmsalesview main = new frmsalesview();
            main.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void frmsales_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.Handled = true;
                e.SuppressKeyPress = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable dtc =prdal.GetCompanyData();
            string compname = dtc.Rows[0]["cname"].ToString();
            string caddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;

            DataTable dts = GetSalesData();
            string mdescription = dts.Rows[0]["description"].ToString();
            string trdate = dts.Rows[0]["trdate"].ToString();
            string payment = dts.Rows[0]["paymethod"].ToString();
            string adduser = dts.Rows[0]["added_by"].ToString();
            string invno = dts.Rows[0]["id"].ToString();
            string mcust = dts.Rows[0]["customer"].ToString();
            string gtotal = dts.Rows[0]["grandtotal"].ToString();
            string gvat = dts.Rows[0]["vat"].ToString();
            string gdiscount = dts.Rows[0]["discount"].ToString();
            string gsubtotal = dts.Rows[0]["subtotal"].ToString();

            // string[] dateFormats = new[] { "yyyy/MM/dd", "MM/dd/yyyy","MM/dd/yyyyHH:mm:ss"};
            CultureInfo provider = new CultureInfo("en-US");
            //DateTime mdate = DateTime.ParseExact(trdate, dateFormats, provider,DateTimeStyles.AdjustToUniversal);

            DateTime mdate = DateTime.Parse(trdate);//, provider);
            // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal + nvat;
            string gnetval = mnetval.ToString();




            DataTable dtcust =prdal.GetCustomer(mcust);
            string custname = dtcust.Rows[0]["name"].ToString();
            string custadd = dtcust.Rows[0]["address"].ToString();
            string custvat = dtcust.Rows[0]["vatno"].ToString();

            //********************

            //MessageBox.Show(mytotal);

            //string Hexcode = text2hex(1, hsellername) + text2hex(2, hexvatno) + text2hex(3, hexdate) + text2hex(4, hextotal) + text2hex(5, hexvat);
            //string Hexcode = text2hex(1,12,cmpname) + text2hex(2,15,cvatno) + text2hex(3, 20,DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssZ")) + text2hex(4,7, txtgrandtotal.Text) + text2hex(5,6, txtvat.Text);
            string Hexcode = text2hex(1, compname.Length, compname) + text2hex(2, cvatno.Length, cvatno) + text2hex(3, 20, mdate.ToString("yyyy-MM-ddTHH:mm:ssZ")) + text2hex(4, gtotal.Length, gtotal) + text2hex(5, gvat.Length, gvat);

            string enctext1 = HexToBase64(Hexcode);


            //using QRcoder

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(enctext1, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save("Q1.bmp");

            /*
            //**************for report
            using(MemoryStream ms=new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Bmp);
            }
            //*******************************
            */
            System.Drawing.Image img = System.Drawing.Image.FromFile("Q1.bmp");
            /*
            if (clogo != "")
            {
                System.Drawing.Image img2 = System.Drawing.Image.FromFile(clogo);
                img2 = resizeImage(img2, new Size(100, 100));

            }
            else
            {
                //  System.Drawing.Image img2= System.Drawing.Image.FromFile("Q1.bmp");
                //img2 = resizeImage(img2, new Size(100, 100));
                //e.Graphics.DrawImage(img2, 90, 10);
            }
            */
            img = resizeImage(img, new Size(120, 120));
            byte[] imgBytes = File.ReadAllBytes("Q1.bmp");
            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");

            string imagePath = new Uri("file:///" + "Q1.bmp").AbsoluteUri;

            string myimage = Convert.ToBase64String(imgBytes);
            //MessageBox.Show(imgpath.ToString());

            ReportParameter rp1 = new ReportParameter("cname", compname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);
            if (custname == "")
            {
                custname = "  ";
            }
            if (custadd == "")
            {
                custadd = "  ";
            }
            if (custvat == "")
            {
                custvat = "   ";

            }
            if (mdescription == "")
            {
                mdescription = "   ";
            }
            if (adduser == "")
            {
                adduser = " ";
            }
            ReportParameter rp3 = new ReportParameter("customer", custname);
            ReportParameter rp4 = new ReportParameter("caddress", caddress);
            ReportParameter rp5 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp6 = new ReportParameter("description", mdescription);
            ReportParameter rp7 = new ReportParameter("invdate", trdate);
            ReportParameter rp8 = new ReportParameter("invno", invno);
            ReportParameter rp9 = new ReportParameter("payment", payment);
            ReportParameter rp10 = new ReportParameter("seller", adduser);

            ReportParameter rp11 = new ReportParameter();
            rp11.Name = "qrcode";
            rp11.Values.Add(@"file:///" + imgpath);
            ReportParameter rp12 = new ReportParameter();
            rp12.Name = "logo";
            rp12.Values.Add(@"file:///" + clogo);

            ReportParameter rp13 = new ReportParameter("psubtotal", gsubtotal);
            ReportParameter rp14 = new ReportParameter("pdiscount", gdiscount);
            ReportParameter rp15 = new ReportParameter("pnet", gnetval);
            ReportParameter rp16 = new ReportParameter("pvat", gvat);
            ReportParameter rp17 = new ReportParameter("pgtotal", gtotal);
            ReportParameter rp18 = new ReportParameter("arabicname", arname);

            // reportViewer1.LocalReport.DataSources.Clear();


            //string sql = "Select * from Product";
            //var dt = GetDataTable(sql);
            LocalReport report = new LocalReport();
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string fullpath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\SalesRep.rdlc";
            report.ReportPath = fullpath;

          //  int printQty = Convert.ToInt32(txtprntqty.Text);

            report.EnableExternalImages = true;

            report.SetParameters(new ReportParameter[] { rp1, rp2, rp3, rp4, rp5, rp6, rp7, rp8, rp9, rp10, rp11, rp12, rp13, rp14, rp15, rp16, rp17, rp18 });
            //this.report.RefreshReport();
            DataTable dt = DisplayAllsales();
            report.DataSources.Add(new ReportDataSource("DataSet1", dt));
            //report.DataSource = dt;

            //for (int i = 0; i < printQty; i++)
            //{
                PrintToPrinter(report);
            //}


            //frmprntA4 frm = new frmprntA4();
            //frm.Show();


            //   tablelayout frm = new tablelayout(cmbbillno.Text);
            //frm.ShowDialog();


            /*
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinterName = settings.PrinterName;
            prntpreview.Document = prntdoc2;
            prntdoc2.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Custom", 800, 1200);
            prntdoc2.PrinterSettings.PrinterName = defaultPrinterName;
            prntdoc2.Print();
            */
            frmClear();

            //prntpreview.ShowDialog();

        }
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);
        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
            @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();

            report.EnableExternalImages = true;
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
            if (print)
            {
                Print();
            }

        }
        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cnnont find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }

        }
        public static Stream CreateStream(string name, string fileNmeExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            //Adjust area
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);
            //draw white background
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);
            //draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);
            //prepare for the next page
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }
        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }
        public DataTable DisplayAllsales()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //string sql = "SELECT a.trdate as Date,b.productname As name,sum(qty) as qty,rate as rate, sum(b.total) as total from tbl_sales a,tbl_sdetail b where b.trid=a.id and a.id='" + cmbbillno.Text + "' group by b.productname,a.trdate,b.rate";
                string sql = "SELECT trid as id,productname As name,qty,rate, total,discount as discper from tbl_sdetail where trid=@trid";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@trid", cmbbillno.Text);
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

       
        private void salesdetailBLLBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            DataTable dt = DisplayAllsales();
            //salesdetailBLLBindingSource.DataSource = dt;

        }



        
        private void button4_Click(object sender, EventArgs e)
        {
            frmClear();
        }
        
               

        private void cmbbillno_SelectedIndexChanged(object sender, EventArgs e)
        {
            string keywords = cmbbillno.Text;
            
            if (string.IsNullOrEmpty(keywords))
            {

                MessageBox.Show("No Invoices");

                return;


            }
            else
            {


                DataTable dts =  sdal.GetInvoiceSales(keywords);
                if (dts.Rows.Count > 0)
                {
                    string mdate = dts.Rows[0]["trdate"].ToString();
                    txtinvdate.Text = mdate.ToString();
                    txtdescription.Text = dts.Rows[0]["description"].ToString();
                    txtbranch.Text = dts.Rows[0]["branch"].ToString();
                    txtsubtotal.Text = dts.Rows[0]["subtotal"].ToString();
                    txtvat.Text = dts.Rows[0]["vat"].ToString();
                    txtdiscount.Text = dts.Rows[0]["discount"].ToString();
                    txtgrandtotal.Text = dts.Rows[0]["grandtotal"].ToString();
                    string paymentmethod = dts.Rows[0]["paymethod"].ToString();
                    txtpaycash.Text = dts.Rows[0]["paycash"].ToString();
                    txtpaycard.Text = dts.Rows[0]["paycard"].ToString();
                    txtuser.Text = dts.Rows[0]["added_by"].ToString();
                    //cmbtype.Text = dts.Rows[0]["trtype"].ToString();
                    txtname.Text = dts.Rows[0]["customer"].ToString();
                    string ispaid = dts.Rows[0]["paid"].ToString();
                    txtnetval.Text = (double.Parse(dts.Rows[0]["subtotal"].ToString()) + double.Parse(dts.Rows[0]["vat"].ToString())).ToString();
                    acctsBLL cdal = dcdal.searchdealercustomerfortransaction(txtname.Text);
                    txtvatno.Text = cdal.vatno;
                    if (ispaid == "1")
                    {
                        lblpay.Text = "تم السداد...";
                    }
                    else
                    {
                        lblpay.Text = "آجل ";
                    }
                    switch (paymentmethod)
                    {
                        case "1":
                                cmbpayment.Text = "نقدا";
                            break;
                        case "2":
                            cmbpayment.Text = "بطاقة - بنك";
                            break;
                        case "3":
                            cmbpayment.Text = "نقدا+بطاقة";
                            break;
                        case "4":
                            cmbpayment.Text = "آجل";
                            break;
                        default:
                            break;


                    }
                        

                }
                
                DataTable sdat = sdal.GetInvoiceDetails(cmbbillno.Text);
                dgvaddproduct.DataSource = sdat;
            }



        }
    }
}





