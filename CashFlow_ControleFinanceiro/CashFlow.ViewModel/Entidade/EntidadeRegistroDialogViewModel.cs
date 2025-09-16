using CashFlow.Domain.Interfaces.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Entity;
using System.Security.AccessControl;

namespace CashFlow.ViewModel.Entidade
{
    public class EntidadeRegistroDialogViewModel : ViewModelColecaoBase<EntidadeFinanceira>, IEntidadeRegistroDialogViewModel
    {
        #region Categoria
        private ObservableCollection<Domain.Entity.Categoria> _categoriaCollection;
        private Domain.Entity.Categoria _categoriaSelecionada;

        public ObservableCollection<Domain.Entity.Categoria> CategoriaCollection
        {
            get
            {
                if (_categoriaCollection == null)
                    _categoriaCollection = new ObservableCollection<Domain.Entity.Categoria>();

                return _categoriaCollection;
            }
            set
            {
                _categoriaCollection = value;
                PropriedadeAlterada();
            }
        }
        public Domain.Entity.Categoria CategoriaSelecionada
        {
            get => _categoriaSelecionada;
            set
            {
                _categoriaSelecionada = value;
                PropriedadeAlterada();
            }
        }
        #endregion
    }
}
