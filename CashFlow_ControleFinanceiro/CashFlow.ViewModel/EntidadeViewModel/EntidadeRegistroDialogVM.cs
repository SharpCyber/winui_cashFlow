using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Text;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using Microsoft.UI.Xaml;


namespace CashFlow.ViewModel.EntidadeFinanceiraViewModel
{
    public class EntidadeRegistroDialogVM : CrudViewModelBase<EntidadeFinanceira>, IEntidadeRegistroDialogVM
    {
        private ObservableCollection<Categoria> _categoriaCollection;
        private Categoria _categoriaSelecionada;

        public ObservableCollection<Categoria> CategoriaCollection
        {
            get
            {
                if (_categoriaCollection == null)
                    _categoriaCollection = new ObservableCollection<Categoria>();

                return _categoriaCollection;
            }
            set
            {
                _categoriaCollection = value;
                OnPropertyChanged();
            }
        }
        public Categoria CategoriaSelecionada
        {
            get => _categoriaSelecionada;
            set
            {
                _categoriaSelecionada = value;

                Nome = _categoriaSelecionada != null ? _categoriaSelecionada.Nome : "";
                OnPropertyChanged(nameof(CategoriaSelecionada));
            }
        }
    }
}
