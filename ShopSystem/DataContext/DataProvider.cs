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
    public class DataProvider
    {
        private readonly IUnitOfWork db;
        
        public DataProvider(IUnitOfWork db)
        {
            this.db = db;
        }

        public List<UserModel> Users()
        {
            var users = db.UserRepository.GetUsers();

            List<UserModel> usersModels = new List<UserModel>();

            UserMapper mapper = new UserMapper();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];

                var usersmodel = mapper.Map(user);

                usersmodel.No = i + 1;

                usersModels.Add(usersmodel);
            }

            return usersModels;
        }

        public List<ProductModel> Products()
        {
            var products = db.ProductRepository.GetProducts();

            List<ProductModel> productModels = new List<ProductModel>();

            ProductMapper mapper = new ProductMapper();

            for (int i = 0; i < products.Count; i++)
            {
                var product = products[i];

                var productModel = mapper.Map(product);

                productModel.No = i + 1;

                productModels.Add(productModel);
            }
            
            return productModels;
        }

        public List<CompanyModel> Companies()
        {
            var companies = db.CompaniesRepository.GetCompanies();

            List<CompanyModel> companiesModel = new List<CompanyModel>();

            CompaniesMapper mapper = new CompaniesMapper();

            for (int i = 0; i < companies.Count; i++)
            {
                var product = companies[i];

                var productModel = mapper.Map(product);

                productModel.No = i + 1;

                companiesModel.Add(productModel);
            }

            return companiesModel;
        }

        public List<BranchModel> Branches()
        {
            var branches = db.BranchesRepository.GetBranches();
            List<BranchModel> branchModels = new List<BranchModel>();

            BranchMapper mapper = new BranchMapper();

            for (int i = 0; i < branches.Count; i++)
            {
                var branch = branches[i];

                var productModel = mapper.Map(branch);

                productModel.No = i + 1;

                branchModels.Add(productModel);
            }

            return branchModels;
        }

    }
}
