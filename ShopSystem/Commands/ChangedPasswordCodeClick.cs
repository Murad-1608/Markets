using ShopSystem.Models;
using ShopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands
{
    internal class ChangedPasswordCodeClick : BaseCommand
    {
        private readonly ChangedPasswordViewModel viewModel;
        public ChangedPasswordCodeClick(ChangedPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
           
        }
    }
}
