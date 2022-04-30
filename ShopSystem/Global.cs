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
        public static string UserName { get; set; }
        public static string UserPosition { get; set; }
        public static string Email { get; set; }
        public static string Password { get; set; }
    }
}
