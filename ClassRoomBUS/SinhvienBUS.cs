using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class SinhvienBUS:IBUS<SinhVien>
    {
        SinhvienDAL DAL;
        public SinhvienBUS()
        {
            DAL = new SinhvienDAL();
        }

        public List<SinhVien> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(SinhVien obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(SinhVien obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(SinhVien oldobj, SinhVien newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
