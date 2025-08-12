using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using CashFlow.Application;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Helpers;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using CashFlow.ViewModel.CategoriaViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

namespace CashFlow.Views
{
    public sealed partial class CategoriaRegistroDialog : ContentDialog
    {
        #region Interfaces
        private readonly ICategoriaDialogVM _categoriaDialogViewModel;
        #endregion

        #region Propriedades
        private eTipoOperacao tipoOperacaoAtual = eTipoOperacao.Visualizar;
        #endregion

        #region Método Construtor
        public CategoriaRegistroDialog(ICategoriaDialogVM categoriaDialogViewModel)
        {
            InitializeComponent();

            _categoriaDialogViewModel = categoriaDialogViewModel;
            this.DataContext = _categoriaDialogViewModel;
        }
        #endregion

        #region Eventos
        private void Categoria_Loaded(object sender, RoutedEventArgs e)
        {
            _categoriaDialogViewModel.Items.Clear();

            _categoriaDialogViewModel.Items.Add(new Categoria { PK_Categoria = 0, Nome = "" });
            _categoriaDialogViewModel.Items.Add(new Categoria { PK_Categoria = 1, Nome = "Alimentação" });
            _categoriaDialogViewModel.Items.Add(new Categoria { PK_Categoria = 2, Nome = "Transporte" });
            _categoriaDialogViewModel.Items.Add(new Categoria { PK_Categoria = 3, Nome = "Lazer" });

            _categoriaDialogViewModel.ItemSelecionado = _categoriaDialogViewModel.Items.FirstOrDefault();
            
            ExecutarOperacao(tipoOperacaoAtual);
        }
        private void Categoria_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            
        }
        private void Categoria_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
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
                    "As categorias são como etiquetas que você cria para organizar suas entidades financeiras.\n\n" +
                    "Exemplo: Agrupe 'Netflix' e 'Spotify' na categoria 'Assinaturas'.";

                Aviso.MostrarComBotao(spAjuda, mensagem, eTipoMensagem.Informacao, TextWrapping.Wrap);
            }
            else
            {
                Aviso.Ocultar(spAjuda);
            }
        }
        #endregion

        #region Metodos
        private void ExecutarOperacao(eTipoOperacao eTipoOperacao)
        {
            tipoOperacaoAtual = eTipoOperacao;
            _categoriaDialogViewModel.DefinirOperacao(tipoOperacaoAtual);

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
                        "Tem certeza que deseja realizar a exclusão da categoria?\nEssa operação não poderá ser desfeita.", 
                        eTipoMensagem.Informacao);

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
