using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class NganhBUS:IBUS<Nganh>
    {
        NganhDAL DAL;
        public NganhBUS()
        {
            DAL = new NganhDAL();
        }

        public List<Nganh> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(Nganh obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(Nganh obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(Nganh oldobj, Nganh newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
