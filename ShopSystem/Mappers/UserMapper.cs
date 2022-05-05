using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models;
namespace ShopSystem.Mappers
{
    internal class UserMapper : BaseMapper<UserModel, UserEntity>
    {
        public override UserModel Map(UserEntity entity)
        {
            UserModel model = new UserModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                FatherName = entity.FatherName,
                Email = entity.Email,
                Password = entity.Password,
                PhoneNumber = entity.PhoneNumber,
                Position = entity.Position
            };

            return model;
        }

        public override UserEntity Map(UserModel model)
        {
            UserEntity entity = new UserEntity()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                FatherName = model.FatherName,
                Email = model.Email,
                Password = model.Password,
                PhoneNumber = model.PhoneNumber,
                Position = model.Position
            };

            return entity;
        }
    }
}
