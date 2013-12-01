using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class NhomBUS:BBUS<Nhom>
    {
        NhomDAL DAL;
        public NhomBUS()
        {
            DAL = new NhomDAL();
        }

        public List<Nhom> getdata()
        {
            return DAL.getdata();
        }

        public bool Insert(Nhom obj)
        {
            return DAL.Insert(obj);
        }

        public bool Delete(Nhom obj)
        { 
            return DAL.Delete(obj); 
        }

        public bool Update(Nhom oldobj, Nhom newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
