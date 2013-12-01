using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;

namespace ClassRoomBUS
{
    public class ThoikhoabieuBUS:IBUS<thoikhoabieu>
    {
        ThoikhoabieuDAL DAL;
        public ThoikhoabieuBUS()
        {
            DAL = new ThoikhoabieuDAL();
        }

        public List<thoikhoabieu> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(thoikhoabieu obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(thoikhoabieu obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(thoikhoabieu oldobj, thoikhoabieu newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
