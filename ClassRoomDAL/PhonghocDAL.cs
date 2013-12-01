using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public class PhonghocDAL:BDAL<phonghoc>
    {
        public List<phonghoc> getdata()
        {
            //DataConnect.Context.data.phonghocs.getdata();

            var result = from s in DataConnect.Context.data.getdata<phonghoc>() select s;
            //var result = from s in DataConnect.Context.data.phonghocs select s;
            //DataConnect.Context.data.phonghocs.getdata();
            return result.ToList();
        }

        public bool Insert(phonghoc obj)
        {
            
            if(!getdata().Test<phonghoc>(obj))
                return false;
            //DataConnect.Context.data.phonghocs.Add(obj);
            DataConnect.Context.data.Insert<phonghoc>(obj);

            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Delete(phonghoc obj)
        {
            phonghoc del = (from s in DataConnect.Context.data.getdata<phonghoc>() where s.maphong.Equals(obj.maphong) select s).First();
            DataConnect.Context.data.Delete<phonghoc>(del);
            DataConnect.Context.SaveChanges();
            return true;
        }

        public bool Update(phonghoc oldobj, phonghoc newobj)
        {

            if (!oldobj.maphong.Equals(newobj.maphong))
            {
                if (!getdata().Test<phonghoc>(newobj))
                    return false;
                DataConnect.Context.data.Database.ExecuteSqlCommand("UPDATE dbo.phonghoc set maphong = @mp ,tenphong = @tp,siso = @ss,dien_tich = @dt,images = @img where maphong = @omp",
                    new System.Data.SqlClient.SqlParameter("@mp", newobj.maphong), new System.Data.SqlClient.SqlParameter("@tp", newobj.tenphong),
                    new System.Data.SqlClient.SqlParameter("@ss", newobj.siso), new System.Data.SqlClient.SqlParameter("@dt", newobj.dien_tich),
                    new System.Data.SqlClient.SqlParameter("@img", newobj.images), new System.Data.SqlClient.SqlParameter("@omp", oldobj.maphong));

            }
            else
            {
                if (!DataException.TestNullExtract<phonghoc>(newobj))
                    return false;
                phonghoc list = (from s in DataConnect.Context.data.getdata<phonghoc>() where s.maphong.Equals(oldobj.maphong) select s).Single();
                //phonghoc x = new phonghoc();
                //x = DataConnect.Context.data.phonghocs.Single(z => z.maphong == oldobj.maphong);
                //DataConnect.Context.data.phonghocs.Attach(x);
                //DataConnect.Context.Entry(x).Property(a => a.maphong).IsModified = true;
                //DataConnect.Context.data.Database.ExecuteSqlCommandAsync(
                //list(x =>
                //{
                //    x.tenphong = newobj.tenphong;
                //    x.siso = newobj.siso;
                //    x.images = newobj.images;
                //    x.dien_tich = newobj.dien_tich;
                //});
                //}
                DataConnect.Context.data.Update<phonghoc>(list, newobj);
            }
            DataConnect.Context.SaveChanges();
            return true;
        }

        public List<string> getdataextract()
        {
            var result = from s in DataConnect.Context.data.phonghocs select s.maphong;
            return result.ToList();
        }
    }
}
