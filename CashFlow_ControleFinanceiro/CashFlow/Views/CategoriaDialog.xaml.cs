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
using CashFlow.ViewModel.CategoriaViewModel;
using CashFlow.Domain.Interfaces;
using CashFlow.Application;
using Microsoft.Extensions.DependencyInjection;
using CashFlow.Domain.Entity;

namespace CashFlow.Views
{
    public sealed partial class CategoriaDialog : ContentDialog
    {
        #region Interfaces
        private readonly ICategoriaDialogViewModel _categoriaDialogViewModel;
        #endregion

        #region Propriedades
        #endregion

        #region Método Construtor
        public CategoriaDialog(ICategoriaDialogViewModel categoriaDialogViewModel)
        {
            InitializeComponent();

            _categoriaDialogViewModel = categoriaDialogViewModel;
            this.DataContext = _categoriaDialogViewModel;
        }
        #endregion

        #region Eventos
        private void Categoria_Loaded(object sender, RoutedEventArgs e)
        {
            _categoriaDialogViewModel.Categorias.Add(new Categoria { PK_Categoria = 0, Nome = "" });
            _categoriaDialogViewModel.Categorias.Add(new Categoria { PK_Categoria = 1, Nome = "Alimentação" });
            _categoriaDialogViewModel.Categorias.Add(new Categoria { PK_Categoria = 2, Nome = "Transporte" });
            _categoriaDialogViewModel.Categorias.Add(new Categoria { PK_Categoria = 3, Nome = "Lazer" });
        }
        private void Categoria_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {

        }
        private void Categoria_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
        }
        #endregion

        #region Metodos

        #endregion
    }
}
