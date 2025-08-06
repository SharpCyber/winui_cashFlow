using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;

namespace CashFlow.ViewModel.CategoriaViewModel
{
    public class CategoriaDialogViewModel : INotifyPropertyChanged, ICategoriaDialogViewModel
    {
        #region Propriedades
        public event PropertyChangedEventHandler PropertyChanged;
        private Categoria _categoriaSelecionada;
        private string _nome;
        private bool _editarNome;
        private eTipoOperacao _tipoOperacao;
        private bool _mostrarBotoesCrud = true;
        private bool _mostrarBotoesSalvarCancelar = false;
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
        public eTipoOperacao TipoOperacao
        {
            get => _tipoOperacao;
            set => _tipoOperacao = value;
        }
        public bool MostrarBotoesCrud
        {
            get => _mostrarBotoesCrud;
            set
            {
                _mostrarBotoesCrud = value;
                OnPropertyChanged(nameof(MostrarBotoesCrud));
            }
        }
        public bool MostrarBotoesSalvarCancelar
        {
            get => _mostrarBotoesSalvarCancelar;
            set
            {
                _mostrarBotoesSalvarCancelar = value;
                OnPropertyChanged(nameof(MostrarBotoesSalvarCancelar));
            }
        }
        public bool EditarNome
        {
            get => _editarNome;
            set
            {
                _editarNome = value;
                OnPropertyChanged(nameof(EditarNome));
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

        #region Métodos Públicos
        public void DefinirOperacao(eTipoOperacao tipoOperacao)
        {
            _tipoOperacao = tipoOperacao;

            if (_tipoOperacao == eTipoOperacao.Visualizar ||
                _tipoOperacao == eTipoOperacao.Salvar ||
                _tipoOperacao == eTipoOperacao.Cancelar ||
                _tipoOperacao == eTipoOperacao.Nenhuma)
            {
                MostrarBotoesCrud = true;
                MostrarBotoesSalvarCancelar = false;
            }
            else if (_tipoOperacao == eTipoOperacao.Alterar ||
                     _tipoOperacao == eTipoOperacao.Deletar ||
                     _tipoOperacao == eTipoOperacao.Adicionar)
            {
                MostrarBotoesCrud = false;
                MostrarBotoesSalvarCancelar = true;
            }

            EditarNome = (_tipoOperacao == eTipoOperacao.Alterar || _tipoOperacao == eTipoOperacao.Adicionar);

            OnPropertyChanged(nameof(TipoOperacao));
        }
        #endregion
    }
}
