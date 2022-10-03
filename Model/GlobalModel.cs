using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Model
{
    public abstract class GlobalModel
    {
        [BsonElement("create_date")]
        public DateTime? CreateDate { get; set; }

        [BsonElement("update_date")]
        public DateTime? UpdateDate { get; set; }

    }
}
