using Supermarket.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class frmbackup : Form
    {
        public frmbackup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var source = new SqlConnection("Data Source = Supermarket.db; version = 3"))
            using (var destination = new SqlConnection("Data Source=" + textBox1.Text + "/" + DateTime.Now.ToString("yyyyMMdd") + "backup.db"))
            {
                source.Open();
                destination.Open();
               // source.BackupDatabase(destination, "main", "main", -1, null, 0);
            }
            MessageBox.Show("Backup Successfull...");
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox1.Text = fbd.SelectedPath.ToString();
                    Settings.Default.BackupDir = textBox1.Text;
                    Settings.Default.Save();

                    
                }
            }
            /*
            OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName.ToString();
                
            }
            */
        }
        private static void RestoreDB(string filePath, string srcFilename, string  destFileName) //, bool IsCopy = false)
        {
            var srcfile = Path.Combine(filePath, srcFilename);
            var destfile = Path.Combine(filePath, destFileName);

            if (File.Exists(destfile)) File.Delete(destfile);

           // if (IsCopy)
             //   BackupDB(filePath, srcFilename, destFileName);
            //else
                File.Move(srcfile, destfile);
        }

    }
}
