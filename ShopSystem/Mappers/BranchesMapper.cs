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
        public BranchesModel Map(BranchesEntity entity)
        {
           BranchesModel model = new BranchesModel()
           {
               NumberId = entity.NumberId,
               Location = entity.Location,
               Profit = entity.Profit,
               PhoneNumber = entity.PhoneNumber,
               DepoInformations = entity.DepoInformations,
               Balance = entity.Balance,
           };
            return model;
        }
        public BranchesEntity Map(BranchesModel model)
        {
            BranchesEntity entity = new BranchesEntity()
            {
                NumberId = model.NumberId,
                Location = model.Location,
                PhoneNumber = model.PhoneNumber,
                Profit = model.Profit,
                DepoInformations = model.DepoInformations,
                Balance = model.Balance,
            };
            return entity;
        }
    }
}
