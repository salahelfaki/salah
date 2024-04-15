using Microsoft.VisualBasic.FileIO;
using Supermarket.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Supermarket.DAL;
using System.Configuration;

namespace Supermarket.UI
{
    public partial class frmimport : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public frmimport()
        {
            InitializeComponent();
        }
        productsBLL p = new productsBLL();



        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection mycon = new SqlConnection(myconnstrng);
            mycon.Open();

            for (int i = 0; i < dgItems.Rows.Count - 1; i++)
            {


                
                    
                    

                    string msql = "insert into tbl_products(barcode,name,description,unit,rate,category) VALUES(@barcode,@name,@description,@unit,@rate,@category)";
                    SqlCommand cmd1 = new SqlCommand(msql, mycon);

                cmd1.Parameters.AddWithValue("@barcode", dgItems.Rows[i].Cells[0].Value);
                cmd1.Parameters.AddWithValue("@name", dgItems.Rows[i].Cells[1].Value);
                cmd1.Parameters.AddWithValue("@description", dgItems.Rows[i].Cells[2].Value);
                cmd1.Parameters.AddWithValue("@unit", dgItems.Rows[i].Cells[3].Value);
                cmd1.Parameters.AddWithValue("@rate", dgItems.Rows[i].Cells[4].Value);
                cmd1.Parameters.AddWithValue("@category", dgItems.Rows[i].Cells[5].Value);
                




                cmd1.ExecuteNonQuery();
                
            }
            MessageBox.Show("Imported Successfully");
            mycon.Close();
                    /*
                    try
                    {
                        DataTable dtItem = (DataTable)(dgItems.DataSource);
                        string barcode, name, rate; //, UnitPrice;
                        string InsertItemQry = "";
                        int count = 0;
                        foreach (DataRow dr in dtItem.Rows)
                        {
                            barcode = Convert.ToString(dr["barcode"]);
                            name = Convert.ToString(dr["name"]);
                            rate = Convert.ToString(dr["rate"]);

                           // UnitPrice = Convert.ToString(dr["Price"]);

                           // if (barcode != "" && name != "" && rate != "" && UnitPrice != "")
                            //{
                                InsertItemQry = "Insert into tbl_product(barcode,name,rate)Values('" + barcode + "','" + name + "','" + rate +"' ); ";
                            // + dr["CateId"] + "','" + dr["Cost"] + "','"  + dr["Quantity"] + ",'" + dr["UOM"] + "','" + dr["Weight"] + "','" + dr["TaxID"] + "','" + dr["IsDiscountItem"] + "',GETDATE()); ";
                            count++;
                            //}

                        }
                        //if (InsertItemQry.Length > 0)
                        //{
                            bool isSuccess = DBAccess.ExecuteQuery(InsertItemQry);
                            if (isSuccess)
                            {
                                MessageBox.Show("Item Imported Successfully, Total Imported Records : " + count + "", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgItems.DataSource = null;
                            }
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Exception " + ex);
                    }
                    */


        }


        private void frmimport_Load(object sender, EventArgs e)
        {
            
        }
        

        private void btnChoose_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.ShowDialog();
                int ImportedRecord = 0, inValidItem = 0;
                string SourceURl = "";
                if (dialog.FileName != "")
                {
                    if (dialog.FileName.EndsWith(".csv"))
                    {
                        DataTable dtNew = new DataTable();
                        dtNew = GetDataTabletFromCSVFile(dialog.FileName);
                        if (Convert.ToString(dtNew.Columns[0]).ToLower() != "barcode")
                        {
                            MessageBox.Show("Invalid Items File");
                            btnSave.Enabled = false;
                            return;
                        }
                        txtFile.Text = dialog.SafeFileName;
                        SourceURl = dialog.FileName;
                        if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                        {
                            dgItems.DataSource = dtNew;
                        }
                        foreach (DataGridViewRow row in dgItems.Rows)
                        {
                            if (Convert.ToString(row.Cells["barcode"].Value) == "" || row.Cells["barcode"].Value == null || Convert.ToString(row.Cells["name"].Value) == "" || row.Cells["name"].Value == null || Convert.ToString(row.Cells["rate"].Value) == "" || row.Cells["rate"].Value == null)
                            {
                                row.DefaultCellStyle.BackColor = Color.Red;
                                inValidItem += 1;
                            }
                            else
                            {
                                ImportedRecord += 1;
                            }
                        }
                        if (dgItems.Rows.Count == 0)
                        {
                            btnSave.Enabled = false;
                            MessageBox.Show("There is no data in this file", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Selected File is Invalid, Please Select valid csv file.", "GAUTAM POS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception " + ex);
            }

        }
        public static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                if (csv_file_path.EndsWith(".csv"))
                {
                    using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                    {
                        csvReader.SetDelimiters(new string[] {
                    ",",";"
                });
                        csvReader.HasFieldsEnclosedInQuotes = true;
                        //read column  
                        string[] colFields = csvReader.ReadFields();
                        foreach (string column in colFields)
                        {
                            DataColumn datecolumn = new DataColumn(column);
                            datecolumn.AllowDBNull = true;
                            csvData.Columns.Add(datecolumn);
                        }
                        while (!csvReader.EndOfData)
                        {
                            string[] fieldData = csvReader.ReadFields();
                            for (int i = 0; i < fieldData.Length; i++)
                            {
                                if (fieldData[i] == "")
                                {
                                    fieldData[i] = null;
                                }
                            }
                            csvData.Rows.Add(fieldData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exce " + ex);
            }
            return csvData;
        }
    }
    
    
}
