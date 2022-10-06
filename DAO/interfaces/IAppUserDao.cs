using Common;
using Model;
using Model.DTO;
using Model.ResultModel;
using Model.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.interfaces
{
    public interface IAppUserDao
    {
        /// <summary>
        /// 取得所有AppUser資料清單
        /// </summary>
        /// <returns></returns>
        public IList<AppUserQueryViewModel> Get();

        /// <summary>
        /// 根據ID，取得AppUser資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AppUserQueryViewModel GetById(AppUserQueryByIdDTO dto);

        /// <summary>
        /// 新增AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AppUserModel Post(AppUserInsertDTO dto);
        
        /// <summary>
        /// 更新AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AppUserModel Update(AppUserUpdateDTO dto);

        /// <summary>
        /// 刪除AppUser
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public void Delete(AppUserDeleteDTO dto);

    }
}
