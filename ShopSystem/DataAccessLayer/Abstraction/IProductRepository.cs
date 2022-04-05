using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IProductRepository
    {
        int Insert();
        int Update();
        int Delete();
        List<ProductModel> GetProducts();

    }
}
