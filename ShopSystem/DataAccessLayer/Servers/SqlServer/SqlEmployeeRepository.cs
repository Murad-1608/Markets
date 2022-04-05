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
    internal class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly string connectionString;

        public SqlEmployeeRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public int Delete(int Id)
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"delete from Employees where Id=@Id";

                using (SqlCommand cmd=new SqlCommand(command,con))
                {
                    cmd.Parameters.AddWithValue("@Id", Id);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public List<EmployeeEntity> GetEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<EmployeeEntity> employees = new List<EmployeeEntity>();

                string command = @"select *from Employees";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(command,con))
                {
                    
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EmployeeEntity model = new EmployeeEntity();
                        model.Id = int.Parse(dr["id"].ToString());
                        model.Name = dr["Name"].ToString();
                        model.Surname = dr["Surname"].ToString();
                        model.FatherName = dr["FatherName"].ToString();
                        model.Email = dr["Email"].ToString();
                        model.Password = dr["Password"].ToString();
                        model.PhoneNumber = dr["PhoneNumber"].ToString();
                        model.Position = dr["Position"].ToString();
                        employees.Add(model);                        
                    }
                    return employees;
                }
            }
        }
               

        public int Insert(EmployeeEntity entity)
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                string command = @"Insert into Employees values(@BranchId,@Name,@Surname,@FatherName,@Email,@Password,@PhoneNumber,@Position)";
                con.Open();
                using (SqlCommand cmd=new SqlCommand(command,con))
                {


                    cmd.Parameters.AddWithValue("@BranchId",entity.BranchId);
                    cmd.Parameters.AddWithValue("@Name",entity.Name);
                    cmd.Parameters.AddWithValue("@Surname",entity.Surname);
                    cmd.Parameters.AddWithValue("@FatherName",entity.FatherName);
                    cmd.Parameters.AddWithValue("@Email",entity.Email);
                    cmd.Parameters.AddWithValue("@Password",entity.Password);
                    cmd.Parameters.AddWithValue("@PhoneNumber",entity.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Position",entity.Position);
                    int check = cmd.ExecuteNonQuery();
                    return check;
                }
            }
        }

        public int Get(EmployeeEntity entity)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"select Password from Employees where Password=@Password and Email=@Email";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    int a = 0;
                    cmd.Parameters.AddWithValue("@Email", entity.Email);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        entity.Email = dr["Email"].ToString();
                        entity.Password = dr["Password"].ToString();
                        a++;
                    }
                    return a;
                }
            }
        }

        public int Update(EmployeeEntity entity)
        {
            using (SqlConnection con=new SqlConnection(connectionString))
            {
                string command = @"Update Employees set BranchId=@BranchId,Name=@Name,Surname=@Surname,FatherName=@FatherName,Email=@Email,Password=@Password,PhoneNumber=@PhoneNumber,Position=@Position where Id=@Id";
                con.Open();
                using (SqlCommand cmd=new SqlCommand(command,con))
                {
                    cmd.Parameters.AddWithValue("@Id",entity.Id);
                    cmd.Parameters.AddWithValue("@BranchId", entity.BranchId);
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
    }
}
