using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ShopSystem.Views.MainViews
{
    /// <summary>
    /// Interaction logic for EditUser.xaml
    /// </summary>
    public partial class EditUser : Window
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserViewModel viewModel = (UserViewModel)DataContext;

            if (txtName.Text == "")
                MessageBox.Show("Name is empty");

            else if (txtSurname.Text == "")
                MessageBox.Show("Surname is empty");

            else if (txtFatherName.Text == "")
                MessageBox.Show("Father name is empty");

            else if (txtEmail.Text == "")
                MessageBox.Show("Email is empty");           

            else if (txtPhoneNumber.Text == "")
                MessageBox.Show("Phone number is empty");

            else if (ComboPosition.Text == "")
                MessageBox.Show("Position is empty");

            else
                viewModel.SaveUserCommand.Execute("");
        }

      

        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            UserViewModel viewModel = (UserViewModel)DataContext;
            viewModel.CurrentValue = new Models.UserModel();
        }
    }
}

