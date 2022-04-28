using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.CompanyCommand
{
    internal class DeleteCompanyCommand:BaseCommand
    {
        public CompanyViewModel viewModel;

        public DeleteCompanyCommand(CompanyViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public override void Execute(object? parameter)
        {

            int check = viewModel.db.CompaniesRepository.Delete(viewModel.SelectedValue.Id);



            if (check == 1)
            {
                MessageBox.Show("Success");

                viewModel.AllCompanies = viewModel.dataprovider.Companies();
                viewModel.Initialize();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
