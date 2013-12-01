using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class quyen:BaseObject
    {
        public quyen()
        {
            this.quyentruycaps = new List<quyentruycap>();
        }

        public string maquyen { get; set; }
        public string quyenloi { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<quyentruycap> quyentruycaps { get; set; }
    }
}
