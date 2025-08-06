using CashFlow.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface ICategoriaDialogViewModel
    {
        ObservableCollection<Categoria> Categorias { get; set; }
        Categoria CategoriaSelecionada { get; set; }
        string Nome { get; set; }
    }
}
