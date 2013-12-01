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
        
        public MySQL(String database)
            : base(database)
        {
            url = "server=localhost;database="+database+";uid=root;pwd=''";
            try
            {
                CMConnection = new MySqlConnection(url);
                CCommand = new MySqlCommand();
                CDataAdapter = new MySqlDataAdapter();
            }
            catch (Exception e)
            {
                Console.Write("");
            }

        }
    }
}
