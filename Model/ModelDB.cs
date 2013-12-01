using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace Model
{
    public interface ModelDB
    {
         DbSet<Account> Accounts { get; set; }
         DbSet<cahoc> cahocs { get; set; }
         DbSet<Giangvien> Giangviens { get; set; }
         DbSet<hocphan> hocphans { get; set; }
         DbSet<lapphong> lapphongs { get; set; }
         DbSet<Lop> Lops { get; set; }
         DbSet<monhoc> monhocs { get; set; }
         DbSet<Nganh> Nganhs { get; set; }
         DbSet<Nhom> Nhoms { get; set; }
         DbSet<phonghoc> phonghocs { get; set; }
         DbSet<quyen> quyens { get; set; }
         DbSet<quyentruycap> quyentruycaps { get; set; }
         DbSet<SinhVien> SinhViens { get; set; }
         DbSet<tuanhoc> tuanhocs { get; set; }
         DbSet<thoikhoabieu> thoikhoabieus { get; set; }
         DbSet<trangthaiphong> trangthaiphongs { get; set; }

    }
}
