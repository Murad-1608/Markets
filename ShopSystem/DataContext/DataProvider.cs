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
        IUnitOfWork db = new SqlUnitOfWork();

        public List<UserModel> Users()
        {
            var users = db.UserRepository.GetUsers();

            List<UserModel> UsersModel = new List<UserModel>();

            UserMapper mapper = new UserMapper();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];

                var usersmodel = mapper.Map(user);

                usersmodel.No = i + 1;

                UsersModel.Add(usersmodel);
            }
            return UsersModel;
        }



        public List<ProductModel> Products()
        {
            var products = db.ProductRepository.GetProducts();
            List<ProductModel> ProductModel = new List<ProductModel>();

            ProductMapper mapper = new ProductMapper();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];

                var productModel = mapper.Map(product);

                productModel.No = i + 1;

                ProductModel.Add(productModel);
            }
            return ProductModel;
        }

        public List<CompaniesModel> Companies()
        {
            var products = db.CompaniesRepository.GetCompanies();
            List<CompaniesModel> ProductModel = new List<CompaniesModel>();

            CompaniesMapper mapper = new CompaniesMapper();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];

                var productModel = mapper.Map(product);

                productModel.No = i + 1;

                ProductModel.Add(productModel);
            }
            return ProductModel;
        }
        public List<BranchesModel> Branches()
        {
            var products = db.BranchesRepository.GetBranches();
            List<BranchesModel> ProductModel = new List<BranchesModel>();

            BranchesMapper mapper = new BranchesMapper();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];

                var productModel = mapper.Map(product);

                productModel.No = i + 1;

                ProductModel.Add(productModel);
            }
            return ProductModel;
        }

    }
}
