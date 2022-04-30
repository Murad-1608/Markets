using ShopSystem.ViewModels.CompanentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace ShopSystem.Commands
{
    public abstract class BaseCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public abstract void Execute(object? parameter);

        int number = 0;
        public void EditPanelAnimation()
        {
            //DoubleAnimation da = new DoubleAnimation();
            //CircleEase ease = new CircleEase() { EasingMode = EasingMode.EaseOut };

            //da.From = 0;
            //da.To = 50;
            //da.Duration = TimeSpan.FromSeconds(3000);
            //da.EasingFunction = ease;


            DispatcherTimer timer = new DispatcherTimer();
            number = 0;
            timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Timer_Tick; ;
            timer.Start();

        }

        public abstract void Timer_Tick(object? sender, EventArgs e);
       
    }
}
