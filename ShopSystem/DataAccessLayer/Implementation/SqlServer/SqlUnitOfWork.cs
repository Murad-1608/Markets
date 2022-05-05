using ShopSystem.Core.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    internal class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString;
        public SqlUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public IUserRepository UserRepository => new SqlUserRepository(connectionString);

        public IBranchRepository BranchesRepository =>  new SqlBranchRepository(connectionString);

        public IProductRepository ProductRepository => new SqlProductRepository(connectionString);

        public ICompanyRepository CompaniesRepository => new SqlCompanyRepository(connectionString);

        
    }
}
