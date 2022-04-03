using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    public class SqlBranchesRepository : IBranchesRepository
    {
        private readonly string connectionString;
        public SqlBranchesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Add()
        {
            throw new NotImplementedException();
        }

        public int Delete()
        {
            throw new NotImplementedException();
        }

        public int Update()
        {
            throw new NotImplementedException();
        }
    }
}
