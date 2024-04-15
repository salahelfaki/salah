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
    public partial class frmcategories : Form
    {
        public frmcategories()
        {
            InitializeComponent();
        }

        private void frmcategories_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvcategories.DataSource = dt;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        categoriesBLL c = new categoriesBLL();
        categoriesDAL dal = new categoriesDAL();
        usersDAL udal = new usersDAL();

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.title = txttitle.Text;
            c.description = txtdescription.Text;
            c.added_date = DateTime.Now;

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show("New Category Inserted Suceessfully");
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to insert category");

            }


        }
        public void clear()
        {
            txtcategoryid.Text = "";
            txttitle.Text = "";
            txtdescription.Text = "";
            txtsearch.Text = "";
        }

        private void dgvcategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            txtcategoryid.Text = dgvcategories.Rows[rowindex].Cells[0].Value.ToString();
            txttitle.Text = dgvcategories.Rows[rowindex].Cells[1].Value.ToString();
            txtdescription.Text = dgvcategories.Rows[rowindex].Cells[2].Value.ToString();

            


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtcategoryid.Text);
            c.title = txttitle.Text;
            c.description = txtdescription.Text;
            c.added_date = DateTime.Now;
            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show("Category Updated Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to update category");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtcategoryid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show("Category Deleted Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete Category");
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvcategories.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
        }
    }
}
