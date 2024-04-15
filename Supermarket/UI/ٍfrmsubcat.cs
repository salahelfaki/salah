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
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmsubcat : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmsubcat()
        {
            InitializeComponent();
        }

        
        subcatBLL c = new subcatBLL();
        subcatDAL sdal = new subcatDAL();
        usersDAL udal = new usersDAL();
        private void frmsubcat_Load(object sender, EventArgs e)
        {
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            DataTable dt = sdal.Select();
            dgvsubcat.DataSource = dt;
            if (t.CurrentCulture.Name == "ar-SA")
            {
                dgvsubcat.Columns[0].HeaderText = "الرقم";
                dgvsubcat.Columns[1].HeaderText = "المجموعة";
                dgvsubcat.Columns[2].HeaderText = "الاسم";
            }
            else
            {
                dgvsubcat.Columns[0].HeaderText = "ID";
                dgvsubcat.Columns[1].HeaderText = "Main Category";
                dgvsubcat.Columns[2].HeaderText = "Name";

            }

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
            cmbcategid.DataSource = ds.Tables["categories"];
            // Tell the combo box what collumn to display to the user
            cmbcategid.DisplayMember = "title";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbcategid.ValueMember = "title";
            conn.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.categid = cmbcategid.Text;
            c.name = txtname.Text;
            /* 
             byte[] images = null;
             FileStream streem = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
             BinaryReader brs = new BinaryReader(streem);
             images = brs.ReadBytes((int)streem.Length);

             c.cimage = imglocation;

             //c.cimage = txtimage.Text;
            */
            string loggeduser = frmlogin.loggedin;
            //usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = sdal.Insert(c);
            if (Success == true)
            {
                MessageBox.Show("تمت الإضافة بنجاح");
                clear();
                DataTable dt = sdal.Select();
                dgvsubcat.DataSource = dt;
            }
            else
            {
                MessageBox.Show("خطأ...فشلت الاضافة");

            }


        }
        public void clear()
        {
            txtsubcatid.Text = "";
            cmbcategid.Text = "";
            txtname.Text = "";
            txtsearch.Text = "";
            // pictureBox.Image = null;
        }

        private void dgvsubcat_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;


            txtsubcatid.Text = dgvsubcat.Rows[rowindex].Cells[0].Value.ToString();
            cmbcategid.Text = dgvsubcat.Rows[rowindex].Cells[1].Value.ToString();
            txtname.Text = dgvsubcat.Rows[rowindex].Cells[2].Value.ToString();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtsubcatid.Text);
            c.categid = cmbcategid.Text;
            c.name = txtname.Text;
            /*
            byte[] images = null;
            FileStream streem = new FileStream(txtcimage.Text, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);

            c.cimage = imglocation;

            */
            string loggeduser = frmlogin.loggedin;
            //usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = sdal.update(c);
            if (success == true)
            {
                MessageBox.Show("تم التحديث");
                clear();
                DataTable dt = sdal.Select();
                dgvsubcat.DataSource = dt;
            }
            else
            {
                MessageBox.Show("فشل التحديث");
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtsubcatid.Text);
            bool success = sdal.delete(c);
            if (success == true)
            {
                MessageBox.Show("Category Deleted Successfully");
                clear();
                DataTable dt = sdal.Select();
                dgvsubcat.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Failed To Delete Category");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = sdal.Search(keywords);
                dgvsubcat.DataSource = dt;
            }
            else
            {
                DataTable dt = sdal.Select();
                dgvsubcat.DataSource = dt;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    
}
