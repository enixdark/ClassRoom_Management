using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace SingletonConnect
{
    class SQLServer:Connect
    {
        
        public SQLServer(String database)
            : base(database)
        {
            url = "server=localhost;database="+database+";integrated security=true";
            CMConnection = new SqlConnection(url);
            CCommand = new SqlCommand();
            CDataAdapter = new SqlDataAdapter();

        }
    }
}
