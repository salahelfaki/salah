using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    class SqlHelper
    {
        SqlConnection connstrng;
        public SqlHelper(string connectionString)
        {
            connstrng = new SqlConnection(connectionString);
        }
        public bool IsConnection
        {
            get
            {
                if (connstrng.State == System.Data.ConnectionState.Closed)
                    connstrng.Open();
                return true;
            }
        }
    }
}
