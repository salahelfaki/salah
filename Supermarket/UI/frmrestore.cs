using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmrestore : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmrestore()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName.ToString();
            }
        }
        private static readonly string filePath = Environment.CurrentDirectory;
        private void btnrest_Click(object sender, EventArgs e)
        {
            var filename = "Supermarket.db";


            var bkupFilename = textBox1.Text;

            RestoreDB(filePath, bkupFilename, filename);
        }

            

        

        
        private static void RestoreDB(string filePath, string srcFilename, string destFileName) //, bool IsCopy = false)
        {
            var srcfile = Path.Combine(filePath, srcFilename);
            var destfile = Path.Combine(filePath, destFileName);

            try
            {
                if (File.Exists(destfile))
                {
                    SqlConnection connection = new SqlConnection(myconnstrng);
                    connection.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    File.Delete(destfile);
                }
            }
            catch (Exception ex)
            {
                File.Delete(destfile);
            }

            //if (File.Exists(destfile)) File.Delete(destfile);

            //if (IsCopy)
              //  BackupDB(filePath, srcFilename, destFileName);
            //else
                File.Copy(srcfile, destfile);
            MessageBox.Show("Restored Successfully...");
        }

    }
}
