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
    public partial class frmtransactions : Form
    {
        public frmtransactions()
        {
            InitializeComponent();
        }
        transactionDAL tdal = new transactionDAL();

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmtransactions_Load(object sender, EventArgs e)
        {
            // Display all transactions
            DataTable dt = tdal.DisplayAllTransactions();
            dgvtransaction.DataSource = dt;

        }

        private void cmbtransactiontype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cmbtransactiontype.Text;
            DataTable dt = tdal.DisplayTransactionbyType(type);
            dgvtransaction.DataSource = dt;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            // Display all transactions
            DataTable dt = tdal.DisplayAllTransactions();
            dgvtransaction.DataSource = dt;
        }
    }
}
