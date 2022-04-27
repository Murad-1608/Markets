using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Factories
{
    public class DBFactory
    {
        public static IUnitOfWork Create(string connectionString)
        {
            return new SqlUnitOfWork(connectionString);
        }
    }
}
