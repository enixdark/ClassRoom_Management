using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class monhoc:BaseObject
    {
        public monhoc()
        {
            this.hocphans = new List<hocphan>();
        }

        public string mamh { get; set; }
        public string tenmh { get; set; }
        public Nullable<int> sotinchi { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<hocphan> hocphans { get; set; }
    }
}
