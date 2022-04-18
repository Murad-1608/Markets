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

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class UserViewModel : BaseViewModel
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public UserViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }


        public DeleteUserCommand DeleteUserCommand => new DeleteUserCommand(this);

        private List<UserModel> allusers;
        public List<UserModel> AllUsers
        {
            get { return allusers; }
            set
            {
                allusers = value;
                OnPropertyChanged(nameof(allusers));
            }
        }

        private UserModel selectedvalue;
        public UserModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private ObservableCollection<UserModel> getusers;
        public ObservableCollection<UserModel> GetUsers
        {
            get { return getusers; }
            set
            {
                getusers = value;
                OnPropertyChanged(nameof(GetUsers));
            }
        }


        #region SEARCH

        private string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                OnSearchUsers();
            }
        }

        public void Initialize()
        {
            GetUsers =new ObservableCollection<UserModel>(AllUsers);
        }

        public void OnSearchUsers()
        {
            var users = AllUsers.Where(x => x.Name != null && x.Name.ToLower().Contains(SearchText.ToLower()));

            GetUsers = new ObservableCollection<UserModel>(users);
        }

        #endregion

       
    }
}
