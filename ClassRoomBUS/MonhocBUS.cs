using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class monhocBUS:IBUS<monhoc>
    {
        monhocDAL DAL;
        public monhocBUS()
        {
            DAL = new monhocDAL();
        }

        public List<monhoc> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(monhoc obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(monhoc obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(monhoc oldobj, monhoc newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
