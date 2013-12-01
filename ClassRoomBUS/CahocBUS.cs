using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassRoomDAL;
using Model.Models;
namespace ClassRoomBUS
{
    public class CahocBUS:IBUS<cahoc>
    {
        CahocDAL DAL;
        public CahocBUS()
        {
            DAL = new CahocDAL();
        }

        public List<cahoc> getdata()
        {
            return DAL.getdata();
        }

        public List<String> getdataExtract()
        {

            return DAL.getdataExtract();
        }

        public int Insert(cahoc obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(cahoc obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(cahoc oldobj, cahoc newobj)
        {
            return DAL.Update(oldobj, newobj);
        } 
    }
}
