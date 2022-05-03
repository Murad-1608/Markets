using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.CompanyCont;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.CompanyCommand
{
    internal class EditCompanyCommand
    {
        private CompanyViewModel viewModel;
        public EditCompanyCommand(CompanyViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        //public override void Execute(object? parameter)
        //{

        //    //EditCompany addPanel = new EditCompany();
        //    //addPanel.DataContext = viewModel;
        //    //viewModel.AddPanelVisibility = Visibility.Visible;
        //    //viewModel.EditPanelVisibility = Visibility.Collapsed;
        //    //viewModel.CurrentSituation = (byte)Situations.ADDandEDIT;
        //    //EditPanelAnimation();
        //}
    }
}
