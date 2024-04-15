using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class rateBLL
    {
        public int id { get; set; }
        public DateTime exdate { get; set; }
        public decimal exrate { get; set; }
        public string from_currency { get; set; }
        public string to_currency { get; set; }


    }
}
