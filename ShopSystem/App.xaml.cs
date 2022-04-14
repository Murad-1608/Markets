using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.ViewModels;
using ShopSystem.Views;
using ShopSystem.Views.LoginViews;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            LoginViewModel viewModel = new LoginViewModel();

            Login login = new Login();
            login.DataContext = viewModel;
            login.Show();

            //MainWindow main = new MainWindow();
            //main.Show();

            //ChangedPassword changedPassword = new ChangedPassword();
            //changedPassword.Show();


            //AddProduct addProduct = new AddProduct();
            //addProduct.Show();

        }
    }
}
