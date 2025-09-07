using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.ViewModel.Login
{
    public class LoginViewModel : ViewModelBase, ILoginViewModel
    {
        private eLoginOperacao loginOperacaoAtual = eLoginOperacao.Login;

        public void NavegarPara(eLoginOperacao loginOperacao)
        {
            this.loginOperacaoAtual = loginOperacao;

            switch (loginOperacao)
            {
                case eLoginOperacao.Login:
                    break;
                case eLoginOperacao.Registrar:
                    break;
                case eLoginOperacao.RecuperarSenha:
                    break;
                case eLoginOperacao.TrocarSenha:
                    break;
                case eLoginOperacao.LoginGoogle:
                    break;
                default:
                    break;
            }
        }
    }
}
