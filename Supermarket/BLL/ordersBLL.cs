using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class ordersBLL
    {
        public int id { get; set; }
        public string type { get; set; }
        public DateTime trdate { get; set; }
        public decimal subtotal { get; set; }
        public decimal vat { get; set; }
        public decimal discount { get; set; }
        public decimal grandtotal { get; set; }
        public string paymethod { get; set; }
        public int added_by { get; set; }
        public DataTable orderDetails { get; set; }
    }
}
