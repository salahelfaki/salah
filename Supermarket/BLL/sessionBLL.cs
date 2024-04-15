using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class sessionBLL
    {
        public int id { get; set; }
        public string sessionname { get; set; }
        public string sessionuser { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public int status { get; set; }
    }
}
