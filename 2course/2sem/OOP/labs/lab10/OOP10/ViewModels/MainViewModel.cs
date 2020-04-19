using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP10
{
    class MainViewModel
    {
        public ObservableCollection<SkladViewModel> StoreList { get; set; }
        public MainViewModel(List<Sklad> Stores)
        {
            StoreList = new ObservableCollection<SkladViewModel>(Stores.Select(b => new SkladViewModel(b)));
        }
    }
}
