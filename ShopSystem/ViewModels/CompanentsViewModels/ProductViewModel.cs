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
        public DataProvider dataprovider;
        public ProductViewModel(IUnitOfWork db) : base(db)
        {
            dataprovider = new DataProvider(Global.DB);
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

        public List<BranchModel> Branches { get; set; }

        private BranchModel selectedItem;
        public BranchModel SelectedItem
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

        public override void OnCurrentValueChange()
        {
            SelectedItem = CurrentValue?.Branch?.Clone() as BranchModel;
        }

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
