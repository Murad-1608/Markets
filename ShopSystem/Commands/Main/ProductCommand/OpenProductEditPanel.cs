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
    internal class OpenProductEditPanel : BaseControlCommand
    {
        private ProductViewModel viewModel;
        public OpenProductEditPanel(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            number = 0;
            EditProduct editProduct = new EditProduct();
            editProduct.DataContext = viewModel;
            viewModel.AddPanelVisibility = Visibility.Collapsed;
            viewModel.EditPanelVisibility = Visibility.Visible;
            viewModel.CurrentSituation = (byte)Situations.ADDandEDIT;
            EditPanelAnimation();
        }

        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number += 2;
            viewModel.RowHeight = new GridLength(number);


            if (number == 190)
            {
                timer.Stop();
            }
        }
    }
}
