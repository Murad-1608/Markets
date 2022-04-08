using ShopSystem.Commands;
using ShopSystem.Models;
using ShopSystem.ViewModels;
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
    public partial class ChangedPassword : Window
    {
        ChangedPasswordViewModel viewModel = new ChangedPasswordViewModel();
        public ChangedPassword()
        {
            InitializeComponent();

            
            DataContext = viewModel;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel = (ChangedPasswordViewModel)DataContext;
            if (UserInformation.Code == viewModel.Code)
            {
                WriteCode.Visibility = Visibility.Collapsed;
                UpdateCode.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            

            if (txt_NewPassword.Password==txt_ConfirmPassword.Password)
            {
                ChangedPassword_NewPasswordClick click = new ChangedPassword_NewPasswordClick();
                click.Execute(txt_NewPassword);
            }
        }
    }
}
