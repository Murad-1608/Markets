using ShopSystem.Security;
using ShopSystem.ViewModels;
using System.Windows;

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

            var user = viewModel.db.UserRepository.Get(Global.User.Email);

            if (Password == user.Password)
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
