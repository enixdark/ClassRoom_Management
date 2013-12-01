using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    public class CahocDAL:IDAL<cahoc>
    {
        public List<cahoc> getdata()
        {
            var result = from s in DataConnect.Context.data.cahocs select s;
            return result.ToList();
        }


        public List<String> getdataExtract()
        {
            var result = from s in DataConnect.Context.data.cahocs select s.maca;
            return result.ToList();
        }

        public int Insert(cahoc obj)
        {
            int result;
            DataConnect.Context.data.cahocs.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(cahoc obj)
        {
            int result;
            DataConnect.Context.data.cahocs.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(cahoc oldobj, cahoc newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.cahocs where s.maca.Equals(oldobj.maca) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
