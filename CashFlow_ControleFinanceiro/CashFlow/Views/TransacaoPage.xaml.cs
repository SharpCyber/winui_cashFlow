using CashFlow.Application;
using CashFlow.Domain.Entity;
using CashFlow.Domain.Interfaces;
using CashFlow.Domain.Interfaces.ViewModels;
using CashFlow.ViewModel.TransacaoPage;
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
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace CashFlow.Views
{
    public sealed partial class TransacaoPage : Page
    {
        #region Interfaces
        private readonly ITransacaoPageViewModel _transacaoPageViewModel;
        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        public TransacaoPage()
        {
            InitializeComponent();

            _transacaoPageViewModel = Bootstrap.ServiceProvider.GetRequiredService<ITransacaoPageViewModel>();

            this.DataContext = _transacaoPageViewModel;
        }
        #endregion

        #region Eventos
        private void pageTransacao_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void gStatusGeral_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        private void btnOrdenacao_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void scroll_LayoutUpdated(object sender, object e)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
