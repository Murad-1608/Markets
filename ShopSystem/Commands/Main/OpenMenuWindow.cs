using ShopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.Commands.Main
{
    internal class OpenMenuWindow : BaseControlCommand
    {
        private readonly MainViewModel viewModel;
        public OpenMenuWindow(MainViewModel viewModel)
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

            number = 0;
            viewModel.MainMenu = new GridLength(number);
            viewModel.OpenMenu = Visibility.Collapsed;
            EditPanelAnimation();
        }


        public override void Timer_Tick(object? sender, EventArgs e)
        {
            number += 1;
            viewModel.MainMenu = new GridLength(number);


            if (number == 150)
            {
                timer.Stop();                
                viewModel.CloseMenu = Visibility.Visible;
            }
        }


    }
}
