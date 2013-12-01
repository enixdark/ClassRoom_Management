using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DBSET : DbSet { }
    public class DBSET<T> : DbSet<T> where T:class
    {
        //public DBSET(){
        //   if (classroommanagementContext.dataname.Equals("NOSQL")) {
               
        //   }     
        //}
        protected DBSET() : base() { }
        //public DbSet<T> getdata()
        //{
        //    if (classroommanagementContext.dataname.Equals("NOSQL"))
        //    {
        //        return null;
        //    }
        //    return this;
        //}
        //public override T Add(T entity)
        //{
        //    if (classroommanagementContext.dataname.Equals("SQL"))
        //    {
        //        return base.Add(entity);
        //    }
        //    if (classroommanagementContext.dataname.Equals("NOSQL"))
        //    {
        //        return base.Add(entity);
        //    }
        //    return null;
        //}

        
        
    }
}
