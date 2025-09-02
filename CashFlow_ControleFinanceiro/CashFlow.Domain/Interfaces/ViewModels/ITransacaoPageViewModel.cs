using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces.ViewModels
{
    public interface ITransacaoPageViewModel : IViewModelBase
    {
        void Pesquisar(DateTime data);
    }
}
