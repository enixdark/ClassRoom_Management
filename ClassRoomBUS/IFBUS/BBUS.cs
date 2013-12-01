using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRoomBUS
{
    public interface BBUS<T> where T:class
    {
        List<T> getdata();
        bool Insert(T obj);
        bool Update(T oldobj, T newobj);
        bool Delete(T obj);
    }
}
