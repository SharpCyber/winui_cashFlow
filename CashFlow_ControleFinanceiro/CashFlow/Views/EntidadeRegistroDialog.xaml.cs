using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CashFlow.Application;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Helpers;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.ViewModels;

namespace CashFlow.Views
{
    public sealed partial class EntidadeRegistroDialog : ContentDialog
    {
        #region Interfaces
        private readonly IEntidadeRegistroDialogViewModel _entidadeRegistroDialogViewModel;
        #endregion

        #region Propriedades
        private eTipoOperacao tipoOperacaoAtual = eTipoOperacao.Visualizar;
        #endregion

        #region Método Construtor
        public EntidadeRegistroDialog()
        {
            InitializeComponent();

            _entidadeRegistroDialogViewModel = Bootstrap.ServiceProvider.GetRequiredService<IEntidadeRegistroDialogViewModel>();

            this.DataContext = _entidadeRegistroDialogViewModel;
        }
        #endregion

        #region Eventos
        private void EntidadeFinanceira_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarDropDowns();

            ExecutarOperacao(tipoOperacaoAtual);
        }
        private void EntidadeFinanceira_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
        private void EntidadeFinanceira_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
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
            if (spAjuda.Visibility != Visibility.Visible)
            {
                string mensagem = "" +
                    "A 'Entidade Financeira' é a identificação da origem ou o destino de uma transação (pessoa física, jurídica ou governamental).\n\n" +
                    "Exemplos: 'Netflix', 'Padaria Pão Quente', 'Dra. Maria (Dentista)', 'Cliente José'.";

                Aviso.MostrarComBotao(spAjuda, mensagem, eTipoMensagem.Informacao, TextWrapping.Wrap);
            }
            else
            {
                Aviso.Ocultar(spAjuda);
            }
        }
        #endregion

        #region Metodos
        private void CarregarDropDowns()
        {
            CarregarEntidadeFinanceira();
            CarregarCategoria();
        }
        private void CarregarEntidadeFinanceira()
        {
            _entidadeRegistroDialogViewModel.Items.Clear();

            _entidadeRegistroDialogViewModel.Items.Add(new EntidadeFinanceira { PK_EntidadeFinanceira = 1, Nome = "Teste 1" });
            _entidadeRegistroDialogViewModel.Items.Add(new EntidadeFinanceira { PK_EntidadeFinanceira = 2, Nome = "Teste 2" });
            _entidadeRegistroDialogViewModel.Items.Add(new EntidadeFinanceira { PK_EntidadeFinanceira = 3, Nome = "Teste 3" });

            cboEntidadeFinanceira.SelectedIndex = 0;
        }

        private void CarregarCategoria()
        {
            _entidadeRegistroDialogViewModel.CategoriaCollection.Clear();

            _entidadeRegistroDialogViewModel.CategoriaCollection.Add(new Categoria { PK_Categoria = 1, Nome = "Teste 1" });
            _entidadeRegistroDialogViewModel.CategoriaCollection.Add(new Categoria { PK_Categoria = 2, Nome = "Teste 2" });
            _entidadeRegistroDialogViewModel.CategoriaCollection.Add(new Categoria { PK_Categoria = 3, Nome = "Teste 3" });

            cboCategoria.SelectedIndex = 0;
        }
        private void ExecutarOperacao(eTipoOperacao eTipoOperacao)
        {
            tipoOperacaoAtual = eTipoOperacao;
            _entidadeRegistroDialogViewModel.DefinirOperacao(tipoOperacaoAtual);

            Aviso.Ocultar(spAviso);

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
                    Aviso.Mostrar(
                        spAviso,
                        "Tem certeza que deseja realizar a exclusão da entidade?\n\nEssa operação não poderá ser desfeita.",
                        eTipoMensagem.Informacao,
                        TextWrapping.Wrap);
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
    }
}
