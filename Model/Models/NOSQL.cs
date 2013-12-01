using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Mapping;

namespace Model
{
    public class NOSQL:DBCONTEXT
    {
         protected string host { get; set; }
         protected string port { get; set; }

         
         //public abstract vitual void SelectDB(string database);
         //public abstract virtual void Insert(object obj);
         
         public override int SaveChanges()
         {
             return 1;
         }
         
         
         
    }
}
