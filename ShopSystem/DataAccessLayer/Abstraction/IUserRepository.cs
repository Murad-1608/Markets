using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    internal interface IUserRepository
    {
        List<UserEntity> GetUsers();
        int Delete(int Id);
        int Update(int Id, int BranchId, string Name, string Surname, string FatherName, string Email, string Password, string PhoneNumber);
        int Update(string Email, string Password);
        int Insert(int BranchId, string Name, string Surname, string FatherName, string Email, string Password, string PhoneNumber);
        int Get(string Email, string Password);
        int Get(string Email);

    }
}
