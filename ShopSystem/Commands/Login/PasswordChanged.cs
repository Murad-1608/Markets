using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.Views.LoginViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.Commands
{
    internal class PasswordChanged : BaseCommand
    {
        private readonly ChangedPasswordViewModel viewModel;
        public PasswordChanged(ChangedPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            PasswordBox NewPassword = parameter as PasswordBox;

            string Password = NewPassword.Password;

            IUnitOfWork unitOfWork = new SqlUnitOfWork();

            int check = unitOfWork.UserRepository.Update(UserInformation.Email, Password);

            if (check == 1)
            {
                MessageBox.Show("Password changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);                            
            }
        }
    }
}
