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
using System.Windows.Threading;

namespace ShopSystem.Views.Controls.UserControls
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel viewModel = (UserViewModel)DataContext;
            AddUser addUser = new AddUser();
            addUser.DataContext = viewModel;
            addUser.ShowDialog();

        }

  
        private void dgContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                dgContent.UnselectAllCells();
            }
        }

        DispatcherTimer dt = new DispatcherTimer();
        DispatcherTimer dtClose = new DispatcherTimer();
        int number = 0;
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            StackEdit.IsEnabled = true;
            Center.IsEnabled = false;
            SearchPanel.IsEnabled = false;

            number = 0;
            dt.Interval = TimeSpan.FromSeconds(0.005);
            dt.Tick += dtTicker;
            dt.Start();

        }


        private void dtTicker(object sender, EventArgs e)
        {
            number += 10;
            EditPanel.Height = new GridLength(number);

            UserViewModel viewModel = (UserViewModel)DataContext;
            EditUser editUser = new EditUser();
            editUser.DataContext = viewModel;

            if (number == 190)
            {
                dt.Stop();
            }

        }

     
        private void dtTickerClose(object sender, EventArgs e)
        {

            number -= 5;
            EditPanel.Height = new GridLength(number);



            if (number == 0)
            {
                dtClose.Stop();

                StackEdit.IsEnabled = false;
                Center.IsEnabled = true;
                SearchPanel.IsEnabled = true;
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            
            dtClose.Interval = TimeSpan.FromSeconds(0.005);
            dtClose.Tick += dtTickerClose;
            dtClose.Start();
        }
    }
}
