using ShopSystem.Enums;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.UserCommand
{
    internal class OpenUserAddPanel : BaseControlCommand
    {
        private UserViewModel viewModel;
        public OpenUserAddPanel(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            number = 0;
            AddUser addUser = new AddUser();
            addUser.DataContext = viewModel;
            viewModel.AddPanelVisibility = Visibility.Visible;
            viewModel.EditPanelVisibility = Visibility.Collapsed;
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
