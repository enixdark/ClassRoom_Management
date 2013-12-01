using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    public class LopDAL:IDAL<Lop>
    {
        public List<Lop> getdata()
        {
            var result = from s in DataConnect.Context.data.Lops select s;
            return result.ToList();
        }

        public int Insert(Lop obj)
        {
            int result;
            DataConnect.Context.data.Lops.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(Lop obj)
        {
            int result;
            DataConnect.Context.data.Lops.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(Lop oldobj, Lop newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.Lops where s.malop.Equals(oldobj.malop) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
