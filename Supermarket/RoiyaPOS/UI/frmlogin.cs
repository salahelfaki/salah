using supermarket.BLL;
using supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket.UI
{
    public partial class frmlogin : Form
    {
        public frmlogin()
        {
            InitializeComponent();
        }
        loginBLL l = new loginBLL();
        loginDAL dal = new loginDAL();
        public static string loggedin;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            l.username = txtuname.Text.Trim();
            l.password = txtpass.Text.Trim();
            l.user_type = cmbutype.Text.Trim();

            bool success = dal.loginCheck(l);
            if (success == true)
            {
                //MessageBox.Show("Login Successful.");
                loggedin = l.username;
                switch(l.user_type)
                {
                    case "Admin":
                        {
                            frmmaindashboard admin = new frmmaindashboard();
                            //frmAdminDashboard admin = new frmAdminDashboard();
                            admin.Show();
                            this.Hide();
                        }
                        break;
                    case "User":
                        {
                            frmUserdashboard user = new frmUserdashboard();
                            user.Show();
                            this.Hide();
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("Invalid User Type");
                        }
                        break;

                }
            }
            else
            {
                MessageBox.Show("Login Failed. Try again");
            }

        }
        //test
        
        //test
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
            this.Controls.Clear();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (btnlang.Text == "AR")
            {

                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar");
                this.Controls.Clear();
                InitializeComponent();
                btnlang.Text = "EN";
            }
            else if (btnlang.Text=="EN")
            { 
                
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                this.Controls.Clear();
                InitializeComponent();
                btnlang.Text = "AR";
             }

            }
            
        }
    }

