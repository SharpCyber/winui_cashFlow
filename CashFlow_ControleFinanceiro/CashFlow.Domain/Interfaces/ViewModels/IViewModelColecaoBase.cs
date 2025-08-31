using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces.ViewModels
{
    public interface IViewModelColecaoBase<T> : IViewModelButtonCrud where T : class
    {
        T ItemSelecionado { get; set; }
        ObservableCollection<T> Items { get; set; }
    }
}
