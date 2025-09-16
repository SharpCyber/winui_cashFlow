using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces.ViewModels
{
    public interface IViewModelButtonCrud : IViewModelBase
    {
        bool ExibirBotaoCancelar { get; set; }  
        bool ExibirBotaoSalvar { get; set; }
        bool ExibirBotaoExcluir { get; set; }
        bool ExibirBotaoEditar { get; set; }
        bool ExibirBotaoAdicionar { get; set; }

        void DefinirOperacao(eTipoOperacao tipoOperacao);
    }
}
