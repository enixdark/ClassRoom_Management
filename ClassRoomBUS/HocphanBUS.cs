using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using ClassRoomDAL;
namespace ClassRoomBUS
{
    public class HocphanBUS:IBUS<hocphan>
    {
        HocphanDAL DAL;
        public HocphanBUS()
        {
            DAL = new HocphanDAL();
        }

        public List<hocphan> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(hocphan obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(hocphan obj)
        { 
            return DAL.Delete(obj); 
        }


        public int Update(hocphan oldobj, hocphan newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
