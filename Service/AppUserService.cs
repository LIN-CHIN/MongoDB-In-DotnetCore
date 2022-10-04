using Common;
using DAO.interfaces;
using Model;
using Model.DTO;
using Model.ResultModel;
using Service.helper;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserDao _appUserDao;
        private readonly AppUserHelper _appUserHelper;
        public AppUserService(IAppUserDao appUserDao, AppUserHelper appUserHelper)
        {
            _appUserDao = appUserDao;
            _appUserHelper = appUserHelper;
        }

        public ReturnModel Get()
        {
            return new ReturnModel
            {
                Code = ResponseCode.Success,
                Content = _appUserDao.Get()
            };
                
        }

        public ReturnModel Post(AppUserInsertDTO dto)
        {
            return new ReturnModel
            {
                Code = ResponseCode.Success,
                Content = _appUserDao.Post(dto)
            };
        }

        public ReturnModel Update(AppUserUpdateDTO dto)
        {
            ReturnModel result = new ReturnModel();

            //確認是否能取得資料
            bool isFindData = _appUserHelper.TryGetAppUserDataById(dto.Id);

            if (!isFindData)
            {
                result.Code = ResponseCode.NotFindDataError;
                result.Content = new
                {
                    Id = dto.Id
                };
            }
            else 
            {
                result.Code = ResponseCode.Success;
                result.Content = _appUserDao.Update(dto);
            }

            return result;
        }

        public ReturnModel Delete(AppUserDeleteDTO dto)
        {
            ReturnModel result = new ReturnModel();

            //確認是否能取得資料
            bool isFindData = _appUserHelper.TryGetAppUserDataById(dto.Id);

            if (!isFindData)
            {
                result.Code = ResponseCode.NotFindDataError;
                result.Content = new
                {
                    Id = dto.Id
                };
            }
            else
            {
                _appUserDao.Delete(dto);
                result.Code = ResponseCode.Success;
            }

            return result;
        }


        
    }
}
