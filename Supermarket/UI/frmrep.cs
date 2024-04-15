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
    public partial class frmrep : Form
    {
        public frmrep()
        {
            InitializeComponent();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btndailyrep_Click(object sender, EventArgs e)
        {
            frmdailysales dsales = new frmdailysales();
            dsales.Show();
        }

        private void btnvat_Click(object sender, EventArgs e)
        {
            frmvatrep vatrep = new frmvatrep();
            vatrep.Show();

        }

        private void btnitemsale_Click(object sender, EventArgs e)
        {
            frmitemsalerep itemsales = new frmitemsalerep();
            itemsales.Show();
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            frmpurchaserep purchaserep = new frmpurchaserep();
            purchaserep.Show();
        }

        private void btnstock_Click(object sender, EventArgs e)
        {
            frmStockrep srep = new frmStockrep();
            srep.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaccttr_Click(object sender, EventArgs e)
        {
            frmaccttrep frm = new frmaccttrep();
            frm.Show();
        }

        private void btnacctbal_Click(object sender, EventArgs e)
        {
            frmacctbalrep frm = new frmacctbalrep();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmdayclose frm = new frmdayclose();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmcurrsession dsales = new frmcurrsession();
            dsales.Show();
        }

        private void btndailyrep_Click_1(object sender, EventArgs e)
        {
            frmsalesrep frm = new frmsalesrep();
            frm.Show();
        }

        private void btnpurchase_Click_1(object sender, EventArgs e)
        {
            frmpurchaserep purchaserep = new frmpurchaserep();
            purchaserep.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmsession frm = new frmsession();
            frm.Show();
        }

        private void btnitemsale_Click_1(object sender, EventArgs e)
        {
            frmitemsalerep itemsales = new frmitemsalerep();
            itemsales.Show();
        }

        private void btnitempurchase_Click(object sender, EventArgs e)
        {
            frmitempurchaserep frm = new frmitempurchaserep();
            frm.Show();
        }

        private void btnvat_Click_1(object sender, EventArgs e)
        {
            frmvatrep vatrep = new frmvatrep();
            vatrep.Show();
        }

        private void btnaccttr_Click_1(object sender, EventArgs e)
        {
            frmaccttrep frm = new frmaccttrep();
            frm.Show();
        }

        private void btnexprep_Click(object sender, EventArgs e)
        {
            frmexprep frm = new frmexprep();
            frm.Show();
        }

        private void btnacctbal_Click_1(object sender, EventArgs e)
        {
            frmacctbalrep frm = new frmacctbalrep();
            frm.Show();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            frmitemcategrep frm = new frmitemcategrep();
            frm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //frmfinalrep frm = new frmfinalrep();
            frmbalancesheet frm = new frmbalancesheet();
            frm.Show();
        }

        private void btnitemtr_Click(object sender, EventArgs e)
        {
            frmitemtr frm = new frmitemtr();
            frm.Show();
        }

        private void btnvalues_Click(object sender, EventArgs e)
        {
            frmvaluesrep frm = new frmvaluesrep();
            frm.Show();
        }

        private void btnstock_Click_1(object sender, EventArgs e)
        {
            frmStockrep frm = new frmStockrep();
            frm.Show();
        }
    }
}
