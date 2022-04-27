using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopSystem.Views.Controls
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : UserControl
    {
        //ProductModel model = null;
        public Products()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel viewModel = (ProductViewModel)DataContext;
            AddProduct addproduct = new AddProduct();

            addproduct.DataContext = viewModel;
            addproduct.ShowDialog();


        }

        private void dgContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key==Key.Escape)
            {
                dgContent.UnselectAllCells();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditProduct editProduct = new EditProduct();
            ProductViewModel viewModel = (ProductViewModel)DataContext;
            editProduct.DataContext = viewModel;
            editProduct.ShowDialog();
        }
    }
}
