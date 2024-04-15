using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class dexpenseBLL
    {
        public int id { get; set; }
        public DateTime edate { get; set; }
        public string description { get; set; }


        public decimal amount { get; set; }
        public string trtype { get; set; }
    }
}
