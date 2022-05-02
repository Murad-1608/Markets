using ShopSystem.Enums;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.ProductControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.ProductCommand
{
    internal class OpenProductAddPanel:BaseControlCommand
    {
        private ProductViewModel viewModel;
        public OpenProductAddPanel(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            number = 0;
            AddProduct addPanel = new AddProduct();
            addPanel.DataContext = viewModel;
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
