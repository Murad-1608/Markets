using ShopSystem.ViewModels.CompanentsViewModels;
using ShopSystem.Views.Controls.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace ShopSystem.Commands.Main.UserCommand
{
    public class OpenUserEditPanel : BaseCommand
    {
        public readonly UserViewModel viewModel;

        public OpenUserEditPanel(UserViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            
        }

        private void dtTicker(object sender, EventArgs e)
        {
         
            
        }
    }
}
