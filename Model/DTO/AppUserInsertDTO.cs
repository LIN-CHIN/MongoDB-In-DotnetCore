using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTO
{
    public class AppUserInsertDTO
    {
        /// <summary>
        /// 使用者帳號
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 6)]
        public string UserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string UserName { get; set; }

        /// <summary>
        /// 職位
        /// </summary>
        [Required]
        public string Position { get; set; }

    }
}
