using ShopSystem.Commands.Main.CompanyCommand;
using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataContext;
using ShopSystem.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class CompanyViewModel : BaseViewModel
    {
        public DataProvider dataprovider;
        public CompanyViewModel(IUnitOfWork db) : base(db)
        {
            dataprovider = new DataProvider(Global.DB);
        }

        #region Commands
        public AddCompanyCommand addcommand => new AddCompanyCommand(this);
        public DeleteCompanyCommand DeleteProductCommand => new DeleteCompanyCommand(this);
        public EditCompanyCommand EditCompanyCommand => new EditCompanyCommand(this);

        #endregion


        #region Values

        private CompanyModel selectedvalue;
        public CompanyModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                currentValue = (CompanyModel)SelectedValue?.Clone();
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private CompanyModel currentValue;
        public CompanyModel CurrentValue
        {
            get => currentValue;
            set
            {
                selectedvalue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }


        private ObservableCollection<CompanyModel> getcompanies;
        public ObservableCollection<CompanyModel> GetCompanies
        {
            get { return getcompanies; }
            set
            {
                getcompanies = value;
                OnPropertyChanged(nameof(GetCompanies));
            }
        }


        private List<CompanyModel> allCompanies;
        public List<CompanyModel> AllCompanies
        {
            get { return allCompanies; }
            set
            {
                allCompanies = value;
                OnPropertyChanged(nameof(allCompanies));
            }
        }


        private CompanyModel model = new CompanyModel();
        public CompanyModel Model
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
            GetCompanies = new ObservableCollection<CompanyModel>(AllCompanies);
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
            var products = AllCompanies.Where(x => (x.Name != null && x.Name.ToLower().Contains(SearchText.ToLower())));


            GetCompanies = new ObservableCollection<CompanyModel>(products);
        }


    }
}
