using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;

namespace ClassRoomBUS
{
    public class LapphongBUS:BBUS<lapphong>
    {
        LapphongDAL DAL;
        public LapphongBUS()
        {
            DAL = new LapphongDAL();
        }

        public List<lapphong> getdata()
        {
            return DAL.getdata();
        }

        public bool Insert(lapphong obj)
        {
            return DAL.Insert(obj);
        }

        public bool Delete(lapphong obj)
        { 
            return DAL.Delete(obj); 
        }

        public bool Update(lapphong oldobj, lapphong newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
