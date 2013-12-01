using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class phonghoc:BaseObject
    {
        public phonghoc()
        {
            this.lapphongs = new List<lapphong>();
        }

        public string maphong { get; set; }
        public string tenphong { get; set; }
        public byte[] images { get; set; }
        public Nullable<double> dien_tich { get; set; }
        public Nullable<int> siso { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<lapphong> lapphongs { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<trangthaiphong> trangthaiphongs { get; set; }
    }
}
