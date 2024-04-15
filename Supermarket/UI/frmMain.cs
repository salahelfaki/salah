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
    public partial class frmMain : Form
    {
        //Fields
        private Button currentButton;
        //private Button btnSender;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        public frmMain()
        {
            InitializeComponent();
            random = new Random();
        }

        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {

                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panellogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);


                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelmenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktoppanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;

        }

        private void btncategories_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmcategories(), sender);
        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmproducts(), sender);
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmsales(), sender);
        }

        private void btnpurchase_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmpurchase(), sender);
        }

        private void btndeacust_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmaccts(), sender);
        }

        private void btnusers_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUsers(), sender);
        }

        private void btnsettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmUsers(), sender);
        }
    }
}
