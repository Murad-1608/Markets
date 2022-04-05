using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    internal class SqlProductRepository : IProductRepository
    {
        private readonly string connectionString;
        public SqlProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int Insert(ProductEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"Insert into Products values(@Brand,@Count,@Price,@Type,@Color,@Comment)";
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@Brad", entity.Brand);
                    cmd.Parameters.AddWithValue("@Count", entity.Count);
                    cmd.Parameters.AddWithValue("@Prince", entity.Price);
                    cmd.Parameters.AddWithValue("@Type", entity.Type);
                    cmd.Parameters.AddWithValue("@Color", entity.Color);
                    cmd.Parameters.AddWithValue("@Type", entity.Comment);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Update(ProductEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = "update Products set Brand=@Brand,Count=@Count,Price=@Price,Type=@Type,Color=@Color,Comment=@Comment where Id=@Id";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Brad", entity.Brand);
                    cmd.Parameters.AddWithValue("@Count", entity.Count);
                    cmd.Parameters.AddWithValue("@Prince", entity.Price);
                    cmd.Parameters.AddWithValue("@Type", entity.Type);
                    cmd.Parameters.AddWithValue("@Color", entity.Color);
                    cmd.Parameters.AddWithValue("@Type", entity.Comment);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = " delete from Products where Id=@Id";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);

                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }


        public List<ProductEntity> GetProducts()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<ProductEntity> products = new List<ProductEntity>();

                con.Open();

                string command = @"select *from Products";

                using(SqlCommand cmd = new SqlCommand(connectionString, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ProductEntity entity = new ProductEntity();
                        entity.Id = int.Parse(dr["Id"].ToString());
                        entity.Brand = dr["Brand"].ToString();
                        entity.Count = int.Parse(dr["Count"].ToString());
                        entity.Price = double.Parse(dr["Price"].ToString());
                        entity.Type = dr["Type"].ToString();
                        entity.Color = dr["Color"].ToString();
                        entity.Comment = dr["Commenct"].ToString();
                        products.Add(entity);
                        
                    }
                    return products;
                }
            }
        }
    }

    


}

