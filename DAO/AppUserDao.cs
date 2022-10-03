using Common;
using DAO.interfaces;
using Model;
using Model.ConfigModel;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAO
{
    public class AppUserDao : IAppUserDao
    {
        public readonly string _collectionName = "AppUser";
        public readonly IMongoCollection<AppUserModel> _appUserModel;
        public AppUserDao(MongoDbSettingModel mongoDbSettingModel)
        {
            MongoClient client = new MongoClient(mongoDbSettingModel.ConnectionString);
            IMongoDatabase database = client.GetDatabase(mongoDbSettingModel.DatabaseName);

            _appUserModel = database.GetCollection<AppUserModel>(_collectionName);
        }

        public IList<AppUserModel> Get()
        {
            return _appUserModel.AsQueryable().ToList();
        }
    }
}
