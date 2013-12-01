using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Model.Models
{
    public abstract class BaseObject
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }

        public virtual string getclassname()
        {
            return this.GetType().Name;
        }
    }
}
