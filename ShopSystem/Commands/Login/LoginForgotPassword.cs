﻿using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataAccessLayer.Servers.SqlServer;
using ShopSystem.Entities;
using ShopSystem.Mappers;
using ShopSystem.Models;
using ShopSystem.ViewModels;
using ShopSystem.ViewModels.WindowViewModels;
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
            Random random = new Random();

            var confirmationCode = random.Next(1111, 9999).ToString();

            // TODO: Create confirmation code and store it in ConfirmationCodes table

            UserEntity user = viewModel.db.UserRepository.Get(viewModel.ForgotPasswordEmail);

            if (user!=null)
            {
                // TODO: move it to EmailSender class which implement from IEmailSender interface
             
                MailAddress mailReveiver = new MailAddress( viewModel.ForgotPasswordEmail," ");
                MailAddress mailSender = new MailAddress("projecttesting452@gmail.com", "Murad Kenan");
                MailMessage message = new MailMessage();

                message.To.Add(mailReveiver);
                message.From = mailSender;
                message.Subject = "Rememberin the password";
                message.Body = "Security code : "; // TODO: write confirmation code here

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("projecttesting452@gmail.com", "muradkenan");
                smtp.EnableSsl = true;
                smtp.Send(message);

                MessageBox.Show("Your password has been sent to your E-mail address", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

                ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel(viewModel.db, viewModel.ForgotPasswordEmail);

                ForgotPassword changedPassword = new ForgotPassword();

                changedPassword.DataContext = forgotPasswordViewModel;
                
                changedPassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrected E-mail", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
