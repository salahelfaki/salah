using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class printorders : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public printorders()
        {
            InitializeComponent();
        }

        private void btnload_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(myconnstrng);
            con.Open();
            string query = "Select tbl_sales.id,trdate,subtotal,vat,discount,grandtotal,paymethod,productid,productname,rate,qty, total from tbl_sales,tbl_sdetail where tbl_sales.id=tbl_sdetail.trid"; // and trdate between '{fromdate.Value}' AND '{todate.Value}'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvorders.DataSource = dt;





        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            int j = 120;
            SqlConnection con = new SqlConnection(myconnstrng);
            con.Open();
            try
            {
                string query = "Select tbl_sales.id,trdate,subtotal,vat,discount,grandtotal,paymethod,productid,productname,rate,qty, total from tbl_sales,tbl_sdetail where tbl_sales.id=tbl_sdetail.trid"; // and trdate between '{fromdate.Value}' AND '{todate.Value}'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvorders.DataSource = dt;
                // Headers and footer values
                string mtrid = dgvorders.Rows[1].Cells[0].Value.ToString();
                string mdate = (dgvorders.Rows[1].Cells[1].Value.ToString()).Substring(0,10);
                string msubtotal = dgvorders.Rows[1].Cells[2].Value.ToString();
                string mvat = dgvorders.Rows[1].Cells[3].Value.ToString();
                string mgtotal = dgvorders.Rows[1].Cells[5].Value.ToString();

                e.Graphics.DrawString("Order No:"+mtrid, new Font("calibri", 12, FontStyle.Bold), Brushes.Black, new Point(10, 10));
                e.Graphics.DrawString("Order Date:"+mdate, new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(10, 50));
                e.Graphics.DrawString("ID  Name                  Qty     Unit Price   Total", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(10, 100));

                
                    //foreach (DataColumn dc in dgvorders.Columns)
                    //{
                        for (int i = 0; i < dgvorders.Rows.Count - 1; i++)
                         {

                        string mpid = dgvorders.Rows[i].Cells[7].Value.ToString();
                        string mpname = dgvorders.Rows[i].Cells[8].Value.ToString();
                        string mqty = dgvorders.Rows[i].Cells[10].Value.ToString();
                        string mrate = dgvorders.Rows[i].Cells[9].Value.ToString();
                        string mtotal = dgvorders.Rows[i].Cells[11].Value.ToString();
                        e.Graphics.DrawString(mpid, new Font("arial", 10), Brushes.Black, new Point(10, j));
                        e.Graphics.DrawString(mpname, new Font("arial", 10), Brushes.Black, new Point(20, j));
                        e.Graphics.DrawString(mqty, new Font("arial", 10), Brushes.Black, new Point(130, j));
                        e.Graphics.DrawString(mrate, new Font("arial", 10), Brushes.Black, new Point(180, j));
                        e.Graphics.DrawString(mtotal, new Font("arial", 10), Brushes.Black, new Point(240, j));
                        
                        j = j + 20;
                    }
                e.Graphics.DrawString("Subtotal", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(120, j));
                e.Graphics.DrawString(msubtotal, new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(220, j));
                e.Graphics.DrawString("VAT 15%", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(120, j+30));
                e.Graphics.DrawString(mvat, new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(220, j+30));
                e.Graphics.DrawString("Total Amount", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(120, j+60));
                e.Graphics.DrawString(mgtotal, new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(220, j+60));

                e.Graphics.DrawString("***Thank you for visiting our Supermarket***", new Font("calibri", 10, FontStyle.Bold), Brushes.Black, new Point(15, j + 80));
                //}


            }
            catch (Exception )
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
