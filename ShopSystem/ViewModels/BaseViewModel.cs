using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels
{
    internal class BaseViewModel : INotifyPropertyChanged
    {
        private IUnitOfWork db { get; }
        private DataProvider dataProvider;
        public BaseViewModel(IUnitOfWork db)
        {
            this.db = db;
            dataProvider=new DataProvider();
        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));  
        }
    }
}
