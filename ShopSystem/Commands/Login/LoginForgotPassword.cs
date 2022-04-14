using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.Views.LoginViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ShopSystem.Commands
{
    internal class LoginForgotPassword : ICommand
    {
        private readonly LoginViewModel viewModel;

        public LoginForgotPassword(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            IUnitOfWork unitOfWork = new SqlUnitOfWork();            
            Random random = new Random();
            UserInformation.Code=random.Next(1111,9999);

            int check = unitOfWork.UserRepository.Get(viewModel.ForgotPasswordEmail);

            if (check == 1)
            {
                try
                {
                    MailAddress mailReveiver = new MailAddress("murad.yunus.2017@gmail.com", "Murad Yunus");
                    MailAddress mailSender = new MailAddress("projecttesting452@gmail.com", "Murad Holding");
                    MailMessage message = new MailMessage();

                    message.To.Add(mailReveiver);
                    message.From = mailSender;
                    message.Subject = "Rememberin the password";
                    message.Body = "Security code : " + UserInformation.Code;


                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("projecttesting452@gmail.com", "muradkenan");
                    smtp.EnableSsl = true;
                    smtp.Send(message);
                    MessageBox.Show("Your password has been sent to your E-mail address", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                    ChangedPassword changedPassword = new ChangedPassword();
                    changedPassword.ShowDialog();
                }

                catch (Exception)
                {

                    MessageBox.Show("You don't have internet");
                }
                

            }
            else
            {
                MessageBox.Show("Incorrected E-mail", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
