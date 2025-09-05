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
using Windows.Foundation.Collections;
using Windows.Foundation;
using CashFlow.Domain.Interfaces.ViewModels;
using CashFlow.ViewModel.MainWindow;

namespace CashFlow.Views
{
    public sealed partial class LoginPage : Page
    {
        #region Interfaces
        private IMainWindowViewModel _mainWindowViewModel;
        #endregion

        #region Propriedades
        #endregion

        #region Construtor
        public LoginPage()
        {
            InitializeComponent();
        }
        #endregion

        #region Eventos
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.ExibirMenuNavegacao = Visibility.Visible;
            (_mainWindowViewModel as MainWindowViewModel)?.NavegarPara(Domain.Enumeration.eTela.TransacaoPage);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is IMainWindowViewModel viewModel)
            {
                _mainWindowViewModel = viewModel;
            }
        }
        private void btnLoginGoogle_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {

        }
        private void hlbEsqueciMinhaSenha_Click(object sender, RoutedEventArgs e)
        {

        }
        private void hlbCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Metodos
        #endregion
    }
}
