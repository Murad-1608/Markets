using ShopSystem.Core.DataAccessLayer.Abstraction;
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
    public class SqlBranchesRepository : IBranchesRepository
    {
        private readonly string connectionString;
        public SqlBranchesRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }    

        public List<BranchEntity> GetBranches()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<BranchEntity> branches = new List<BranchEntity>();
                con.Open();
                string cmdtxt = @"select * from Branches";
                using (SqlCommand cmd = new SqlCommand(cmdtxt, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BranchEntity entity = new BranchEntity();
                        entity.Id = int.Parse(dr["Id"].ToString());
                        entity.Location = dr["Location"].ToString();
                        entity.Profit = int.Parse(dr["Profit"].ToString());
                        entity.PhoneNumber = dr["PhoneNumber"].ToString();
                        entity.Balance = int.Parse(dr["Balance"].ToString());
                        branches.Add(entity);
                    }
                    return branches;
                }
            }
        }

        public int Insert(BranchEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "insert into Branches values(@Location,@Profit,@PhoneNumber,@Balance)";
                using (SqlCommand cmd = new SqlCommand(cmdtxt, con))
                {
                
                    cmd.Parameters.AddWithValue("@Location", entity.Location);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Balance", entity.Balance);
                    cmd.Parameters.AddWithValue("@Profit", entity.Profit);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Update(BranchEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "update Branches set Name=@Name,Location=@Location,Profit=@Profit,PhoneNumber=@PhoneNumber,Balance=@Balance  where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(cmdtxt, con))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Location", entity.Location);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Balance", entity.Balance);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string cmdtxt = "delete from Branches where Id=@Id";
                using (SqlCommand cmd = new SqlCommand(cmdtxt, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }
    }
}
