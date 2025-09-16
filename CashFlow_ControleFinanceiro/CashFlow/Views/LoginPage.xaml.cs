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
using CashFlow.Domain.Enumeration;

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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is IMainWindowViewModel viewModel)
                _mainWindowViewModel = viewModel;
        }
        private void btnEntrarLogin_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowViewModel.NavegarPara(eTela.TransacaoPage, exibirMenuLateral: true);
        }
        private void btnEntrarLoginGoogle_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnRegistroVoltarLogin_Click(object sender, RoutedEventArgs e)
        {
            this.rLogin.Height = new GridLength();
            this.rRegistroUsuario.Height = new GridLength(0);
            this.rValidarEmail.Height = new GridLength(0);
            this.rRedefinirSenha.Height = new GridLength(0);
        }

        private void btnVoltarLogin_Click(object sender, RoutedEventArgs e)
        {
            this.rLogin.Height = new GridLength();
            this.rRegistroUsuario.Height = new GridLength(0);
            this.rValidarEmail.Height = new GridLength(0);
            this.rRedefinirSenha.Height = new GridLength(0);
        }

        private void btnCadastrarUsuario_Click(object sender, RoutedEventArgs e)
        {
            this.rLogin.Height = new GridLength(0);
            this.rRegistroUsuario.Height = new GridLength();
            this.rValidarEmail.Height = new GridLength(0);
            this.rRedefinirSenha.Height = new GridLength(0);
        }

        private void btnContinuarRedefinirSenha_Click(object sender, RoutedEventArgs e)
        {
            this.rLogin.Height = new GridLength(0);
            this.rRegistroUsuario.Height = new GridLength(0);
            this.rValidarEmail.Height = new GridLength(0);
            this.rRedefinirSenha.Height = new GridLength();
        }

        private void btnValidarEmail_Click(object sender, RoutedEventArgs e)
        {
            this.rLogin.Height = new GridLength(0);
            this.rRegistroUsuario.Height = new GridLength(0);
            this.rValidarEmail.Height = new GridLength();
            this.rRedefinirSenha.Height = new GridLength(0);
        }
        #endregion

        #region Metodos
        #endregion
    }
}
