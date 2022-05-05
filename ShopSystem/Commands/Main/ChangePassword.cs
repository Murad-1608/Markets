using ShopSystem.Models;
using ShopSystem.Security;
using ShopSystem.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.Commands.Main
{
    internal class ChangePassword : BaseCommand
    {
        private MainViewModel viewModel;
        public ChangePassword(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            PasswordBox NewPassword = parameter as PasswordBox;

            string Password = NewPassword.Password;

            var user = viewModel.db.UserRepository.Get(Global.User.Email);

            user.Password = Utils.PasswordHash(Password);

            int check = viewModel.db.UserRepository.Update(user);

            if (check == 1)
            {
                MessageBox.Show("Password changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}