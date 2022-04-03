using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopSystem.Models;
namespace ShopSystem.Mappers
{
    internal class EmployeeMapper
    {
        public EmployeeModel Map(EmployeeEntity entity)
        {
            EmployeeModel model = new EmployeeModel()
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

        public EmployeeEntity Map(EmployeeModel model)
        {
            EmployeeEntity entity = new EmployeeEntity()
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
