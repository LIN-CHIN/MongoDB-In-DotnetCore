using Common;
using DAO.interfaces;
using Model;
using Model.ConfigModel;
using Model.DTO;
using Model.ViewModel.AppUser;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<AppUserQueryViewModel> Get()
        {
            return _appUserModel.AsQueryable()
                                .Select(s => new AppUserQueryViewModel 
                                {
                                    Id = s.Id,
                                    UserId = s.UserId,
                                    UserName = s.UserName,
                                    Position = s.Position,
                                    CreateDate = s.CreateDate,
                                    UpdateDate = s.UpdateDate
                                })
                                .ToList();
        }

        public AppUserQueryViewModel GetById(AppUserQueryByIdDTO dto)
        {
            return _appUserModel.AsQueryable()
                                .Where(x => x.Id == dto.Id)
                                .Select(s => new AppUserQueryViewModel
                                {
                                    Id = s.Id,
                                    UserId = s.UserId,
                                    UserName = s.UserName,
                                    Position = s.Position,
                                    CreateDate = s.CreateDate,
                                    UpdateDate = s.UpdateDate
                                })
                                .FirstOrDefault();
        }

        public AppUserModel Post(AppUserInsertDTO dto)
        {
            AppUserModel insertModel = new AppUserModel
            {
                UserId  = dto.UserId,
                UserName = dto.UserName,
                Position = dto.Position,
                CreateDate = DateTime.Now
            };

            _appUserModel.InsertOne(insertModel);

            return insertModel;
        
        }

        public AppUserModel Update(AppUserUpdateDTO dto)
        {
            var filter = Builders<AppUserModel>.Filter.Eq("Id", dto.Id);
            var update = Builders<AppUserModel>.Update.Set(s => s.UserId, dto.UserId)
                                                      .Set(s => s.UserName, dto.UserName)
                                                      .Set(s => s.Position, dto.Position)
                                                      .Set(s => s.UpdateDate, DateTime.Now);

            _appUserModel.UpdateOne(filter, update);

            return _appUserModel.AsQueryable()
                                .Where(x => x.Id == dto.Id)
                                .FirstOrDefault();
        }

        public void Delete(AppUserDeleteDTO dto)
        {
            _appUserModel.DeleteOne(x => x.Id == dto.Id);
        }

    }
}
