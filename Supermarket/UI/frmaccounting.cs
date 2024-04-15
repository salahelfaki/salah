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
    public partial class frmaccounting : Form
    {
        public frmaccounting()
        {
            InitializeComponent();
        }

        private void btnpayment_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpayment.ClientRectangle,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
            
        }

        private void btncreditnote_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btncreditnote.ClientRectangle,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }


        private void frmaccounting_Load(object sender, EventArgs e)
        {

        }

        private void btnpayment_Click(object sender, EventArgs e)
        {
            frmpayment frm = new frmpayment();
            frm.Show();
            this.Hide();
        }

        private void btncreditnote_Click(object sender, EventArgs e)
        {
            frmcreditnote frm = new frmcreditnote();
            frm.Show();
            this.Hide();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            frmaccts frm = new frmaccts();
            frm.Show();
        }

        private void btnbill_Click(object sender, EventArgs e)
        {
            frmpurchase frm = new frmpurchase();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnjrnl_Click(object sender, EventArgs e)
        {
            frmrecouncil frm = new frmrecouncil();
            frm.Show();
        }

        private void btnexpense_Click(object sender, EventArgs e)
        {
            frmexpenses frm = new frmexpenses();
            frm.Show();
        }

        private void btnexpense_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpayment.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }

        private void btnjrnl_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpayment.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
