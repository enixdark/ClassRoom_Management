using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using ClassRoomDAL;
namespace ClassRoomBUS
{
    public class QuyenBUS:IBUS<quyen>
    {
        QuyenDAL DAL;
        public QuyenBUS()
        {
            DAL = new QuyenDAL();
        }

        public List<quyen> getdata()
        {
            return DAL.getdata();
        }

        public int Insert(quyen obj)
        {
            return DAL.Insert(obj);
        }

        public int Delete(quyen obj)
        { 
            return DAL.Delete(obj); 
        }

        public int Update(quyen oldobj,quyen newobj)
        {
            return DAL.Update(oldobj, newobj);
        }
    }
}
