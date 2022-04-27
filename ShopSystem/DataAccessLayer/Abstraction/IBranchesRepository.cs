using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Core.DataAccessLayer.Abstraction
{
    public interface IBranchesRepository
    {
        int Insert(BranchEntity entity);
        int Update(BranchEntity entity);
        int Delete(int Id);
        List<BranchEntity> GetBranches();
    }
}
