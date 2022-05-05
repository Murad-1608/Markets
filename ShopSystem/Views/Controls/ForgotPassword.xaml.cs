using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.WindowViewModels;
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

namespace ShopSystem.Views.LoginViews
{
    /// <summary>
    /// Interaction logic for ChangedPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Window
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void enterClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ForgotPasswordViewModel)DataContext;

            // TODO: Get actual confirmation code from Confirmation Codes table by email
            string actualCode = string.Empty; // DB.ConfirmationCodesRepository.Get(email);

            if (actualCode == viewModel.Code)
            {
                // TODO: move this click event to command and add visibility properties to viewmodel
                //WriteCode.Visibility = Visibility.Collapsed;
                //UpdateCode.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Wrong code");
            }
        }

        private void updateBtnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (ForgotPasswordViewModel)DataContext;

            if (txt_NewPassword.Password == txt_ConfirmPassword.Password)
            {
                viewModel.NewPasswordClick.Execute(txt_NewPassword);
                this.Close();
            }
            else
            {
                MessageBox.Show("Check again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
