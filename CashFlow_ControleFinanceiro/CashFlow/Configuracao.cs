using CashFlow.Domain.Enumeration;
using CashFlow.Views;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow
{
    public static class Configuracao
    {
        public static void AbrirTela(ePagina pagina, Frame frame)
        {
            switch (pagina)
            {
                case ePagina.Nenhuma:
                    break;
                case ePagina.Teste:
                    frame.Navigate(typeof(TestePage));
                    break;
                case ePagina.Dashboard:
                    frame.Navigate(typeof(DashboardPage));
                    break;
                case ePagina.Transacao:
                    frame.Navigate(typeof(TransacaoPage));
                    break;
                case ePagina.Investimento:
                    frame.Navigate(typeof(InvestimentoPage));
                    break;
                default:
                    break;
            }
        }
        public static async Task AbrirDialog(eDialogo dialogo, XamlRoot xamlRoot)
        {
            switch (dialogo)
            {
                case eDialogo.Nenhuma:
                    break;
                case eDialogo.AtivoFinanceiro:
                    await AbrirDialog(new AtivoFinanceiroDialog(), xamlRoot);
                    break;
                case eDialogo.EntidadeFinanceira:
                    await AbrirDialog(new EntidadeFinanceiraDialog(), xamlRoot);
                    break;
                case eDialogo.Categoria:
                    await AbrirDialog(new CategoriaDialog(), xamlRoot);
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
