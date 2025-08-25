using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface IMainWindowVM : INotifyPropertyChanged
    {
        string NomeTelaAtiva { get; set; }
        void OnPropertyChanged([CallerMemberName] string propertyName = null);
    }
}
