using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.ViewModels;
using CashFlow.Views;

namespace CashFlow
{
    public static class Configuracao
    {
        public static void AbrirTela(eTela tela, Frame frame, eTipoOperacao tipoOperacao = eTipoOperacao.Visualizar, IMainWindowViewModel mainWindowViewModel = null)
        {
            switch (tela)
            {
                case eTela.Nenhuma:
                    break;
                case eTela.LoginPage:
                    frame.Navigate(typeof(LoginPage), mainWindowViewModel);
                    break;
                case eTela.TransacaoPage:
                    frame.Navigate(typeof(TransacaoPage), tipoOperacao);
                    break;
                case eTela.TransacaoRegistroPage:
                    frame.Navigate(typeof(TransacaoRegistroPage), tipoOperacao);
                    break;

                default:
                    break;
            }
        }
        public static async Task AbrirDialog(eTela tela, XamlRoot xamlRoot)
        {
            switch (tela)
            {
                case eTela.Nenhuma:
                    break;
                case eTela.AtivoFinanceiroDialog:
                    await AbrirDialog(new AtivoRegistroDialog(), xamlRoot);
                    break;
                case eTela.EntidadeFinanceiraDialog:
                    await AbrirDialog(new EntidadeRegistroDialog(), xamlRoot);
                    break;
                case eTela.CategoriaDialog:
                    await AbrirDialog(new CategoriaRegistroDialog(), xamlRoot);
                    break;
                default:
                    break;
            }
        }

        private static async Task AbrirDialog(ContentDialog dialog, XamlRoot xamlRoot)
        {
            dialog.XamlRoot = xamlRoot;
            dialog.HorizontalAlignment = HorizontalAlignment.Center;
            dialog.VerticalAlignment = VerticalAlignment.Center;

            await dialog.ShowAsync();
        }
    }
}
