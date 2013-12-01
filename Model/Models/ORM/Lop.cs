using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class Lop : BaseObject
    {
        public Lop()
        {
            this.lapphongs = new List<lapphong>();
            this.SinhViens = new List<SinhVien>();
        }

        public string malop { get; set; }
        public string tenlop { get; set; }
        public string manganh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<lapphong> lapphongs { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nganh Nganh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<SinhVien> SinhViens { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<thoikhoabieu> thoikhoabieus { get; set; }
       
    }
}
