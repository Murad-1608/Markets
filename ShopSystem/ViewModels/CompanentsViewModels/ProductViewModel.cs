using ShopSystem.Commands.Main.ProductCommand;
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
    internal class ProductViewModel : INotifyPropertyChanged
    {


        public AddProductCommand addcommand => new AddProductCommand(this);





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

        private ObservableCollection<ProductModel> allproducts;
        public ObservableCollection<ProductModel> AllProducts
        {
            get { return allproducts; }
            set
            {
                allproducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }


        public void Initialize()
        {
            GetProducts = AllProducts;
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

        public ProductModel Model { get; set; } = new ProductModel();

       




        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
