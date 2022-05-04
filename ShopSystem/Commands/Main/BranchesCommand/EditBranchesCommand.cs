using ShopSystem.Mappers;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.BranchesCommand
{
    internal class EditBranchesCommand : BaseCommand
    {
        private BranchesViewModel viewModel;
        public EditBranchesCommand(BranchesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

      
        public override void Execute(object? parameter)
        {
            BranchesMapper mapper = new BranchesMapper();
            var entity = mapper.Map(viewModel.CurrentValue);


            int check = viewModel.db.BranchesRepository.Update(entity);

            if (check == 1)

            {
                MessageBox.Show("Success");



                viewModel.AllBranches = viewModel.dataprovider.Branches();
                viewModel.Initialize();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        //public override void Execute(object? parameter)
        //{

        //    EditBranches addPanel = new EditBranches();
        //    addPanel.DataContext = viewModel;
        //    viewModel.AddPanelVisibility = Visibility.Visible;
        //    viewModel.EditPanelVisibility = Visibility.Collapsed;
        //    viewModel.CurrentSituation = (byte)Situations.ADDandEDIT;
        //    EditPanelAnimation();
        //}
    }
}
