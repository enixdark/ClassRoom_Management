using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class lapphong:BaseObject
    {
        public string mahp { get; set; }
        public string maphong { get; set; }
        public string malop { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Lop Lop { get; set; }
        [BsonIgnoreIfDefault]
        public virtual phonghoc phonghoc { get; set; }
    }
}
