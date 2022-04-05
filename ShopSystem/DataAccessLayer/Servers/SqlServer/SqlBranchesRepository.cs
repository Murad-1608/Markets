using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
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

        public List<BranchesModel> GetBranches()
        {
            throw new NotImplementedException();
        }

        public int Insert(BranchEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Update(BranchEntity entity)
        {
            throw new NotImplementedException();
        }

        public int Delete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
