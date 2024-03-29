﻿using ShopSystem.ViewModels.CompanentsViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopSystem.Views.Controls.ProductControls
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : UserControl
    {
        public EditProduct()
        {
            InitializeComponent();
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9\.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ProductViewModel viewModel = (ProductViewModel)DataContext;

            if (txtName.Text == "")
                MessageBox.Show("Name is empty");

            else if (txtBrand.Text == "")
                MessageBox.Show("Brand is empty");

            else if (txtPrice.Text == "")
                MessageBox.Show("Price name is empty");

            else if (txtCount.Text == "")
                MessageBox.Show("Count is empty");

            else if (txtType.Text == "")
                MessageBox.Show("Type is empty");

            else if (txtColor.Text == "")
                MessageBox.Show("Color is empty");

            else if (txtComment.Text == "")
                MessageBox.Show("Comment is empty");

            else if (ComboBranch.Text == "")
                MessageBox.Show("Branch is empty");

            else
                viewModel.SaveProductCommand.Execute("");
        }
    }
}
