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

            Companies companies = new Companies();

            viewModel.CenterGrid.Children.Add(companies);

        }
    }
}
