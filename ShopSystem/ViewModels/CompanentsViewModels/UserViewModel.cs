using ShopSystem.Commands.Main.UserCommand;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataContext;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class UserViewModel : BaseControlViewModel<UserModel>
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public UserControl UserPanel;
        public UserViewModel(UserControl UserPanel, IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }



        #region Commands
        public AddUserCommand AddUserCommand => new AddUserCommand(this);
        public DeleteUserCommand DeleteUserCommand => new DeleteUserCommand(this);
        public SaveUserCommand SaveUserCommand => new SaveUserCommand(this);
        public OpenUserEditPanel OpenEditPanel=>new OpenUserEditPanel(this);
        public OpenUserAddPanel OpenAddPanel =>new OpenUserAddPanel(this);
        public CloseAddandEditPanel CloseAddandEditPanel =>new CloseAddandEditPanel(this);
       
        #endregion


        #region Values
        public override string Header => "Users";              

        #endregion



        #region SEARCH

        public void Initialize()
        {
            GetValues = new ObservableCollection<UserModel>(AllValues);
        }



        public override void OnSearch()
        {
            var users = AllValues.Where(x => Filter(x.Name) ||
                                            Filter(x.Email) ||
                                            Filter(x.Position) ||
                                            Filter(x.Surname) ||
                                            Filter(x.FatherName));

            GetValues = new ObservableCollection<UserModel>(users);
        }

        #endregion


    }
}
