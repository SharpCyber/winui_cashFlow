using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel
{
    public abstract class ViewModelColecaoBase<T> : ViewModelButtonCrud, IViewModelColecaoBase<T> where T : class
    {
        #region ItemSelecionado
        private T _itemSelecionado;
        public T ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                if (!Equals(_itemSelecionado, value))
                {
                    _itemSelecionado = value;
                    PropriedadeAlterada();
                }
            }
        }
        #endregion

        #region Itens
        private ObservableCollection<T> _items = new ObservableCollection<T>();
        public ObservableCollection<T> Items
        {
            get => _items;
            set
            {
                if (!Equals(_items, value))
                {
                    _items = value;
                    PropriedadeAlterada();
                }
            }
        }
        #endregion
    }
}
