using ShopSystem.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace ShopSystem.Views.LoginViews
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void forgetPasswordClick(object sender, MouseButtonEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Visible;
            Panel_Login.Visibility = Visibility.Hidden;
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Hidden;
            Panel_Login.Visibility = Visibility.Visible;
        }

        private void loginClick(object sender, RoutedEventArgs e)
        {
            LoginViewModel viewModel = (LoginViewModel)DataContext;

            if (txtPassword.IsVisible)
            {
                viewModel.LoginClick.Execute(txtPassword.Text);
            }

            else if (PswPassword.IsVisible)
            {
                viewModel.LoginClick.Execute(PswPassword.Password);
            }
        }

        private void check_Show_Checked(object sender, RoutedEventArgs e)
        {
            txtPassword.Text = PswPassword.Password;

            PswPassword.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
        }

        private void check_Show_Unchecked(object sender, RoutedEventArgs e)
        {
            PswPassword.Password = txtPassword.Text;

            txtPassword.Visibility = Visibility.Hidden;
            PswPassword.Visibility = Visibility.Visible;
        }
    }
}
