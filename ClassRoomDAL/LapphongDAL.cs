using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class LapphongDAL:BDAL<lapphong>
    {
        public List<lapphong> getdata()
        {
            var result = from s in DataConnect.Context.data.lapphongs select s;
            return result.ToList();
        }

        public bool Insert(lapphong obj)
        {
            
            DataConnect.Context.data.lapphongs.Add(obj);
            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Delete(lapphong obj)
        {
            
            DataConnect.Context.data.lapphongs.Remove(obj);
            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Update(lapphong oldobj, lapphong newobj)
        {
            bool result;
            
            DataConnect.Context.SaveChanges();
            return true;
        }
    }
}
