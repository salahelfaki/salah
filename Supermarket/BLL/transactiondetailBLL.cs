using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class transactiondetailBLL
    {
        public int trid { get; set; }
        public int productid { get; set; }
        public string barcode { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
        public decimal balance { get; set; }
        public string productname { get; set; }
        public decimal lastprice { get; set; }
        public decimal vat15 { get; set; }
        public decimal costprice { get; set; }
        public decimal oldqty { get; set; }
        public string trtype { get; set; }
        public DateTime trdate { get; set; }
    }
}
