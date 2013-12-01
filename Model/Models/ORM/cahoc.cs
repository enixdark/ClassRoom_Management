using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class cahoc:BaseObject
    {
        
        public string maca { get; set; }
        public string thoiluong { get; set; }
        public Nullable<System.TimeSpan> thoigianbatdau { get; set; }
        public Nullable<System.TimeSpan> thoigianketthuc { get; set; }
        //public string thoigianbatdau { get; set; }
        //public string thoigianketthuc { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<thoikhoabieu> thoikhoabieus { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<trangthaiphong> trangthaiphongs { get; set; }
    }

    
    
}
