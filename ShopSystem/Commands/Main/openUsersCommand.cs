using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.DataContext;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls;
using ShopSystem.Views.Controls.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.Commands.Main
{
    internal class OpenUsersCommand : BaseCommand
    {
        private readonly MainViewModel viewModel;
        public OpenUsersCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            viewModel.CenterGrid.Children.Clear();


            Users users = new Users();

            viewModel.CenterGrid.Children.Add(users);
            UserViewModel userViewModel = new UserViewModel(Global.DB);

            users.DataContext = userViewModel;

            DataProvider dataprovider = new DataProvider(Global.DB);
            Users User = new Users();

            //userViewModel.RowHeight = new GridLength();


            var GetUsers = dataprovider.Users();

            userViewModel.AllValues = GetUsers;

            userViewModel.Initialize();
        }
    }
}
