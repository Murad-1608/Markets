using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public IUnitOfWork db = null;
        public LoginViewModel(IUnitOfWork db):base(db)
        {
            this.db = db;
        }
        public LoginClick LoginClick => new LoginClick(this);
        public LoginForgotPassword ForgotPasswordClick => new LoginForgotPassword(this);

        public string Email { get; set; } = "murad.yunus.2017@mail.ru";
        public string Password { get; set; }
        public string ForgotPasswordEmail { get; set; }



        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
