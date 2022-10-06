using System;
using System.Collections.Generic;
using System.Text;

namespace Model.ViewModel.AppUser
{
    public class AppUserQueryViewModel
    {
        /// <summary>
        /// MongoDB ObjectId
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 使用者帳號
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 職位
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? UpdateDate { get; set; }
    }
}
