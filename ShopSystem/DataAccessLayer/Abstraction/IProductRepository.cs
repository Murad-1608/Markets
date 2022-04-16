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
        int Insert(string name,string brand, double price, int count,string type, string color, string comment);
        int Update(ProductEntity entity);
        int Delete(string Name);
        List<ProductEntity> GetProducts();

    }
}
