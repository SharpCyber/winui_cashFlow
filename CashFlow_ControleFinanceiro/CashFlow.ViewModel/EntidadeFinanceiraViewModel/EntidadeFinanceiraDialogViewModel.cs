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
    public class EntidadeFinanceiraDialogViewModel : CrudViewModelBase<object>, IEntidadeFinanceiraDialogViewModel
    {
        private ObservableCollection<Categoria> _categorias;
        private Categoria _categoriaSelecionada;

        public ObservableCollection<Categoria> Categorias
        {
            get
            {
                if (_categorias == null)
                    _categorias = new ObservableCollection<Categoria>();

                return _categorias;
            }
            set
            {
                _categorias = value;
                OnPropertyChanged();
            }
        }
        public Categoria CategoriaSelecionada
        {
            get => _categoriaSelecionada;
            set
            {
                _categoriaSelecionada = value;

                Nome = CategoriaSelecionada != null ? CategoriaSelecionada.Nome : "";
                OnPropertyChanged(nameof(CategoriaSelecionada));
            }
        }
    }
}
