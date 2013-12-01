using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class trangthaiphong:BaseObject
    {
        public string maphong { get; set; }
        //public Nullable<int> tuan { get; set; }
        public string maca { get; set; }
        public string hientrang { get; set; }
        //public string thu { get; set; }
        public Nullable<System.DateTime> thoigianbatdau { get; set; }
        public Nullable<System.DateTime> thoigianketthuc { get; set; }
        public int ID { get; set; }
        [BsonIgnoreIfDefault]
        public virtual cahoc cahoc { get; set; }
        [BsonIgnoreIfDefault]
        public virtual phonghoc phonghoc { get; set; }
    }
}
