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
    internal class SaveUserCommand : BaseControlCommand
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
                        MessageBox.Show("There is a user in this email");
                        viewModel.CurrentValue = (UserModel)viewModel.SelectedValue.Clone();
                        break;
                    }
                }
            }      
                      

            else
            {
                try
                {
                    int check = viewModel.db.UserRepository.Update(entity);

                    if (check == 1)

                    {
                        MessageBox.Show("Success");

                        CloseAddandEditPanel closePanel = new CloseAddandEditPanel(viewModel);
                        closePanel.Execute("");

                        viewModel.AllValues = viewModel.dataprovider.Users();
                        viewModel.Initialize();
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }
                }
                catch (Exception)
                {
                    EditPanelAnimation();                   
                }             
                               
            }
        }

        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number += 1;

            if (number==6)
            {

            }

        }
    }
}
