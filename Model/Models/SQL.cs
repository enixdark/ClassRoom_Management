using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Model.Models.Mapping;
using MySql.Data.MySqlClient;
using MySql.Data.Entity;

namespace Model
{
    public class SQL:DBCONTEXT
    {
        static SQL()
        {
            Database.SetInitializer<SQL>(null);
            
        }
        
        public SQL()
            : base("Name=MSSQL")
        {
            
        }
        public SQL(string name)
            : base("Name="+name)
        {

        }
        
        

        
    }
}
