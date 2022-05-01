using ShopSystem.Mappers;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.ProductCommand
{
    internal class SaveProductCommand : BaseCommand
    {
        private readonly ProductViewModel viewModel;

        public SaveProductCommand(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {



            ProductMapper mapper=new ProductMapper();
            var entity = mapper.Map(viewModel.CurrentValue);
            

            int check = viewModel.db.ProductRepository.Update(entity,viewModel.SelectedItem.Id);

            if (check == 1)

            {
                MessageBox.Show("Success");

                CloseAddandEditPanel closePanel = new CloseAddandEditPanel(viewModel);

                closePanel.Execute("");

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
