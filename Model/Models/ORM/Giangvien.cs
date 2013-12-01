using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class Giangvien:BaseObject
    {
       
        

        public string magv { get; set; }
        public string tengv { get; set; }
        public string manganh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Account Account { get; set; }
        [BsonIgnoreIfDefault]
        public virtual Nganh Nganh { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<thoikhoabieu> thoikhoabieus { get; set; }
        
    }
}
