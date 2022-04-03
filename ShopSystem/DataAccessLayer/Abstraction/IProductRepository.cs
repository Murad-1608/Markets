using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IProductRepository
    {
        int Add();
        int Update();
        int Delete();

    }
}
