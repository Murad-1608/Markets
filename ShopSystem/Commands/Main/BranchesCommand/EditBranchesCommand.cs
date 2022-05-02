﻿using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands.Main.BranchesCommand
{
    public class EditBranchesCommand : BaseCommand
    {
        private BranchesViewModel viewModel;
        public EditBranchesCommand(BranchesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            
            EditBranches addPanel = new EditBranches();
            addPanel.DataContext = viewModel;
            viewModel.AddPanelVisibility = Visibility.Visible;
            viewModel.EditPanelVisibility = Visibility.Collapsed;
            viewModel.CurrentSituation = (byte)Situations.ADDandEDIT;
            EditPanelAnimation();
        }
    }
}
