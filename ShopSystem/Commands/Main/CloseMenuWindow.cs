using ShopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main
{
    internal class CloseMenuWindow : BaseControlCommand
    {
        private readonly MainViewModel viewModel;
        public CloseMenuWindow(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void EditPanelAnimation()
        {
            timer.Interval = TimeSpan.FromMilliseconds(0.2);
            timer.Tick += Timer_Tick; ;
            timer.Start();
        }

        public override void Execute(object? parameter)
        {

            number = 150;
            viewModel.MainMenu = new GridLength(number);
            viewModel.CloseMenu = Visibility.Collapsed;
            EditPanelAnimation();
        }

        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number -= 1;
            viewModel.MainMenu = new GridLength(number);

            if (number == 0)
            {
                timer.Stop();
              
                viewModel.OpenMenu = Visibility.Visible;
            }
        }
    }
}
