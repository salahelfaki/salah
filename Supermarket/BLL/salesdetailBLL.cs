using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
   public class salesdetailBLL
    {
        public int id { get; set; }
        public int name { get; set; }
        public decimal rate { get; set; }
        public decimal qty { get; set; }
        
        public decimal discper { get; set; }
        public decimal total
        {
            get
            {
                return rate * qty - qty * rate * discper;
            }
        }
               

    }
}
