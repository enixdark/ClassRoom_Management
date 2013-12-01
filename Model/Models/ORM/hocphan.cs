using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class hocphan : BaseObject
    {

        public string mahp { get; set; }
        public string mamh { get; set; }
        //public virtual monhoc monhoc { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<thoikhoabieu> thoikhoabieus { get; set; }
        
    }
}
