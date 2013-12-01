using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class TrangthaiDAL : BDAL<trangthaiphong>
    {
        public List<trangthaiphong> getdata()
        {


            var result = from s in DataConnect.Context.data.trangthaiphongs select s;



            return result.ToList();
        }

        public bool Insert(trangthaiphong obj)
        {
            if (!getdata().Test<trangthaiphong>(obj))
                return false;
            DataConnect.Context.data.trangthaiphongs.Add(obj);
            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Delete(trangthaiphong obj)
        {

            trangthaiphong del = (from s in DataConnect.Context.data.trangthaiphongs
                                  where s.maphong.Equals(obj.maphong) && (s.thoigianbatdau == obj.thoigianbatdau) && (s.thoigianketthuc == obj.thoigianketthuc)
                                  select s).First();
            DataConnect.Context.data.trangthaiphongs.Remove(del);
            DataConnect.Context.SaveChanges();
                return true;
        }

        public bool Update(trangthaiphong oldobj, trangthaiphong newobj)
        {
            if (!DataException.TestNullExtract<trangthaiphong>(newobj) || !getdata().TestPrimarykey<trangthaiphong>(newobj))
                return false;
            var list = (from s in DataConnect.Context.data.trangthaiphongs
                        where s.maphong.Equals(oldobj.maphong) && (s.thoigianbatdau == oldobj.thoigianbatdau) && (s.thoigianketthuc == oldobj.thoigianketthuc)
                        select s).ToList();
            list.ForEach(x => {
                x.maca = newobj.maca;
                x.maphong = newobj.maphong;
                x.thoigianbatdau = newobj.thoigianbatdau;
                x.thoigianketthuc = newobj.thoigianketthuc;
                x.hientrang = newobj.hientrang;
            });
            DataConnect.Context.SaveChanges();
            return true;
        }
    }
}
