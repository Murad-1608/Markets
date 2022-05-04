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
    internal class MainViewModel : BaseViewModel
    {
        public IUnitOfWork db = null;
        public MainViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
        }







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
        public OpenProductsCommand openProductsCommand => new OpenProductsCommand(this);
        public ChangePassword changePassword => new ChangePassword(this);
        public OpenDashboard OpenDashboard => new OpenDashboard(this);






        #region Values
        public Grid CenterGrid { get; set; }


        private string userPosition = "Murad";
        public string UserPosition
        {
            get
            {
                return userPosition;
            }
            set
            {
                userPosition = value;
                OnPropertyChanged(nameof(UserPosition));
            }


        }

        public string UserFullName { get; set; }

        private int productCount;
        public int ProductCount
        {
            get
            {
                return productCount;
            }
            set
            {
                productCount = value;
                OnPropertyChanged(nameof(ProductCount));
            }

        }

        private int branchCount;
        public int BranchCount
        {
            get
            {
                return branchCount;
            }
            set
            {
                branchCount = value;
                OnPropertyChanged(nameof(BranchCount));
            }

        }

        private int companyCount;
        public int CompanyCount
        {
            get
            {
                return companyCount;
            }
            set
            {
                companyCount = value;
                OnPropertyChanged(nameof(CompanyCount));
            }

        }

        private int userCount;
        public int UserCount
        {
            get
            {
                return userCount;
            }
            set
            {
                userCount = value;
                OnPropertyChanged(nameof(UserCount));
            }

        }


        #endregion



    }
}
