using Supermarket.BLL;
using Supermarket.DAL;
using Supermarket.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket
{
    public partial class frmUserdashboard : Form
    {
        companyBLL c = new companyBLL();
        companyDAL dal = new companyDAL();
        public frmUserdashboard()
        {
            DataTable dt = dal.Select();
            string lang = dt.Rows[0]["lang"].ToString();
            switch (lang)
            {
                case "Arabic":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-SA");
                    break;
                case "English":
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    break;
            }
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
            string langCulture = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag;
            //MessageBox.Show(langCulture);
            CultureInfo culture = new CultureInfo(langCulture);
            DayOfWeek wk = DateTime.Today.DayOfWeek;
            //lblday.Text = DateTime.Now.ToString("dddd", culture);
            string md1 = DateTime.Now.ToString("MMMM",culture);
            string md2= DateTime.Now.ToString("yyyy-dd",culture);
          //  lbldate.Text = md1 + "," + md2;
          //  lbltime.Text=DateTime.Now.ToString("HH:mm:ss");
            label2.Text = frmlogin.loggedin;

        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmproducts prod = new frmproducts();
            prod.Show();
            
            
           
        }

        

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsales sales = new frmsales();
            sales.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmcategories categ = new frmcategories();
            categ.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mainCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void المجموعاتالرئيسيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcategories categ = new frmcategories();
            categ.Show();
        }

        private void المجموعاتالفرعيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsubcat subcat = new frmsubcat();
            subcat.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmsubcat subcateg = new frmsubcat();
            subcateg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmproducts products = new frmproducts();
            products.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmsales sales = new frmsales();
            sales.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void تقاريرToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
