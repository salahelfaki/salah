using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.BLL;
using Supermarket.DAL;
using System.Data.SqlClient;
using System.IO;

namespace Supermarket.UI
{
    public partial class frmitems : Form
    {
        public frmitems()
        {
            InitializeComponent();
        }

     
        private void frmitems_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvitems.DataSource = dt;


            /*
            string sql = "Select * from tbl_categories";
            SqlConnection conn = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql, conn);


            // Create the data adapter to use to get the data and handle connecting to the DB
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            // Get the data from the database. I am using the Northwind database the customers table
            da.Fill(ds, "categories");
            // Disconnect the event handler to handle the comboBox1_SelectedIndexChanged event
            // while the combo box is being populated, otherwise it will fire a couple of times
            // before you are ready to handle them.
            //this.cmbcategory.SelectedIndexChanged -= new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            // Connect the cobo box to the data source from where the data is comming from
            // In this case the Customers data table in the dataset.
            cmbcategory.DataSource = ds.Tables["categories"];
            // Tell the combo box what collumn to display to the user
            cmbcategory.DisplayMember = "title";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbcategory.ValueMember = "title";
            // Restored the event handler
            */

        }
        itemsBLL c = new itemsBLL();
        itemsDAL dal = new itemsDAL();
        usersDAL udal = new usersDAL();

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.name = txtname.Text;
            c.unit = txtunit.Text;

            

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show("New Item Inserted Suceessfully");
                clear();
                DataTable dt = dal.Select();
                dgvitems.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to insert item");

            }


        }
        public void clear()
        {
            txtname.Text = "";
            txtunit.Text = "";
            txtsearch.Text = "";
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtid.Text);
            c.name = txtname.Text;
            c.unit = txtunit.Text;

           


            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show("Item Updated Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvitems.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to update item");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show("Item Deleted Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvitems.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete Item");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvitems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvitems_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;

            txtid.Text = dgvitems.Rows[rowindex].Cells[0].Value.ToString();
            txtname.Text = dgvitems.Rows[rowindex].Cells[1].Value.ToString();
            txtunit.Text = dgvitems.Rows[rowindex].Cells[4].Value.ToString();
            




        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvitems.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvitems.DataSource = dt;
            }
        }
    }
    
    
}
