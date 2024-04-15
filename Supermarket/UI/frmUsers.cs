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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        usersBLL u = new usersBLL();
        usersDAL dal = new usersDAL();

        

        private void frmUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;

            dgvusers.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvusers.EnableHeadersVisualStyles = false;
            dgvusers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvusers.Columns[0].HeaderText = "الرقم";
            dgvusers.Columns[1].HeaderText = "الاسم";
            dgvusers.Columns[2].HeaderText = "اسم المستخدم";
            dgvusers.Columns[3].HeaderText = "كلمة المرور ";
            dgvusers.Columns[4].HeaderText = "الصلاحية";
            
        }
        private void clear()
        {
            txtuserid.Text = "";
            txtname.Text = "";
            
            txtusername.Text = "";
            txtpassword.Text = "";
            
            txtusertype.Text = "";

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtuserid.Text);
            bool sucess = dal.delete(u);
            if (sucess == true)
            {
                MessageBox.Show("تم حذف الحساب");
                clear();
            }
            else
            {
                MessageBox.Show("خطأ...لم يتم الحذف");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if(keywords != null)
            {
                DataTable dt = dal.Search(keywords);
                dgvusers.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvusers.DataSource = dt;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loggedinuser = frmlogin.loggedin;


            u.name = txtname.Text;

            u.username = txtusername.Text;
            u.password = txtpassword.Text;

            u.usertype = txtusertype.Text;



            usersBLL usr = dal.getidfromusername(loggedinuser);


            bool success = dal.insert(u);
            if (success == true)
            {
                MessageBox.Show("تم اضافة الحساب");
                clear();
            }
            else
            {
                MessageBox.Show("خطأ..لم تتم الاضافة");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtuserid.Text);
            u.name = txtname.Text;

            u.username = txtusername.Text;
            u.password = txtpassword.Text;

            u.usertype = txtusertype.Text;


            bool success = dal.update(u);
            if (success == true)
            {
                MessageBox.Show("تم تحديث البيانات");
                clear();
            }
            else
            {
                MessageBox.Show("خطأ...فشل تحديث البيانات");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            u.id = Convert.ToInt32(txtuserid.Text);
            bool sucess = dal.delete(u);
            if (sucess == true)
            {
                MessageBox.Show("تم حذف الحساب");
                clear();
            }
            else
            {
                MessageBox.Show("خطأ...لم يتم الحذف");
            }
            DataTable dt = dal.Select();
            dgvusers.DataSource = dt;
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void dgvusers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            txtuserid.Text = dgvusers.Rows[rowIndex].Cells[0].Value.ToString();
            txtname.Text = dgvusers.Rows[rowIndex].Cells[1].Value.ToString();

            txtusername.Text = dgvusers.Rows[rowIndex].Cells[2].Value.ToString();
            txtpassword.Text = dgvusers.Rows[rowIndex].Cells[3].Value.ToString();

            txtusertype.Text = dgvusers.Rows[rowIndex].Cells[4].Value.ToString();

        }
    }
}
