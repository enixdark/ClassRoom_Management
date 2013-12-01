using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomBUS
{
    public interface IBUS<T> where T:class
    {
        List<T> getdata();
        int Insert(T obj);
        int Update(T oldobj, T newobj);
        int Delete(T obj);
    }
}
