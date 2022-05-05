using ShopSystem.Commands.Main;
using ShopSystem.Commands.Main.BranchesCommand;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataContext;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class BranchesViewModel : BaseViewModel
    {
        public DataProvider dataprovider;
        public BranchesViewModel(IUnitOfWork db) : base(db)
        {
            dataprovider = new DataProvider(Global.DB);
        }

        #region Commands
        public AddBranchesCommand addcommand => new AddBranchesCommand(this);
        public DeleteBranchesCommand DeleteBranchesCommand => new DeleteBranchesCommand(this);
        public EditBranchesCommand EditBranchesCommand => new EditBranchesCommand(this);


        #endregion

        #region Values

        private BranchModel selectedvalue;
        public BranchModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                CurrentValue = (BranchModel)SelectedValue?.Clone();
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private BranchModel currentValue;
        public BranchModel CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }


        private ObservableCollection<BranchModel> getbranches;
        public ObservableCollection<BranchModel> GetBranches
        {
            get { return getbranches; }
            set
            {
                getbranches = value;
                OnPropertyChanged(nameof(GetBranches));
            }
        }

        private List<BranchModel> allBranches;
        public List<BranchModel> AllBranches
        {
            get { return allBranches; }
            set
            {
                allBranches = value;
                OnPropertyChanged(nameof(AllBranches));
            }
        }


        private BranchModel model = new BranchModel();
        public BranchModel Model
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


        #endregion

        public void Initialize()
        {
            GetBranches = new ObservableCollection<BranchModel>(AllBranches);
        }


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
                OnSearch();
            }
        }



        public void OnSearch()
        {
            var products = AllBranches.Where(x => (x.Location != null && x.Location.ToLower().Contains(SearchText.ToLower()) ||
                                                  (x.PhoneNumber != null && x.PhoneNumber.ToLower().Contains(SearchText.ToLower()))));



            GetBranches = new ObservableCollection<BranchModel>(products);
        }
    }
}
