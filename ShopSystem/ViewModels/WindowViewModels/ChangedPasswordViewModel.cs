using ShopSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels
{
    internal class ChangedPasswordViewModel
    {    
        public PasswordChanged password_NewPasswordClick => new PasswordChanged(this);

        public int Code { get; set; }
        public string NewPassword { get; set; }

    }
}
