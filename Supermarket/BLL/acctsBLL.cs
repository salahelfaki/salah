using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.BLL
{
    class acctsBLL
    {
        public int acctid { get; set; }
        public string acctcode { get; set; }
        public string acctname { get; set; }
        public int mainacct { get; set; }
        public decimal crval { get; set; }
        public decimal dbval { get; set; }
        public decimal balance { get; set; }
        public decimal obalance { get; set; }

        public string cemail { get; set; }
        public string telno { get; set; }
        public string caddress { get; set; }
        public string vatno { get; set; }
        public DateTime added_date { get; set; }
        public string added_by { get; set; }
        public string cregno { get; set; }
    }
}
