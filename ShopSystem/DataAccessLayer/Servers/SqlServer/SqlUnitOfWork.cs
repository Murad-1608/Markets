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
            builder.DataSource = "SQL5104.site4now.net";
            builder.InitialCatalog = "db_a853f8_shopsystemdata";
            builder.IntegratedSecurity = false;
            builder.UserID = "db_a853f8_shopsystemdata_admin";
            builder.Password = "mk20032003";
            connectionString = builder.ConnectionString;
        }
        
        public IUserRepository EmployeeRepository => new SqlUserRepository(connectionString);

        public IBranchesRepository BranchesRepository =>  new SqlBranchesRepository(connectionString);

        public IProductRepository ProductRepository => new SqlProductRepository(connectionString);
    }
}
