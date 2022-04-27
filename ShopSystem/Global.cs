using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem
{
    public static class Global
    {
        public static IUnitOfWork DB { get; set; }
    }
}
