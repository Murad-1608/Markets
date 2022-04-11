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
    internal class UserViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<UserModel> allusers;
        public ObservableCollection<UserModel> AllUsers
        {
            get { return allusers; }
            set
            {
                allusers = value;
                OnProperyChanged(nameof(allusers));
            }
        }


        private ObservableCollection<UserModel> getusers;
        public ObservableCollection<UserModel> GetUsers
        {
            get { return getusers; }
            set
            {
                getusers = value;
                OnProperyChanged(nameof(GetUsers));
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
                OnProperyChanged(nameof(SearchText));
                OnSearchUsers();
            }
        }

        public void Initialize()
        {
            GetUsers = AllUsers;
        }

        public void OnSearchUsers()
        {
            var users = AllUsers.Where(x => x.Name != null && x.Name.ToLower().Contains(SearchText.ToLower()));

            GetUsers = new ObservableCollection<UserModel>(users);
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnProperyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
