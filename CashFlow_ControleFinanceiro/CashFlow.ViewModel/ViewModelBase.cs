using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Interfaces;

namespace CashFlow.ViewModel
{
    public class ViewModelBase<T> : IViewModelBase<T> where T : class
    {
        private T _itemSelecionado;
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public virtual T ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                if (!Equals(_itemSelecionado, value))
                {
                    _itemSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }
        public virtual ObservableCollection<T> Items
        {
            get => _items;
            set
            {
                if (!Equals(_items, value))
                {
                    _items = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
