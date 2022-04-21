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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Visible;
            Panel_Login.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Hidden;
            Panel_Login.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please fill in the textboxes");
            }
            else if (txtPassword.Text == "" && PswPassword.Password == "")
            {
                MessageBox.Show("Please fill in the textboxes");
            }
            else
            {
                LoginViewModel viewModel = (LoginViewModel)DataContext;

                if (txtPassword.IsVisible == true)
                {
                    viewModel.LoginClick.Execute(txtPassword.Text);
                }

                else if (PswPassword.IsVisible == true)
                {
                    viewModel.LoginClick.Execute(PswPassword.Password);
                }
            }
        }

        private void check_Show_Checked(object sender, RoutedEventArgs e)
        {

            txtPassword.Text = PswPassword.Password;

            PswPassword.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Visible;
        }

        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void check_Show_Unchecked(object sender, RoutedEventArgs e)
        {
            PswPassword.Password = txtPassword.Text;

            txtPassword.Visibility = Visibility.Hidden;
            PswPassword.Visibility = Visibility.Visible;
        }
    }
}
