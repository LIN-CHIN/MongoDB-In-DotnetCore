using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class AppUserModel : GlobalModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [BsonElement("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [BsonElement("user_name")]
        public string UserName { get; set; }

        /// <summary>
        /// 職位
        /// </summary>
        [BsonElement("position")]
        public string Position { get; set; }
    }
}
