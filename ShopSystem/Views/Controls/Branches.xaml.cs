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
    /// Interaction logic for Branches.xaml
    /// </summary>
    public partial class Branches : UserControl
    {
        BranchesModel model = null;
        public Branches()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BranchesViewModel viewModel = (BranchesViewModel)DataContext;
            AddProduct addproduct = new AddProduct();

            addproduct.DataContext = viewModel;
            addproduct.ShowDialog();
        }
    }
}
