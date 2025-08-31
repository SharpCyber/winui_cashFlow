using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private string _nomeTelaAtiva { get; set; }
        public string NomeTelaAtiva
        {
            get => _nomeTelaAtiva;
            set
            {
                _nomeTelaAtiva = value;
                PropriedadeAlterada();
            }
        }
    }
}
