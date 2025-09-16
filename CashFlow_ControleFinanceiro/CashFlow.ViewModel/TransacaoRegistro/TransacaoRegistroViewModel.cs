using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel.TransacaoRegistro
{
    public class TransacaoRegistroViewModel : ViewModelColecaoBase<Domain.Entity.Transacao>, ITransacaoRegistroViewModel
    {
    }
}
