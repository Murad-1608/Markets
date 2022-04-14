using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
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

            ProductModel model = new ProductModel();
            IUnitOfWork unitOfWork = new SqlUnitOfWork();
            ProductMapper mapper = new ProductMapper();
            var entity = mapper.Map(viewModel.Model);
            int check = unitOfWork.ProductRepository.Insert(entity.Name, entity.Brand, entity.Price, entity.Count, entity.Type, entity.Color, entity.Comment);

            if (check == 1)
            {
                MessageBox.Show("Success");

            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
