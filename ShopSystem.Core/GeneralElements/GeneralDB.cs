using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Core.GeneralElements
{
    public class GeneralDB
    {
        public static IUnitOfWork Db(string connectionString)
        {
            return new SqlUnitOfWork();
        }
    }
}
