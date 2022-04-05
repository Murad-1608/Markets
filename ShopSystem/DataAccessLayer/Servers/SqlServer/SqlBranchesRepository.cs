using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Models;
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
        public int Insert()
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

        public List<BranchesModel> GetBranches()
        {
            throw new NotImplementedException();
        }
    }
}
