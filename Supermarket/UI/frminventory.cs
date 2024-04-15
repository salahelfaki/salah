using Supermarket.DAL;
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
    public partial class frminventory : Form
    {
        public frminventory()
        {
            InitializeComponent();
        }
        categoriesDAL cdal = new categoriesDAL();
        productsDAL pdal = new productsDAL(); 

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frminventory_Load(object sender, EventArgs e)
        {
            // display categories on combo box
            DataTable cdt = cdal.Select();
            cmbcategory.DataSource = cdt;
            // Give the value member and display
            cmbcategory.DisplayMember = "title";
            cmbcategory.ValueMember = "title";

            //display in data grid view
            DataTable pdt = pdal.Select();
            dgvinventory.DataSource = pdt;
        }

        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cmbcategory.Text;
            DataTable dt = pdal.DisplayProductsByCategory(category);
            dgvinventory.DataSource = dt;
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            //Display all products
            DataTable dt = pdal.Select();
            dgvinventory.DataSource = dt;
        }
    }
}
