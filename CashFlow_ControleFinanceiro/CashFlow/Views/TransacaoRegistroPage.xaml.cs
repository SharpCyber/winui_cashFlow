using CashFlow.Application;
using CashFlow.Domain.Enumeration;
using CashFlow.Domain.Interfaces;
using CashFlow.ViewModel.TransacaoRegistroViewModel;
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
        private void Page_Loading(FrameworkElement sender, object args)
        {
            _transacaoRegistroPageVM.TipoTransacaoCollection.Clear();

            _transacaoRegistroPageVM.TipoTransacaoCollection.Add(new Domain.Entity.TipoTransacao { PK_TipoTransacao = 1, Nome = "Entrada" });
            _transacaoRegistroPageVM.TipoTransacaoCollection.Add(new Domain.Entity.TipoTransacao { PK_TipoTransacao = 2, Nome = "Saída" });

            _transacaoRegistroPageVM.TipoTransacaoSelecionada = _transacaoRegistroPageVM.TipoTransacaoCollection.FirstOrDefault();
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
            txtEntidade.Text = "Size: " + this.XamlRoot.Size.Width;
        }

        private void chkDataVencimento_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void chkDataVencimento_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Metodos
        #endregion


    }
}
