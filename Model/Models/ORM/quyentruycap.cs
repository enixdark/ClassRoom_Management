using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class quyentruycap:BaseObject
    {
        public string manhom { get; set; }
        public string maquyen { get; set; }
        public string trangthai { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nhom Nhom { get; set; }
        [BsonIgnoreIfDefault]
        public virtual quyen quyen { get; set; }
    }
}
