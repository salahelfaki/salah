using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class connect : Form
    {
        public connect()
        {
            InitializeComponent();
        }

        private void connect_Load(object sender, EventArgs e)
        {
            cboserver.Items.Add(".");
            cboserver.Items.Add("(local)");
            cboserver.Items.Add(@".\SQLEXPRESS");
            cboserver.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboserver.SelectedIndex = 3;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboserver.Text, txtdatabase.Text, txtusername.Text, txtpassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                {
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("connstrng", connectionString);
                    MessageBox.Show("connection String Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmLicense frm = new FrmLicense();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", cboserver.Text, txtdatabase.Text, txtusername.Text, txtpassword.Text);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);
                if (helper.IsConnection)
                    MessageBox.Show("Test connection succeeded", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
