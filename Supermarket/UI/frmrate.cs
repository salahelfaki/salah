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
using System.IO;


namespace Supermarket.UI
{
    public partial class frmrate : Form
    {
        public frmrate()
        {
            InitializeComponent();
        }
        //string imglocation = "";
        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";

        private void frmcategories_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            //MessageBox.Show(t.CurrentCulture.Name);
            /*
            dt.Columns.Add("Picture", Type.GetType("System.Byte[]"));
            foreach(DataRow drow in dt.Rows)
            {
                drow["Picture"] = File.ReadAllBytes(drow["cimage"].ToString());
            }
            
            dt.Columns.Add("الرقم");
            dt.Columns.Add("الاسم");
            dt.Columns.Add("الاسم اللاتيني");
            */

            dgvcategories.DataSource = dt;
            dgvcategories.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvcategories.EnableHeadersVisualStyles = false;
            dgvcategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvcategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvcategories.Columns[0].HeaderText = "الرقم";
                dgvcategories.Columns[1].HeaderText = "التاريخ";
                dgvcategories.Columns[2].HeaderText = "المعدل";
                dgvcategories.Columns[3].HeaderText = "من";
                dgvcategories.Columns[4].HeaderText = "الى";
                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                mupdate = "تم التحديث...";
                fupdate = "خطأ...فشل التحديث";
                mdelete = "تم الحذف";
                fdelete = "خطأ...فشل الحذف";
            }
            else
            {
                dgvcategories.Columns[0].HeaderText = "ID";
                dgvcategories.Columns[1].HeaderText = "Date";
                dgvcategories.Columns[2].HeaderText = "Ex-Rate";
                dgvcategories.Columns[3].HeaderText = "From";
                dgvcategories.Columns[4].HeaderText = "To";
                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                mupdate = "Updated Successfully";
                fupdate = "Failed To Update";
                mdelete = " Deleted Successfuly";
                fdelete = "Failed To Delete...";
            }

            cmbfrom.SelectedValue = 1;
            cmbto.SelectedValue = 1;




        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        rateBLL c = new rateBLL();
        rateDAL dal = new rateDAL();
        usersDAL udal = new usersDAL();

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.exdate = dtpexdate.Value;
            c.exrate = decimal.Parse(txtexrate.Text);
            c.from_currency = cmbfrom.Text;
            c.to_currency = cmbto.Text;

            
            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show(madd);
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fadd);

            }


        }
        public void clear()
        {
            txtcategoryid.Text = "";
            txtexrate.Text = "";
            txtsearch.Text = "";
            // pictureBox.Image = null;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            btnadd.Enabled = true;
        }

        private void dgvcategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;

            int rowindex = e.RowIndex;
            
            
            txtcategoryid.Text = dgvcategories.Rows[rowindex].Cells[0].Value.ToString();
            dtpexdate.Text = dgvcategories.Rows[rowindex].Cells[1].Value.ToString();
            txtexrate.Text = dgvcategories.Rows[rowindex].Cells[2].Value.ToString();
            cmbfrom.Text= dgvcategories.Rows[rowindex].Cells[3].Value.ToString();
            cmbto.Text= dgvcategories.Rows[rowindex].Cells[4].Value.ToString();





        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            // Get values from form
            c.id = int.Parse(txtcategoryid.Text);
            c.exdate = dtpexdate.Value;
            c.exrate = decimal.Parse(txtexrate.Text);
            c.from_currency = cmbfrom.Text;
            c.to_currency = cmbto.Text;

            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show(mupdate);
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fupdate);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtcategoryid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show(mdelete);
                clear();
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fdelete);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvcategories.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvcategories.DataSource = dt;
            }
        }

        

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void cmbfrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
