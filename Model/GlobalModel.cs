using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Model
{
    public abstract class GlobalModel
    {
        /// <summary>
        /// 建立日期
        /// </summary>
        [BsonRequired]
        [BsonElement("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        [BsonElement("update_date")]
        public DateTime? UpdateDate { get; set; }

    }
}
