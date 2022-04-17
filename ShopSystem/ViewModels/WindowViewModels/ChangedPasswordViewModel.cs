using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels
{
    internal class ChangedPasswordViewModel:BaseViewModel
    {
        public IUnitOfWork db;
        public ChangedPasswordViewModel(IUnitOfWork db):base(db)
        {
            this.db = db;
        }
        public PasswordChanged password_NewPasswordClick => new PasswordChanged(this);

        public int Code { get; set; }
        public string NewPassword { get; set; }

    }
}
