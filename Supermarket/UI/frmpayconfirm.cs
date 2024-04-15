using Microsoft.Reporting.WinForms;
using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmpayconfirm : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        TextBox txtid = new TextBox();
        TextBox paymethod = new TextBox();
        TextBox checkpay = new TextBox();
        companyDAL cmpdal = new companyDAL();
        //tempsalesDAL sdal = new tempsalesDAL();
        DataTable sales = new DataTable();
        DataTable details = new DataTable();
        productsBLL pdal = new productsBLL();
        salesDAL sdal = new salesDAL();
        private TextBox focusedTextbox = null;
        TextBox oldbalance = new TextBox();
        public int sessionid;
        public string sess = "";


        public string ReturnValue1 { get; set; }
        public string ReturnValue2 { get; set; }
        public string ReturnValue3 { get; set; }
        public string ReturnValue4 { get; set; }
        public string ReturnValue5 { get; set; }
        public frmpayconfirm(string grandtotal)
        {
            InitializeComponent();
            txtgrandtotal.Text = grandtotal;
            txtdue.Text = grandtotal;
        }
        Control ActiveControl;
        void textBox_Enter(object sender, EventArgs e)
        {
            focusedTextbox = (TextBox)sender;
        }

        private void frmtableconfirm_Load(object sender, EventArgs e)
        {
            
            oldbalance.Text = txtdue.Text;
            this.ActiveControl = txtcash;
            
        }

        private void btncard_Click(object sender, EventArgs e)
        {
            paymethod.Text = "2";
            
            txtcard.Text = txtdue.Text;
            txtcash.Text = "0.00";
            txtblance.Text = "0.00";
            btncash.Enabled = false;
            btnboth.Enabled = false;
            btncredit.Enabled = false;
            btnok.Enabled = true;
        }

     /*
        
        public void frmClear()
        {

            foreach (var f in Application.OpenForms.OfType<frmtablefollow>().ToList())
            {
                f.Close();
            }
            foreach (var t in Application.OpenForms.OfType<frmtablesales>().ToList())
            {
                t.Close();
            }
            foreach (var et in Application.OpenForms.OfType<frmtablesalesedit>().ToList())
            {
                et.Close();
            }
            foreach (var ct in Application.OpenForms.OfType<frmtableconfirm>().ToList())
            {
                ct.Close();
            }
            foreach (var ctf in Application.OpenForms.OfType<frmtables>().ToList())
            {
                ctf.Close();
            }
            c.tabno = txtid.Text;
            bool y = sdal.delete(c);
            frmtables frm = new frmtables();
            frm.Show();
            frm.WindowState = FormWindowState.Normal;
            frm.ShowInTaskbar = true;


        }
     */
        private void btncash_Click(object sender, EventArgs e)
        {
            paymethod.Text = "1";
            //btncard.Enabled = false;
            txtcash.Text = txtdue.Text;
            txtcard.Text = "0.00";
            txtblance.Text = "0.00";
            btncard.Enabled = false;
            btnboth.Enabled = false;
            btncredit.Enabled = false;
            btnok.Enabled = true;
            
            
        }

        
        

        private void frmtableconfirm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmClear();
        }

        private void btnok_Click(object sender, EventArgs e)
        {

            this.ReturnValue1 = paymethod.Text;
            this.ReturnValue2 = txtcash.Text;
            this.ReturnValue3 = txtcard.Text;
            this.ReturnValue4 = txtdiscount.Text;
            this.ReturnValue5 = txtdue.Text;

            this.DialogResult = DialogResult.OK;
                this.Close();
            

        }




        private void txtcash_Validated(object sender, EventArgs e)
        {
            // double balance = 0;
            try
            {
                double balance = (double.Parse(oldbalance.Text) - double.Parse(txtcash.Text) - double.Parse(txtcard.Text));
                if (balance < 0)
                {
                    MessageBox.Show("المدفوع اكبر من قيمة الفاتورة");
                }
                txtblance.Text = balance.ToString("#,0.00");
            }
            catch(Exception ex)
            {
                MessageBox.Show("خطأ فى الادخال");
            }

           
            
            btnok.Enabled = txtblance.Text == "0.00";
            

            
        }

        private void txtcard_Validated(object sender, EventArgs e)
        {

            try
            {
                double balance = (double.Parse(oldbalance.Text) - double.Parse(txtcash.Text) - double.Parse(txtcard.Text));
                if (balance < 0)
                {
                    MessageBox.Show("المدفوع اكبر من قيمة الفاتورة");
                }
                txtblance.Text = balance.ToString("#,0.00");
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطأ فى الادخال");
            }
            btnok.Enabled = txtblance.Text == "0.00";

            /*
            if (balance == 0)
            {
                btnok.Enabled = true;
            }
            else
            {
                btnok.Enabled = false;
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            SendKeys.Send(btn.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (txtcash.Text == "")
            {
                txtcash.Focus();
            }
            else if (txtcard.Text == "")
            {
                txtcard.Focus();
            }
            else if (txtdiscount.Text == "")
            {
                txtdiscount.Focus();
            }else
            {
                txtcash.Text = "0";
                txtcard.Text = "0";
                txtblance.Text="0.00";
                txtdiscount.Text = "0";
            }
        }

        private void txtcash_Enter(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void txtcard_Enter(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }
        private void txtdiscount_Enter(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            string currentcont = this.ActiveControl.Name;
            switch (currentcont)
                {
                case "txtcash":
                    string oldcash = txtcash.Text;
                    txtcash.Text = (double.Parse(oldcash) + 10).ToString();
                    break;
                case "txtcard":
                    string oldcard = txtcard.Text;
                    txtcash.Text = (double.Parse(oldcard) + 10).ToString();
                    break;
                case "txtdiscount":
                    string olddiscount = txtdiscount.Text;
                    txtdiscount.Text = (double.Parse(olddiscount) + 10).ToString();
                    break;
                default:
                    break;

            }
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            string currentcont = this.ActiveControl.Name;
            if (currentcont == "txtcash")
            {
                string oldcash = txtcash.Text;
                txtcash.Text = (double.Parse(oldcash) + 20).ToString();
            }
            else if (currentcont == "txtcard")
            {
                string oldcard = txtcard.Text;
                txtcash.Text = (double.Parse(oldcard) + 20).ToString();
            }
            else if (currentcont == "txtdiscount")
            {
                string olddiscount = txtdiscount.Text;
                txtdiscount.Text = (double.Parse(olddiscount) + 20).ToString();
            }
            else
            {

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            string currentcont = this.ActiveControl.Name;
            if (currentcont == "txtcash")
            {
                string oldcash = txtcash.Text;
                txtcash.Text = (double.Parse(oldcash) + 50).ToString();
            }
            else if (currentcont == "txtcard")
            {
                string oldcard = txtcard.Text;
                txtcash.Text = (double.Parse(oldcard) + 50).ToString();
            }
            else if (currentcont == "txtdiscount")
            {
                string olddiscount = txtdiscount.Text;
                txtdiscount.Text = (double.Parse(olddiscount) + 50).ToString();
            }
            else
            {

            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            ActiveControl.Focus();
            string currentcont = this.ActiveControl.Name;
            if (currentcont == "txtcash")
            {
                string oldcash = txtcash.Text;
                txtcash.Text = (double.Parse(oldcash) * -1).ToString();
            }
            else if (currentcont == "txtcard")
            {
                string oldcard = txtcard.Text;
                txtcash.Text = (double.Parse(oldcard) *- 1).ToString();
            }
            else
            {

            }
        }

        private void btnboth_Click(object sender, EventArgs e)
        {
            paymethod.Text = "3";
            //btncash.Enabled = false;
            btnboth.BackColor = Color.AliceBlue;
        }

        private void txtdiscount_Validated(object sender, EventArgs e)
        {
            double due = double.Parse(txtgrandtotal.Text) - double.Parse(txtdiscount.Text);
            txtdue.Text = due.ToString("#,0.00");
            oldbalance.Text = txtdue.Text;
        }

        private void txtdiscount_Enter_1(object sender, EventArgs e)
        {
            ActiveControl = (Control)sender;
        }

        private void btncredit_Click_1(object sender, EventArgs e)
        {
            paymethod.Text = "4";
            //btncard.Enabled = false;
            
            txtcash.Text = "0.00";
            txtcard.Text = "0.00";
            txtblance.Text = "0.00";
            btncash.Enabled = false;
            btnboth.Enabled = false;
            btncard.Enabled = false;
            btnok.Enabled = true;
            
        }
    }
    
}
