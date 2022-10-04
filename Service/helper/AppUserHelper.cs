using DAO.interfaces;
using Model.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.helper
{
    public class AppUserHelper
    {
        private readonly IAppUserDao _appUserDao;
        public AppUserHelper(IAppUserDao appUserDao)
        {
            _appUserDao = appUserDao;
        }

        /// <summary>
        /// 嘗試根據傳入的Id 取得AppUser資料
        /// </summary>
        /// <param name="id"> MongoDB ObjectId </param>
        /// <returns></returns>
        public bool TryGetAppUserDataById(string id)
        {
            AppUserQueryByIdDTO filter = new AppUserQueryByIdDTO
            {
                Id = id
            };

            if (_appUserDao.GetById(filter) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
