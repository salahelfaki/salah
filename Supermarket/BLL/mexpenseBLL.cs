using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class mexpenseBLL
    {
        public int id { get; set; }
        public DateTime edate { get; set; }
        public decimal electricity { get; set; }
        public decimal rent { get; set; }
        public decimal water { get; set; }
        public decimal salary { get; set; }
        public decimal others { get; set; }
        public decimal total { get; set; }
        public string trtype { get; set; }
        public string month { get; set; }
        public string year { get; set; }
    }
}
