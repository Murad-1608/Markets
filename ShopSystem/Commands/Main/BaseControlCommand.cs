﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ShopSystem.Commands.Main
{
    public abstract class BaseControlCommand : BaseCommand
    {
        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public int number { get; set; } = 0;
        
        public DispatcherTimer timer = new DispatcherTimer();
     
        public virtual void EditPanelAnimation()
        {
            timer.Interval = TimeSpan.FromMilliseconds(0.5);
            timer.Tick += Timer_Tick; ;
            timer.Start();
        }  
       
        public abstract void Timer_Tick(object? sender, EventArgs e);
    }
}
