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
    internal class OpenBranchesCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;

        public OpenBranchesCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.CenterGrid.Children.Clear();

            Branches products = new Branches();

            viewModel.CenterGrid.Children.Add(products);

            BranchesViewModel productViewModel = new BranchesViewModel(Global.DB);

            products.DataContext = productViewModel;

            DataProvider data = new DataProvider();

            var GetBranches = data.Branches();

            productViewModel.AllBranches = data.Branches();

            productViewModel.Initialize();


        }
    }
}
