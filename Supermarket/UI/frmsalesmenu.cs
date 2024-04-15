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
    public partial class frmsalesmenu : Form
    {
        public frmsalesmenu()
        {
            InitializeComponent();
        }


        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btninvoice_Click(object sender, EventArgs e)
        {
            frmsales frm = new frmsales();
            frm.Show();
        }

        private void btnproforma_Click(object sender, EventArgs e)
        {
            frmproforma frm = new frmproforma();
            frm.Show();
        }

        private void btnconvert_Click(object sender, EventArgs e)
        {
            frmproview frm = new frmproview();
            frm.Show();
        }
    }
}
