using ShopSystem.DataAccessLayer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.ViewModels
{
    public abstract class BaseControlViewModel : BaseViewModel
    {
        public IUnitOfWork db;
        public BaseControlViewModel(IUnitOfWork db) : base(db)
        {

        }

        public abstract void OnSearch();
        public abstract string Header { get; }


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
                OnSearch();
            }
        }

        private byte currentSituation;
        public byte CurrentSituation
        {
            get
            {
                return currentSituation;
            }

            set
            {
                currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));

            }


        }


        protected bool Filter(string value)
        {
            if (value != null && value.ToLower().Contains(SearchText.ToLower()))
                return true;

            else
                return false;
        }

    }
}
