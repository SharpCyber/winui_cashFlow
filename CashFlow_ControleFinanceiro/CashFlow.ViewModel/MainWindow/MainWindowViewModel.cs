using ABI.Microsoft.UI.Xaml;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces.ViewModels;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.ViewModel.MainWindow
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Nome Tela
        private string _nomeTelaAtiva = "";
        public string NomeTelaAtiva
        {
            get => _nomeTelaAtiva;
            set
            {
                _nomeTelaAtiva = value;
                PropriedadeAlterada();
            }
        }
        #endregion

        #region Exibir Menu Navegação
        private Visibility _exibirMenuNavegacao = Visibility.Collapsed;
        public Visibility ExibirMenuNavegacao
        {
            get => _exibirMenuNavegacao;
            set
            {
                if (value != _exibirMenuNavegacao)
                {
                    _exibirMenuNavegacao = value;
                    PropriedadeAlterada(nameof(ExibirMenuNavegacao));
                    PropriedadeAlterada(nameof(TamanhoColunaMenuNavegacao));
                }
            }
        }

        public Microsoft.UI.Xaml.GridLength TamanhoColunaMenuNavegacao
        {
            get
            {
                return (_exibirMenuNavegacao == Visibility.Collapsed ? new Microsoft.UI.Xaml.GridLength(0) : new Microsoft.UI.Xaml.GridLength(82));
            }
        }
        #endregion

        public event EventHandler<eTela> NavegarParaPaginaRequested;

        public void NavegarPara(eTela tela)
        {
            NavegarParaPaginaRequested?.Invoke(this, tela);
        }

    }
}
