using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces.ViewModels
{
    public interface IMainWindowViewModel : IViewModelBase
    {
        string NomeTelaAtiva { get; set; }
    }
}
