using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class Nganh:BaseObject
    {
        public Nganh()
        {
            this.Giangviens = new List<Giangvien>();
            this.Lops = new List<Lop>();
            this.SinhViens = new List<SinhVien>();
        }

        public string manganh { get; set; }
        public string tennganh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<Giangvien> Giangviens { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<Lop> Lops { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<thoikhoabieu> thoikhoabieus { get; set; }
    }
}
