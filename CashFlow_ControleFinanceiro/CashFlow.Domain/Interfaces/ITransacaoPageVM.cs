using CashFlow.Domain.DTO;
using CashFlow.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface ITransacaoPageVM : ICrudViewModelBase<Transacao>
    {
        ObservableCollection<Item> OrdenacaoCollection { get; set; }
        Item OrdenacaoSelecionada { get; set; }
    }
}
