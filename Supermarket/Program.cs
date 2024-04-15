using Supermarket.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    static class Program
    {
        static Mutex m;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool first = false;
            bool isconnect = false;
            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if (first)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                // Check connection
                isconnect = checkDB();
                if (isconnect)
                {
                    Application.Run(new FrmLicense());
                }
                else
                {
                    Application.Run(new connect());
                }

                

                // Application.Run(new FrmLicense());
                // Application.Run(new frmlogin());
                // Application.Run(new frmAdminDashboard());
               // Application.Run(new connect());
                m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Another Instance running");
                return;
            }
        }
        static bool checkDB()
        {
            //var connString = @"Server=myServerName\myInstanceName;Database=myDataBase;Integrated Security=true;";
            var myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
            //SqlConnection con = new SqlConnection(myconnstrng);
            try
            {
                using (var con = new SqlConnection(myconnstrng))
                {
                    con.Open();
                    using (var com = new SqlCommand("SELECT * FROM tbl_users", con))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(com);
                        
                        // use your query here...
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
