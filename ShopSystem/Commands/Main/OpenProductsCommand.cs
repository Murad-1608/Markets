using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.DataContext;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls;
using ShopSystem.Views.Controls.ProductControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands.Main
{
    internal class OpenProductsCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;
        public OpenProductsCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }



        public override void Execute(object? parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            Products products = new Products();

            viewModel.CenterGrid.Children.Add(products);

            ProductViewModel productViewModel = new ProductViewModel(Global.DB);

            products.DataContext = productViewModel;

            DataProvider data = new DataProvider();

            var GetProducts = data.Products();

            productViewModel.AllValues = data.Products();
            productViewModel.Branches=data.Branches();
            productViewModel.Initialize();
        }
    }
}
