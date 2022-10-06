using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model
{
    public class AppUserModel : GlobalModel
    {
        /// <summary>
        /// MongoDB ObjectId
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        [BsonElement("user_id")]
        [StringLength(50, MinimumLength = 6)]
        public string UserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [BsonElement("user_name")]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; }

        /// <summary>
        /// 職位
        /// </summary>
        [BsonElement("position")]
        [StringLength(50)]
        public string Position { get; set; }
    }
}
