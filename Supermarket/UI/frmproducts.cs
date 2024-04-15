
using Supermarket.BLL;
using Supermarket.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Supermarket.UI
{
    public partial class frmproducts : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmproducts()
        {
            InitializeComponent();
        }
        

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        productsBLL c = new productsBLL();
        productsDAL dal = new productsDAL();
        usersDAL udal = new usersDAL();
        public string madd = "";
        public string fadd = "";
        public string mupdate = "";
        public string fupdate = "";
        public string mdelete = "";
        public string fdelete = "";
        public string mitemnot = "";
        string imglocation = "";
        
        private void frmproducts_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.Select();
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            dgvproducts.DataSource = dt;
            dgvproducts.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvproducts.EnableHeadersVisualStyles = false;
            dgvproducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvproducts.Columns[0].Width = 20;
            dgvproducts.Columns[1].Width = 120;
            dgvproducts.Columns[2].Width = 200;
            dgvproducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (t.CurrentCulture.Name == "ar-EG")
            {
                dgvproducts.Columns[0].HeaderText = "الرقم";
                dgvproducts.Columns[1].HeaderText = "الباركود";
                dgvproducts.Columns[2].HeaderText = "الاسم";
                //dgvproducts.Columns[3].HeaderText = "الاسم اللاتيني";
                dgvproducts.Columns[3].HeaderText = "الوحدة";
                dgvproducts.Columns[4].HeaderText = "الكمية";
                dgvproducts.Columns[5].HeaderText = "السعر";
                dgvproducts.Columns[6].HeaderText = "التكلفة";
                dgvproducts.Columns[7].HeaderText = "المجموعة";
                dgvproducts.Columns[8].HeaderText = "الصورة";

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
                dgvproducts.Columns[0].HeaderText = "ID";
                dgvproducts.Columns[1].HeaderText = "Barcode";
                dgvproducts.Columns[2].HeaderText = "Name";
                //dgvproducts.Columns[3].HeaderText = "Alias ";
                dgvproducts.Columns[3].HeaderText = "Unit";
                dgvproducts.Columns[4].HeaderText = "Qty";
                dgvproducts.Columns[5].HeaderText = "Price";
                dgvproducts.Columns[6].HeaderText = "Cost";
                dgvproducts.Columns[7].HeaderText = "Main Group";
                dgvproducts.Columns[8].HeaderText = "Photo";

                madd = "Added successfuly";
                fadd = "Failed To Add Category";
                mupdate = "Updated Successfully";
                fupdate = "Failed To Update";
                mdelete = " Deleted Successfuly";
                fdelete = "Failed To Delete...";
                mitemnot = "Item Exist!!!";

                
            }
            cmbunit.SelectedIndex = 0;

            txtbarcode.Focus();


            string sql = "Select * from tbl_categories";
            SqlConnection conn = new SqlConnection(myconnstrng);

            SqlCommand cmd = new SqlCommand(sql,conn);
            
            
            // Create the data adapter to use to get the data and handle connecting to the DB
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            // Get the data from the database. I am using the Northwind database the customers table
            da.Fill(ds, "categories");
            // Disconnect the event handler to handle the comboBox1_SelectedIndexChanged event
            // while the combo box is being populated, otherwise it will fire a couple of times
            // before you are ready to handle them.
            //this.cmbcategory.SelectedIndexChanged -= new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            // Connect the cobo box to the data source from where the data is comming from
            // In this case the Customers data table in the dataset.
            cmbcategory.DataSource = ds.Tables["categories"];
            // Tell the combo box what collumn to display to the user
            cmbcategory.DisplayMember = "title";
            // Tell the combo box what collumn to use with the displayed value, value is not displayed
            cmbcategory.ValueMember = "id";
            string mcat = cmbcategory.Text;
            
            // Restored the event handler
            //this.cmbcategory.SelectedIndexChanged += new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            conn.Close();
           /*
            string sql2 = "Select * from tbl_subcat where categid='"+mcat+"'";
            conn.Open();
           SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "subcategories");
            cmbsubcat.DataSource = ds2.Tables["subcategories"];
            cmbsubcat.DisplayMember = "name";
            cmbsubcat.ValueMember = "name";
           */

        }
        private void cmbcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When the user clicks on a item in the combo box ist primary key will be displayed.
            MessageBox.Show("Category Primary Key is \"" + cmbcategory.SelectedValue + "\"");
        }


    

        private void btnadd_Click(object sender, EventArgs e)
        {
            c.barcode = txtbarcode.Text;
            c.pname = txtname.Text;
            c.description = txtdescription.Text;
            c.unit = cmbunit.Text;
            c.category =cmbcategory.SelectedValue.ToString();
            c.subcatid = 0; // cmbsubcat.Text;
            c.rate = decimal.Parse(txtrate.Text);
            c.qty = decimal.Parse(txtqty.Text);
            c.lastprice = decimal.Parse(txtlastprice.Text);
            c.costprice = decimal.Parse(txtcostprice.Text);

            string myimage = txtpimage.Text;
            byte[] images = null;
            if (string.IsNullOrEmpty(myimage))
            {
                c.pimage = txtpimage.Text;
            }
            else
            {
                string myfilename=Path.GetFileName(myimage);
                FileStream Mystreem = new FileStream(myimage, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(Mystreem);
                
                images = brs.ReadBytes((int)Mystreem.Length);
                //c.pimage = imglocation;

                 File.Copy(myimage, Path.Combine(@"C:\images\", Path.GetFileName(txtpimage.Text)), true);
                string filenewpath= Path.Combine(@"C:\images\",myfilename);
                
                c.pimage = filenewpath;
                Mystreem.Dispose();
            }


            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool Success = dal.insert(c);
            if (Success == true)
            {
                MessageBox.Show(madd);
                clear();
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fadd);

            }


        }
        public void clear()
        {
            txtid.Text = "";
            txtbarcode.Text = "";
            txtname.Text = "";
            txtdescription.Text = "";
            cmbunit.SelectedIndex =0;
            cmbcategory.SelectedIndex = 0;
            //cmbsubcat.Text = "";
            txtrate.Text = "0.00";
            txtqty.Text = "0.00";
            txtsearch.Text = "";
            txtlastprice.Text = "0.00";
            txtcostprice.Text = "0.00";
            btnadd.Enabled = true;
            btnupdate.Enabled = false;
            btndelete.Enabled = false;
            txtpimage.Text = "";
            pictureBox.Image = null;
            txtbarcode.Focus();

        }

        private void dgvproducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;

            int rowindex = e.RowIndex;
            txtid.Text = dgvproducts.Rows[rowindex].Cells[0].Value.ToString();
            txtbarcode.Text = dgvproducts.Rows[rowindex].Cells[1].Value.ToString();
            txtname.Text = dgvproducts.Rows[rowindex].Cells[2].Value.ToString();
            cmbunit.Text = dgvproducts.Rows[rowindex].Cells[3].Value.ToString();
            txtqty.Text = dgvproducts.Rows[rowindex].Cells[4].Value.ToString();
            txtrate.Text = dgvproducts.Rows[rowindex].Cells[5].Value.ToString();
            txtcostprice.Text = dgvproducts.Rows[rowindex].Cells[6].Value.ToString();
            cmbcategory.Text = dgvproducts.Rows[rowindex].Cells[7].Value.ToString();
           // cmbsubcat.Text = dgvproducts.Rows[rowindex].Cells[8].Value.ToString();
            
            txtpimage.Text= dgvproducts.Rows[rowindex].Cells[8].Value.ToString();

            if (string.IsNullOrEmpty(txtpimage.Text))
            {

            }
            else { 
                 MemoryStream ms = new MemoryStream(File.ReadAllBytes(dgvproducts.Rows[rowindex].Cells[8].Value.ToString()));

                 pictureBox.Image = Image.FromStream(ms);
                 pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
             


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(txtlastprice.Text=="")
            {
                txtlastprice.Text = "0.00";
            }
            if (txtqty.Text == "")
            {
                txtqty.Text = "0.00";
            }
            if (txtrate.Text == "")
            {
                txtrate.Text = "0.00";
            }
            // Get values from form
            c.id = int.Parse(txtid.Text);
            c.barcode = txtbarcode.Text;
            c.pname = txtname.Text;
            c.category = cmbcategory.SelectedValue.ToString();
            c.subcatid = 0; // cmbsubcat.Text;
            c.description = txtdescription.Text;
            c.unit = cmbunit.Text;
            c.rate = decimal.Parse(txtrate.Text);
            c.qty = decimal.Parse(txtqty.Text);
            c.lastprice = decimal.Parse(txtlastprice.Text);
            c.costprice = decimal.Parse(txtcostprice.Text);
            //  c.pimage = txtpimage.Text;
            /*
             byte[] images = null;

             FileStream streem = new FileStream(txtpimage.Text, FileMode.Open, FileAccess.Read);
             BinaryReader brs = new BinaryReader(streem);
             images = brs.ReadBytes((int)streem.Length);
             c.pimage = imglocation;
            */
            string loggeduser = frmlogin.loggedin;
            usersBLL usr = udal.getidfromusername(loggeduser);
            //c.added_by = usr.id;

            bool success = dal.update(c);
            if (success == true)
            {
                MessageBox.Show(mupdate);
                clear();
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fupdate);
            }

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
                dgvproducts.DataSource = dt;
            }
            else
            {
                MessageBox.Show(fdelete);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;

            if (txtsearch.Text.Length > 0)
            {
                (dgvproducts.DataSource as DataTable).DefaultView.RowFilter = string.Format("pname LIKE '{0}%'", txtsearch.Text);
                //DataTable dt = dal.SearchList(txtsearch.Text);
                //dgvproducts.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.SelectList();
                dgvproducts.DataSource = dt;
            }
            
            
        }
/*
        private void btnbrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox.ImageLocation = imglocation;
            }
        }
*/
        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();
            txtlastprice.Text = "0.00";
        }

        private void txtdescription_KeyDown(object sender, KeyEventArgs e)
        {
            txtdescription.Text = txtname.Text;
        }

        private void cmbcategory_SelectedValueChanged(object sender, EventArgs e)
        {
            string mcat = cmbcategory.Text;
            SqlConnection conn = new SqlConnection(myconnstrng);

            // Restored the event handler
            //this.cmbcategory.SelectedIndexChanged += new System.EventHandler(this.cmbcategory_SelectedIndexChanged);
            /*
            string sql2 = "Select * from tbl_subcat where categid='" + mcat + "'";
            conn.Open();
            SqlCommand cmd2 = new SqlCommand(sql2, conn);
            SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            da2.Fill(ds2, "subcategories");
            if (ds2.Tables[0].Rows.Count == 0)
            {
                cmbsubcat.Text = "";
            }
            else
            {
                cmbsubcat.DataSource = ds2.Tables["subcategories"];
                cmbsubcat.DisplayMember = "name";
                cmbsubcat.ValueMember = "name";
            }
            */
        }
        /*
        private async void txtbarcode_TextChanged(object sender, EventArgs e)
        {
                        lblvalid.Text = "";
            await Task.Delay(1000);
            string keywords = txtbarcode.Text;
            if (keywords != null)
            {
                DataTable dt = dal.BarcodeValidate(keywords);

               
                //string mytest = dt.Rows[0]["barcode"].ToString();
                //MessageBox.Show(mytest);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Barcode Exists!");
                    return;

                   // lblvalid.Text = mitemnot;
                    
                    
                    
                }
                
            }
            
        }
         */   

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtbarcode_Validated(object sender, EventArgs e)
        {

            string keywords = txtbarcode.Text;
            if (string.IsNullOrEmpty(keywords))
            {
                //***
            }
            else
            {
                DataTable dt = dal.BarcodeValidate(keywords);


                //string mytest = dt.Rows[0]["barcode"].ToString();
                //MessageBox.Show(mytest);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(mitemnot);
                    txtbarcode.Clear();
                    txtbarcode.Focus();
                    return;

                    // lblvalid.Text = mitemnot;



                }
            
            }
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png| All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imglocation = dialog.FileName.ToString();
                //txtpimage.Text= dialog.FileName.ToString();
                //pictureBox.ImageLocation = imglocation;


                txtpimage.Text = imglocation;
                //Path.GetFileName(dialog.FileName.ToString());


                System.Drawing.Image imgOriginal = System.Drawing.Image.FromFile(imglocation, true);
                using (System.Drawing.Image img = System.Drawing.Image.FromFile(imglocation, true))
                {
                    using (Graphics gra = Graphics.FromImage(imgOriginal))
                    {
                        using (Bitmap b = new Bitmap(img))
                        {
                            int nWidth = b.Size.Width;
                            int nHeight = b.Size.Height;
                            int nLeft = (imgOriginal.Width / 2) - (nWidth / 2);
                            int nTop = (imgOriginal.Height / 2) - (nHeight / 2);
                            gra.DrawImage(b, nLeft, nTop, nWidth, nHeight);
                            //System.Drawing.Image i = resizeImage(b, new Size(50, 50));

                        }
                    }
                }
                pictureBox.Image = imgOriginal;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsearchname_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearchname.Text;
            if (keywords != null)
            {
                (dgvproducts.DataSource as DataTable).DefaultView.RowFilter = string.Format("pname LIKE '{0}%'", txtsearchname.Text);
               // DataTable dt = dal.SearchName(keywords);
                
               // dgvproducts.DataSource = dt;
            }
            else
            {
                DataTable dt = dal.Select();
                dgvproducts.DataSource = dt;
            }
        }
    }
    
}
