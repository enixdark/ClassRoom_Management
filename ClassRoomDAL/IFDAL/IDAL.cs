namespace ClassRoomDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model.Models;

    public interface IDAL<T> where T:class
    {
        List<T> getdata();
        int Insert(T obj);
        int Update(T oldobj, T newobj);
        int Delete(T obj);
    }
}
