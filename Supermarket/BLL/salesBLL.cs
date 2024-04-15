using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class salesBLL
    {
        public int id { get; set; }
        public DateTime trdate { get; set; }
        public string paymentmethod { get; set; }
        
        public decimal subtotal { get; set; }
        public decimal vat { get; set; }
        public decimal grandtotal { get; set; }
        public int added_by { get; set; }
        public int returnno { get; set; }
    }
}
