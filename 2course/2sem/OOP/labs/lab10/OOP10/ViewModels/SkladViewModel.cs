using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOP10
{
    public class SkladViewModel: INotifyPropertyChanged
    {
        public Sklad Store;

        public SkladViewModel(Sklad store) { this.Store = store; }

        public string View
        {
            get { return Store.View; }
            set
            {
                Store.View = value;
                OnPropertyChanged("View");
            }
        }
        public string Name
        {
            get
            {
                return Store.Name;
            }
            set
            {
                Store.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Price
        {
            get { return Store.Price; }
            set
            {
                Store.Price = value;
                OnPropertyChanged("Price");
            }
        }
        public int Count
        {
            get { return Store.Count; }
            set
            {
                Store.Count = value;
                OnPropertyChanged("Count");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
               
            }
        #region Commands
        #region Забрать
        private DelegateCommand getItemCommand;
        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand  ==  null)
                {
                    getItemCommand  =  new DelegateCommand(GetItem);
                }
        return getItemCommand;
            }
        }
        private void GetItem(){Count++;}
        #endregion
        #region Выдать
        private  DelegateCommand giveItemCommand;
        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand  ==  null)
                {
                    giveItemCommand  =  new DelegateCommand(GiveItem,  CanGiveItem);
                }
                return giveItemCommand;
            }
        }
        private void GiveItem(){Count--;}
        private bool CanGiveItem(){return Count  >  0;}
        #endregion
        #endregion
    }
}
