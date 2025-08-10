using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;

namespace CashFlow.Domain.Interfaces
{
    public interface IEntidadeFinanceiraDialogViewModel : ICrudViewModelBase<object>
    {
        ObservableCollection<Categoria> Categorias { get; set; }
        Categoria CategoriaSelecionada { get; set; }
    }
}
