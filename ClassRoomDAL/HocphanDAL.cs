using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class HocphanDAL:IDAL<hocphan>
    {
        public List<hocphan> getdata()
        {
            var result = from s in DataConnect.Context.data.hocphans select s;
            return result.ToList();
        }

        public int Insert(hocphan obj)
        {
            int result;
            DataConnect.Context.data.hocphans.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(hocphan obj)
        {
            int result;
            DataConnect.Context.data.hocphans.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(hocphan oldobj, hocphan newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.hocphans where s.mahp.Equals(oldobj.mahp) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
