using supermarket.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarket
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();

        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            lbloggedinuser.Text = frmlogin.loggedin;
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcategories category = new frmcategories();
            category.Show();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproducts products = new frmproducts();
            products.Show();
        }

        private void dealersCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmdeacust deacust = new frmdeacust();
            deacust.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void transactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmtransactions transaction = new frmtransactions();
            transaction.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frminventory inventory = new frminventory();
            inventory.Show();
        }
    }
}
