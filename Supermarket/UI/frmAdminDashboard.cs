using Supermarket.BLL;
using Supermarket.DAL;
using Supermarket.Properties;
using Supermarket.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
    


namespace Supermarket
{
    public partial class frmAdminDashboard : Form
    {
        companyBLL c = new companyBLL();
        companyDAL dal = new companyDAL();
        string remdays = "";
        string mver = "";
        public frmAdminDashboard()
        {
            DataTable dt = dal.Select();
            string lang = dt.Rows[0]["lang"].ToString();
            switch(lang)
            {
                case "Arabic":
                    //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-SA");
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("ar-EG");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("ar-EG");
                    break;
                case "English":
                    //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo("en-US");
                    break;
            }

            InitializeComponent();
           
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers user = new frmUsers();
            user.Show();

        }

        private void frmAdminDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            frmlogin login = new frmlogin();
            login.Show();
            this.Hide();
        }

        private void frmAdminDashboard_Load(object sender, EventArgs e)
        {
            System.Globalization.CultureInfo cultureinfo =  new System.Globalization.CultureInfo("nl-NL");
            //DateTime dt = DateTime.Parse(DateTime.Now, cultureinfo);
            label4.Text = DateTimeFormatInfo.CurrentInfo.GetDayName(DateTime.Now.DayOfWeek);
               
            label5.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label6.Text = DateTime.Now.ToShortTimeString();

            this.Location = new Point(0, 0);

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            loguser.Text = frmlogin.loggedin;
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            if (t.CurrentCulture.Name == "ar-EG")
            {
                remdays = "    الايام المتبقية للنسخة التجريبية:  ";
                mver = "برنامج ادارة السيوبرماركت نسخة 1";
            }
            else
            {
                remdays = "Trial Remaining Days:";

            }

            if (Settings.Default.IsLicensed == true)
            {
                lbltrial.Text = "License Activated";
            }
            else
            {
                lbltrial.Text = remdays + FrmLicense.lbldays;


                timer1.Start();
            }

            if (frmlogin.userrole == "User")
            {
                btnacct.Enabled = false;
                btnpurchase.Enabled = false;
                btnrep.Enabled = false;
                btnreturn.Enabled = false;
                btnsettings.Enabled = false;
                btntools.Enabled = false;
                btnusers.Enabled = false;

                btnusers.BackColor = Color.Gray;
                btnacct.BackColor = Color.Gray;
                btnpurchase.BackColor = Color.Gray;
                btnrep.BackColor = Color.Gray;
                btnreturn.BackColor = Color.Gray;
                btnsettings.BackColor = Color.Gray;
                btntools.BackColor = Color.Gray;

                purchaseToolStripMenuItem.Enabled = false;
                reportsToolStripMenuItem.Enabled = false;
                accountingToolStripMenuItem.Enabled = false;
                usersToolStripMenuItem.Enabled = false;

                toolStripMenuItem2.Enabled = false;
                الحساباتToolStripMenuItem.Enabled = false;
                الأدواتToolStripMenuItem.Enabled = false;
            }
            string myimage = @"C:\images";
            if (Directory.Exists(myimage))
            {
                return;
            }
            else
            {
                Directory.CreateDirectory(myimage);
            }

        }
        public static void ClearSpace(Control control)
        {
            foreach (Control c in control.Controls)
            {
                var textBox = c as TextBox;
                var comboBox = c as ComboBox;

                if (textBox != null)
                    (textBox).Clear();

                if (comboBox != null)
                    comboBox.SelectedIndex = -1;

                if (c.HasChildren)
                    ClearSpace(c);
            }
        }


        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmproducts products = new frmproducts();
            products.Show();
        }

        private void dealersCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccts deacust = new frmaccts();
            deacust.Show();
        }

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void transactionsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmdailysales dsales = new frmdailysales();
            dsales.Show();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsales sales = new frmsales();
            sales.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printorders porder = new printorders();
            porder.Show();
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmitems items = new frmitems();
                items.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmpurchaseStock frm = new frmpurchaseStock();
            frm.Show();
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmreturn issue = new frmreturn();
            issue.Show();
        }

        private void btncat_Click(object sender, EventArgs e)
        {
            frmcategories cat = new frmcategories();
            cat.Show();
        }

        private void btnprod_Click(object sender, EventArgs e)
        {
            frmproducts prod = new frmproducts();
            prod.Show();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            frmsales sales = new frmsales();
            sales.Show();
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            frmpurchase purchase = new frmpurchase();
            purchase.Show();
        }

        private void vATReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmvatrep vatrep = new frmvatrep();
            vatrep.Show();

        }

        private void salesByItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmitemsalerep itemsalerep = new frmitemsalerep();
            itemsalerep.Show();
        }

        private void purchaseReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpurchaserep purchaserep = new frmpurchaserep();
            purchaserep.Show();
        }

        private void mainCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcategories mcateg = new frmcategories();
            mcateg.Show();
        }

        private void subCategoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsubcat subcateg = new frmsubcat();
            subcateg.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmproducts prod = new frmproducts();
            prod.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmcategories newMDIChild = new frmcategories();
           // newMDIChild.MdiParent = this;

             newMDIChild.Show();
            //Point childLocation = new Point(this.Location.X + 100, this.Location.Y + 120);
            //frmcategories formReserve = new frmcategories();
            //formReserve.Location = childLocation;
            //formReserve.MdiParent = this;
            //formReserve.Show();
            //frmcategories categ = new frmcategories();
            //categ.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmsubcat subcat = new frmsubcat();
            subcat.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //frmsales frm = new frmsales();
            frminvoice frm = new frminvoice();
            frm.Show();
            
            //frmsalesmenu sales = new frmsalesmenu(); ;
           //sales.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmpurchaseStock frm = new frmpurchaseStock();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmreturn freturn = new frmreturn();
            freturn.Show();
            //return
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmaccts deacust = new frmaccts();
            deacust.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmUsers users = new frmUsers();
            users.Show();
        }

        private void btnrep_Click(object sender, EventArgs e)
        {
            frmrep rep = new frmrep();
            rep.Show();
        }

        private void btnsetting_Click(object sender, EventArgs e)
        {
            frmsettings sett = new frmsettings();
            sett.Show();
        }

        private void الاعداداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmsettings sett = new frmsettings();
            sett.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmimport import = new frmimport();
            import.Show();
        }

        private void customersSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccts deacust = new frmaccts();
            deacust.Show();
        }

        private void btnAcct_Click(object sender, EventArgs e)
        {
            frmaccounting frm = new frmaccounting();
            frm.Show();
        }

        private void الدفعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btncategories_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btncategories.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnproducts_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnproducts.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }
        
        private void btnsales_Paint(object sender, PaintEventArgs e)
        {
            
           ControlPaint.DrawBorder(e.Graphics, btnsales.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnpurchase_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnpurchase.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnreturn_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnreturn.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btncustomer_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btncustomer.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnacct_Click_1(object sender, EventArgs e)
        {
            frmaccounting frm = new frmaccounting();
            frm.Show();
        }

        private void btnacct_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnacct.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnrep_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnrep.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnusers_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnusers.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnsetting_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnsettings.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btntools_Click(object sender, EventArgs e)
        {
            frmtools frm1 = new frmtools();
            frm1.Show();
        }

        private void btntools_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btntools.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }

        private void btnexit_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btnexit.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
        }


        // buttons
        /*
        private bool blnButtonDown = false;

        private void button_Paint(object sender, PaintEventArgs e)
        {
            if (blnButtonDown == false)
            {
                ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Button).ClientRectangle,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Button).ClientRectangle,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset,
                    System.Drawing.SystemColors.ControlLightLight, 2, ButtonBorderStyle.Inset);
            }
        }

        private void button_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            blnButtonDown = true;
            (sender as System.Windows.Forms.Button).Invalidate();
        }

        private void button_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            blnButtonDown = false;
            (sender as System.Windows.Forms.Button).Invalidate();

        }
        */
        //finish buttons

        private void استيرادToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmimport frm = new frmimport();
            frm.Show();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void الأدواتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            frmsettings frm = new frmsettings();
            frm.Show();
        }

        private void btnrep_Paint_1(object sender, PaintEventArgs e)
        {/*
            int borderRadius = 50;
            float borderThickness = 1.75f;
            base.OnPaint(e);
            RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
            GraphicsPath GraphPath = GetRoundPath(Rect, borderRadius);

            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.Silver, borderThickness))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, GraphPath);
            }
        
            */
            ControlPaint.DrawBorder(e.Graphics, btnrep.ClientRectangle,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset,
           SystemColors.ControlLightLight, 5, ButtonBorderStyle.Inset);
            
        }
        GraphicsPath GetRoundPath(RectangleF Rect, int radius)
        {
            float r2 = radius / 2f;
            GraphicsPath GraphPath = new GraphicsPath();
            GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
            GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
            GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
            GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
            GraphPath.AddArc(Rect.X + Rect.Width - radius,
                             Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
            GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
            GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
            GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
            GraphPath.CloseFigure();
            return GraphPath;
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpayment frm = new frmpayment();
            frm.Show();

        }

        private void creditNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcreditnote frm = new frmcreditnote();
            frm.Show();
        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmpurchase frm = new frmpurchase();
            frm.Show();
        }

        private void btnrep_Click_1(object sender, EventArgs e)
        {
            frmrep frm = new frmrep();
            frm.Show();
        }

        private void تقريرالجردوالمخزونToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStockrep frm = new frmStockrep();
            frm.Show();
        }

        private void حركةحسابToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmaccttrep frm = new frmaccttrep();
            frm.Show();
        }

        private void أرصدةالحساباتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmacctbalrep frm = new frmacctbalrep();
            frm.Show();
        }

        private void clearDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcleardata frm = new frmcleardata();
            frm.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.Default.BackupDir == "")
            {
                frmbackup frm = new frmbackup();
                frm.Show();
            }
            else
            {
                using (var source = new SqlConnection("Data Source = Supermarket.db; version = 3"))
                using (var destination = new SqlConnection("Data Source=" + Settings.Default.BackupDir + "/" + DateTime.Now.ToString("yyyyMMdd") + "backup.db"))
                {
                    source.Open();
                    destination.Open();
                   // source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }
                MessageBox.Show("Backup Successfull...");
            }
        }

        private void restoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrestore frm = new frmrestore();
            frm.Show();
        }

        private void مسحالبياناتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmcleardata frm = new frmcleardata();
            frm.Show();
        }

        private void نسخاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbackup frm = new frmbackup();
            frm.Show();
        }

        private void استعادةالنسخالاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmrestore frm = new frmrestore();
            frm.Show();
        }

        private void categmenu_Click(object sender, EventArgs e)
        {
            frmcategories frm = new frmcategories();
            frm.Show();
        }

        private void prodmenu_Click(object sender, EventArgs e)
        {
            frmproducts frm = new frmproducts();
            frm.Show();
        }

        private void deacustmenu_Click(object sender, EventArgs e)
        {
            frmaccts frm = new frmaccts();
            frm.Show();
        }

        private void exratemenu_Click(object sender, EventArgs e)
        {
            frmrate frm = new frmrate();
            frm.Show();
        }

        private void settingsmenu_Click(object sender, EventArgs e)
        {
            frmsettings frm = new frmsettings();
            frm.Show();
        }
    }
}
