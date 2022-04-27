using ShopSystem.Core.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IProductRepository
    {
        int Insert(ProductEntity entity);
        int Update(ProductEntity entity);
        int Delete(int Id);
        List<ProductEntity> GetProducts();

    }
}
