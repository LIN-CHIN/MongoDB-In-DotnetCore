using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTO
{
    public class AppUserDeleteDTO
    {
        /// <summary>
        /// MongoDB ObjectId
        /// </summary>
        [Required]
        public string Id { get; set; }

    }
}
