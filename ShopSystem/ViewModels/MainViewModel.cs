using ShopSystem.Commands.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ShopSystem.ViewModels
{
    internal class MainViewModel: INotifyPropertyChanged
    {
        public OpenCompaniesCommand openCompaniesCommand => new OpenCompaniesCommand(this);
        public OpenBranchesCommand openBranhesCommand => new OpenBranchesCommand(this);
     //  public OpenBranchesCommand openBranhesCommand => new OpenBranchesCommand(this);

        public Grid CenterGrid { get; set; }


        private string header;
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                OnPropertyChanged(nameof(Header));
            }
        }


        private string header1;
        public string Header1
        {
            get
            {
                return header1;
            }
            set
            {
                header = value;
                OnPropertyChanged(nameof(Header1));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
