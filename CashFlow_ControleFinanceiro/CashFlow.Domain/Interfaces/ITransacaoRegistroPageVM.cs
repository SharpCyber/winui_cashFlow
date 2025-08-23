using CashFlow.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface ITransacaoRegistroPageVM : ICrudViewModelBase<Transacao>
    {
        ObservableCollection<TipoTransacao> TipoTransacaoCollection { get; set; }
        TipoTransacao TipoTransacaoSelecionada { get; set; }

        ObservableCollection<AtivoFinanceiro> AtivoFinanceiroCollection { get; set; }
        AtivoFinanceiro AtivoFinanceiroSelecionada { get; set; }

        ObservableCollection<EntidadeFinanceira> EntidadeFinanceiraCollection { get; set; }
        EntidadeFinanceira EntidadeFinanceiraSelecionada { get; set; }

        bool HabilitarDataTransacao { get; set; }
        bool HabilitarDataVencimento { get; set; }
    }
}
