using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    public class NganhDAL:IDAL<Nganh>
    {
        
        public List<Nganh> getdata()
        {
            var result = from s in DataConnect.Context.data.Nganhs select s;
            return result.ToList();
        }

        public int Insert(Nganh obj)
        {
            int result;
            DataConnect.Context.data.Nganhs.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(Nganh obj)
        {
            int result;
            DataConnect.Context.data.Nganhs.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(Nganh oldobj, Nganh newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.Nganhs where s.manganh.Equals(oldobj.manganh) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
