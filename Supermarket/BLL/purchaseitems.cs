using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class purchaseitems
    {
        public int id { get; set; }
        public int trid { get; set; }
        public int itemid { get; set; }
        public string itemname { get; set; }
        public decimal itemqty { get; set; }
        public decimal itemprice { get; set; }
        public decimal itemtotal { get; set; }
        
    }
}
