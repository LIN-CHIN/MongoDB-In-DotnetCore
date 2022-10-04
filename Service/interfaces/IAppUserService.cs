using Model.DTO;
using Model.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.interfaces
{
    public interface IAppUserService
    {
        /// <summary>
        /// 取得AppUser資料清單
        /// </summary>
        /// <returns></returns>
        public ReturnModel Get();

        /// <summary>
        /// 新增AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnModel Post(AppUserInsertDTO dto);

        /// <summary>
        /// 更新AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnModel Update(AppUserUpdateDTO dto);

        /// <summary>
        /// 刪除AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ReturnModel Delete(AppUserDeleteDTO dto);
    }
}
