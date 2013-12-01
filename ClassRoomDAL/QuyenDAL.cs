using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    public class QuyenDAL:IDAL<quyen>
    {
        public List<quyen> getdata()
        {
            var result = from s in DataConnect.Context.data.quyens select s;
            return result.ToList();
        }

        public int Insert(quyen obj)
        {
            int result;
            DataConnect.Context.data.quyens.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(quyen obj)
        {
            int result;
            DataConnect.Context.data.quyens.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(quyen oldobj, quyen newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.quyens where s.maquyen.Equals(oldobj.maquyen) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
