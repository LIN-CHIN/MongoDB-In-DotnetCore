using Common;
using Model;
using Model.ResultModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.interfaces
{
    public interface IAppUserDao
    {
        public IList<AppUserModel> Get();
    }
}
