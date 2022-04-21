using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.UserCommand
{
    internal class AddUserCommand : BaseCommand
    {
        private readonly UserViewModel viewModel;
        public AddUserCommand(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            UserMapper mapper = new UserMapper();
            var entity = mapper.Map(viewModel.Model);
            var Users= viewModel.dataprovider.Users();

            bool isCompatible = false;
            foreach (var users in Users)
            {
                if (users.Email!=null&&users.Email.ToLower().Contains(viewModel.Model.Email.ToLower()))
                {
                    isCompatible = true;
                }
            }


            if (isCompatible)
            {
                MessageBox.Show("There is a user in this email");
            }

            else
            {
                int check = viewModel.db.UserRepository.Insert(entity);

                if (check == 1)

                {
                    MessageBox.Show("Success");
                    viewModel.Model = new UserModel();


                    viewModel.AllUsers = viewModel.dataprovider.Users();
                    viewModel.Initialize();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
           
        }
    }
}
