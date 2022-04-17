using ShopSystem.Commands.Main;
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
    internal class ProductViewModel : BaseViewModel
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public ProductViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }

        #region Commands
        public AddProductCommand addcommand => new AddProductCommand(this);
        public DeleteProductCommand DeleteProductCommand => new DeleteProductCommand(this);
       

        #endregion


        #region Values

        private ProductModel selectedvalue;
        public ProductModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                OnPropertyChanged(nameof(SelectedValue));
            }
        }


        private ObservableCollection<ProductModel> getproducts;
        public ObservableCollection<ProductModel> GetProducts
        {
            get { return getproducts; }
            set
            {
                getproducts = value;
                OnPropertyChanged(nameof(GetProducts));
            }
        }


        private List<ProductModel> allproducts;
        public List<ProductModel> AllProducts
        {
            get { return allproducts; }
            set
            {
                allproducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }


        private ProductModel model=new ProductModel();
        public ProductModel Model
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
            GetProducts = new ObservableCollection<ProductModel>(AllProducts);
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
            var products = AllProducts.Where(x => (x.Name != null && x.Name.ToLower().Contains(SearchText.ToLower()) ||
                                                  (x.Brand != null && x.Brand.ToLower().Contains(SearchText.ToLower()) ||
                                                  (x.Type != null && x.Type.ToLower().Contains(SearchText.ToLower())))));


            GetProducts = new ObservableCollection<ProductModel>(products);
        }

    }
}
