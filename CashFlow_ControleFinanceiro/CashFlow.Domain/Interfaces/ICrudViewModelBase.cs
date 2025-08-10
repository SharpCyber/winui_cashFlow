using CashFlow.Domain.Enumeration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Interfaces
{
    public interface ICrudViewModelBase<T> : INotifyPropertyChanged
    {
        ObservableCollection<T> Items { get; set; } 
        T ItemSelecionado { get; set; } 

        string Nome { get; set; }
        bool EditarNome { get; set; }
        bool ExibirBotaoCrud { get; set; }
        bool HabilitarBotaoCrud { get; set; }
        bool ExibirBotaoSalvarCancelar { get; set; }
        void DefinirOperacao(eTipoOperacao tipoOperacao);
    }
}
