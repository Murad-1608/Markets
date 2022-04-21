using ShopSystem.Commands;
using ShopSystem.Commands.Main;
using ShopSystem.Commands.Main.CompanyCommand;
using ShopSystem.Commands.Main.ProductCommand;
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
    internal class CompanyViewModel : BaseViewModel
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public CompanyViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }

        #region Commands
        public AddCompanyCommand addcommand => new AddCompanyCommand(this);
        public DeleteCompanyCommand DeleteProductCommand => new DeleteCompanyCommand(this);


        #endregion


        #region Values

        private CompaniesModel selectedvalue;
        public CompaniesModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }


        private ObservableCollection<CompaniesModel> getcompanies;
        public ObservableCollection<CompaniesModel> GetCompanies
        {
            get { return getcompanies; }
            set
            {
                getcompanies = value;
                OnPropertyChanged(nameof(GetCompanies));
            }
        }


        private List<CompaniesModel> allCompanies;
        public List<CompaniesModel> AllCompanies
        {
            get { return allCompanies; }
            set
            {
                allCompanies = value;
                OnPropertyChanged(nameof(allCompanies));
            }
        }


        private CompaniesModel model = new CompaniesModel();
        public CompaniesModel Model
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
            GetCompanies = new ObservableCollection<CompaniesModel>(AllCompanies);
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


            GetCompanies = new ObservableCollection<CompaniesModel>(products);
        }


    }
}
