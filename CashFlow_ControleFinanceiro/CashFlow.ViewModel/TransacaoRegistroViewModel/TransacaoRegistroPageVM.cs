using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.ViewModel.TransacaoRegistroViewModel
{
    public class TransacaoRegistroPageVM : CrudViewModelBase<Transacao>, ITransacaoRegistroPageVM
    {
        #region TipoTransacao
        private ObservableCollection<TipoTransacao> _tipoTransacaoCollection;
        private TipoTransacao _tipoTransacaoSelecionada;
        public ObservableCollection<TipoTransacao> TipoTransacaoCollection
        {
            get
            {
                if (_tipoTransacaoCollection == null)
                    _tipoTransacaoCollection = new ObservableCollection<TipoTransacao>();

                return _tipoTransacaoCollection;
            }
            set
            {
                _tipoTransacaoCollection = value;
                OnPropertyChanged();
            }
        }
        public TipoTransacao TipoTransacaoSelecionada
        {
            get => _tipoTransacaoSelecionada;
            set
            {
                _tipoTransacaoSelecionada = value;

                OnPropertyChanged(nameof(TipoTransacaoSelecionada));
            }
        }
        #endregion

        #region AtivoFinanceiro
        private ObservableCollection<AtivoFinanceiro> _ativoFinanceiroCollection;
        private AtivoFinanceiro _ativoFinanceiroSelecionada;
        public ObservableCollection<AtivoFinanceiro> AtivoFinanceiroCollection
        {
            get
            {
                if (_ativoFinanceiroCollection == null)
                    _ativoFinanceiroCollection = new ObservableCollection<AtivoFinanceiro>();

                return _ativoFinanceiroCollection;
            }
            set
            {
                _ativoFinanceiroCollection = value;
                OnPropertyChanged();
            }
        }
        public AtivoFinanceiro AtivoFinanceiroSelecionada
        {
            get => _ativoFinanceiroSelecionada;
            set
            {
                _ativoFinanceiroSelecionada = value;

                OnPropertyChanged(nameof(AtivoFinanceiroSelecionada));
            }
        }
        #endregion

        #region EntidadeFinanceira
        private ObservableCollection<EntidadeFinanceira> _entidadeFinanceiraCollection;
        private EntidadeFinanceira _entidadeFinanceiraSelecionada;
        public ObservableCollection<EntidadeFinanceira> EntidadeFinanceiraCollection
        {
            get
            {
                if (_entidadeFinanceiraCollection == null)
                    _entidadeFinanceiraCollection = new ObservableCollection<EntidadeFinanceira>();

                return _entidadeFinanceiraCollection;
            }
            set
            {
                _entidadeFinanceiraCollection = value;
                OnPropertyChanged();
            }
        }
        public EntidadeFinanceira EntidadeFinanceiraSelecionada
        {
            get => _entidadeFinanceiraSelecionada;
            set
            {
                _entidadeFinanceiraSelecionada = value;

                OnPropertyChanged(nameof(EntidadeFinanceiraSelecionada));
            }
        }
        #endregion
    }
}
