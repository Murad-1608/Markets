using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Mappers
{
    public class ProductMapper
    {
        public ProductModel Map(ProductEntity entity)
        {
            ProductModel model = new ProductModel()
            {
               Id = entity.Id,
               Price = entity.Price,
               Name = entity.Name,
               Type = entity.Type,
               Color = entity.Color,
               Comment = entity.Comment,
               Count = entity.Count                
            };
            return model;
        }
        public ProductEntity Map(ProductModel model)
        {
            ProductEntity entity = new ProductEntity()
            {
                Id = model.Id,
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
