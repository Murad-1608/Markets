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

            

            if (MessageBox.Show("Want to delete information?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int check = viewModel.db.ProductRepository.Delete(viewModel.SelectedValue.Id);



                if (check == 1)
                {
                    MessageBox.Show("Success");

                    viewModel.AllValues = viewModel.dataprovider.Products();
                    viewModel.Initialize();
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }        


            
        }
    }
}
