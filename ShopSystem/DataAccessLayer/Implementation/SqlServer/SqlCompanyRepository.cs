using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    public class SqlCompanyRepository : ICompanyRepository
    {
        private readonly string connectionString;
        public SqlCompanyRepository(string connectionString)
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

        public List<CompanyEntity> GetCompanies()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<CompanyEntity> companies = new List<CompanyEntity>();
                con.Open();
                string cmdtxt = "select * from Companies";
                using(SqlCommand cmd = new SqlCommand(cmdtxt,con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        CompanyEntity entity = new CompanyEntity();
                        entity.Id = int.Parse(dr["Id"].ToString());
                        entity.Name = dr["Name"].ToString();
                        companies.Add(entity);
                    }
                    return companies;
                }
            }
        }

        public int Insert(CompanyEntity entity)
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

        
        public int Update(CompanyEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "update Companies set Name=@Name where Id=@Id ";
                using (SqlCommand cmd = new SqlCommand(cmdtxt,con))
                {
                    
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }
    }
}
