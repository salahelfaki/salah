using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmaccts : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmaccts()
        {
            InitializeComponent();
        }
        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";
        public string mytype = "";

        System.Threading.Thread t = System.Threading.Thread.CurrentThread;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        acctsBLL c = new acctsBLL();
        acctsDAL dal = new acctsDAL();
        usersDAL udal = new usersDAL();
        
        private void frmdeacust_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvdeacust.DataSource = dt;

            dgvdeacust.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvdeacust.EnableHeadersVisualStyles = false;
            dgvdeacust.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvdeacust.Columns[0].HeaderText = "التسلسل";
                dgvdeacust.Columns[1].HeaderText = "الرقم";
                dgvdeacust.Columns[2].HeaderText = "الاسم";
                dgvdeacust.Columns[3].HeaderText = "الرئيسي";
                dgvdeacust.Columns[4].HeaderText = "الرقم الضريبي";
                dgvdeacust.Columns[5].HeaderText = "التلفون ";
                dgvdeacust.Columns[6].HeaderText = "الايميل";
                dgvdeacust.Columns[7].HeaderText = "العنوان";
                dgvdeacust.Columns[8].HeaderText = "السجل";
                dgvdeacust.Columns[9].HeaderText = "الافتتاحي";

                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ...فشلت الاضافة.";
                mupdate = "تم تحديث البيانات";
                fupdate = "خطأ...فشل تحديث البيانات";
                mdelete = "تم الحذف";
                fdelete = "خطأ..فشل الحذف";
    }
            else
            {
                dgvdeacust.Columns[0].HeaderText = "ID";
                dgvdeacust.Columns[1].HeaderText = "Acct Code";
                dgvdeacust.Columns[2].HeaderText = "Name";
                dgvdeacust.Columns[3].HeaderText = "Main Acct ";
                dgvdeacust.Columns[4].HeaderText = "VAT No.";
                dgvdeacust.Columns[5].HeaderText = "Tel No.";
                dgvdeacust.Columns[6].HeaderText = "E-mail";
                dgvdeacust.Columns[7].HeaderText = "Address";
                dgvdeacust.Columns[6].HeaderText = "Reg. No";
                dgvdeacust.Columns[6].HeaderText = "O. Balance";

                madd = "Added Successfully";
                fadd = "Error... Failed Adding ";
                mupdate = "Update Successfully";
                fupdate = "Error.. Update Failed";
                mdelete = "Delete Successfully";
                fdelete = "Error...Delete Failed";
            }
            dgvdeacust.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Combo list
            string sql2 = "Select mid,mainname from tbl_mainacct";
            SqlConnection conn2 = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql2, conn2);



            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            da.Fill(ds, "mainacct");

            cmbmainacct.DisplayMember = "mainname";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbmainacct.ValueMember = "mid";
            cmbmainacct.DataSource = ds.Tables["mainacct"];

            // Restored the event handler
            //this.cmbcategory.SelectedIndexChanged += new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            conn2.Close();

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            

            

        }
        public void clear()
        {
            txtid.Text = "";
            
            txtacctname.Text = "";
            txtcreg.Text = "";
            txttleno.Text = "";
            txtcaddress.Text = "";
            txtsearch.Text = "";
            txtvat.Text = "";
            txtacctcode.Text = "";
            txtobalance.Text = "0.00";
            txtcreg.Text = "";
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            btnadd.Enabled = true;
        }

        private void dgvdeacust_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //string cmbtype = "";
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;

            int rowindex = e.RowIndex;
            txtid.Text = dgvdeacust.Rows[rowindex].Cells[0].Value.ToString();
            txtacctcode.Text = dgvdeacust.Rows[rowindex].Cells[1].Value.ToString();
            txtacctname.Text = dgvdeacust.Rows[rowindex].Cells[2].Value.ToString();
            cmbmainacct.Text = dgvdeacust.Rows[rowindex].Cells[3].Value.ToString();
            txtvat.Text = dgvdeacust.Rows[rowindex].Cells[4].Value.ToString();
            txttleno.Text = dgvdeacust.Rows[rowindex].Cells[5].Value.ToString();
            txtcemail.Text = dgvdeacust.Rows[rowindex].Cells[6].Value.ToString();
            txtcaddress.Text = dgvdeacust.Rows[rowindex].Cells[7].Value.ToString();
            txtcreg.Text = dgvdeacust.Rows[rowindex].Cells[8].Value.ToString();
            txtobalance.Text = dgvdeacust.Rows[rowindex].Cells[9].Value.ToString();
           
           
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            
            

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvdeacust.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.acctname = txtacctname.Text;
            c.acctcode = txtacctcode.Text;
            c.vatno = txtvat.Text;
            c.cemail = txtcreg.Text;
            c.telno = txttleno.Text;
            c.caddress = txtcaddress.Text;
            c.added_date = DateTime.Now;
            c.added_by = frmlogin.loggedin;
            c.mainacct = int.Parse(cmbmainacct.SelectedValue.ToString());
            c.cregno = txtcreg.Text;
            c.obalance = decimal.Parse(txtobalance.Text);




            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show(madd);
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fadd);

            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            /// Get values from form

            c.acctid = int.Parse(txtid.Text);
            c.acctname = txtacctname.Text;
            c.acctcode = txtacctcode.Text;
            c.vatno = txtvat.Text;
            c.cemail = txtcreg.Text;
            c.telno = txttleno.Text;
            c.caddress = txtcaddress.Text;
            c.mainacct = int.Parse(cmbmainacct.SelectedValue.ToString());
            c.cregno = txtcreg.Text;
            c.obalance = decimal.Parse(txtobalance.Text);



            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show(mupdate);
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fupdate);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            c.acctid = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show(mdelete);
                clear();
                DataTable dt = dal.Select();
                dgvdeacust.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fdelete);
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmbtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if(cmbtype.SelectedText.ToString()=="Customer")
            {
                cmbtype.Text = "1";
            }
            else if(cmbtype.SelectedText.ToString() == "Vendor")
            {
                cmbtype.Text = "2";
            }
            */
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbmainacct_SelectedIndexChanged(object sender, EventArgs e)
        {

            string newacct = "0";
            string mtype = cmbmainacct.SelectedValue.ToString();
            

            if (string.IsNullOrEmpty(mtype))
            {
                newacct = "0";
            }
            else
            {
                string mainacc = mtype;

                acctsBLL macct = dal.GetMaxId(mainacc);

                newacct = macct.acctcode;
                
            }
            txtacctcode.Text = newacct;
            txtacctname.Focus();
        }

        private void txtacctcode_Validated(object sender, EventArgs e)
        {

        }
    }
}

