using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBranchesRepository BranchesRepository { get; }
        IProductRepository ProductRepository { get; }
        ICompaniesRepository CompaniesRepository { get; }
    }
}
