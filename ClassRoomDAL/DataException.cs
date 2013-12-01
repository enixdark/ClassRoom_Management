using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace ClassRoomDAL
{
    public enum EnumException
    {
        Pass,
        Primarikey,
        ForeignKey,
        Null,
    }

    public struct Log
    {
        public static EnumException en = EnumException.Pass;
        public static String message = "Đã Cập Nhật";
        public static Object Data = null;
        public static bool check = true;
        public static void CreateInstanceLog(EnumException en = EnumException.Pass, String message = "Đã Cập Nhật", Object Data = null, bool check = true)
        {
            Log.en = en;
            Log.Data = Data;
            Log.check = check;
            Log.message = message;
        }
    }

    public static class DataException
    {
        public static bool Test<T>(this List<T> list, T obj) where T : class
        {
            if(!TestPrimarykey<T>(list, obj)) return false;
            if (!TestFoireignKey<T>(obj)) return false;
            if (!TestNullExtract<T>(obj)) return false;
            Log.CreateInstanceLog();
            return true;
        }


        #region Test Duplicate Key
        public static bool TestPrimarykey<T>(this List<T> list, T obj) where T : class
        {
            Type i = typeof(T);
            int num = 0;
            object o = null;
            try
            {
                switch (i.Name)
                {
                    case "thoikhoabieu":
                        
                        num = ((from s in (list as List<thoikhoabieu>) select s).Where(s => s.mahp.Equals(( obj as thoikhoabieu).mahp)).ToList()).Count;
                        break;
                    case "phonghoc":
                        num = ((from s in (list as List<phonghoc>) select s).Where(s => s.maphong.Equals((obj as phonghoc).maphong)).ToList()).Count;
                        break;
                    case "trangthaiphong":
                        num = (((from s in (list as List<trangthaiphong>) select s).Where(s => s.maphong.Equals((obj as trangthaiphong).maphong)
                        && s.thoigianbatdau.Equals((obj as trangthaiphong).thoigianbatdau)
                        && s.thoigianketthuc.Equals((obj as trangthaiphong).thoigianketthuc))).ToList()).Count;
                        break;
                    case "Nhom":
                        num = ((from s in (list as List<Nhom>) select s).Where(s => s.manhom.Equals((obj as Nhom).manhom)).ToList()).Count;
                        break;
                    case "Account":
                        num = ((from s in (list as List<Account>) select s).Where(s => s.maid.Equals((obj as Account).manhom) && s.pass.Equals((obj as Account).pass)).ToList()).Count;
                        break;

                    default:
                        break;
                }
                if (num > 0){
                    string s = "đã có thông tin {0} trong bảng,vui lòng nhập dữ liệu lại";
                    Log.CreateInstanceLog(EnumException.Primarikey,s, obj, false);
                    throw new Exception(s);
            
                }
            }
            catch (InvalidOperationException Ex)
            {
                return false;
            }
            catch (Exception Ex)
            {
                return false;
            }
            return true;    

        }
        #endregion

        #region NULL
        public static bool TestNull<T>(T obj) where T : class
        {
            Type i = typeof(T);
            bool check = false;
            
            try
            {

                switch (i.Name)
                {
                    case "thoikhoabieu":
                        thoikhoabieu o = (obj as thoikhoabieu);
                        check = (o.maca == null || o.maca.Equals("") || o.magv == null || o.magv.Equals("")
                            || o.mahp == null || o.mahp.Equals("") || o.manganh == null || o.manganh.Equals("") || o.siso < 0
                            || o.Nganh == null || o.Nganh.Equals("") || o.tuanhocbatdau < 0
                            || o.tuanhocketthuc < o.tuanhocbatdau || o.mahp == null || o.mahp.Equals("")) ? true : false;
                        

                        break;

                    case "phonghoc":
                        phonghoc p = (obj as phonghoc);
                        check = (p.tenphong == null || p.tenphong.Equals("") || p.siso < 0 || p.maphong == null || p.maphong.Equals("") || p.dien_tich < 0) ? true : false;
                        break;
                    case "trangthaiphong":
                        trangthaiphong t = (obj as trangthaiphong);
                        check = (t.maphong == null || t.maphong.Equals("") || t.maca == null || t.maca.Equals("") || t.cahoc == null || t.cahoc.Equals("")) ? true : false;
                        
                        break;
                    case "Nhom":
                        Nhom n = (obj as Nhom);
                        check = (n.manhom == null || n.manhom.Equals("") || n.tennhom == null || n.tennhom.Equals("")) ? true : false;

                        break;
                    default:
                        break;
                }

                if (check)
                {
                    string s = "Thông Tin Cung Cấp chưa chính xác";
                    Log.CreateInstanceLog(EnumException.Null,s,obj, false);
                    throw new Exception(s);
                }

            }
            catch (NullReferenceException Ex)
            {
                return false;
            }
            catch (Exception Ex)
            {

                return false;
            }
            return true;
        }

        public static bool TestNullExtract<T>(T obj) where T : class
        {
            Type i = typeof(T);
            bool check = false;

            try
            {

                switch (i.Name)
                {
                    case "thoikhoabieu":
                        thoikhoabieu o = (obj as thoikhoabieu);
                        check = ( o.siso < 0 || o.manganh == null || o.manganh.Equals("") || o.tuanhocbatdau < 0 || o.tuanhocketthuc < o.tuanhocbatdau) ? true : false;
                        break;

                    case "phonghoc":
                        phonghoc p = (obj as phonghoc);
                        check = (p.siso < 0 || p.maphong == null || p.maphong.Equals("") || p.dien_tich < 0 || p.images==null) ? true : false;
                        break;
                    case "trangthaiphong":
                        trangthaiphong t = (obj as trangthaiphong);
                        check = (t.maphong == null || t.maphong.Equals("") || t.maca == null || t.maca.Equals("")  || t.hientrang == null || t.thoigianbatdau == null || t.thoigianketthuc == null) ? true : false;
                        break;
                    case "Nhom":
                        Nhom n = (obj as Nhom);
                        check = (n.manhom == null || n.manhom.Equals("") || n.tennhom == null || n.tennhom.Equals("")) ? true : false;
                        break;
                    default:
                        break;
                }

                if (check)
                {
                    string s = "Thông Tin Cung Cấp chưa chính xác";
                    Log.CreateInstanceLog(EnumException.Null, s, obj, false);
                    throw new Exception(s);
                }

            }
            catch (NullReferenceException Ex)
            {
                return false;
            }
            catch (Exception Ex)
            {

                return false;
            }
            return true;
        }
        #endregion

        #region Test Foreign when Connect 2 and N Table
        public static bool TestFoireignKey<T>(T obj) where T : class
        {
            Type i = typeof(T);
            string str = "";
            try
            {

                switch (i.Name)
                {
                    case "thoikhoabieu":
                        thoikhoabieu o = (obj as thoikhoabieu);

                        str += (from s in DataConnect.Context.data.hocphans select s).Where(s => s.mahp.Equals(o.mahp)).Count() > 0 ? "" : o.mahp + ",";
                        str += (from s in DataConnect.Context.data.Nganhs select s).Where(s => s.manganh.Equals(o.manganh)).Count() > 0 ? "" : o.manganh + ",";
                        str += (from s in DataConnect.Context.data.Giangviens select s).Where(s => s.magv.Equals(o.magv)).Count() > 0 ? "" : o.magv + ",";
                        str += (from s in DataConnect.Context.data.Lops select s).Where(s => s.malop.Equals(o.malop)).Count() > 0 ? "" : o.malop + ",";
                        str += (from s in DataConnect.Context.data.cahocs select s).Where(s => s.maca.Equals(o.maca)).Count() > 0 ? "" : o.maca;

                        break;

                    case "phonghoc":

                        break;
                    default:
                        break;
                }
                if (str.Length > 0)
                {
                        string s = "các thuộc tính " + str + " không có trong dữ liệu,vui lòng nhập lại các thuộc tính có trong dữ liệu";
                        Log.CreateInstanceLog(EnumException.Primarikey, s, obj, false);
                        throw new Exception("các thuộc tính " + str + " không có trong dữ liệu,vui lòng nhập lại các thuộc tính có trong dữ liệu");
                }
                
            }
            catch (InvalidOperationException Ex)
            {
                return false;
            }
            catch (Exception Ex)
            {

                return false;
            }
            return true;
        #endregion


        }
    }
}