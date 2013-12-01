using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using ClassRoomDAL;
namespace ClassRoomBUS
{
    public class PhonghocBUS:BBUS<phonghoc>
    {
        PhonghocDAL DAL;
        public PhonghocBUS()
        {
            DAL = new PhonghocDAL();
        }

        public List<phonghoc> getdata()
        {
            return DAL.getdata();
        }

        public bool Insert(phonghoc obj)
        {
            return DAL.Insert(obj);
        }

        public bool Delete(phonghoc obj)
        { 
            return DAL.Delete(obj); 
        }

        public bool Update(phonghoc oldobj, phonghoc newobj)
        {
            return DAL.Update(oldobj, newobj);
        }

        public List<String> getdataextract()
        {
            return DAL.getdataextract();
        }
    }
}
