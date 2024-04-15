using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    public class salesrep
    {
        public int id { get; set; }
        public DateTime trdate { get; set; }
        public string paymentmethod { get; set; }

        public decimal subtotal { get; set; }
        public decimal vat { get; set; }
        public decimal grandtotal { get; set; }
        public int added_by { get; set; }
        public decimal discount { get; set; }
        public decimal paid { get; set; }
        public decimal ret { get; set; }
        public string description { get; set; }
        public string customer { get; set; }
        public string trtype { get; set; }




    }
}
