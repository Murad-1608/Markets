using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopSystem.Views.MainViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainViewModel main = new MainViewModel(Global.DB);

            DataContext = main;

            txt_UserFullName.Text = $"{Global.User.Name} {Global.User.Surname}";
            txt_Position.Text = Global.User.Position;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;
            ChangePasswordMain changePasswordMain = new ChangePasswordMain();
            changePasswordMain.DataContext = viewModel;
            changePasswordMain.ShowDialog();
        }
    }
}
