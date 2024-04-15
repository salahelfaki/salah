using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmsessionclose : Form
    {
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public frmsessionclose()
        {
            InitializeComponent();
        }
        salesDAL sdal = new salesDAL();
        printDAL prdal = new printDAL();
        sessionDAL ssdal = new sessionDAL();
        sessionBLL c = new sessionBLL();
        public string msessclose = "";
        public string fsessclose = "";
        public string msessopen = "";
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        string loggedinuser = frmlogin.loggedin;
        TextBox sessid = new TextBox();

        private void frmsessionclose_Load(object sender, EventArgs e)
        {
            if (t.CurrentCulture.Name == "ar-EG")
            {
                msessclose = "تم اغلاق الجلسة";
                fsessclose = "خطأ...فشل اغلاق الجلسة";
                msessopen = "لا توجد جلسة مفتوحة";
            }
            else
            {
                msessclose = "Session Closed...";
                fsessclose = "Error... Fail to close session";
                msessopen = "No pen Session";
            }
            DataTable ssdat = ssdal.Getsessions();

            //DataTable dt = sdal.GetSessionCloseSales(txtid.Text);


            dgvsalesrep.DataSource = ssdat;
            if (ssdat.Rows.Count > 0)
            {
                if (t.CurrentCulture.Name == "ar-EG")
                {
                    dgvsalesrep.Columns[0].HeaderText = "الرقم";
                    dgvsalesrep.Columns[1].HeaderText = "البداية من";
                    dgvsalesrep.Columns[2].HeaderText = "الموظف ";
                    dgvsalesrep.Columns[3].HeaderText = " عدد الفواتير";


                }
                else
                {

                    dgvsalesrep.Columns[0].HeaderText = "ID";
                    dgvsalesrep.Columns[1].HeaderText = "Start Time";
                    dgvsalesrep.Columns[2].HeaderText = "User";
                    dgvsalesrep.Columns[3].HeaderText = "No. of Invoices";






                }

                dgvsalesrep.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                /*
                                txtcash.Text = dt.Rows[0]["cash"].ToString();
                                txtcard.Text = dt.Rows[0]["card"].ToString();
                                txttotal.Text = dt.Rows[0]["credit"].ToString();
                                txtdiff.Text = dt.Rows[0]["total"].ToString();
                */






            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.status = 1;
            c.id = int.Parse(sessid.Text);

            bool x = ssdal.update(c);
            if (x == true)
            {
                MessageBox.Show(msessclose);
            }
            else
            {
                MessageBox.Show(fsessclose);
            }
        }

        private void dgvsalesrep_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            string tid = dgvsalesrep.Rows[rowindex].Cells[0].Value.ToString();
            sessid.Text = tid;
            DataTable dtc = ssdal.GetInvCount(tid);
            txtid.Text = dtc.Rows[0]["total"].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
