﻿using ShopSystem.ViewModels;
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
using System.Windows.Shapes;

namespace ShopSystem.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();            
        }
      
        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Visible;
            Panel_Login.Visibility = Visibility.Hidden;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Panel_ForgotPassword.Visibility = Visibility.Hidden;
            Panel_Login.Visibility = Visibility.Visible;
        }
    }
}
