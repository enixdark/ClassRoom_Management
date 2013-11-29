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
        private String url = "";
        public SQLServer(String DBName)
            : base(DBName)
        {
            url = "server=localhost;database="+DBName+";integrated security=true";
            CMConnection = new SqlConnection(url);
            CCommand = new SqlCommand();
            CDataAdapter = new SqlDataAdapter();

        }
    }
}
