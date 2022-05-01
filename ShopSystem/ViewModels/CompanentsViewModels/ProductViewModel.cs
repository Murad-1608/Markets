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
using System.Windows;

namespace ShopSystem.ViewModels.CompanentsViewModels
{
    internal class ProductViewModel : BaseControlViewModel<ProductModel>
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
        public OpenProductEditPanel OpenProductEditPanel => new OpenProductEditPanel(this);
        public CloseAddandEditPanel CloseAddandEditPanel => new CloseAddandEditPanel(this);
        public OpenProductAddPanel OpenProductAddPanel => new OpenProductAddPanel(this);


        #endregion


        #region Values

        public List<BranchesModel> Branches { get; set; }

        private BranchesModel selectedItem;
        public BranchesModel SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public override string Header => "Products";

        #endregion





        public override void OnSearch()
        {
            var products = AllValues.Where(x => Filter(x.Name) ||
                                                  Filter(x.Brand) ||
                                                  Filter(x.Type));


            GetValues = new ObservableCollection<ProductModel>(products);
        }
    }
}
