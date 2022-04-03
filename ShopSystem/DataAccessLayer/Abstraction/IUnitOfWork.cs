using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IProductRepository ProductRepository { get; }
        IBranchesRepository BranchesRepository { get; }
    }
}
