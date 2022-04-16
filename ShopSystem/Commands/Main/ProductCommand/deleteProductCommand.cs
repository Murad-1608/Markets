using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataContext;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.ProductCommand
{
    internal class DeleteProductCommand : BaseCommand
    {
        public ProductViewModel viewModel;
        
        public DeleteProductCommand(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;

        }
        public override void Execute(object? parameter)
        {
            
            int check = viewModel.db.ProductRepository.Delete(viewModel.SelectedValue.Name,viewModel.SelectedValue.Brand);

            if (check == 1)
            {
                MessageBox.Show("Success");

                viewModel.AllProducts = viewModel.dataprovider.Products();
                viewModel.Initialize();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
