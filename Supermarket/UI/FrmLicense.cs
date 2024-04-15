using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;
using System.Management;
using System.IO;
using Supermarket.Properties;
using System.Text.RegularExpressions;

namespace Supermarket.UI
{
    public partial class FrmLicense : Form
    {
        double result;
        double Tresult;
        DateTime TrialTime, CalTime;
        RegistryKey Df = Registry.CurrentUser.OpenSubKey("SOFTWARE\\LicenseProtection", true);
        public string pstatus;
        public static string lbldays;
        public FrmLicense()
        {
            InitializeComponent();
             // Settings.Default.Reset();



            TrialTime = DateTime.Now;
            CalTime = DateTime.Now.AddDays(10);
            if (!Settings.Default.IsChecked)
            {
                RegistryKey Df = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LicenseProtection");
                Df.Close();

                Df = Registry.CurrentUser.OpenSubKey("SOFTWARE\\LicenseProtection", true);
                Settings.Default.CalDate = CalTime;
                Df.SetValue("Count", ClsEncryption.Encrypt(Settings.Default.CalDate.ToString()));

                Settings.Default.Trial = TrialTime;
                Settings.Default.IsChecked = true;
                timer1.Enabled = true;
                
                Settings.Default.Save();

            }
            else
            {
                
                

                if (Settings.Default.Trial.Add(new TimeSpan(10, 0, 0, 0)) > DateTime.Now && DateTime.Now <= DateTime.Parse(ClsEncryption.Decrypt(Df.GetValue("Count").ToString())))
                {
                    DateTime totalTime = DateTime.Parse(ClsEncryption.Decrypt(Df.GetValue("Count").ToString()));
                    TimeSpan countDown = totalTime - DateTime.Now;
                    //MessageBox.Show("Current Option");
                    Settings.Default.IsTrial = true;
                    Settings.Default.Save();
                    lblDays.Text = countDown.Days.ToString();
                    lbldays = lblDays.Text;

                }
                else if (DateTime.Now >= DateTime.Parse(ClsEncryption.Decrypt(Df.GetValue("Count").ToString())))
                {
                    
                    lblDays.Visible = false;
                    //lbld.Visible = false;
                    //lblTrial.Visible = false;
                    timer1.Enabled = false;
                    btnTrial.Enabled = false;
                    lblPeriod.ForeColor = Color.Red;
                    lblPeriod.Text = "Your Trial Period Ended";
                }
                else
                {
                    // MessageBox.Show("Your Trial Period Ended");
                    lblDays.Visible = false;
                    lbld.Visible = false;
                    //lblTrial.Visible = false;
                    timer1.Enabled = false;
                    btnTrial.Enabled = false;
                    lblPeriod.ForeColor = Color.Red;
                    lblPeriod.Text = "Your Trial Period Ended";

                }
            }




        }
        void calculate()
        {
            if (txt1.Text != string.Empty && txt2.Text != string.Empty && txt3.Text != string.Empty && txt4.Text != string.Empty)
            {
                try
                {
                    double tx1 = Convert.ToDouble(txt1.Text);
                    double tx2 = Convert.ToDouble(txt2.Text);
                    double tx3 = Convert.ToDouble(txt3.Text);
                    double tx4 = Convert.ToDouble(txt4.Text);
                    result = (tx1 + tx2) - (tx3 + tx4);

                }
                catch
                {
                    return;
                }



            }
        }
        void Settingscalculate()
        {
            if (Settings.Default.M != string.Empty && Settings.Default.M1 != string.Empty && Settings.Default.M2 != string.Empty && Settings.Default.M3 != string.Empty)
            {
                try
                {
                    double tx1 = Convert.ToDouble(Settings.Default.M);
                    double tx2 = Convert.ToDouble(Settings.Default.M1);
                    double tx3 = Convert.ToDouble(Settings.Default.M2);
                    double tx4 = Convert.ToDouble(Settings.Default.M3);
                    Tresult = (tx1 + tx2) - (tx3 + tx4);

                }
                catch
                {
                    return;
                }



            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLicense_Load(object sender, EventArgs e)
        {
            if (DateTime.Now < Settings.Default.Trial)
            {
                MessageBox.Show("Wrong Date");
                Application.Exit();
            }

            getUniqueID("C");
            TextBox td = new TextBox();
            td.Text = getUniqueID("C");
            if (Settings.Default.IsLicensed == true)
            {


                Settingscalculate();
                if (Tresult == Convert.ToDouble(ClsEncryption.Decrypt(Settings.Default.KT.ToString())))
                {
                    if (td.Text != ClsEncryption.Decrypt(Settings.Default.GI))
                    {
                        
                        Application.Exit();
                    }
                    timer1.Enabled = true;
                    pstatus = "License Activated";
                    
                    frmlogin frm1 = new frmlogin();
                    //this.Hide();
                    this.WindowState = FormWindowState.Minimized;
                    this.ShowInTaskbar = false;

                    frm1.ShowDialog();
                    //MessageBox.Show("Licensed");
                    

                    //Close();
                }
                else
                {
                    
                    Application.Exit();
                }

            }



        }
    
    
        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty)
            {
                MessageBox.Show("Enter Serial Key");
                return;
            }
            calculate();
            try
            {
                if (result == Convert.ToDouble(ClsEncryption.Decrypt(Settings.Default.KT.ToString())))
                {
                    //*****************computer id
                    getUniqueID("C");
                    TextBox td = new TextBox();
                    td.Text = getUniqueID("C");
                    /*
                    if (td.Text != ClsEncryption.Decrypt(Settings.Default.GI))
                    {
                        Application.Exit();

                    }
                    else
                    {
                    */
                        Settings.Default.M = txt1.Text;
                        Settings.Default.M1 = txt2.Text;
                        Settings.Default.M2 = txt3.Text;
                        Settings.Default.M3 = txt4.Text;

                        MessageBox.Show("Successfuly Activated");
                        Settings.Default.IsLicensed = true;
                        Settings.Default.GI = ClsEncryption.Encrypt(td.Text);
                        Settings.Default.Save();
                        timer1.Enabled = false;
                        //open project main form
                        frmlogin frm = new frmlogin();
                        this.Hide();
                        frm.ShowDialog();
                        //this.Close();


                   // }
                    //************




                }
                else
                {
                    MessageBox.Show("Serial not Correct");
                }
            }
            catch //(Exception err)
            {
                //throw new Exception("Error: Serial is wrong:", err);
                return;

            }
        }
        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txt1_Validated(object sender, EventArgs e)
        {
            Regex r = new Regex("[0-9]{4}");
            System.Text.RegularExpressions.Match m = r.Match(txt1.Text);
            if (txt1.Text != string.Empty)
            {
                if (!m.Success)
                {
                    txt1.Focus();
                    return;
                }
            }
        }

