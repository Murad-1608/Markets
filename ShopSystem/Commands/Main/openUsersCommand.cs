using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.DataContext;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            UserMapper mapper = new UserMapper();

            Users users = new Users();

            viewModel.CenterGrid.Children.Add(users);
            UserViewModel userViewModel = new UserViewModel();

            users.DataContext= userViewModel;

            DataProvider dataprovider = new DataProvider();

           
            var GetUsers = dataprovider.Users();

            userViewModel.AllUsers = new ObservableCollection<UserModel>(GetUsers);

            userViewModel.Initialize();
        }
    }
}
