using ShopSystem.Enums;
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
    internal class CloseAddandEditPanel : BaseControlCommand
    {
        private UserViewModel viewModel;
        public CloseAddandEditPanel(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {

            if (viewModel.AddPanelVisibility == Visibility.Visible)
            {
                viewModel.Model = new UserModel();
            }
            else if (viewModel.EditPanelVisibility == Visibility.Visible)
            {
                viewModel.CurrentValue = (UserModel)viewModel.SelectedValue.Clone();
            }

            number = 190;
            viewModel.CurrentSituation = (byte)Situations.NORMAL;
            EditPanelAnimation();
        }

        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number -= 2;
            viewModel.RowHeight = new GridLength(number);

            if (number == 0)
            {
                timer.Stop();
            }
        }
    }
}
