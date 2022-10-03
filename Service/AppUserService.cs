using Common;
using DAO.interfaces;
using Model;
using Model.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class AppUserService
    {
        private readonly IAppUserDao _appUserDao;
        public AppUserService(IAppUserDao appUserDao)
        {
            _appUserDao = appUserDao;
        }

        public ReturnModel Get()
        {
            return new ReturnModel
            {
                Code = ResponseCode.Success,
                Content = _appUserDao.Get()
            };
                
        }
    }
}
