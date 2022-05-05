using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels.WindowViewModels
{
    internal class ForgotPasswordViewModel : BaseViewModel
    {
        public ForgotPasswordViewModel(IUnitOfWork db, string email) : base(db)
        {
            Email = email;
        }

        public string Email { get; }

        public string Code { get; set; }
        public string NewPassword { get; set; }

        public ChangeForgottonPassword NewPasswordClick => new ChangeForgottonPassword(this);
    }
}
