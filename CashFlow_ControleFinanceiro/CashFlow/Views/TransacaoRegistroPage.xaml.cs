using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Windows.Globalization.NumberFormatting;
using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Helpers;
using CashFlow.Domain.Interfaces;
using CashFlow.ViewModel.TransacaoRegistroViewModel;

namespace CashFlow.Views
{
    public sealed partial class TransacaoRegistroPage : Page
    {
        #region Interfaces
        private readonly ITransacaoRegistroPageVM _transacaoRegistroPageVM;
        #endregion

        #region Propriedades
        private eTipoOperacao tipoOperacaoAtual = eTipoOperacao.Visualizar;
        #endregion

        #region Método Construtor
        public TransacaoRegistroPage()
        {
            InitializeComponent();

            _transacaoRegistroPageVM = Bootstrap.ServiceProvider.GetRequiredService<ITransacaoRegistroPageVM>();

            this.DataContext = _transacaoRegistroPageVM;
        }
        #endregion

        #region Eventos
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is eTipoOperacao tipoOperacao) 
                tipoOperacaoAtual = tipoOperacao;
        }
        private void Page_Loading(FrameworkElement sender, object args)
        {
            CarregarDropDowns();
            DefinirPadronizacaoDosComponentes();
        }
        private async void btnAdicionarEntidade_Click(object sender, RoutedEventArgs e)
        {
            await Configuracao.AbrirDialog(eDialogo.EntidadeFinanceira, this.Content.XamlRoot);
        }
        private void VencimentoCheckBox_Changed(object sender, RoutedEventArgs e)
        {

        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }
        private void chkDataVencimento_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void chkDataVencimento_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void btnAdicionarAtivo_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            ExecutarOperacao(eTipoOperacao.Adicionar);
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            ExecutarOperacao(eTipoOperacao.Alterar);
        }
        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            ExecutarOperacao(eTipoOperacao.Deletar);
        }
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            ExecutarOperacao(eTipoOperacao.Visualizar);
        }
        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ExecutarOperacao(eTipoOperacao.Salvar);
        }
        private void btnAjuda_Click(object sender, RoutedEventArgs e)
        {
            //if (spAjuda.Visibility != Visibility.Visible)
            //{
            //    string mensagem = "" +
            //        "Uma transação financeira representa a entrada ou saída de dinheiro.\n\n" +
            //        "";

            //    Aviso.MostrarComBotao(spAjuda, mensagem, eTipoMensagem.Informacao, TextWrapping.Wrap);
            //}
            //else
            //{
            //    Aviso.Ocultar(spAjuda);
            //}
        }
        #endregion

        #region Metodos
        private void CarregarDropDowns()
        {
            CarregarTipoTransacao();
        }
        private void CarregarTipoTransacao()
        {
            _transacaoRegistroPageVM.TipoTransacaoCollection.Clear();

            _transacaoRegistroPageVM.TipoTransacaoCollection.Add(new Domain.Entity.TipoTransacao { PK_TipoTransacao = 1, Nome = "Entrada" });
            _transacaoRegistroPageVM.TipoTransacaoCollection.Add(new Domain.Entity.TipoTransacao { PK_TipoTransacao = 2, Nome = "Saída" });

            _transacaoRegistroPageVM.TipoTransacaoSelecionada = _transacaoRegistroPageVM.TipoTransacaoCollection.FirstOrDefault();
        }
        private void CarregarTipoEntidadeFinanceira()
        {

        }
        private void DefinirPadronizacaoDosComponentes()
        {
            DefinirPadraoValorTotal();
        }
        private void DefinirPadraoValorTotal()
        {
            //txtValorTotal.NumberFormatter = new DecimalFormatter(new[] { "pt-BR" }, "BR")
            //{
            //    IsGrouped = true,
            //    FractionDigits = 2
            //};
        }
        private void ExecutarOperacao(eTipoOperacao eTipoOperacao)
        {
            tipoOperacaoAtual = eTipoOperacao;
            _transacaoRegistroPageVM.DefinirOperacao(tipoOperacaoAtual);

            // Aviso.Ocultar(spAviso);

            switch (tipoOperacaoAtual)
            {
                case eTipoOperacao.Nenhuma:
                    break;
                case eTipoOperacao.Visualizar:
                    break;
                case eTipoOperacao.Adicionar:
                    break;
                case eTipoOperacao.Salvar:
                    break;
                case eTipoOperacao.Alterar:
                    break;
                case eTipoOperacao.Deletar:

                    //Aviso.Mostrar(
                    //    spAviso,
                    //    "Tem certeza que deseja realizar a exclusão da categoria?\nEssa operação não poderá ser desfeita.",
                    //    eTipoMensagem.Informacao);

                    break;
                case eTipoOperacao.Cancelar:
                    break;
                case eTipoOperacao.Confirmar:
                    break;
                default:
                    break;
            }
        }
        #endregion

        private void gStatusGeral_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}