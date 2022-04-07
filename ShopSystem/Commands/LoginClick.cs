using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.Security;
using ShopSystem.ViewModels;
using ShopSystem.Views;
using ShopSystem.Views.LoginViews;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopSystem.Commands
{
    internal class LoginClick : BaseCommand
    {
        private readonly LoginViewModel viewModel;
        public LoginClick(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            IUnitOfWork unitOfWork = new SqlUnitOfWork();


            int check = unitOfWork.UserRepository.Get(viewModel.Email);


            if (Utils.PasswordHash(viewModel.Password) == UserInformation.Password)
            {

                Login login = new Login();
                login.Hide();

                MainWindow main = new MainWindow();
                main.Show();


                //int deyer= unitOfWork.UserRepository.Insert(1, "Nicat", "Muradov", "Natiq", "nicat@mail.ru", Utils.PasswordHash("1234"), "0775140308");

            }
            else
            {
                MessageBox.Show("Email and password incorrected", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
