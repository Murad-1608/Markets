using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        public IUnitOfWork db = null;
        public Window Login;
        public LoginViewModel(Window Login, IUnitOfWork db) : base(db)
        {
            this.db = db;
        }
        public LoginClick LoginClick => new LoginClick(this);
        public LoginForgotPassword ForgotPasswordClick => new LoginForgotPassword(this);

        public string Email { get; set; } = "murad.yunus.2017@mail.ru";
        public string Password { get; set; }
        public string ForgotPasswordEmail { get; set; }

        public UserModel Register { get; set; } = new UserModel();

        private Visibility loginInCorrected=Visibility.Collapsed;
        public Visibility LoginInCorrected
        {
            get
            {
                return loginInCorrected;
            }
            set
            {
                loginInCorrected = value;
                OnPropertyChanged(nameof(LoginInCorrected));
            }
      }

    }
}
