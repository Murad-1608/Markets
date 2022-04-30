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
    public class UserViewModel : BaseControlViewModel
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
        public OpenUserEditPanel OpenEditpanel=>new OpenUserEditPanel(this);
        #endregion


        #region Values

        public override string Header => "Users";

        private UserModel model = new UserModel();
        public UserModel Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                OnPropertyChanged(nameof(Model));
            }
        }


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
                CurrentValue = (UserModel)SelectedValue?.Clone();
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private UserModel currentValue;
        public UserModel CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
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

        public RowDefinition RowDefinition { get; set; } = new RowDefinition();
        #endregion

        #region SEARCH


        public void Initialize()
        {
            GetUsers = new ObservableCollection<UserModel>(AllUsers);
        }



        public override void OnSearch()
        {
            var users = AllUsers.Where(x => Filter(x.Name) ||
                                            Filter(x.Email) ||
                                            Filter(x.Position) ||
                                            Filter(x.Surname) ||
                                            Filter(x.FatherName));

            GetUsers = new ObservableCollection<UserModel>(users);
        }

        #endregion


    }
}
