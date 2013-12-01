using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;


namespace Model.Models
{
    public partial class thoikhoabieu:BaseObject
    {
        public string mahp { get; set; }
        public string malop { get; set; }
        public string magv { get; set; }
        public string manganh { get; set; }
        public string maca { get; set; }
        public Nullable<int> siso { get; set; }
        public Nullable<int> tuanhocbatdau { get; set; }
        public Nullable<int> tuanhocketthuc { get; set; }
        public int ID { get; set; }
        [BsonIgnoreIfDefault]
        public virtual cahoc cahoc { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Giangvien Giangvien { get; set; }
        [BsonIgnoreIfDefault]
        public virtual hocphan hocphan { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Lop Lop { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nganh Nganh { get; set; }
    }
}
