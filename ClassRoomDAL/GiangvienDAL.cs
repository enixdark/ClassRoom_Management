using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class GiangvienDAL:IDAL<Giangvien>
    {
        public List<Giangvien> getdata()
        {
            var result = from s in DataConnect.Context.data.Giangviens select s;
            return result.ToList();
        }

        public int Insert(Giangvien obj)
        {
            int result;
            DataConnect.Context.data.Giangviens.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(Giangvien obj)
        {
            int result;
            DataConnect.Context.data.Giangviens.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(Giangvien oldobj, Giangvien newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.Giangviens where s.magv.Equals(oldobj.magv) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
