using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel
{
    public class ViewModelButtonCrud : ViewModelBase, IViewModelButtonCrud
    {
        private bool _exibirBotaoCancelar = false;
        private bool _exibirBotaoSalvar = false;
        private bool _exibirBotaoExcluir = false;
        private bool _exibirBotaoEditar = false;
        private bool _exibirBotaoAdicionar = false;

        public bool ExibirBotaoCancelar
        {
            get => _exibirBotaoCancelar;
            set
            {
                _exibirBotaoCancelar = value;
                PropriedadeAlterada();
            }
        }
        public bool ExibirBotaoSalvar
        {
            get => _exibirBotaoSalvar;
            set
            {
                _exibirBotaoSalvar = value;
                PropriedadeAlterada();
            }
        }
        public bool ExibirBotaoExcluir
        {
            get => _exibirBotaoExcluir;
            set
            {
                _exibirBotaoExcluir = value;
                PropriedadeAlterada();
            }
        }
        public bool ExibirBotaoEditar
        {
            get => _exibirBotaoEditar;
            set
            {
                _exibirBotaoEditar = value;
                PropriedadeAlterada();
            }
        }
        public bool ExibirBotaoAdicionar
        {
            get => _exibirBotaoAdicionar;
            set
            {
                _exibirBotaoAdicionar = value;
                PropriedadeAlterada();
            }
        }

        public virtual void DefinirOperacao(eTipoOperacao tipoOperacao)
        {
            bool operacaoCrud = (tipoOperacao == eTipoOperacao.Adicionar || tipoOperacao == eTipoOperacao.Alterar || tipoOperacao == eTipoOperacao.Deletar);

            if (tipoOperacao == eTipoOperacao.Nenhuma)
            {
                ExibirBotaoCancelar = false;
                ExibirBotaoSalvar = false;
                ExibirBotaoExcluir = false;
                ExibirBotaoEditar = false;
                ExibirBotaoAdicionar = false;
            }
            else if (operacaoCrud)
            {
                ExibirBotaoCancelar = true;
                ExibirBotaoSalvar = true;
                ExibirBotaoExcluir = false;
                ExibirBotaoEditar = false;
                ExibirBotaoAdicionar = false;
            }
            else
            {
                ExibirBotaoCancelar = false;
                ExibirBotaoSalvar = false;
                ExibirBotaoExcluir = true;
                ExibirBotaoEditar = true;
                ExibirBotaoAdicionar = true;
            }
        }
    }
}
