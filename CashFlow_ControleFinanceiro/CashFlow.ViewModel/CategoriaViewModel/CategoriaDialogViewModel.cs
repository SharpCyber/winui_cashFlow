using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Text;

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
        private Visibility _exibirAviso = Visibility.Collapsed;
        private string _mensagemAviso;
        private bool _habilitarBotoesCrud = true;

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
                _habilitarBotoesCrud = (CategoriaSelecionada != null);

                OnPropertyChanged(nameof(MostrarBotoesCrud));
                OnPropertyChanged(nameof(HabilitarBotoesCrud));
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
        public bool HabilitarBotoesCrud
        {
            get => _habilitarBotoesCrud;
            set
            {
                _habilitarBotoesCrud = value;
                OnPropertyChanged(nameof(HabilitarBotoesCrud));
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
        public Visibility ExibirAviso
        {
            get => _exibirAviso;
            set
            {
                _exibirAviso = value;
                OnPropertyChanged(nameof(ExibirAviso));
            }
        }
        public string MensagemAviso
        {
            get => _mensagemAviso;
            set
            {
                _mensagemAviso = value;
                OnPropertyChanged(nameof(MensagemAviso));
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
            bool habilitarCrud = false;
            bool exibirAviso = false;
            string mensagemAviso = "";

            switch (_tipoOperacao)
            {
                case eTipoOperacao.Nenhuma: 
                    habilitarCrud = true;
                    break;
                case eTipoOperacao.Visualizar:
                    habilitarCrud = true;
                    break;
                case eTipoOperacao.Cancelar:
                    habilitarCrud = true;
                    break;
                case eTipoOperacao.Confirmar:
                    habilitarCrud = true;
                    break;
                case eTipoOperacao.Salvar:
                    habilitarCrud = true;
                    break;
                case eTipoOperacao.Adicionar: 
                    break;
                case eTipoOperacao.Alterar:
                    break;
                case eTipoOperacao.Deletar:
                    exibirAviso = true;
                    mensagemAviso = "Tem certeza que deseja realizar a exclusão da categoria?\nEssa operação não poderá ser desfeita.";
                    break;
                default: break;
            }

            MostrarBotoesCrud = habilitarCrud;
            MostrarBotoesSalvarCancelar = !habilitarCrud;

            EditarNome = (_tipoOperacao == eTipoOperacao.Alterar || _tipoOperacao == eTipoOperacao.Adicionar);
            ExibirAviso = (exibirAviso) ? Visibility.Visible : Visibility.Collapsed;
            MensagemAviso = mensagemAviso;

            OnPropertyChanged(nameof(TipoOperacao));
        }
        #endregion
    }
}
