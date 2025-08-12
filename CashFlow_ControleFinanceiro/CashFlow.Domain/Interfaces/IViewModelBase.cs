using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface IViewModelBase<T> : INotifyPropertyChanged
    {
        T ItemSelecionado { get; set; }
        ObservableCollection<T> Items { get; set; }
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}
