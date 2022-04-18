using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Models;
using ShopSystem.Security;
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
    /// Interaction logic for ChangePasswordMain.xaml
    /// </summary>
    public partial class ChangePasswordMain : Window
    {

        public ChangePasswordMain()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainViewModel viewModel = (MainViewModel)DataContext;


            string Password = Utils.PasswordHash(txtPassword.Password);

            if (Password == UserInformation.Password)
            {
                if (txtNewPassword.Password != "" && (txtNewPassword.Password == txtConfirmPassword.Password))
                {
                    viewModel.changePassword.Execute(txtNewPassword);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Check that the passwords are the same or empty");
                }
            }
            else
            {
                MessageBox.Show("The password is incorrect");
            }
        }
    }
}
