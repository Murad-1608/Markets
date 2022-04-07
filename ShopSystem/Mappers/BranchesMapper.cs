using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public class BranchesMapper
    {
        public BranchesModel Map(BranchEntity entity)
        {
           BranchesModel model = new BranchesModel()
           {
               Id = entity.Id,
               Location = entity.Location,
               Profit = entity.Profit,
               PhoneNumber = entity.PhoneNumber,       
               Balance = entity.Balance,
           };
            return model;
        }
        public BranchEntity Map(BranchesModel model)
        {
            BranchEntity entity = new BranchEntity()
            {
                Id = model.Id,
                Location = model.Location,
                PhoneNumber = model.PhoneNumber,
                Profit = model.Profit,
                Balance = model.Balance,
            };
            return entity;
        }
    }
}
