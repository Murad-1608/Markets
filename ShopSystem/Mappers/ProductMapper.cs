using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public class ProductMapper : BaseMapper<ProductModel, ProductEntity>
    {
        private readonly BranchMapper branchesMapper = new BranchMapper();

        public override ProductModel Map(ProductEntity entity)
        {
            ProductModel model = new ProductModel()
            {
                Id = entity.Id,
                Brand = entity.Brand,
                Branch = branchesMapper.Map(entity.Branch),
                Name = entity.Name,
                Color = entity.Color,
                Count = entity.Count,
                Price = entity.Price,
                Type = entity.Type,
                Comment = entity.Comment
            };
            return model;
        }

        public override ProductEntity Map(ProductModel model)
        {
            ProductEntity entity = new ProductEntity()
            {
                Id = model.Id,
                Brand = model.Brand,
                Branch = branchesMapper.Map(model.Branch),
                Price = model.Price,
                Name = model.Name,
                Type = model.Type,
                Color = model.Color,
                Comment = model.Comment,
                Count = model.Count
            };

            return entity;
        }
    }
}
