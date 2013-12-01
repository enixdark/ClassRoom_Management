
using System.Data.Entity;
namespace Model
{
    public partial class classroommanagementContext
    {
        public DBCONTEXT data { get; set; }
        public static string dataname { get; set; }
        public classroommanagementContext()
        {
        }
        public classroommanagementContext(string dataname)
        {
            classroommanagementContext.dataname = dataname;
            if (classroommanagementContext.dataname.Equals("SQL"))
            {
                data = new SQL();
            }
            if (classroommanagementContext.dataname.Equals("NOSQL"))
            {
                data = new MonGoDB();
            }
        }

        public virtual int SaveChanges()
        {
            if (classroommanagementContext.dataname.Equals("SQL"))
            {
                return ((SQL)data).SaveChanges();
            }
            if (classroommanagementContext.dataname.Equals("NOSQL"))
            {
                return ((NOSQL)data).SaveChanges();
            }
            return 1;

        }
    }
    //public partial class classroommanagementContext<T> where T :DBCONTEXT,new()
    //{
    //    private DBCONTEXT data { get; set; }
    //    public ModelDB table { get; set; }
    //    public classroommanagementContext(){
    //        data = new T();
            
    //    }

    //    public virtual int SaveChanges(){
    //        if (typeof(T).Name.Equals("SQL"))
    //        {
    //            return ((SQL)data).SaveChanges();
    //        }
    //        if (typeof(T).Name.Equals("NOSQL"))
    //        {
    //            return ((NOSQL)data).SaveChanges();
    //        }
    //        return 1;
            
    //    }
    //}
}
