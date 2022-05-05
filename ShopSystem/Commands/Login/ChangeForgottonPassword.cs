using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Security;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.WindowViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.Commands
{
    internal class ChangeForgottonPassword : BaseCommand
    {
        private readonly ForgotPasswordViewModel viewModel;
        public ChangeForgottonPassword(ForgotPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            PasswordBox NewPassword = parameter as PasswordBox;

            string Password = NewPassword.Password;

            var user = viewModel.db.UserRepository.Get(viewModel.Email);

            user.Password = Utils.PasswordHash(Password);

            int check = viewModel.db.UserRepository.Update(user);

            if (check == 1)
            {
                MessageBox.Show("Password changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);                            
            }
        }
    }
}
