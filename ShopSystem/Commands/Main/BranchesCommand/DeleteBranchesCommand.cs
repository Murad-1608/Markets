using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.BranchesCommand
{
    internal class DeleteBranchesCommand : BaseCommand
    {
        public BranchesViewModel viewModel;

        public DeleteBranchesCommand(BranchesViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public override void Execute(object? parameter)
        {

            int check = viewModel.db.ProductRepository.Delete(viewModel.SelectedValue.Id);



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
    }
}
