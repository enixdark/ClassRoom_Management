using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Model.Models.Mapping;

namespace Model
{
    public class DBCONTEXT:DbContext,ModelDB
    {
        public DBCONTEXT() { }
        public DBCONTEXT(string name) : base(name) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<cahoc> cahocs { get; set; }
        public DbSet<Giangvien> Giangviens { get; set; }
        public DbSet<hocphan> hocphans { get; set; }
        public DbSet<lapphong> lapphongs { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<monhoc> monhocs { get; set; }
        public DbSet<Nganh> Nganhs { get; set; }
        public DbSet<Nhom> Nhoms { get; set; }
        public DbSet<phonghoc> phonghocs { get; set; }
        public DbSet<quyen> quyens { get; set; }
        public DbSet<quyentruycap> quyentruycaps { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<tuanhoc> tuanhocs { get; set; }
        public DbSet<thoikhoabieu> thoikhoabieus { get; set; }
        public DbSet<trangthaiphong> trangthaiphongs { get; set; }

        public virtual DbSet<T> getdb<T>() where T:BaseObject
        {
            return this.Set<T>();
        }
        public virtual IEnumerable<T> getdata<T>() where T : BaseObject,new()
        {
            return this.Set<T>().AsEnumerable<T>();
        }

        public virtual int Insert<T>(T obj) where T : BaseObject,new()
        {
             this.Set<T>().Add(obj);
             return 1;
        }
        public virtual int Delete<T>(T obj) where T : BaseObject, new()
        {
            this.Set<T>().Remove(obj);
            return 1;
        }

        public virtual int Update<T>(T oldobj, T newobj) where T : BaseObject, new()
        {
            switch ((new T()).getclassname())
            {
                case "phonghoc":
                    (oldobj as phonghoc).tenphong = (newobj as phonghoc).tenphong;
                    (oldobj as phonghoc).siso = (newobj as phonghoc).siso;
                    (oldobj as phonghoc).images = (newobj as phonghoc).images;
                    (oldobj as phonghoc).dien_tich = (newobj as phonghoc).dien_tich;
                    break;
                default:
                    break;
                    
            }
            return 1;
        }
        //public virtual IEnumerable<phonghoc> getphonghoc()
        //{
        //    return this.phonghocs;
        //}
        //protected Dictionary<BaseObject, object> Mapping_Key { get; set; }

        protected virtual string OnKey<T>(T Key) where T:class,new()
        {
            switch (Key.GetType().Name)
            {
                case "phonghoc":
                    return "maphong";
                case "trangthaiphong":
                    return "ID";
                case "thoikhoabieu":
                    return "ID";
                default:
                    return "";
            }

        }

        protected virtual object OnValue<T>(T Key) where T : class,new()
        {
            switch (Key.GetType().Name)
            {
                case "phonghoc":
                    return (Key as phonghoc).maphong;
                case "trangthaiphong":
                    return (Key as trangthaiphong).ID;
                case "thoikhoabieu":
                    return (Key as thoikhoabieu).ID;
                default:
                    return "";
            }

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new cahocMap());
            modelBuilder.Configurations.Add(new GiangvienMap());
            modelBuilder.Configurations.Add(new hocphanMap());
            modelBuilder.Configurations.Add(new lapphongMap());
            modelBuilder.Configurations.Add(new LopMap());
            modelBuilder.Configurations.Add(new monhocMap());
            modelBuilder.Configurations.Add(new NganhMap());
            modelBuilder.Configurations.Add(new NhomMap());
            modelBuilder.Configurations.Add(new phonghocMap());
            modelBuilder.Configurations.Add(new quyenMap());
            modelBuilder.Configurations.Add(new quyentruycapMap());
            modelBuilder.Configurations.Add(new SinhVienMap());
            modelBuilder.Configurations.Add(new tuanhocMap());
            modelBuilder.Configurations.Add(new thoikhoabieuMap());
            modelBuilder.Configurations.Add(new trangthaiphongMap());
        }


       
    }
}
