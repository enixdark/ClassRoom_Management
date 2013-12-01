using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class monhocDAL:IDAL<monhoc>
    {
        public List<monhoc> getdata()
        {
            var result = from s in DataConnect.Context.data.monhocs select s;
            return result.ToList();
        }

        public int Insert(monhoc obj)
        {
            int result;
            DataConnect.Context.data.monhocs.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(monhoc obj)
        {
            int result;
            DataConnect.Context.data.monhocs.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(monhoc oldobj, monhoc newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.monhocs where s.mamh.Equals(oldobj.mamh) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
