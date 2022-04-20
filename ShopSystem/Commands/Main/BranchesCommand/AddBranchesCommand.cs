using ShopSystem.Mappers;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.BranchesCommand
{
    internal class AddBranchesCommand:BaseCommand
    {
        private readonly BranchesViewModel viewModel;
        public AddBranchesCommand(BranchesViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            BranchesMapper mapper = new BranchesMapper();
            var entity = mapper.Map(viewModel.Model);
            int check = viewModel.db.BranchesRepository.Insert(entity);

            if (check == 1)

            {
                MessageBox.Show("Success");
                viewModel.Model = null;


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
