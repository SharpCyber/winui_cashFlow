using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
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
        bool EditarNome { get; set; }
        void DefinirOperacao(eTipoOperacao tipoOperacao);
    }
}
