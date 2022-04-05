using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.Views;
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
            EmployeeMapper mapper = new EmployeeMapper();
            
            var Email=mapper.Map(viewModel.Email);

            int check = unitOfWork.EmployeeRepository.Get(Email);

            if (check==1)
            {
                MainWindow main = new MainWindow();
                main.Show();
            }
            else
            {
                MessageBox.Show("Email and password incorrected","Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
