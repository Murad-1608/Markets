using ShopSystem.DataAccessLayer.Abstraction;
using ShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ShopSystem.ViewModels
{
    internal abstract class BaseControlViewModel<T> : BaseViewModel where T : BaseModel, new()
    {
        public IUnitOfWork db;
        public BaseControlViewModel(IUnitOfWork db) : base(db)
        {

        }

        public abstract void OnSearch();
        public abstract string Header { get; }

        public virtual void OnCurrentValueChange()
        {

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
                OnSearch();
            }
        }

        private T model = new T();
        public T Model
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

        private List<T> allValues;
        public List<T> AllValues
        {
            get { return allValues; }
            set
            {
                allValues = value;
                OnPropertyChanged(nameof(AllValues));
            }
        }

        private T selectedvalue;
        public T SelectedValue
        {
            get => selectedvalue;
            set
            {
                selectedvalue = value;
                CurrentValue = (T)SelectedValue?.Clone();
                OnPropertyChanged(nameof(SelectedValue));
            }
        }

        private T currentValue;
        public T CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnCurrentValueChange();
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private ObservableCollection<T> getValues;
        public ObservableCollection<T> GetValues
        {
            get { return getValues; }
            set
            {
                getValues = value;
                OnPropertyChanged(nameof(GetValues));
            }
        }

        private GridLength rowHeight = new GridLength(0);
        public GridLength RowHeight
        {
            get
            {
                return rowHeight;
            }
            set
            {
                rowHeight = value;
                OnPropertyChanged(nameof(RowHeight));
            }
        }

        private Visibility addPanelVisibility = Visibility.Collapsed;
        public Visibility AddPanelVisibility
        {
            get
            {
                return addPanelVisibility;
            }
            set
            {
                addPanelVisibility = value;
                OnPropertyChanged(nameof(AddPanelVisibility));
            }
        }

        private Visibility editPanelVisibility = Visibility.Collapsed;
        public Visibility EditPanelVisibility
        {
            get
            {
                return editPanelVisibility;
            }
            set
            {
                editPanelVisibility = value;
                OnPropertyChanged(nameof(EditPanelVisibility));
            }
        }

        private Visibility errorTextVisibility = Visibility.Collapsed;
        public Visibility ErrorTextVisibility
        {
            get
            {
                return errorTextVisibility;
            }
            set
            {
                errorTextVisibility = value;
                OnPropertyChanged(nameof(ErrorTextVisibility));
            }
        }
        private string errorText;
        public string ErrorText
        {
            get
            {
                return errorText;
            }
            set
            {
                errorText = value;
                OnPropertyChanged(nameof(ErrorText));
            }
        }



        public void Initialize()
        {
            GetValues = new ObservableCollection<T>(AllValues);
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
