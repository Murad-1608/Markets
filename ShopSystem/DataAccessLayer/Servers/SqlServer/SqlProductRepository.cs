using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly string connectionString;
        public SqlProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Add()
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                string command = @"Insert into Products vlues(@Brand,@Count,@Price,@Type,@Color,@Comment)";
                using (SqlCommand cmd=new SqlCommand(command,con))
                {
                    cmd.Parameters.AddWithValue();
                }
            }
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
