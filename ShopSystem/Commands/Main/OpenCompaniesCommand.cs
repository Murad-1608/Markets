using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.DataContext;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands.Main
{
    internal class OpenCompaniesCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;
        public OpenCompaniesCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            Companies products = new Companies();

            viewModel.CenterGrid.Children.Add(products);

            CompanyViewModel productViewModel = new CompanyViewModel(new SqlUnitOfWork());

            products.DataContext = productViewModel;

            DataProvider data = new DataProvider();

            var GetCompanies = data.Companies();

            productViewModel.AllCompanies = data.Companies();

            productViewModel.Initialize();

        }
    }
}
