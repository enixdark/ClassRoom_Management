using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class ThoikhoabieuDAL:IDAL<thoikhoabieu>
    {
        public void Ex(thoikhoabieu obj)
        {
            var result = (from s in DataConnect.Context.data.thoikhoabieus select s).Where(s => s.mahp.Equals(obj.mahp));
            if (result.ToList<thoikhoabieu>().Count > 0)
                throw new InvalidOperationException("Loi trung khoa chinh");
            
        }
        public List<thoikhoabieu> getdata()
        {
            var result = from s in DataConnect.Context.data.thoikhoabieus select s;
                         //select new
                         //{
                         //    maca = s.maca,
                         //    magv = s.magv,
                         //    malop = s.malop,
                         //    manganh = s.manganh,
                         //    mahp = s.mahp,
                         //    siso = s.siso,
                         //    thoigian = s.tuanhocbatdau.ToString() + " -> " + s.tuanhocketthuc.ToString()
                         //};
            return result.ToList();
        }



        public int Insert(thoikhoabieu obj)
        {
            int result;
            
                //getdata().TestPrimarykey<thoikhoabieu>(obj);
                //getdata().TestFoireignKey<thoikhoabieu>(obj);
                //var l = DataConnect.Context.data.thoikhoabieus.Include("hocphan").Where(c => c.mahp == obj.mahp);

            if (!getdata().Test<thoikhoabieu>(obj))
                return 0;
            DataConnect.Context.data.thoikhoabieus.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(thoikhoabieu obj)
        {
            thoikhoabieu del = (from s in DataConnect.Context.data.thoikhoabieus
                                  where s.ID.Equals(obj.ID) 
                                  select s).First();
            DataConnect.Context.data.thoikhoabieus.Remove(del);
            return DataConnect.Context.SaveChanges();
        }

        public int Update(thoikhoabieu oldobj, thoikhoabieu newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.thoikhoabieus
                        where s.mahp.Equals(oldobj.mahp)
                        select s).ToList();
            list.ForEach(x =>
            {
                x.mahp = newobj.mahp;
                x.malop = newobj.malop;
                x.manganh = newobj.manganh;
                x.magv = newobj.magv;
                x.maca= newobj.maca;
                x.siso = newobj.siso;
                x.tuanhocbatdau = newobj.tuanhocbatdau;
                x.tuanhocketthuc = newobj.tuanhocketthuc;

            });
            result = DataConnect.Context.SaveChanges();
            return result;
        }
    }
}
