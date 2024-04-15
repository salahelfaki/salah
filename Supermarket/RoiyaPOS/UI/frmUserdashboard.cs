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
    public partial class frmUserdashboard : Form
    {
        public frmUserdashboard()
        {
            InitializeComponent();
        }

        public static string transactontype;

        private void frmUserdashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
        }

        private void frmUserdashboard_Load(object sender, EventArgs e)
        {
            lbloggedinuser.Text = frmlogin.loggedin;
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactontype = "Purchase";
            frmpurchase purchase = new frmpurchase();
            purchase.Show();
            
            
           
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transactontype = "Sales";
             frmsales sales = new frmsales();
            sales.Show();
            
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frminventory inventory = new frminventory();
            inventory.Show();
        }
    }
}
