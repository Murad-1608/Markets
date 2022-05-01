using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.UserCommand
{
    public class DeleteUserCommand : BaseCommand
    {
        private UserViewModel viewModel;
        public DeleteUserCommand(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            if (MessageBox.Show("Want to delete information?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int check = viewModel.db.UserRepository.Delete(viewModel.SelectedValue.Id);



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
