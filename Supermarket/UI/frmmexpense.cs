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
    public partial class frmmexpense : Form
    {
        public frmmexpense()
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

        mexpenseBLL c = new mexpenseBLL();
        mexpenseDAL dal = new mexpenseDAL();
        usersDAL udal = new usersDAL();

        private void frmmexpense_Load(object sender, EventArgs e)
        {
            txtmonth.Text = Convert.ToDateTime(dpicker.Text).Month.ToString();
            txtyear.Text = Convert.ToDateTime(dpicker.Text).Year.ToString();
            string mmonth = txtmonth.Text;
            string myear = txtyear.Text;
            DataTable dt = dal.Select(mmonth, myear);
            dgvmexpense.DataSource = dt;

            System.Threading.Thread t = System.Threading.Thread.CurrentThread;

            dgvmexpense.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvmexpense.EnableHeadersVisualStyles = false;
            dgvmexpense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;



            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvmexpense.Columns[0].HeaderText = "الرقم";
                dgvmexpense.Columns[1].HeaderText = "المرتبات ";
                dgvmexpense.Columns[2].HeaderText = "الكهرباء";
                dgvmexpense.Columns[3].HeaderText = "الايجار";
                dgvmexpense.Columns[4].HeaderText = "المياه";
                dgvmexpense.Columns[5].HeaderText = "أخرى";
                dgvmexpense.Columns[6].HeaderText = "الاجمالى";
                dgvmexpense.Columns[7].HeaderText = "الشهر";
                dgvmexpense.Columns[8].HeaderText = "السنة";


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
                dgvmexpense.Columns[0].HeaderText = "ID";
                dgvmexpense.Columns[1].HeaderText = "Salaries ";
                dgvmexpense.Columns[2].HeaderText = "Electricity";
                dgvmexpense.Columns[3].HeaderText = "Rent";
                dgvmexpense.Columns[4].HeaderText = "Water";
                dgvmexpense.Columns[5].HeaderText = "Others";
                dgvmexpense.Columns[6].HeaderText = "Total";
                dgvmexpense.Columns[7].HeaderText = "Month";
                dgvmexpense.Columns[8].HeaderText = "Year";

                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                mupdate = "Updated Successfully";
                fupdate = "Failed To Update";
                mdelete = " Deleted Successfuly";
                fdelete = "Failed To Delete...";
                mitemnot = "Item Exist!!!";

                dgvmexpense.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
                dgvmexpense.EnableHeadersVisualStyles = false;
                dgvmexpense.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;




            }
            for (int i = 0; i <= dgvmexpense.Columns.Count - 1; i++)
            {
                dgvmexpense.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void txtsalary_Validated(object sender, EventArgs e)
        {
            double osal = Convert.ToDouble(txtsalary.Text);
            double owater = Convert.ToDouble(txtwater.Text);

            double orent = Convert.ToDouble(txtrent.Text);
            double oother = Convert.ToDouble(txtothers.Text);
            double oelect = Convert.ToDouble(txtelectricity.Text);
            double newtot = osal + owater + orent + oother + oelect;
            txttotal.Text = newtot.ToString("0.00");
        }

        private void txtwater_Validated(object sender, EventArgs e)
        {
            double osal = Convert.ToDouble(txtsalary.Text);
            double owater = Convert.ToDouble(txtwater.Text);

            double orent = Convert.ToDouble(txtrent.Text);
            double oother = Convert.ToDouble(txtothers.Text);
            double oelect = Convert.ToDouble(txtelectricity.Text);
            double newtot = osal + owater + orent + oother + oelect;
            txttotal.Text = newtot.ToString("0.00");
        }

        private void txtelectricity_Validated(object sender, EventArgs e)
        {
            double osal = Convert.ToDouble(txtsalary.Text);
            double owater = Convert.ToDouble(txtwater.Text);

            double orent = Convert.ToDouble(txtrent.Text);
            double oother = Convert.ToDouble(txtothers.Text);
            double oelect = Convert.ToDouble(txtelectricity.Text);
            double newtot = osal + owater + orent + oother + oelect;
            txttotal.Text = newtot.ToString("0.00");
        }

        private void txtrent_Validated(object sender, EventArgs e)
        {
            double osal = Convert.ToDouble(txtsalary.Text);
            double owater = Convert.ToDouble(txtwater.Text);

            double orent = Convert.ToDouble(txtrent.Text);
            double oother = Convert.ToDouble(txtothers.Text);
            double oelect = Convert.ToDouble(txtelectricity.Text);
            double newtot = osal + owater + orent + oother + oelect;
            txttotal.Text = newtot.ToString("0.00");
        }

        private void txtothers_Validated(object sender, EventArgs e)
        {
            double osal = Convert.ToDouble(txtsalary.Text);
            double owater = Convert.ToDouble(txtwater.Text);

            double orent = Convert.ToDouble(txtrent.Text);
            double oother = Convert.ToDouble(txtothers.Text);
            double oelect = Convert.ToDouble(txtelectricity.Text);
            double newtot = osal + owater + orent + oother + oelect;
            txttotal.Text = newtot.ToString("0.00");
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.edate = DateTime.Parse(dpicker.Text);
            c.electricity = decimal.Parse(txtelectricity.Text);
            c.rent = decimal.Parse(txtrent.Text);
            c.water = decimal.Parse(txtwater.Text);
            c.others = decimal.Parse(txtothers.Text);
            c.total = decimal.Parse(txttotal.Text);
            c.salary = decimal.Parse(txtsalary.Text);
            c.month = txtmonth.Text;
            c.year = txtyear.Text;



            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show(madd);
                clear();
                DataTable dt = dal.Select(txtmonth.Text, txtyear.Text);
                dgvmexpense.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fadd);

            }
        }
        public void clear()
        {
            dpicker.Text = "";
            txtelectricity.Text = "0.00";
            txtrent.Text = "0.00";
            txtwater.Text = "0.00";
            txtsalary.Text = "0.00";
            txtothers.Text = "0.00";
            txttotal.Text = "0.00";
            txtmonth.Text = "";
            txtyear.Text = "";
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;


        }

        private void dpicker_ValueChanged(object sender, EventArgs e)
        {
            txtmonth.Text = Convert.ToDateTime(dpicker.Text).Month.ToString();
            txtyear.Text = Convert.ToDateTime(dpicker.Text).Year.ToString();
            string mmonth = txtmonth.Text;
            string myear = txtyear.Text;
            DataTable dt2 = dal.Select(mmonth, myear);
            dgvmexpense.DataSource = dt2;
            dgvmexpense.Refresh();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            c.edate = Convert.ToDateTime(dpicker.Text);
            c.electricity = decimal.Parse(txtelectricity.Text);
            c.rent = decimal.Parse(txtrent.Text);
            c.water = decimal.Parse(txtwater.Text);
            c.others = decimal.Parse(txtothers.Text);
            c.total = decimal.Parse(txttotal.Text);
            c.salary = decimal.Parse(txtsalary.Text);
            c.month = txtmonth.Text;
            c.year = txtyear.Text;





            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show(mupdate);
                clear();
                DataTable dt = dal.Select(txtmonth.Text, txtyear.Text);
                dgvmexpense.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fupdate);
            }
        }

        private void dgvmexpense_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;

            int rowindex = e.RowIndex;
            txtid.Text = dgvmexpense.Rows[rowindex].Cells[0].Value.ToString();
            txtsalary.Text = dgvmexpense.Rows[rowindex].Cells[1].Value.ToString();
            txtelectricity.Text = dgvmexpense.Rows[rowindex].Cells[2].Value.ToString();
            txtrent.Text = dgvmexpense.Rows[rowindex].Cells[3].Value.ToString();
            txtwater.Text = dgvmexpense.Rows[rowindex].Cells[4].Value.ToString();
            txtothers.Text = dgvmexpense.Rows[rowindex].Cells[5].Value.ToString();
            txttotal.Text = dgvmexpense.Rows[rowindex].Cells[6].Value.ToString();
            txtmonth.Text = dgvmexpense.Rows[rowindex].Cells[7].Value.ToString();
            txtyear.Text = dgvmexpense.Rows[rowindex].Cells[8].Value.ToString();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            c.id = int.Parse(txtid.Text);
            bool success = dal.delete(c);
            if (success == true)
            {
                MessageBox.Show(mdelete);
                clear();
                DataTable dt = dal.Select(txtmonth.Text, txtyear.Text);
                dgvmexpense.DataSource = dt;
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
