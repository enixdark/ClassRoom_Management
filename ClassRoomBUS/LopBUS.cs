using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class LopBUS:IBUS<Lop>
    {
        LopDAL DAL;
        public LopBUS()
        {
            DAL = new LopDAL();
        }

        public List<Lop> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(Lop obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(Lop obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(Lop oldobj, Lop newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
