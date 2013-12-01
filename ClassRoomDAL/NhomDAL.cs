using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class NhomDAL:BDAL<Nhom>
    {
        public List<Nhom> getdata()
        {
            try
            {
                var result = from s in DataConnect.Context.data.Nhoms select s;
                return result.ToList();
            }
            catch (Exception ex)
            {
                
                
            }
            return null;
        }

        public bool Insert(Nhom obj)
        {
            if (!getdata().Test<Nhom>(obj))
                return false;
            DataConnect.Context.data.Nhoms.Add(obj);
            DataConnect.Context.SaveChanges();
            return true ;
        }

        public bool Delete(Nhom obj)
        {
            
            DataConnect.Context.data.Nhoms.Remove((from s in DataConnect.Context.data.Nhoms select s).Single(x => x.manhom.Equals(obj.manhom)));
            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Update(Nhom oldobj, Nhom newobj)
        {

            if (!DataException.TestNull(newobj))
                return false;
            var list = (from s in DataConnect.Context.data.Nhoms where s.manhom.Equals(oldobj.manhom) select s).ToList();
            list.ForEach(x => {
                x.tennhom = newobj.tennhom;
                x.thongtin = newobj.thongtin;
                x.image = newobj.image;
                x.phanloai = newobj.phanloai;

            });
            DataConnect.Context.SaveChanges();
            return true;
        }
    }
}
