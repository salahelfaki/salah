using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class productsBLL
    {
        public  int id { get; set; }
        public string barcode { get; set; }
        public string pname { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public int subcatid { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        public decimal total { get; set; }
        public decimal lastprice { get; set; }
        public decimal costprice { get; set; }
        public string pimage { get; set; }
        
        
    }
}
