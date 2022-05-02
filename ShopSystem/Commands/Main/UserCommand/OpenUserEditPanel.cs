using ShopSystem.Enums;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ShopSystem.Commands.Main.UserCommand
{
    internal class OpenUserEditPanel : BaseControlCommand
    {
        public readonly UserViewModel viewModel;

        public OpenUserEditPanel(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            number = 0;
            EditUser editUser = new EditUser();
            editUser.DataContext = viewModel;
            viewModel.AddPanelVisibility = Visibility.Collapsed;
            viewModel.EditPanelVisibility = Visibility.Visible;
            viewModel.CurrentSituation = (byte)Situations.ADDandEDIT;
            EditPanelAnimation();
        }


        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number += 1;
            viewModel.RowHeight = new GridLength(number);


            if (number == 190)
            {
                timer.Stop();
            }
        }

    }
}
