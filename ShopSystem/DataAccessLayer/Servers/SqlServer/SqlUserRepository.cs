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
                        UserEntity model = new UserEntity();
                        model.Id = int.Parse(dr["id"].ToString());
                        model.Name = dr["Name"].ToString();
                        model.Surname = dr["Surname"].ToString();
                        model.FatherName = dr["FatherName"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Password = dr["Password"].ToString();
                        model.PhoneNumber = dr["PhoneNumber"].ToString();
                        Users.Add(model);
                    }
                    return Users;
                }
            }
        }


        public int Insert(int BranchId, string Name, string Surname, string FatherName, string Email, string Password, string PhoneNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string command = @"Insert into Users values(@BranchId,@Name,@Surname,@FatherName,@Email,@Password,@PhoneNumber)";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command, con))
                {


                    cmd.Parameters.AddWithValue("@BranchId",BranchId);
                    cmd.Parameters.AddWithValue("@Name",Name);
                    cmd.Parameters.AddWithValue("@Surname",Surname);
                    cmd.Parameters.AddWithValue("@FatherName", FatherName);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);                    
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
                string command = @"select Name,Surname,Password from Users where Password=@Password and Email=@Email";

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
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Surname", entity.Surname);
                    cmd.Parameters.AddWithValue("@FatherName", entity.FatherName);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber", entity.PhoneNumber);

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
                string command = @"select Password from Users where Email=@Email";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    UserEntity entity = new UserEntity();


                    int a = 0;
                    cmd.Parameters.AddWithValue("@Email", Email);                   
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        UserInformation.Password = dr["Password"].ToString();
                        a++;
                    }
                    return a;
                }
            }
        }
    }
}
