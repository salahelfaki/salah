using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Supermarket.UI
{
    public partial class language : Form
    {
        public language()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                    RightToLeftLayout = false;
                    break;
                case 1:
                    Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar");
                    RightToLeftLayout = true;
                    break;

            }
            this.Controls.Clear();
            InitializeComponent();
        }
    }
}
