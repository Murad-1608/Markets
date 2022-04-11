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
        public ChangedPasswordCodeClick PasswordCodeClick => new ChangedPasswordCodeClick(this);
        public ChangedPassword_NewPasswordClick password_NewPasswordClick => new ChangedPassword_NewPasswordClick(this);

        public int Code { get; set; }
        public string NewPassword { get; set; }

    }
}
