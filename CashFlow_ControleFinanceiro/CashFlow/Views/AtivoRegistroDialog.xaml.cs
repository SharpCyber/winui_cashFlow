using CashFlow.Application;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace CashFlow.Views
{
    public sealed partial class AtivoRegistroDialog : ContentDialog
    {
        #region Interfaces
        private readonly IAtivoRegistroDialogVM _ativoRegistroDialogVM;
        #endregion

        #region Propriedades
        private List<AtivoFinanceiro> Ativos = new List<AtivoFinanceiro>();
        private readonly int _delayPesquisa = 500;
        private CancellationTokenSource _cancellationTokenSource;
        private bool fecharDialog = true;
        #endregion

        #region Construtor
        public AtivoRegistroDialog()
        {
            InitializeComponent();

            _ativoRegistroDialogVM = Bootstrap.ServiceProvider.GetRequiredService<IAtivoRegistroDialogVM>();

            this.DataContext = _ativoRegistroDialogVM;
        }
        #endregion

        #region Eventos
        private void AtivoFinanceiro_Loaded(object sender, RoutedEventArgs e)
        {
            _ativoRegistroDialogVM.Items.Clear();

            Ativos.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 1, Codigo = "Teste 1", FK_TipoInvestimento = 1, Nome = "Teste 1 Nome", Ativo = true });
            Ativos.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 2, Codigo = "Teste 2", FK_TipoInvestimento = 2, Nome = "Teste 2 Nome", Ativo = true });
            Ativos.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 3, Codigo = "Teste 3", FK_TipoInvestimento = 3, Nome = "Teste 3 Nome", Ativo = true });
            Ativos.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 4, Codigo = "Teste 4", FK_TipoInvestimento = 4, Nome = "Teste 4 Nome", Ativo = true });

            //_ativoRegistroDialogVM.Items.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 1, Codigo = "Teste 1", FK_TipoInvestimento = 1, Nome = "Teste 1 Nome", Ativo = true });
            //_ativoRegistroDialogVM.Items.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 2, Codigo = "Teste 2", FK_TipoInvestimento = 2, Nome = "Teste 2 Nome", Ativo = true });
            //_ativoRegistroDialogVM.Items.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 3, Codigo = "Teste 3", FK_TipoInvestimento = 3, Nome = "Teste 3 Nome", Ativo = true });
            //_ativoRegistroDialogVM.Items.Add(new AtivoFinanceiro { PK_AtivoFinanceiro = 4, Codigo = "Teste 4", FK_TipoInvestimento = 4, Nome = "Teste 4 Nome", Ativo = true });

            _ativoRegistroDialogVM.ItemSelecionado = _ativoRegistroDialogVM.Items.FirstOrDefault();
        }
        private void AtivoFinanceiro_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
        private void AtivoFinanceiro_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }
        private void scroll_LayoutUpdated(object sender, object e)
        {

        }
        private void btnAjuda_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void txtPesquisarAtivo_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            try
            {
                _cancellationTokenSource?.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();

                if (txtPesquisarAtivo.Text.Trim() == "")
                {
                    return;
                }

                await Task.Delay(_delayPesquisa, _cancellationTokenSource.Token);

                if (!_cancellationTokenSource.IsCancellationRequested)
                {

                }
            }
            catch (TaskCanceledException)
            {

            }
        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
