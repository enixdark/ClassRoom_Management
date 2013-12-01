using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace ClassRoomDAL
{
    public class SinhvienDAL:IDAL<SinhVien>
    {
        //ClassRoomContext Context;
        //public SinhvienDAL()
        //{
        //    Context = new ClassRoomContext();

        //}
        public List<SinhVien> getdata(){
            
            
            var result = from s in DataConnect.Context.data.SinhViens select s;
            
            
                
            return result.ToList();
        }

        public int Insert(SinhVien obj)
        {
            int result;
            DataConnect.Context.data.SinhViens.Add(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Delete(SinhVien obj)
        {
            int result;
            DataConnect.Context.data.SinhViens.Remove(obj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }

        public int Update(SinhVien oldobj,SinhVien newobj)
        {
            int result;
            var list = (from s in DataConnect.Context.data.SinhViens where s.masv.Equals(oldobj.masv) select s).ToList();
            list.ForEach(x => x = newobj);
            result = DataConnect.Context.SaveChanges();
            return result;
        }




        
    }


}
