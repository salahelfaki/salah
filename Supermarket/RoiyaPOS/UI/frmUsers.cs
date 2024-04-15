using supermarket.BLL;
using supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        usersBLL u = new usersBLL();
        usersDAL dal = new usersDAL();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string loggedinuser = frmlogin.loggedin;


            u.first_name = txtfirstname.Text;
            u.last_name = txtlastname.Text;
            u.email = txtemail.Text;
            u.username = txtusername.Text;
            u.password = txtpassword.Text;
            u.contact = txtcontact.Text;
            u.address = txtaddress.Text;
            u.gender = txtgender.Text;
            u.user_type = txtusertype.Text;
            u.added_date = DateTime.Now;
           

            usersBLL usr = dal.getidfromusername(loggedinuser);
            u.added_by = usr.id;

            bool success = dal.insert(u);
            if(success == true)
            {
                MessageBox.Show("User successfuly created.");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add user");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;




        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;
        }
        private void clear()
        {
            txtuserid.Text = "";
            txtfirstname.Text = "";
            txtlastname.Text = "";
            txtemail.Text = "";
            txtusername.Text = "";
            txtpassword.Text = "";
            txtcontact.Text = "";
            txtaddress.Text = "";
            txtgender.Text = "";
            txtusertype.Text = "";

        }

        private void dgvusers_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtuserid.Text = dgvusers.Rows[rowIndex].Cells[0].Value.ToString();
            txtfirstname.Text = dgvusers.Rows[rowIndex].Cells[1].Value.ToString();
            txtlastname.Text = dgvusers.Rows[rowIndex].Cells[2].Value.ToString();
            txtemail.Text = dgvusers.Rows[rowIndex].Cells[3].Value.ToString();
            txtusername.Text = dgvusers.Rows[rowIndex].Cells[4].Value.ToString();
            txtpassword.Text = dgvusers.Rows[rowIndex].Cells[5].Value.ToString();
            txtcontact.Text = dgvusers.Rows[rowIndex].Cells[6].Value.ToString();
            txtaddress.Text = dgvusers.Rows[rowIndex].Cells[7].Value.ToString();
            txtgender.Text = dgvusers.Rows[rowIndex].Cells[8].Value.ToString();
            txtusertype.Text = dgvusers.Rows[rowIndex].Cells[9].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtuserid.Text);
            u.first_name = txtfirstname.Text;
            u.last_name = txtlastname.Text;
            u.email = txtemail.Text;
            u.username = txtusername.Text;
            u.password = txtpassword.Text;
            u.contact = txtcontact.Text;
            u.address = txtaddress.Text;
            u.gender = txtgender.Text;
            u.user_type = txtusertype.Text;
            u.added_date = DateTime.Now;
            u.added_by = 1;

            bool success = dal.update(u);
            if (success == true)
            {
                MessageBox.Show("User Data Successfuly updated");
                clear();
            }
            else
            {
                MessageBox.Show("failed to update user data");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtuserid.Text);
            bool sucess = dal.delete(u);
            if (sucess == true)
            {
                MessageBox.Show("User Deleted Successfully");
                clear();
            }
            else
            {
                MessageBox.Show("failed to delete user");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if(keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvusers.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvusers.DataSource = dt;
            }
        }
    }
}
