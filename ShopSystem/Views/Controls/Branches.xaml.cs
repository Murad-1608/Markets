using ShopSystem.Models;
using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.BranchesCont;
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
        public Branches()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            BranchesViewModel viewModel = (BranchesViewModel)DataContext;
            AddBranch addbranch = new AddBranch();

            addbranch.DataContext = viewModel;
            addbranch.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BranchesViewModel viewModel = (BranchesViewModel)DataContext;
            EditBranches edit = new EditBranches();
            edit.DataContext = viewModel;
            edit.ShowDialog();
        }
    }
}
