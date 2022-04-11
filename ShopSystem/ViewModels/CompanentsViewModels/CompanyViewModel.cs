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
    internal class CompanyViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<UserModel> companies;

        public ObservableCollection<UserModel> Companies
        {
            get { return companies; }
            set
            {
                companies = value;
                OnPropertyChanged(nameof(Companies));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
