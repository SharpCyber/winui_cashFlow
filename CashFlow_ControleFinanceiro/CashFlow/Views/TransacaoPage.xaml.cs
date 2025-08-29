using CashFlow.Application;
using CashFlow.Domain.Interfaces;
using CashFlow.ViewModel.TransacaoPageViewModel;
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
        private readonly ITransacaoPageVM transacaoPageVM;
        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        public TransacaoPage()
        {
            InitializeComponent();

            transacaoPageVM = Bootstrap.ServiceProvider.GetRequiredService<ITransacaoPageVM>();
            this.DataContext = transacaoPageVM;
        }
        #endregion

        #region Eventos
        private void gStatusGeral_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
