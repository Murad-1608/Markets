using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    public class SqlCompaniesRepository : ICompaniesRepository
    {
        private readonly string connectionString;
        public SqlCompaniesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "delete from Companies where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(cmdtxt, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);                    
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public List<CompaniesEntity> GetCompanies()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<CompaniesEntity> companies = new List<CompaniesEntity>();
                con.Open();
                string cmdtxt = "select * from Companies";
                using(SqlCommand cmd = new SqlCommand(cmdtxt,con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CompaniesEntity entity = new CompaniesEntity();
                        entity.Id = int.Parse(dr["Id"].ToString());
                        entity.Name = dr["Name"].ToString();
                        companies.Add(entity);
                    }
                    return companies;
                }
            }
        }

        public int Insert(CompaniesEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "insert into Companies values(@Name)";
                using (SqlCommand cmd = new SqlCommand(cmdtxt,con))
                {
                 
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        
        public int Update(CompaniesEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "update Companies set Name=@Name where Name=@Name ";
                using (SqlCommand cmd = new SqlCommand(cmdtxt,con))
                {
                    
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }
    }
}
