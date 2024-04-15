using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmsettings : Form
    {
        public frmsettings()
        {
            InitializeComponent();
        }
        companyBLL c = new companyBLL();
        companyDAL dal = new companyDAL();
        string imglocation = "";
        public int mcheck = 0;
        public int isvat = 0;
        int iscreen = 0;

        private void frmsettings_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            txtcompany.Text=dt.Rows[0]["cname"].ToString();
            txtaname.Text = dt.Rows[0]["aname"].ToString();
            txtregno.Text = dt.Rows[0]["regno"].ToString();
            txtaddress.Text= dt.Rows[0]["caddress"].ToString();
             txtvatno.Text = dt.Rows[0]["cvatno"].ToString(); 
            txtlogo.Text = dt.Rows[0]["clogo"].ToString(); ;
             txtbranch.Text = dt.Rows[0]["branch"].ToString(); 
            txtvatval.Text= dt.Rows[0]["vatval"].ToString();
            txtstore.Text = dt.Rows[0]["store"].ToString(); 
            c.lang = cmbcategory.Text = dt.Rows[0]["lang"].ToString();
            string isvat = dt.Rows[0]["vatincluded"].ToString();
            string iscreen = dt.Rows[0]["custdisplay"].ToString();
            if (isvat.ToString()=="1")
            {
                txtvatok.Checked = true;
            }
            if (iscreen.ToString() == "1")
            {
                chkscreen.Checked = true;
            }
            if (txtlogo.Text != "")
            {

                MemoryStream ms = new MemoryStream(File.ReadAllBytes(txtlogo.Text));


                pictbox.Image = Image.FromStream(ms);
            }
        }
        private void lblname_Click(object sender, EventArgs e)
        {

        }

        private void txtaddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            if (txtlogo.Text != "")
            {

                FileStream streem = new FileStream(txtlogo.Text, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(streem);
                images = brs.ReadBytes((int)streem.Length);

                c.clogo = imglocation;
            }

            // Get values from form
            //c.id = int.Parse(txtid.Text);
            c.cname = txtcompany.Text;
            c.aname = txtaname.Text;
            c.regno = txtregno.Text;
            c.caddress = txtaddress.Text;
            c.cvatno = txtvatno.Text;
            c.clogo = txtlogo.Text;
            c.branch = txtbranch.Text;
            c.vatval = decimal.Parse(txtvatval.Text);
            c.store =txtstore.Text;
            c.lang = cmbcategory.Text;
            c.vatincluded = isvat;
            c.custdisplay = iscreen;
            //  c.pimage = txtpimage.Text;
            /*
             byte[] images = null;

             FileStream streem = new FileStream(txtpimage.Text, FileMode.Open, FileAccess.Read);
             BinaryReader brs = new BinaryReader(streem);
             images = brs.ReadBytes((int)streem.Length);
             c.pimage = imglocation;
            */
            string loggeduser = frmlogin.loggedin;
           // usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show("تم تحديث البيانات");
               // clear();
              //  DataTable dt = dal.Select();
                //dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show("خطأ..لم يتم التحديث");
            }

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtlogo.Text = dialog.FileName.ToString();
                pictbox.ImageLocation = txtlogo.Text;
            }
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtvatok_CheckedChanged(object sender, EventArgs e)
        {
            if (txtvatok.Checked)
            {
                isvat = 1;
            }
            else
            {
                isvat = 0;
            }
        }

        private void chkscreen_CheckedChanged(object sender, EventArgs e)
        {
            if (chkscreen.Checked)
            {
                iscreen = 1;
            }
            else
            {
                iscreen = 0;
            }
        }
    }
}
