using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using CashFlow.Views;
using Microsoft.Extensions.DependencyInjection;
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
        public static void AbrirTela(ePagina pagina, Frame frame, eTipoOperacao tipoOperacao = eTipoOperacao.Visualizar)
        {
            switch (pagina)
            {
                case ePagina.Nenhuma:
                    break;
                case ePagina.Teste:
                    frame.Navigate(typeof(TestePage), tipoOperacao);
                    break;
                case ePagina.Dashboard:
                    frame.Navigate(typeof(DashboardPage), tipoOperacao);
                    break;
                case ePagina.Transacao:
                    frame.Navigate(typeof(TransacaoPage), tipoOperacao);
                    break;
                case ePagina.Investimento:
                    frame.Navigate(typeof(InvestimentoPage), tipoOperacao);
                    break;
                case ePagina.TransacaoRegistro:
                    frame.Navigate(typeof(TransacaoRegistroPage), tipoOperacao);
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
                    await AbrirDialog(new AtivoRegistroDialog(), xamlRoot);
                    break;
                case eDialogo.EntidadeFinanceira:
                    var entidadeFinanceiraDialogViewModel = Bootstrap.ServiceProvider.GetRequiredService<IEntidadeRegistroDialogVM>();

                    await AbrirDialog(new EntidadeRegistroDialog(entidadeFinanceiraDialogViewModel), xamlRoot);
                    break;
                case eDialogo.Categoria:
                    var categoriaDialogViewModel = Bootstrap.ServiceProvider.GetRequiredService<ICategoriaDialogVM>();

                    await AbrirDialog(new CategoriaRegistroDialog(categoriaDialogViewModel), xamlRoot);
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
