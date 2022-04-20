using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public class CompaniesMapper
    {
        
        public CompaniesModel Map(CompaniesEntity entity)
        {
            CompaniesModel model = new CompaniesModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return model;
        }
        public CompaniesEntity Map(CompaniesModel model)
        {
            CompaniesEntity entity = new CompaniesEntity()
            {
                Id = model.Id,
                Name = model.Name,
            };
            return entity;
        }
    }
}
