﻿using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.Commands.Main
{
    internal class ChangePassword : BaseCommand
    {
        private ProductViewModel viewModel;
        public ChangePassword(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            PasswordBox NewPassword = parameter as PasswordBox;

            string Password = NewPassword.Password;



            int check = viewModel.db.UserRepository.Update(UserInformation.Email, Password);

            if (check == 1)
            {
                MessageBox.Show("Password changed", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
