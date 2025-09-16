using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel.TransacaoPage
{
    public class TransacaoViewModel 
    {
        private readonly Transacao _transacao;

        public TransacaoViewModel(Transacao transacao)
        {
            this._transacao = transacao;
        }

        public string CategoriaNome
        {
            get => _transacao.EntidadeFinanceira.Categoria.Nome;
        }
    }
}
