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

namespace Supermarket.UI
{
    public partial class frmdexpense : Form
    {
        public frmdexpense()
        {
            InitializeComponent();
        }
        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";
        public string mitemnot = "";

        dexpenseBLL c = new dexpenseBLL();
        dexpenseDAL dal = new dexpenseDAL();
        usersDAL udal = new usersDAL();

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.edate = DateTime.Parse(dpicker.Text);
            c.description = txtdescription.Text;
            c.amount = decimal.Parse(txtamount.Text);



            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show(madd);
                clear();
                DataTable dt = dal.Select();
                dgvdexpense.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fadd);

            }


        }
        public void clear()
        {
            dpicker.Text = "";
            txtdescription.Text = "";
            txtamount.Text = "";
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;

        }

        private void dpicker_ValueChanged(object sender, EventArgs e)
        {
            string keywords = dpicker.Text;
            if (keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvdexpense.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvdexpense.DataSource = dt;
            }
        }

        private void frmdexpense_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvdexpense.DataSource = dt;

            System.Threading.Thread t = System.Threading.Thread.CurrentThread;

            dgvdexpense.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvdexpense.EnableHeadersVisualStyles = false;
            dgvdexpense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvdexpense.Columns[0].HeaderText = "الرقم";
                dgvdexpense.Columns[1].HeaderText = "تاريخ الشراء";
                dgvdexpense.Columns[2].HeaderText = "البيـان";
                dgvdexpense.Columns[3].HeaderText = "القيمة";
                dgvdexpense.Columns[4].HeaderText = "المخزن";

                madd = "تمت الاضافة بنجاح...";
                fadd = "خطأ..فشلت الإضافة";
                mupdate = "تم التحديث...";
                fupdate = "خطأ...فشل التحديث";
                mdelete = "تم الحذف";
                fdelete = "خطأ...فشل الحذف";
                mitemnot = "الصنف موجود!!!";
            }
            else
            {
                dgvdexpense.Columns[0].HeaderText = "ID";
                dgvdexpense.Columns[1].HeaderText = "Purchase Date";
                dgvdexpense.Columns[2].HeaderText = "Description";
                dgvdexpense.Columns[3].HeaderText = "Amount";
                dgvdexpense.Columns[4].HeaderText = "Store";

                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                mupdate = "Updated Successfully";
                fupdate = "Failed To Update";
                mdelete = " Deleted Successfuly";
                fdelete = "Failed To Delete...";
                mitemnot = "Item Exist!!!";

                dgvdexpense.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
                dgvdexpense.EnableHeadersVisualStyles = false;
                dgvdexpense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;




            }
            dgvdexpense.Columns[0].Width = 100;
            dgvdexpense.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvdexpense.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvdexpense.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvdexpense.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            c.description = txtdescription.Text;
            c.edate = DateTime.Parse(dpicker.Text);
            c.amount = decimal.Parse(txtamount.Text);




            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show(mupdate);
                clear();
                DataTable dt = dal.Select();
                dgvdexpense.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fupdate);
            }
        }

        private void dgvdexpense_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
            int rowindex = e.RowIndex;

            txtid.Text = dgvdexpense.Rows[rowindex].Cells[0].Value.ToString();
            dpicker.Text = dgvdexpense.Rows[rowindex].Cells[1].Value.ToString();
            txtdescription.Text = dgvdexpense.Rows[rowindex].Cells[2].Value.ToString();
            txtamount.Text = dgvdexpense.Rows[rowindex].Cells[3].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show(mdelete);
                clear();
                DataTable dt = dal.Select();
                dgvdexpense.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fdelete);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
