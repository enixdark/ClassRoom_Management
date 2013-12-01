using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;

namespace ClassRoomBUS
{
    public class TrangthaiphongBUS:BBUS<trangthaiphong>
    {
        TrangthaiDAL DAL;
        public TrangthaiphongBUS()
        {
            DAL = new TrangthaiDAL();
        }

        public List<trangthaiphong> getdata()
        {
            return DAL.getdata();
        }

        public bool Insert(trangthaiphong obj)
        {
            return DAL.Insert(obj);
        }

        public bool Delete(trangthaiphong obj)
        { 
            return DAL.Delete(obj); 
        }

        public bool Update(trangthaiphong oldobj, trangthaiphong newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
