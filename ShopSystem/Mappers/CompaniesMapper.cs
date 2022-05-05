using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public class CompaniesMapper : BaseMapper<CompanyModel, CompanyEntity>
    {
        public override CompanyModel Map(CompanyEntity entity)
        {
            CompanyModel model = new CompanyModel()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            return model;
        }

        public override CompanyEntity Map(CompanyModel model)
        {
            CompanyEntity entity = new CompanyEntity()
            {
                Id = model.Id,
                Name = model.Name,
            };

            return entity;
        }
    }
}