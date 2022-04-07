using ShopSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Commands
{
    internal class ChangedPassword_NewPasswordClick : BaseCommand
    {
        private readonly ChangedPasswordViewModel viewModel;
        public ChangedPassword_NewPasswordClick(ChangedPasswordViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public override void Execute(object? parameter)
        {
            string name=parameter.ToString();
        }
    }
}
