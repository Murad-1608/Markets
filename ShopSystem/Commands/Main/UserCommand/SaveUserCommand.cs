using ShopSystem.Mappers;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.UserCommand
{
    public class SaveUserCommand : BaseCommand
    {
        private readonly UserViewModel viewModel;
        public SaveUserCommand(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            UserMapper mapper = new UserMapper();
            var entity = mapper.Map(viewModel.CurrentValue);
            var Users = viewModel.dataprovider.Users();

            bool isCompatible = false;


            if (viewModel.CurrentValue.Email.ToLower()!=viewModel.SelectedValue.Email.ToLower())
            {
                foreach (var users in Users)
                {
                    if (users.Email != null && users.Email.ToLower().Contains(viewModel.CurrentValue.Email.ToLower()))
                    {
                        isCompatible = true;
                    }
                }
            }         




            if (isCompatible)
            {
                MessageBox.Show("There is a user in this email");
                viewModel.CurrentValue = viewModel.SelectedValue;
            }

            else
            {
                int check = viewModel.db.UserRepository.Update(entity);

                if (check == 1)

                {
                    MessageBox.Show("Success");
                    


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
