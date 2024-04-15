using MySql.Data.MySqlClient;
using supermarket.BLL;
using supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket.UI
{
    public partial class frmproducts : Form
    {
        public frmproducts()
        {
            InitializeComponent();
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        productsBLL c = new productsBLL();
        productsDAL dal = new productsDAL();
        usersDAL udal = new usersDAL();

        private void frmproducts_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvproducts.DataSource = dt;

            string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

            string sql = "Select * from tbl_categories";
            MySqlConnection conn = new MySqlConnection(myconnstrng);

            MySqlCommand cmd = new MySqlCommand(sql,conn);
            
            
            // Create the data adapter to use to get the data and handle connecting to the DB
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
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
            //this.cmbcategory.SelectedIndexChanged += new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
        }
        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the user clicks on a item in the combo box ist primary key will be displayed.
            MessageBox.Show("Category Primary Key is \"" + cmbcategory.SelectedValue + "\"");
        }

    

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.name = txtname.Text;
            c.description = txtdescription.Text;
            c.category =cmbcategory.Text;
            c.rate = decimal.Parse(txtrate.Text);
            c.qty = 0; // decimal.Parse(txtqty.Text);
            c.added_date = DateTime.Now;
            c.pcode = txtpcode.Text;
            c.pbarcode = txtpbarcode.Text;

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show("New Product Inserted Suceessfully");
                clear();
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to insert product");

            }


        }
        public void clear()
        {
            txtid.Text = "";
            txtname.Text = "";
            txtdescription.Text = "";
            cmbcategory.Text = "";
            txtrate.Text = "";
            txtqty.Text = "";
            txtsearch.Text = "";
            txtpcode.Text = "";
            txtpbarcode.Text = "";
        }

        private void dgvproducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            txtid.Text = dgvproducts.Rows[rowindex].Cells[0].Value.ToString();
            txtname.Text = dgvproducts.Rows[rowindex].Cells[1].Value.ToString();
            cmbcategory.Text = dgvproducts.Rows[rowindex].Cells[2].Value.ToString();
            txtdescription.Text = dgvproducts.Rows[rowindex].Cells[3].Value.ToString();
            txtrate.Text = dgvproducts.Rows[rowindex].Cells[4].Value.ToString();
            txtqty.Text = dgvproducts.Rows[rowindex].Cells[5].Value.ToString();
            txtpcode.Text = dgvproducts.Rows[rowindex].Cells[8].Value.ToString();
            txtpbarcode.Text = dgvproducts.Rows[rowindex].Cells[9].Value.ToString();


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtid.Text);
            c.name = txtname.Text;
            c.category = cmbcategory.Text;
            c.description = txtdescription.Text;
            c.rate = decimal.Parse(txtrate.Text);
            c.added_date = DateTime.Now;
            c.pbarcode = txtpbarcode.Text;
            c.pcode = txtpcode.Text;
            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show("Product Updated Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed to update product");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show("Product Deleted Successfully");
                clear();
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete product");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvproducts.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
        }
    }
    
}
