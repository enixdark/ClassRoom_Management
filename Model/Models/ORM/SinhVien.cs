using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class SinhVien:BaseObject
    {
        public string masv { get; set; }
        public string hoten { get; set; }
        public string malop { get; set; }
        public string manganh { get; set; }
        public Nullable<bool> gioitinh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Account Account { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Lop Lop { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nganh Nganh { get; set; }
    }
}
