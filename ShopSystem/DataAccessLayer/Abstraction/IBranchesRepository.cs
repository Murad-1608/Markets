using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IBranchesRepository
    {
        int Add();
        int Update();
        int Delete();
    }
}
