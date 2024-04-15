using Microsoft.VisualBasic;
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
    public partial class e_invoice : Form
    {
        public e_invoice()
        {
            InitializeComponent();
        }

        private void e_invoice_Load(object sender, EventArgs e)

        {
            txt3.Text = DateTime.Now.ToString();
        }




        private string getTLV(int tag, string value)
        {
            return Strings.Chr(tag) + Strings.Chr(value.Length) + value;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            /*

            try
            {
                string value1 = getTLV(1, txt1.Text);
                string value2 = getTLV(2, txt2.Text);
                string value3 = getTLV(3, txt3.Text);
                string value4 = getTLV(4, txt4.Text);
                string value5 = getTLV(5, txt5.Text);
                byte[] b = System.Text.Encoding.UTF8.GetBytes(value1 + value2 + value3 + value4 + value5);
                string t = Convert.ToBase64String(b);
                txtcode.Text = t;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            */
            txtcode.Text = text2hex(1, txt1.Text.Length, txt1.Text);


        }
        public static String text2hex(Int32 Tagnum, Int32 TagLength, String TagVal)
        {



            string binary = Convert.ToString(TagLength, 2);
            string binary2 = Convert.ToString(Tagnum, 2);

            ushort ulen = Convert.ToUInt16(binary, 2);
            ushort unum = Convert.ToUInt16(binary2, 2);



            //string hexval = String.Concat(TagVal.Select(x => ((int)x).ToString("x")));

            string hextag = unum.ToString("X2");
            string hexlen = ulen.ToString("X2");

            //string valbinary = Convert.ToString(TagVal, 2);
            byte[] arr = System.Text.Encoding.UTF8.GetBytes(TagVal);
            // string hexval = Convert.ToInt32(arr,2).ToString("X2");
            string hexval = String.Concat(TagVal.Select(x => ((int)x).ToString("x")));



            // int i = 0;
            // for Arabic 
            /*
             while(i <= TagVal.Length)
                 {
                 foreach (char c in TagVal)
                 {
                     int value = (int)c;
                     string hex[i] = value.ToString("X2");

                 }
                 i = i++;
             }
            */



            return (hextag + hexlen + hexval);


        }
    }
}
