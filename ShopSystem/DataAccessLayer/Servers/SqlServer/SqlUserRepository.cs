using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Entities;
using ShopSystem.Models;
using ShopSystem.Security;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Servers.SqlServer
{
    internal class SqlUserRepository : IUserRepository
    {
        private readonly string connectionString;

        public SqlUserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Delete(int Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"delete from Users where Id=@Id";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public List<UserEntity> GetUsers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                List<UserEntity> Users = new List<UserEntity>();

                string command = @"select *from Users";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserEntity entity = new UserEntity();
                        entity.Id = int.Parse(dr["id"].ToString());
                        entity.Name = dr["Name"].ToString();
                        entity.Surname = dr["Surname"].ToString();
                        entity.FatherName = dr["FatherName"].ToString();
                        entity.Email = dr["Email"].ToString();
                        entity.Password = dr["Password"].ToString();
                        entity.PhoneNumber = dr["PhoneNumber"].ToString();
                        entity.Position = dr["Position"].ToString();

                        Users.Add(entity);
                    }
                    return Users;
                }
            }
        }


        public int Insert(UserEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = @"Insert into Users values(@Name,@Surname,@FatherName,@Email,@Password,@PhoneNumber,@Position)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {                 
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Surname", entity.Surname);
                    cmd.Parameters.AddWithValue("@FatherName", entity.FatherName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Password", Utils.PasswordHash(entity.Password));
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Position", entity.Position);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Get(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"select Name,Surname,Password,Position from Users where Password=@Password and Email=@Email";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    UserEntity entity = new UserEntity();


                    int a = 0;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        UserInformation.Password = dr["Password"].ToString();
                        UserInformation.Name = dr["Name"].ToString();
                        UserInformation.Surname = dr["Surname"].ToString();
                        UserInformation.Position = dr["Position"].ToString();
                        a++;
                    }
                    return a;
                }
            }
        }

        public int Update(UserEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = @"Update Users set BranchId=@BranchId,Name=@Name,Surname=@Surname,FatherName=@FatherName,Email=@Email,Password=@Password,PhoneNumber=@PhoneNumber,Position=@Position where Id=@Id";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@BranchId", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Surname", entity.Surname);
                    cmd.Parameters.AddWithValue("@FatherName", entity.FatherName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Position", entity.Position);

                    int check = cmd.ExecuteNonQuery();
                    return check;
                }

            }
        }

        public int Get(string Email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"select Name,Surname,Password,Email,Position from Users where Email=@Email";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    UserEntity entity = new UserEntity();


                    int a = 0;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserInformation.Password = dr["Password"].ToString();
                        UserInformation.Name = dr["Name"].ToString();
                        UserInformation.Surname = dr["Surname"].ToString();
                        UserInformation.Email = dr["Email"].ToString();
                        UserInformation.Position = dr["Position"].ToString();
                        a++;
                    }
                    return a;
                }
            }
        }

        public int Update(string Email, string Password)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = @"Update Users set Password=@Password where Email=@Email";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    cmd.Parameters.AddWithValue("@Password", Utils.PasswordHash(Password));
                    cmd.Parameters.AddWithValue("@Email", Email);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }
    }
}
