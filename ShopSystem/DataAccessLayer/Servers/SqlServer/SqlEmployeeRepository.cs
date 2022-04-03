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
            throw new NotImplementedException();
        }

        public List<EmployeeEntity> Employees()
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
               

        public int Insert(EmployeeEntity model)
        {
            throw new NotImplementedException();
        }

        public int Get(string Email)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string command = @"select Password from Employees where Email=@Email";

                using (SqlCommand cmd = new SqlCommand(command, con))
                {
                    int a = 0;
                    cmd.Parameters.AddWithValue("@Email", Email);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {                        
                        User.Email = Email;
                        User.Password = dr["Password"].ToString();
                        a++;
                    }
                    return a;
                }
            }
        }

        public int Update(EmployeeEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
