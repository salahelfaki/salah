using Microsoft.Win32;
using Supermarket.BLL;
using Supermarket.DAL;
using Supermarket.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmlogin : Form
    {

       
        companyBLL c = new companyBLL();
        private TextBox focusedTextbox = null;
        public frmlogin()
        {
            companyDAL dal = new companyDAL();
            DataTable dt = dal.Select();
            string lang = dt.Rows[0]["lang"].ToString();
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
          
            InitializeComponent();
            
         
        }




            loginBLL l = new loginBLL();
            loginDAL dal = new loginDAL();
        usersDAL udal = new usersDAL();
        public static string loggedin;
        public static string userrole;



        void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }
        Control ActiveControl;
        private void btnlogin_Click(object sender, EventArgs e)
        {
            l.username = txtuname.Text.Trim();
            l.password = txtpass.Text.Trim();
           

            bool success = dal.loginCheck(l);
            if (success == true)
            {
                //MessageBox.Show("Login Successful.");
                DataTable dt = udal.UserList(txtuname.Text, txtpass.Text);
                loggedin = dt.Rows[0]["name"].ToString();
                userrole = dt.Rows[0]["usertype"].ToString();
                myDashboard frm = new myDashboard();
                frm.Show();
                //frmAdminDashboard admin = new frmAdminDashboard();
                //admin.Show();

                this.Hide();
                




            }
            else
            {
                MessageBox.Show("Login Failed. Try again");
            }


        }

        private void frmlogin_Load(object sender, EventArgs e)
        {

            this.ActiveControl = txtuname;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            SendKeys.Send(btn.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                txtuname.Focus();
            }
            else if (txtpass.Text == "")
            {
                txtpass.Focus();
            }
            else
            {
                if (txtpass.Text == "")
                {
                    txtpass.Focus();
                }
                else
                {
                    l.username = txtuname.Text.Trim();
                    l.password = txtpass.Text.Trim();
                    //l.usertype = cmbutype.Text.Trim();

                    bool success = dal.loginCheck(l);
                    if (success == true)
                    {
                        //MessageBox.Show("Login Successful.");
                        DataTable dt = udal.UserList(txtuname.Text, txtpass.Text);
                        loggedin = dt.Rows[0]["name"].ToString();
                        userrole = dt.Rows[0]["usertype"].ToString();

                        //frmAdminDashboard admin = new frmAdminDashboard();
                        myDashboard admin = new myDashboard();
                        admin.Show();

                        this.Hide();




                    }
                    else
                    {
                        MessageBox.Show("Login Failed. Try again");
                    }

                }
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void button14_Click(object sender, EventArgs e)
        {

            txtpass.Text = "";
            txtuname.Text = "";
        }

        private void txtuname_Enter(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


