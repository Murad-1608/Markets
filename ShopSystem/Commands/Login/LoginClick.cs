using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.Security;
using ShopSystem.ViewModels;
using ShopSystem.Views;
using ShopSystem.Views.LoginViews;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopSystem.Commands
{
    internal class LoginClick : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public LoginClick(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            //try
            //{
            //    int check = viewModel.db.UserRepository.Get(viewModel.Email);

            //    string PasswordHash = Utils.PasswordHash(parameter.ToString());

            //    if (PasswordHash == UserInformation.Password)
            //    {
            //        MainViewModel mainViewModel = new MainViewModel(Global.DB);

            //        MainWindow main = new MainWindow();
            //        main.DataContext = mainViewModel;

            //        mainViewModel.CenterGrid = main.grdCenter;

            //        main.Show();

            //    }
            //    else
            //    {
            //        viewModel.LoginInCorrected = Visibility.Visible;
            //    }
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("No connection", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            //}

            int check = viewModel.db.UserRepository.Get(viewModel.Email);

            string PasswordHash = Utils.PasswordHash(parameter.ToString());

            if (PasswordHash == UserInformation.Password)
            {
                MainViewModel mainViewModel = new MainViewModel(Global.DB);

                MainWindow main = new MainWindow();
                main.DataContext = mainViewModel;

                mainViewModel.CenterGrid = main.grdCenter;

                main.Show();

            }
            else
            {
                viewModel.LoginInCorrected = Visibility.Visible;
            }


        }
    }
}
