using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class GiangvienBUS:IBUS<Giangvien>
    {
        GiangvienDAL DAL;
        public GiangvienBUS()
        {
            DAL = new GiangvienDAL();
        }

        public List<Giangvien> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(Giangvien obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(Giangvien obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(Giangvien oldobj, Giangvien newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
