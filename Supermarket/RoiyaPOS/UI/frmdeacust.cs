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
    public partial class frmdeacust : Form
    {
        public frmdeacust()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        deacustBLL c = new deacustBLL();
        deacustDAL dal = new deacustDAL();
        usersDAL udal = new usersDAL();

        private void frmdeacust_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvdeacust.DataSource = dt;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.type = cmbtype.Text;
            c.name = txtname.Text;
            c.email = txtemail.Text;
            c.contact = txtcontact.Text;
            c.address = txtaddress.Text;
            c.added_date = DateTime.Now;

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show("New Dealer/Customer Inserted Suceessfully");
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to insert Customer/Dealer");

            }


        }
        public void clear()
        {
            txtid.Text = "";
            cmbtype.Text = "";
            txtname.Text = "";
            txtemail.Text = "";
            txtcontact.Text = "";
            txtaddress.Text = "";
            txtsearch.Text = "";
        }

        private void dgvdeacust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            txtid.Text = dgvdeacust.Rows[rowindex].Cells[0].Value.ToString();
            cmbtype.Text = dgvdeacust.Rows[rowindex].Cells[1].Value.ToString();
            txtname.Text = dgvdeacust.Rows[rowindex].Cells[2].Value.ToString();
            txtemail.Text = dgvdeacust.Rows[rowindex].Cells[3].Value.ToString();
            txtcontact.Text = dgvdeacust.Rows[rowindex].Cells[4].Value.ToString();
            txtaddress.Text = dgvdeacust.Rows[rowindex].Cells[5].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtid.Text);
            c.type = cmbtype.Text;
            c.name = txtname.Text;
            c.email = txtemail.Text;
            c.contact = txtcontact.Text;
            c.address = txtaddress.Text;
            c.added_date = DateTime.Now;

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show("Dealer/Customer Updated Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to update Customer/Dealer");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show("Dealer/Customer Deleted Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete Dealer/Customer");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvdeacust.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
        }
    }
}
