using Microsoft.Reporting.WinForms;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class tablelayout : Form
    {
        TextBox txtbox1 = new TextBox();




        /*
         public string TextBoxValue
         {
             get
             {
                 return txtbox1.Text;
             }
         }
        */
        public string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public tablelayout(String InitialTextBoxValue)
        {
            
            
            InitializeComponent();
            txtbox1.Text = InitialTextBoxValue;
        }

        public int myid;



        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void tablelayout_Load(object sender, EventArgs e)
        {
           /*
            SqlConnection mconn = new SqlConnection(myconnstrng);
            mconn.Open();
            string mysqlm = "select max(id) from tbl_sales";

            SqlCommand cmd2 = new SqlCommand(mysqlm, mconn);
            var mytr = cmd2.ExecuteScalar();
            //txtbillno.Text = mytr.ToString();
            
            mconn.Close();

            if (mytr != null)
            {
                myid = Convert.ToInt32(mytr);
            }

            else
            {
                myid = 0;
            }
            mconn.Close();

            */
            

            DataTable dtc = GetCompanyData();
            string compname = dtc.Rows[0]["cname"].ToString();
            string caddress = dtc.Rows[0]["caddress"].ToString();
            string arname = dtc.Rows[0]["aname"].ToString();
            string cvatno = dtc.Rows[0]["cvatno"].ToString();
            string clogo = dtc.Rows[0]["clogo"].ToString();

            string cvatno2 = "الرقم الضريبي:   " + cvatno;

            DataTable dts = GetSalesData();
            string mdescription= dts.Rows[0]["description"].ToString();
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
            
            DateTime mdate = Convert.ToDateTime(trdate,provider);
           // MessageBox.Show(trdate);
            //MessageBox.Show(mdate.ToString());


            //string fdate= Format(CDate(Parameters!DateTimeFrom.Value), "MM-dd-yyyy hh:mm:ss")


            double mdiscount = Convert.ToDouble(gdiscount);
            double msubtotal = Convert.ToDouble(gsubtotal);
            double nvat = Convert.ToDouble(gvat);
            double mnetval = msubtotal + nvat;
            string gnetval = mnetval.ToString();

           


            DataTable dtcust = GetCustomer(mcust);
            string custname= dtcust.Rows[0]["name"].ToString();
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
            img = resizeImage(img, new Size(120, 120));
            byte[] imgBytes = File.ReadAllBytes("Q1.bmp");
            //*************************

            string imgpath = Path.GetFullPath("Q1.bmp");
            
            string imagePath = new Uri("file:///" + "Q1.bmp").AbsoluteUri;

            string myimage = Convert.ToBase64String(imgBytes);
            //MessageBox.Show(imgpath.ToString());

            ReportParameter rp1 = new ReportParameter("cname", compname);
            ReportParameter rp2 = new ReportParameter("vatid", cvatno2);
            if(custname=="")
            {
                custname = "  ";
            }
            if(custadd=="")
            {
                custadd = "  ";
            }
            if(custvat=="")
            {
                custvat = "   ";

            }
            if(mdescription=="")
            {
                mdescription = "   ";
            }
            if(adduser=="")
            {
                adduser = " ";
            }
            ReportParameter rp3 = new ReportParameter("customer", custname);
            ReportParameter rp4 = new ReportParameter("caddress", custadd);
            ReportParameter rp5 = new ReportParameter("cvatnumber", custvat);
            ReportParameter rp6 = new ReportParameter("description", mdescription);
            ReportParameter rp7 = new ReportParameter("invdate", trdate);
            ReportParameter rp8 = new ReportParameter("invno", invno);
            ReportParameter rp9 = new ReportParameter("payment", payment);
            ReportParameter rp10 = new ReportParameter("seller", adduser);
           
            ReportParameter rp11 = new ReportParameter();
            rp11.Name="qrcode";
            rp11.Values.Add(@"file:///"+imgpath);
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
            reportViewer1.LocalReport.EnableExternalImages = true;

            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp1,rp2,rp3,rp4,rp5,rp6,rp7,rp8,rp9,rp10,rp11,rp12,rp13,rp14,rp15,rp16,rp17,rp18 });
            this.reportViewer1.RefreshReport();
            DataTable dt = DisplayAllsales();
            
            salesdetailBLLBindingSource.DataSource = dt;


        }

        public DataTable DisplayAllsales()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT a.trdate as Date,b.productname As name,sum(qty) as qty,rate as rate, sum(b.total) as total from tbl_sales a,tbl_sdetail b where b.trid=a.id and a.id='"+txtbox1.Text+"' group by b.productid";
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

        public DataTable GetSalesData()
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dts = new DataTable();
            try
            {

                string mysql = "select * from tbl_sales where id='" + txtbox1.Text + "'";

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

        public DataTable GetCustomer(string custname)
        {
            SqlConnection myconn = new SqlConnection(myconnstrng);
            DataTable dtcust = new DataTable();
            //MessageBox.Show(custname);
            try
            {

                string mysql = "select * from tbl_accts where name='"+custname+"'";

                myconn.Open();
                SqlCommand cmd3 = new SqlCommand(mysql, myconn);
                SqlDataAdapter da = new SqlDataAdapter(mysql, myconn);

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

        private void salesdetailBLLBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            DataTable dt = DisplayAllsales();
            salesdetailBLLBindingSource.DataSource = dt;
            
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
        public string ImageToBase64(Image image,
  System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

    }
}
