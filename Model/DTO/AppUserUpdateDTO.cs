using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTO
{
    public class AppUserUpdateDTO
    {
        /// <summary>
        /// MongoDB ObjectId
        /// </summary>
        [Required]
        public string Id { get; set; }

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
        [StringLength(50)]
        public string Position { get; set; }

    }
}
