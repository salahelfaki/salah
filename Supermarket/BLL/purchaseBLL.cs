using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class purchaseBLL
    {
        public int id { get; set; }
        public DateTime trdate { get; set; }
        public string dealer { get; set; }
        public string invno { get; set; }
        public DateTime invdate { get; set; }
        public decimal subtotal { get; set; }
        public decimal vat { get; set; }
        public decimal grandtotal { get; set; }
        public string added_by { get; set; }
        public decimal discount { get; set; }
        public string trtype { get; set; }
        public string description { get; set; }
        public string paymethod { get; set; }
        public int returnno { get; set; }


    }
}
