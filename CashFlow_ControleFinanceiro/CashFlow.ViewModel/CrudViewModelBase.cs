using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Extension;
using CashFlow.Domain.Interfaces;

namespace CashFlow.ViewModel
{
    public abstract class CrudViewModelBase<T> : ViewModelBase <T>, ICrudViewModelBase<T> where T : class
    {
        #region Propriedades
        private T _itemSelecionado;
        
        private string _nome;
        private bool _editarNome;
        
        private bool _exibirBotaoCrud = true;
        private bool _habilitarBotaoCrud = true;
        private bool _exibirBotoesSalvarCancelar = false;
        #endregion

        #region Propriedades Pública
        public override T ItemSelecionado
        {
            get => _itemSelecionado;
            set
            {
                _itemSelecionado = value;

                Nome = ItemSelecionado.ObterPropriedade("Nome", "");
                OnPropertyChanged(nameof(ItemSelecionado));
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
        public bool EditarNome
        {
            get => _editarNome;
            set
            {
                _editarNome = value;
                OnPropertyChanged(nameof(EditarNome));
            }
        }
        public bool ExibirBotaoCrud
        {
            get => _exibirBotaoCrud;
            set
            {
                _exibirBotaoCrud = value;
                _habilitarBotaoCrud = (ItemSelecionado != null);

                OnPropertyChanged(nameof(ExibirBotaoCrud));
                OnPropertyChanged(nameof(HabilitarBotaoCrud));
            }
        }
        public bool HabilitarBotaoCrud
        {
            get => _habilitarBotaoCrud;
            set
            {
                _habilitarBotaoCrud = value;
                OnPropertyChanged(nameof(HabilitarBotaoCrud));
            }
        }
        public bool ExibirBotaoSalvarCancelar
        {
            get => _exibirBotoesSalvarCancelar;
            set
            {
                _exibirBotoesSalvarCancelar = value;
                OnPropertyChanged(nameof(ExibirBotaoSalvarCancelar));
            }
        }
        #endregion

        #region Métodos Públicos

        public virtual void DefinirOperacao(eTipoOperacao tipoOperacao)
        {
            bool habilitarCrud = false;

            Nome = ItemSelecionado.ObterPropriedade("Nome", "");

            switch (tipoOperacao)
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
                    Nome = "";
                    break;
                case eTipoOperacao.Alterar:
                    break;
                case eTipoOperacao.Deletar:
                    break;
                default: break;
            }

            ExibirBotaoCrud = habilitarCrud;
            ExibirBotaoSalvarCancelar = !habilitarCrud;

            EditarNome = (tipoOperacao == eTipoOperacao.Alterar || tipoOperacao == eTipoOperacao.Adicionar);
        }
        #endregion

        #region Metodos
        #endregion
    }
}
