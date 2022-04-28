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
    /// Interaction logic for Companies.xaml
    /// </summary>
    public partial class Companies : UserControl
    {
        public Companies()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            CompanyViewModel viewModel = (CompanyViewModel)DataContext;
             AddCompany addcompany = new AddCompany();

            addcompany.DataContext = viewModel;
            addcompany.ShowDialog();
        }
    }
}
