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
    public partial class frmpurchaseStock : Form
    {
        public frmpurchaseStock()
        {
            InitializeComponent();
        }

        private void btnitems_Click(object sender, EventArgs e)
        {
            frmpurchase frm = new frmpurchase();
            frm.Show();
            this.Hide();
        }

        private void btndespense_Click(object sender, EventArgs e)
        {
            frmdexpense frm = new frmdexpense();
            frm.Show();
            this.Hide();
        }

        private void btnmexpense_Click(object sender, EventArgs e)
        {
            frmmexpense frm = new frmmexpense();
            frm.Show();
            this.Hide();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            frminventory frm = new frminventory();
            frm.Show();
            this.Hide();
        }

        private void btnreturn_Click(object sender, EventArgs e)
        {
            frmpurchasereturn frm = new frmpurchasereturn();
            frm.Show();
        }

        private void btntr_Click(object sender, EventArgs e)
        {
            frmitemtr frm = new frmitemtr();
            frm.Show();
        }
    }
}
