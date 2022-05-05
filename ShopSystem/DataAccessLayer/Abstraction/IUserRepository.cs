using ShopSystem.Entities;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataAccessLayer.Abstraction
{
    public interface IUserRepository
    {
        List<UserEntity> GetUsers();
        int Delete(int Id);
        int Update(UserEntity entity);
        int Insert(UserEntity entity);
        UserEntity Get(string email);

    }
}
