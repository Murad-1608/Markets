using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.DataContext
{
    internal class DataProvider
    {  
        public List<UserModel> Users()
        {
            IUnitOfWork unitOfWork = new SqlUnitOfWork();
            var users = unitOfWork.UserRepository.GetUsers();

            List<UserModel> UsersModel = new List<UserModel>();

            UserMapper mapper = new UserMapper();

            for (int i=0; i<users.Count;i++)
            {
                var user = users[i];

                var usersmodel=mapper.Map(user);

                usersmodel.No = i + 1;

                UsersModel.Add(usersmodel);
            }
            return UsersModel;
        }

    }
}
