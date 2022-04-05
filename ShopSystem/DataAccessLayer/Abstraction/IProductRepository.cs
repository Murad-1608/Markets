using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IProductRepository
    {
        int Insert(ProductEntity entity);
        int Update(ProductEntity entity);
        int Delete(int Id);
        List<ProductEntity> GetProducts();

    }
}
