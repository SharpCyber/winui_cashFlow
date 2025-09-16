using CashFlow.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces.ViewModels
{
    public interface IEntidadeRegistroDialogViewModel : IViewModelColecaoBase<EntidadeFinanceira>
    {
        ObservableCollection<Categoria> CategoriaCollection { get; set; }
        Categoria CategoriaSelecionada { get; set; }    
    }
}
