using ShopSystem.Commands;
using ShopSystem.DataAccessLayer.Abstraction;
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
        IUnitOfWork db = null;
        public CompanyViewModel(IUnitOfWork db):base(db)
        {
            this.db = db;
        }


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
       
        
    }
}
