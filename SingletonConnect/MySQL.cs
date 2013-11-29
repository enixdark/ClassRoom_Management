using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace SingletonConnect
{
    class MySQL:Connect
    {
        private String url = "";
        public MySQL(String DBName)
            : base(DBName)
        {
            url = "server=localhost;database="+DBName+";uid=root;pwd=''";
            CMConnection = new MySqlConnection(url);
            CCommand = new MySqlCommand();
            CDataAdapter = new MySqlDataAdapter();

        }
    }
}
