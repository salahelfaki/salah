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
    public partial class frmitemcategrep : Form
    {
        public frmitemcategrep()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmitemsalerep frm = new frmitemsalerep();
            frm.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmcategsalerep frm = new frmcategsalerep();
            frm.Show();
            this.Hide();
        }

        private void btnsummary_Click(object sender, EventArgs e)
        {
            frmcategSumrep frm = new frmcategSumrep();
            frm.Show();
            this.Hide();
        }
    }
}
