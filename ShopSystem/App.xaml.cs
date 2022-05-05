using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Factories;
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
            var connectionstring = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            Login login = new Login();

            Global.DB = DBFactory.Create(connectionstring);

            LoginViewModel viewModel = new LoginViewModel(Global.DB);

            login.DataContext = viewModel;
            login.Show();
        }
    }
}
