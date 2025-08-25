using CashFlow.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.ViewModel.MainWindowViewModel
{
    public class MainWindowVM : IMainWindowVM
    {
        private string _nomeTelaAtiva { get; set; }
        public string NomeTelaAtiva 
        { 
            get => _nomeTelaAtiva;
            set 
            { 
                _nomeTelaAtiva = value;
                OnPropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
