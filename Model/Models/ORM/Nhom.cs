using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public partial class Nhom:BaseObject
    {
        public Nhom()
        {
            this.Accounts = new List<Account>();
            this.quyentruycaps = new List<quyentruycap>();
        }

        public string manhom { get; set; }
        public string tennhom { get; set; }
        public string phanloai { get; set; }
        public string thongtin { get; set; }
        
        public byte[] image { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<Account> Accounts { get; set; }
        [BsonIgnoreIfDefault]
        public virtual ICollection<quyentruycap> quyentruycaps { get; set; }
    }
}
