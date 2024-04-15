using Supermarket.BLL;
using Supermarket.DAL;
using Supermarket.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmtools : Form
    {
        public frmtools()
        {
            InitializeComponent();
        }
        public string madd = "";
        public string fadd = "";
        public string msess = "";
        public string msessclose = "";
        public string fsessclose = "";
        public string msessopen = "";

        sessionDAL sdal = new sessionDAL();
        sessionBLL c = new sessionBLL();
        usersDAL udal = new usersDAL();
        System.Threading.Thread t = System.Threading.Thread.CurrentThread;


        private void btnimport_Click(object sender, EventArgs e)
        {
            frmimport frm = new frmimport();
            frm.Show();
        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            frmexport frm = new frmexport();
            frm.Show();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            frmcleardata frm = new frmcleardata();
            frm.Show();
        }

        private void Btnback_Click(object sender, EventArgs e)
        {
            if(Settings.Default.BackupDir=="")
            {
                frmbackup frm = new frmbackup();
                frm.Show();
            }
            else
            {
                using (var source = new SqlConnection("Data Source = Supermarket.db; version = 3"))
                using (var destination = new SqlConnection("Data Source=" + Settings.Default.BackupDir + "/" + DateTime.Now.ToString("yyyyMMdd") + "backup.db"))
                {
                    source.Open();
                    destination.Open();
                    //source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }
                MessageBox.Show("Backup Successfull...");
            }
            
        }

        private void btnrestore_Click(object sender, EventArgs e)
        {
            frmrestore frm = new frmrestore();
            frm.Show();
        }

        private void btnbarcode_Click(object sender, EventArgs e)
        {
            this.Hide();
            var frmbarcode = new frmbarcode();
            frmbarcode.Closed += (s, args) => this.Close();
            frmbarcode.Show();
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = sdal.Getsessions();
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(msess);
                return;
            }
            else
            {
                //************



                c.sessionname = frmlogin.loggedin;
                c.sessionuser = frmlogin.loggedin;
                c.startdate = DateTime.Now;
                c.status = 0;

                bool Success = sdal.insert(c);
                if (Success == true)
                {
                    DataTable ssd = sdal.GetMaxId();
                    string myid = ssd.Rows[0]["id"].ToString();
                    int myno = int.Parse(myid);

                    MessageBox.Show(madd + "   " + myno.ToString());


                }
                else
                {
                    MessageBox.Show(fadd);

                }

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = sdal.Getsessions();
            if (dt.Rows.Count > 0)
            {
                frmsessionclose frm = new frmsessionclose();
                frm.Show();

            }
            else
            {
                MessageBox.Show("No Open Session");
                return;
            }
        }

        private void txtcode_TextChanged(object sender, EventArgs e)
        {
            if (txtcode.Text == "242")
            {
                btnclear.Enabled = true;
            }
        }
    }
}
