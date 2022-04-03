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
        public SqlUnitOfWork()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "DESKTOP-D2H7I2Q";
            builder.InitialCatalog = "ShopSystemData";
            builder.IntegratedSecurity = false;
            builder.UserID = "sa";
            builder.Password = "1";
            connectionString = builder.ConnectionString;
        }
        public IEmployeeRepository EmployeeRepository => new SqlEmployeeRepository(connectionString);

        public IProductRepository ProductRepository =>  new SqlProductRepository(connectionString);

        public IBranchesRepository BranchesRepository => new SqlBranchesRepository(connectionString);
    }
}
