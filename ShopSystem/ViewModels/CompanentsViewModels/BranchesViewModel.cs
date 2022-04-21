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

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class BranchesViewModel : BaseViewModel
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public BranchesViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }

        #region Commands
        public AddBranchesCommand addcommand => new AddBranchesCommand(this);
        public DeleteBranchesCommand DeleteBranchesCommand => new DeleteBranchesCommand(this);


        #endregion


        #region Values

        private BranchesModel selectedvalue;
        public BranchesModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }


        private ObservableCollection<BranchesModel> getbranches;
        public ObservableCollection<BranchesModel> GetBranches
        {
            get { return getbranches; }
            set
            {
                getbranches = value;
                OnPropertyChanged(nameof(GetBranches));
            }
        }


        private List<BranchesModel> allBranches;
        public List<BranchesModel> AllBranches
        {
            get { return allBranches; }
            set
            {
                allBranches = value;
                OnPropertyChanged(nameof(AllBranches));
            }
        }


        private BranchesModel model = new BranchesModel();
        public BranchesModel Model
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
            GetBranches = new ObservableCollection<BranchesModel>(AllBranches);
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



            GetBranches = new ObservableCollection<BranchesModel>(products);
        }
    }
}
