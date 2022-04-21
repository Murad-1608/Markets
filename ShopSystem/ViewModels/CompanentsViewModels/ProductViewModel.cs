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
    internal class ProductViewModel : BaseControlViewModel
    {
        public IUnitOfWork db;
        public DataProvider dataprovider;
        public ProductViewModel(IUnitOfWork db) : base(db)
        {
            this.db = db;
            dataprovider = new DataProvider();
        }



        #region Commands
        public AddProductCommand AddProductCommand => new AddProductCommand(this);
        public DeleteProductCommand DeleteProductCommand => new DeleteProductCommand(this);
        public SaveProductCommand SaveProductCommand => new SaveProductCommand(this);


        #endregion


        #region Values
        public override string Header => "Products";

        private ProductModel selectedvalue;
        public ProductModel SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                CurrentValue = (ProductModel)SelectedValue?.Clone();
                OnPropertyChanged(nameof(SelectedValue));
            }
        }


        private ProductModel currentValue;
        public ProductModel CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnPropertyChanged(nameof(currentValue));
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


        private ProductModel model = new ProductModel();
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


        public override void OnSearch()
        {
            var products = AllProducts.Where(x => Filter(x.Name) ||
                                                  Filter(x.Brand) ||
                                                  Filter(x.Type));


            GetProducts = new ObservableCollection<ProductModel>(products);
        }
    }
}
