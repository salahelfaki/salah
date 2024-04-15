using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class orderdetails
    {
        public int trid { get; set; }
        public int productid { get; set; }
        public string productname { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
    }
}
