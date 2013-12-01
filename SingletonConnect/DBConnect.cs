using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;

namespace SingletonConnect
{
    public class DBConnect
    {
        public static DBConnect DB = null;
        public static Connect Conn;
        
        String DBName ;
        String database;
        String Url ="";
        String pass;
        String user;
        private DBConnect(String DBName,String database,String user,String pass)
        {
            this.DBName = DBName;
            this.database = database;
            this.pass = pass;
            this.user = user;
            if (DBName.Equals("SQLServer"))
            {
                
                Conn = new SQLServer(database);
            }
            else if (DBName.Equals("MySQL"))
            {
                Conn = new MySQL(database);
            }
            //else if (DBName.Equals("MongoDB"))
            //{
            //    Conn = new MongoDB(database);
            //}
            else if (DBName.Equals("Access"))
            {
                Conn = new Access(Url,database);
            }
            //else if (DBName.Equals("Oracle"))
            //{
            //    Conn = new Oracle(database);
            //}
        }

        public static DBConnect InstanceofDBConnect(String DBName, String database, String user, String pass)
        {
            if (DB == null)
            {
                DB = new DBConnect(DBName, database, user, pass);
                
            }
            return DB;
        }

    }
}
