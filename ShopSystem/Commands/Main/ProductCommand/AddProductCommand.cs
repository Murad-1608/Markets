using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.DataContext;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main.ProductCommand
{
    internal class AddProductCommand : BaseCommand
    {
        private readonly ProductViewModel viewModel;
        public AddProductCommand(ProductViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            ProductMapper mapper = new ProductMapper();
            var entity = mapper.Map(viewModel.Model);
            int check = viewModel.db.ProductRepository.Insert(entity);

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
