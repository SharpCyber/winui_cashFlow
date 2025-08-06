using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.ViewModel.CategoriaViewModel
{
    public class CategoriaDialogViewModel : INotifyPropertyChanged, ICategoriaDialogViewModel
    {
        #region Propriedades
        public event PropertyChangedEventHandler PropertyChanged;
        private Categoria _categoriaSelecionada;
        private string _nome;
        #endregion

        #region Propriedades Pública
        public ObservableCollection<Categoria> Categorias { get; set; }
        public Categoria CategoriaSelecionada
        {
            get => _categoriaSelecionada;
            set
            {
                _categoriaSelecionada = value;
                Nome = value?.Nome;
                OnPropertyChanged(nameof(CategoriaSelecionada));
            }
        }
        public string Nome
        {
            get => _nome;
            set
            {
                _nome = value;
                OnPropertyChanged(nameof(Nome));
            }
        }
        #endregion

        #region Construtor
        public CategoriaDialogViewModel()
        {
            this.Categorias = new ObservableCollection<Categoria>();
        }
        #endregion

        #region Metodos
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
