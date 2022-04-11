using ShopSystem.Commands.Main;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShopSystem.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UserModel> allusers;

        public ObservableCollection<UserModel> AllGetUsers
        {
            get
            {
                return allusers;
            }
            set
            {
                allusers = value;
                OnPropertyChanged(nameof(AllGetUsers));
            }
        }



        private ObservableCollection<UserModel> users;

        public ObservableCollection<UserModel> GetUsers
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged(nameof(GetUsers));
            }
        }



        public OpenCompaniesCommand openCompaniesCommand => new OpenCompaniesCommand(this);
        public OpenBranchesCommand openBranhesCommand => new OpenBranchesCommand(this);
        public OpenUsersCommand openUsersCommand => new OpenUsersCommand(this);

     



        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnSearchUsers();
                OnPropertyChanged(nameof(SearchText));
            }
        }


        public Grid CenterGrid { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnSearchUsers()
        {
            var users = AllGetUsers.Where(x => x.Name != null && x.Name.ToLower().Contains(SearchText.ToLower()));

            GetUsers = new ObservableCollection<UserModel>(users);
        }
    }
}
