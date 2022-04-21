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
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        public AddUser()
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

            else if (txtPassword.Text == "")
                MessageBox.Show("Password is empty");

            else if (txtPhoneNumber.Text == "")
                MessageBox.Show("Phone number is empty");

            else if (ComboPosition.Text == "")
                MessageBox.Show("Position is empty");

            else
                viewModel.AddUserCommand.Execute("");
        }

        private void txtPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

     
    }
}
