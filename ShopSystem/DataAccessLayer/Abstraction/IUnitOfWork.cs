using ShopSystem.Core.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBranchesRepository BranchesRepository { get; }
        IProductRepository ProductRepository { get; }
        ICompaniesRepository CompaniesRepository { get; }
    }
}
