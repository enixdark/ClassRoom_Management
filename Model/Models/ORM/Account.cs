using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class Account : BaseObject
    {
       
        public string maid { get; set; }
        public string pass { get; set; }
        public string manhom { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nhom Nhom { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Giangvien Giangvien { get; set; }
        [BsonIgnoreIfDefault]
        public virtual SinhVien SinhVien { get; set; }
    }
}
