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
    public partial class frmprodlist : Form
    {
        public frmprodlist()
        {
            InitializeComponent();
        }
        productsBLL c = new productsBLL();
        productsDAL dal = new productsDAL();
        public int Rowid;
        public string ReturnValue1 { get; set; }
        //DataTable dtx = new DataTable();

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keywords = txtsearch.Text;
            if (txtsearch.Text.Length >0)
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

        private void frmprodlist_Load(object sender, EventArgs e)
        {
            DataTable dt = dal.SelectList();
            System.Threading.Thread t = System.Threading.Thread.CurrentThread;
            dgvproducts.DataSource = dt;
            dgvproducts.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
            dgvproducts.EnableHeadersVisualStyles = false;
            dgvproducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            if (t.CurrentCulture.Name == "ar-EG")
            {

                dgvproducts.Columns[0].HeaderText = "الباركود";
                dgvproducts.Columns[1].HeaderText = "الاسم";
                dgvproducts.Columns[2].HeaderText = "الكمية";
                dgvproducts.Columns[3].HeaderText = "السعر";


            }
            else
            {
                dgvproducts.Columns[0].HeaderText = "Barcode";
                dgvproducts.Columns[1].HeaderText = "Name";
                dgvproducts.Columns[2].HeaderText = "Qty";
                dgvproducts.Columns[3].HeaderText = "Price";



                dgvproducts.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#38619e");
                dgvproducts.EnableHeadersVisualStyles = false;
                dgvproducts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                // dgvproducts.RowHeadersWidth = 55;
                // dgvproducts.RowTemplate.MinimumHeight = 25;

                
                dgvproducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            DataTable dt= GetDataTable();
            
            this.ReturnValue1 = dt.Rows[0]["barcode"].ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void dgvproducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //DataTable dt = new DataTable();
            Rowid = e.RowIndex;
            int currentRow = dgvproducts.CurrentCell.RowIndex;
            // txtolddiscount.Text = this.dgvproducts.Rows[rowIndex].Cells[0].Value.ToString();
            

        }
        public DataTable GetDataTable()
        {
            DataTable dtLocalC = new DataTable();
            dtLocalC.Columns.Add("barcode");
            dtLocalC.Columns.Add("name");
            dtLocalC.Columns.Add("qty");
            dtLocalC.Columns.Add("rate");

            DataRow drLocal = null;
            foreach (DataGridViewRow dr in dgvproducts.Rows)
            {
                drLocal = dtLocalC.NewRow();
                drLocal["barcode"] = dgvproducts.Rows[Rowid].Cells[0].Value.ToString();
                drLocal["name"] = dgvproducts.Rows[Rowid].Cells[0].Value.ToString();
                drLocal["qty"] = dgvproducts.Rows[Rowid].Cells[0].Value.ToString();
                drLocal["rate"] = dgvproducts.Rows[Rowid].Cells[0].Value.ToString();
                dtLocalC.Rows.Add(drLocal);
            }

            return dtLocalC;
        }
    }
}
