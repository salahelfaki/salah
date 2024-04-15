using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class transactionBLL
    {
        public int id { get; set; }
        public string trtype { get; set; }
        public string customer { get; set; }
        public string acctcode { get; set; }
        public DateTime trdate { get; set; }
        public DateTime invdate { get; set; }
        public decimal subtotal { get; set; }
        public decimal vat { get; set; }
        public decimal discount { get; set; }
        public decimal grandtotal { get; set; }
        public string paymethod { get; set; }
        public string added_by { get; set; }
        public string description { get; set; }
        public string branch { get; set; }
        public decimal paid { get; set; }
        public decimal returned { get; set; }
        public decimal paycard { get; set; }
        public decimal paycredit { get; set; }
        public decimal paycash { get; set; }
        public int returnno { get; set; }
        public int sessionid { get; set; }
        public string ordertype { get; set; }
        public string tableno { get; set; }
        public int invno { get; set; }

        public DataTable transactionDetails { get; set; }

    }
}