        private void txt2_Validated(object sender, EventArgs e)
        {
            Regex r = new Regex("[0-9]{4}");
            System.Text.RegularExpressions.Match m = r.Match(txt2.Text);
            if (txt2.Text != string.Empty)
            {
                if (!m.Success)
                {
                    txt2.Focus();
                    return;
                }
            }

        }

        private void txt3_Validated(object sender, EventArgs e)
        {
            Regex r = new Regex("[0-9]{4}");
            System.Text.RegularExpressions.Match m = r.Match(txt3.Text);
            if (txt3.Text != string.Empty)
            {
                if (!m.Success)
                {
                    txt3.Focus();
                    return;
                }
            }

        }

        private void txt4_Validated(object sender, EventArgs e)
        {
            Regex r = new Regex("[0-9]{4}");
            System.Text.RegularExpressions.Match m = r.Match(txt4.Text);
            if (txt4.Text != string.Empty)
            {
                if (!m.Success)
                {
                    txt4.Focus();
                    return;
                }
            }

        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            if (Settings.Default.Trial.Add(new TimeSpan(10, 0, 0, 0)) > DateTime.Now)
            {
                Settings.Default.IsTrial = true;
                Settings.Default.Save();
                frmlogin fm = new frmlogin();
                this.Hide();
                fm.ShowDialog();
                //this.Close();
            }
            else
            {
                timer1.Enabled = false;
                Application.Exit();
            }

        }
        private string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }
            if (drive.EndsWith(":\\"))
            {
                drive = drive.Substring(0, drive.Length - 2);
            }
            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }
        private string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();
            return volumeSerial;
        }

        private string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();

            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime totalTime = DateTime.Parse(ClsEncryption.Decrypt(Df.GetValue("Count").ToString()));
            TimeSpan countDown = totalTime - DateTime.Now;
            

            if (countDown.TotalSeconds <= 0)
            {
                timer1.Enabled = false;
                lblDays.Visible = false;
                lbld.Visible = false;
                lblPeriod.Visible = false;
                btnTrial.Enabled = false;
                lblPeriod.ForeColor = Color.Red;
                lblPeriod.Text = "Your Trial Period Ended";

            }
            else
            {
                lblDays.Visible = true;
                lblDays.Text = countDown.Days.ToString();
                
            }
        }
    }
}
